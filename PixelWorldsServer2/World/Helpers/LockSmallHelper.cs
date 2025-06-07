using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes;
using Kernys.Bson;
using static PWS.Constants.Enums;

namespace PWS.World
{
    public class LockSmallHelper
    {
		public string dataClass = string.Empty;
		public string blockType = string.Empty;
		public string playerWhoOwnsLockId = string.Empty;
		public string playerWhoOwnsLockName = string.Empty;
		public List<string> playersWhoHaveAccessToLock = new List<string>();
		public List<string> playersWhoHaveMinorAccessToLock = new List<string>();
		public bool isOpen;
		public bool ignoreEmptyArea;
		public List<Vector2i> lockMapPoints = new List<Vector2i>();
		public DateTime creationTime = DateTime.MinValue;
		public DateTime lastActivatedTime = DateTime.MinValue;
		public bool isBattleOn;

		public LockSmallHelper(BSONObject asBSON)
        {

        }

		public BSONObject GetAsBSON()
		{
			BSONObject bsonobject = new BSONObject();
			bsonobject["class"] = dataClass;
			bsonobject["blockType"] = blockType;
			bsonobject["animOn"] = true;
			bsonobject["playerWhoOwnsLockId"] = playerWhoOwnsLockId;
			bsonobject["playerWhoOwnsLockName"] = playerWhoOwnsLockName;
			bsonobject["playersWhoHaveAccessToLock"] = this.playersWhoHaveAccessToLock;
			bsonobject["playersWhoHaveMinorAccessToLock"] = this.playersWhoHaveMinorAccessToLock;
			bsonobject["isOpen"] = this.isOpen;
			bsonobject["ignoreEmptyArea"] = this.ignoreEmptyArea;
			bsonobject["lockMapPoints"] = this.lockMapPoints;
			bsonobject["creationTime"] = this.creationTime;
			bsonobject["lastActivatedTime"] = this.lastActivatedTime;
			bsonobject["isBattleOn"] = this.isBattleOn;
			return bsonobject;
		}
	}
}
