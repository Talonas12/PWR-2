using Newtonsoft.Json;
using PWS.DataManagement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PWS.Constants.Enums;

namespace PWS.Constants
{
    public static class ConfigData
    {
        public delegate int ParseItemNumber(string[] strings);
        public delegate void SetConfigDataValue(string newValue, int index);

        public static readonly int Gem1Value = 1;
        public static readonly int Gem2Value = 5;
        public static readonly int Gem3Value = 20;
        public static readonly int Gem4Value = 50;
        public static readonly int Gem5Value = 100;
        public static readonly int RollCollectableXMin = -14;
        public static readonly int RollCollectableXMax = 15;
        public static readonly int RollCollectableYMin = -14;
        public static readonly int RollCollectableYMax = 15;
        public static readonly float TileSizeX = 0.32f;
        public static readonly float TileSizeY = 0.32f;
        public static readonly float ReviveBlockTime = 5f;
        public static int BlocksCount = Enum.GetValues(typeof(BlockType)).Length + 1;

        public static int DefaultBlockHitPoints { get; private set; } = 1000;
        public static int DefaultBlockComplexity { get; private set; }
        public static int DefaultGrowthTimeInSeconds { get; private set; } = 60;
        public static int DefaultTreeExtraDropChance { get; private set; }
        public static int DefaultBlockExtraDropChance { get; private set; }
        public static byte DefaultTreeDropSeedPercentage { get; private set; }
        public static byte DefaultBlockDropSeedPercentage { get; private set; }
        public static byte DefaultBlockDropBlockPercentage { get; private set; }
        public static bool DefaultBlockDropGemPercentageOn { get; private set; }
        public static float DefaultRecycleValue { get; private set; }
        public static short DefaultTreeDropGemRangeMin { get; private set; }
        public static short DefaultTreeDropGemRangeMax { get; private set; }
        public static short DefaultBlockDropGemRangeMin { get; private set; }
        public static short DefaultBlockDropGemRangeMax { get; private set; }
        public static short DefaultTreeDropBlockRangeMin { get; private set; }
        public static short DefaultTreeDropBlockRangeMax { get; private set; }
        public static BlockType DefaultTreeExtraDropBlock { get; private set; }
        public static BlockType DefaultBlockExtraDropBlock { get; private set; }
        public static BlockClass DefaultBlockClass { get; private set; } = BlockClass.GroundSoft;
        public static InventoryItemType DefaultBlockInventoryItemType { get; private set; } = InventoryItemType.Block;

        public static int[] BlockHitPoints { get; private set; } = null!;
        public static int[] BlockComplexity { get; private set; } = null!;
        public static int[] GrowthTimeInSeconds { get; private set; } = null!;
        public static int[] TreeExtraDropChance { get; private set; } = null!;
        public static int[] BlockExtraDropChance { get; private set; } = null!;
        public static byte[] TreeDropSeedPercentage { get; private set; } = null!;
        public static byte[] BlockDropSeedPercentage { get; private set; } = null!;
        public static byte[] BlockDropBlockPercentage { get; private set; } = null!;
        public static bool[] BlockDropGemPercentageOn { get; private set; } = null!;
        public static float[] RecycleValue { get; private set; } = null!;
        public static short[] TreeDropGemRangeMin { get; private set; } = null!;
        public static short[] TreeDropGemRangeMax { get; private set; } = null!;
        public static short[] TreeDropBlockRangeMin { get; private set; } = null!;
        public static short[] TreeDropBlockRangeMax { get; private set; } = null!;
        public static short[] BlockDropGemRangeMin { get; private set; } = null!;
        public static short[] BlockDropGemRangeMax { get; private set; } = null!;
        public static BlockType[] TreeExtraDropBlock { get; private set; } = null!;
        public static BlockType[] BlockExtraDropBlock { get; private set; } = null!;
        public static BlockClass[] BlockClasses { get; private set; } = null!;
        public static InventoryItemType[] BlockInventoryItemType { get; private set; } = null!;
        public static bool[] doesBlockHasCollider = new bool[BlocksCount];
        public static short[] blockDropGemRangeMin = new short[BlocksCount];
        public static short[] blockDropGemRangeMax = new short[BlocksCount];
        public static short[] blockExperienceAmount = new short[BlocksCount];


