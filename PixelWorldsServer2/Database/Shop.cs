using Kernys.Bson;
using PWS.DataManagement;
using PWS.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static PWS.Constants.Enums;

namespace PWS.Database
{
    public struct ShopResult
    {
        // Token: 0x04000150 RID: 336
        public int price;

        // Token: 0x04000151 RID: 337
        public List<KeyTriple<int, InventoryItemType, int>> items;
    }
    public struct ShopByteResult
    {
        // Token: 0x04000152 RID: 338
        public int price;

        // Token: 0x04000153 RID: 339
        public int amount;
    }

    public class Shop
    {
        // Token: 0x06000248 RID: 584 RVA: 0x000147C8 File Offset: 0x000129C8


        // Token: 0x06000249 RID: 585 RVA: 0x00014800 File Offset: 0x00012A00
        public static void AddShopByteOffer(string name, int price, int amount)
        {
            ShopByteResult sr = default(ShopByteResult);
            sr.price = price;
            sr.amount = amount;
            Shop.byteOffers[name] = sr;
        }

        // Token: 0x0600024A RID: 586 RVA: 0x00014834 File Offset: 0x00012A34
        public static bool ContainsItem(int itemId)
        {
            foreach (ShopResult res in Shop.offers.Values)
            {
                bool flag = res.items.Any(item => item.Key == itemId);
                if (flag)
                {
                    return true;
                }
            }
            return false;
        }

        public static InventoryKey[] StringToInventoryKeysArray(string commaSeparatedArary)
        {
            string[] array = commaSeparatedArary.Split(',');
            InventoryKey[] result = new InventoryKey[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = InventoryKey.IntToInventoryKey(int.Parse(array[i]));
            }
            return result;
        }

        public static short[] StringToShortArray(string commaSeparatedArary)
        {
            string[] array = commaSeparatedArary.Split(',');
            short[] result = new short[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = short.Parse(array[i]);
            }
            return result;
        }


        // Token: 0x0600024B RID: 587 RVA: 0x000148D4 File Offset: 0x00012AD4 Easterbooster
        public static void Init()
        {
            Shop.AddShopByteOffer("ByteCoin01", 800, 50);
            Shop.AddShopByteOffer("ByteCoin02", 4000, 250);
            Shop.AddShopByteOffer("ByteCoin03", 24000, 1500);
            Shop.AddShopByteOffer("ByteCoin04", 96000, 6000);
            Shop.AddShopByteOffer("WorldLock", 219, 1);

            string[] content = System.IO.File.ReadAllLines(@"LocalData\itempacks.txt");
            foreach (string line in content)
            {
                string[] args = line.Split("|");
                //LEGEND: ID-0|Price-1|IsVipOnly-2|SureDropsCount-3|Bucket1Count-4|Bucket2Count-5|SureDrops-6|SureDropsAmounts-7|Bucket1-8|Bucket2-9|Bucket1Amounts-10|Bucked2Amounts-11|Bucket1Weights-12|Bucket2Weights-13
                var pack = new ItemPacks.ItemPack();
                pack.id = args[0];
                pack.priceInGems = int.Parse(args[1]);
                pack.isVIPOnly = args[2] == "1";
                pack.sureDropsCount = short.Parse(args[3]);
                pack.randomDropsBucket1Count = short.Parse(args[4]);
                pack.randomDropsBucket2Count = short.Parse(args[5]);
                pack.sureDrops = pack.sureDropsCount > 0 ? StringToInventoryKeysArray(args[6]) : null;
                pack.sureDropAmounts = pack.sureDropsCount > 0 ? StringToShortArray(args[7]) : null;
                pack.randomDropsBucket1 = pack.randomDropsBucket1Count > 0 ? StringToInventoryKeysArray(args[8]) : null;
                pack.randomDropsBucket2 = pack.randomDropsBucket2Count > 0 ? StringToInventoryKeysArray(args[9]) : null;
                pack.randomDropAmountsBucket1 = pack.randomDropsBucket1Count > 0 ? StringToShortArray(args[10]) : null;
                pack.randomDropAmountsBucket2 = pack.randomDropsBucket2Count > 0 ? StringToShortArray(args[11]) : null;
                pack.bucket1Weights = pack.randomDropsBucket1Count > 0 ? StringToShortArray(args[12]) : null;
                pack.bucket2Weights = pack.randomDropsBucket2Count > 0 ? StringToShortArray(args[13]) : null;

                ItemPacks.AddItemPack(pack);
            }
            Util.Log($"Initialized Shop ItemPacks database, {ItemPacks.GetPacksCount()} entries!");
        }

