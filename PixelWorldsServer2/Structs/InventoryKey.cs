using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PWS.Constants.Enums;

namespace PWS.Structs
{
    public struct InventoryKey
    {
        public BlockType blockType;
        public InventoryItemType itemType;

        public InventoryKey(BlockType BlockType, InventoryItemType ItemType)
        {
            blockType = BlockType;
            itemType = ItemType;

        }

        public static int InventoryKeyToInt(InventoryKey ik)
        {
            return BlockTypeAndInventoryItemTypeToInt((BlockType)ik.blockType, (InventoryItemType)ik.itemType);
        }

        public static int BlockTypeAndInventoryItemTypeToInt(BlockType blockType, InventoryItemType inventoryItemType)
        {
            return (int)((BlockType)((int)inventoryItemType << 24) | blockType);
        }

        public static InventoryKey IntToInventoryKey(int asInt)
        {
            return new InventoryKey((BlockType)(asInt & 0xFFFFFF), (InventoryItemType)(asInt >> 24));
        }

        public static int[] InventoryKeyArrayToIntArray(InventoryKey[] array)
        {
            int[] result = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = InventoryKeyToInt(array[i]);
            }
            return result;
        }

        public bool Equals(InventoryKey other)
        {
            return blockType == other.blockType && itemType == other.itemType;
        }

        public override bool Equals(object other)
        {
            if (other is InventoryKey)
            {
                return Equals((InventoryKey)other);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (int)((uint)itemType << 24) | (int)blockType;
        }

        public static bool operator ==(InventoryKey lhs, object rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(InventoryKey lhs, object rhs)
        {
            return !(lhs == rhs);
        }

        public static InventoryKey GetNoneBlockKey()
        {
            return new InventoryKey(0, 0);
        }

        public static List<int> GetInventoryKeysAsIntList(List<InventoryKey> iks)
        {
            List<int> list = new List<int>(iks.Count);
            for (int i = 0; i < iks.Count; i++)
            {
                list.Add(InventoryKeyToInt(iks[i]));
            }
            return list;
        }

        public static List<InventoryKey> IntListToInventoryKeyList(List<int> intList)
        {
            List<InventoryKey> list = new List<InventoryKey>(intList.Count);
            for (int i = 0; i < intList.Count; i++)
            {
                list.Add(IntToInventoryKey(intList[i]));
            }
            return list;
        }

        public override string ToString()
        {
            return blockType + " " + itemType;
        }

        public static explicit operator int(InventoryKey ik)
        {
            return InventoryKeyToInt(ik);
        }
        
        public static explicit operator InventoryKey(int i)
        {
            return IntToInventoryKey(i);
        }
    }
}
