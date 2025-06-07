using System;
using System.Collections.Generic;
using System.Text;
using PWS.Networking.Server;
using System.IO;
using Kernys.Bson;
using PWS.DataManagement;
using System.Linq;
using static PWS.World.WorldInterface;
using System.Threading;
using System.Collections;
using System.Reflection.Emit;
using static System.Net.Mime.MediaTypeNames;
using MongoDB.Bson;
using static PWS.Constants.Enums;
using PWS.Structs;
using PWS.Constants;
using BasicTypes;
using Discord;
using PWS.World.Helpers;

namespace PWS.World
{
    public class WorldSession
    {
        private PWServer pServer = null;
        private byte version = 0x1;

        //players
        private List<Player> players = new List<Player>();
        public List<Player> Players => players;

        //collectables
        public Dictionary<int, Collectable> collectables = new Dictionary<int, Collectable>();

        public int colID = 0;
        public int wiID = 0;
        public uint WorldID = 0;
        public long creation = 0;
        public short SpawnPointX = 99, SpawnPointY = 44;
        public bool worldProcessing = false;
        public string WorldName = string.Empty;
        public WorldLayoutType worldLayoutType = WorldLayoutType.Basic;
        public LayerBackgroundType layerBackgroundType = LayerBackgroundType.ForestBackground;
        public WeatherType weatherType = WeatherType.None;
        public LightingType lightingType = LightingType.None;
        public GravityMode gravityMode = GravityMode.Normal;
        public int musicIndex = 0;
        public Helpers.WorldLockHelper wl;

        //tiles
        private WorldTile[,] tiles = null;
        public int GetSizeX() => tiles.GetUpperBound(0) + 1;
        public int GetSizeY() => tiles.GetUpperBound(1) + 1;

        //item data (Wib)
        public BSONObject[,] worldItemsData = new BSONObject[200, 90];
        public SeedData[,] plantedSeeds = new SeedData[200, 90];
        public void AddPlayer(Player p)
        {
            if (HasPlayer(p) == -1)
                players.Add(p);
            Save();
            p.world = this;
        }

        public int HasPlayer(Player p)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (p.Data.UserID == players[i].Data.UserID)
                    return i;
            }