        private static T[] InitArray<T>(T value)
        {
            var array = new T[(int)BlockType.BLOCK_TYPE_COUNT];
            for (int i = 0; i < array.Length; ++i)
            {
                array[i] = value;
            }
            return array;
        }

        private static string ReadText(BinaryReader reader)
        {
            return new string(reader.ReadChars(reader.ReadInt32()));
        }

        private static void ParseSomeCSV(string inputString, SetConfigDataValue?[] dataSetters, ParseItemNumber itemNumberParser)
        {
            var stringReader = new StringReader(inputString);
            while (true)
            {
                string? text = stringReader.ReadLine();
                if (text is null)
                {
                    break;
                }

                string[] array = text.Split(',');
                int index = itemNumberParser(array);

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].Length > 0 && dataSetters[i] is not null)
                    {
                        dataSetters[i]!(array[i], index);
                    }
                }
            }
        }

        private static int ParseWorldBlockItemNumber(string[] strings)
        {
            if (int.TryParse(strings[1], out var result))
            {
                return result;
            }

            return -1;
        }

        public static int[] SplitGemValueToGems(int gemValue)
        {
            int num = gemValue / Gem5Value;
            gemValue -= num * Gem5Value;
            int num2 = gemValue / Gem4Value;
            gemValue -= num2 * Gem4Value;
            int num3 = gemValue / Gem3Value;
            gemValue -= num3 * Gem3Value;
            int num4 = gemValue / Gem2Value;
            gemValue -= num4 * Gem2Value;
            int num5 = gemValue / Gem1Value;
            return new int[5] { num5, num4, num3, num2, num };
        }

        private static void InitArrays()
        {
            BlockClasses = InitArray(DefaultBlockClass);
            RecycleValue = InitArray(DefaultRecycleValue);
            BlockHitPoints = InitArray(DefaultBlockHitPoints);
            BlockComplexity = InitArray(DefaultBlockComplexity);
            TreeExtraDropBlock = InitArray(DefaultTreeExtraDropBlock);
            BlockExtraDropBlock = InitArray(DefaultBlockExtraDropBlock);
            TreeExtraDropChance = InitArray(DefaultTreeExtraDropChance);
            GrowthTimeInSeconds = InitArray(DefaultGrowthTimeInSeconds);
            TreeDropGemRangeMin = InitArray(DefaultTreeDropGemRangeMin);
            TreeDropGemRangeMax = InitArray(DefaultTreeDropGemRangeMax);
            BlockDropGemRangeMin = InitArray(DefaultBlockDropGemRangeMin);
            BlockDropGemRangeMax = InitArray(DefaultBlockDropGemRangeMax);
            BlockExtraDropChance = InitArray(DefaultBlockExtraDropChance);
            TreeDropBlockRangeMin = InitArray(DefaultTreeDropBlockRangeMin);
            TreeDropBlockRangeMax = InitArray(DefaultTreeDropBlockRangeMax);
            BlockInventoryItemType = InitArray(DefaultBlockInventoryItemType);
            TreeDropSeedPercentage = InitArray(DefaultTreeDropSeedPercentage);
            BlockDropSeedPercentage = InitArray(DefaultBlockDropSeedPercentage);
            BlockDropBlockPercentage = InitArray(DefaultBlockDropBlockPercentage);
            BlockDropGemPercentageOn = InitArray(DefaultBlockDropGemPercentageOn);
        }

        public static string ReadCsvContent(string csvFilePath)
        {
            using var fs = File.OpenRead(csvFilePath);
            using var br = new BinaryReader(fs);

            var csvId = ReadText(br);
            var content = ReadText(br);
            return content;
        }

        public static bool Init()
        {
            try
            {

                {
                    var content = ReadCsvContent("LocalData\\default-blocks-config.csv");
                    InitDefaultValues(content);
                    InitArrays();
                }

                {
                    var content = ReadCsvContent("LocalData\\blocks-config.csv");
                    SetConfigDataValue?[] dataSetters = new SetConfigDataValue?[]
                    {
                    null,
                    null,
                    SetBlockTypeInventoryItemType,
                    null, //SetBlockSortingLayerType,
					null, //SetInventoryOrderType
					null, //SetIsValidForAuctionHouse
					null, //SetBlockAvailabilityDate
					null, //SetBlockSortingOrderInLayer,
					SetBlockClass,
                    null, //SetDoesBlockHaveCollider,
					null, //SetIsBlockColliderOneWay,
					SetHitsRequired,
                    SetTreeDropSeedPercentage,
                    SetTreeDropBlockRange,
                    SetTreeDropGemRange,
                    SetBlockDropSeedPercentage,
                    SetBlockDropBlockPercentage,
                    SetBlockDropGemRangeOrPercentage,
                    SetTreeExtraDropBlock,
                    SetTreeExtraDropChance,
                    SetBlockExtraDropBlock,
                    SetBlockExtraDropChance,
                    null, //SetBlockCustomGroups,
					SetRecycleValue,
                    Seeds.SetFirstCrossBreedingPart,
                    Seeds.AddCrossBreeding,
                    null, //SetShouldBelowSpriteUseAlternativeSprite,
					null, //SetBlockGroundDamping,
					null, //SetBlockRunSpeed,
					null, //SetBlockGravity,
					null, //SetBlockMaxFallVelocity,
					null, //SetBlockAirResistance,
					null, //SetBlockJumpHeight,
					null, //SetBlockJumpHeight60FPS,
					null, //SetIsBlockTrampolin,
					null, //SetIsBlockSpring,
					null, //SetIsBlockHot,
					null, //SetIsBlockPinball,
					null, //SetBlockBounceForce,
					null, //SetBlockBounceForce60FPS,
					null, //SetIsBlockSwimming,
					null, //SetIsBlockTradeable,
					null, //SetBlockParticleColor,
					null, //SetTreeHSL,
					null, //SetSeedHSL,
					null, //SetIsSeed,
					null, //SetBlockTreeSpriteIndex,
					null, //SetBlockSeedSpriteIndex,
					SetGrowthTimeInSeconds,
                    null, //SetCanBlockBeBehindWater,
					null, //SetShouldBlockUseSpriteAnimation,
					null, //SetBlockSpriteAnimationSpeed,
					null, //SetShouldBlockUseEffectSpriteAnimation,
					null, //SetBlockEffectSpriteAnimationSpeed,
					null, //SetShouldBlockUseLight,
					null, //SetBlockLightSpriteAnimationType,
					null, //SetBlockHitEffectOffnull, //SetX,
					null, //SetBlockHitEffectOffnull, //SetY,
					null, //SetOffnull, //SetAnimationSpeedX,
					null, //SetOffnull, //SetAnimationSpeedY,
					null, //SetBlockHandItemType,
					null, //SetToolUsableForBlock,
					null, //SetBlockStorageIndex,
					null, //SetBlockRange,
					null, //SetCanSitDownToBlock,
					null, //SetHitBuffer,
					null, //SetNewBlockAnimationOn,
					null, //SetShowButtonWhenPlayerIsNearEnough,
					null, //SetShowButtonWhenPlayerIsNearEnoughDistance,
					null, //SetBlockFadeInOutEffect,
					null, //SetBlockEffectSpriteAnimationType,
					null, //SetShouldBlockUseAnimalAnimation,
					null, //SetHidePlayerBlock,
					null, //SetBlockDirection,
					null, //SetSpriteAnimationLoopCount,
					null, //SetIsBlockWind,
					null, //SetHitForce,
					null, //SetBattleDamage,
					null, //SetArmor,
					null, //SetFireElement,
					null, //SetWaterElement,
					null, //SetEarthElement,
					null, //SetAirElement,
					null, //SetLightElement,
					null, //SetDarkElement,
					null, //SetCritChance,
					null, //SetBlockMaterialClass,
					SetBlockComplexity,
                    null, //SetSpriteContainsAlpha,
					null, //SetPlayerJumpModeForBlock,
					null, //SetIsBlockElastic,
					null, //SetShouldGiveBlockBackIntoInventory,
					null, //SetBlockSkinColorIndex,
					null, //SetShardRarity,
					null, //SetShouldCausePoisoned,
					null, //SetBlockMaxCountInWorld
                    };

                    ParseSomeCSV(content, dataSetters, ParseWorldBlockItemNumber);
                }

                return true;
            }
            catch
            {
                throw;
            }
        }

        private static void SetBlockComplexity(string newValue, int index)
        {
            BlockComplexity[index] = int.Parse(newValue);
        }

        private static void SetGrowthTimeInSeconds(string newValue, int index)
        {
            GrowthTimeInSeconds[index] = int.Parse(newValue);
        }

        // These values are fucked up
        public static void InitDefaultValues(string inputString)
        {
            string[] array = inputString.Split(',');
            DefaultBlockClass = (BlockClass)byte.Parse(array[12]);
            DefaultBlockHitPoints = int.Parse(array[15]);
            DefaultTreeDropSeedPercentage = byte.Parse(array[16]);

            {
                string[] array2 = array[17].Split('-');
                DefaultTreeDropBlockRangeMin = short.Parse(array2[0]);
                DefaultTreeDropBlockRangeMax = short.Parse(array2[1]);
            }

            {
                string[] array2 = array[18].Split('-');
                DefaultTreeDropGemRangeMin = short.Parse(array2[0]);
                DefaultTreeDropGemRangeMax = short.Parse(array2[1]);
            }

            DefaultBlockDropSeedPercentage = byte.Parse(array[19]);
            DefaultBlockDropBlockPercentage = byte.Parse(array[20]);

            {
                string[] array2 = array[21].Split('-');
                DefaultBlockDropGemRangeMin = short.Parse(array2[0]);
                DefaultBlockDropGemRangeMax = short.Parse(array2[1]);
            }

            DefaultTreeExtraDropBlock = (BlockType)int.Parse(array[22]);
            DefaultTreeExtraDropChance = int.Parse(array[23]);
            DefaultBlockExtraDropBlock = (BlockType)int.Parse(array[24]);
            DefaultBlockExtraDropChance = int.Parse(array[25]);
            DefaultRecycleValue = float.Parse(array[27]);
        }

        private static void SetRecycleValue(string newValue, int index)
        {
            RecycleValue[index] = float.Parse(newValue);
        }

        private static void SetBlockExtraDropChance(string newValue, int index)
        {
            BlockExtraDropChance[index] = int.Parse(newValue);
        }

        private static void SetBlockExtraDropBlock(string newValue, int index)
        {
            BlockExtraDropBlock[index] = (BlockType)int.Parse(newValue);
        }

        private static void SetTreeExtraDropChance(string newValue, int index)
        {
            TreeExtraDropChance[index] = int.Parse(newValue);
        }

        private static void SetTreeExtraDropBlock(string newValue, int index)
        {
            TreeExtraDropBlock[index] = (BlockType)int.Parse(newValue);
        }

        private static void SetTreeDropGemRange(string newValue, int index)
        {
            string[] array = newValue.Split('-');
            TreeDropGemRangeMin[index] = short.Parse(array[0]);
            TreeDropGemRangeMax[index] = short.Parse(array[1]);
        }

        private static void SetBlockDropBlockPercentage(string newValue, int index)
        {
            BlockDropBlockPercentage[index] = byte.Parse(newValue);
        }

        private static void SetBlockDropSeedPercentage(string newValue, int index)
        {
            BlockDropSeedPercentage[index] = byte.Parse(newValue);
        }

        private static void SetTreeDropBlockRange(string newValue, int index)
        {
            string[] array = newValue.Split('-');
            TreeDropBlockRangeMin[index] = short.Parse(array[0]);
            TreeDropBlockRangeMax[index] = short.Parse(array[1]);
        }

        private static void SetBlockDropGemRangeOrPercentage(string newValue, int index)
        {
            if (newValue.EndsWith("%"))
            {
                BlockDropGemPercentageOn[index] = true;

                short num = short.Parse(newValue.Remove(newValue.Length - 1));
                BlockDropGemRangeMin[index] = num;
                BlockDropGemRangeMax[index] = num;
            }
            else
            {
                BlockDropGemPercentageOn[index] = false;

                string[] array = newValue.Split('-');
                BlockDropGemRangeMin[index] = short.Parse(array[0]);
                BlockDropGemRangeMax[index] = short.Parse(array[1]);
            }
        }

        private static void SetTreeDropSeedPercentage(string newValue, int index)
        {
            TreeDropSeedPercentage[index] = byte.Parse(newValue);
        }

        private static void SetHitsRequired(string newValue, int index)
        {
            BlockHitPoints[index] = int.Parse(newValue);
        }

        private static void SetBlockClass(string newValue, int index)
        {
            BlockClasses[index] = (BlockClass)byte.Parse(newValue);
        }

        private static void SetBlockTypeInventoryItemType(string newValue, int index)
        {
            BlockInventoryItemType[index] = (InventoryItemType)byte.Parse(newValue);
        }

        public static bool IsAnyDoor(BlockType bt)
        {
            return bt == BlockType.Door || bt == BlockType.DoorClan || bt == BlockType.DoorFactionDark || bt == BlockType.DoorFactionLight || bt == BlockType.DoorLevel || bt == BlockType.DoorLevelVIP
                || bt == BlockType.BarnDoor || bt == BlockType.BonusDoorVIP || bt == BlockType.CastleDoor || bt == BlockType.DungeonDoor || bt == BlockType.DungeonDoorWhite
                || bt == BlockType.GlassDoor || bt == BlockType.GlassDoorTinted || bt == BlockType.HatchWooden || bt == BlockType.HatchMetal || bt == BlockType.HatchLevel || bt == BlockType.HatchLevelVIP;
        }

        public static bool IsBlockMannequin(BlockType bt)
        {
            return bt == BlockType.Mannequin;
        }

        public static bool IsLockSmall(BlockType bt)
        {
            return bt == BlockType.LockSmall || bt == BlockType.LockMedium || bt == BlockType.LockLarge || bt == BlockType.LockBattle || bt == BlockType.LockBattleFaction;
        }
        public static bool IsLock(BlockType bt)
        {
            return bt == BlockType.LockWorld || bt == BlockType.LockGold || bt == BlockType.LockDiamond || bt == BlockType.LockPlatinum || bt == BlockType.LockWorldBattle || bt == BlockType.LockWorldBattleFaction
                || bt == BlockType.LockWorldDark || bt == BlockType.LockWorldNoob;
        }

        public static bool IsBlockDisplay(BlockType bt)
        {
            return bt == BlockType.DisplayBlock || bt == BlockType.AnniversaryDisplayBlock;
        }

        public static bool IsBasicDoor(BlockType bt)
        {
            switch (bt)
            {
                case BlockType.Door:
                case BlockType.GlassDoor:
                case BlockType.CastleDoor:
                case BlockType.BarnDoor:
                case BlockType.ScifiDoor:
                case BlockType.GlassDoorTinted:
                case BlockType.DungeonDoor:
                case BlockType.DungeonDoorWhite:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsBasicHatch(BlockType bt)
        {
            return bt == BlockType.HatchWooden || bt == BlockType.HatchMetal;
        }

        public static bool CanBlockBeBehindWater(BlockType bt)
        {
            return ItemDB.GetByID((int)bt).canBeBehindWater;
        }
        public static bool IsTradeable(BlockType bt)
        {
            return ItemDB.GetByID((int)bt).tradeable;
        }
        public static bool IsRecallSupported(BlockType bt)
        {
            return ItemDB.GetByID((int)bt).recallSupported;
        }
        public static bool GetDefaultHotspots(BlockType bt, out List<int> list)
        {
            list = new();
            string s = ItemDB.GetByID((int)bt).hotspots;

            if (s == "0")
                return false;

            var a = s.Split(',');
            for (int i = 0; i < a.Length; i++)
            {
                list.Add(int.Parse(a[i]));
            }
            return true;
        }

        public static bool IsPortalWireable(BlockType bt)
        {
            switch (bt)
            {
                case BlockType.Portal:
                case BlockType.PortalFactionDark:
                case BlockType.PortalFactionLight:
                case BlockType.PortalPassword:
                case BlockType.AnniversaryPortal:
                case BlockType.LabEnterPortal:
                case BlockType.LabExitPortal:
                case BlockType.VortexPortal:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsBlockBreakableByAnoyone(BlockType bt)
        {
            switch (bt)
            {
                case BlockType.PotOfGems:
                case BlockType.BreakableItemQuestSummer:
                case BlockType.NetherTreasure:
                case BlockType.ButterflyDaySmall:
                case BlockType.ButterflyDayLarge:
                case BlockType.ButterflyNightSmall:
                case BlockType.ButterflyNightLarge:
                case BlockType.MiningLightCrystalSmall:
                case BlockType.MiningLightCrystalMedium:
                case BlockType.MiningLightCrystalLarge:
                case BlockType.MiningTimeCrystalSmall:
                case BlockType.MiningTimeCrystalMedium:
                case BlockType.MiningTimeCrystalLarge:
                case BlockType.MiningSoil1:
                case BlockType.MiningSoil2:
                case BlockType.MiningSoil3:
                case BlockType.MiningSoil4:
                case BlockType.MiningSoil5:
                case BlockType.MiningRockHard2:
                case BlockType.MiningRockHard3:
                case BlockType.MiningLava1:
                case BlockType.MiningBedrock3:
                case BlockType.MiningRockSoft1:
                case BlockType.MiningBedrock2:
                case BlockType.MiningRockMedium1:
                case BlockType.MiningRockHard1:
                case BlockType.MiningBedrock1:
                case BlockType.MiningWoodBlock1:
                case BlockType.MiningGemStoneDiamond:
                case BlockType.MiningGemStoneEmerald:
                case BlockType.MiningGemStoneMoonStone:
                case BlockType.MiningGemStoneOpal:
                case BlockType.MiningGemStoneRuby:
                case BlockType.MiningGemStoneSapphire:
                case BlockType.MiningGemStoneSunStone:
                case BlockType.MiningGemStoneTopaz:
                case BlockType.MiningGemStoneZircon:
                case BlockType.MiningMushrooms1:
                case BlockType.MiningMushrooms2:
                case BlockType.MiningMushrooms3:
                case BlockType.MiningCrate1:
                case BlockType.MiningStalactitesTop:
                case BlockType.MiningStalactitesBottom:
                case BlockType.MiningRocks1:
                case BlockType.MiningRocks2:
                case BlockType.MiningStackedRocks1:
                case BlockType.MiningStackedRocks2:
                case BlockType.MiningCrate2:
                case BlockType.MiningCrate3:
                case BlockType.MiningBat:
                case BlockType.MiningSpider:
                case BlockType.MiningTorch:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsBlockDataEditableByAnyone(BlockType bt)
        {
            switch (bt)
            {
                case BlockType.Mushroom:
                case BlockType.WoodenChair:
                case BlockType.Armchair:
                case BlockType.Throne:
                case BlockType.HotTub:
                case BlockType.GoldenToilet:
                case BlockType.BlackLeatherChair:
                case BlockType.ManekiNekoR:
                case BlockType.Bed:
                case BlockType.Coffin:
                case BlockType.Dice:
                case BlockType.BarStool:
                case BlockType.WaterBed:
                case BlockType.MetalChairYellow:
                case BlockType.MetalChairBlue:
                case BlockType.MetalChairRed:
                case BlockType.MetalChairPink:
                case BlockType.MetalChairGreen:
                case BlockType.TVChair:
                case BlockType.Sargophagus:
                case BlockType.Bathtub:
                case BlockType.ParrotCage:
                case BlockType.SwingChair:
                case BlockType.ArmChairLeopard:
                case BlockType.WinterBells:
                case BlockType.CloudPlatform:
                case BlockType.GummyBearOrange:
                case BlockType.GummyBearGreen:
                case BlockType.GummyBearRed:
                case BlockType.MushroomGreen:
                case BlockType.BunnyPlushToy:
                case BlockType.ChickPlushToy:
                case BlockType.PinballBumper:
                case BlockType.TrapdoorMetalPlatform:
                case BlockType.TaikoDrum:
                case BlockType.ManekiNekoL:
                case BlockType.LifeGuardChair:
                case BlockType.KiddieRide:
                case BlockType.ToiletSeat:
                case BlockType.OuijaBoard:
                case BlockType.ElectricChair:
                case BlockType.ChurchBell:
                case BlockType.MimicCoffin:
                case BlockType.EasterChicks:
                case BlockType.PsychoBunny:
                case BlockType.StreetBench:
                case BlockType.Sunchair:
                case BlockType.FantasyThroneDark:
                case BlockType.FantasyThroneLight:
                case BlockType.SwordThrone:
                case BlockType.AntiqueChair:
                case BlockType.BaroqueBed:
                case BlockType.AlienMushroom:
                case BlockType.AlienPoisonPlant:
                case BlockType.AlienTentacleTrap:
                case BlockType.AlienChair:
                case BlockType.AlienPodBlue:
                case BlockType.AlienPodPurple:
                case BlockType.FireballTriggerTrap:
                case BlockType.Outhouse:
                case BlockType.CampingTent:
                case BlockType.SpikeTriggerTrap:
                case BlockType.PirateCannon:
                case BlockType.WoodenStool:
                case BlockType.ArmchairWhite:
                case BlockType.BathtubGolden:
                case BlockType.BedBlack:
                case BlockType.PunchingBag:
                case BlockType.SofaBrown:
                case BlockType.WashingMachine:
                case BlockType.HalloweenCannon:
                case BlockType.SofaRed:
                case BlockType.CottonCandyPlatform:
                case BlockType.TempleBench:
                case BlockType.BounceBlobGreen:
                case BlockType.BounceBlobOrange:
                case BlockType.BounceBlobPurple:
                case BlockType.TrapdoorWoodenPlatform:
                case BlockType.LoveThrone:
                case BlockType.HotTubGolden:
                case BlockType.AirTrampoline:
                case BlockType.WhoopeeCushion:
                case BlockType.LawnChair:
                    return true;
                default:
                    return false;
            }
        }

        public static bool CanPlayerHide(BlockType bt)
        {
            switch (bt)
            {
                case BlockType.Coffin:
                case BlockType.Sargophagus:
                case BlockType.MimicCoffin:
                case BlockType.AlienPodBlue:
                case BlockType.AlienPodPurple:
                case BlockType.Outhouse:
                case BlockType.CampingTent:
                    return true;
                default:
                    return false;
            }
        }

        public static int GetGemValue(GemType gemType)
        {
            switch (gemType)
            {
                case GemType.Gem1:
                    return 1;
                case GemType.Gem2:
                    return 5;
                case GemType.Gem3:
                    return 20;
                case GemType.Gem4:
                    return 50;
                case GemType.Gem5:
                    return 100;
                default:
                    return 1;
            }
        }

        public static bool HasCollider(BlockType bt)
        {
            return ConfigData.doesBlockHasCollider[(int)bt];
        }

        public static bool IsBlockCloud(BlockType bt)
        {
            return bt == BlockType.CloudPlatform || bt == BlockType.CottonCandyPlatform || bt == BlockType.TrapdoorMetalPlatform || bt == BlockType.TrapdoorWoodenPlatform;
        }
        
        public static bool IsBlockBattleBarrier(BlockType bt)
        {
            return bt == BlockType.BattleBarrierBasic || bt == BlockType.BattleBarrierBones || bt == BlockType.BattleBarrierLab || bt == BlockType.DisappearingBlock
                || bt == BlockType.DisappearingBlockSecret01 || bt == BlockType.DisappearingBlockSecret02 || bt == BlockType.DisappearingBlockSecret03;
        }

        public static bool IsBlockInstaKill(BlockType bt)
        {
            switch (bt)
            {
                case BlockType.Buzzsaw:
                case BlockType.SpikeBall:
                case BlockType.Spikes:
                case BlockType.CandySpikes:
                case BlockType.AlienMine:
                case BlockType.JellyfishElectric:
                case BlockType.PufferFishTrap:
                case BlockType.JetRaceMine:
                case BlockType.SpikesIce:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsBasicPlatform(BlockType bt)
        {
            switch (bt)
            {
                case BlockType.WoodenPlatform:
                case BlockType.MetalPlatform:
                case BlockType.BonusPlatform:
                case BlockType.StonePlatform:
                case BlockType.NetherBridge:
                case BlockType.NetherPlatform:
                case BlockType.IcePlatform:
                case BlockType.GluePlatform:
                case BlockType.RedJelloPlatform:
                case BlockType.ConcretePlatform:
                case BlockType.MetalBeamPlatform:
                case BlockType.LabPlatform:
                case BlockType.FantasyPlatformLight:
                case BlockType.FantasyPlatformDark:
                case BlockType.AlienPlatform:
                case BlockType.ShipPlatform:
                case BlockType.WoodenPier:
                case BlockType.GlassPlatform:
                case BlockType.CandyCanePlatform:
                case BlockType.PixelPlatformToledo:
                case BlockType.PixelPlatformCabSav:
                case BlockType.PixelPlatformTawnyPort:
                case BlockType.PixelPlatformCopperRust:
                case BlockType.PixelPlatformChestnutRose:
                case BlockType.PixelPlatformRajah:
                case BlockType.PixelPlatformAlbescentWhite:
                case BlockType.PixelPlatformStarship:
                case BlockType.PixelPlatformApple:
                case BlockType.PixelPlatformSalem:
                case BlockType.PixelPlatformEden:
                case BlockType.PixelPlatformBlack:
                case BlockType.PixelPlatformShipGray:
                case BlockType.PixelPlatformSaltBox:
                case BlockType.PixelPlatformAmethystSmoke:
                case BlockType.PixelPlatformMoonRaker:
                case BlockType.PixelPlatformWhite:
                case BlockType.PixelPlatformAnakiwa:
                case BlockType.PixelPlatformCyan:
                case BlockType.PixelPlatformScienceBlue:
                case BlockType.PixelPlatformResolutionBlue:
                case BlockType.PixelPlatformBlackRock:
                case BlockType.PixelPlatformValhalla:
                case BlockType.PixelPlatformSeance:
                case BlockType.PixelPlatformBrilliantRose:
                case BlockType.PixelPlatformClassicRose:
                case BlockType.PixelPlatformSaffron:
                case BlockType.PixelPlatformTango:
                case BlockType.PixelPlatformRed:
                case BlockType.PixelPlatformTamarillo:
                case BlockType.PixelPlatformDeluge:
                case BlockType.PixelPlatformAstronaut:
                case BlockType.PixelPlatformBalticSea:
                case BlockType.PixelPlatformBittersweet:
                case BlockType.PixelPlatformBracken:
                case BlockType.PixelPlatformCafeRoyale:
                case BlockType.PixelPlatformDarkTan:
                case BlockType.PixelPlatformDodgerBlue:
                case BlockType.PixelPlatformEndeavour:
                case BlockType.PixelPlatformForestGreen:
                case BlockType.PixelPlatformJapaneseLaurel:
                case BlockType.PixelPlatformKorma:
                case BlockType.PixelPlatformTuscany:
                case BlockType.TempleWoodenPlatform:
                case BlockType.TempleStonePlatform:
                    return true;
                default:
                    return false;
            }
        }

        public static int GetBlockXP(BlockType bt)
        {
            return (int)blockExperienceAmount[(int)bt];
        }
    }
}