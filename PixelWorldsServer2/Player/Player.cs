using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using FeatherNet;
using Kernys.Bson;
using PWS.DataManagement;
using PWS.Networking.Server;
using BasicTypes;
using System.Text.Json;
using static PWS.Constants.Enums;

namespace PWS
{
    public class Player
    {
        private PWServer pServer = null;
        public PlayerSettings pSettings = null;
        public ACT act = null;
        public bool isInGame = false; // when the player has logon and is inside.
        public bool sendPing = false;
        public bool isLoadingWorld = false;
        public string ClientID { get { try { return this.Data.UserID.ToString("X8"); } catch { return "0"; } } }
        public Vector2i CurrentMP { get { try { return World.WorldSession.ConvertWorldPointToMapPoint((float)this.Data.PosX, (float)this.Data.PosY); } catch { return new Vector2i(-1, -1); } } }
        public bool IsOnline() => isInGame && Client != null;
        public Vector2i PreviousMp = new Vector2i(40, 30);
        public struct PlayerData
        {
            //not sorted
            public Player player;
            public InventoryHelper InvHelper;
            public Dictionary<int, short> Inventory;
            public BSONObject BSON;
            public List<string> recentlyVisited;
            public Dictionary<string, DateTime> worldBans;
            public List<string> bansDetails;
            public List<string> warnsDetails;
            public List<string> givenBansDetails;
            public List<string> givenWarnsDetails;

            //numbers
            public uint UserID;
            public int Gems, Coins;
            public double PosX, PosY;
            public int Anim, Dir;
            public int OPStatus;
            public int BPl;
            public int countryCode;
            public int Gnd;
            public int skinColor;
            public int invslots;
            public int banCount;
            public int warnCount;
            public long banEndTime;
            public int gender;
            public int level;
            public int possibleHacks;
            public int SCI;
            public int SCIbo;
            //strings
            public string CognitoID, Token;
            public string Name;
            public string LastIP;
            public string banReason;
            public string password;

            //booleans
            public bool respawning;
            public bool isInvis; //for later
            public bool justRegistered;
            public bool suspended;
            public bool isBanned;
            public bool showFirstTimeReg;
            public bool adminWantsToBeSummoned; //Not for db
            public bool adminInEditWorldMode; //Not for db

            //time
            public DateTime AccountCreationDate { get; set; }
            public long beenInsideBlockFor;
            public long lastHit;
            public DateTime VIPEndTime { get; set; }
            public DateTime LoginTime { get; private set; }
            public int XP;
            public Player.RecentWorlds recentWorlds;
            public void SetLoginTime() //NOT USED!!!
            {
                LoginTime = DateTime.Now;
            }
        }

        private PlayerData pData; // basically acts like a save, this is not the data that is assigned to the FeatherNet session itself.
        private FeatherClient fClient = null;
        private List<BSONObject> packets = new List<BSONObject>();
        public World.WorldSession world = null;

        public class RecentWorlds
        {
            public Stack<string> WorldNames = new Stack<string>();
            public Stack<string> WorldIds = new Stack<string>();
        }

        public string GetWorldName()
        {
            if (world == null)
                return "[WORLD MENU]";

            return world == null ? "<World Menu>" : world.WorldName;
        }

