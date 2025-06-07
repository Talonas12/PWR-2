using Kernys.Bson;
using PWS.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PWS.Constants.Enums;

namespace PWS
{
    public class InventoryHelper
    {
        public Player player;
        public List<InventoryKey> Items
        {
            get
            {
                return this.itemList;
            }
        }

        // Token: 0x06000116 RID: 278 RVA: 0x00006656 File Offset: 0x00004856
        public InventoryHelper(Player pl)
        {
            this.p = pl;
        }

        // Token: 0x06000117 RID: 279 RVA: 0x00006674 File Offset: 0x00004874
        public void RegularDefaultInventory()
        {
            AddItemToInventory(BlockType.ShirtHoodieSupport, InventoryItemType.WearableItem);
            AddItemToInventory(BlockType.ShirtHoodieSupportFemale, InventoryItemType.WearableItem);
            AddItemToInventory(BlockType.Fertilizer, InventoryItemType.Seed, 5);
            AddItemToInventory(BlockType.PotionInstantGrowth, InventoryItemType.Seed);
            AddItemToInventory(BlockType.GemSoil, InventoryItemType.Seed, 2);
            AddItemToInventory(BlockType.Obsidian, InventoryItemType.Seed, 3);
            AddItemToInventory(BlockType.Marble, InventoryItemType.Seed, 3);
            AddItemToInventory(BlockType.Lava, InventoryItemType.Seed, 3);
            AddItemToInventory(BlockType.MiningIngredientSilverCoin, InventoryItemType.Consumable);
            AddItemToInventory(BlockType.LockWorld, InventoryItemType.Block);

        }

        // Token: 0x06000118 RID: 280 RVA: 0x0000680B File Offset: 0x00004A0B
        public void AddItemToInventory(InventoryKey ik, short addAmount = 1)
        {
            this.AddItemToInventory(ik.blockType, ik.itemType, addAmount);
        }

        // Token: 0x06000119 RID: 281 RVA: 0x00006824 File Offset: 0x00004A24
        public void AddItemToInventory(BlockType blockType, InventoryItemType inventoryItemType, short addAmount = 1)
        {
            if (!(addAmount < 1))
            {

                int num = InventoryKey.BlockTypeAndInventoryItemTypeToInt(blockType, inventoryItemType);

                bool flag2 = this.p.Data.Inventory.ContainsKey(num);
                if (flag2)
                {
                    // Explicitly cast the int value to short
                    this.p.Data.Inventory[num] = (short)(this.p.Data.Inventory[num] + addAmount);
                }
                else
                {
                    // Explicitly cast the int value to short
                    this.p.Data.Inventory[num] = (short)addAmount;
                }
            }
        }


        // Token: 0x0600011A RID: 282 RVA: 0x000068AD File Offset: 0x00004AAD
        public void RemoveItemsFromInventory(InventoryKey inventoryKey, short amount = 1)
        {
            this.RemoveItemsFromInventory(inventoryKey.blockType, inventoryKey.itemType, amount);
        }

        // Token: 0x0600011B RID: 283 RVA: 0x000068C4 File Offset: 0x00004AC4
        public void RemoveItemsFromInventory(BlockType blockType, InventoryItemType inventoryItemType, short amount = 1)
        {
            bool flag = amount < 1;
            if (!flag)
            {
                int key = InventoryKey.BlockTypeAndInventoryItemTypeToInt(blockType, inventoryItemType);
                bool flag2 = this.p.Data.Inventory.ContainsKey(key);
                if (flag2)
                {
                    short num = (short)(this.p.Data.Inventory[key] - amount);
                    bool flag3 = num > 0;
                    if (flag3)
                    {
                        this.p.Data.Inventory[key] = num;
                    }
                    else
                    {
                        this.p.Data.Inventory.Remove(key);
                    }
                }
            }
        }

        // Token: 0x0600011C RID: 284 RVA: 0x0000695C File Offset: 0x00004B5C
        public bool HasItemAmountInInventory(InventoryKey inventoryKey, short amount = 1)
        {
            BlockType blockType = inventoryKey.blockType;
            InventoryItemType itemType = inventoryKey.itemType;
            int key = InventoryKey.BlockTypeAndInventoryItemTypeToInt(blockType, itemType);
            bool flag = this.p.Data.Inventory.ContainsKey(key);
            if (flag)
            {
                int num = (int)this.p.Data.Inventory[key];
                bool flag2 = num >= (int)amount;
                if (flag2)
                {
                    return true;
                }
            }
            return false;
        }

