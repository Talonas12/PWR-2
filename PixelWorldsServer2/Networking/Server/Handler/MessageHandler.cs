using FeatherNet;
using Kernys.Bson;
using PWS.Database;
using PWS.DataManagement;
using PWS.World;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using static PWS.Constants.Enums;
using BasicTypes;
using PWS.Structs;
using PWS.Constants;
using PWS.World.Helpers;
using System.Text.RegularExpressions;

namespace PWS.Networking.Server
{
    public class MessageHandler
    {
        private PWServer pServer = null;

        public MessageHandler(PWServer pwServer)
        {
            pServer = pwServer;
        }

        public void ProcessBSONPacket(FeatherClient client, BSONObject bObj)
        {
            if (pServer == null)
            {
                Util.Log("ERROR cannot process BSON packet when pServer is null!");
                return;
            }

            if (!bObj.ContainsKey("mc"))
            {
                Util.Log("Invalid bson packet (no mc!)");
                client.DisconnectLater();
                return; // Invalid Pixel Worlds BSON packet!
            }

#if RELEASE

#endif
            int messageCount = bObj["mc"];


            Player p = client.data == null ? null : ((Player.PlayerData)client.data).player;
            for (int i = 0; i < messageCount; i++)
            {
                if (!bObj.ContainsKey($"m{i}"))
                    throw new Exception($"Non existing message object failed to be accessed by index '{i}'!");

                BSONObject mObj = bObj[$"m{i}"] as BSONObject;
                string mID = mObj[MsgLabels.MessageID];
                if (pServer.debugCaptureAll)
                    Util.Log(SimpleBSON.DumpBSON(mObj));
                if (pServer.iCapture != null && pServer.iCapture.Count > 0)
                {
                    if (pServer.iCapture.Contains(mID))
                    {
                        Util.Log(SimpleBSON.DumpBSON(mObj));
                    }
                }
#if DEBUG
                //Util.Log("Got message: " + mID);
#endif

                switch (mID)
                {
                    case MsgLabels.Ident.VersionCheck:
#if DEBUG
                        Util.Log("Client requests version check, responding now...");
#endif
                        BSONObject resp = new BSONObject();
                        resp[MsgLabels.MessageID] = MsgLabels.Ident.VersionCheck;
                        resp[MsgLabels.VersionNumberKey] = pServer.Version;
                        client.Send(resp);
                        break;

                    case MsgLabels.Ident.GetPlayerData:
                        HandlePlayerLogon(client, mObj);
                        break;

                    case MsgLabels.Ident.TryToJoinWorld:
                        HandleTryToJoinWorld(p, mObj);
                        break;

                    case "TTJWR":
                        HandleTryToJoinWorldRandom(p);
                        break;

                    case MsgLabels.Ident.GetWorld:
                        HandleGetWorld(p, mObj);
                        break;

                    case "GSb":
                        if (p != null)
                            p.isLoadingWorld = false;

                        p.Send(ref mObj);
                        break;

                    case "WCM":
                        HandleWorldChatMessage(p, mObj);
                        break;

                    case "MWli":
                        HandleMoreWorldInfo(p, mObj);
                        break;

                    case "PSicU":
                        HandlePlayerStatusChange(p, mObj);
                        break;

                    case "BIPack":
                        HandleShopPurchase(p, mObj);
                        break;

                    case "RenamePlayer":
                        HandleRenamePlayer(p, mObj, pServer);
                        break;

                    case "rOP": // request other players
                        HandleSpawnPlayer(p, mObj);
                        HandleRequestOtherPlayers(p, mObj);
                        break;

                    case "ChangeBackground":
                        ChangeWorldOrb(p, mObj);
                        break;

                    case "GM":
                        HandleGlobalMessage(p, mObj);
                        break;

                    case "RtP":
                        break;

                    case MsgLabels.Ident.LeaveWorld:
                        HandleLeaveWorld(p, mObj);
                        break;

                    case "rAI": // request AI (bots, etc.)??
                        HandleRequestAI(p, mObj);
                        break;

                    case "rAIp": // ??
                        HandleRequestAIp(p, mObj);
                        break;

                    case "Rez":
                        if (p == null)
                            break;

                        if (p.world == null)
                            break;

                        mObj["U"] = p.Data.UserID.ToString("X8");
                        p.world.Broadcast(ref mObj, p);
                        break;

                    case MsgLabels.Ident.WearableUsed:
                        HandleWearableUsed(p, mObj);
                        break;
                    case MsgLabels.Ident.WearableRemoved:
                        HandleWearableRemoved(p, mObj);
                        break;

                    case "C":
                        HandleCollect(p, mObj["CollectableID"]);
                        break;

                    case "RsP":
                        HandleRespawn(p, mObj);
                        break;

                    case "GAW":
                        HandleGetActiveWorlds(p);
                        break;

                    case "RIi":
                        HandleTrashItem(p, mObj);
                        break;

                    case "TDmg":
                        {
                            if (p != null)
                            {
                                if (p.world != null)
                                {
                                    BSONObject response = new BSONObject();
                                    response["ID"] = "TDmg";
                                    response["DBl"] = 0;
                                    response["Mp1X"] = p.Data.PosX;
                                    response["Mp1Y"] = p.Data.PosY;
                                    response[MsgLabels.TimeStamp] = DateTime.UtcNow.Ticks;
                                    p.world.Broadcast(ref response);
                                    p.Send(ref mObj);
                                }
                            }
                        }
                        break;
                    case "XPCl":
                        p.Data.level++;
                        break;
                    case "PDC":
                        {
                            if (p != null)
                            {
                                if (p.world != null)
                                {
                                    BSONObject rsp = new BSONObject();
                                    rsp["ID"] = "UD";
                                    rsp["U"] = p.Data.UserID.ToString("X8");
                                    rsp["x"] = p.world.SpawnPointX;
                                    rsp["y"] = p.world.SpawnPointY;
                                    rsp["DBl"] = 0;
                                    p.world.Broadcast(ref rsp);
                                    p.Send(ref mObj);
                                }
                            }
                            break;
                        }

                    case "Di":
                        HandleDropItem(p, mObj);
                        break;
                    case "TTFFMP":
                        HandleTryToFishFromMapPointMessage(bSONObject);
                        break;
                    case "FBmS":
                        HandleFishBroadcastMessageStart(bSONObject);
                        break;
                    case "FBmSt":
                        HandleFishBroadcastMessageStrike(bSONObject);
                        break;
                    case "FBmM":
                        HandleFishBroadcastMessageMissed(bSONObject);
                        break;
                    case "FBmH":
                        HandleFishBroadcastMessageHook(bSONObject);
                        break;
                    case "FBmMW":
                        HandleFishBroadcastMessageMinigameWon(bSONObject);
                        break;
                    case "FBmME":
                        HandleFishBroadcastMessageMinigameCancelled(bSONObject);
                        break;
                    case "FBmML":
                        HandleFishBroadcastMessageMinigameLost(bSONObject);
                        break;
                    case "FOnAM":
                        HandleFishOnAreaMessage(bSONObject);
                        break;
                    case "FOffAM":
                        HandleFishOffAreaMessage(bSONObject);
                        break;
                    case "FRM":
                        HandleFishRunMessage(bSONObject);
                        break;

                    case "mp":
                        p.act.HandleMovements(mObj);
                        break;

                    case "GRW":
                        getRecentlyVisitedWorlds(p);
                        break;

                    case MsgLabels.Ident.MovePlayer:
                        HandleMovePlayer(p, mObj);
                        break;

                    case "PiU":
                        PlayerInfo(p, mObj);
                        break;

                    case "WarnPlayer":
                        HandleWarnPlayer(p, mObj);
                        break;

                    case MsgLabels.Ident.SetBlock:
                        HandleSetBlock(p, mObj);
                        break;

                    case MsgLabels.Ident.SetBackgroundBlock:
                        HandleSetBackgroundBlock(p, mObj);
                        break;

                    case MsgLabels.Ident.SetBlockWater:
                        HandleSetBlockWater(p, mObj);
                        break;

                    case MsgLabels.Ident.HitBlock:
                        HandleHitBlock(p, mObj);
                        break;

                    case MsgLabels.Ident.HitBackgroundBlock:
                        HandleHitBackground(p, mObj);
                        break;
                    case MsgLabels.Ident.HitBlockWater:
                        HandleHitWater(p, mObj);
                        break;

                    case "SS":
                        HandleSetSeed(p, mObj);
                        break;

                    case MsgLabels.Ident.SyncTime:
                        HandleSyncTime(client);
                        break;

                    case MsgLabels.Ident.WorldItemUpdate:
                        HandleWorldItemUpdate(p, mObj);
                        break;

                    case "ADI":
                        HandleAdjustDisplayItem(p, mObj);
                        break;

                    case "ADM":
                        HandleAdjustDisplayMessage(p, mObj);
                        break;

                    case "TTSWi":
                        HandleTryToSecureWorldItem(p, mObj);
                        break;

                    case "WP":
                        HandleWarpPlayer(p, mObj);
                        break;

                    case "KPl":
                        HandleKickPlayer(p, mObj, 0);
                        break;

                    case "BPl":
                        HandleKickPlayer(p, mObj, 1);
                        break;

                    case "SetAdminWantsToBeSummoned":
                        HandleSetAdminWantsToBeSummoned(p, mObj);
                        break;

                    case "SetEditWorldByAdmin ": //must be space at the end!
                        HandleSetEditWorldByAdmin(p, mObj);
                        break;

                    case "FKPBl": //damage system
                        {
                            if (p != null)
                            {
                                if (p.world != null)
                                {
                                    BSONObject response = new BSONObject();
                                    response["ID"] = "FKPBl";
                                    response["DBl"] = 0;
                                    response["Mp1X"] = p.Data.PosX;
                                    response["Mp1Y"] = p.Data.PosY;
                                    response[MsgLabels.TimeStamp] = DateTime.Now.Ticks;
                                    p.world.Broadcast(ref response);
                                    p.Send(ref mObj);
                                    HandleRespawn(p, mObj);
                                }
                            }
                            break;
                        }

                    case "BanPlayerFromGame":
                        HandleBanPlayer(p, mObj);
                        break;

                    case "QPi":
                        HandleQueryPlayerInformation(p, mObj);
                        break;

                    case "PAiP":
                        HandlePlayPortalInAnimation(p, mObj);
                        break;

                    case "PAoP":
                        HandlePlayPortalOutAnimation(p, mObj);
                        break;

                    default:
                        pServer.OnPing(client, 1);
                        break;

                }
            }
        }

