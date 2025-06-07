using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PWS.Constants.Enums;

namespace PWS.Constants
{
    public static class RollDrops
    {
        public static Random roll = new Random();
        public struct RollChances
        {
            private static readonly short[] m_AmountArray = new short[100];

            public RollChances(short[] chances, short[] amounts)
            {
                int counter = 0;
                for (int i = 0; i < chances.Length; i++)
                {
                    for (int j = 0; j < chances[i]; j++)
                    {
                        m_AmountArray[counter++] = amounts[i];
                    }
                }
            }

            public short GetRolledAmount(int roll)
            {
                return m_AmountArray[roll];
            }
        }

        public static bool DoesTreeDropSeed(BlockType blockType)
        {
            return RollD100() < ConfigData.TreeDropSeedPercentage[(int)blockType];
        }

        public static bool DoesBlockDropSeed(BlockType blockType)
        {
            return RollD100() < ConfigData.BlockDropSeedPercentage[(int)blockType];
        }

        public static bool DoesBlockDropBlock(BlockType blockType)
        {
            return RollD100() < ConfigData.BlockDropBlockPercentage[(int)blockType];
        }

        public static bool DoesTreeDropExtraBlock(BlockType blockType)
        {
            int treeExtraDropChance = ConfigData.TreeExtraDropChance[(int)blockType];
            if (treeExtraDropChance == 0)
            {
                return false;
            }
            return 0 == GenericRoll(0, treeExtraDropChance);
        }

        public static bool DoesBlockDropExtraBlock(BlockType blockType)
        {
            int blockExtraDropChance = ConfigData.BlockExtraDropChance[(int)blockType];
            if (blockExtraDropChance == 0)
            {
                return false;
            }
            return 0 == GenericRoll(0, blockExtraDropChance);
        }

        public static short TreeDropsBlocks(BlockType blockType)
        {
            short treeDropBlockRangeMax = ConfigData.TreeDropBlockRangeMax[(int)blockType];
            if (treeDropBlockRangeMax == 0)
            {
                return 0;
            }
            short treeDropBlockRangeMin = ConfigData.TreeDropBlockRangeMin[(int)blockType];
            return GenericRoll(treeDropBlockRangeMin, (short)(treeDropBlockRangeMax + 1));
        }

        //public static short TreeDropsGems(BlockType blockType) shit
        //{
        //    short treeDropGemRangeMax = ConfigData.blockDropGemRangeMax[(int)blockType];
        //    if (treeDropGemRangeMax == 0)
        //    {
        //        return 0;
        //    }
        //    short treeDropGemRangeMin = ConfigData.blockDropGemRangeMin[(int)blockType];
        //    return GenericRoll(treeDropGemRangeMin, (short)(treeDropGemRangeMax + 1));
        //}

        public static short BlockDropsGems(BlockType blockType)
        {
            short blockDropGemRangeMax = ConfigData.blockDropGemRangeMax[(int)blockType];
            short blockDropGemRangeMin = ConfigData.blockDropGemRangeMin[(int)blockType];
            if (blockDropGemRangeMax == 0)
            {
                return 0;
            }
            if (blockDropGemRangeMax < 2 && roll.Next(0, 5) != 0)
            {
                return 0;
            }
            return GenericRoll(blockDropGemRangeMin, (short)(blockDropGemRangeMax + 1));
        }

        private static byte RollD100()
        {
            return (byte)GenericRoll(0, 100);
        }

        private static short GenericRoll(short minInclusive, short maxExclusive)
        {
            return (short)GenericRoll((int)minInclusive, (int)maxExclusive);
        }

        public static int GenericRoll(int minInclusive, int maxExclusive)
        {
            return new Random().Next(minInclusive, maxExclusive);
        }

        public static int RollPosition(int min, int max)
        {
            return new Random().Next(min, max);
        }

        public static void Shuffle<T>(T[] array)
        {
            var length = array.Length;
            var random = new Random();
            while (length > 1)
            {
                int index = random.Next(length--);

                T val = array[length];
                array[length] = array[index];
                array[index] = val;
            }
        }
    }
}