        // Token: 0x0600011D RID: 285 RVA: 0x000069D0 File Offset: 0x00004BD0
        public bool HasItemAmountInInventory(BlockType blockType, InventoryItemType inventoryItemType, short amount = 1)
        {
            int key = InventoryKey.BlockTypeAndInventoryItemTypeToInt(blockType, inventoryItemType);
            bool flag = this.p.Data.Inventory.ContainsKey(key);
            if (flag)
            {
                int num = (int)this.p.Data.Inventory[key];
                bool flag2 = num >= (int)amount;
                if (flag2)
                {
                    return true;
                }
            }
            return false;
        }

        // Token: 0x0600011E RID: 286 RVA: 0x00006A34 File Offset: 0x00004C34
        public short GetCount(InventoryKey inventoryKey)
        {
            int key = InventoryKey.InventoryKeyToInt(inventoryKey);
            bool flag = this.p.Data.Inventory.ContainsKey(key);
            short result;
            if (flag)
            {
                result = this.p.Data.Inventory[key];
            }
            else
            {
                result = 0;
            }
            return result;
        }

        // Token: 0x0600011F RID: 287 RVA: 0x00006A84 File Offset: 0x00004C84
        public Dictionary<InventoryKey, short> GetCounts()
        {
            Dictionary<InventoryKey, short> dictionary = new Dictionary<InventoryKey, short>();
            foreach (KeyValuePair<int, short> keyValuePair in this.p.Data.Inventory)
            {
                dictionary[InventoryKey.IntToInventoryKey(keyValuePair.Key)] = keyValuePair.Value;
            }
            return dictionary;
        }

        // Token: 0x06000120 RID: 288 RVA: 0x00006B04 File Offset: 0x00004D04
        public bool IsItemAvailable(InventoryKey inventoryKey)
        {
            return this.IsItemAvailable(inventoryKey.blockType, inventoryKey.itemType);
        }

        // Token: 0x06000121 RID: 289 RVA: 0x00006B28 File Offset: 0x00004D28
        public bool IsItemAvailable(BlockType blockType, InventoryItemType inventoryItemType)
        {
            return this.p.Data.Inventory.ContainsKey(InventoryKey.BlockTypeAndInventoryItemTypeToInt(blockType, inventoryItemType));
        }

        // Token: 0x06000122 RID: 290 RVA: 0x00006B58 File Offset: 0x00004D58
        public bool CanTransfer(InventoryKey inventoryKey, short amount)
        {
            return 0 < amount && amount <= this.GetCount(inventoryKey);
        }

        // Token: 0x06000123 RID: 291 RVA: 0x00006B80 File Offset: 0x00004D80
        public byte[] GetInventoryAsBinary()
        {
            int num = 6;
            bool flag = this.p.Data.InvHelper == null || p.Data.Inventory == null || this.p.Data.Inventory.Count < 1;
            byte[] result;
            if (flag)
            {
                result = new byte[]
                {
                    1
                };
            }
            else
            {
                byte[] array = new byte[num * this.p.Data.Inventory.Count];
                int num2 = 0;
                foreach (KeyValuePair<int, short> keyValuePair in this.p.Data.Inventory)
                {
                    byte[] bytes = BitConverter.GetBytes(keyValuePair.Key);
                    byte[] bytes2 = BitConverter.GetBytes(keyValuePair.Value);
                    Buffer.BlockCopy(bytes, 0, array, num2, 4);
                    num2 += 4;
                    Buffer.BlockCopy(bytes2, 0, array, num2, 2);
                    num2 += 2;
                }
                result = array;
            }
            return result;
        }

        // Token: 0x06000124 RID: 292 RVA: 0x00006C84 File Offset: 0x00004E84
        public Dictionary<int, short> InitInventoryFromBinary(byte[] binary = null)
        {
            int num = 6;
            this.p.Data.Inventory = new Dictionary<int, short>();
            bool flag = binary == null || binary.Length < num;
            Dictionary<int, short> result;
            if (flag)
            {
                result = null;
            }
            else
            {
                for (int i = 0; i < binary.Length; i += num)
                {
                    this.p.Data.Inventory[BitConverter.ToInt32(binary, i)] = BitConverter.ToInt16(binary, i + 4);
                }
                result = this.p.Data.Inventory;
            }
            return result;
        }

        // Token: 0x06000125 RID: 293 RVA: 0x00006D0E File Offset: 0x00004F0E
        public void ClearInventory()
        {
            this.p.Data.Inventory.Clear();
        }

        // Token: 0x04000077 RID: 119
        private List<InventoryKey> itemList = new List<InventoryKey>();

        // Token: 0x04000078 RID: 120
        public Animation.HotSpots[] AnimHotSpots;

        // Token: 0x04000079 RID: 121
        public Player p;
    }
}