        private byte[] playerDataTemp = File.ReadAllBytes("player.dat").Skip(4).ToArray(); // template for playerdata, too painful to reverse rn so I am just gonna modify whats needed.
        public void HandlePlayerLogon(FeatherClient client, BSONObject bObj)
        {
#if DEBUG
            Util.Log("Handling player logon...");
#endif

            string cogID = bObj[MsgLabels.CognitoId];
            string cogToken = bObj[MsgLabels.CognitoToken];

            var resp = SimpleBSON.Load(playerDataTemp)["m0"] as BSONObject;
            var accHelper = pServer.GetAccountHelper();

            Player p = accHelper.LoginPlayer(cogID, cogToken, client.GetIPString());
            if (p == null)
            {
                Util.Log("Player was null upon logon!!");
                client.DisconnectLater();
                return;
            }

            if (p.Client == null)
            {
                Util.Log("Client was null, so setting it here!");
                p.SetClient(client);
                client.data = p.Data;
            }

            uint userID = p.Data.UserID;

            if (!pServer.players.ContainsKey(userID))
            {
                pServer.players[userID] = p; // just a test with userID = 0
            }
            else
            {
                p = pServer.players[userID];

                if (p.isInGame)
                {
                    Util.Log("Account is online already, disconnecting current client...");
                    if (p.Client != null)
                    {
                        if (p.Client.isConnected())
                        {
                            p.Client.Send(new BSONObject("DR"));
                            p.Client.DisconnectLater();
                        }
                    }
                }
            }

            p.Data.CognitoID = cogID;
            p.Data.Token = cogToken;

            BSONObject pd = new BSONObject("pD");
            pd[MsgLabels.PlayerData.ByteCoinAmount] = p.Data.Coins;
            pd[MsgLabels.PlayerData.GemsAmount] = p.Data.Gems;
            pd[MsgLabels.PlayerData.Username] = p.Data.Name.ToUpper();
            pd[MsgLabels.PlayerData.PlayerOPStatus] = p.Data.OPStatus;
            pd[MsgLabels.PlayerData.XPAmount] = p.Data.XP;
            pd["ll"] = 200;
            pd[MsgLabels.PlayerData.InventorySlots] = 150;
            pd[MsgLabels.PlayerData.Gender] = p.Data.gender;
            pd[MsgLabels.PlayerData.Skin] = p.Data.skinColor;
            pd[MsgLabels.PlayerData.CountryCode] = p.Data.countryCode;

            // pd["experienceAmount"] = 180000;
            // pd["xpAmount"] = 180000;

            //if (p.Data.InvHelper.Items.Count == 0)
            //{
            //    p.Data.InvHelper.RegularDefaultInventory();
            //}

            //pd["inv"] = p.Data.Inventory.Serialize();
            pd["inv"] = p.Data.InvHelper.GetInventoryAsBinary();
            pd["tutorialState"] = 3;
            pd["Gnd"] = p.Data.Gnd;
            pd["SCI"] = p.Data.SCI;
            resp["rUN"] = p.Data.Name;
            resp["pD"] = SimpleBSON.Dump(pd);
            resp["U"] = p.Data.UserID.ToString("X8");
            resp["Wo"] = "PIXELSTATION";
            resp["EmailVerified"] = true;
            resp["Email"] = p.IsUnregistered() ? "Register!" : "Registered!";

            p.SetClient(client); // override client...
            client.data = p.Data;
            p.isInGame = true;

            client.Send(resp);
        }

        public string HandleCommandClearInventory(Player p)
        {
            p.Data.InvHelper.Items.Clear();
            BSONObject r = new BSONObject("DR");
            p.Send(ref r);

            return "Cleared inventory!";
        }

        public string HandleCommandGlobalMessage(Player p, string[] args)
        {
            if (args.Length < 2)
            {
                return "Usage: /gm (message to broadcast)";
            }

            string msg_query = "";

            for (int i = 1; i < args.Length; i++)
            {
                msg_query += args[i];

                if (i < args.Length - 1) msg_query += " ";
            }


            if (p.Data.Gems >= 100)
            {
                p.RemoveGems(100);
                BSONObject gObj = new BSONObject(MsgLabels.Ident.BroadcastGlobalMessage);
                gObj[MsgLabels.ChatMessageBinary] = Util.CreateChatMessage($"<color=#00FFFF>Broadcast from {p.Data.Name}", p.world.WorldName, p.world.WorldName, 1,
                   msg_query);

                pServer.Broadcast(ref gObj);

                return "Sent message to everybody.";
            }
            else
            {
                return "Not enough gems to send a Global Message to everybody! (You need 100 at least).";
            }
        }

        public string HandleCommandPay(Player p, string[] args)
        {
            if (args.Length < 3)
                return "Usage: /pay (NAME) (GEMS)";

            string user = args[1];
            int amt;
            int.TryParse(args[2], out amt);

            if (amt < 50 || amt > 9999999)
            {
                return "Can only send gems between 50 and 9999999!";
            }

            if (p.Data.Gems < amt)
                return "Not enough gems to transfer.";

            var player = pServer.GetOnlinePlayerByName(user);
            if (player == null)
                return String.Format(">> {0} is offline.", user);

            if (player == p)
                return "Cannot transfer gems to yourself, duh!";

            p.RemoveGems(amt);
            player.AddGems(amt);

            return String.Format("Transferred {0} Gems to Account {1}!", amt, player.Data.Name);
        }

        public string HandleCommandRegister(Player p, string[] args)
        {
            if (args.Length < 3)
                return "Usage: /register (NAME) (PASS)";

            string name = args[1], pass = args[2];

            if (SQLiteManager.HasIllegalChar(name) || SQLiteManager.HasIllegalChar(pass))
                return "Username or password has illegal character! Only letters and numbers.";

            if (pass.Length > 24 || name.Length > 24 || pass.Length < 3 || name.Length < 3)
                return "Username or Password too long or too short!";

            if (!p.IsUnregistered())
                return "You are registered already!";

            var sql = pServer.GetSQL();

            using (var read = sql.FetchQuery($"SELECT * FROM players WHERE Name='{name}'"))
            {
                if (read.HasRows)
                    return "An account with this name already exists.";
            }

            pass = Util.HashCredentials_SHA256(pass);
            if (sql.Query($"UPDATE players SET Name='{name}', Pass='{pass}' WHERE ID='{p.Data.UserID}'") > 0)
            {
                p.Data.Name = name;
                BSONObject r = new BSONObject("DR");

                p.Send(ref r);
                return "";
            }

            return "Couldn't register right now, try again!";
        }

        public string HandleCommandLogin(Player p, string[] args)
        {
            if (args.Length < 3)
                return "Usage: /login (NAME) (PASS)";

            string name = args[1], pass = args[2];

            if (SQLiteManager.HasIllegalChar(name) || SQLiteManager.HasIllegalChar(pass))
                return "Username or password has illegal character! Only letters and numbers.";

            if (pass.Length > 24 || name.Length > 24 || pass.Length < 3 || name.Length < 3)
                return "Username or Password too long or too short!";

            if (!p.IsUnregistered())
                return "You are logged on already!";

            pass = Util.HashCredentials_SHA256(pass);
            var sql = pServer.GetSQL();
            using (var read = sql.FetchQuery($"SELECT * FROM players WHERE Name='{name}' AND Pass='{pass}'"))
            {
                uint uID = 0;

                if (!read.HasRows)
                    return "Account does not exist or password is wrong!";

                if (!read.Read())
                    return "Account does not exist or password is wrong!";


                uID = (uint)(long)read["ID"];

                Util.Log("CognitoID: " + p.Data.CognitoID + " Token: " + p.Data.Token + " UID: " + uID + " UserID: " + p.Data.UserID);

                var cmd = sql.Make("UPDATE players SET CognitoID=@CognitoID, Token=@Token WHERE ID=@ID");
                cmd.Parameters.AddWithValue("@CognitoID", p.Data.CognitoID);
                cmd.Parameters.AddWithValue("@Token", p.Data.Token);
                cmd.Parameters.AddWithValue("@ID", uID);

                if (sql.PreparedQuery(cmd) > 0 && sql.Query($"DELETE FROM players WHERE ID='{p.Data.UserID}'") > 0)
                {
                    BSONObject r = new BSONObject("DR");
                    p.Client.Send(r);
                    p.Client.Flush();

                    pServer.players.Remove(p.Data.UserID);
                    return "";
                }
            }

            return "Couldn't login right now, try again!";
        }

        public void HandleWorldChatMessage(Player p, BSONObject bObj)
        {
            if (p == null)
                return;

            if (p.world == null)
                return;

            string msg = bObj["msg"];

            string[] tokens = msg.Split(" ");
            int tokCount = tokens.Count();

            if (tokCount <= 0)
                return;

            if (tokens[0] == "")
                return;

            if (tokens[0][0] == '/')
            {
                string res = "Unknown command.";
                switch (tokens[0])
                {
                    case "/help":
                        res = "Commands >> /help /item (item id) /find (item name) /register (username pass) /login (username pass) /gm (message, uses 100 gems) /spin /pay (username gems)";
                        break;

                    case "/gm":
                        {
                            res = HandleCommandGlobalMessage(p, tokens);
                            break;
                        }

                    case "/spin":
                        BSONObject gObj = new BSONObject(MsgLabels.Ident.BroadcastGlobalMessage);
                        gObj[MsgLabels.ChatMessageBinary] = Util.CreateChatMessage($"<color=#00FAFA>{p.Data.Name}", p.world.WorldName, p.world.WorldName, 1,
                           String.Format("Spun the wheel and got {0}", Util.rand.Next(0, 36)));

                        p.world.Broadcast(ref gObj);
                        res = "Everybody saw you SPIN!";
                        break;

                    case "/pay":
                        {
                            res = HandleCommandPay(p, tokens);
                            break;
                        }

                    case "/dc":
                        p.Reconnect();
                        res = "";
                        break;

                    case "/mypass":
                        {
                            string[] args = tokens;
                            if (args.Length < 1)
                            {
                                p.SelfChat("Usage /mypass");
                                res = "";
                                break;
                            }
                            res = "";
                            var sqlManager = pServer.GetSQL();
                            using (var read = sqlManager.FetchQuery($"SELECT Pass FROM players WHERE ID='{p.Data.UserID}'"))
                            {
                                if (read.Read())
                                {
                                    string pass = read.GetString(0);
                                    p.SelfChat("Your password is " + pass + " Remember it!");
                                }
                            }
                            break;
                        }

                    case "/changepass":
                        {
                            if (p.IsUnregistered())
                            {
                                p.SelfChat("Register an account first");
                                res = "";
                                break;
                            }
                            res = "";
                            string[] args = tokens;
                            if (args.Length < 2)
                            {
                                p.SelfChat("Usage: /changepass newPass");
                                break;
                            }
                            pServer.updatePassword(p, args[1], pServer.GetSQL());
                            p.SelfChat("Your password was changed successfully");
                            break;
                        }

                    case "/debug":
                        {
                            PWServer.banPlayer(p, 1231312, "Test", false);
                            break;
                        }

                    case "/pm":
                        {
                            string[] args = tokens;
                            if (tokens.Length < 2)
                            {
                                p.SelfChat("Usage: /pm (user) (message)");
                                res = "";
                                break;
                            }
                            res = "";
                            string user = args[1];
                            string message = string.Join(" ", tokens.Skip(2));
                            Player targetPlayer = pServer.GetOnlinePlayerByName(user);

                            if (targetPlayer != null)
                            {
                                var messageData = new BSONObject()
                                {
                                    { "ID", "PCM" }
                                };
                                var messageBinary = new BSONObject() // Its more efficient to do these inside a function but I dont give a fk
                                {
                                    { "nick", p.Data.Name },
                                    { "userID", p.ClientID },
                                    { "channel", p.world.WorldName },
                                    { "channelIndex", 2 },
                                    { "message", message },
                                    { "time", DateTime.UtcNow }
                                 };
                                messageData["CmB"] = messageBinary;
                                p.Send(ref messageData);
                                targetPlayer.Send(ref messageData);
                                break;
                            }
                            else
                            {
                                res = "The user is not online or does not exist!";
                                break;
                            }
                        }

                    case "/find":
                        {
                            if (tokCount < 2)
                            {
                                res = "Usage: /find (ITEM NAME)";
                                break;
                            }

                            string item_query = "";

                            for (int i = 1; i < tokens.Length; i++)
                            {
                                item_query += tokens[i];

                                if (i < tokens.Length - 1) item_query += " ";
                            }

                            if (item_query.Length < 2)
                            {
                                res = "Please enter an item name with more than 2 characters!";
                                break;
                            }

                            var items = ItemDB.FindByAnyName(item_query);

                            if (items.Length > 0)
                            {
                                string found = "";

                                foreach (var it in items)
                                {
                                    found += $"\nItem Name: {it.name}   ID: {it.ID}";
                                }

                                res = $"Found items:{found}";
                            }
                            else
                            {
                                res = $"No item containing '{item_query}' was found.";
                            }
                            break;
                        }

                    case "/register":
                        res = HandleCommandRegister(p, tokens);
                        break;

                    case "/clearinv":
                        res = HandleCommandClearInventory(p);
                        break;

                    case "/login":
                        res = HandleCommandLogin(p, tokens);
                        break;

                    case "/ppa":
                        BSONObject pa = new BSONObject()
                        {
                            ["ID"] = "PPA",
                            ["audioType"] = int.Parse(tokens[1]),
                            ["audioBlockType"] = int.Parse(tokens[2]),
                            ["U"] = "SERVER"
                        };
                        p.world.Broadcast(ref pa);
                        break;

                    case "/give":
                        {
                            if (!AuthorityHelper.IsPlayerAdmin(p)) return;

                            if (tokCount < 3)
                            {
                                p.SelfChat("Usage: /give (itemId) (amount)");
                                res = "";
                            }
                            else
                            {
                                int id;
                                int amount;

                                if (!int.TryParse(tokens[1], out id) || !int.TryParse(tokens[2], out amount))
                                {
                                    p.SelfChat("Invalid item id or amount");
                                    res = "";
                                    break;
                                }

                                var it = ItemDB.GetByID(id);
                                res = "";

                                if (it.ID < 0)
                                {
                                    p.SelfChat($"Item: {id} not found!");
                                    res = "";
                                }
                                else
                                {
                                    p.world.visualDrop(p, new InventoryKey((BlockType)it.ID, (InventoryItemType)it.type), amount, p.Data.PosX, p.Data.PosY);
                                    p.SelfChat(@$"Given {amount}x {it.name} (ID {id}, IT {it.type}");
                                }
                            }
                            break;
                        }


                    default:
                        break;
                }

                if (res != "")
                {
                    bObj[MsgLabels.ChatMessageBinary] = Util.CreateChatMessage("<color=#FF0000>System",
                        p.world.WorldName,
                        p.world.WorldName,
                        1,
                        res);

                    p.Send(ref bObj);
                }
            }
            else
            {
                bObj[MsgLabels.MessageID] = "WCM";
                bObj[MsgLabels.ChatMessageBinary] = Util.CreateChatMessage(p.Data.Name, p.Data.UserID.ToString("X8"), "#" + p.world.WorldName, 0, msg);
                p.world.Broadcast(ref bObj, p);
            }
        }

