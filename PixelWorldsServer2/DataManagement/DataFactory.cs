using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes;
using Kernys.Bson;
using static PWS.Constants.Enums;

namespace PWS.DataManagement
{
    public static class DataFactory
    {
        public static BSONObject SpawnBSON(Player p, int bt, int itemId = 0)
        {
            switch (bt)
            {



                case 31:
                    return new BSONObject()
                    {
                        ["class"] = "BrazierData",
                        ["itemId"] = itemId,
                        ["blockType"] = 31,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 74:
                    return new BSONObject()
                    {
                        ["class"] = "SignData",
                        ["itemId"] = itemId,
                        ["blockType"] = 74,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["text"] = ""
                    };


                case 75:
                    return new BSONObject()
                    {
                        ["class"] = "MushroomData",
                        ["itemId"] = itemId,
                        ["blockType"] = 75,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 76:
                    return new BSONObject()
                    {
                        ["class"] = "DoorData",
                        ["itemId"] = itemId,
                        ["blockType"] = 76,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isLocked"] = true
                    };


                case 79:
                    return new BSONObject()
                    {
                        ["class"] = "LavaLampData",
                        ["itemId"] = itemId,
                        ["blockType"] = 79,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 80:
                    return new BSONObject()
                    {
                        ["class"] = "SmallChestData",
                        ["itemId"] = itemId,
                        ["blockType"] = 80,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["storageItemsAsInventoryKeys"] = new BSONArray(),
                        ["storageItemsAmounts"] = new BSONArray(),
                        ["maxStorageItems"] = 4,
                        ["inventoryDatas"] = new BSONObject()
                        {
                            ["DatasCount"] = 0
                        }
                    };


                case 88:
                    return new BSONObject()
                    {
                        ["class"] = "WoodenChairData",
                        ["itemId"] = itemId,
                        ["blockType"] = 88,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 91:
                    return new BSONObject()
                    {
                        ["class"] = "LanternData",
                        ["itemId"] = itemId,
                        ["blockType"] = 91,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 96:
                    return new BSONObject()
                    {
                        ["class"] = "FireplaceData",
                        ["itemId"] = itemId,
                        ["blockType"] = 96,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 98:
                    return new BSONObject()
                    {
                        ["class"] = "ArmchairData",
                        ["itemId"] = itemId,
                        ["blockType"] = 98,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 99:
                    return new BSONObject()
                    {
                        ["class"] = "GlassDoorData",
                        ["itemId"] = itemId,
                        ["blockType"] = 99,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isLocked"] = true
                    };


                case 100:
                    return new BSONObject()
                    {
                        ["class"] = "FloorLampData",
                        ["itemId"] = itemId,
                        ["blockType"] = 100,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 108:
                    return new BSONObject()
                    {
                        ["class"] = "OldTVData",
                        ["itemId"] = itemId,
                        ["blockType"] = 108,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 109:
                    return new BSONObject()
                    {
                        ["class"] = "SpikeTrapData",
                        ["itemId"] = itemId,
                        ["blockType"] = 109,
                        ["animOn"] = true,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["trapFrequencyType"] = 2,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 110:
                    return new BSONObject()
                    {
                        ["class"] = "EntrancePortalData",
                        ["itemId"] = itemId,
                        ["blockType"] = 110,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 111:
                    return new BSONObject()
                    {
                        ["class"] = "FireTrapData",
                        ["itemId"] = itemId,
                        ["blockType"] = 111,
                        ["animOn"] = true,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["trapFrequencyType"] = 2,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 112:
                    return new BSONObject()
                    {
                        ["class"] = "LEDSignData",
                        ["itemId"] = itemId,
                        ["blockType"] = 112,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["text"] = ""
                    };


                case 114:
                    return new BSONObject()
                    {
                        ["class"] = "DungeonDoorData",
                        ["itemId"] = itemId,
                        ["blockType"] = 114,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isLocked"] = true
                    };


                case 120:
                    return new BSONObject()
                    {
                        ["class"] = "HugeMetalFanData",
                        ["itemId"] = itemId,
                        ["blockType"] = 120,
                        ["animOn"] = true,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 125:
                    return new BSONObject()
                    {
                        ["class"] = "CastleDoorData",
                        ["itemId"] = itemId,
                        ["blockType"] = 125,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isLocked"] = true
                    };


                case 126:
                    return new BSONObject()
                    {
                        ["class"] = "IronChandelierData",
                        ["itemId"] = itemId,
                        ["blockType"] = 126,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 127:
                    return new BSONObject()
                    {
                        ["class"] = "ThroneData",
                        ["itemId"] = itemId,
                        ["blockType"] = 127,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 129:
                    return new BSONObject()
                    {
                        ["class"] = "FountainData",
                        ["itemId"] = itemId,
                        ["blockType"] = 129,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 130:
                    return new BSONObject()
                    {
                        ["class"] = "TorchData",
                        ["itemId"] = itemId,
                        ["blockType"] = 130,
                        ["animOn"] = true,
                        ["direction"] = 1,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isFlameOn"] = false
                    };


                case 132:
                    return new BSONObject()
                    {
                        ["class"] = "StereosData",
                        ["itemId"] = itemId,
                        ["blockType"] = 132,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 134:
                    return new BSONObject()
                    {
                        ["class"] = "HotTubData",
                        ["itemId"] = itemId,
                        ["blockType"] = 134,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 135:
                    return new BSONObject()
                    {
                        ["class"] = "SafeData",
                        ["itemId"] = itemId,
                        ["blockType"] = 135,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["storageItemsAsInventoryKeys"] = new BSONArray(),
                        ["storageItemsAmounts"] = new BSONArray(),
                        ["maxStorageItems"] = 6,
                        ["inventoryDatas"] = new BSONObject()
                        {
                            ["DatasCount"] = 0
                        }
                    };


                case 136:
                    return new BSONObject()
                    {
                        ["class"] = "ATMData",
                        ["itemId"] = itemId,
                        ["blockType"] = 136,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isCollectableStateOn"] = false
                    };


                case 140:
                    return new BSONObject()
                    {
                        ["class"] = "GoldenToiletData",
                        ["itemId"] = itemId,
                        ["blockType"] = 140,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 143:
                    return new BSONObject()
                    {
                        ["class"] = "BlackLeatherChairData",
                        ["itemId"] = itemId,
                        ["blockType"] = 143,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 144:
                    return new BSONObject()
                    {
                        ["class"] = "SellOMatData",
                        ["itemId"] = itemId,
                        ["blockType"] = 144,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isItemsToSell"] = false
                    };


                case 155:
                    return new BSONObject()
                    {
                        ["class"] = "BarnDoorData",
                        ["itemId"] = itemId,
                        ["blockType"] = 155,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isLocked"] = true
                    };


                case 218:
                    return new BSONObject()
                    {
                        ["class"] = "ChickenData",
                        ["itemId"] = itemId,
                        ["blockType"] = 218,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isCollectableStateOn"] = false
                    };


                case 219:
                    return new BSONObject()
                    {
                        ["class"] = "CowData",
                        ["itemId"] = itemId,
                        ["blockType"] = 219,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isCollectableStateOn"] = false
                    };


                case 220:
                    return new BSONObject()
                    {
                        ["class"] = "SheepData",
                        ["itemId"] = itemId,
                        ["blockType"] = 220,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isCollectableStateOn"] = false
                    };


                case 226:
                    return new BSONObject()
                    {
                        ["class"] = "ScifiLightsData",
                        ["itemId"] = itemId,
                        ["blockType"] = 226,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 227:
                    return new BSONObject()
                    {
                        ["class"] = "ScifiDoorData",
                        ["itemId"] = itemId,
                        ["blockType"] = 227,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isLocked"] = true
                    };


                case 228:
                    return new BSONObject()
                    {
                        ["class"] = "ScifiGeneratorData",
                        ["itemId"] = itemId,
                        ["blockType"] = 228,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 231:
                    return new BSONObject()
                    {
                        ["class"] = "HauntedMirrorData",
                        ["itemId"] = itemId,
                        ["blockType"] = 231,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 233:
                    return new BSONObject()
                    {
                        ["class"] = "CandleStandData",
                        ["itemId"] = itemId,
                        ["blockType"] = 233,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 234:
                    return new BSONObject()
                    {
                        ["class"] = "GravestoneData",
                        ["itemId"] = itemId,
                        ["blockType"] = 234,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["text"] = ""
                    };


                case 236:
                    return new BSONObject()
                    {
                        ["class"] = "DiplomaData",
                        ["itemId"] = itemId,
                        ["blockType"] = 236,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["achievementType"] = -1,
                        ["stars"] = 0,
                        ["playerName"] = ""
                    };


                case 241:
                    return new BSONObject()
                    {
                        ["class"] = "YardLampData",
                        ["itemId"] = itemId,
                        ["blockType"] = 241,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 246:
                    return new BSONObject()
                    {
                        ["class"] = "FireBarrelData",
                        ["itemId"] = itemId,
                        ["blockType"] = 246,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 252:
                    return new BSONObject()
                    {
                        ["class"] = "RadioactiveBarrelData",
                        ["itemId"] = itemId,
                        ["blockType"] = 252,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 258:
                    return new BSONObject()
                    {
                        ["class"] = "FishBowlData",
                        ["itemId"] = itemId,
                        ["blockType"] = 258,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 262:
                    return new BSONObject()
                    {
                        ["class"] = "ManekiNekoRData",
                        ["itemId"] = itemId,
                        ["blockType"] = 262,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 263:
                    return new BSONObject()
                    {
                        ["class"] = "BedData",
                        ["itemId"] = itemId,
                        ["blockType"] = 263,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 264:
                    return new BSONObject()
                    {
                        ["class"] = "BookPodiumData",
                        ["itemId"] = itemId,
                        ["blockType"] = 264,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["text"] = ""
                    };


                case 265:
                    return new BSONObject()
                    {
                        ["class"] = "GargoyleData",
                        ["itemId"] = itemId,
                        ["blockType"] = 265,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 267:
                    return new BSONObject()
                    {
                        ["class"] = "CoffinData",
                        ["itemId"] = itemId,
                        ["blockType"] = 267,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 271:
                    return new BSONObject()
                    {
                        ["class"] = "NoteBoardData",
                        ["itemId"] = itemId,
                        ["blockType"] = 271,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["text"] = ""
                    };


                case 272:
                    return new BSONObject()
                    {
                        ["class"] = "GlassDoorTintedData",
                        ["itemId"] = itemId,
                        ["blockType"] = 272,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isLocked"] = true
                    };


                case 273:
                    return new BSONObject()
                    {
                        ["class"] = "DiceData",
                        ["itemId"] = itemId,
                        ["blockType"] = 273,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["randomDiceNumber"] = 2
                    };


                case 274:
                    return new BSONObject()
                    {
                        ["class"] = "GramophoneData",
                        ["itemId"] = itemId,
                        ["blockType"] = 274,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 276:
                    return new BSONObject()
                    {
                        ["class"] = "BarStoolData",
                        ["itemId"] = itemId,
                        ["blockType"] = 276,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 277:
                    return new BSONObject()
                    {
                        ["class"] = "HelloBotData",
                        ["itemId"] = itemId,
                        ["blockType"] = 277,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["text"] = new BSONArray(),
                        ["maxMessages"] = 5
                    };


                case 279:
                    return new BSONObject()
                    {
                        ["class"] = "ArrowSignData",
                        ["itemId"] = itemId,
                        ["blockType"] = 279,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 294:
                    return new BSONObject()
                    {
                        ["class"] = "MagicCauldronData",
                        ["itemId"] = itemId,
                        ["blockType"] = 294,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["itemBeingCraftedAsBlockType"] = 0,
                        ["craftingStartTimeInTicks"] = DateTime.UtcNow
                    };


                case 295:
                    return new BSONObject()
                    {
                        ["class"] = "VortexPortalData",
                        ["itemId"] = itemId,
                        ["blockType"] = 295,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["targetWorldID"] = "",
                        ["targetEntryPointID"] = "",
                        ["name"] = "",
                        ["entryPointID"] = "",
                        ["isLocked"] = false
                    };


                case 297:
                    return new BSONObject()
                    {
                        ["class"] = "FishtankData",
                        ["itemId"] = itemId,
                        ["blockType"] = 297,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 298:
                    return new BSONObject()
                    {
                        ["class"] = "FlatScreenTVData",
                        ["itemId"] = itemId,
                        ["blockType"] = 298,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 299:
                    return new BSONObject()
                    {
                        ["class"] = "WaterBedData",
                        ["itemId"] = itemId,
                        ["blockType"] = 299,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 303:
                    return new BSONObject()
                    {
                        ["class"] = "SkullBlockData",
                        ["itemId"] = itemId,
                        ["blockType"] = 303,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 304:
                    return new BSONObject()
                    {
                        ["class"] = "DiscoBallData",
                        ["itemId"] = itemId,
                        ["blockType"] = 304,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 305:
                    return new BSONObject()
                    {
                        ["class"] = "AmateurRadioData",
                        ["itemId"] = itemId,
                        ["blockType"] = 305,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isOn"] = true,
                        ["frequency"] = 0
                    };


                case 307:
                    return new BSONObject()
                    {
                        ["class"] = "MetalChairYellowData",
                        ["itemId"] = itemId,
                        ["blockType"] = 307,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 308:
                    return new BSONObject()
                    {
                        ["class"] = "MetalChairBlueData",
                        ["itemId"] = itemId,
                        ["blockType"] = 308,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 309:
                    return new BSONObject()
                    {
                        ["class"] = "MetalChairRedData",
                        ["itemId"] = itemId,
                        ["blockType"] = 309,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 310:
                    return new BSONObject()
                    {
                        ["class"] = "MetalChairPinkData",
                        ["itemId"] = itemId,
                        ["blockType"] = 310,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 311:
                    return new BSONObject()
                    {
                        ["class"] = "MetalChairGreenData",
                        ["itemId"] = itemId,
                        ["blockType"] = 311,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 312:
                    return new BSONObject()
                    {
                        ["class"] = "TVChairData",
                        ["itemId"] = itemId,
                        ["blockType"] = 312,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 313:
                    return new BSONObject()
                    {
                        ["class"] = "SargophagusData",
                        ["itemId"] = itemId,
                        ["blockType"] = 313,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 316:
                    return new BSONObject()
                    {
                        ["class"] = "OpenSignData",
                        ["itemId"] = itemId,
                        ["blockType"] = 316,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 318:
                    return new BSONObject()
                    {
                        ["class"] = "MarbleFireplaceData",
                        ["itemId"] = itemId,
                        ["blockType"] = 318,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 319:
                    return new BSONObject()
                    {
                        ["class"] = "BatData",
                        ["itemId"] = itemId,
                        ["blockType"] = 319,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 320:
                    return new BSONObject()
                    {
                        ["class"] = "BathtubData",
                        ["itemId"] = itemId,
                        ["blockType"] = 320,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 321:
                    return new BSONObject()
                    {
                        ["class"] = "ParrotCageData",
                        ["itemId"] = itemId,
                        ["blockType"] = 321,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 323:
                    return new BSONObject()
                    {
                        ["class"] = "MailboxData",
                        ["itemId"] = itemId,
                        ["blockType"] = 323,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isSomethingIn"] = false
                    };


                case 325:
                    return new BSONObject()
                    {
                        ["class"] = "SwingChairData",
                        ["itemId"] = itemId,
                        ["blockType"] = 325,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 326:
                    return new BSONObject()
                    {
                        ["class"] = "MirrorWardrobeData",
                        ["itemId"] = itemId,
                        ["blockType"] = 326,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["storageItemsAsInventoryKeys"] = new BSONArray(),
                        ["storageItemsAmounts"] = new BSONArray(),
                        ["maxStorageItems"] = 4,
                        ["inventoryDatas"] = new BSONObject()
                        {
                            ["DatasCount"] = 0
                        }
                    };


                case 329:
                    return new BSONObject()
                    {
                        ["class"] = "PortalData",
                        ["itemId"] = itemId,
                        ["blockType"] = 329,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["targetWorldID"] = "",
                        ["targetEntryPointID"] = "",
                        ["name"] = "",
                        ["entryPointID"] = "",
                        ["isLocked"] = false,
                        ["password"] = ""
                    };


                case 330:
                    return new BSONObject()
                    {
                        ["class"] = "CeilingLampWhiteData",
                        ["itemId"] = itemId,
                        ["blockType"] = 330,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 335:
                    return new BSONObject()
                    {
                        ["class"] = "DiscoBlockData",
                        ["itemId"] = itemId,
                        ["blockType"] = 335,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 336:
                    return new BSONObject()
                    {
                        ["class"] = "WhiteboardData",
                        ["itemId"] = itemId,
                        ["blockType"] = 336,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["text"] = ""
                    };


                case 341:
                    return new BSONObject()
                    {
                        ["class"] = "WardrobeData",
                        ["itemId"] = itemId,
                        ["blockType"] = 341,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["storageItemsAsInventoryKeys"] = new BSONArray(),
                        ["storageItemsAmounts"] = new BSONArray(),
                        ["maxStorageItems"] = 4,
                        ["inventoryDatas"] = new BSONObject()
                        {
                            ["DatasCount"] = 0
                        }
                    };


                case 410:
                    return new BSONObject()
                    {
                        ["class"] = "LockSmallData",
                        ["itemId"] = itemId,
                        ["blockType"] = 410,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["playerWhoOwnsLockId"] = "",
                        ["playerWhoOwnsLockName"] = "",
                        ["playersWhoHaveAccessToLock"] = new BSONArray(),
                        ["playersWhoHaveMinorAccessToLock"] = new BSONArray(),
                        ["isOpen"] = false,
                        ["ignoreEmptyArea"] = false,
                        ["lockMapPoints"] = new List<Vector2i>(),
                        ["creationTime"] = DateTime.UtcNow,
                        ["lastActivatedTime"] = DateTime.UtcNow,
                        ["isBattleOn"] = false
                    };


                case 411:
                    return new BSONObject()
                    {
                        ["class"] = "LockMediumData",
                        ["itemId"] = itemId,
                        ["blockType"] = 411,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["playerWhoOwnsLockId"] = "",
                        ["playerWhoOwnsLockName"] = "",
                        ["playersWhoHaveAccessToLock"] = new BSONArray(),
                        ["playersWhoHaveMinorAccessToLock"] = new BSONArray(),
                        ["isOpen"] = false,
                        ["ignoreEmptyArea"] = false,
                        ["lockMapPoints"] = new List<Vector2i>(),
                        ["creationTime"] = DateTime.UtcNow,
                        ["lastActivatedTime"] = DateTime.UtcNow,
                        ["isBattleOn"] = false
                    };


                case 412:
                    return new BSONObject()
                    {
                        ["class"] = "LockLargeData",
                        ["itemId"] = itemId,
                        ["blockType"] = 412,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["playerWhoOwnsLockId"] = "",
                        ["playerWhoOwnsLockName"] = "",
                        ["playersWhoHaveAccessToLock"] = new BSONArray(),
                        ["playersWhoHaveMinorAccessToLock"] = new BSONArray(),
                        ["isOpen"] = false,
                        ["ignoreEmptyArea"] = false,
                        ["lockMapPoints"] = new List<Vector2i>(),
                        ["creationTime"] = DateTime.UtcNow,
                        ["lastActivatedTime"] = DateTime.UtcNow,
                        ["isBattleOn"] = false
                    };


                case 413:
                    return new BSONObject()
                    {
                        ["class"] = "LockWorldData",
                        ["itemId"] = itemId,
                        ["blockType"] = 413,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["playerWhoOwnsLockId"] = p.ClientID,
                        ["playerWhoOwnsLockName"] = p.Data.Name,
                        ["playersWhoHaveAccessToLock"] = new List<string>(),
                        ["playersWhoHaveMinorAccessToLock"] = new List<string>(),
                        ["isOpen"] = false,
                        ["punchingAllowed"] = false,
                        ["creationTime"] = DateTime.UtcNow,
                        ["lastActivatedTime"] = DateTime.UtcNow,
                        ["isBattleOn"] = false,

                    };


                case 414:
                    return new BSONObject()
                    {
                        ["class"] = "LockGoldData",
                        ["itemId"] = itemId,
                        ["blockType"] = 414,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["playerWhoOwnsLockId"] = p.ClientID,
                        ["playerWhoOwnsLockName"] = p.Data.Name,
                        ["playersWhoHaveAccessToLock"] = new List<string>(),
                        ["playersWhoHaveMinorAccessToLock"] = new List<string>(),
                        ["isOpen"] = false,
                        ["punchingAllowed"] = false,
                        ["creationTime"] = DateTime.UtcNow,
                        ["lastActivatedTime"] = DateTime.UtcNow,
                        ["isBattleOn"] = false,
                    };


                case 415:
                    return new BSONObject()
                    {
                        ["class"] = "LockDiamondData",
                        ["itemId"] = itemId,
                        ["blockType"] = 415,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["playerWhoOwnsLockId"] = p.ClientID,
                        ["playerWhoOwnsLockName"] = p.Data.Name,
                        ["playersWhoHaveAccessToLock"] = new List<string>(),
                        ["playersWhoHaveMinorAccessToLock"] = new List<string>(),
                        ["isOpen"] = false,
                        ["punchingAllowed"] = false,
                        ["creationTime"] = DateTime.UtcNow,
                        ["lastActivatedTime"] = DateTime.UtcNow,
                        ["isBattleOn"] = false,
                    };


                case 416:
                    return new BSONObject()
                    {
                        ["class"] = "LockClanData",
                        ["itemId"] = itemId,
                        ["blockType"] = 416,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["playerWhoOwnsLockId"] = p.ClientID,
                        ["playerWhoOwnsLockName"] = p.Data.Name,
                        ["playersWhoHaveAccessToLock"] = new List<string>(),
                        ["playersWhoHaveMinorAccessToLock"] = new List<string>(),
                        ["isOpen"] = false,
                        ["punchingAllowed"] = false,
                        ["creationTime"] = DateTime.UtcNow,
                        ["lastActivatedTime"] = DateTime.UtcNow,
                        ["isBattleOn"] = false,
                    };


                case 419:
                    return new BSONObject()
                    {
                        ["class"] = "CheckPointData",
                        ["itemId"] = itemId,
                        ["blockType"] = 419,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false
                    };


                case 424:
                    return new BSONObject()
                    {
                        ["class"] = "PennantBlackData",
                        ["itemId"] = itemId,
                        ["blockType"] = 424,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 453:
                    return new BSONObject()
                    {
                        ["class"] = "BuzzsawData",
                        ["itemId"] = itemId,
                        ["blockType"] = 453,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 502:
                    return new BSONObject()
                    {
                        ["class"] = "ArmChairLeopardData",
                        ["itemId"] = itemId,
                        ["blockType"] = 502,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 525:
                    return new BSONObject()
                    {
                        ["class"] = "TutorialBotData",
                        ["itemId"] = itemId,
                        ["blockType"] = 525,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["text"] = "",
                        ["bodyAnimation"] = 0,
                        ["playFaceAnimation"] = false,
                        ["faceAnimation"] = 0,
                        ["deltaKey"] = "",
                        ["customData"] = -1
                    };


                case 570:
                    return new BSONObject()
                    {
                        ["class"] = "GlowingContainerData",
                        ["itemId"] = itemId,
                        ["blockType"] = 570,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 587:
                    return new BSONObject()
                    {
                        ["class"] = "MiniatureSpaceshipData",
                        ["itemId"] = itemId,
                        ["blockType"] = 587,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 589:
                    return new BSONObject()
                    {
                        ["class"] = "ScifiComputerData",
                        ["itemId"] = itemId,
                        ["blockType"] = 589,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 590:
                    return new BSONObject()
                    {
                        ["class"] = "BonusDoorVIPData",
                        ["itemId"] = itemId,
                        ["blockType"] = 590,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isLocked"] = true
                    };


                case 632:
                    return new BSONObject()
                    {
                        ["class"] = "WinterBellsData",
                        ["itemId"] = itemId,
                        ["blockType"] = 632,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 648:
                    return new BSONObject()
                    {
                        ["class"] = "HatchWoodenData",
                        ["itemId"] = itemId,
                        ["blockType"] = 648,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isLocked"] = true
                    };


                case 649:
                    return new BSONObject()
                    {
                        ["class"] = "HatchMetalData",
                        ["itemId"] = itemId,
                        ["blockType"] = 649,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isLocked"] = true
                    };


                case 656:
                    return new BSONObject()
                    {
                        ["class"] = "CloudPlatformData",
                        ["itemId"] = itemId,
                        ["blockType"] = 656,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 680:
                    return new BSONObject()
                    {
                        ["class"] = "CakeData",
                        ["itemId"] = itemId,
                        ["blockType"] = 680,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 706:
                    return new BSONObject()
                    {
                        ["class"] = "GummyBearOrangeData",
                        ["itemId"] = itemId,
                        ["blockType"] = 706,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 707:
                    return new BSONObject()
                    {
                        ["class"] = "GummyBearGreenData",
                        ["itemId"] = itemId,
                        ["blockType"] = 707,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 708:
                    return new BSONObject()
                    {
                        ["class"] = "GummyBearRedData",
                        ["itemId"] = itemId,
                        ["blockType"] = 708,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 757:
                    return new BSONObject()
                    {
                        ["class"] = "MushroomGreenData",
                        ["itemId"] = itemId,
                        ["blockType"] = 757,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 785:
                    return new BSONObject()
                    {
                        ["class"] = "QuestNPCData",
                        ["itemId"] = itemId,
                        ["blockType"] = 785,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["questLineType"] = "",
                        ["questNPCVisualLookType"] = 0
                    };


                case 796:
                    return new BSONObject()
                    {
                        ["class"] = "LockPlatinumData",
                        ["itemId"] = itemId,
                        ["blockType"] = 796,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["playerWhoOwnsLockId"] = p.ClientID,
                        ["playerWhoOwnsLockName"] = p.Data.Name,
                        ["playersWhoHaveAccessToLock"] = new List<string>(),
                        ["playersWhoHaveMinorAccessToLock"] = new List<string>(),
                        ["isOpen"] = false,
                        ["punchingAllowed"] = false,
                        ["creationTime"] = DateTime.UtcNow,
                        ["lastActivatedTime"] = DateTime.UtcNow,
                        ["isBattleOn"] = false,
                    };


                case 815:
                    return new BSONObject()
                    {
                        ["class"] = "BunnyPlushToyData",
                        ["itemId"] = itemId,
                        ["blockType"] = 815,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 816:
                    return new BSONObject()
                    {
                        ["class"] = "ChickPlushToyData",
                        ["itemId"] = itemId,
                        ["blockType"] = 816,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 882:
                    return new BSONObject()
                    {
                        ["class"] = "LockWorldDarkData",
                        ["itemId"] = itemId,
                        ["blockType"] = 882,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["playerWhoOwnsLockId"] = p.ClientID,
                        ["playerWhoOwnsLockName"] = p.Data.Name,
                        ["playersWhoHaveAccessToLock"] = new List<string>(),
                        ["playersWhoHaveMinorAccessToLock"] = new List<string>(),
                        ["isOpen"] = false,
                        ["punchingAllowed"] = false,
                        ["creationTime"] = DateTime.UtcNow,
                        ["lastActivatedTime"] = DateTime.UtcNow,
                        ["isBattleOn"] = false,
                    };


                case 953:
                    return new BSONObject()
                    {
                        ["class"] = "DeflectorData",
                        ["itemId"] = itemId,
                        ["blockType"] = 953,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 954:
                    return new BSONObject()
                    {
                        ["class"] = "PinballBumperData",
                        ["itemId"] = itemId,
                        ["blockType"] = 954,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 955:
                    return new BSONObject()
                    {
                        ["class"] = "SpringBoardData",
                        ["itemId"] = itemId,
                        ["blockType"] = 955,
                        ["animOn"] = false,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 956:
                    return new BSONObject()
                    {
                        ["class"] = "TrapdoorMetalPlatformData",
                        ["itemId"] = itemId,
                        ["blockType"] = 956,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 957:
                    return new BSONObject()
                    {
                        ["class"] = "PoisonTrapData",
                        ["itemId"] = itemId,
                        ["blockType"] = 957,
                        ["animOn"] = true,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["trapFrequencyType"] = 1,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 959:
                    return new BSONObject()
                    {
                        ["class"] = "SpikeBallData",
                        ["itemId"] = itemId,
                        ["blockType"] = 959,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 961:
                    return new BSONObject()
                    {
                        ["class"] = "TeslaSphereData",
                        ["itemId"] = itemId,
                        ["blockType"] = 961,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["trapFrequencyType"] = 3,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 966:
                    return new BSONObject()
                    {
                        ["class"] = "GiftBoxData",
                        ["itemId"] = itemId,
                        ["blockType"] = 966,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["itemInventoryKeyAsInt"] = 0,
                        ["itemAmount"] = 0,
                        ["takeAmount"] = 1
                    };


                case 967:
                    return new BSONObject()
                    {
                        ["class"] = "ScoreBoardData",
                        ["itemId"] = itemId,
                        ["blockType"] = 967,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 970:
                    return new BSONObject()
                    {
                        ["class"] = "DeathCounterData",
                        ["itemId"] = itemId,
                        ["blockType"] = 970,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 980:
                    return new BSONObject()
                    {
                        ["class"] = "TaikoDrumData",
                        ["itemId"] = itemId,
                        ["blockType"] = 980,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 985:
                    return new BSONObject()
                    {
                        ["class"] = "ManekiNekoLData",
                        ["itemId"] = itemId,
                        ["blockType"] = 985,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1077:
                    return new BSONObject()
                    {
                        ["class"] = "LifeGuardChairData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1077,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 1125:
                    return new BSONObject()
                    {
                        ["class"] = "FAMFoodMachineData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1125,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["itemBeingCraftedAsBlockType"] = 0,
                        ["craftingStartTimeInTicks"] = DateTime.UtcNow
                    };


                case 1126:
                    return new BSONObject()
                    {
                        ["class"] = "FAMEvolveratorData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1126,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["familiarBeingEvolvedAsBlockType"] = 0,
                        ["evolveStartTimeInTicks"] = DateTime.UtcNow
                    };


                case 1129:
                    return new BSONObject()
                    {
                        ["class"] = "KiddieRideData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1129,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1131:
                    return new BSONObject()
                    {
                        ["class"] = "LockWorldBattleData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1131,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["playerWhoOwnsLockId"] = p.ClientID,
                        ["playerWhoOwnsLockName"] = p.Data.Name,
                        ["playersWhoHaveAccessToLock"] = new List<string>(),
                        ["playersWhoHaveMinorAccessToLock"] = new List<string>(),
                        ["isOpen"] = false,
                        ["punchingAllowed"] = true,
                        ["creationTime"] = DateTime.UtcNow,
                        ["lastActivatedTime"] = DateTime.UtcNow,
                        ["isBattleOn"] = false
                    };


                case 1132:
                    return new BSONObject()
                    {
                        ["class"] = "LockBattleData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1132,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["playerWhoOwnsLockId"] = "",
                        ["playerWhoOwnsLockName"] = "",
                        ["playersWhoHaveAccessToLock"] = new BSONArray(),
                        ["playersWhoHaveMinorAccessToLock"] = new BSONArray(),
                        ["isOpen"] = false,
                        ["ignoreEmptyArea"] = false,
                        ["lockMapPoints"] = new List<Vector2i>(),
                        ["creationTime"] = DateTime.UtcNow,
                        ["lastActivatedTime"] = DateTime.UtcNow,
                        ["isBattleOn"] = false
                    };


                case 1133:
                    return new BSONObject()
                    {
                        ["class"] = "BattleBarrierBasicData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1133,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isOpen"] = false
                    };


                case 1134:
                    return new BSONObject()
                    {
                        ["class"] = "BattleScoreBoardData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1134,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1159:
                    return new BSONObject()
                    {
                        ["class"] = "GlowBlockBlueData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1159,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1160:
                    return new BSONObject()
                    {
                        ["class"] = "GlowBlockGreenData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1160,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1161:
                    return new BSONObject()
                    {
                        ["class"] = "GlowBlockOrangeData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1161,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1162:
                    return new BSONObject()
                    {
                        ["class"] = "GlowBlockRedData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1162,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1184:
                    return new BSONObject()
                    {
                        ["class"] = "OldWallLampData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1184,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1186:
                    return new BSONObject()
                    {
                        ["class"] = "ToiletSeatData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1186,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 1282:
                    return new BSONObject()
                    {
                        ["class"] = "BonfireData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1282,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1284:
                    return new BSONObject()
                    {
                        ["class"] = "RavenTreeData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1284,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1286:
                    return new BSONObject()
                    {
                        ["class"] = "VikingFigureheadData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1286,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1334:
                    return new BSONObject()
                    {
                        ["class"] = "BlackCandlesData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1334,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1335:
                    return new BSONObject()
                    {
                        ["class"] = "PumpkinLanternData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1335,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1338:
                    return new BSONObject()
                    {
                        ["class"] = "OuijaBoardData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1338,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1339:
                    return new BSONObject()
                    {
                        ["class"] = "ElectricChairData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1339,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 1340:
                    return new BSONObject()
                    {
                        ["class"] = "SpikesData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1340,
                        ["animOn"] = false,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1341:
                    return new BSONObject()
                    {
                        ["class"] = "ChurchBellData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1341,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1342:
                    return new BSONObject()
                    {
                        ["class"] = "SpiderWebData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1342,
                        ["animOn"] = false,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1346:
                    return new BSONObject()
                    {
                        ["class"] = "TombStoneData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1346,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["text"] = ""
                    };


                case 1347:
                    return new BSONObject()
                    {
                        ["class"] = "MimicCoffinData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1347,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 1348:
                    return new BSONObject()
                    {
                        ["class"] = "CheckpointBonfireData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1348,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false
                    };


                case 1353:
                    return new BSONObject()
                    {
                        ["class"] = "ZombieTrapData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1353,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["trapFrequencyType"] = 1,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 1355:
                    return new BSONObject()
                    {
                        ["class"] = "BattleBarrierBonesData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1355,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isOpen"] = false
                    };


                case 1358:
                    return new BSONObject()
                    {
                        ["class"] = "RuleBotData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1358,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isDoubleJumpAllowed"] = false,
                        ["isLongJumpAllowed"] = false,
                        ["isParachuteAllowed"] = false,
                        ["isRocketAllowed"] = false,
                        ["isContinuousJumpingAllowed"] = false,
                        ["isTripleJumpAllowed"] = false
                    };


                case 1359:
                    return new BSONObject()
                    {
                        ["class"] = "SpiralPillarData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1359,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1363:
                    return new BSONObject()
                    {
                        ["class"] = "HeadstoneData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1363,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["text"] = ""
                    };


                case 1364:
                    return new BSONObject()
                    {
                        ["class"] = "CelticCrossData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1364,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["text"] = ""
                    };


                case 1365:
                    return new BSONObject()
                    {
                        ["class"] = "GraveSlantData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1365,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["text"] = ""
                    };


                case 1370:
                    return new BSONObject()
                    {
                        ["class"] = "WotwTrophyData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1370,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["worldname"] = "",
                        ["winnername"] = "",
                        ["awardedticks"] = DateTime.UnixEpoch.Ticks
                    };


                case 1371:
                    return new BSONObject()
                    {
                        ["class"] = "AIEnemySpawnerBasicData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1371,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["possibleAIEnemyTypes"] = new BSONArray(),
                        ["aiEnemyTypesShuffleBagValue"] = new BSONArray(),
                        ["offsetX"] = 0,
                        ["offsetY"] = 0,
                        ["aiEnemyDirections"] = new BSONArray()
                    };


                case 1372:
                    return new BSONObject()
                    {
                        ["class"] = "NetherLavaFallData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1372,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1373:
                    return new BSONObject()
                    {
                        ["class"] = "NetherBridgeData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1373,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1384:
                    return new BSONObject()
                    {
                        ["class"] = "NetherPlatformData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1384,
                        ["animOn"] = false,
                        ["direction"] = 5,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1392:
                    return new BSONObject()
                    {
                        ["class"] = "NetherGiftBoxData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1392,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["itemInventoryKeyAsInt"] = 0,
                        ["itemAmount"] = 0,
                        ["takeAmount"] = 1
                    };


                case 1398:
                    return new BSONObject()
                    {
                        ["class"] = "TreasureSpawnerData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1398,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["possibleBlockTypes"] = new BSONArray(),
                        ["blockTypesShuffleBagValue"] = new BSONArray(),
                        ["offsetX"] = 0,
                        ["offsetY"] = 0
                    };


                case 1399:
                    return new BSONObject()
                    {
                        ["class"] = "CheckPointSpawnerData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1399,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["possibleBlockTypes"] = new BSONArray(),
                        ["blockTypesShuffleBagValue"] = new BSONArray(),
                        ["offsetX"] = 0,
                        ["offsetY"] = 0
                    };


                case 1401:
                    return new BSONObject()
                    {
                        ["class"] = "FireBallShooterTrapData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1401,
                        ["animOn"] = true,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["trapFrequencyType"] = 2,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 1408:
                    return new BSONObject()
                    {
                        ["class"] = "NetherFireTrapData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1408,
                        ["animOn"] = true,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["trapFrequencyType"] = 2,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 1409:
                    return new BSONObject()
                    {
                        ["class"] = "NetherSpikeTrapData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1409,
                        ["animOn"] = true,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["trapFrequencyType"] = 2,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 1410:
                    return new BSONObject()
                    {
                        ["class"] = "NetherFireBallShooterTrapData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1410,
                        ["animOn"] = true,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["trapFrequencyType"] = 2,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 1411:
                    return new BSONObject()
                    {
                        ["class"] = "NetherDeathCounterData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1411,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1419:
                    return new BSONObject()
                    {
                        ["class"] = "NetherExitData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1419,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isOpen"] = false,
                        ["collectedKeysCount"] = 0
                    };


                case 1451:
                    return new BSONObject()
                    {
                        ["class"] = "GingerbreadSignData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1451,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["text"] = ""
                    };


                case 1454:
                    return new BSONObject()
                    {
                        ["class"] = "SnowLanternData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1454,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1481:
                    return new BSONObject()
                    {
                        ["class"] = "AnniversaryPortalData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1481,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["targetWorldID"] = "",
                        ["targetEntryPointID"] = "",
                        ["name"] = "",
                        ["entryPointID"] = "",
                        ["isLocked"] = false
                    };


                case 1482:
                    return new BSONObject()
                    {
                        ["class"] = "VendorNPCData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1482,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["vendorNPCVisualLookType"] = 0,
                        ["vendorNPCCatalogs"] = new BSONArray()
                    };


                case 1502:
                    return new BSONObject()
                    {
                        ["class"] = "DeepNetherExitData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1502,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isOpen"] = false
                    };


                case 1504:
                    return new BSONObject()
                    {
                        ["class"] = "NetherSignData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1504,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["text"] = ""
                    };


                case 1514:
                    return new BSONObject()
                    {
                        ["class"] = "HangingLeavesData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1514,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1519:
                    return new BSONObject()
                    {
                        ["class"] = "TreeTrunk1Data",
                        ["itemId"] = itemId,
                        ["blockType"] = 1519,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1535:
                    return new BSONObject()
                    {
                        ["class"] = "ScifiArrowData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1535,
                        ["animOn"] = true,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1566:
                    return new BSONObject()
                    {
                        ["class"] = "BoomBoxData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1566,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1568:
                    return new BSONObject()
                    {
                        ["class"] = "InfoNPCData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1568,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["infoType"] = 0,
                        ["infoNPCVisualLookType"] = 0,
                        ["indexNumber"] = 0
                    };


                case 1596:
                    return new BSONObject()
                    {
                        ["class"] = "PortalWOTWData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1596,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["targetWorldID"] = "",
                        ["targetEntryPointID"] = "",
                        ["name"] = "",
                        ["entryPointID"] = "",
                        ["isLocked"] = false,
                        ["password"] = ""
                    };


                case 1604:
                    return new BSONObject()
                    {
                        ["class"] = "SpotlightData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1604,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1659:
                    return new BSONObject()
                    {
                        ["class"] = "ConstructionBarricadeData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1659,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1664:
                    return new BSONObject()
                    {
                        ["class"] = "RuinsPillarData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1664,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1666:
                    return new BSONObject()
                    {
                        ["class"] = "ShowerData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1666,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1668:
                    return new BSONObject()
                    {
                        ["class"] = "TwistedWoodPillarData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1668,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1781:
                    return new BSONObject()
                    {
                        ["class"] = "EasterChicksData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1781,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1782:
                    return new BSONObject()
                    {
                        ["class"] = "PsychoBunnyData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1782,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1799:
                    return new BSONObject()
                    {
                        ["class"] = "NetherGroupPortalData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1799,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["targetWorldID"] = "NETHERWORLD",
                        ["targetEntryPointID"] = "",
                        ["name"] = "Netherworld",
                        ["entryPointID"] = "",
                        ["isLocked"] = false,
                        ["password"] = "",
                        ["isActivated"] = false,
                        ["netherworldID"] = "",
                        ["idNumber"] = 0,
                        ["startTimeInTicks"] = DateTime.UtcNow,
                        ["useCount"] = 0
                    };


                case 1851:
                    return new BSONObject()
                    {
                        ["class"] = "DrainPipeDarkData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1851,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1852:
                    return new BSONObject()
                    {
                        ["class"] = "DrainPipeLightData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1852,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1853:
                    return new BSONObject()
                    {
                        ["class"] = "EmergencyStairsGreyData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1853,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1854:
                    return new BSONObject()
                    {
                        ["class"] = "EmergencyStairsRedData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1854,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1883:
                    return new BSONObject()
                    {
                        ["class"] = "MetalBeamBlockData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1883,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1892:
                    return new BSONObject()
                    {
                        ["class"] = "NeonSignIcecreamData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1892,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1893:
                    return new BSONObject()
                    {
                        ["class"] = "NeonSignSodaData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1893,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1897:
                    return new BSONObject()
                    {
                        ["class"] = "PhoneLinePoleData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1897,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1898:
                    return new BSONObject()
                    {
                        ["class"] = "PipeBlockData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1898,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1906:
                    return new BSONObject()
                    {
                        ["class"] = "SewerPipeBlackData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1906,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1907:
                    return new BSONObject()
                    {
                        ["class"] = "SewerPipeRustyData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1907,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1914:
                    return new BSONObject()
                    {
                        ["class"] = "StreetBenchData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1914,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 1916:
                    return new BSONObject()
                    {
                        ["class"] = "TrafficLightsData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1916,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1917:
                    return new BSONObject()
                    {
                        ["class"] = "TrussData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1917,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1919:
                    return new BSONObject()
                    {
                        ["class"] = "UrbanArrowSignData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1919,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1922:
                    return new BSONObject()
                    {
                        ["class"] = "RecyclerBasicData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1922,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["recycledPoints"] = 0
                    };


                case 1957:
                    return new BSONObject()
                    {
                        ["class"] = "LabElectricWireBlueData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1957,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1958:
                    return new BSONObject()
                    {
                        ["class"] = "LabElectricWireLargeData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1958,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1959:
                    return new BSONObject()
                    {
                        ["class"] = "LabElectricWireRedData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1959,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1970:
                    return new BSONObject()
                    {
                        ["class"] = "LabHoseLargeData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1970,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1972:
                    return new BSONObject()
                    {
                        ["class"] = "LabLightRedData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1972,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 1994:
                    return new BSONObject()
                    {
                        ["class"] = "LabEnterPortalData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1994,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["targetWorldID"] = "",
                        ["targetEntryPointID"] = "",
                        ["name"] = "",
                        ["entryPointID"] = "",
                        ["isLocked"] = false,
                        ["password"] = ""
                    };


                case 1995:
                    return new BSONObject()
                    {
                        ["class"] = "LabExitPortalData",
                        ["itemId"] = itemId,
                        ["blockType"] = 1995,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["targetWorldID"] = "",
                        ["targetEntryPointID"] = "",
                        ["name"] = "",
                        ["entryPointID"] = "",
                        ["isLocked"] = false,
                        ["password"] = "",
                        ["isActivated"] = false
                    };


                case 2001:
                    return new BSONObject()
                    {
                        ["class"] = "BluePortalData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2001,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["targetWorldID"] = "SECRETBASE",
                        ["targetEntryPointID"] = "",
                        ["name"] = "Secret Base",
                        ["entryPointID"] = "",
                        ["isLocked"] = false,
                        ["password"] = "",
                        ["isActivated"] = false,
                        ["secretBaseLaboratoryID"] = "",
                        ["idNumber"] = 0,
                        ["startTimeInTicks"] = DateTime.UtcNow,
                        ["useCount"] = 0
                    };


                case 2003:
                    return new BSONObject()
                    {
                        ["class"] = "DeflectorSuperData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2003,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2004:
                    return new BSONObject()
                    {
                        ["class"] = "ElectricTrapData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2004,
                        ["animOn"] = true,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["trapFrequencyType"] = 2,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 2005:
                    return new BSONObject()
                    {
                        ["class"] = "LaserShooterTrapData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2005,
                        ["animOn"] = true,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["trapFrequencyType"] = 2,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 2006:
                    return new BSONObject()
                    {
                        ["class"] = "LabPoisonTrapData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2006,
                        ["animOn"] = true,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["trapFrequencyType"] = 1,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 2007:
                    return new BSONObject()
                    {
                        ["class"] = "LaserBeamTrapData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2007,
                        ["animOn"] = true,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["trapFrequencyType"] = 3,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 2008:
                    return new BSONObject()
                    {
                        ["class"] = "GravityModifierData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2008,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2051:
                    return new BSONObject()
                    {
                        ["class"] = "LabHangarDoor1Data",
                        ["itemId"] = itemId,
                        ["blockType"] = 2051,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2052:
                    return new BSONObject()
                    {
                        ["class"] = "LabHangarDoor2Data",
                        ["itemId"] = itemId,
                        ["blockType"] = 2052,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2053:
                    return new BSONObject()
                    {
                        ["class"] = "LabHangarDoor3Data",
                        ["itemId"] = itemId,
                        ["blockType"] = 2053,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2054:
                    return new BSONObject()
                    {
                        ["class"] = "LabHangarDoor4Data",
                        ["itemId"] = itemId,
                        ["blockType"] = 2054,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2065:
                    return new BSONObject()
                    {
                        ["class"] = "BattleBarrierLabData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2065,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isOpen"] = false
                    };


                case 2066:
                    return new BSONObject()
                    {
                        ["class"] = "LabGiftBoxData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2066,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["itemInventoryKeyAsInt"] = 0,
                        ["itemAmount"] = 0,
                        ["takeAmount"] = 1
                    };


                case 2070:
                    return new BSONObject()
                    {
                        ["class"] = "SpotlightFloorData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2070,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2078:
                    return new BSONObject()
                    {
                        ["class"] = "SuperHeroPinballBumperData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2078,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2079:
                    return new BSONObject()
                    {
                        ["class"] = "SuperHeroSpringBoardData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2079,
                        ["animOn"] = false,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2087:
                    return new BSONObject()
                    {
                        ["class"] = "QuantumSafeData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2087,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["storageItemsAsInventoryKeys"] = new BSONArray(),
                        ["storageItemsAmounts"] = new BSONArray(),
                        ["maxStorageItems"] = 20,
                        ["inventoryDatas"] = new BSONObject()
                        {
                            ["DatasCount"] = 0
                        }
                    };


                case 2113:
                    return new BSONObject()
                    {
                        ["class"] = "GiantClamData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2113,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["storageItemsAsInventoryKeys"] = new BSONArray(),
                        ["storageItemsAmounts"] = new BSONArray(),
                        ["maxStorageItems"] = 4,
                        ["inventoryDatas"] = new BSONObject()
                        {
                            ["DatasCount"] = 0
                        }
                    };


                case 2118:
                    return new BSONObject()
                    {
                        ["class"] = "SunchairData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2118,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 2119:
                    return new BSONObject()
                    {
                        ["class"] = "TikiTorchData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2119,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2121:
                    return new BSONObject()
                    {
                        ["class"] = "XtremeSpeakerData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2121,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2122:
                    return new BSONObject()
                    {
                        ["class"] = "WildBeeHiveData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2122,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2146:
                    return new BSONObject()
                    {
                        ["class"] = "DisplayBlockData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2146,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["storageItemAsInventoryKey"] = 0,
                        ["text"] = ""
                    };


                case 2148:
                    return new BSONObject()
                    {
                        ["class"] = "RuleBotWeaponData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2148,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isWeaponAllowed"] = false,
                        ["allowedRange"] = 2
                    };


                case 2166:
                    return new BSONObject()
                    {
                        ["class"] = "MannequinData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2166,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["itemsAsInventoryKeys"] = new BSONArray(),
                        ["inventoryDatas"] = new BSONObject()
                        {
                            ["DatasCount"] = 0
                        },
                        ["gender"] = 0
                    };


                case 2203:
                    return new BSONObject()
                    {
                        ["class"] = "DoorLevelVIPData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2203,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isVIPOnly"] = true,
                        ["minLevel"] = 0,
                        ["maxLevel"] = 0
                    };


                case 2204:
                    return new BSONObject()
                    {
                        ["class"] = "DoorLevelData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2204,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isVIPOnly"] = false,
                        ["minLevel"] = 0,
                        ["maxLevel"] = 0
                    };


                case 2205:
                    return new BSONObject()
                    {
                        ["class"] = "DoorVIPData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2205,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isVIPOnly"] = true,
                        ["minLevel"] = -1,
                        ["maxLevel"] = -1
                    };


                case 2206:
                    return new BSONObject()
                    {
                        ["class"] = "HatchLevelVIPData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2206,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isVIPOnly"] = true,
                        ["minLevel"] = 0,
                        ["maxLevel"] = 0
                    };


                case 2207:
                    return new BSONObject()
                    {
                        ["class"] = "HatchLevelData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2207,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isVIPOnly"] = false,
                        ["minLevel"] = 0,
                        ["maxLevel"] = 0
                    };


                case 2208:
                    return new BSONObject()
                    {
                        ["class"] = "HatchVIPData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2208,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isVIPOnly"] = true,
                        ["minLevel"] = -1,
                        ["maxLevel"] = -1
                    };


                case 2210:
                    return new BSONObject()
                    {
                        ["class"] = "VIPNeonSignData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2210,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2211:
                    return new BSONObject()
                    {
                        ["class"] = "StereosGreenData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2211,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2212:
                    return new BSONObject()
                    {
                        ["class"] = "LockWorldNoobData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2212,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["playerWhoOwnsLockId"] = p.ClientID,
                        ["playerWhoOwnsLockName"] = p.Data.Name,
                        ["playersWhoHaveAccessToLock"] = new List<string>(),
                        ["playersWhoHaveMinorAccessToLock"] = new List<string>(),
                        ["isOpen"] = false,
                        ["punchingAllowed"] = false,
                        ["creationTime"] = DateTime.UtcNow,
                        ["lastActivatedTime"] = DateTime.UtcNow,
                        ["isBattleOn"] = false
                    };


                case 2245:
                    return new BSONObject()
                    {
                        ["class"] = "FantasyBlueLightData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2245,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2246:
                    return new BSONObject()
                    {
                        ["class"] = "FantasyRedLightData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2246,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2250:
                    return new BSONObject()
                    {
                        ["class"] = "FantasyDarkPillarData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2250,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2251:
                    return new BSONObject()
                    {
                        ["class"] = "FantasyDarkSignData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2251,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2252:
                    return new BSONObject()
                    {
                        ["class"] = "FantasyDarkSupportBeamData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2252,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2255:
                    return new BSONObject()
                    {
                        ["class"] = "FantasyLightPillarData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2255,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2256:
                    return new BSONObject()
                    {
                        ["class"] = "FantasyLightSignData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2256,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2257:
                    return new BSONObject()
                    {
                        ["class"] = "FantasyLightSupportBeamData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2257,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2258:
                    return new BSONObject()
                    {
                        ["class"] = "FantasyWellData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2258,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["activatedStartTimeInTicks"] = DateTime.UnixEpoch.Ticks
                    };


                case 2274:
                    return new BSONObject()
                    {
                        ["class"] = "FantasySwordInStoneData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2274,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["activatedStartTimeInTicks"] = DateTime.UnixEpoch.Ticks
                    };


                case 2310:
                    return new BSONObject()
                    {
                        ["class"] = "FantasyPlatformLightData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2310,
                        ["animOn"] = false,
                        ["direction"] = 1,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2311:
                    return new BSONObject()
                    {
                        ["class"] = "FantasyPlatformDarkData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2311,
                        ["animOn"] = false,
                        ["direction"] = 1,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2321:
                    return new BSONObject()
                    {
                        ["class"] = "TreeTrunkSilverData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2321,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2322:
                    return new BSONObject()
                    {
                        ["class"] = "FantasyThroneDarkData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2322,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 2323:
                    return new BSONObject()
                    {
                        ["class"] = "FantasyThroneLightData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2323,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 2332:
                    return new BSONObject()
                    {
                        ["class"] = "RuleBotPotionData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2332,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isPotionsAllowed"] = false
                    };


                case 2344:
                    return new BSONObject()
                    {
                        ["class"] = "SlimeShooterTrapData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2344,
                        ["animOn"] = true,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["trapFrequencyType"] = 2,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 2345:
                    return new BSONObject()
                    {
                        ["class"] = "SpikeTrapHalloweenData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2345,
                        ["animOn"] = true,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["trapFrequencyType"] = 2,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 2380:
                    return new BSONObject()
                    {
                        ["class"] = "SwordThroneData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2380,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 2389:
                    return new BSONObject()
                    {
                        ["class"] = "BloodyChestData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2389,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["storageItemsAsInventoryKeys"] = new BSONArray(),
                        ["storageItemsAmounts"] = new BSONArray(),
                        ["maxStorageItems"] = 4,
                        ["inventoryDatas"] = new BSONObject()
                        {
                            ["DatasCount"] = 0
                        }
                    };


                case 2390:
                    return new BSONObject()
                    {
                        ["class"] = "AntiqueChairData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2390,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 2391:
                    return new BSONObject()
                    {
                        ["class"] = "ZombieTrapRedData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2391,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["trapFrequencyType"] = 1,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 2393:
                    return new BSONObject()
                    {
                        ["class"] = "PumpkinLanternBlackData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2393,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2401:
                    return new BSONObject()
                    {
                        ["class"] = "TombStoneMarbleData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2401,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["text"] = ""
                    };


                case 2402:
                    return new BSONObject()
                    {
                        ["class"] = "HugeMetalFanRedData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2402,
                        ["animOn"] = true,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2403:
                    return new BSONObject()
                    {
                        ["class"] = "SmallChestBlackGoldData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2403,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["storageItemsAsInventoryKeys"] = new BSONArray(),
                        ["storageItemsAmounts"] = new BSONArray(),
                        ["maxStorageItems"] = 4,
                        ["inventoryDatas"] = new BSONObject()
                        {
                            ["DatasCount"] = 0
                        }
                    };


                case 2492:
                    return new BSONObject()
                    {
                        ["class"] = "TrophyFishHerringData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2492,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["weight"] = 0.0,
                        ["playerName"] = "",
                        ["playerID"] = "",
                        ["caughtTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["lastUpdateTimeTicks"] = DateTime.UnixEpoch.Ticks
                    };


                case 2493:
                    return new BSONObject()
                    {
                        ["class"] = "TrophyFishKingfishData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2493,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["weight"] = 0.0,
                        ["playerName"] = "",
                        ["playerID"] = "",
                        ["caughtTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["lastUpdateTimeTicks"] = DateTime.UnixEpoch.Ticks
                    };


                case 2494:
                    return new BSONObject()
                    {
                        ["class"] = "TrophyFishButterflyfishData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2494,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["weight"] = 0.0,
                        ["playerName"] = "",
                        ["playerID"] = "",
                        ["caughtTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["lastUpdateTimeTicks"] = DateTime.UnixEpoch.Ticks
                    };


                case 2495:
                    return new BSONObject()
                    {
                        ["class"] = "TrophyFishGoldfishData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2495,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["weight"] = 0.0,
                        ["playerName"] = "",
                        ["playerID"] = "",
                        ["caughtTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["lastUpdateTimeTicks"] = DateTime.UnixEpoch.Ticks
                    };


                case 2496:
                    return new BSONObject()
                    {
                        ["class"] = "TrophyFishCarpData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2496,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["weight"] = 0.0,
                        ["playerName"] = "",
                        ["playerID"] = "",
                        ["caughtTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["lastUpdateTimeTicks"] = DateTime.UnixEpoch.Ticks
                    };


                case 2497:
                    return new BSONObject()
                    {
                        ["class"] = "TrophyFishHalibutData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2497,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["weight"] = 0.0,
                        ["playerName"] = "",
                        ["playerID"] = "",
                        ["caughtTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["lastUpdateTimeTicks"] = DateTime.UnixEpoch.Ticks
                    };


                case 2498:
                    return new BSONObject()
                    {
                        ["class"] = "TrophyFishSeaAnglerData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2498,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["weight"] = 0.0,
                        ["playerName"] = "",
                        ["playerID"] = "",
                        ["caughtTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["lastUpdateTimeTicks"] = DateTime.UnixEpoch.Ticks
                    };


                case 2499:
                    return new BSONObject()
                    {
                        ["class"] = "TrophyFishTunaData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2499,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["weight"] = 0.0,
                        ["playerName"] = "",
                        ["playerID"] = "",
                        ["caughtTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["lastUpdateTimeTicks"] = DateTime.UnixEpoch.Ticks
                    };


                case 2500:
                    return new BSONObject()
                    {
                        ["class"] = "TrophyFishingTournamentFirstData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2500,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["winnerName"] = "",
                        ["awardedTicks"] = DateTime.UnixEpoch.Ticks
                    };


                case 2501:
                    return new BSONObject()
                    {
                        ["class"] = "TrophyFishingTournamentSecondData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2501,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["winnerName"] = "",
                        ["awardedTicks"] = DateTime.UnixEpoch.Ticks
                    };


                case 2502:
                    return new BSONObject()
                    {
                        ["class"] = "TrophyFishingTournamentThirdData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2502,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["winnerName"] = "",
                        ["awardedTicks"] = DateTime.UnixEpoch.Ticks
                    };


                case 2611:
                    return new BSONObject()
                    {
                        ["class"] = "RedCandleData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2611,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2612:
                    return new BSONObject()
                    {
                        ["class"] = "DungeonDoorWhiteData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2612,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isLocked"] = true
                    };


                case 2616:
                    return new BSONObject()
                    {
                        ["class"] = "TrophyFishingTournamentFirstBabyData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2616,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["winnerName"] = "",
                        ["awardedTicks"] = DateTime.UnixEpoch.Ticks
                    };


                case 2617:
                    return new BSONObject()
                    {
                        ["class"] = "TrophyFishingTournamentSecondBabyData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2617,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["winnerName"] = "",
                        ["awardedTicks"] = DateTime.UnixEpoch.Ticks
                    };


                case 2618:
                    return new BSONObject()
                    {
                        ["class"] = "TrophyFishingTournamentThirdBabyData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2618,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["winnerName"] = "",
                        ["awardedTicks"] = DateTime.UnixEpoch.Ticks
                    };


                case 2619:
                    return new BSONObject()
                    {
                        ["class"] = "TrophyFishingTournamentFirstFishermanData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2619,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["winnerName"] = "",
                        ["awardedTicks"] = DateTime.UnixEpoch.Ticks
                    };


                case 2620:
                    return new BSONObject()
                    {
                        ["class"] = "TrophyFishingTournamentSecondFishermanData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2620,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["winnerName"] = "",
                        ["awardedTicks"] = DateTime.UnixEpoch.Ticks
                    };


                case 2621:
                    return new BSONObject()
                    {
                        ["class"] = "TrophyFishingTournamentThirdFishermanData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2621,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["winnerName"] = "",
                        ["awardedTicks"] = DateTime.UnixEpoch.Ticks
                    };


                case 2623:
                    return new BSONObject()
                    {
                        ["class"] = "AnniversaryRadioData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2623,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isOn"] = true,
                        ["frequency"] = 0
                    };


                case 2681:
                    return new BSONObject()
                    {
                        ["class"] = "HeartTrapData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2681,
                        ["animOn"] = true,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["trapFrequencyType"] = 2,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 2682:
                    return new BSONObject()
                    {
                        ["class"] = "BaroqueBedData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2682,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 2683:
                    return new BSONObject()
                    {
                        ["class"] = "CandySpikesData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2683,
                        ["animOn"] = false,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2693:
                    return new BSONObject()
                    {
                        ["class"] = "HeartSignData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2693,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["text"] = ""
                    };


                case 2736:
                    return new BSONObject()
                    {
                        ["class"] = "CelticColumnData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2736,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2766:
                    return new BSONObject()
                    {
                        ["class"] = "TutorialSleepPodData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2766,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["targetWorldID"] = "",
                        ["targetEntryPointID"] = "",
                        ["name"] = "",
                        ["entryPointID"] = "",
                        ["isLocked"] = false
                    };


                case 2904:
                    return new BSONObject()
                    {
                        ["class"] = "TutorialCablePortalData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2904,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["targetWorldID"] = "",
                        ["targetEntryPointID"] = "",
                        ["name"] = "",
                        ["entryPointID"] = "",
                        ["isLocked"] = false
                    };


                case 2988:
                    return new BSONObject()
                    {
                        ["class"] = "StalactitesBrownData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2988,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2989:
                    return new BSONObject()
                    {
                        ["class"] = "StalactitesGreyData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2989,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2990:
                    return new BSONObject()
                    {
                        ["class"] = "StalagmitesBrownData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2990,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2991:
                    return new BSONObject()
                    {
                        ["class"] = "StalagmitesGreyData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2991,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2992:
                    return new BSONObject()
                    {
                        ["class"] = "RiftPortalData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2992,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["targetWorldID"] = "",
                        ["targetEntryPointID"] = "",
                        ["name"] = "",
                        ["entryPointID"] = "",
                        ["isLocked"] = false,
                        ["users"] = new BSONArray(),
                        ["maxUsers"] = 3
                    };


                case 2998:
                    return new BSONObject()
                    {
                        ["class"] = "AlienMushroomData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2998,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 2999:
                    return new BSONObject()
                    {
                        ["class"] = "AlienPoisonPlantData",
                        ["itemId"] = itemId,
                        ["blockType"] = 2999,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["trapFrequencyType"] = 1,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 3002:
                    return new BSONObject()
                    {
                        ["class"] = "AlienBlockRuins1Data",
                        ["itemId"] = itemId,
                        ["blockType"] = 3002,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3003:
                    return new BSONObject()
                    {
                        ["class"] = "AlienBlockRuins2Data",
                        ["itemId"] = itemId,
                        ["blockType"] = 3003,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3004:
                    return new BSONObject()
                    {
                        ["class"] = "AlienPillarRuinsData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3004,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3005:
                    return new BSONObject()
                    {
                        ["class"] = "AlienSlimeData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3005,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3007:
                    return new BSONObject()
                    {
                        ["class"] = "AlienTentacleTrapData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3007,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["trapFrequencyType"] = 1,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 3008:
                    return new BSONObject()
                    {
                        ["class"] = "AlienTreeData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3008,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3009:
                    return new BSONObject()
                    {
                        ["class"] = "AlienArrowSignData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3009,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3030:
                    return new BSONObject()
                    {
                        ["class"] = "AlienChairData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3030,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 3031:
                    return new BSONObject()
                    {
                        ["class"] = "AlienChestData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3031,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["storageItemsAsInventoryKeys"] = new BSONArray(),
                        ["storageItemsAmounts"] = new BSONArray(),
                        ["maxStorageItems"] = 4,
                        ["inventoryDatas"] = new BSONObject()
                        {
                            ["DatasCount"] = 0
                        }
                    };


                case 3037:
                    return new BSONObject()
                    {
                        ["class"] = "AlienLightGreenData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3037,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3038:
                    return new BSONObject()
                    {
                        ["class"] = "AlienLightPurpleData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3038,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3039:
                    return new BSONObject()
                    {
                        ["class"] = "AlienHangingLightGreenData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3039,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3040:
                    return new BSONObject()
                    {
                        ["class"] = "AlienHangingLightPurpleData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3040,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3042:
                    return new BSONObject()
                    {
                        ["class"] = "AlienLaserTrapData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3042,
                        ["animOn"] = true,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["trapFrequencyType"] = 3,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 3044:
                    return new BSONObject()
                    {
                        ["class"] = "AlienMineData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3044,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3045:
                    return new BSONObject()
                    {
                        ["class"] = "AlienPipesData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3045,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3046:
                    return new BSONObject()
                    {
                        ["class"] = "AlienPlatformData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3046,
                        ["animOn"] = false,
                        ["direction"] = 1,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3047:
                    return new BSONObject()
                    {
                        ["class"] = "AlienPodBlueData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3047,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 3048:
                    return new BSONObject()
                    {
                        ["class"] = "AlienPodPurpleData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3048,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 3049:
                    return new BSONObject()
                    {
                        ["class"] = "AlienSignData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3049,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["text"] = ""
                    };


                case 3051:
                    return new BSONObject()
                    {
                        ["class"] = "AlienTurretData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3051,
                        ["animOn"] = true,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["trapFrequencyType"] = 0,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 3052:
                    return new BSONObject()
                    {
                        ["class"] = "AdTVData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3052,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["amount"] = 0
                    };


                case 3090:
                    return new BSONObject()
                    {
                        ["class"] = "MessagingComputerData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3090,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["text"] = ""
                    };


                case 3098:
                    return new BSONObject()
                    {
                        ["class"] = "WiringTriggerSwitchData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3098,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["canEveryoneUse"] = true
                    };


                case 3099:
                    return new BSONObject()
                    {
                        ["class"] = "WiringTriggerButtonData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3099,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["canEveryoneUse"] = true
                    };


                case 3100:
                    return new BSONObject()
                    {
                        ["class"] = "WiringTriggerLeverData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3100,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["canEveryoneUse"] = true
                    };


                case 3101:
                    return new BSONObject()
                    {
                        ["class"] = "WiringTriggerPressurePadData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3101,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["canEveryoneUse"] = true
                    };


                case 3102:
                    return new BSONObject()
                    {
                        ["class"] = "WiringTriggerProximitySensorData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3102,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["canEveryoneUse"] = true
                    };


                case 3110:
                    return new BSONObject()
                    {
                        ["class"] = "FireballTriggerTrapData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3110,
                        ["animOn"] = false,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["trapFrequencyType"] = 2,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 3111:
                    return new BSONObject()
                    {
                        ["class"] = "OnOffLightData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3111,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3112:
                    return new BSONObject()
                    {
                        ["class"] = "DisappearingBlockData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3112,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isOpen"] = false,
                        ["controlByFist"] = true
                    };


                case 3113:
                    return new BSONObject()
                    {
                        ["class"] = "WeatherMachineData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3113,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3125:
                    return new BSONObject()
                    {
                        ["class"] = "SoapBubbleMachineData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3125,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3126:
                    return new BSONObject()
                    {
                        ["class"] = "OuthouseData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3126,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 3127:
                    return new BSONObject()
                    {
                        ["class"] = "CampingTentData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3127,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 3128:
                    return new BSONObject()
                    {
                        ["class"] = "ColaFridgeData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3128,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["storageItemsAsInventoryKeys"] = new BSONArray(),
                        ["storageItemsAmounts"] = new BSONArray(),
                        ["maxStorageItems"] = 4,
                        ["inventoryDatas"] = new BSONObject()
                        {
                            ["DatasCount"] = 0
                        }
                    };


                case 3141:
                    return new BSONObject()
                    {
                        ["class"] = "FlameConstantTrapData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3141,
                        ["animOn"] = true,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = true,
                        ["trapFrequencyType"] = 2,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 3142:
                    return new BSONObject()
                    {
                        ["class"] = "SpikeTriggerTrapData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3142,
                        ["animOn"] = false,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["trapFrequencyType"] = 2,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 3147:
                    return new BSONObject()
                    {
                        ["class"] = "GreenRedLightData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3147,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3148:
                    return new BSONObject()
                    {
                        ["class"] = "WiringTriggerButtonScifiData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3148,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["canEveryoneUse"] = true
                    };


                case 3149:
                    return new BSONObject()
                    {
                        ["class"] = "WiringTriggerPushButtonData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3149,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["canEveryoneUse"] = true
                    };


                case 3150:
                    return new BSONObject()
                    {
                        ["class"] = "WiringTriggerGroundLeverWoodenData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3150,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["canEveryoneUse"] = true
                    };


                case 3151:
                    return new BSONObject()
                    {
                        ["class"] = "WiringTriggerSwitchScifiData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3151,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["canEveryoneUse"] = true
                    };


                case 3152:
                    return new BSONObject()
                    {
                        ["class"] = "WiringTriggerPowerSwitchData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3152,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["canEveryoneUse"] = true
                    };


                case 3153:
                    return new BSONObject()
                    {
                        ["class"] = "PoisonConstantTrapData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3153,
                        ["animOn"] = true,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = true,
                        ["trapFrequencyType"] = 2,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 3154:
                    return new BSONObject()
                    {
                        ["class"] = "TrafficLightBlockData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3154,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3156:
                    return new BSONObject()
                    {
                        ["class"] = "TrapdoorWiredData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3156,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isOpen"] = false,
                        ["controlByFist"] = true
                    };


                case 3157:
                    return new BSONObject()
                    {
                        ["class"] = "WarningLightData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3157,
                        ["animOn"] = true,
                        ["direction"] = 5,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3158:
                    return new BSONObject()
                    {
                        ["class"] = "PalmTreeData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3158,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3168:
                    return new BSONObject()
                    {
                        ["class"] = "WiringTriggerButtonStoneData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3168,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["canEveryoneUse"] = true
                    };


                case 3196:
                    return new BSONObject()
                    {
                        ["class"] = "ShipGunPortData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3196,
                        ["animOn"] = false,
                        ["direction"] = 5,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3201:
                    return new BSONObject()
                    {
                        ["class"] = "CannonBallsData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3201,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3206:
                    return new BSONObject()
                    {
                        ["class"] = "GunnyBagsData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3206,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3207:
                    return new BSONObject()
                    {
                        ["class"] = "LongDinnerTableData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3207,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3208:
                    return new BSONObject()
                    {
                        ["class"] = "OilLanternData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3208,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3210:
                    return new BSONObject()
                    {
                        ["class"] = "PirateCannonData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3210,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["trapFrequencyType"] = 2,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 3212:
                    return new BSONObject()
                    {
                        ["class"] = "RatlinesData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3212,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3213:
                    return new BSONObject()
                    {
                        ["class"] = "RopeFenceData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3213,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3215:
                    return new BSONObject()
                    {
                        ["class"] = "ShipBoomData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3215,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3216:
                    return new BSONObject()
                    {
                        ["class"] = "ShipCabinSupportData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3216,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3217:
                    return new BSONObject()
                    {
                        ["class"] = "ShipMastData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3217,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3218:
                    return new BSONObject()
                    {
                        ["class"] = "ShipPlatformData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3218,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3219:
                    return new BSONObject()
                    {
                        ["class"] = "ShipRopeData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3219,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3220:
                    return new BSONObject()
                    {
                        ["class"] = "ShipWheelData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3220,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3222:
                    return new BSONObject()
                    {
                        ["class"] = "GreenParrotData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3222,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["text"] = new BSONArray(),
                        ["maxMessages"] = 5
                    };


                case 3223:
                    return new BSONObject()
                    {
                        ["class"] = "TortureCageData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3223,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3224:
                    return new BSONObject()
                    {
                        ["class"] = "WoodenBucketData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3224,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3226:
                    return new BSONObject()
                    {
                        ["class"] = "WoodenPierData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3226,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3227:
                    return new BSONObject()
                    {
                        ["class"] = "WoodenStoolData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3227,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 3303:
                    return new BSONObject()
                    {
                        ["class"] = "ArmchairWhiteData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3303,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 3304:
                    return new BSONObject()
                    {
                        ["class"] = "BathtubGoldenData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3304,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 3305:
                    return new BSONObject()
                    {
                        ["class"] = "BedBlackData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3305,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 3308:
                    return new BSONObject()
                    {
                        ["class"] = "FireplaceGothicData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3308,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3309:
                    return new BSONObject()
                    {
                        ["class"] = "LanternBlueData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3309,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3310:
                    return new BSONObject()
                    {
                        ["class"] = "LanternRedData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3310,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3311:
                    return new BSONObject()
                    {
                        ["class"] = "LanternGreenData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3311,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3315:
                    return new BSONObject()
                    {
                        ["class"] = "PunchingBagData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3315,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3316:
                    return new BSONObject()
                    {
                        ["class"] = "RockPillarData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3316,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3318:
                    return new BSONObject()
                    {
                        ["class"] = "SofaBrownData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3318,
                        ["animOn"] = false,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 3329:
                    return new BSONObject()
                    {
                        ["class"] = "WallShelfWoodenData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3329,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3330:
                    return new BSONObject()
                    {
                        ["class"] = "WashingMachineData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3330,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3359:
                    return new BSONObject()
                    {
                        ["class"] = "TrophyFishAcidPufferData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3359,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["weight"] = 0.0,
                        ["playerName"] = "",
                        ["playerID"] = "",
                        ["caughtTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["lastUpdateTimeTicks"] = DateTime.UnixEpoch.Ticks
                    };


                case 3360:
                    return new BSONObject()
                    {
                        ["class"] = "TrophyFishDumbFishData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3360,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["weight"] = 0.0,
                        ["playerName"] = "",
                        ["playerID"] = "",
                        ["caughtTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["lastUpdateTimeTicks"] = DateTime.UnixEpoch.Ticks
                    };


                case 3437:
                    return new BSONObject()
                    {
                        ["class"] = "ColorOMatData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3437,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["itemBeingCraftedAsBlockType"] = 0,
                        ["itemCount"] = 0,
                        ["craftingStartTimeInTicks"] = DateTime.UtcNow
                    };


                case 3438:
                    return new BSONObject()
                    {
                        ["class"] = "PortalPasswordData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3438,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["targetWorldID"] = "",
                        ["targetEntryPointID"] = "",
                        ["name"] = "",
                        ["entryPointID"] = "",
                        ["isLocked"] = false,
                        ["hasPassword"] = false
                    };


                case 3466:
                    return new BSONObject()
                    {
                        ["class"] = "ClanTotemData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3466,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["level"] = 1
                    };


                case 3498:
                    return new BSONObject()
                    {
                        ["class"] = "HalloweenCannonData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3498,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["trapFrequencyType"] = 2,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 3500:
                    return new BSONObject()
                    {
                        ["class"] = "ClanQuestBotData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3500,
                        ["animOn"] = true,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3559:
                    return new BSONObject()
                    {
                        ["class"] = "DoorClanData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3559,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3596:
                    return new BSONObject()
                    {
                        ["class"] = "LockBattleFactionData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3596,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["playerWhoOwnsLockId"] = "",
                        ["playerWhoOwnsLockName"] = "",
                        ["playersWhoHaveAccessToLock"] = new BSONArray(),
                        ["playersWhoHaveMinorAccessToLock"] = new BSONArray(),
                        ["isOpen"] = false,
                        ["ignoreEmptyArea"] = false,
                        ["lockMapPoints"] = new List<Vector2i>(),
                        ["creationTime"] = DateTime.UtcNow,
                        ["lastActivatedTime"] = DateTime.UtcNow,
                        ["isBattleOn"] = false
                    };


                case 3597:
                    return new BSONObject()
                    {
                        ["class"] = "BattleScoreBoardFactionData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3597,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3598:
                    return new BSONObject()
                    {
                        ["class"] = "CheckPointFactionDarkData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3598,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false
                    };


                case 3599:
                    return new BSONObject()
                    {
                        ["class"] = "CheckPointFactionLightData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3599,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false
                    };


                case 3600:
                    return new BSONObject()
                    {
                        ["class"] = "PortalFactionDarkData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3600,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["targetWorldID"] = "",
                        ["targetEntryPointID"] = "",
                        ["name"] = "",
                        ["entryPointID"] = "",
                        ["isLocked"] = false,
                        ["password"] = ""
                    };


                case 3601:
                    return new BSONObject()
                    {
                        ["class"] = "PortalFactionLightData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3601,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["targetWorldID"] = "",
                        ["targetEntryPointID"] = "",
                        ["name"] = "",
                        ["entryPointID"] = "",
                        ["isLocked"] = false,
                        ["password"] = ""
                    };


                case 3602:
                    return new BSONObject()
                    {
                        ["class"] = "DoorFactionDarkData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3602,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isLocked"] = true
                    };


                case 3603:
                    return new BSONObject()
                    {
                        ["class"] = "DoorFactionLightData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3603,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isLocked"] = true
                    };


                case 3604:
                    return new BSONObject()
                    {
                        ["class"] = "DonationBoxData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3604,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["itemsAsInventoryKeys"] = new BSONArray(),
                        ["itemsAmounts"] = new BSONArray(),
                        ["inventoryDatas"] = new BSONObject()
                        {
                            ["DatasCount"] = 0
                        },
                        ["playerIds"] = new BSONArray(),
                        ["minRarity"] = 0,
                        ["maxItems"] = 20
                    };


                case 3605:
                    return new BSONObject()
                    {
                        ["class"] = "GuestBookData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3605,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["playerIds"] = new BSONArray(),
                        ["messages"] = new BSONArray(),
                        ["timestamps"] = new BSONArray(),
                        ["approved"] = new BSONArray(),
                        ["maxEntries"] = 20,
                        ["locked"] = false
                    };


                case 3606:
                    return new BSONObject()
                    {
                        ["class"] = "LockWorldBattleFactionData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3606,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["playerWhoOwnsLockId"] = p.ClientID,
                        ["playerWhoOwnsLockName"] = p.Data.Name,
                        ["playersWhoHaveAccessToLock"] = new List<string>(),
                        ["playersWhoHaveMinorAccessToLock"] = new List<string>(),
                        ["isOpen"] = false,
                        ["punchingAllowed"] = true,
                        ["creationTime"] = DateTime.UtcNow,
                        ["lastActivatedTime"] = DateTime.UtcNow,
                        ["isBattleOn"] = false
                    };


                case 3610:
                    return new BSONObject()
                    {
                        ["class"] = "AnniversaryJukeboxData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3610,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3611:
                    return new BSONObject()
                    {
                        ["class"] = "PaperLanternData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3611,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3628:
                    return new BSONObject()
                    {
                        ["class"] = "WiringTriggerPressurePadSecretData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3628,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["canEveryoneUse"] = true
                    };


                case 3629:
                    return new BSONObject()
                    {
                        ["class"] = "DisappearingBlockSecret01Data",
                        ["itemId"] = itemId,
                        ["blockType"] = 3629,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isOpen"] = false,
                        ["controlByFist"] = true
                    };


                case 3630:
                    return new BSONObject()
                    {
                        ["class"] = "DisappearingBlockSecret02Data",
                        ["itemId"] = itemId,
                        ["blockType"] = 3630,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isOpen"] = false,
                        ["controlByFist"] = true
                    };


                case 3631:
                    return new BSONObject()
                    {
                        ["class"] = "DisappearingBlockSecret03Data",
                        ["itemId"] = itemId,
                        ["blockType"] = 3631,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isOpen"] = false,
                        ["controlByFist"] = true
                    };


                case 3632:
                    return new BSONObject()
                    {
                        ["class"] = "DarknessFactionLightData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3632,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3633:
                    return new BSONObject()
                    {
                        ["class"] = "LightFactionLightData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3633,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3634:
                    return new BSONObject()
                    {
                        ["class"] = "TimeFactionLightData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3634,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3635:
                    return new BSONObject()
                    {
                        ["class"] = "PowerLiftData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3635,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3636:
                    return new BSONObject()
                    {
                        ["class"] = "TeslaSphereConstantData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3636,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = true,
                        ["trapFrequencyType"] = 3,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 3639:
                    return new BSONObject()
                    {
                        ["class"] = "DonationBoxValentinesData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3639,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["itemsAsInventoryKeys"] = new BSONArray(),
                        ["itemsAmounts"] = new BSONArray(),
                        ["inventoryDatas"] = new BSONObject()
                        {
                            ["DatasCount"] = 0
                        },
                        ["playerIds"] = new BSONArray(),
                        ["minRarity"] = 0,
                        ["maxItems"] = 20
                    };


                case 3647:
                    return new BSONObject()
                    {
                        ["class"] = "SofaRedData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3647,
                        ["animOn"] = false,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 3648:
                    return new BSONObject()
                    {
                        ["class"] = "CottonCandyPlatformData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3648,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3651:
                    return new BSONObject()
                    {
                        ["class"] = "HeartLampData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3651,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3677:
                    return new BSONObject()
                    {
                        ["class"] = "LoreBotData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3677,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["text"] = new BSONArray(),
                        ["maxMessages"] = 5
                    };


                case 3678:
                    return new BSONObject()
                    {
                        ["class"] = "LoreSignData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3678,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["text"] = ""
                    };


                case 3686:
                    return new BSONObject()
                    {
                        ["class"] = "TrophyFishPiranhaData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3686,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["weight"] = 0.0,
                        ["playerName"] = "",
                        ["playerID"] = "",
                        ["caughtTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["lastUpdateTimeTicks"] = DateTime.UnixEpoch.Ticks
                    };


                case 3769:
                    return new BSONObject()
                    {
                        ["class"] = "PetDogData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3769,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["ownerPlayerID"] = "",
                        ["name"] = "",
                        ["dateOfBirthTicks"] = DateTime.UnixEpoch.Ticks,
                        ["gender"] = 0,
                        ["baseColor"] = 0,
                        ["section1Color"] = 0,
                        ["section2Color"] = 0,
                        ["section3Color"] = 0,
                        ["section4Color"] = 0,
                        ["section5Color"] = 0,
                        ["offsetLastMapPointXFromHome"] = 0,
                        ["interactionTrainCounter"] = 0,
                        ["adventureRandomizePrizeSeed"] = -1,
                        ["totalAdventurePrizesCount"] = 0,
                        ["happinessWhenAdventureStarted"] = 0.0,
                        ["obedienceWhenAdventureStarted"] = 0.0,
                        ["experienceAmount"] = 0.0,
                        ["health"] = 80.0,
                        ["hunger"] = 55.0,
                        ["happiness"] = 55.0,
                        ["hygiene"] = 55.0,
                        ["obedience"] = 50.0,
                        ["lastInteractionPetDateTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["lastInteractionTrainDateTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["lastStatsUpdatedDateTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["sicknessStartDateTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["freezeStartDateTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["freezeEndDateTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["adventureStartDateTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["adventureCooldownStartDateTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["totalAdventureDateTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["isAtAdventure"] = false
                    };


                case 3815:
                    return new BSONObject()
                    {
                        ["class"] = "PetCatData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3815,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["ownerPlayerID"] = "",
                        ["name"] = "",
                        ["dateOfBirthTicks"] = DateTime.UnixEpoch.Ticks,
                        ["gender"] = 0,
                        ["baseColor"] = 0,
                        ["section1Color"] = 0,
                        ["section2Color"] = 0,
                        ["section3Color"] = 0,
                        ["section4Color"] = 0,
                        ["section5Color"] = 0,
                        ["offsetLastMapPointXFromHome"] = 0,
                        ["interactionTrainCounter"] = 0,
                        ["adventureRandomizePrizeSeed"] = -1,
                        ["totalAdventurePrizesCount"] = 0,
                        ["happinessWhenAdventureStarted"] = 0.0,
                        ["obedienceWhenAdventureStarted"] = 0.0,
                        ["experienceAmount"] = 0.0,
                        ["health"] = 80.0,
                        ["hunger"] = 55.0,
                        ["happiness"] = 55.0,
                        ["hygiene"] = 55.0,
                        ["obedience"] = 50.0,
                        ["lastInteractionPetDateTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["lastInteractionTrainDateTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["lastStatsUpdatedDateTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["sicknessStartDateTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["freezeStartDateTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["freezeEndDateTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["adventureStartDateTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["adventureCooldownStartDateTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["totalAdventureDateTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["isAtAdventure"] = false
                    };


                case 3816:
                    return new BSONObject()
                    {
                        ["class"] = "PetSlimeData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3816,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["ownerPlayerID"] = "",
                        ["name"] = "",
                        ["dateOfBirthTicks"] = DateTime.UnixEpoch.Ticks,
                        ["gender"] = 0,
                        ["baseColor"] = 0,
                        ["section1Color"] = 0,
                        ["section2Color"] = 0,
                        ["section3Color"] = 0,
                        ["section4Color"] = 0,
                        ["section5Color"] = 0,
                        ["offsetLastMapPointXFromHome"] = 0,
                        ["interactionTrainCounter"] = 0,
                        ["adventureRandomizePrizeSeed"] = -1,
                        ["totalAdventurePrizesCount"] = 0,
                        ["happinessWhenAdventureStarted"] = 0.0,
                        ["obedienceWhenAdventureStarted"] = 0.0,
                        ["experienceAmount"] = 0.0,
                        ["health"] = 80.0,
                        ["hunger"] = 55.0,
                        ["happiness"] = 55.0,
                        ["hygiene"] = 55.0,
                        ["obedience"] = 50.0,
                        ["lastInteractionPetDateTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["lastInteractionTrainDateTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["lastStatsUpdatedDateTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["sicknessStartDateTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["freezeStartDateTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["freezeEndDateTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["adventureStartDateTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["adventureCooldownStartDateTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["totalAdventureDateTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["isAtAdventure"] = false
                    };


                case 3883:
                    return new BSONObject()
                    {
                        ["class"] = "WiringTriggerPressurePadCustomData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3883,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["canEveryoneUse"] = true,
                        ["conditions1"] = new BSONArray(),
                        ["conditions2"] = new BSONArray(),
                        ["conditions3"] = new BSONArray()
                    };


                case 3884:
                    return new BSONObject()
                    {
                        ["class"] = "CeilingLampLightData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3884,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3885:
                    return new BSONObject()
                    {
                        ["class"] = "CeilingLampDarkData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3885,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3886:
                    return new BSONObject()
                    {
                        ["class"] = "WiringTriggerPuzzleLoreLightData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3886,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["canEveryoneUse"] = true,
                        ["correctState"] = 0,
                        ["maxStates"] = 6
                    };


                case 3887:
                    return new BSONObject()
                    {
                        ["class"] = "WiringTriggerPuzzleLoreDarkData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3887,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["canEveryoneUse"] = true,
                        ["correctState"] = 0,
                        ["maxStates"] = 6
                    };


                case 3949:
                    return new BSONObject()
                    {
                        ["class"] = "TemplePillarData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3949,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3950:
                    return new BSONObject()
                    {
                        ["class"] = "TempleRocksData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3950,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3951:
                    return new BSONObject()
                    {
                        ["class"] = "TempleWoodenPlatformData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3951,
                        ["animOn"] = false,
                        ["direction"] = 1,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3952:
                    return new BSONObject()
                    {
                        ["class"] = "TempleStonePlatformData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3952,
                        ["animOn"] = false,
                        ["direction"] = 1,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3953:
                    return new BSONObject()
                    {
                        ["class"] = "TempleStoneTableData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3953,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3954:
                    return new BSONObject()
                    {
                        ["class"] = "TempleBenchData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3954,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 3956:
                    return new BSONObject()
                    {
                        ["class"] = "TempleBrazierData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3956,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3957:
                    return new BSONObject()
                    {
                        ["class"] = "TempleHangingBrazierData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3957,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3958:
                    return new BSONObject()
                    {
                        ["class"] = "TempleRoofLeftData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3958,
                        ["animOn"] = false,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3959:
                    return new BSONObject()
                    {
                        ["class"] = "TempleRoofRightData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3959,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3960:
                    return new BSONObject()
                    {
                        ["class"] = "IvyPlantData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3960,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3962:
                    return new BSONObject()
                    {
                        ["class"] = "SoapBubbleMachineFrogData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3962,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 3964:
                    return new BSONObject()
                    {
                        ["class"] = "PortalCrypticData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3964,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["targetWorldID"] = "",
                        ["targetEntryPointID"] = "",
                        ["name"] = "",
                        ["entryPointID"] = "",
                        ["isLocked"] = false,
                        ["isActivated"] = false,
                        ["startTimeInTicks"] = DateTime.UtcNow,
                        ["useCount"] = 0,
                        ["timesActivated"] = 0
                    };


                case 3965:
                    return new BSONObject()
                    {
                        ["class"] = "PortalPixelMinesData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3965,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["targetWorldID"] = "",
                        ["targetEntryPointID"] = "",
                        ["name"] = "",
                        ["entryPointID"] = "",
                        ["isLocked"] = false,
                        ["password"] = ""
                    };


                case 3966:
                    return new BSONObject()
                    {
                        ["class"] = "PortalMineExitData",
                        ["itemId"] = itemId,
                        ["blockType"] = 3966,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["targetWorldID"] = "",
                        ["targetEntryPointID"] = "",
                        ["name"] = "",
                        ["entryPointID"] = "",
                        ["isLocked"] = false,
                        ["password"] = ""
                    };


                case 4103:
                    return new BSONObject()
                    {
                        ["class"] = "PortalMiningEntryData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4103,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["targetWorldID"] = "",
                        ["targetEntryPointID"] = "",
                        ["name"] = "",
                        ["entryPointID"] = "",
                        ["isLocked"] = false,
                        ["password"] = ""
                    };


                case 4143:
                    return new BSONObject()
                    {
                        ["class"] = "MiningStalactitesTopData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4143,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4144:
                    return new BSONObject()
                    {
                        ["class"] = "MiningStalactitesBottomData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4144,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4151:
                    return new BSONObject()
                    {
                        ["class"] = "MiningBatData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4151,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4152:
                    return new BSONObject()
                    {
                        ["class"] = "MiningSpiderData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4152,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4153:
                    return new BSONObject()
                    {
                        ["class"] = "MiningTorchData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4153,
                        ["animOn"] = true,
                        ["direction"] = 1,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isFlameOn"] = false
                    };


                case 4250:
                    return new BSONObject()
                    {
                        ["class"] = "JetRaceAwardGate1Data",
                        ["itemId"] = itemId,
                        ["blockType"] = 4250,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4251:
                    return new BSONObject()
                    {
                        ["class"] = "JetRaceAwardGate2Data",
                        ["itemId"] = itemId,
                        ["blockType"] = 4251,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4252:
                    return new BSONObject()
                    {
                        ["class"] = "JetRaceAwardGate3Data",
                        ["itemId"] = itemId,
                        ["blockType"] = 4252,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4253:
                    return new BSONObject()
                    {
                        ["class"] = "JetRaceDoorData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4253,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4257:
                    return new BSONObject()
                    {
                        ["class"] = "JetRacePinballBumperData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4257,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4258:
                    return new BSONObject()
                    {
                        ["class"] = "JetRaceDoorEdgeData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4258,
                        ["animOn"] = false,
                        ["direction"] = 5,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4259:
                    return new BSONObject()
                    {
                        ["class"] = "JetRaceSquarePillarData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4259,
                        ["animOn"] = false,
                        ["direction"] = 5,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4260:
                    return new BSONObject()
                    {
                        ["class"] = "JetRacePipeData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4260,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4261:
                    return new BSONObject()
                    {
                        ["class"] = "JetRaceSpeedBoostData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4261,
                        ["animOn"] = true,
                        ["direction"] = 3,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4276:
                    return new BSONObject()
                    {
                        ["class"] = "TorchUnholyData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4276,
                        ["animOn"] = true,
                        ["direction"] = 1,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isFlameOn"] = false
                    };


                case 4277:
                    return new BSONObject()
                    {
                        ["class"] = "HelloBotSkeletonData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4277,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["text"] = new BSONArray(),
                        ["maxMessages"] = 5
                    };


                case 4285:
                    return new BSONObject()
                    {
                        ["class"] = "JetRaceElectricWireLargeData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4285,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4286:
                    return new BSONObject()
                    {
                        ["class"] = "JetRaceForcefieldStartData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4286,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isOpen"] = false,
                        ["controlByFist"] = true
                    };


                case 4287:
                    return new BSONObject()
                    {
                        ["class"] = "JetRaceElectricConstantTrapData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4287,
                        ["animOn"] = true,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = true,
                        ["trapFrequencyType"] = 2,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 4288:
                    return new BSONObject()
                    {
                        ["class"] = "JetRaceTrampolineData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4288,
                        ["animOn"] = false,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4367:
                    return new BSONObject()
                    {
                        ["class"] = "RuleBotMountData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4367,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isFlyingMountAllowed"] = false,
                        ["isTemporaryMountOn"] = false
                    };


                case 4373:
                    return new BSONObject()
                    {
                        ["class"] = "JetRaceGroupPortalData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4373,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["targetWorldID"] = "JETRACE",
                        ["targetEntryPointID"] = "",
                        ["name"] = "JetRace",
                        ["entryPointID"] = "",
                        ["isLocked"] = false,
                        ["password"] = "",
                        ["isActivated"] = false,
                        ["jetRaceWorldID"] = "",
                        ["idNumber"] = 0,
                        ["startTimeInTicks"] = DateTime.UtcNow,
                        ["useCount"] = 0
                    };


                case 4423:
                    return new BSONObject()
                    {
                        ["class"] = "JetRaceCyanDoorEdgeData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4423,
                        ["animOn"] = false,
                        ["direction"] = 5,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4424:
                    return new BSONObject()
                    {
                        ["class"] = "JetRaceCyanSquarePillarData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4424,
                        ["animOn"] = false,
                        ["direction"] = 5,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4437:
                    return new BSONObject()
                    {
                        ["class"] = "SnowDriftData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4437,
                        ["animOn"] = false,
                        ["direction"] = 5,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4457:
                    return new BSONObject()
                    {
                        ["class"] = "FrostTrapData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4457,
                        ["animOn"] = true,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["trapFrequencyType"] = 2,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 4458:
                    return new BSONObject()
                    {
                        ["class"] = "FrostConstantTrapData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4458,
                        ["animOn"] = true,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = true,
                        ["trapFrequencyType"] = 2,
                        ["activatedTicks"] = DateTime.UnixEpoch.Ticks,
                        ["trapSyncIndex"] = 0
                    };


                case 4460:
                    return new BSONObject()
                    {
                        ["class"] = "HangingLeavesSilverData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4460,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4463:
                    return new BSONObject()
                    {
                        ["class"] = "SnowPillarData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4463,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4464:
                    return new BSONObject()
                    {
                        ["class"] = "SpikesIceData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4464,
                        ["animOn"] = false,
                        ["direction"] = 2,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4470:
                    return new BSONObject()
                    {
                        ["class"] = "TorchBlueData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4470,
                        ["animOn"] = true,
                        ["direction"] = 1,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isFlameOn"] = false
                    };


                case 4475:
                    return new BSONObject()
                    {
                        ["class"] = "GuestBookAnniversaryData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4475,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["playerIds"] = new BSONArray(),
                        ["messages"] = new BSONArray(),
                        ["timestamps"] = new BSONArray(),
                        ["approved"] = new BSONArray(),
                        ["maxEntries"] = 20,
                        ["locked"] = false
                    };


                case 4476:
                    return new BSONObject()
                    {
                        ["class"] = "LoreBotLeftData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4476,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["text"] = new BSONArray(),
                        ["maxMessages"] = 5
                    };


                case 4503:
                    return new BSONObject()
                    {
                        ["class"] = "BestSetTrophyData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4503,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["winnerName"] = "",
                        ["awardedTicks"] = DateTime.UnixEpoch.Ticks
                    };


                case 4536:
                    return new BSONObject()
                    {
                        ["class"] = "BounceBlobGreenData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4536,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4537:
                    return new BSONObject()
                    {
                        ["class"] = "BounceBlobOrangeData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4537,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4538:
                    return new BSONObject()
                    {
                        ["class"] = "BounceBlobPurpleData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4538,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4546:
                    return new BSONObject()
                    {
                        ["class"] = "ForSaleSignData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4546,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["text"] = ""
                    };


                case 4548:
                    return new BSONObject()
                    {
                        ["class"] = "WoodenSignPlanksData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4548,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["text"] = ""
                    };


                case 4549:
                    return new BSONObject()
                    {
                        ["class"] = "RoadMarkerStoneData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4549,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["text"] = ""
                    };


                case 4551:
                    return new BSONObject()
                    {
                        ["class"] = "TrapdoorWoodenPlatformData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4551,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4573:
                    return new BSONObject()
                    {
                        ["class"] = "CandyWormData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4573,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4574:
                    return new BSONObject()
                    {
                        ["class"] = "LoveThroneData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4574,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 4584:
                    return new BSONObject()
                    {
                        ["class"] = "SignLocalizedData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4584,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["text"] = ""
                    };


                case 4592:
                    return new BSONObject()
                    {
                        ["class"] = "TrophyFishCrabData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4592,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["weight"] = 0.0,
                        ["playerName"] = "",
                        ["playerID"] = "",
                        ["caughtTimeTicks"] = DateTime.UnixEpoch.Ticks,
                        ["lastUpdateTimeTicks"] = DateTime.UnixEpoch.Ticks
                    };


                case 4615:
                    return new BSONObject()
                    {
                        ["class"] = "HotTubGoldenData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4615,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 4649:
                    return new BSONObject()
                    {
                        ["class"] = "SignSwitchableTextWoodenData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4649,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["canEveryoneUse"] = true,
                        ["textA"] = "",
                        ["textB"] = ""
                    };


                case 4699:
                    return new BSONObject()
                    {
                        ["class"] = "JetRaceAwardGateEasterData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4699,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4740:
                    return new BSONObject()
                    {
                        ["class"] = "AirTrampolineData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4740,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4741:
                    return new BSONObject()
                    {
                        ["class"] = "GiantSunflowerData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4741,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4742:
                    return new BSONObject()
                    {
                        ["class"] = "JetRaceAwardGateCard160Data",
                        ["itemId"] = itemId,
                        ["blockType"] = 4742,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4743:
                    return new BSONObject()
                    {
                        ["class"] = "JetRaceAwardGateCard160GoldData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4743,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4747:
                    return new BSONObject()
                    {
                        ["class"] = "SoapBubbleMachineSunData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4747,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4752:
                    return new BSONObject()
                    {
                        ["class"] = "CardSeasonsTrophyFirstData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4752,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["winnerName"] = "",
                        ["awardedTicks"] = DateTime.UnixEpoch.Ticks
                    };


                case 4753:
                    return new BSONObject()
                    {
                        ["class"] = "CardSeasonsTrophySecondData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4753,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["winnerName"] = "",
                        ["awardedTicks"] = DateTime.UnixEpoch.Ticks
                    };


                case 4754:
                    return new BSONObject()
                    {
                        ["class"] = "CardSeasonsTrophyThirdData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4754,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["winnerName"] = "",
                        ["awardedTicks"] = DateTime.UnixEpoch.Ticks
                    };


                case 4761:
                    return new BSONObject()
                    {
                        ["class"] = "TinyChestData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4761,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = true,
                        ["damageNow"] = false,
                        ["storageItemsAsInventoryKeys"] = new BSONArray(),
                        ["storageItemsAmounts"] = new BSONArray(),
                        ["maxStorageItems"] = 3,
                        ["inventoryDatas"] = new BSONObject()
                        {
                            ["DatasCount"] = 0
                        }
                    };


                case 4791:
                    return new BSONObject()
                    {
                        ["class"] = "JetRaceAwardGateHalloweenData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4791,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4793:
                    return new BSONObject()
                    {
                        ["class"] = "JetRaceAwardGateXmasData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4793,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4824:
                    return new BSONObject()
                    {
                        ["class"] = "WhoopeeCushionData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4824,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 4825:
                    return new BSONObject()
                    {
                        ["class"] = "TreeTopData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4825,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4826:
                    return new BSONObject()
                    {
                        ["class"] = "TreeTopSnowyData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4826,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4827:
                    return new BSONObject()
                    {
                        ["class"] = "TreeTopSilverData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4827,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4828:
                    return new BSONObject()
                    {
                        ["class"] = "TreeTrunkSnowyData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4828,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4829:
                    return new BSONObject()
                    {
                        ["class"] = "SewerPipeBronzeData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4829,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4838:
                    return new BSONObject()
                    {
                        ["class"] = "UnderwaterPillarData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4838,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };


                case 4863:
                    return new BSONObject()
                    {
                        ["class"] = "AnniversaryDisplayBlockData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4863,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["storageItemAsInventoryKey"] = 0,
                        ["text"] = ""
                    };


                case 4947:
                    return new BSONObject()
                    {
                        ["class"] = "LawnChairData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4947,
                        ["animOn"] = false,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false,
                        ["isClosed"] = false,
                        ["isPlayerIn"] = false,
                        ["playerId"] = ""
                    };


                case 4948:
                    return new BSONObject()
                    {
                        ["class"] = "SoapBubbleMachineCrabData",
                        ["itemId"] = itemId,
                        ["blockType"] = 4948,
                        ["animOn"] = true,
                        ["direction"] = 0,
                        ["anotherSprite"] = false,
                        ["damageNow"] = false
                    };
                default:
                    {
                        return null;
                    }

            }
        }

        public static bool DoesBlockNeedData(Player p, BlockType bt)
        {
            return SpawnBSON(p, (short)bt) != null;
        }

        public static bool ValidateWIB(BSONObject wib, Player p)
        {
            if (!wib.ContainsKey("blockType") || wib["blockType"].valueType != BSONValue.ValueType.Int32)
                return false;

            BSONObject def = SpawnBSON(p, wib["blockType"].int32Value);

            if (def == null)
                return false;

            foreach (string key in def.Keys)
            {
                if (!wib.ContainsKey(key))
                    return false;
            }

            return true;
        }

        public static bool ValidateWIB(BSONValue wib, Player p)
        {
            return ValidateWIB((BSONObject)wib, p);
        }

        public static void CopyBaseData(BSONObject from, BSONObject to)
        {
            to["class"] = from["class"];
            to["itemId"] = from["itemId"];
            to["blockType"] = from["blockType"];
            to["animOn"] = from["animOn"];
            to["direction"] = from["direction"];
            to["anotherSprite"] = from["anotherSprite"];
            to["damageNow"] = from["damageNow"];
        }

        public static int Pair(int x, int y)
        {
            return (int)(0.5 * (x + y) * (x + y + 1) + y);
        }

        public static Vector2i Unpair(int z)
        {
            double w = Math.Floor((Math.Sqrt(8 * z + 1) - 1) / 2);
            double t = (w * w + w) / 2;
            int y = (int)(z - t);
            int x = (int)(w - y);
            return new Vector2i(x, y);
        }
    }
}
