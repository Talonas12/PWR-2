using BasicTypes;
using Kernys.Bson;
using PWS.Constants;
using PWS.DataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PWS.Constants.Enums;

namespace PWS
{
    public class SeedData
    {
        private static readonly int m_GrowthTimeInSecondsForZeroOrLessComplexity = 432000;
        private static readonly int m_MinGrowthTimeInSeconds = 30;
        private static readonly int m_MaxGrowthTimeInSeconds = 432000;

        public BlockType BlockType { get; set; }
        public DateTime GrowthEndTime { get; set; }
        public int GrowthDurationInSeconds { get; set; }
        public bool IsAlreadyCrossBred { get; set; }
        public Vector2i Position { get; set; } = new();
        public short HarvestSeeds { get; set; }
        public short HarvestBlocks { get; set; }
        public short HarvestGems { get; set; }
        public short HarvestExtraBlocks { get; set; }

        public SeedData(BlockType blockType, Vector2i position, int growthDurationSeconds, bool isMixed = false)
        {
            BlockType = blockType;
            Position = position;
            GrowthEndTime = DateTime.UtcNow.AddSeconds(growthDurationSeconds);
            GrowthDurationInSeconds = growthDurationSeconds;
            IsAlreadyCrossBred = isMixed;
            HarvestSeeds = (short)(RollDrops.DoesTreeDropSeed(blockType) ? 1 : 0);
            HarvestBlocks = RollDrops.TreeDropsBlocks(blockType);
            HarvestGems = RollDrops.BlockDropsGems(blockType);
            HarvestExtraBlocks = (short)(RollDrops.DoesTreeDropExtraBlock(blockType) ? 1 : 0);
            
        }
        public SeedData(BSONObject bson)
        {
            BlockType = (BlockType)bson["BlockType"].int32Value;
            Position = new Vector2i(bson["x"].int32Value, bson["y"].int32Value);
            GrowthEndTime = new DateTime(bson["GrowthEndTime"].int64Value);
            GrowthDurationInSeconds = bson["GrowthDuration"].int32Value;
            IsAlreadyCrossBred = bson["Mixed"].boolValue;
            HarvestSeeds = (short)bson["HarvestSeeds"].int32Value;
            HarvestBlocks = (short)bson["HarvestBlocks"].int32Value;
            HarvestGems = (short)bson["HarvestGems"].int32Value;
            HarvestExtraBlocks = (short)bson["HarvestExtraBlocks"].int32Value;
        }

        public static int CalculateGrowthTimeInSeconds(int blockComplexity, BlockType seedBlockType)
        {
            System.Diagnostics.Debug.WriteLine("Complexity: " + blockComplexity.ToString());
            //if (blockComplexity <= 0)
            //{
            //    return m_GrowthTimeInSecondsForZeroOrLessComplexity;
            //}

            var item = ItemDB.GetByID((int)seedBlockType);

            //double growthTime = Math.Floor(Math.Pow(blockComplexity, 3.2) + 30.0 * Math.Pow(blockComplexity, 1.4));
            double growthTime;
            if (item.tier < 1)
            {
                growthTime = 30 * blockComplexity * 10;
            }
            else
            {
                growthTime = 30 * blockComplexity * item.tier;
            }

            if (growthTime < m_MinGrowthTimeInSeconds)
            {
                growthTime = m_MinGrowthTimeInSeconds;
            }
            else if (growthTime > m_MaxGrowthTimeInSeconds)
            {
                growthTime = m_MaxGrowthTimeInSeconds;
            }

            return (int)growthTime;
        }

        //public BSONObject AsBSON { get
        //    {
        //        return new BSONObject()
        //        {
        //            ["BlockType"] = (int)BlockType,
        //            ["GrowthDuration"] = GrowthDurationInSeconds,
        //            ["GrowthEndTime"] = GrowthEndTime.Ticks,
        //            ["Mixed"] = IsAlreadyCrossBred,
        //            ["HarvestSeeds"] = HarvestSeeds,
        //            ["HarvestBlocks"] = HarvestBlocks,
        //            ["HarvestGems"] = HarvestGems,
        //            ["HarvestExtraBlocks"] = HarvestExtraBlocks,
        //            ["x"] = Position.x,
        //            ["y"] = Position.y
        //        };
        //    }
        //}

        public BSONObject AsBSON()
        {
            return new BSONObject()
            {
                ["BlockType"] = (int)BlockType,
                ["GrowthDuration"] = GrowthDurationInSeconds,
                ["GrowthEndTime"] = GrowthEndTime.Ticks,
                ["Mixed"] = IsAlreadyCrossBred,
                ["HarvestSeeds"] = HarvestSeeds,
                ["HarvestBlocks"] = HarvestBlocks,
                ["HarvestGems"] = HarvestGems,
                ["HarvestExtraBlocks"] = HarvestExtraBlocks,
                ["x"] = Position.x,
                ["y"] = Position.y
            };
        }
    }
}
