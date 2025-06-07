﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PWS.Networking.Server
{
    public class AccountHelper
    {
        PWServer pServer = null;
        public AccountHelper(PWServer pServer)
        {
            this.pServer = pServer;
        }

        // forceRegister: Register Player if not found in Database. If false, null can be returned.
        public Player LoginPlayer(string cogID, string cogToken, string ip, bool forceRegister = true)
        {
            Player player = null;
            var sql = pServer.GetSQL();

            var cmd = sql.Make("SELECT * FROM players WHERE CognitoID=@CognitoID AND Token=@Token");

            cmd.Parameters.AddWithValue("@CognitoID", cogID);
            cmd.Parameters.AddWithValue("@Token", cogToken);

            using (var reader = sql.PreparedFetchQuery(cmd))
            {
                if (reader != null)
                {
                    if (reader.Read())
                    {
                        // Found an entry:
                        player = new Player(reader);
                    }
                    else
                    {
                        player = CreateAccount(cogID, cogToken, ip);
                    }
                }
                else
                {
                    player = CreateAccount(cogID, cogToken, ip);
                }
            }

            return player;
        }
        public Player CreateAccount(string cogID, string cogToken, string ip = "0.0.0.0")
        {
            var sql = pServer.GetSQL();

            var cmd = sql.Make("INSERT INTO players (Name, CognitoID, Token, IP) VALUES (@Name, @CognitoID, @Token, @IP)");
            cmd.Parameters.AddWithValue("@CognitoID", cogID);
            cmd.Parameters.AddWithValue("@Token", cogToken);
            cmd.Parameters.AddWithValue("@IP", ip);

            string name = "Player" + Util.RandomString(8); // Name generation soon...
            cmd.Parameters.AddWithValue("@Name", name);

            if (sql.PreparedQuery(cmd) > 0)
            {
                var p = new Player();
                try
                {
                    p.Data.player = p;
                    p.Data.UserID = (uint)sql.GetLastInsertID();
                    p.Data.CognitoID = cogID;
                    p.Data.Token = cogToken;
                    p.Data.Name = name;
                    p.Data.LastIP = ip;
                    //p.pSettings = new PlayerSettings();
                    p.Data.skinColor = 7;
                    p.Data.lastHit = 0;
                    p.Data.beenInsideBlockFor = 0;
                    p.Data.possibleHacks = 0;
                    p.Data.countryCode = 999;
                    p.Data.gender = 0;
                    p.Data.InvHelper = new InventoryHelper(p);
                    p.Data.Inventory = new Dictionary<int, short>();
                    p.Data.InvHelper.RegularDefaultInventory();
                    p.act = new(p);
                }
                catch (Exception e)
                {
                    Util.Log(e.ToString());
                }

                return p;
            }

            return null;
        }
    }
}
