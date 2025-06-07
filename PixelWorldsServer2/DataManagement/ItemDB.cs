using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PWS.DataManagement
{
    public enum ItemTileLockType
    {
        SMALL,
        BIG,
        LARGE,
        WORLD
    }
    public enum ItemType
    {
        BLOCK,
        BACKGROUND,
        FALL,
        LIQUID,
        CLOTHING,
        WEAPON,
        CONSUMABLE,
        ORB,
        SHARD,
        BLUEPRINT,
        FAMILIAR,
        SNACK,
        GATE,
    }

    public struct Item
    {
        public short ID;
        public short type;
        public int health;
        public short tier;
        public string name;
        public bool tradeable;
        public bool canBeBehindWater;
        public bool recallSupported;
        public string hotspots;
        public short complexity;

        public Item(string _name, short _ID, short _type, short _tier = 0,
            string _hotspots = "0", int _hitsRequired = 1000, bool _tradeable = true, bool _behindWater = true, bool _recall = true, short _complexity = -1)
        {
            ID = _ID;
            type = _type;
            health = _hitsRequired;
            tier = _tier;
            name = _name;
            tradeable = _tradeable;
            canBeBehindWater = _behindWater;
            recallSupported = _recall;
            hotspots = _hotspots;
            complexity = _complexity;
        }
    }
    public class ItemDB
    {
        public static ItemTileLockType GetLockType(ref Item it)
        {
            switch (it.ID)
            {
                case 410:
                    return ItemTileLockType.SMALL;

                case 411:
                    return ItemTileLockType.BIG;

                case 412:
                    return ItemTileLockType.LARGE;

                default:
                    break;
            }
            return ItemTileLockType.WORLD;
        }

        private static List<Item> items = new List<Item>();

        public static bool IsWearable(int item)
        {
            Item it = GetByID(item);
            var type = (ItemType)it.type;

            return type == ItemType.CLOTHING || type == ItemType.WEAPON || type == ItemType.FAMILIAR;
        }

        public static Item GetByName(string name)
        {

            string s = name.ToLower();
            foreach (var item in items)
            {
                if (item.name.ToLower() == s)
                    return item;
            }

            return new Item("", -1, -1);
        }

        public static Item[] FindByName(string name)
        {
            List<Item> foundItems = new List<Item>();

            string s = name.ToLower();
            foreach (var item in items)
            {
                if (item.name.ToLower().Contains(s))
                    foundItems.Add(item);
            }

            return foundItems.ToArray();
        }

        public static Item[] FindByAnyName(string name)
        {
            List<Item> foundItems = new List<Item>();

            string s = name.ToLower();
            foreach (var item in items)
            {
                if (item.name.ToLower().StartsWith(s))
                    foundItems.Add(item);
            }

            return foundItems.ToArray();
        }

        public static int ItemsCount()
        {
            return items.Count;
        }
        public static Item GetByID(int id)
        {
            return (id >= items.Count || id < 0) ? new Item("", -1, 0) : items[id];
        }

        public static void Initialize()
        {
            //#LEGEND: ID-0|InventoryItemType-1|Health-2|Tier-3|Name-4|IsTradeable-5|CanBeBehindWater-6|RecallAllowed-7|HotSpots-8|Complexity-9|HasCollider-10|DropGemsMin-11|DropGemsMax-12|XpAfterDestroy-13|
            string[] content = File.ReadAllLines(@"LocalData\items.txt");
            int i = 0;
            foreach (string line in content)
            {
                string[] args = line.Split("|");

                Item item;
                item.ID = short.Parse(args[0]);
                item.type = short.Parse(args[1]);
                item.health = int.Parse(args[2]);
                item.tier = short.Parse(args[3]);
                item.name = args[4];
                item.tradeable = args[5] == "1";
                item.canBeBehindWater = args[6] == "1";
                item.recallSupported = args[7] == "1";
                item.hotspots = args[8];
                item.complexity = short.Parse(args[9]);
                Constants.ConfigData.doesBlockHasCollider[i] = args[10] == "1";
                Constants.ConfigData.blockDropGemRangeMin[i] = short.Parse(args[11]);
                Constants.ConfigData.blockDropGemRangeMax[i] = short.Parse(args[12]);
                Constants.ConfigData.blockExperienceAmount[i] = short.Parse(args[13]);

                items.Add(item);
                i++;
            }
            Util.Log($"Initialized item database, {items.Count} entries!");
        }

        //private static bool[] hasCollider = Array.Empty<bool>();
        //private static bool[] isTradeable = Array.Empty<bool>();
        //private static bool[] canBeBehindWater = Array.Empty<bool>();
        //private static bool[] supportsRecall = Array.Empty<bool>();
        //private static int[] tiers = Array.Empty<int>();
        //private static int[] inventoryTypes = Array.Empty<int>();
        //private static string[] names = Array.Empty<string>();
        //private static List<int>[] hotSpots = Array.Empty<List<int>>();
    }
}