            return -1;
        }
        public void RemovePlayer(Player p)
        {
            int idx = HasPlayer(p);

            if (idx >= 0)
                players.RemoveAt(idx);

            p.world = null;
        }

        public static bool doesWorldExist(string worldName)
        {
            string path = $"maps/{worldName}.map";
            return File.Exists(path);
        }


        public void RemoveCollectable(int colID, Player toIgnore = null)
        {
            collectables.Remove(colID);
            BSONObject bObj = new BSONObject("RC");
            bObj["CollectableID"] = colID;

            Broadcast(ref bObj, toIgnore);
        }

        public void Broadcast(ref BSONObject bObj, params Player[] ignored) // ignored player can be used to ignore packet being sent to player itself.
        {
            foreach (var p in players)
            {
                if (ignored.Contains(p))
                    continue;

                p.Send(ref bObj);
            }
        }

        public void visualDrop(Player player, InventoryKey ik, int amt, double posX, double posY, int gem = -1)
        {
            if ((int)ik.blockType < 1 && gem < 0) return;
            if (gem >= 0 && amt <= 0) return;

            int cId = ++colID;
            BSONObject cObj = new BSONObject("nCo");
            cObj["CollectableID"] = cId;
            cObj["BlockType"] = (int)ik.blockType;
            cObj["Amount"] = amt;
            cObj["InventoryType"] = (int)ik.itemType;

            Collectable c = new Collectable();
            c.amt = (short)amt;
            c.BlockType = ik.blockType;
            c.InventoryType = ik.itemType;
            c.posX = posX * Math.PI;
            c.posY = posY * Math.PI;
            c.gemType = (short)gem;

            cObj["PosX"] = c.posX;
            cObj["PosY"] = c.posY;
            cObj["IsGem"] = c.gemType > -1;
            cObj["GemType"] = c.gemType < 0 ? 0 : c.gemType;

            collectables[cId] = c;
            player.Send(ref cObj);
        }

        public void Drop(InventoryKey ik, int amt, double posX, double posY, int gem = -1)
        {
            if ((int)ik.blockType < 1 && gem < 0) return;
            if (gem >= 0 && amt <= 0) return;
            if (gem >= 0 && amt > 1) //recursion to spawn more collectable-gems
            {
                for (int re = 0; re < amt; re++)
                {
                    Drop(InventoryKey.GetNoneBlockKey(), 1, posX, posY, gem);
                }
            }

            int cId = ++colID;
            BSONObject cObj = new BSONObject("nCo");
            cObj["CollectableID"] = cId;
            cObj["BlockType"] = (int)ik.blockType;
            cObj["Amount"] = amt;
            cObj["InventoryType"] = (int)ik.itemType;

            Collectable c = new Collectable();
            c.amt = (short)amt;
            c.BlockType = ik.blockType;
            c.InventoryType = ik.itemType;
            c.posX = posX * Math.PI;
            c.posY = posY * Math.PI;
            c.gemType = (short)gem;

            cObj["PosX"] = c.posX;
            cObj["PosY"] = c.posY;
            cObj["IsGem"] = c.gemType > -1;
            cObj["GemType"] = c.gemType < 0 ? 0 : c.gemType;

            collectables[cId] = c;

            Broadcast(ref cObj);
        }


        public WorldSession(PWServer pServer, string worldName = "")
        {
            if (worldName == "")
                return;

            // load from SQL and File, if it doesn't exist, then generate.
            // first retrieve worldID, name, metadata... if fail, then generate world.
            this.pServer = pServer;
            string path = $"maps/{worldName}.map";

            if (!File.Exists(path))
            {
#if DEBUG
                Util.Log("Generating new world with name: " + worldName);
#endif
                // generate world
                Generate(worldName);
                return;
            }

            Util.Log("Attempting to load world from DB...");
            Deserialize(SimpleBSON.Load(Util.LZMAHelper.DecompressLZMA(File.ReadAllBytes(path))));
            this.WorldName = worldName;
        }

        public void Generate(string name)
        {
            // first, add new entry to sql:
            // todo filter the name from bad shit b4 release...
            SpawnPointX = 80;
            SpawnPointY = 44;
            WorldName = name;

            if (name == "MAIN" || name == "TEST" || name == "WORLD")
                SetupTerrain();
            else
            {
                SpawnPointX = 40;
                SpawnPointY = 30;
                SetupTerrain();
            }
        }

        public void Save()
        {
            string path = $"maps/{WorldName}.map";

            BSONObject bson = new BSONObject();
            bson = Serialize();

            byte[] buffer = Util.LZMAHelper.CompressLZMA(SimpleBSON.Dump(bson));
            using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                binaryWriter.Write(buffer);
            }
        }

        public void SetupTerrain(Player player = null)
        {
            try
            {
                worldProcessing = true;
                creation = Util.GetMs(); // For new worlds so players can see in chat the world is new.

                tiles = new WorldTile[80, 60]; // 80 floor/width, 60 = height

                if (WorldName == "MAIN" || WorldName == "TEST" || WorldName == "WORLD")
                    tiles = new WorldTile[160, 80]; // for LARGE worlds


                for (int i = 0; i < tiles.GetLength(1); i++)
                {
                    for (int j = 0; j < tiles.GetLength(0); j++)
                    {
                        tiles[j, i] = new WorldTile();
                    }
                }

                int currentLayer = 24;
                int tilesPlaced = 0;
                short nextBlock = 0;
                Random random = new Random();
                for (int y = 0; y < SpawnPointY; y++)
                {
                    for (int x = 0; x < GetSizeX(); x++)
                    {
                        int layerLimit = WorldName == "MAIN" || WorldName == "TEST" || WorldName == "WORLD" ? 20 : 21;
                        short foregroundBlock = 1;
                        short backgroundBlock = 2;
                        if (tilesPlaced >= GetSizeX())
                        {
                            currentLayer--;
                            tilesPlaced = 0;
                        }
                        tilesPlaced++;

                        int randomPercentage = (int)getRandomPossibility();
                        int betaLayerLimit = WorldName == "MAIN" || WorldName == "TEST" || WorldName == "WORLD" ? 20 : 13;

                        if (randomPercentage > 80 && nextBlock == 0)
                        {
                            short[] upperBlocks = new List<short>() { 7, 4 }.ToArray();
                            short[] lowerBlocks = new List<short>() { 9, 8, 2735 }.ToArray();

                            short upperBlock = upperBlocks[random.Next(0, upperBlocks.Length)];
                            short lowerBlock = lowerBlocks[random.Next(0, lowerBlocks.Length)];

                            if (currentLayer > 4 && currentLayer < layerLimit && currentLayer < betaLayerLimit)
                            {
                                if (randomPercentage > 40) nextBlock = upperBlock;
                                foregroundBlock = upperBlock;
                            }

                            if (betaLayerLimit >= 13 && currentLayer < layerLimit)
                            {
                                if (randomPercentage > 40) nextBlock = lowerBlock;
                                foregroundBlock = lowerBlock;
                            }
                        }

                        if (nextBlock != 0)
                        {
                            foregroundBlock = nextBlock;
                            nextBlock = 0;
                        }

                        if (currentLayer >= layerLimit)
                        {
                            backgroundBlock = 0;
                        }

                        if (currentLayer > 21) foregroundBlock = 3;
                        if (currentLayer > 22) foregroundBlock = 343;
                        if (currentLayer > 23) foregroundBlock = 344;

                        tiles[x, y].fg.id = foregroundBlock;
                        tiles[x, y].bg.id = backgroundBlock;
                    }
                }
                worldItemsData[SpawnPointX, SpawnPointY] = DataFactory.SpawnBSON(null, 110, DataFactory.Pair(SpawnPointX, SpawnPointY));
            }
            finally
            {
                worldProcessing = false;
            }
        }

        public WorldTile GetTile(int x, int y)
        {
            if (x >= GetSizeX() || y >= GetSizeY() || x < 0 || y < 0)
                return null;

            return tiles[x, y];
        }

        public double getRandomPossibility() // Gets harder possibility between 0-100%
        {
            double a = 0;
            double b = 100;
            double c = 50;

            double u = new Random().NextDouble();
            double percentage;

            if (u <= (c - a) / (b - a))
            {
                percentage = a + Math.Sqrt(u * (b - a) * (c - a));
            }
            else
            {
                percentage = b - Math.Sqrt((1 - u) * (b - a) * (b - c));
            }

            return percentage;
        }

        public BSONObject Serialize()
        {
            BSONObject wObj = new BSONObject();
            BSONObject itemDatas = new BSONObject();
            BSONObject seedDatas = new BSONObject();

            int tileLen = tiles.Length;
            int allocLen = tileLen * 2;

            byte[] blockLayerData = new byte[allocLen];
            byte[] backgroundLayerData = new byte[allocLen];
            byte[] waterLayerData = new byte[allocLen];
            byte[] wiringLayerData = new byte[allocLen];

            int width = GetSizeX();
            int height = GetSizeY();

            Util.Log($"Serializing world '{WorldName}' with width: {width} and height: {height}.");

            int pos = 0;
            for (int i = 0; i < tiles.Length; ++i)
            {
                int x = i % width;
                int y = i / width;

                if (x == SpawnPointX && y == SpawnPointY)
                    tiles[x, y].fg.id = 110;

                if (tiles[x, y].fg.id != 0) Buffer.BlockCopy(BitConverter.GetBytes(tiles[x, y].fg.id), 0, blockLayerData, pos, 2);
                if (tiles[x, y].bg.id != 0) Buffer.BlockCopy(BitConverter.GetBytes(tiles[x, y].bg.id), 0, backgroundLayerData, pos, 2);
                if (tiles[x, y].water.id != 0) Buffer.BlockCopy(BitConverter.GetBytes(tiles[x, y].water.id), 0, waterLayerData, pos, 2);
                if (tiles[x, y].wire.id != 0) Buffer.BlockCopy(BitConverter.GetBytes(tiles[x, y].wire.id), 0, wiringLayerData, pos, 2);


                if (worldItemsData != null && worldItemsData[x, y] != null)
                {
                    itemDatas[$"W {x} {y}"] = worldItemsData[x, y];
                    if (ConfigData.IsLock(worldItemsData[x, y]["blockType"].blockTypeValue))
                    {
                        if (wl == null)
                            wl = new Helpers.WorldLockHelper(this, worldItemsData[x, y], x, y);
                        else
                            itemDatas[$"W {x} {y}"] = wl.AsBSON();
                    }
                }
                if (plantedSeeds != null && plantedSeeds[x, y] != null)
                    seedDatas[$"S {x} {y}"] = plantedSeeds[x, y].AsBSON();
                pos += 2;
            }

            wObj[MsgLabels.MessageID] = MsgLabels.Ident.GetWorld;
            wObj["World"] = WorldName;
            wObj["BlockLayer"] = blockLayerData;
            wObj["BackgroundLayer"] = backgroundLayerData;
            wObj["WaterLayer"] = waterLayerData;
            wObj["WiringLayer"] = wiringLayerData;

            BSONObject cObj = new BSONObject();
            cObj["Count"] = collectables.Values.Count;

            for (int i = 0; i < collectables.Values.Count; i++)
            {
                var col = collectables.ElementAt(i).Value.GetAsBSON();
                var kv = collectables.ElementAt(i);

                col["CollectableID"] = kv.Key;
                cObj[$"C{i}"] = col;
            }

            List<int>[] layerHits = new List<int>[4];
            for (int j = 0; j < layerHits.Length; j++)
            {
                layerHits[j] = new List<int>();
                layerHits[j].AddRange(Enumerable.Repeat(0, tileLen));
            }

            List<int>[] layerHitBuffers = new List<int>[4];
            for (int j = 0; j < layerHitBuffers.Length; j++)
            {
                layerHitBuffers[j] = new List<int>();
                layerHitBuffers[j].AddRange(Enumerable.Repeat(0, tileLen));
            }

            wObj["BlockLayerHits"] = layerHits[0];
            wObj["BackgroundLayerHits"] = layerHits[1];
            wObj["WaterLayerHits"] = layerHits[2];
            wObj["WiringLayerHits"] = layerHits[3];
            wObj["BlockLayerHitBuffers"] = layerHitBuffers[0];
            wObj["BackgroundLayerHitBuffers"] = layerHitBuffers[1];
            wObj["WaterLayerHitBuffers"] = layerHitBuffers[2];
            wObj["WiringLayerHits"] = layerHitBuffers[3];

            // change to template null count for optimization soon...
            BSONObject wLayoutType = new BSONObject();
            wLayoutType["Count"] = (int)worldLayoutType;
            BSONObject wBackgroundType = new BSONObject();
            wBackgroundType["Count"] = (int)layerBackgroundType;
            BSONObject wMusicSettings = new BSONObject();
            wMusicSettings["Count"] = musicIndex;

            BSONObject wStartPoint = new BSONObject();
            wStartPoint["x"] = (int)SpawnPointX; wStartPoint["y"] = (int)SpawnPointY;

            BSONObject wSizeSettings = new BSONObject();
            wSizeSettings["WorldSizeX"] = width; wSizeSettings["WorldSizeY"] = height;
            BSONObject wGravityMode = new BSONObject();
            wGravityMode["GM"] = (int)gravityMode;
            BSONObject wRatings = new BSONObject();
            wRatings["Count"] = 0;
            BSONObject wRaceScores = new BSONObject();
            wRaceScores["Count"] = 0;
            BSONObject wLightingType = new BSONObject();
            wLightingType["Count"] = (int)lightingType;


            wObj["WorldLayoutType"] = wLayoutType;
            wObj["WorldBackgroundType"] = wBackgroundType;
            wObj["WorldMusicIndex"] = wMusicSettings;
            wObj["WorldStartPoint"] = wStartPoint;
            wObj["WorldItemId"] = 0;
            wObj["WorldSizeSettingsType"] = wSizeSettings;
            wObj["WorldGravityMode"] = wGravityMode;
            wObj["WorldRatingsKey"] = wRatings;
            wObj["WorldItemId"] = 1;
            wObj["InventoryId"] = 1;
            wObj["RatingBoardCountKey"] = 0;
            wObj["QuestStarterItemSummerCountKey"] = 0;
            wObj["WorldRaceScoresKey"] = wRaceScores;
            wObj["WorldTagKey"] = 0;
            wObj["PlayerMaxDeathsCountKey"] = 0;
            wObj["RatingBoardDateTimeKey"] = DateTimeOffset.UtcNow.Date;
            wObj["WorldLightingType"] = wLightingType;
            wObj["WorldWeatherType"] = wLightingType;
            wObj["WorldItems"] = itemDatas;
            wObj["PlantedSeeds"] = seedDatas;
            wObj["Collectables"] = cObj;

            return wObj;
        }

        public void Deserialize(BSONObject bson)
        {
            //Console.Write(SimpleBSON.DumpBSON(bson));
            int worldSizeX = bson["WorldSizeSettingsType"]["WorldSizeX"].int32Value;
            int worldSizeY = bson["WorldSizeSettingsType"]["WorldSizeY"].int32Value;
            tiles = new WorldTile[worldSizeX, worldSizeY];


            for (int i = 0; i < tiles.GetLength(1); i++)
            {
                for (int j = 0; j < tiles.GetLength(0); j++)
                {
                    tiles[j, i] = new WorldTile();
                }
            }

            byte[] byteArray = bson["BlockLayer"].binaryValue;
            byte[] byteArray2 = bson["BackgroundLayer"].binaryValue;
            byte[] byteArray3 = bson["WaterLayer"].binaryValue;
            byte[] byteArray4 = bson["WiringLayer"].binaryValue;

            short[] array = new short[byteArray.Length / 2];
            Buffer.BlockCopy(byteArray, 0, array, 0, byteArray.Length);

            short[] array2 = new short[byteArray2.Length / 2];
            Buffer.BlockCopy(byteArray2, 0, array2, 0, byteArray2.Length);

            short[] array3 = new short[byteArray3.Length / 2];
            Buffer.BlockCopy(byteArray3, 0, array3, 0, byteArray3.Length);

            short[] array4 = new short[byteArray4.Length / 2];
            Buffer.BlockCopy(byteArray4, 0, array4, 0, byteArray4.Length);

            for (int x = 0; x < GetSizeX(); x++)
            {
                for (int y = 0; y < GetSizeY(); y++)
                {
                    var tile = tiles[x, y];

                    tile.fg.id = array[y * worldSizeX + x];
                    tile.bg.id = array2[y * worldSizeX + x]; ;
                    tile.water.id = array3[y * worldSizeX + x];
                    tile.wire.id = array4[y * worldSizeX + x];
                    if (bson["WorldItems"] != null)
                    {
                        if (bson["WorldItems"].ContainsKey($"W {x} {y}"))
                        {
                            worldItemsData[x, y] = bson["WorldItems"][$"W {x} {y}"] as BSONObject;
                            if (ConfigData.IsLock(worldItemsData[x, y]["blockType"].blockTypeValue))
                            {
                                wl = new WorldLockHelper(this, worldItemsData[x, y], x, y);
                            }
                        }
                    }
                    if (bson["PlantedSeeds"] != null)
                    {
                        if (bson["PlantedSeeds"].ContainsKey($"S {x} {y}"))
                            plantedSeeds[x, y] = new SeedData(bson["PlantedSeeds"][$"S {x} {y}"] as BSONObject);
                    }

                    if (tile.fg.id == 110)
                    {
                        SpawnPointX = (short)x;
                        SpawnPointY = (short)y;
                    }
                }
            }

            int dropCount = bson["Collectables"]["Count"];
            for (int i = 0; i < dropCount; i++)
            {
                BSONObject col = bson["Collectables"]["C" + i.ToString()] as BSONObject;
                Collectable c = new Collectable();
                c.BlockType = (BlockType)col["BlockType"].int32Value;
                c.InventoryType = (InventoryItemType)col["InventoryType"].int32Value;
                c.amt = (short)col["Amount"].int32Value;
                c.posX = col["PosX"].doubleValue;
                c.posY = col["PosY"].doubleValue;
                c.gemType = (short)col["GemType"].int32Value;
                collectables[++colID] = c;
            }

            worldLayoutType = (WorldLayoutType)bson["WorldLayoutType"]["Count"].int32Value;
            layerBackgroundType = (LayerBackgroundType)bson["WorldBackgroundType"]["Count"].int32Value;
            weatherType = (WeatherType)bson["WorldWeatherType"]["Count"].int32Value;
            lightingType = (LightingType)bson["WorldLightingType"]["Count"].int32Value;
            gravityMode = (GravityMode)bson["WorldGravityMode"]["GM"].int32Value;
            musicIndex = bson["WorldMusicIndex"]["Count"].int32Value;
        }

        ~WorldSession()
        {

        }

        public /*List<Collectable>*/void RandomizeCollectablesForDestroyedBlock(Vector2i mapPoint, BlockType blockType)
        {
            var list = new List<Collectable>();

            double pX = mapPoint.x / Math.PI, pY = mapPoint.y / Math.PI; //idk wtf is that
            pX = pX - 0.1 + Util.rand.NextDouble(0, 0.2);
            pY = pY - 0.1 + Util.rand.NextDouble(0, 0.2);

            short seedsCount;
            short blocksCount;
            short gemsCount;
            short extraBlocksCount;
            BlockType extraBlock;
            if (blockType == BlockType.Tree)
            {
                var seedDataAt = plantedSeeds[mapPoint.x, mapPoint.y];
                if (seedDataAt is null || seedDataAt.GrowthEndTime > DateTime.UtcNow)
                {
                    return;
                }

                gemsCount = seedDataAt.HarvestGems;
                blockType = seedDataAt.BlockType;
                seedsCount = seedDataAt.HarvestSeeds;
                blocksCount = seedDataAt.HarvestBlocks;
                extraBlocksCount = seedDataAt.HarvestExtraBlocks;
                extraBlock = ConfigData.TreeExtraDropBlock[(int)blockType];
            }
            else
            {
                seedsCount = (short)(RollDrops.DoesBlockDropSeed(blockType) ? 1 : 0);
                blocksCount = (short)(RollDrops.DoesBlockDropBlock(blockType) ? 1 : 0);
                gemsCount = RollDrops.BlockDropsGems(blockType);
                extraBlocksCount = (short)(RollDrops.DoesBlockDropExtraBlock(blockType) ? 1 : 0);
                extraBlock = ConfigData.BlockExtraDropBlock[(int)blockType];
            }

            if (seedsCount > 0)
            {
                this.Drop(new InventoryKey(blockType, InventoryItemType.Seed), seedsCount, pX, pY);
            }

            if (blocksCount > 0)
            {
                // (!InventoryDataFactory.DoesEnumNeedDataClass(blockType)) ? null : InventoryDataFactory.SpawnDataClassForEnum(blockType)
                this.Drop(new InventoryKey(blockType, (InventoryItemType)ItemDB.GetByID((int)blockType).type), blocksCount, pX, pY);
            }

            if (gemsCount == 1) //quick, saves resources
                Drop(InventoryKey.GetNoneBlockKey(), gemsCount, pX, pY, 0);
            else if (gemsCount > 0)
            {
                int gemsLeft = gemsCount;
                var array = Enum.GetValues(typeof(GemType));
                Array.Reverse(array);
                foreach (GemType type in array)
                {
                    if (gemsLeft < 1) break;
                    int value = ConfigData.GetGemValue(type);
                    int count = gemsLeft / value;
                    gemsLeft -= value * count;
                    if (count > 0)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            Drop(InventoryKey.GetNoneBlockKey(), 1, pX, pY, (int)type);
                        }
                    }
                }

            }

            if (extraBlocksCount > 0)
            {
                // (!InventoryDataFactory.DoesEnumNeedDataClass(blockType2)) ? null : InventoryDataFactory.SpawnDataClassForEnum(blockType2)
                //list.Add(AddCollectable(extraBlock, extraBlocksCount, ConfigData.BlockInventoryItemType[(int)extraBlock], mapPoint, null!));
                this.Drop(new InventoryKey(extraBlock, ConfigData.BlockInventoryItemType[(int)extraBlock]), extraBlocksCount, pX, pY);
            }

            //return list;
        }

        public void SetSeed(Vector2i mp, BlockType bt, bool mixed = false, bool fertilized = false, string playerId = "SERVER")
        {
            plantedSeeds[mp.x, mp.y] = Seeds.GenerateSeedData(bt, mp, mixed);
            GetTile(mp.x, mp.y).fg.id = 37;
            BSONObject resp = plantedSeeds[mp.x, mp.y].AsBSON();
            resp["ID"] = "SS";
            resp["U"] = playerId;
            resp["SFe"] = fertilized;
            Broadcast(ref resp);
        }

        public static Vector2i ConvertWorldPointToMapPoint(float posx, float posy, bool fromFeet = true)
        {
            posy = fromFeet ? posy + ConfigData.TileSizeY * 0.01f : posy;
            return new Vector2i((int)((posx + ConfigData.TileSizeX * 0.5f) / ConfigData.TileSizeX), (int)((posy + ConfigData.TileSizeY * 0.5f) / ConfigData.TileSizeY));
        }

        public static void ConvertMapPointToWorldPoint(Vector2i mapPoint, out double x, out double y)
        {
            x = mapPoint.x * ConfigData.TileSizeX;
            y = (mapPoint.y * ConfigData.TileSizeY) - (ConfigData.TileSizeY * 0.01f);
        }

        public static Vector2i ConvertCollectablePosToMapPoint(float x, float y)
        {
            return ConvertWorldPointToMapPoint(x * ConfigData.TileSizeX, y * ConfigData.TileSizeY);
        }

        public static Vector2i DistanceMP(Vector2i point1, Vector2i point2)
        {
            int x = 0;
            int y = 0;
            if (point1.x > point2.x) { x = point1.x - point2.x; }
            else if (point1.x < point2.x) { x = point2.x - point1.x; }

            if (point1.y > point2.y) { y = point1.y - point2.y; }
            else if (point1.y < point2.y) { y = point2.y - point1.y; }

            return new Vector2i(x, y);
        }

        public static float Distance(Vector2i point1, Vector2i point2)
        {
            float dx = point1.x - point2.x;
            float dy = point1.y - point2.y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }

        public BlockType GetBlockType(Vector2i mp)
        {
            return (BlockType)GetTile(mp.x, mp.y).fg.id;
        }

        public bool InWorldBounds(Vector2i position)
        {
            return InWorldBounds(position.x, position.y);
        }
        public bool InWorldBounds(int positionX, int positionY)
        {
            return positionX >= 0 && positionX < GetSizeX() && positionY >= 0 && positionY < GetSizeY();
        }

        public List<Vector2i> GetMapPointsGridInRange(Vector2i center, int range)
        {
            List<Vector2i> result = new List<Vector2i>();
            //start points
            Vector2i stp = new Vector2i(
                center.x - range,
                center.y + range
                );
            int xx = stp.x;
            int yy = stp.y;
            //loop for Y from start point to range
            for (int i = 0; i < 2 * range + 1; i++)
            {
                //loop for X from start point to range
                for (int r = 0; r < 2 * range + 1; r++)
                {
                    if (xx >= 0 && yy >= 0 && xx <= GetSizeX() && yy <= GetSizeY())
                        result.Add(new Vector2i(xx, yy));
                    xx++;
                }
                xx = stp.x;
                yy--;
            }
            return result;
        }
    }
}

