﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Kernys.Bson;
using System.Linq;
using SevenZip;
using PWS.DataManagement;
using System.Threading;
using System.Collections.Concurrent;
using System.Security.Cryptography;

namespace PWS
{
    public static class RandomExtensions
    {
        public static double NextDouble(
            this Random random,
            double minValue,
            double maxValue)
        {
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }

    public class Util
    {
        public static Networking.Server.PWServer staticServer = null;
        private static Thread loggerThread = new Thread(Logger);
        private static ConcurrentQueue<string> logQueue = new ConcurrentQueue<string>();

        private static void HandleConsoleInput(string input)
        {
            string[] vs = input.Split(' ');

            staticServer.ConsoleCommand(vs);
        }

        private static bool runningLogger = true;

        private static void CheckInput()
        {
            while (Console.KeyAvailable)
            {
                string input = Console.ReadLine();
                Util.Log("Admin Console > '" + input + "'");
                HandleConsoleInput(input);
            }
        }
        private static void Logger()
        {
            bool hadOutput = false;
            string outLog = "";

            while (runningLogger)
            {
                CheckInput();

                string toLog = "";

                while (logQueue.TryDequeue(out outLog))
                    toLog += "\n" + outLog;

                if (toLog.Length > 0)
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write(new String(' ', Console.BufferWidth));

                    Console.WriteLine(toLog);
                    File.AppendAllText("log.txt", toLog);
                    Console.Out.Flush();

                    hadOutput = true;
                }
                else if (toLog.Length == 0 && hadOutput)
                {
                    hadOutput = false;

                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write(new String(' ', Console.BufferWidth));

                    Console.Write("Admin Console > ");
                    Console.Out.Flush();
                }
              
                Thread.Sleep(50);
            }
        }

        public static void StartLogger(Networking.Server.PWServer pServer)
        {
            staticServer = pServer;
            loggerThread.Start();
        }

        public static void StopLogger()
        {
            runningLogger = false;
            loggerThread.Join();
        }
       
