using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PWS.Constants;
using Kernys.Bson;
using BasicTypes;
using static PWS.Constants.Enums;
using PWS.World;

namespace PWS
{
    public class ACT
    {
        public Player p;
        public World.WorldSession world { get => p.world; }

        public ACT(Player player)
        {
            p = player;
        }

        public bool IsTileWalkable(int x, int y)
        {
            var blockType = world.GetBlockType(new Vector2i(x, y));
            var wib = world.worldItemsData[x, y];

            if (!world.InWorldBounds(new Vector2i(x, y))) return false;

            if (blockType == BlockType.EntrancePortal) return true;

            if (ConfigData.IsBlockCloud(blockType)) return true;

            if (ConfigData.IsBasicPlatform(blockType))
                if (p.CurrentMP.y <= y)
                    return true;

            if (ConfigData.IsAnyDoor(blockType))
                if (AuthorityHelper.HasMinorRightsToLock(p))
                    return true;
                else
                    return false;

            if (ConfigData.IsBlockBattleBarrier(blockType))
            {
                if (wib == null) return true;
                if (wib["isOpen"].boolValue) return true;
                else return false;
            }

            if (blockType == BlockType.NetherKey || blockType == BlockType.JetRaceForcefieldStart ||
                blockType == BlockType.JetRaceFinishline || blockType == BlockType.JetRaceCrestGold || blockType == BlockType.PortalMiningEntry || blockType == BlockType.PortalMineExit)
                return true;

            if (ConfigData.IsBlockInstaKill(blockType))
            {
                //KillPlayer;
                return true;
            }

            if (ConfigData.HasCollider(blockType))
                return false;

            return true;
        }

        public bool LegalMove(Vector2i from, Vector2i to)
        {
            if (!world.InWorldBounds(to)) return false;
            Vector2i mpd = WorldSession.DistanceMP(from, to);   //distance between previous and new map point
            bool illegal = mpd.x > 2 || mpd.y > 2 || (mpd.x == mpd.y && mpd.x > 1) || (mpd.x == 1 && mpd.y == 2) || (mpd.y == 1 && mpd.x == 2);
            return !illegal;
        }

        public void HandleMovements(BSONObject obj)
        {
            if (world == null || !obj.ContainsKey("pM")) p.Reconnect(); //wtf?!
            List<Vector2i> list = obj["pM"].vector2iListValue;
            if (list.Count < 1 || AuthorityHelper.IsPlayerStaffMember(p)) return;
            string onKickReason = $"{p.Data.Name}, movement hack detector: ";
            if (list.Count > 55)
            {
                p.Reconnect(onKickReason + $"too many tiles ({list.Count})");
                return;
            }
            Vector2i current = p.CurrentMP;
            //Vector2i mp_prev = list[0];
            BlockType tile = world.GetBlockType(current);


            foreach (Vector2i mp in list)
            {
                if (mp == current)
                    continue;
                tile = world.GetBlockType(mp);

                //out of range detector
                if (!LegalMove(current, mp) && !ConfigData.IsPortalWireable(tile) && tile != BlockType.EntrancePortal)
                {
                    p.Reconnect(onKickReason + $"Out of range tp (wallhack)\nFrom {current} to {mp}, target tile: {tile}, MPs Count: {list.Count}");
                    return;
                }
                if (!IsTileWalkable(mp.x, mp.y))
                {
                    p.Reconnect(onKickReason + $"WalkIN (wallhack)\nFrom {current} to {mp}, target tile: {tile}, MPs Count: {list.Count}");
                    return;
                }

                current = mp;
            }
            WorldSession.ConvertMapPointToWorldPoint(current, out p.Data.PosX, out p.Data.PosY);
        }
    }
}