        // Token: 0x04000154 RID: 340
        public static Dictionary<string, ShopResult> offers = new Dictionary<string, ShopResult>();

        // Token: 0x04000155 RID: 341
        public static Dictionary<string, ShopByteResult> byteOffers = new Dictionary<string, ShopByteResult>();
    }

    public static class ItemPacks
    {
        private static Dictionary<string, ItemPack> itemPacks = new Dictionary<string, ItemPack>();
        public static bool GetWithID(string itemPackId, out ItemPack itemPack)
        {
            if (itemPacks.TryGetValue(itemPackId, out itemPack))
            {
                return true;
            }
            else return false;
        }

        public static int GetPacksCount()
        {
            return itemPacks.Count;
        }

        public static void AddItemPack(ItemPack itemPack)
        {
            itemPacks.Add(itemPack.id, itemPack);
        }

        public struct ItemPack
        {
            public ItemPack(string itemPackId, int price, bool isVIPOnly, short sureDropsCount, short randomDropsBucket1Count, short randomDropsBucket2Count, InventoryKey[] guaranteedDrops, short[] guaranteedAmounts, InventoryKey[] lotteryDrops1, short[] lotteryAmounts1, short[] bucket1Weights, InventoryKey[] lotteryDrops2, short[] lotteryAmounts2, short[] bucket2Weights/*,DateTime endTime, bool isOneTimeOnly*/)
            {
                this.id = itemPackId;
                this.priceInGems = price;

                this.sureDropsCount = sureDropsCount;
                this.randomDropsBucket1Count = randomDropsBucket1Count;
                this.randomDropsBucket2Count = randomDropsBucket2Count;

                this.sureDrops = guaranteedDrops;
                this.sureDropAmounts = guaranteedAmounts;

                this.randomDropsBucket1 = lotteryDrops1;
                this.randomDropsBucket2 = lotteryDrops2;
                this.randomDropAmountsBucket1 = lotteryAmounts1;
                this.randomDropAmountsBucket2 = lotteryAmounts2;

                this.bucket2Weights = bucket2Weights;
                this.bucket1Weights = bucket1Weights;
                this.isVIPOnly = isVIPOnly;
                //this.limitedTime = endTime;
                //this.isOneTimeOnly = isOneTimeOnly;

            }

            public string id;
            public bool isVIPOnly;
            public int priceInGems;
            public InventoryKey[] sureDrops;
            public short[] sureDropAmounts;
            public InventoryKey[] randomDropsBucket1;
            public InventoryKey[] randomDropsBucket2;
            public short[] randomDropAmountsBucket1;
            public short[] randomDropAmountsBucket2;
            public short[] bucket1Weights;
            public short[] bucket2Weights;
            public short sureDropsCount;
            public short randomDropsBucket1Count;
            public short randomDropsBucket2Count;

            //// Token: 0x04002068 RID: 8296
            //public DateTime limitedTime;

            //// Token: 0x0400206B RID: 8299
            //public bool isOneTimeOnly;
        }