        public static bool IsFileReady(string filename)
        {
            // If the file can be opened for exclusive access it means that the file
            // is no longer locked by another process.
            try
            {
                using (FileStream inputStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
                    return inputStream.Length > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Random rand = new Random();

        public static BSONObject CreateChatMessage(string nickname, string userID, string channel, int channelIndex, string message)
        {
            BSONObject bObj = new BSONObject();
            bObj[MsgLabels.ChatMessage.Nickname] = nickname;
            bObj[MsgLabels.ChatMessage.UserID] = userID;
            bObj[MsgLabels.ChatMessage.Channel] = channel;
            bObj["channelIndex"] = channelIndex;
            bObj[MsgLabels.ChatMessage.Message] = message;
            bObj[MsgLabels.ChatMessage.ChatTime] = DateTime.UtcNow;
            return bObj;
        }

        public static string RandomString(int length)
        {
            string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";

            char[] letters = new char[length];
            for (int i = 0; i < length; i++)
            {
                letters[i] = allowedChars[rand.Next(allowedChars.Length)];
            }
            return new string(letters);
        }

        public static void LogBinary(byte[] bin)
        {
            Util.Log(String.Format("{0:X2}", Convert.ToUInt64(bin)));
        }
        public static void Log(string text)
        {
            logQueue.Enqueue("[SERVER at " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "]: " + text);
        }

        public static long GetKukouriTime()
        {
            return (DateTime.UtcNow - default(TimeSpan)).Ticks;
        }

        public static long GetMs()
        {
            return DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }

        public static long GetSec()
        {
            return DateTimeOffset.Now.ToUnixTimeSeconds();
        }

        public class TextScanner
        {
            public TextScanner(string str, char separator = '|')
            {
                string[] lines = str.Split('\n');

                foreach (string line in lines)
                {
                    string[] rows = line.Split(separator);
                    table.Add(rows);
                }
            }

            public string[] GetRows(int column = 0)
            {
                return column < table.Count ? table[column] : null;
            }

            public string Get(int row = 0, int column = 0)
            {
                string[] rows = GetRows(column);

                if (rows == null)
                    return "";

                return rows.Length > row ? rows[row] : "";
            }

            public string[] Get(string key, int offset = 0)
            {
                int cur = 0;
                foreach (string[] arr in table)
                {
                    if (arr.Length < 1)
                        continue;

                    if (arr[0] == key && offset == cur) 
                    {
                        return arr.Skip(1).ToArray();
                    }
                    else if (arr[0] == key)
                    {
                        cur++;
                    }
                }

                return null;
            }

            // get the simple neighboured value from the key:

            public T GetValueFromKey<T>(string key, int offset = 0)
            {
                string[] v = Get(key, offset);

                if (v != null)
                {
                    var tCode = Type.GetTypeCode(typeof(T));
                    switch (tCode)
                    {
                      
                        case TypeCode.Double:
                            return (T)(object)double.Parse(v[0]);

                        case TypeCode.Int32:
                            return (T)(object)int.Parse(v[0]);

                        case TypeCode.String:
                            return (T)(object)v[0];

                        default:
                            break;
                    }
                    throw new Exception($"TextScanner type not implemented (Type: {(int)tCode})");
                }

                throw new Exception("Non existing key or bad offset.");
            }

            List<string[]> table = new List<string[]>();
        }

        public static void LogBSONInDepth(BSONObject bObj, bool appendToFile = false)
        {
            string data = "====================\n";
            foreach (string key in bObj.Keys)
            {
                BSONValue bVal = bObj[key];

                switch (bVal.valueType)
                {
                    case BSONValue.ValueType.String:
                        data += "\t[BSON] >> KEY: " + key + " VALUE: " + bVal.stringValue + "\n";
                        break;
                    case BSONValue.ValueType.Object:
                        {
                            if (bVal is BSONObject)
                            {
                                data += "\t[BSON] >> KEY: " + key + " VALUE: (is bsonobject)\n";
                                LogBSONInDepth(bVal as BSONObject, true);
                            }
                            else
                            {
                                data += "\t[BSON] >> KEY: " + key + " VALUE: (is object)\n";
                            }
                            // that object related shit is more complex so im gonna leave that for later
                            break;
                        }
                    case BSONValue.ValueType.Array:
                        {

                            data += "\t[BSON] >> KEY: " + key + " VALUE: (is array)\n";
                            break;
                        }
                    case BSONValue.ValueType.Int32:
                        data += "\t[BSON] >> KEY: " + key + " VALUE: " + bVal.int32Value.ToString() + "\n";
                        break;
                    case BSONValue.ValueType.Int64:
                        data += "\t[BSON] >> KEY: " + key + " VALUE: " + bVal.int64Value.ToString() + "\n";
                        break;
                    case BSONValue.ValueType.Double:
                        data += "\t[BSON] >> KEY: " + key + " VALUE: " + bVal.doubleValue.ToString() + "\n";
                        break;
                    case BSONValue.ValueType.Boolean:
                        data += "\t[BSON] >> KEY: " + key + " VALUE: " + bVal.boolValue.ToString() + "\n";
                        break;

                    default:
                        data += "\t[BSON] >> KEY: " + key + " VALUE TYPE: " + bVal.valueType.ToString() + "\n";
                        break;
                }
            }
            data += "====================\n";
            Util.Log(data);

            if (appendToFile)
                File.AppendAllText("bsonlogs.txt", data);
        }

        public class LZMAHelper
        {
            public static void CompressFileLZMA(string inFile, string outFile)
            {
                SevenZip.Compression.LZMA.Encoder coder = new SevenZip.Compression.LZMA.Encoder();
                FileStream input = new FileStream(inFile, FileMode.Open);
                FileStream output = new FileStream(outFile, FileMode.Create);

                // Write the encoder properties
                coder.WriteCoderProperties(output);

                // Write the decompressed file size.
                output.Write(BitConverter.GetBytes(input.Length), 0, 8);

                // Encode the file.
                coder.Code(input, output, input.Length, -1, null);
                output.Flush();
                output.Close();
            }

            public static byte[] CompressLZMA(byte[] compressed)
            {
                SevenZip.Compression.LZMA.Encoder encoder = new SevenZip.Compression.LZMA.Encoder();

                using (Stream input = new MemoryStream(compressed))
                {
                    using (Stream output = new MemoryStream(512000)) // more optimized...
                    {
                        encoder.SetCoderProperties(new CoderPropID[]
                        {
                        CoderPropID.DictionarySize
                        }, new object[]
                        {
                        (int)512000
                        });

                        encoder.WriteCoderProperties(output);
                        output.Write(BitConverter.GetBytes(input.Length), 0, 8);
                        encoder.Code(input, output, input.Length, -1L, null);

                        output.Flush();

                        return ((MemoryStream)output).ToArray();
                    }
                }
            }

            public static byte[] DecompressLZMA(byte[] compressed)
            {
                SevenZip.Compression.LZMA.Decoder coder = new SevenZip.Compression.LZMA.Decoder();

                long fileLength = BitConverter.ToInt64(compressed, 5);

                using (Stream input = new MemoryStream(compressed))
                {
                    using (Stream output = new MemoryStream((int)fileLength)) // more optimized...
                    {

                        byte[] properties = new byte[5];
                        input.Read(properties);


                        byte[] sig = new byte[8]; // actually the length, again... :/
                        input.Read(sig);

                        coder.SetDecoderProperties(properties);
                        coder.Code(input, output, input.Length, fileLength, null);
                        output.Flush();

                        return ((MemoryStream)output).ToArray();
                    }
                }
            }

            public static void DecompressFileLZMA(string inFile, string outFile)
            {
                SevenZip.Compression.LZMA.Decoder coder = new SevenZip.Compression.LZMA.Decoder();
                FileStream input = new FileStream(inFile, FileMode.Open);
                FileStream output = new FileStream(outFile, FileMode.Create);

                // Read the decoder properties
                byte[] properties = new byte[5];
                input.Read(properties, 0, 5);

                // Read in the decompress file size.
                byte[] fileLengthBytes = new byte[8];
                input.Read(fileLengthBytes, 0, 8);
                long fileLength = BitConverter.ToInt64(fileLengthBytes, 0);

                coder.SetDecoderProperties(properties);
                coder.Code(input, output, input.Length, fileLength, null);
                output.Flush();
                output.Close();
                input.Close();
            }
        }

        public static string HashCredentials_SHA256(string input)
        {
            if (string.IsNullOrEmpty(input)) { return string.Empty; }

            // Create a SHA256 instance
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert the byte array to a hexadecimal string
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
