using System;
using System.Collections.Generic;
using System.Reactive;
using System.Xml.Linq;
using BasicTypes;
using Kernys.Bson;
using PWS.Networking.Server;
using static PWS.Constants.Enums;

namespace PWS.World.Helpers
{
	public class WorldLockHelper
	{
		public string dataClass { get; set; }
		public BlockType blockType { get; set; }
		public string ownerId { get; set; }
		public string ownerName { get; set; }
		public List<string> fulls = new List<string>();
		public List<string> minors = new List<string>();
		public bool isOpen;
		public bool punchingAllowed = false;
		public DateTime creationTime = DateTime.MinValue;
		public DateTime lastActivatedTime = DateTime.MinValue;
		public bool isBattleOn;
		public Vector2i pos;
		public WorldSession World;

		//garbage//
		public bool isAnimationOn { get => !isOpen; }
		public int itemId;
		//public int direction = 0;
		//public bool anotherSprite = true;
		//public bool damageNow = false;

		public WorldLockHelper(WorldSession world, BSONObject bson, int x, int y)
		{
			World = world;
			dataClass = bson["class"].stringValue;
			blockType = (BlockType)bson["blockType"].int32Value;
			ownerId = bson["playerWhoOwnsLockId"].stringValue;
			ownerName = bson["playerWhoOwnsLockName"].stringValue;
			fulls = bson["playersWhoHaveAccessToLock"].stringListValue;
			minors = bson["playersWhoHaveMinorAccessToLock"].stringListValue;
			isOpen = bson["isOpen"].boolValue;
			punchingAllowed = bson["punchingAllowed"].boolValue;
			creationTime = bson["creationTime"].dateTimeValue;
			lastActivatedTime = bson["lastActivatedTime"].dateTimeValue;
			isBattleOn = bson["isBattleOn"].boolValue;
			pos = new Vector2i(x, y);
			itemId = bson["itemId"].int32Value;
		}

		public BSONObject AsBSON()
		{
			BSONObject bsonobject = new BSONObject();
			bsonobject["class"] = dataClass;
			bsonobject["itemId"] = itemId;
			bsonobject["blockType"] = (int)blockType;
			bsonobject["animOn"] = isAnimationOn;
			bsonobject["direction"] = 0;
			bsonobject["anotherSprite"] = isAnimationOn; //dont touch
			bsonobject["damageNow"] = false;
			bsonobject["playerWhoOwnsLockId"] = ownerId;
			bsonobject["playerWhoOwnsLockName"] = ownerName;
			bsonobject["playersWhoHaveAccessToLock"] = this.fulls;
			bsonobject["playersWhoHaveMinorAccessToLock"] = this.minors;
			bsonobject["isOpen"] = this.isOpen;
			bsonobject["punchingAllowed"] = this.punchingAllowed;
			bsonobject["creationTime"] = this.creationTime;
			bsonobject["lastActivatedTime"] = this.lastActivatedTime;
			bsonobject["isBattleOn"] = this.isBattleOn;
			return bsonobject;
		}


		private bool ValidateKeys(BSONObject bson) //shit, use DataFactory.ValidateWIB() instead 
		{
			return bson.ContainsKey("playerWhoOwnsLockId") && bson.ContainsKey("playerWhoOwnsLockName") && bson.ContainsKey("playersWhoHaveMinorAccessToLock") && bson.ContainsKey("isOpen") && bson.ContainsKey("punchingAllowed") && bson.ContainsKey("creationTime") && bson.ContainsKey("lastActivatedTime") && bson.ContainsKey("isBattleOn");
		}

		public bool IsOwner(string playerId)
		{
			return ownerId == playerId;
		}

		public void AddFull(string idNameCombined)
		{
			if (this.fulls.Count < 50)
			{
				this.fulls.Add(idNameCombined);
			}
		}

		public void RemoveFull(string idNameCombined)
		{
			this.fulls.Remove(idNameCombined);
		}

		public void AddMinor(string idNameCombined)
		{
			if (this.minors.Count < 50)
			{
				this.minors.Add(idNameCombined);
			}
		}

		public void RemoveMinor(string idNameCombined)
		{
			this.minors.Remove(idNameCombined);
		}

		public bool HasFull(string playerId)
		{
			if (this.ownerId.Equals(playerId))
			{
				return true;
			}
			if (this.fulls != null && this.fulls.Count > 0)
			{
				for (int i = 0; i < this.fulls.Count; i++)
				{
					if (PlayerIdNameHelper.GetPlayerIdFromCombined(this.fulls[i]).Equals(playerId))
					{
						return true;
					}
				}
			}
			return false;
		}

		public bool HasMinor(string playerId)
		{
			if (this.ownerId.Equals(playerId))
			{
				return true;
			}
			if (this.fulls != null && this.minors.Count > 0)
			{
				for (int i = 0; i < this.minors.Count; i++)
				{
					if (PlayerIdNameHelper.GetPlayerIdFromCombined(this.minors[i]).Equals(playerId))
					{
						return true;
					}
				}
			}
			return false;
		}

		public void Destroy()
		{
			World.worldItemsData[pos.x, pos.y] = null;
			World.wl = null;
		}
	}
}

