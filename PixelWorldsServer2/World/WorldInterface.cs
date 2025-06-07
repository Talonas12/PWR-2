using BasicTypes;
using Kernys.Bson;
using PWS.DataManagement;
using System;
using System.Collections.Generic;
using System.Text;
using static PWS.Constants.Enums;
using PWS.Structs;

namespace PWS.World
{
    public interface WorldInterface
    {
		

		public class Collectable
        {
			public BlockType BlockType;
			public short amt;
            public InventoryItemType InventoryType;
            public double posX, posY;
			public bool IsGem;
			public short gemType; // over -1: is a gem as well and has a type.

			public BSONObject GetAsBSON()
            {
				var bObj = new BSONObject();
				bObj["BlockType"] = (short)BlockType;
				bObj["Amount"] = amt;
				bObj["InventoryType"] = (short)InventoryType;
				bObj["PosX"] = posX;
				bObj["PosY"] = posY;
				bObj["IsGem"] = IsGem;
				bObj["GemType"] = gemType;
				return bObj;
			}
        }

		public BSONObject Serialize();
    }
}