        public bool InWorld()
        {
            return world != null;
        }
        public Player(FeatherClient fClient = null)
        {
            if (fClient != null)
            {
                this.fClient = fClient;
                pServer = fClient.link as PWServer;
                //   this.pSettings = new PlayerSettings();

                pData.player = this;
                pData.UserID = 0;
                pData.Gems = 0;
                pData.Coins = 0;
                pData.CognitoID = "";
                pData.level = 1;
                pData.XP = 0;
                pData.Token = "";
                pData.warnCount = 0;
                pData.banCount = 0;
                pData.recentlyVisited = new List<string>();
                pData.countryCode = 0;
                pData.skinColor = 0;
                pData.gender = 0;
                pData.Name = "";
                pData.LastIP = "0.0.0.0";
                pData.Inventory = new Dictionary<int, short>();
                pData.BSON = new BSONObject();
                pData.OPStatus = 0;
                pData.worldBans = new Dictionary<string, DateTime>();
                pData.adminWantsToBeSummoned = true;
                //  pData.countryCode = 999;
                //   pData.SCI = 7;
                //   pData.Gnd = 0;

                //DateTime VIPExpirationDate { get; set; }
                //TimeSpan AccountAge => DateTime.Now - AccountCreationDate;

                fClient.data = pData; // interlink
                act = new ACT(this);
            }
        }
        public Player(SQLiteDataReader reader)
        {
            pData.player = this;
            pData.UserID = (uint)(long)reader["ID"];
            pData.Gems = (int)reader["Gems"];
            pData.Coins = (int)reader["ByteCoins"];
            pData.Name = (string)reader["Name"];
            pData.XP = (int)reader["XP"];
            pData.gender = (int)reader["gender"];
            pData.beenInsideBlockFor = 0;
            pData.respawning = false;
            pData.countryCode = (int)reader["countryCode"];
            pData.skinColor = (int)reader["skinColor"];
            pData.suspended = false;
            pData.level = (int)reader["level"];
            pData.warnCount = (int)reader["warnCount"];
            pData.banCount = (int)reader["banCount"];
            pData.showFirstTimeReg = false;
            pData.LastIP = (string)reader["IP"];
            pData.OPStatus = (int)reader["OPStatus"];
            pData.lastHit = 0;
            pData.possibleHacks = 0;
            pData.worldBans = new Dictionary<string, DateTime>();
            pData.adminWantsToBeSummoned = true;

            object inven = reader["Inventory"];
            byte[] invData = null;

            if (inven != DBNull.Value)
                invData = (byte[])inven;

            object bsonObj = reader["Inventory"];
            byte[] bsonData = null;

            if (bsonObj != DBNull.Value)
                bsonData = (byte[])bsonObj;

            if (bsonData != null)
            {
                try
                {
                    pData.BSON = SimpleBSON.Load(bsonData);
                }
                catch
                {
                    pData.BSON = new BSONObject();
                }
            }
            else
            {
                pData.BSON = new BSONObject();
            }


            pData.Inventory = new Dictionary<int, short>();
            Data.InvHelper = new InventoryHelper(this);
            Data.InvHelper.InitInventoryFromBinary(invData);

            if (!reader.IsDBNull(reader.GetOrdinal("Pass")))
            {
                if (!string.IsNullOrEmpty((string)reader["Pass"]))
                {
                    pData.password = (string)reader["Pass"];
                }
            }

            if (!reader.IsDBNull(reader.GetOrdinal("recentlyVisited")))
            {
                string worldNamesString = reader["recentlyVisited"].ToString();
                List<string> worldNamesList = worldNamesString.Split(',').ToList();
                pData.recentlyVisited = worldNamesList;
            }


            if (!reader.IsDBNull(reader.GetOrdinal("WorldBans")))
            {
                pData.worldBans = JsonSerializer.Deserialize<Dictionary<string, DateTime>>(reader["WorldBans"].ToString());
            }
            else
                pData.worldBans = new();

            if (!reader.IsDBNull(reader.GetOrdinal("Ban")))
            {
                var ban = JsonSerializer.Deserialize<List<string>>(reader["Ban"].ToString());
                pData.isBanned = true;
                pData.banReason = ban[0];
                pData.banEndTime = long.Parse(ban[1]);

                if (DateTime.UtcNow.CompareTo(new DateTime(pData.banEndTime)) > 0)
                {
                    pData.isBanned = false;
                }
            }

            if (!reader.IsDBNull(reader.GetOrdinal("BansDetails")))
            {
                pData.bansDetails = JsonSerializer.Deserialize<List<string>>(reader["BansDetails"].ToString());
            }
            if (!reader.IsDBNull(reader.GetOrdinal("WarnsDetails")))
            {
                pData.warnsDetails = JsonSerializer.Deserialize<List<string>>(reader["WarnsDetails"].ToString());
            }
            if (!reader.IsDBNull(reader.GetOrdinal("BansGiven")))
            {
                pData.givenBansDetails = JsonSerializer.Deserialize<List<string>>(reader["BansGiven"].ToString());
            }
            if (!reader.IsDBNull(reader.GetOrdinal("WarnsGiven")))
            {
                pData.givenWarnsDetails = JsonSerializer.Deserialize<List<string>>(reader["WarnsGiven"].ToString());
            }
            act = new ACT(this);

        }

        public FeatherClient Client { get { return fClient; } }
        public ref dynamic ClientData { get { return ref fClient.data; } }

        public ref PlayerData Data => ref pData;

        public void Tick()
        {
            if (Client != null)
            {
                while (packets.Count > 0)
                {
                    Client.Send(packets[0]);
                    packets.RemoveAt(0);
                }
            }
        }