        public static string generateChars(int length)
        {
            char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890".ToCharArray();
            Random ran = new Random();
            List<string> pass = new List<string>();

            for (int i = 0; i < length; i++)
            {
                int charToTake = ran.Next(0, chars.Length);
                if (charToTake > chars.Length) continue;
                pass.Add(chars[charToTake].ToString());
            }

            return string.Join("", pass);
        }

        public void HandleMoreWorldInfo(Player p, BSONObject bObj)
        {
            if (p == null)
                return;
            string wName = bObj["WN"].stringValue;
            var w = pServer.GetWorldManager().GetByName(bObj["WN"]);

            bObj[MsgLabels.Count] = w == null ? 0 : w.Players.Count;

            if (WorldSession.doesWorldExist(wName))
            {
                bObj[MsgLabels.Count] = w == null ? 0 : w.Players.Count;
                p.Send(ref bObj);
            }
            else
            {
                bObj["Ct"] = -3;
                p.Send(ref bObj);

            }
        }

        private void HandleTryToFishFromMapPointMessage(BSONObject currentMessage)
        {
            if (currentMessage.ContainsKey(NetStrings.Success) && currentMessage[NetStrings.Success].boolValue)
            {
                if ((Object)(object)ControllerHelper.worldController != (Object)null && (Object)(object)ControllerHelper.worldController.player != (Object)null && (Object)(object)ControllerHelper.gameplayUI != (Object)null)
                {
                    Vector2i mapPoint = Vector2i.GetZero();
                    World.BlockType fishBlockType = World.BlockType.None;
                    if (Vector2i.DoesValidate(currentMessage))
                    {
                        mapPoint = new Vector2i(currentMessage);
                    }
                    if (currentMessage.ContainsKey(NetStrings.BlockType))
                    {
                        fishBlockType = (World.BlockType)currentMessage[NetStrings.BlockType].int32Value;
                    }
                    ControllerHelper.worldController.SaveFishMapPoint(mapPoint);
                    OutgoingMessages.SendStartFishingGameMessage(mapPoint, fishBlockType);
                }
            }
            else
            {
                Debug.LogError((object)"Failed to start fishing from the spot.");
                if (currentMessage.ContainsKey(NetStrings.BlockType))
                {
                    World.BlockType int32Value = (World.BlockType)currentMessage[NetStrings.BlockType].int32Value;
                    StaticPlayer.playerData.AddItemToInventory(new PlayerData.InventoryKey(int32Value), null);
                }
                ControllerHelper.worldController.player.SetFishing(FishingState.NoFishing);
                ControllerHelper.gameplayUI.DeactivateFishing();
                if ((Object)(object)ControllerHelper.worldController != (Object)null)
                {
                    ControllerHelper.worldController.player.ResetPlayerAnimationsAfterFishing();
                }
            }
        }
        public void HandlePlayerStatusChange(Player p, BSONObject bObj)
        {
            if (p == null)
                return;

            if (p.world == null)
                return;


            bObj["U"] = p.Data.UserID.ToString("X8");
            p.world.Broadcast(ref bObj, p);
        }

