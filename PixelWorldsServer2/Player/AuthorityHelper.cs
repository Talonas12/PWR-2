using PWS.World.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWS
{
    public class AuthorityHelper
    {
        public enum Level
        {
            Basic,
            WorldOwner,
            WorldRights,
            WorldMinorRights,
        }
        public static bool IsPlayerAdmin(Player player)
        {
            return player.Data.OPStatus == 2;
        }
        public static bool IsPlayerStaffMember(Player player)
        {
            return player.Data.OPStatus == 2 || player.Data.OPStatus == 1;
        }
        public static bool HasMajorRightsToLock(Player user) // ToLock = wl ; ToLockSmall = sl, ml, ll, etc.
        {
            if (user.world.wl == null)
                return true;

            if (user.world.wl.IsOwner(user.ClientID) || user.world.wl.isOpen || user.world.wl.HasFull(user.ClientID) || user.Data.adminInEditWorldMode)
            {
                return true;
            }
            return false;
        }
        public static bool HasMinorRightsToLock(Player user) // ToLock = wl ; ToLockSmall = sl, ml, ll, etc.
        {
            if (user.world.wl == null)
                return true;

            if (user.world.wl.IsOwner(user.ClientID) || user.world.wl.isOpen || user.world.wl.HasFull(user.ClientID) || user.world.wl.HasMinor(user.ClientID) || user.Data.adminInEditWorldMode)
            {
                return true;
            }
            return false;
        }

        public static Level GetLevel(Player p)
        {
            Level result = Level.Basic;
            if (p.world.wl != null)
            {
                if (p.world.wl.IsOwner(p.ClientID))
                    result = Level.WorldOwner;
                else if (p.world.wl.HasFull(p.ClientID))
                    result = Level.WorldRights;
                else if (p.world.wl.HasMinor(p.ClientID))
                    result = Level.WorldMinorRights;
            }
            return result;
        }

        public static bool CanSummon(Player responsible, Player target)
        {
            if (GetLevel(responsible) == Level.Basic && !IsPlayerStaffMember(responsible))
                return false;
            if (IsPlayerStaffMember(target) && !target.Data.adminWantsToBeSummoned)
                return false;

            return true;
        }

        public static bool CanKickBan(Player p, Player target)
        {
            Level pl = GetLevel(p);
            Level tl = GetLevel(target);

            if (IsPlayerStaffMember(p))
            {
                if (IsPlayerStaffMember(target))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (p.world.wl == null)
                return false;
            else
            {
                if (IsPlayerStaffMember(target))
                    return false;
                if (pl == Level.Basic)
                    return false;
                if (tl == Level.Basic)
                    return true;
                if (pl == Level.WorldOwner)
                    return true;
            }
            return false;
        }
    }
}