        public static void HandleBought(Player p, ItemPack pack)
        {
            if (p.Data.Gems >= pack.priceInGems)
            {
                BSONObject re = new("BIPack")
                {
                    ["IPId"] = pack.id,
                    ["IPRs"] = new List<int>(),
                    ["IPRs2"] = new List<int>(),
                    ["S"] = "PS"
                };

                if (pack.sureDropsCount > 0)
                {
                    for (int i = 0; i < pack.sureDrops.Length; i++)
                    {
                        p.Data.InvHelper.AddItemToInventory(pack.sureDrops[i], pack.sureDropAmounts[i]);
                    }
                }
                if (pack.randomDropsBucket1Count > 0)
                    re["IPRs"] = HelperRollItemsFromPackAndAddToInventory(pack.randomDropsBucket1, pack.bucket1Weights, pack.randomDropAmountsBucket1, pack.randomDropsBucket1Count, p, InventoryKey.GetInventoryKeysAsIntList(pack.randomDropsBucket1.ToList()), false);
                if (pack.randomDropsBucket2Count > 0)
                    re["IPRs2"] = HelperRollItemsFromPackAndAddToInventory(pack.randomDropsBucket2, pack.bucket2Weights, pack.randomDropAmountsBucket2, pack.randomDropsBucket1Count, p, InventoryKey.GetInventoryKeysAsIntList(pack.randomDropsBucket2.ToList()), false);
                p.Send(ref re);
                p.RemoveGems(pack.priceInGems);
            }
            else
            {
                PurchaseError(p);
            }

        }

        private static List<int> HelperRollItemsFromPackAndAddToInventory(InventoryKey[] randomDropsBucket, short[] randomDropWeightsBucket, short[] randomDropAmountsBucket, short numberOfRandomDropsBucket, Player p, List<int> randomBucket, bool isExclusiveRandom)
        {
            List<int> gain = new List<int>();
            if (randomDropsBucket.Length > 0 && numberOfRandomDropsBucket > 0)
            {
                int num = 0;
                ShuffleBagInt shuffleBagInt = new ShuffleBagInt();
                for (int i = 0; i < randomDropsBucket.Length; i++)
                {
                    shuffleBagInt.Add(i, randomDropWeightsBucket[i]);
                    num += randomDropWeightsBucket[i];
                }
                byte b = 0;
                for (int j = 0; j < num; j++)
                {
                    int num2 = shuffleBagInt.Next();
                    if ((isExclusiveRandom && !randomBucket.Contains(num2)) || !isExclusiveRandom)
                    {
                        randomBucket.Add(num2);
                        InventoryKey ik = randomDropsBucket[num2];
                        //short val = p.Data.InvHelpre.HowMuchCanPlayerPick(ik);
                        //short addAmount = Math.Min(val, (short)randomDropAmountsBucket[num2]);
                        gain.Add(num2);
                        p.Data.InvHelper.AddItemToInventory(ik, randomDropAmountsBucket[num2]);
                        b += 1;
                        if (b >= numberOfRandomDropsBucket)
                        {
                            break;
                        }
                    }
                }
            }
            return gain;
        }

        private static void PurchaseError(Player p, string er = "NEm")
        {
            BSONObject re = new("BIPack")
            {
                ["ER"] = er
            };
            p.Send(ref re);
        }

        public class ShuffleBagInt
        {
            public void Add(int item, int num)
            {
                while (num-- > 0)
                {
                    this.data.Add(item);
                }
                this.cursor = this.data.Count - 1;
            }

            public int Next()
            {
                if (this.data.Count == 0)
                {
                    return 0;
                }
                if (this.cursor < 1)
                {
                    this.cursor = this.data.Count - 1;
                    return this.data[0];
                }
                int index = this.random.Next(0, this.cursor + 1);
                int num = this.data[index];
                this.data[index] = this.data[this.cursor];
                this.data[this.cursor] = num;
                this.cursor--;
                return num;
            }

            public void Clear()
            {
                this.data.Clear();
            }

            private List<int> data = new List<int>(100);
            private int cursor = -1;
            private Random random = new Random();
        }
    }
}