        public void HandleShopPurchase(Player p, BSONObject bObj)
        {
            if (p == null || !bObj.ContainsKey("IPId"))
                return;

            string id = bObj["IPId"];
            Util.Log($"{p.Data.Name} wants to buy {id}, gems: {p.Data.Gems}");
            bObj["S"] = "PS";

            if (Shop.offers.ContainsKey(id))
            {
                var s = Shop.offers[id];

                if (s.items != null)
                {
                    if (p.Data.Gems >= s.price)
                    {
                        bObj["IPRs"] = s.items.SelectMany(item => Enumerable.Repeat(item.Key, item.Value2)).ToList();
                        foreach (var item2 in s.items)
                        {
                            p.Data.InvHelper.AddItemToInventory((BlockType)item2.Key, item2.Value1, (short)item2.Value2);
                        }
                        p.RemoveGems(s.price);

                        bObj["IPRs2"] = new List<int>();

                        p.Send(ref bObj);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            if (ItemPacks.GetWithID(id, out ItemPacks.ItemPack itemPack))
            {
                ItemPacks.HandleBought(p, itemPack);
            }
            
        }

        private static bool IsNameOk(string playerName)
        {
            if (playerName.Length < 2 || playerName.Length > 15)
            {
                return false;
            }
            return Regex.IsMatch(playerName.ToUpper(), "^([][A-Z_^{}][][A-Z_0-9^{}-]+)$");
        }

        public static void HandleRenamePlayer(Player p, BSONObject request, PWServer pServer)
        {
            try
            {
                string playerName = request.ContainsKey("UN") ? request["UN"].stringValue : "";
                int errorCode = 0;
                SQLiteManager sqlManager = pServer.GetSQL();

                if (!p.IsUnregistered()) errorCode = (int)MsgLabels.regErrors.ALREADY_CHANGED;
                if (!IsNameOk(playerName)) errorCode = (int)MsgLabels.regErrors.INVALID_NAME;

                BSONObject response = new BSONObject("RenamePlayer");

                using (var read = sqlManager.FetchQuery($"SELECT * FROM players WHERE LOWER(Name) = LOWER('{playerName}')"))
                {
                    if (read.HasRows) errorCode = (int)MsgLabels.regErrors.ALREADY_EXISTS;
                }

                if (errorCode != 0)
                {
                    response["S"] = false;
                    response["ER"] = errorCode;
                }
                else
                {
                    response["S"] = true;
                    response["UN"] = playerName;

                    string password = generateChars(8);

                    if (sqlManager.Query($"UPDATE players SET Name='{playerName}', Pass='{password}' WHERE ID='{p.Data.UserID}'") > 0)
                    {
                        p.Data.Name = playerName;
                        p.Data.justRegistered = true;
                        p.Data.password = password;
                    }
                }
                p.Send(ref response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        public void HandleTryToJoinWorld(Player p, BSONObject bObj)
        {
            if (p == null)
            {
                Util.Log("p is null");
                return;
            }

            Util.Log($"Player with userID: {p.Data.UserID}/{p.ClientID}/{p.Data.Name} is trying to join a world [{pServer.GetPlayersIngameCount()} players online!]...");

            BSONObject resp = new BSONObject(MsgLabels.Ident.TryToJoinWorld);
            resp[MsgLabels.JoinResult] = (int)MsgLabels.JR.UNAVAILABLE;

            var wmgr = pServer.GetWorldManager();
            string worldName = bObj["W"];

            WorldSession world = wmgr.GetByName(worldName, true);

            if (SQLiteManager.HasIllegalChar(worldName))
            {
                resp[MsgLabels.JoinResult] = (int)MsgLabels.JR.INVALID_NAME;
            }
            else if (p.Data.isBanned)
            {
                if (DateTime.UtcNow.CompareTo(new DateTime(p.Data.banEndTime)) > 0)
                {
                    p.Data.isBanned = false;
                    p.Reconnect();
                }
                resp[MsgLabels.JoinResult] = (int)MsgLabels.JR.UserIsBanned;
                resp["BPl"] = 1;
                resp["T"] = p.Data.banEndTime;
                resp["BPUR"] = p.Data.banReason;
                resp["BanState"] = "Universal";
                p.Send(ref resp);
            }
            else if (world != null)
            {
#if DEBUG
                Util.Log("World not null, JoinResult -, joining world...");
#endif
                if (p.Data.worldBans != null && p.Data.worldBans.Count > 0)
                {
                    if (p.Data.worldBans.ContainsKey(worldName))
                    {
                        DateTime banEndTime = new();
                        if (p.Data.worldBans.TryGetValue(worldName, out banEndTime) && DateTime.UtcNow.CompareTo(banEndTime) > 0)
                        {
                            p.Data.worldBans.Remove(worldName);
                        }
                        else
                        {
                            resp[MsgLabels.JoinResult] = (int)MsgLabels.JR.UserIsBanned;
                            resp["BanState"] = "World";
                            resp["T"] = banEndTime.Ticks;
                            resp["BPUR"] = "Unknown";
                            resp["BPl"] = 1;
                            p.Send(ref resp);
                            return;
                        }
                    }
                }
                resp[MsgLabels.JoinResult] = (int)MsgLabels.JR.SUCCESS;
            }
            else
            {
                resp[MsgLabels.JoinResult] = (int)MsgLabels.JR.UNAVAILABLE;
            }

            p.Send(ref resp);
        }

        public static void BroadcastClanKickMessage(Player player, string message, string title)
        {
            var msg = new BSONObject
            {
                { "ID", "OMsg" },
                { "msg", $"4;" + title + ";" + message }
            };
            player.Send(ref msg);
        }

        public void HandleGetWorld(Player p, BSONObject bObj)
        {
            if (p == null)
                return;

            HandleLeaveWorld(p, null);

            string worldName = bObj["W"];
            var wmgr = pServer.GetWorldManager();

            if (p.Data.worldBans != null && p.Data.worldBans.Count > 0)
            {
                if (p.Data.worldBans.ContainsKey(worldName))
                {
                    if (p.Data.worldBans.TryGetValue(worldName, out DateTime banEndTime) && DateTime.UtcNow.CompareTo(banEndTime) > 0)
                    {
                        p.Data.worldBans.Remove(worldName);
                    }
                    else
                    {
                        p.Reconnect();
                        return;
                    }
                }
            }

                WorldSession world = wmgr.GetByName(worldName, true);
            world.AddPlayer(p);

            BSONObject resp = new BSONObject();
            BSONObject wObj = world.Serialize();

            resp[MsgLabels.MessageID] = MsgLabels.Ident.GetWorldCompressed;
            resp["W"] = Util.LZMAHelper.CompressLZMA(SimpleBSON.Dump(wObj));

            p.Send(ref resp);
            p.Tick();

            p.isLoadingWorld = true;

            //player spawn position
            WorldSession.ConvertMapPointToWorldPoint(new Vector2i(p.world.SpawnPointX, p.world.SpawnPointY), out p.Data.PosX, out p.Data.PosY);
            p.PreviousMp.x = p.world.SpawnPointX;
            p.PreviousMp.y = p.world.SpawnPointY;
        }

        public void PlayerInfo(Player p, BSONObject request)
        {
            if (p == null || p.world == null) return;
            p.Data.countryCode = request["Ctry"].int32Value;
            p.Data.skinColor = request["SCI"].int32Value;
            p.Data.gender = request["Gnd"].int32Value;
        }

        public void HandleLeaveWorld(Player p, BSONObject bObj)
        {
            if (p == null)
                return;

            //if (p.world == null)
            //    return;

            BSONObject resp = new BSONObject("PL");
            resp[MsgLabels.UserID] = p.Data.UserID.ToString("X8");

            if (p.world != null)
            {
                p.world.Broadcast(ref resp, p);
                p.world.RemovePlayer(p);

            }

            if (bObj != null)
                p.Send(ref bObj);


            p.isLoadingWorld = false;

            Util.Log($"Player with UserID {p.Data.UserID} left the world!");
        }

        public void HandleRequestOtherPlayers(Player p, BSONObject bObj)
        {
            if (p == null)
                return;

            if (p.world == null)
                return;

            //p.Send(ref bObj);


            long kukTime = Util.GetKukouriTime();
            foreach (var player in p.world.Players)
            {
                if (player.Data.UserID == p.Data.UserID)
                    continue;

                string prefix = "";

                BSONObject pObj = new BSONObject("AnP");
                pObj["x"] = player.Data.PosX;
                pObj["y"] = player.Data.PosY;
                pObj["t"] = kukTime;
                pObj["a"] = player.Data.Anim;
                pObj["d"] = player.Data.Dir;
                List<int> spotsList = new List<int>();
                //spotsList.AddRange(player.GetSpots());

                pObj["spots"] = spotsList;
                pObj["familiar"] = 0;
                pObj["familiarName"] = "";
                pObj["familiarLvl"] = 0;
                pObj["familiarAge"] = kukTime;
                pObj["isFamiliarMaxLevel"] = false;
                pObj["UN"] = prefix + player.Data.Name;
                pObj["U"] = player.Data.UserID.ToString("X8");
                pObj["Age"] = 69;
                pObj["LvL"] = 99;
                pObj["xpLvL"] = 99;
                pObj["pAS"] = player.Data.OPStatus;
                if (player.Data.adminInEditWorldMode) pObj["PlayerAdminEditMode"] = player.Data.adminInEditWorldMode;
                if (player.Data.OPStatus != 0) pObj[MsgLabels.PlayerData.PlayerOPStatus] = player.Data.OPStatus;
                pObj["Ctry"] = p.Data.countryCode;
                pObj["GAmt"] = player.Data.Gems;
                pObj["ACo"] = 0;
                pObj["QCo"] = 0;
                pObj["Gnd"] = p.Data.gender;
                pObj["skin"] = p.Data.skinColor;
                pObj["faceAnim"] = 0;
                pObj["inPortal"] = true;
                pObj["SIc"] = 0;
                pObj["D"] = 0;
                pObj["VIPEndTimeAge"] = kukTime;
                pObj["IsVIP"] = false;

                p.Send(ref pObj);
            }

            p.Send(ref bObj);
        }

        public enum GlobalMessageResult
        {
            Unknown,
            Timeout,
            ConnectionFailed,
            AuthenticationFailed,
            NoMessage,
            NoSender,
            NoGems,
            Success,
        }


        public void HandleGlobalMessage(Player p, BSONObject bObj)
        {
            if (p == null)
                return;

            if (p.world == null)
                return;

            if (p.Data.Gems >= 2500)
            {
                p.RemoveGems(2500);

                var cmb = SimpleBSON.Load(Convert.FromBase64String(bObj["msg"]));

                string msg = cmb["message"].stringValue;
                if (msg.Length > 256)
                    return;

                BSONObject gObj = new BSONObject(MsgLabels.Ident.BroadcastGlobalMessage);
                gObj[MsgLabels.ChatMessageBinary] = Util.CreateChatMessage($"<color=#00FFFF>Broadcast from {p.Data.Name}", p.world.WorldName, p.world.WorldName, 1,
                   msg);

                pServer.Broadcast(ref gObj);
            }
        }

        public void getRecentlyVisitedWorlds(Player p)
        {
            if (p == null)
                return;

            if (p.Data.recentlyVisited == null) p.Data.recentlyVisited = new List<string>();

            BSONObject resp = new BSONObject("GRW");
            List<int> playerCounts = new List<int>();

            foreach (string world in p.Data.recentlyVisited)
            {
                int dataToAdd = pServer.GetWorldManager().GetWorlds()
    .FirstOrDefault(data => data.WorldName == world)?
    .Players.Count(player => !player.Data.isInvis) ?? 0; // when we program invis, ignore players who are invisible

                playerCounts.Add(dataToAdd);
            }

            resp["W"] = p.Data.recentlyVisited;
            resp["WN"] = p.Data.recentlyVisited;
            resp["Ct"] = playerCounts;
            p.Send(ref resp);
        }

        public void HandleSpawnPlayer(Player p, BSONObject bObj)
        {
            if (p == null)
                return;

            if (p.world == null)
                return;

            if (p.Data.recentlyVisited == null) p.Data.recentlyVisited = new List<string>();

            if (p.world != null)
            {
                if (!p.Data.recentlyVisited.Contains(p.world.WorldName)) p.Data.recentlyVisited.Add(p.world.WorldName);
            }

            long kukTime = Util.GetKukouriTime();
            BSONObject pObj = new BSONObject();
            pObj[MsgLabels.MessageID] = "AnP";
            pObj["x"] = p.Data.PosX;
            pObj["y"] = p.Data.PosY;
            pObj["t"] = kukTime;
            pObj["a"] = p.Data.Anim;
            pObj["d"] = p.Data.Dir;
            List<int> spotsList = new List<int>();
            //spotsList.AddRange(Enumerable.Repeat(0, 35));

            string prefix = "";


            pObj["spots"] = spotsList;
            pObj["familiar"] = 0;
            pObj["familiarName"] = "";
            pObj["familiarLvl"] = 0;
            pObj["familiarAge"] = kukTime;
            pObj["isFamiliarMaxLevel"] = false;
            pObj["UN"] = prefix + p.Data.Name;
            pObj["U"] = p.Data.UserID.ToString("X8");
            pObj["Age"] = 69;
            pObj["LvL"] = 99;
            pObj["xpLvL"] = 99;
            if (p.Data.OPStatus != 0) pObj["pAS"] = p.Data.OPStatus;
            if (p.Data.adminInEditWorldMode) pObj["PlayerAdminEditMode"] = p.Data.adminInEditWorldMode;
            pObj["Ctry"] = 999;
            pObj["GAmt"] = p.Data.Gems;
            pObj["ACo"] = 0;
            pObj["QCo"] = 0;
            pObj["Gnd"] = 0;
            pObj["skin"] = 7;
            pObj["faceAnim"] = 0;
            pObj["inPortal"] = true;
            pObj["SIc"] = 0;
            pObj["VIPEndTimeAge"] = kukTime;
            pObj["IsVIP"] = false;

            p.world.Broadcast(ref pObj, p);

            BSONObject cObj = new BSONObject("WCM");

            cObj[MsgLabels.ChatMessageBinary] = Util.CreateChatMessage("<color=#00FF00>Credits",
                    p.world.WorldName,
                    p.world.WorldName,
                    1,
                    "PWPS By Dude & Nekto, discord.gg/mW6eE6j2");
            if (p.Data.justRegistered || p.Data.showFirstTimeReg)
            {
                if (p.Data.justRegistered)
                {
                    p.Data.justRegistered = false;
                    p.Data.showFirstTimeReg = true;
                }
                BroadcastClanKickMessage(p, "Hello! Welcome to the server!\n After registering your password is automatically generated\nTo add a passworld you'd like just do /changepass <newPassword>", "SERVER");
            }
            p.Send(ref cObj);
        }

        public void HandleRequestAI(Player p, BSONObject bObj)
        {
            if (p == null)
                return;

            p.Send(ref bObj);
        }

        public void ChangeWorldOrb(Player player, BSONObject request)
        {
            //add a way to get ownerid
            if (player == null || player.world == null) return;
            var ik = new InventoryKey((BlockType)request["bgT"].int32Value, InventoryItemType.Consumable);
            if (!player.Data.InvHelper.HasItemAmountInInventory(ik))
            {
                player.Reconnect(); return;
            }
            player.RemoveItemFromTrashPackets(ik, 1);
            player.Data.InvHelper.RemoveItemsFromInventory(ik);
            var w = player.world;
            int backgroundType = request["bgT"].int32Value;
            w.layerBackgroundType = (LayerBackgroundType)backgroundType;
            var response = new BSONObject("ChangeBackground")
            {
                { "bgT", backgroundType },
                { "U", player.ClientID }
            };
            w.Broadcast(ref response);
        }

        public void HandleGetActiveWorlds(Player p)
        {
            if (p == null)
                return;

            BSONObject resp = new BSONObject("GAW");
            List<string> worldNames = new List<string>();
            List<int> playerCounts = new List<int>();

            foreach (var world in pServer.GetWorldManager().GetWorlds())
            {
                int pC = world.Players.Count;
                if (pC > 0)
                {
                    worldNames.Add(world.WorldName);
                    playerCounts.Add(pC);
                }
            }

            resp["W"] = worldNames;
            resp["WN"] = worldNames;
            resp["Ct"] = playerCounts;
            p.Send(ref resp);
        }

        public void HandleRequestAIp(Player p, BSONObject bObj)
        {
            if (p == null)
                return;

            if (p.world == null)
                return;

            p.Send(ref bObj);
        }

        public void HandleWearableUsed(Player p, BSONObject bObj)
        {
            if (p == null)
                return;

            if (p.world == null)
                return;

            int id = bObj["hBlock"];

            if (id < 0 || id >= ItemDB.ItemsCount())
                return;

            Item it = ItemDB.GetByID(id);

            bObj[MsgLabels.UserID] = p.Data.UserID.ToString("X8");
            p.world.Broadcast(ref bObj, p);
        }

        public void HandleCollect(Player p, int colID)
        {
            if (p == null)
                return;

            if (p.world == null)
                return;

            if (!p.world.collectables.ContainsKey(colID))
                return;


            BSONObject resp = new BSONObject();
            resp["ID"] = "C";
            resp["CollectableID"] = colID;

            var c = p.world.collectables[colID];
            if (c == null) return;
            Vector2i mp = WorldSession.ConvertCollectablePosToMapPoint((float)c.posX, (float)c.posY);
            var dist = WorldSession.DistanceMP(p.CurrentMP, mp);
            if (dist.x > 1 || dist.y > 1) return;
            else if (!p.act.IsTileWalkable(mp.x, mp.y)) return;  //Beta

            resp["BlockType"] = (short)c.BlockType;
            resp["Amount"] = c.amt; // HACK
            resp["InventoryType"] = (short)c.InventoryType;
            resp["PosX"] = c.posX;
            resp["PosY"] = c.posY;
            resp["IsGem"] = c.gemType > -1;
            resp["GemType"] = c.gemType < 0 ? 0 : c.gemType;

            if (c.gemType < 0)
            {
                p.Data.InvHelper.AddItemToInventory(new InventoryKey((BlockType)c.BlockType, c.InventoryType), c.amt);
            }
            else
            {
                int gemsToGive = 0;
                switch ((GemType)c.gemType)
                {
                    case GemType.Gem1:
                        gemsToGive = 1;
                        break;

                    case GemType.Gem2:
                        gemsToGive = 5;
                        break;

                    case GemType.Gem3:
                        gemsToGive = 20;
                        break;

                    case GemType.Gem4:
                        gemsToGive = 50;
                        break;

                    case GemType.Gem5:
                        gemsToGive = 100;
                        break;

                    default:
                        break;
                }

                p.Data.Gems += gemsToGive;
            }

            p.world.RemoveCollectable(colID, p);
            p.Send(ref resp);
        }

        public void HandleWearableRemoved(Player p, BSONObject bObj)
        {
            if (p == null)
                return;

            if (p.world == null)
                return;

            int id = bObj["hBlock"];

            if (id < 0 || id >= ItemDB.ItemsCount())
                return;

            Item it = ItemDB.GetByID(id);


            bObj[MsgLabels.UserID] = p.Data.UserID.ToString("X8");
            p.world.Broadcast(ref bObj, p);
        }

        public void HandleTryToJoinWorldRandom(Player p)
        {
            var worlds = pServer.GetWorldManager().GetWorlds();

            if (worlds.Count > 0)
            {
                var w = worlds[new Random().Next(worlds.Count)];

                BSONObject bObj = new BSONObject();
                bObj["W"] = w.WorldName;

                HandleTryToJoinWorld(p, bObj);
            }
        }

        public void HandleRespawn(Player p, BSONObject bObj)
        {
            if (p == null)
                return;

            if (p.world == null)
                return;
            p.Data.respawning = true;
            var w = p.world;

            BSONObject resp = new BSONObject();
            resp[MsgLabels.MessageID] = "UD";
            resp[MsgLabels.UserID] = p.Data.UserID.ToString("X8");
            resp["x"] = w.SpawnPointX;
            resp["y"] = w.SpawnPointY;
            resp["DBl"] = 0;

            w.Broadcast(ref resp);
            p.Send(ref bObj);
        }
        public void HandleHitBackground(Player p, BSONObject bObj)
        {
            if (p == null)
                return;

            if (p.world == null)
                return;

            long ms = Util.GetMs();
            long lastHit = p.Data.lastHit;
            long timeDiff = ms - lastHit;

            //if (timeDiff > 6000 && p.Data.possibleHacks > 0) p.Data.possibleHacks = 0;
            //if (timeDiff < 2 && !AuthorityHelper.IsPlayerStaffMember(p)) p.Data.possibleHacks++;


            //if (p.Data.possibleHacks > 4)
            //{
            //    p.Reconnect();
            //}

            var w = p.world;

            int x = bObj["x"], y = bObj["y"];
            var tile = w.GetTile(x, y);

            BSONObject resp = new BSONObject("DB");

            if (tile != null)
            {
                if (tile.bg.id <= 0 || !p.InRange(x, y, 2))
                    return;

                if (w.wl != null && !AuthorityHelper.HasMajorRightsToLock(p))
                {
                    BSONObject a = OutgoingMessages.HitBlockBackground(x, y, p);
                    p.world.Broadcast(ref a);
                    return;
                }

                if (ConfigData.BlockHitPoints[tile.bg.id] == -1 && p.Data.OPStatus != 2) //cant break unbreakable
                {
                    BSONObject a = OutgoingMessages.HitBlockBackground(x, y, p);
                    p.world.Broadcast(ref a);
                    return;
                }

                if (Util.GetSec() > tile.bg.lastHit + 4)
                {
                    tile.bg.hitBuffer = ConfigData.BlockHitPoints[tile.bg.id];
                }

                BlockType bt = (BlockType)tile.bg.id;

                tile.bg.hitBuffer -= p.GetDamageForBlock();
                if (tile.bg.hitBuffer <= 0)
                {
                    resp[MsgLabels.DestroyBlockBlockType] = (int)tile.bg.id;
                    resp[MsgLabels.UserID] = p.Data.UserID.ToString("X8");
                    resp["x"] = x;
                    resp["y"] = y;
                    w.Broadcast(ref resp);

                    tile.bg.id = 0;
                    tile.fg.hitBuffer = 0;

                    double pX = x / Math.PI, pY = y / Math.PI;

                    //for (int i = 0; i < 5; i++)
                    //    w.Drop(0, 1, pX - 0.1 + Util.rand.NextDouble(0, 0.2), pY - 0.1 + Util.rand.NextDouble(0, 0.2), Util.rand.Next(5));
                    //BlockType bt = (BlockType)Util.rand.Next(1, 4986);
                    //InventoryItemType it = (InventoryItemType)ItemDB.GetByID((int)bt).type;
                    //w.Drop(new InventoryKey(bt, it), 1, pX - 0.1 + Util.rand.NextDouble(0, 0.2), pY - 0.1 + Util.rand.NextDouble(0, 0.2), -1);
                    w.RandomizeCollectablesForDestroyedBlock(new Vector2i(x, y), bt);
                    p.AddXP(ConfigData.GetBlockXP(bt));
                }
                else
                {
                    BSONObject a = OutgoingMessages.HitBlockBackground(x, y, p);
                    p.world.Broadcast(ref a);
                }

                tile.bg.lastHit = Util.GetSec();
            }
        }

        public void HandleHitBlock(Player p, BSONObject bObj)
        {
            if (p == null)
                return;

            if (p.world == null)
                return;


            long ms = Util.GetMs();
            long lastHit = p.Data.lastHit;
            long timeDiff = ms - lastHit;

            //if (timeDiff > 6000 && p.Data.possibleHacks > 0) p.Data.possibleHacks = 0;
            //if (timeDiff < 2 && !AuthorityHelper.IsPlayerStaffMember(p)) p.Data.possibleHacks++;

            //if (p.Data.possibleHacks > 4)
            //{
            //    p.Reconnect();
            //}
            p.Data.lastHit = ms;

            int x = bObj["x"], y = bObj["y"];
            var w = p.world;
            var tile = w.GetTile(x, y);

            BSONObject resp = new BSONObject("DB");

            if (tile != null)
            {
                if (tile.fg.id <= 0 || !p.InRange(x, y, 2))
                    return;

                BlockType bt = (BlockType)tile.fg.id;

                if (!ConfigData.IsBlockDataEditableByAnyone(bt))
                {
                    if (w.wl != null && !AuthorityHelper.HasMajorRightsToLock(p))
                    {
                        BSONObject a = OutgoingMessages.HitBlock(x, y, p);
                        p.world.Broadcast(ref a);
                        return;
                    }
                    else if (w.wl != null && w.wl.pos.x == x && w.wl.pos.y == y && !w.wl.IsOwner(p.ClientID) && !p.Data.adminInEditWorldMode)
                    {
                        BSONObject a = OutgoingMessages.HitBlock(x, y, p);
                        p.world.Broadcast(ref a);
                        return;
                    }

                    if (ConfigData.BlockHitPoints[tile.fg.id] == -1 && !p.Data.adminInEditWorldMode) //cant break unbreakable
                    {
                        BSONObject a = OutgoingMessages.HitBlock(x, y, p);
                        p.world.Broadcast(ref a);
                        return;
                    }

                    if (Util.GetSec() > tile.fg.lastHit + 4)
                    {
                        tile.fg.hitBuffer = ConfigData.BlockHitPoints[tile.fg.id];
                    }
                }

                if (tile.fg.id == (short)BlockType.Tree)
                {
                    var seed = p.world.plantedSeeds[x, y];
                    if (seed is null)
                    {
                        // what the fuck
                        Util.Log($"No seed in {x},{y}; set it");
                        p.world.plantedSeeds[x, y] = new SeedData(BlockType.SoilBlock, new Vector2i(x, y), 30, false);
                        seed = p.world.plantedSeeds[x, y];
                    }

                    if (DateTime.UtcNow >= seed.GrowthEndTime)
                    {
                        tile.fg.hitBuffer = 0;
                    }
                }

                if (w.worldItemsData[x, y] != null)
                {
                    if (ConfigData.IsBlockDisplay(bt))
                    {
                        if (w.worldItemsData[x, y]["storageItemAsInventoryKey"].int32Value != 0)
                            return;
                    }
                }
                tile.fg.hitBuffer -= p.GetDamageForBlock();
                if (tile.fg.hitBuffer <= 0)
                {
                    resp[MsgLabels.DestroyBlockBlockType] = (int)tile.fg.id;
                    resp[MsgLabels.UserID] = p.Data.UserID.ToString("X8");
                    resp["x"] = x;
                    resp["y"] = y;
                    w.Broadcast(ref resp);

                    if (ConfigData.IsLock(bt))
                    {
                        if (w.wl != null)
                        {
                            w.wl.Destroy();
                            //w.Drop(new InventoryKey((BlockType)tile.fg.id, InventoryItemType.Block), 1, pX, pY);
                            //HandleCollect(p, w.colID);
                            p.AdminGive(new InventoryKey((BlockType)tile.fg.id, InventoryItemType.Block), 1);
                        }
                    }

                    w.RandomizeCollectablesForDestroyedBlock(new Vector2i(x, y), bt);
                    w.plantedSeeds[x, y] = null;

                    tile.fg.id = 0;
                    tile.fg.hitBuffer = 0;
                    w.worldItemsData[x, y] = null;
                    p.AddXP(ConfigData.GetBlockXP(bt));

                }
                else
                {
                    BSONObject a = OutgoingMessages.HitBlock(x, y, p);
                    p.world.Broadcast(ref a);
                }

                tile.fg.lastHit = Util.GetSec();
            }
        }

        public void HandleHitWater(Player p, BSONObject bObj)
        {
            if (p == null)
                return;

            if (p.world == null)
                return;

            long ms = Util.GetMs();
            long lastHit = p.Data.lastHit;
            long timeDiff = ms - lastHit;

            //if (timeDiff > 5000 && p.Data.possibleHacks > 0) p.Data.possibleHacks = 0;
            //if (timeDiff < 2 && !AuthorityHelper.IsPlayerStaffMember(p)) p.Data.possibleHacks++;


            //if (p.Data.possibleHacks > 4)
            //{
            //    p.Reconnect();
            //}

            var w = p.world;

            int x = bObj["x"], y = bObj["y"];
            var tile = w.GetTile(x, y);
            double distance = PWServer.GetDistance((x / Math.PI), (y / Math.PI), p.Data.PosX, p.Data.PosY);

            if (distance > 1)
            {
                if (distance > 2) p.Reconnect();
                return;
            }

            BSONObject resp = new BSONObject("DB");

            if (tile != null || !p.InRange(x, y, 2))
            {
                if (tile.water.id <= 0)
                    return;

                if (w.wl != null && !AuthorityHelper.HasMajorRightsToLock(p))
                {
                    BSONObject a = OutgoingMessages.HitBlockWater(x, y, p);
                    p.world.Broadcast(ref a);
                    return;
                }

                if (Util.GetSec() > tile.water.lastHit + 4)
                {
                    tile.water.hitBuffer = ConfigData.BlockHitPoints[tile.water.id];
                }

                BlockType bt = (BlockType)tile.water.id;

                tile.water.hitBuffer -= p.GetDamageForBlock();
                if (tile.water.hitBuffer <= 0)
                {
                    resp[MsgLabels.DestroyBlockBlockType] = (int)tile.water.id;
                    resp[MsgLabels.UserID] = p.Data.UserID.ToString("X8");
                    resp["x"] = x;
                    resp["y"] = y;
                    w.Broadcast(ref resp);

                    tile.water.id = 0;
                    tile.water.hitBuffer = 0;

                    double pX = x / Math.PI, pY = y / Math.PI;
                    w.RandomizeCollectablesForDestroyedBlock(new Vector2i(x, y), bt);
                    p.AddXP(ConfigData.GetBlockXP(bt));
                }
                else
                {
                    BSONObject a = OutgoingMessages.HitBlockWater(x, y, p);
                    p.world.Broadcast(ref a);
                }

                tile.water.lastHit = Util.GetSec();
            }
        }

        public void HandleSetBlock(Player p, BSONObject bObj)
        {
            if (p == null)
                return;

            if (p.world == null)
                return;

            var w = p.world;

            int x = bObj["x"], y = bObj["y"];
            BlockType blockType = (BlockType)bObj["BlockType"].int32Value;
            InventoryKey inventoryKey = new InventoryKey(blockType, InventoryItemType.Block);


            var invIt = p.Data.InvHelper.HasItemAmountInInventory(inventoryKey);
            if (!invIt || !p.InRange(x, y, 2))
                return;

            if (w.wl != null && !AuthorityHelper.HasMajorRightsToLock(p))
            {
                return;
            }

            if (ConfigData.IsLock(blockType))
            {
                //checking for existing World Lock!
                if (w.wl != null)
                    return;
            }

            Item it = ItemDB.GetByID((int)blockType);
            if (it.type != 0)
                return;

            bObj["U"] = p.Data.UserID.ToString("X8");

            if (ConfigData.BlockHitPoints[(int)blockType] == -1 && p.Data.OPStatus != 2)
            {
                var ft = w.GetTile(x, y);
                bObj["BlockType"] = 1163; //hazard block, чтобы не могли ставить unbreakable 
                ft.fg.id = 1163;
                ft.fg.hitBuffer = ConfigData.BlockHitPoints[1163];
                ft.fg.lastHit = 0;
                w.Broadcast(ref bObj);
                return;
            }

            var t = w.GetTile(x, y);
            if (t.fg.id != 0) return; //Cant place, other block there!
            t.fg.id = (short)blockType;
            t.fg.hitBuffer = ConfigData.BlockHitPoints[t.fg.id];
            t.fg.lastHit = 0;

            w.Broadcast(ref bObj);
            //data stuff
            if (DataFactory.DoesBlockNeedData(p, blockType))
            {
                p.world.worldItemsData[x, y] = DataFactory.SpawnBSON(p, (int)blockType, DataFactory.Pair(x, y));
                if (ConfigData.IsLock(blockType))
                    p.world.wl = new WorldLockHelper(p.world, p.world.worldItemsData[x, y], x, y);

                BSONObject resp = new BSONObject()
                {
                    ["ID"] = "WIU",
                    ["WiB"] = p.world.worldItemsData[x, y],
                    ["x"] = x,
                    ["y"] = y,
                    ["PT"] = 1,
                    ["U"] = p.ClientID
                };
                w.Broadcast(ref resp);
            }

            p.Data.InvHelper.RemoveItemsFromInventory(inventoryKey);
        }

        public void HandleSetBackgroundBlock(Player p, BSONObject bObj)
        {
            if (p == null)
                return;

            if (p.world == null)
                return;

            var w = p.world;

            if (w.wl != null && !AuthorityHelper.HasMajorRightsToLock(p))
            {
                return;
            }

            int x = bObj["x"], y = bObj["y"];
            BlockType blockType = (BlockType)bObj["BlockType"].int32Value;
            InventoryKey inventoryKey = new InventoryKey(blockType, InventoryItemType.BlockBackground);
            Item it = ItemDB.GetByID((short)blockType);

            var invIt = p.Data.InvHelper.HasItemAmountInInventory(inventoryKey);

            if (!invIt || !p.InRange(x, y, 2))
                return;

            if (it.type != 1)
                return;

            bObj["U"] = p.Data.UserID.ToString("X8");


            var t = w.GetTile(x, y);
            t.bg.id = (short)blockType;
            t.bg.hitBuffer = ConfigData.BlockHitPoints[t.bg.id];
            t.bg.lastHit = 0;

            w.Broadcast(ref bObj);

            p.Data.InvHelper.RemoveItemsFromInventory(inventoryKey);
        }

        public void HandleSetBlockWater(Player p, BSONObject bObj)
        {
            if (p == null)
                return;

            if (p.world == null)
                return;

            var w = p.world;

            if (w.wl != null && !AuthorityHelper.HasMajorRightsToLock(p))
            {
                return;
            }

            int x = bObj["x"], y = bObj["y"];
            BlockType blockType = (BlockType)bObj["BlockType"].int32Value;
            InventoryKey inventoryKey = new InventoryKey(blockType, InventoryItemType.BlockWater);
            Item it = ItemDB.GetByID((int)blockType);

            var invIt = p.Data.InvHelper.HasItemAmountInInventory(inventoryKey);
            if (!invIt || !p.InRange(x, y, 2))
                return;

            if (it.type != 3)
                return;

            bObj["U"] = p.Data.UserID.ToString("X8");


            var t = w.GetTile(x, y);
            if (t.water.id != 0 || !ConfigData.CanBlockBeBehindWater(blockType)) return; //Cant place, other block there!
            t.water.id = (short)blockType;
            t.water.hitBuffer = ConfigData.BlockHitPoints[t.water.id];
            t.water.lastHit = 0;

            w.Broadcast(ref bObj);

            p.Data.InvHelper.RemoveItemsFromInventory(inventoryKey);
        }

        public void HandleDropItem(Player p, BSONObject bObj)
        {
            try
            {
                if (p == null || p.world == null) return;
                BSONObject request = bObj["dI"] as BSONObject;
                WorldSession.ConvertMapPointToWorldPoint(new Vector2i(bObj["x"].int32Value, bObj["y"].int32Value), out double x, out double y);
                x = bObj["x"].doubleValue / Math.PI - 0.1 + Util.rand.NextDouble(0, 0.13);
                y = bObj["y"].doubleValue / Math.PI - 0.1 + Util.rand.NextDouble(0, 0.13);
                BlockType blockType = (BlockType)request["BlockType"].int32Value;
                InventoryItemType itemType = (InventoryItemType)request["InventoryType"].int32Value;
                InventoryKey ikData = new InventoryKey(blockType, itemType);
                short amt = (short)request["Amount"].int32Value;
                bool inventoryItem = p.Data.InvHelper.HasItemAmountInInventory(ikData, amt);
                if (!inventoryItem || !ConfigData.IsTradeable(blockType)) return;
                p.Data.InvHelper.RemoveItemsFromInventory(blockType, itemType, amt);
                p.RemoveItemFromTrashPackets(ikData, amt);
                p.world.Drop(ikData, amt, x, y, -1);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void HandleTrashItem(Player p, BSONObject bObj)
        {
            BSONObject request = bObj["dI"] as BSONObject;
            if (request != null)
            {
                request.TryGetValue("BlockType", out var bt);
                request.TryGetValue("InventoryType", out var inventoryType);
                request.TryGetValue("Amount", out var amt);
                p.Data.InvHelper.RemoveItemsFromInventory((BlockType)(int)bt, (InventoryItemType)(int)inventoryType, (short)amt);
                BSONObject response = new BSONObject()
                {
                    { "ID", "RIi" },
                    { "rI", request }
                };
                p.Send(ref response);
            }
        }

        public void HandleMovePlayer(Player p, BSONObject bObj)
        {
            if (p == null)
                return;

            if (p.world == null)
                return;

            if (bObj.ContainsKey("x") &&
                bObj.ContainsKey("y") &&
                bObj.ContainsKey("a") &&
                bObj.ContainsKey("d") &&
                bObj.ContainsKey("t"))

            {
                WorldSession world = p.world;

                double prevX = p.Data.PosX;
                double prevY = p.Data.PosY;
                p.Data.PosX = bObj["x"].doubleValue;
                p.Data.PosY = bObj["y"].doubleValue;
                Vector2i mp = WorldSession.ConvertWorldPointToMapPoint((float)p.Data.PosX, (float)p.Data.PosY);
                Vector2i mp_prev = WorldSession.ConvertWorldPointToMapPoint((float)prevX, (float)prevY);
                BlockType tile = world.GetBlockType(mp);
                if (mp != mp_prev)
                {
                    
                    string onKickReason = $"{p.Data.Name}, move from {prevX}{prevY} to {p.Data.PosX}{p.Data.PosY},\n" +
                        $"move from  {mp_prev} to {mp}, new block: {tile}\n" +
                        $"Extra: ";

                    //out of range teleport detector
                    if (!p.act.LegalMove(mp_prev, mp) && !ConfigData.IsPortalWireable(tile) && tile != BlockType.EntrancePortal && !AuthorityHelper.IsPlayerStaffMember(p))
                    {
                        p.Reconnect(onKickReason + "out of range tp");
                        return;
                    }
                    //noclip
                    if (mp != p.PreviousMp && !p.act.IsTileWalkable(mp.x, mp.y) && !AuthorityHelper.IsPlayerStaffMember(p))
                    {
                        p.Reconnect(onKickReason + "WalkIN (wallhack)");
                        return;
                    }
                }




                //double changeBetweenX = p.Data.PosX - prevX;
                //double changeBetweenY = p.Data.PosY - prevY;

                //double posX = p.Data.PosX * Math.PI + 0.5;
                //double posY = p.Data.PosY * Math.PI + 0.5;
                //WorldTile tileOn = world.GetTile((int)posX, (int)posY); // Player exact pos.
                //WorldTile tileAbove = world.GetTile((int)posX, (int)posY + 1);
                //WorldTile tileBelow = world.GetTile((int)posX, (int)posY - 1);
                //WorldTile tileLeft = world.GetTile((int)posX - 1, (int)posY);
                //WorldTile tileRight = world.GetTile((int)posX + 1, (int)posY);

                //if (tileAbove != null && tileBelow != null && tileLeft != null && tileRight != null && tileOn != null)
                //{
                //    if (tileOn.fg.id != 110) // 110 = spawn.
                //    {
                //        int tileId = tileOn.fg.id;
                //        long beenInsideBlock = p.Data.beenInsideBlockFor;
                //        long milliseconds = 0;
                //        long currentTime = Util.GetMs();
                //        var tileCheck = tileId == tileAbove.fg.id && tileId == tileBelow.fg.id && tileId == tileLeft.fg.id && tileId == tileRight.fg.id && !MsgLabels.allowedFg.Contains(tileId);


                //        milliseconds = currentTime - beenInsideBlock;

                //        if (milliseconds > 2200)
                //        {
                //            if (p.Data.respawning) p.Data.respawning = false;
                //            milliseconds = 0;
                //            beenInsideBlock = 0;
                //        }

                //        if (tileId != 0) // On a block.
                //        {
                //            if (tileCheck && beenInsideBlock == 0)
                //            {
                //                beenInsideBlock = currentTime;
                //            }

                //            bool walkingWhileInBlock = !p.Data.respawning && changeBetweenX >= 0.2 && MsgLabels.illegalFg.Contains(tileId) || !p.Data.respawning && changeBetweenX <= -0.2 && MsgLabels.illegalFg.Contains(tileId);

                //            if (milliseconds >= 2000 && tileCheck && !p.Data.respawning || walkingWhileInBlock) // If is inside block for more than 2 seconds and doesn't come out. (Must match all the given options in tileCheck var or match the banned block criteria).
                //            {
                //                p.Reconnect();
                //            }
                //        }

                //        if (p.Data.beenInsideBlockFor != beenInsideBlock) p.Data.beenInsideBlockFor = beenInsideBlock;
                //    }
                //}
                if (bObj["a"].int32Value == (int)AnimationNames.Invisible)
                {
                    if (!ConfigData.CanPlayerHide(tile))
                    {
                        OutgoingMessages.PlayerLeft(p.ClientID);
                        p.Reconnect();
                        return;
                    }
                }

                p.Data.Anim = bObj["a"];
                p.Data.Dir = bObj["d"];
                bObj["U"] = p.Data.UserID.ToString("X8");

                if (bObj.ContainsKey("tp"))
                    bObj.Remove("tp");

                //if (p.Data.isInvis) return;
                p.PreviousMp = mp;
                p.world.Broadcast(ref bObj, p);
            }
        }

        public void HandleSyncTime(FeatherClient client)
        {
            BSONObject resp = new BSONObject(MsgLabels.Ident.SyncTime);
            resp[MsgLabels.MessageID] = MsgLabels.Ident.SyncTime;
            resp[MsgLabels.TimeStamp] = Util.GetKukouriTime();
            resp[MsgLabels.SequencingInterval] = 60;

            client.Send(resp);
        }

        public void HandleWorldItemUpdate(Player p, BSONObject bson)
        {
            if (!p.InWorld())
                return;

            //force data set by admin
            if (p.Data.OPStatus == 2 && p.Data.adminInEditWorldMode)
            {
                p.world.worldItemsData[bson["x"], bson["y"]] = bson["WiB"] as BSONObject;
                if (ConfigData.IsLock(bson["WiB"]["blockType"].blockTypeValue))
                    p.world.wl = new WorldLockHelper(p.world, bson["WiB"] as BSONObject, bson["x"].int32Value, bson["y"].int32Value);
                BSONObject re = bson;
                re["U"] = p.Data.UserID.ToString("X8");

                p.world.Broadcast(ref re);
                return;
            }
            //validate values
            BSONObject data = p.world.worldItemsData[bson["x"].int32Value, bson["y"].int32Value];

            if (bson.ContainsKey("WiB") && bson["WiB"].ContainsKey("blockType"))
            {
                if (!DataFactory.ValidateWIB(bson["WiB"], p))
                {
                    p.Reconnect();
                    return;
                }
                bson["WiB"]["blockType"] = data["blockType"].int32Value; //black-niga-hackers prevention
                bson["WiB"]["class"] = data["class"].stringValue;
            }
            else
            {
                p.Reconnect();
                return;
            }

            //main logic
            BSONObject wib = bson["WiB"] as BSONObject;
            BlockType bt = data["blockType"].blockTypeValue;
            BSONObject resp = bson;
            resp["WiB"] = data;
            resp["PT"] = 1;
            resp["U"] = p.ClientID;

            if (ConfigData.IsLock(bt)) //WORLD LOCKS
            {

                if (!p.world.wl.IsOwner(p.ClientID))
                {
                    p.Reconnect();
                    return;
                }

                WorldLockHelper wl = p.world.wl;
                //isOpen
                wl.isOpen = wib["isOpen"].boolValue;
                //isBattleOn
                if (bt == BlockType.LockWorldBattle || bt == BlockType.LockWorldBattleFaction)
                    wl.isBattleOn = wib["isBattleOn"].boolValue;
                else
                    wl.isBattleOn = false;
                //last activated
                wl.lastActivatedTime = DateTime.UtcNow;
                //punching
                wl.punchingAllowed = wib["punchingAllowed"].boolValue;
                //fulls
                List<string> fulls = wib["playersWhoHaveAccessToLock"].stringListValue;
                foreach (string user in fulls)
                {
                    if (!PlayerIdNameHelper.IsValidCombined(user) || wl.minors.Contains(user) || wl.ownerId == PlayerIdNameHelper.GetPlayerIdFromCombined(user))
                    {
                        fulls.Remove(user);
                    }
                }
                wl.fulls = fulls;
                //minors
                List<string> minors = wib["playersWhoHaveMinorAccessToLock"].stringListValue;
                foreach (string user in minors)
                {
                    if (!PlayerIdNameHelper.IsValidCombined(user) || wl.fulls.Contains(user) || wl.ownerId == PlayerIdNameHelper.GetPlayerIdFromCombined(user))
                    {
                        minors.Remove(user);
                    }
                }
                wl.minors = minors;
                //success
                resp["WiB"] = wl.AsBSON();

            }
            else if (ConfigData.IsAnyDoor(bt))
            {
                if (ConfigData.IsBasicDoor(bt) || ConfigData.IsBasicHatch(bt)) ;
                {
                    if (!AuthorityHelper.HasMinorRightsToLock(p))
                    {
                        p.Reconnect();
                        return;
                    }
                    data["isLocked"] = wib["isLocked"].boolValue;
                }
            }
            else if (ConfigData.IsPortalWireable(bt))
            {
                if (!AuthorityHelper.HasMinorRightsToLock(p))
                {
                    p.Reconnect();
                    return;
                }
                string buf = "";

                data["isLocked"] = wib["isLocked"].boolValue;

                buf = wib["name"].stringValue;
                ProfanityFilter.StripTags(ref buf);
                data["name"] = buf;

                buf = wib["targetWorldID"].stringValue;
                ProfanityFilter.StripTags(ref buf);
                data["targetWorldID"] = buf;

                buf = wib["targetEntryPointID"].stringValue;
                ProfanityFilter.StripTags(ref buf);
                data["targetEntryPointID"] = buf;

                buf = wib["entryPointID"].stringValue;
                ProfanityFilter.StripTags(ref buf);
                data["entryPointID"] = buf;
            }

            //RESPONSE

            p.world.Broadcast(ref resp);

        }

        public void HandleSetSeed(Player p, BSONObject bson)
        {
            int bt = bson["BlockType"].int32Value;
            BlockType blockType = (BlockType)bt;
            int x = bson["x"], y = bson["y"];
            WorldSession w = p.world;

            WorldTile tile = w.GetTile(x, y);
            if (tile != null)
            {
                if (tile.fg.id != 37 && tile.fg.id != 0)
                    return;

                if (!p.Data.InvHelper.HasItemAmountInInventory(blockType, InventoryItemType.Seed))
                    return;

                if (w.wl != null && !AuthorityHelper.HasMajorRightsToLock(p))
                {
                    return;
                }


                if (blockType == BlockType.Fertilizer || blockType == BlockType.FertilizerLarge || blockType == BlockType.PotionInstantGrowth)
                {
                    SeedData seed = w.plantedSeeds[x, y];
                    if (seed == null)
                    {
                        tile.fg.id = 0;
                        return;
                    }

                    if (DateTime.UtcNow.CompareTo(w.plantedSeeds[x, y].GrowthEndTime) > 0)
                        return;

                    int hoursToBeCut = 1;
                    switch (blockType)
                    {
                        case BlockType.FertilizerLarge:
                            hoursToBeCut = 10;
                            break;
                        case BlockType.PotionInstantGrowth:
                            hoursToBeCut = 10000;
                            break;

                    }

                    w.plantedSeeds[x, y].GrowthEndTime = w.plantedSeeds[x, y].GrowthEndTime.AddHours(-hoursToBeCut);
                    BSONObject resp = w.plantedSeeds[x, y].AsBSON();
                    resp["ID"] = "SS";
                    resp["U"] = p.ClientID;
                    resp["SFe"] = true;
                    w.Broadcast(ref resp);
                }

                p.Data.InvHelper.RemoveItemsFromInventory(blockType, InventoryItemType.Seed);


                if (tile.fg.id == 0)
                {
                    w.SetSeed(new Vector2i(x, y), blockType, false, false, p.ClientID);
                    return;
                }
                else if (tile.fg.id == 37)
                {
                    SeedData seed = w.plantedSeeds[x, y];
                    if (seed == null)
                    {
                        tile.fg.id = 0;
                        return;
                    }

                    if (seed.IsAlreadyCrossBred)
                        return;

                    BlockType result = Seeds.GetCrossBreedingResult(new BlockTuple(seed.BlockType, blockType));
                    if (result != BlockType.None)
                    {
                        w.SetSeed(seed.Position, result, true, false, p.ClientID);
                    }
                }
            }
        }

        public void HandleTryToSecureWorldItem(Player p, BSONObject obj)
        {
            if (obj.ContainsKey("x") && obj.ContainsKey("y"))
            {

                BSONObject r = new BSONObject("TTSWi")
                {
                    ["S"] = true,
                    ["x"] = obj["x"].int32Value,
                    ["y"] = obj["y"].int32Value
                };

                p.Send(ref r);
            }
        }

        public void HandleAdjustDisplayItem(Player p, BSONObject obj)
        {
            if (!p.InWorld())
                return;

            //checking for rights
            if (p.world.wl != null && !AuthorityHelper.HasMajorRightsToLock(p))
            {
                p.Reconnect();
                return;
            }
            //checking for range

            BSONObject buf = p.world.worldItemsData[obj["x"].int32Value, obj["y"].int32Value];
            if (buf == null || !DataFactory.ValidateWIB(obj["WiB"], p) || !ConfigData.IsBlockDisplay((BlockType)buf["blockType"].int32Value))
                return;

            //take from action
            if (obj["WiB"]["storageItemAsInventoryKey"].int32Value == 0)
            {
                if (buf["storageItemAsInventoryKey"].int32Value == 0)
                {
                    p.Reconnect();
                    return;
                }
                else
                {
                    InventoryKey ik = (InventoryKey)buf["storageItemAsInventoryKey"].int32Value;
                    buf["storageItemAsInventoryKey"] = 0;
                    p.Data.InvHelper.AddItemToInventory(ik);
                }

            }
            //put to action
            else
            {
                if (buf["storageItemAsInventoryKey"].int32Value != 0)
                {
                    p.Reconnect();
                    return;
                }

                InventoryKey ik = (InventoryKey)obj["WiB"]["storageItemAsInventoryKey"].int32Value;
                if (p.Data.InvHelper.HasItemAmountInInventory(ik))
                {
                    buf["storageItemAsInventoryKey"] = (int)ik;
                    p.Data.InvHelper.RemoveItemsFromInventory(ik);
                }
                else
                {
                    p.Reconnect();
                    return;
                }
            }

            obj["WiB"] = buf;
            obj["U"] = p.ClientID;
            obj["ID"] = "WIU";
            p.world.Broadcast(ref obj);

        }

        public void HandleAdjustDisplayMessage(Player p, BSONObject obj)
        {
            if (!p.InWorld())
                return;

            //checking for rights
            if (p.world.wl != null && !AuthorityHelper.HasMajorRightsToLock(p))
            {
                p.Reconnect();
                return;
            }
            //checking for range

            BSONObject buf = p.world.worldItemsData[obj["x"].int32Value, obj["y"].int32Value];
            if (buf == null || !DataFactory.ValidateWIB(obj["WiB"], p) || !ConfigData.IsBlockDisplay((BlockType)buf["blockType"].int32Value))
                return;

            buf["text"] = obj["WiB"]["text"];
            obj["WiB"] = buf;
            obj["U"] = p.ClientID;
            obj["ID"] = "WIU";
            p.world.Broadcast(ref obj);

            //if (buf != obj["WiB"])
            //    return;
            //else
            //{
            //    p.world.worldItemsData[obj["x"].int32Value, obj["y"].int32Value] = buf;
            //    obj["U"] = p.ClientID;
            //    obj["ID"] = "WIU";
            //    p.world.Broadcast(ref obj);
            //}
        }

        public void HandleWarpPlayer(Player p, BSONObject o)
        {
            if (p != null && p.InWorld())
            {
                Player target = p.world.Players.Find((Player pl) => pl.ClientID == o["U"].stringValue);
                if (target != null)
                {
                    if (AuthorityHelper.CanSummon(p, target))
                    {

                        BSONObject r = new BSONObject()
                        {
                            ["ID"] = "WP",
                            ["U"] = p.ClientID,
                            ["PX"] = p.CurrentMP.x,
                            ["PY"] = p.CurrentMP.y
                        };
                        target.Send(ref r);
                        r = new BSONObject()
                        {
                            ["ID"] = "DoPSE",
                            ["U"] = target.ClientID,
                            ["PX"] = target.CurrentMP.x,
                            ["PY"] = target.CurrentMP.y
                        };
                        target.world.Broadcast(ref r);
                    }
                    else
                    {
                        BSONObject r = new("TryingToMessWithAnAdmin");
                        p.Send(ref r);
                    }
                }
            }
        }

        public void HandleKickPlayer(Player p, BSONObject o, int idx, bool universal = false, int timeInMinutes = 30, string reason = "Unknown")
        {
            if (p != null && p.InWorld())
            {
                Player target = p.world.Players.Find((Player pl) => pl.ClientID == o["U"].stringValue);
                if (target != null)
                {
                    if (AuthorityHelper.CanKickBan(p, target))
                    {
                        DateTime banEndTime = DateTime.UtcNow.AddMinutes(timeInMinutes);
                        string wn = target.world.WorldName;
                        if (idx == 1)
                            target.AddWorldBan(wn, banEndTime);


                        Util.Log($"Player with UserID {target.Data.UserID} kicked/banned the world!");

                        BSONObject r = new BSONObject()
                        {
                            ["ID"] = "KPl",
                            ["BPl"] = idx < 1 ? 0 : 1,
                            ["BanState"] = universal ? "Universal" : "World",
                            ["T"] = banEndTime.Ticks,
                            ["WN"] = wn,
                            ["BanFromGameReasonValue"] = reason
                        };
                        target.Send(ref r);

                        target.world.RemovePlayer(target);
                        target.isLoadingWorld = false;
                        r = new BSONObject()
                        {
                            ["ID"] = "PL",
                            ["U"] = target.ClientID,
                            ["Idx"] = idx
                        };
                        p.world.Broadcast(ref r);


                    }
                    else
                    {
                        BSONObject r = new("TryingToMessWithAnAdmin");
                        p.Send(ref r);
                    }
                }
            }
        }

        public void HandleSetAdminWantsToBeSummoned(Player p, BSONObject o)
        {
            if (AuthorityHelper.IsPlayerStaffMember(p))
            {
                Util.Log(SimpleBSON.DumpBSON(o));
                p.Data.adminWantsToBeSummoned = o["SetAdminWantsToBeSummonedValue"].boolValue;
            }
            else
            {
                p.Reconnect();
                return;
            }
        }
        public void HandleSetEditWorldByAdmin(Player p, BSONObject o)
        {
            if (AuthorityHelper.IsPlayerAdmin(p))
            {
                p.Data.adminInEditWorldMode = o["SetEditWorldByAdminValue"].boolValue;
                BSONObject r = new("AdminSetEditMode")
                {
                    ["AdminSetEditModeValue"] = p.Data.adminInEditWorldMode,
                    ["U"] = p.ClientID
                };
                p.world.Broadcast(ref r, p);
            }
            else
            {
                p.Reconnect();
                return;
            }
        }
        public void HandleWarnPlayer(Player p, BSONObject request)
        {
            if (AuthorityHelper.IsPlayerStaffMember(p))
            {
                string warnReason = request["ReasonForWarning"].stringValue;
                Player targetUser = p.world.Players.Find((Player pl) => pl.ClientID == request["U"].stringValue);

                if (targetUser != null)
                {
                    PWServer.warnPlayer(targetUser, warnReason);
                    targetUser.Data.warnCount++;
                    Player.AddBanOrWarning(ref targetUser.Data.warnsDetails, warnReason, p.Data.Name, DateTime.UtcNow);
                    Player.AddBanOrWarning(ref p.Data.givenWarnsDetails, warnReason, p.Data.Name, DateTime.UtcNow);
                }
            }
            else
            {
                p.Reconnect(); //if not staff
            }
        }

        public void HandleBanPlayer(Player p, BSONObject request)
        {
            if (!AuthorityHelper.IsPlayerStaffMember(p)) return;
            if (p.ClientID == request["U"].stringValue) return;

            string banReason = request["BanFromGameReasonValue"].stringValue;
            long banLength = 0;

            if (long.TryParse(request["BanFromGameDurationValue"].stringValue, out banLength))
            {
                Player targetUser = p.world.Players.Find((Player pl) => pl.ClientID == request["U"].stringValue);
                if (targetUser != null)
                {
                    PWServer.banPlayer(targetUser, banLength, banReason, false);
                    targetUser.Data.banCount++;
                    Player.AddBanOrWarning(ref targetUser.Data.bansDetails, banReason, p.Data.Name, DateTime.UtcNow);
                    Player.AddBanOrWarning(ref p.Data.givenBansDetails, banReason, p.Data.Name, DateTime.UtcNow);
                    targetUser.world.RemovePlayer(targetUser);
                    targetUser.isLoadingWorld = false;
                    var r = new BSONObject()
                    {
                        ["ID"] = "PL",
                        ["U"] = targetUser.ClientID,
                        ["Idx"] = 2
                    };
                    p.world.Broadcast(ref r);
                }
            }
        }

        public void HandleQueryPlayerInformation(Player p, BSONObject request)
        {
            try
            {
                if (p == null) return;
                Player targetUser = p.world.Players.Find((Player pl) => pl.ClientID == request["U"].stringValue);
                if (targetUser == null) return;

                int opStatus = targetUser.Data.OPStatus;
                string rank = "Reqular";
                if (opStatus == 2)
                {
                    rank = "Admin (VIP)";
                }
                else if (opStatus == 1)
                {
                    rank = "Mod (VIP)";
                }
                else if (p.Data.level < 30 && !AuthorityHelper.IsPlayerStaffMember(p))
                {
                    rank = "NAB";
                }
                else if (p.Data.level > 100 && !AuthorityHelper.IsPlayerStaffMember(p))
                {
                    rank = "PRO";
                }
                BSONObject response;
                if (AuthorityHelper.IsPlayerStaffMember(p))
                {
                    response = new BSONObject()
                    {
                    { "ID", "QPi"},
                    { "TuID", targetUser.ClientID },     //level, legacyLVL, Status, Age, achievements, quests, VIPDays, gems, Bans, Warnings, BansGiven, WarnsGiven
                    { "QueryResult", new List<string>() { targetUser.Data.level.ToString(), "1", rank, "365d", "72", "0", "365 Days", targetUser.Data.Gems.ToString(), targetUser.Data.banCount.ToString(), targetUser.Data.warnCount.ToString(), "hidden", "hidden" } }
                    };
                    if (targetUser.Data.bansDetails != null)
                        response["QueryResult1"] = targetUser.Data.bansDetails;
                    else
                        response["QueryResult1"] = new List<string>() { "" };

                    if (targetUser.Data.warnsDetails != null)
                        response["QueryResult2"] = targetUser.Data.warnsDetails;
                    else
                        response["QueryResult2"] = new List<string>() { "" };

                    if (targetUser.Data.givenBansDetails != null && AuthorityHelper.IsPlayerStaffMember(targetUser))
                        response["QueryResult3"] = targetUser.Data.givenBansDetails;
                    else if (AuthorityHelper.IsPlayerStaffMember(targetUser))
                        response["QueryResult3"] = new List<string>() { "" };

                    if (targetUser.Data.givenWarnsDetails != null && AuthorityHelper.IsPlayerStaffMember(targetUser))
                        response["QueryResult4"] = targetUser.Data.warnsDetails;
                    else if (AuthorityHelper.IsPlayerStaffMember(targetUser))
                        response["QueryResult4"] = new List<string>() { "" };
                }
                else
                {
                    response = new BSONObject()
                    {
                    { "ID", "QPi"},
                    { "TuID", targetUser.ClientID },
                    { "QueryResult", new List<string>() { targetUser.Data.level.ToString(), "1", rank, "365d", "72", "0", "365 Days" } }
                    };
                }
                p.Send(ref response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void HandlePlayPortalInAnimation(Player p, BSONObject obj)
        {
            if (p == null || p.world == null || !obj.ContainsKey("x") || !obj.ContainsKey("y"))
            {
                return;
            }
            int x = obj["x"].int32Value;
            int y = obj["x"].int32Value;
            var mp = new Vector2i(x, y);
            if (!p.world.InWorldBounds(x, y)) { p.Reconnect(); return; }
            BlockType bt = p.world.GetBlockType(mp);
            if (bt == BlockType.EntrancePortal || ConfigData.IsPortalWireable(bt))
            {
                if (p.CurrentMP == mp)
                {
                    BSONObject r = new("PAiP")
                    {
                        ["x"] = x,
                        ["y"] = y,
                        ["U"] = p.ClientID
                    };
                    p.world.Broadcast(ref r, p);
                }
            }
        }

        public void HandlePlayPortalOutAnimation(Player p, BSONObject obj)
        {
            if (p == null || p.world == null || !obj.ContainsKey("x") || !obj.ContainsKey("y"))
            {
                return;
            }
            int x = obj["x"].int32Value;
            int y = obj["x"].int32Value;
            var mp = new Vector2i(x, y);
            if (!p.world.InWorldBounds(x, y)) { p.Reconnect(); return; }
            BlockType bt = p.world.GetBlockType(mp);
            if (bt == BlockType.EntrancePortal || ConfigData.IsPortalWireable(bt))
            {
                if (p.CurrentMP == mp)
                {
                    BSONObject r = new("PAoP")
                    {
                        ["x"] = x,
                        ["y"] = y,
                        ["U"] = p.ClientID
                    };
                    p.world.Broadcast(ref r, p);
                }
            }
        }
    }
}