        public void RemoveItemFromTrashPackets(PWS.Structs.InventoryKey ikData, int amount)
        {
            BSONObject response = new BSONObject("RIi");
            response["rI"] = new BSONObject();
            response["rI"]["CollectableID"] = 0;
            response["rI"]["BlockType"] = (int)ikData.blockType;
            response["rI"]["Amount"] = amount;
            response["rI"]["InventoryType"] = (int)ikData.itemType;
            response["rI"]["PosX"] = 0.0;
            response["rI"]["PosY"] = 0.0;
            response["rI"]["IsGem"] = false;
            response["rI"]["GemType"] = 0;
            Send(ref response);
        }
        
        public void AdminGive(Structs.InventoryKey ik, int amount)
        {
            Data.InvHelper.AddItemToInventory(ik, (short)amount);
            BSONObject response = new BSONObject("AG");
            response["aAddI"] = SimpleBSON.Dump(new BSONObject()
            {
                ["ik"] = (int)ik,
                ["amount"] = amount
            });
            Send(ref response);
        }
        public void AdminGive(BlockType bt, InventoryItemType it, int amount)
        {
            Data.InvHelper.AddItemToInventory(bt, it, (short)amount);
            BSONObject response = new BSONObject("AG");
            response["aAddI"] = SimpleBSON.Dump(new BSONObject()
            {
                ["ik"] = Structs.InventoryKey.BlockTypeAndInventoryItemTypeToInt(bt, it),
                ["amount"] = amount
            });
            Send(ref response);
        }

        public void SendPing()
        {
            foreach (var pac in packets)
            {
                if (pac["ID"] == "p")
                    return;
            }

            Send(ref MsgLabels.pingBson);
        }

        public void AddXP(int amount)
        {
            Data.XP += amount;
            var response = new BSONObject("XP")
            {
                { "Amt", amount }
            };
            Send(ref response);
        }

        public void SetClient(FeatherClient fClient)
        {
            this.fClient = fClient;

            if (fClient != null)
            {
                if (fClient.link != null)
                    pServer = fClient.link as PWServer;
            }
        }


        public void SelfChat(string txt)
        {
            BSONObject c = new BSONObject("WCM");
            c[MsgLabels.ChatMessageBinary] = Util.CreateChatMessage("<color=#e744de>Server<color=#e744de>",
                world.WorldName,
                world.WorldName,
                1,
                txt);

            Send(ref c);
        }

        public void Send(ref BSONObject packet) => packets.Add(packet);
        public void RemoveGems(int amt)
        {
            Data.Gems -= amt;
            BSONObject bObj = new BSONObject("RG");
            bObj["Amt"] = amt;

            Send(ref bObj);
        }

        public void AddGems(int amt)
        {
            Data.Gems += amt;
            BSONObject bObj = new BSONObject("GG");
            bObj["Amt"] = amt;

            Send(ref bObj);
        }

        public bool IsUnregistered()
        {
            return pData.Name.StartsWith("Player");
        }

        public bool InRange(Vector2i target, int range = 2)
        {
            if (world.InWorldBounds(target))
            {
                var dist = World.WorldSession.DistanceMP(CurrentMP, target);
                if (dist.x > range || dist.y > range) return false;
                else return true;
            }
            else return false;
        }
        public bool InRange(int x, int y, int range = 2)
        {
            return InRange(new Vector2i(x, y), range);
        }

        public void Reconnect(string reason = "")
        {
            if (this != null)
            {
                if (reason != "")
                    reason = "\nDue to: " + reason;
                Util.Log("Disconnecting player: " + this.ClientID + reason);
                if (world != null && world.Players.Count > 0) //removing if still exist in world
                {
                    var pl = Networking.OutgoingMessages.PlayerLeft(ClientID, 0);
                    world.Broadcast(ref pl);
                    world.RemovePlayer(this);
                }
                //BSONObject pa = new BSONObject()
                //{
                //    ["ID"] = "KErr",
                //    ["ER"] = 3
                //};
                BSONObject pa = new BSONObject("DD");
                this.Send(ref pa);
                isInGame = false;

                this.Client.Flush();
                this.Client.DisconnectLater();
                
            }
        }

        public int GetDamageForBlock()
        {
            return 200;
        }

