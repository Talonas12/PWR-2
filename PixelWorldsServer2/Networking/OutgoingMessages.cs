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
using System.Runtime.CompilerServices;
using PWS.World.Helpers;

namespace PWS.Networking
{
    public static class OutgoingMessages
    {
        public static BSONObject HitBlock(int x, int y, Player p)
        {
            return new BSONObject()
            {
                ["ID"] = "HB",
                ["x"] = x,
                ["y"] = y,
                ["TT"] = 0,
                ["U"] = p.ClientID
            };
        }

        public static BSONObject HitBlockBackground(int x, int y, Player p)
        {
            return new BSONObject()
            {
                ["ID"] = "HBB",
                ["x"] = x,
                ["y"] = y,
                ["TT"] = 0,
                ["U"] = p.ClientID
            };
        }

        public static BSONObject HitBlockWater(int x, int y, Player p)
        {
            return new BSONObject()
            {
                ["ID"] = "HBW",
                ["x"] = x,
                ["y"] = y,
                ["TT"] = 0,
                ["U"] = p.ClientID
            };
        }
        /// <summary>
        /// Return a PlayerLeft packet
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="idx">-1: self-leave,
        /// 0: world kick,
        /// 1: world ban,
        /// 2: game ban</param>
        /// <returns></returns>
        public static BSONObject PlayerLeft(string playerId, int idx = -1)
        {
            var b =  new BSONObject()
            {
                ["ID"] = "PL",
                ["U"] = playerId
            };
            if (idx >= 0)
            {
                b["Idx"] = idx;
            }
            return b;
        }
    }
}