        public void AddWorldBan(string world, DateTime endTime)
        {
            if (Data.worldBans == null)
                Data.worldBans = new();
            if (Data.worldBans.ContainsKey(world))
                Data.worldBans[world] = endTime;
            else
                Data.worldBans.Add(world, endTime);
        }

        public static void AddBanOrWarning(ref List<string> whereToAdd, string reason, string byWho, DateTime when)
        {
            if (whereToAdd == null) whereToAdd = new();
            whereToAdd.AddRange(new List<string>() { when.ToString("yyyy/MM/dd-HH:mm:ss.ffffff", System.Globalization.CultureInfo.InvariantCulture), $":{reason}.:{byWho}.:{reason}" });
        }

        public void Save()
        {
            if (pServer == null)
                return; // No need to save, there has never been a client to perform any changes on the data anyway.
            string joinedWorldNames = string.Join(",", Data.recentlyVisited.Distinct());
            Util.Log("Saving player...");

            var sql = pServer.GetSQL();
            var cmd = sql.Make("UPDATE players SET " +
                "Gems=@Gems, " +
                "ByteCoins=@ByteCoins, " +
                "skinColor=@skinColor, " +
                "countryCode=@countryCode, " +
                "gender=@gender, " +
                "level=@level, " +
                "warnCount=@warnCount, " +
                "banCount=@banCount, " +
                "IP=@IP, " +
                "XP=@XP, " +
                "recentlyVisited=@recentlyVisited, " +
                "Inventory=@Inventory, " +
                "OPStatus=@OPStatus, " +
                "BSON=@BSON," +
                "worldBans=@WorldBans, " +
                "BansDetails=@BansDetails, " +
                "WarnsDetails=@WarnsDetails, " +
                "BansGiven=@BansGiven, " +
                "WarnsGiven=@WarnsGiven " +
                "WHERE ID=@ID");

            cmd.Parameters.AddWithValue("@Gems", Data.Gems);
            cmd.Parameters.AddWithValue("@ByteCoins", Data.Coins);
            cmd.Parameters.AddWithValue("@recentlyVisited", joinedWorldNames);
            cmd.Parameters.AddWithValue("@IP", Data.LastIP);
            cmd.Parameters.AddWithValue("@warnCount", Data.warnCount);
            cmd.Parameters.AddWithValue("@banCount", Data.banCount);
            cmd.Parameters.AddWithValue("@gender", Data.gender);
            cmd.Parameters.AddWithValue("@skinColor", Data.skinColor);
            cmd.Parameters.AddWithValue("@XP", Data.XP);
            cmd.Parameters.AddWithValue("@countryCode", Data.countryCode);
            cmd.Parameters.AddWithValue("@OPStatus", Data.OPStatus);
            cmd.Parameters.AddWithValue("@level", Data.level);
            if (Data.BSON == null)
                Data.BSON = new BSONObject();

            cmd.Parameters.AddWithValue("@BSON", SimpleBSON.Dump(Data.BSON));

            byte[] invData = this.Data.InvHelper.GetInventoryAsBinary();
            cmd.Parameters.Add("@Inventory", DbType.Binary);
            cmd.Parameters["@Inventory"].Value = invData;

            cmd.Parameters.AddWithValue("@ID", Data.UserID);

            //world bans
            if (Data.worldBans != null && Data.worldBans.Count > 0)
                cmd.Parameters.AddWithValue("@WorldBans", JsonSerializer.Serialize(Data.worldBans));
            else
                cmd.Parameters.AddWithValue("@WorldBans", null);
            //game ban
            if (pData.isBanned)
                cmd.Parameters.AddWithValue("@Ban", JsonSerializer.Serialize(new List<string>() { Data.banReason, Data.banEndTime.ToString() }));
            else
                cmd.Parameters.AddWithValue("@Ban", null);
            //ban and warning info
            cmd.Parameters.AddWithValue("@BansDetails", JsonSerializer.Serialize(Data.bansDetails));
            cmd.Parameters.AddWithValue("@WarnsDetails", JsonSerializer.Serialize(Data.warnsDetails));
            cmd.Parameters.AddWithValue("@BansGiven", JsonSerializer.Serialize(Data.givenBansDetails));
            cmd.Parameters.AddWithValue("@WarnsGiven", JsonSerializer.Serialize(Data.givenWarnsDetails));


            if (sql.PreparedQuery(cmd) > 0)
            {
                Util.Log($"Player ID: {Data.UserID} ('{Data.Name}') saved.");
            }
        }
    }
}
