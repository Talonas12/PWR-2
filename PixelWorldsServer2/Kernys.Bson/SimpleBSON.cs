﻿using BasicTypes;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Kernys.Bson
{
	public class BSONValue
	{
		public enum ValueType
		{
			Double,
			String,
			Array,
			Binary,
			Boolean,
			UTCDateTime,
			None,
			Int32,
			Int64,
			Object
		};

		private ValueType mValueType;
		private Double _double;
		private string _string;
		private byte[] _binary;
		private bool _bool;
		private DateTime _dateTime;
		private Int32 _int32;
		private Int64 _int64;

		/*
		protected static BSONValue convert(object obj) {
			if (obj as BSONValue != null)
				return obj as BSONValue;

			if (obj is Int32)
				return new BSONValue (obj as Int32);
			if (obj is Int64)
				return new BSONValue (obj as Int64);
			if (obj is byte[])
				return new BSONValue (obj as byte[]);
			if (obj is DateTime)
				return new BSONValue (obj as DateTime);
			if (obj is string)
				return new BSONValue (obj as string);
			if (obj is bool)
				return new BSONValue (obj as bool);
			if (obj is double)
				return new BSONValue (obj as double);

			throw new InvalidCastException();
		}
		*/

		/// Properties
		public ValueType valueType { get { return mValueType; } }
		public Double doubleValue
		{
			get
			{
				switch (mValueType)
				{
					case ValueType.Int32:
						return (double)_int32;
					case ValueType.Int64:
						return (double)_int64;
					case ValueType.Double:
						return _double;
					case ValueType.None:
						return float.NaN;
				}

				throw new Exception(string.Format("Original type is {0}. Cannot convert from {0} to double", mValueType));
			}
		}
		public Int32 int32Value
		{
			get
			{
				switch (mValueType)
				{
					case ValueType.Int32:
						return (Int32)_int32;
					case ValueType.Int64:
						return (Int32)_int64;
					case ValueType.Double:
						return (Int32)_double;
				}

				throw new Exception(string.Format("Original type is {0}. Cannot convert from {0} to Int32", mValueType));
			}
		}
		public Int64 int64Value
		{
			get
			{
				switch (mValueType)
				{
					case ValueType.Int32:
						return (Int64)_int32;
					case ValueType.Int64:
						return (Int64)_int64;
					case ValueType.Double:
						return (Int64)_double;
				}

				throw new Exception(string.Format("Original type is {0}. Cannot convert from {0} to Int64", mValueType));
			}
		}
		public byte[] binaryValue
		{
			get
			{
				switch (mValueType)
				{
					case ValueType.Binary:
						return _binary;
				}

				throw new Exception(string.Format("Original type is {0}. Cannot convert from {0} to binary", mValueType));
			}
		}
		public DateTime dateTimeValue
		{
			get
			{
				switch (mValueType)
				{
					case ValueType.UTCDateTime:
						return _dateTime;
				}

				throw new Exception(string.Format("Original type is {0}. Cannot convert from {0} to DateTime", mValueType));
			}
		}
		public String stringValue
		{
			get
			{
				switch (mValueType)
				{
					case ValueType.Int32:
						return Convert.ToString(_int32);
					case ValueType.Int64:
						return Convert.ToString(_int64);
					case ValueType.Double:
						return Convert.ToString(_double);
					case ValueType.String:
						return _string != null ? _string.TrimEnd(new char[] { (char)0 }) : null;
					case ValueType.Boolean:
						return _bool == true ? "true" : "false";
					case ValueType.Binary:
						return Encoding.UTF8.GetString(_binary).TrimEnd(new char[] { (char)0 });
				}

				throw new Exception(string.Format("Original type is {0}. Cannot convert from {0} to string", mValueType));
			}
		}
		public bool boolValue
		{
			get
			{
				switch (mValueType)
				{
					case ValueType.Boolean:
						return _bool;
				}

				throw new Exception(string.Format("Original type is {0}. Cannot convert from {0} to bool", mValueType));
			}
		}

		public List<int> int32ListValue
		{
			get
			{
				BSONValue.ValueType valueType = this.mValueType;
				if (valueType != BSONValue.ValueType.Array)
				{
					throw new Exception(string.Format("Original type is {0}. Cannot convert from {0} to int32 array", this.mValueType));
				}
				List<int> list = new List<int>();
				BSONArray bsonarray = (BSONArray)this;
				for (int i = 0; i < bsonarray.Count; i++)
				{
					list.Add(bsonarray[i].int32Value);
				}
				return list;
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06001F47 RID: 8007 RVA: 0x000CC7CC File Offset: 0x000CABCC
		public List<long> int64ListValue
		{
			get
			{
				BSONValue.ValueType valueType = this.mValueType;
				if (valueType != BSONValue.ValueType.Array)
				{
					throw new Exception(string.Format("Original type is {0}. Cannot convert from {0} to int64 array", this.mValueType));
				}
				List<long> list = new List<long>();
				BSONArray bsonarray = (BSONArray)this;
				for (int i = 0; i < bsonarray.Count; i++)
				{
					list.Add(bsonarray[i].int64Value);
				}
				return list;
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06001F48 RID: 8008 RVA: 0x000CC840 File Offset: 0x000CAC40
		public List<string> stringListValue
		{
			get
			{
				BSONValue.ValueType valueType = this.mValueType;
				if (valueType != BSONValue.ValueType.Array)
				{
					throw new Exception(string.Format("Original type is {0}. Cannot convert from {0} to string array", this.mValueType));
				}
				List<string> list = new List<string>();
				BSONArray bsonarray = (BSONArray)this;
				for (int i = 0; i < bsonarray.Count; i++)
				{
					list.Add(bsonarray[i].stringValue);
				}
				return list;
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06001F49 RID: 8009 RVA: 0x000CC8B4 File Offset: 0x000CACB4
		public List<Vector2i> vector2iListValue
		{
			get
			{
				BSONValue.ValueType valueType = this.mValueType;
				if (valueType != BSONValue.ValueType.Binary)
				{
					throw new Exception(string.Format("Original type is {0}. Cannot convert from {0} to Vector2i list", this.mValueType));
				}
				List<Vector2i> list = new List<Vector2i>();
				byte[] array = new byte[8];
				for (int i = 0; i < this._binary.Length; i += 8)
				{
					Buffer.BlockCopy(this._binary, i, array, 0, 8);
					list.Add(new Vector2i(array));
				}
				return list;
			}
		}

		public int[] int32ArrayValue
		{
			get
			{
				BSONValue.ValueType valueType = this.mValueType;
				if (valueType != BSONValue.ValueType.Binary)
				{
					throw new Exception(string.Format("Original type is {0}. Cannot convert from {0} to int32Binary list", this.mValueType));
				}
				int[] list = new int[this._binary.Length / 4];

				for (int i = 0; i < this._binary.Length; i += 4)
				{
					list[i] = BitConverter.ToInt32(this._binary, i);
				}
				return list;
			}
		}

		public short[] int16ArrayValue
		{
			get
			{
				BSONValue.ValueType valueType = this.mValueType;
				if (valueType != BSONValue.ValueType.Binary)
				{
					throw new Exception(string.Format("Original type is {0}. Cannot convert from {0} to int16Array list", this.mValueType));
				}

				int len = this._binary.Length / 2;
				short[] list = new short[len];

				for (int i = 0; i < len; i += 2)
				{
					list[i] = BitConverter.ToInt16(this._binary, i);
				}
				return list;
			}
		}

		public PWS.Constants.Enums.BlockType blockTypeValue
		{
			get
			{
				switch (mValueType)
				{
					case ValueType.Int32:
						return (PWS.Constants.Enums.BlockType)_int32;
					case ValueType.Int64:
						return (PWS.Constants.Enums.BlockType)_int64;
					case ValueType.Double:
						return (PWS.Constants.Enums.BlockType)(int)_double;
				}

				throw new Exception(string.Format("Original type is {0}. Cannot convert from {0} to BlockType", mValueType));
			}
		}

		public static implicit operator BSONValue(List<int> v)
		{
			BSONArray bsonarray = new BSONArray();
			for (int i = 0; i < v.Count; i++)
			{
				bsonarray.Add(new BSONValue(v[i]));
			}
			return bsonarray;
		}

		// Token: 0x06001F5C RID: 8028 RVA: 0x000CC9CC File Offset: 0x000CADCC
		public static implicit operator BSONValue(List<long> v)
		{
			BSONArray bsonarray = new BSONArray();
			for (int i = 0; i < v.Count; i++)
			{
				bsonarray.Add(new BSONValue(v[i]));
			}
			return bsonarray;
		}

		// Token: 0x06001F5D RID: 8029 RVA: 0x000CCA0C File Offset: 0x000CAE0C
		public static implicit operator BSONValue(List<string> v)
		{
			BSONArray bsonarray = new BSONArray();
			for (int i = 0; i < v.Count; i++)
			{
				bsonarray.Add(new BSONValue(v[i]));
			}
			return bsonarray;
		}

		// Token: 0x06001F5E RID: 8030 RVA: 0x000CCA4C File Offset: 0x000CAE4C
		public static implicit operator BSONValue(List<Vector2i> v)
		{
			byte[] array = new byte[v.Count * 8];
			for (int i = 0; i < v.Count; i++)
			{
				Buffer.BlockCopy(v[i].GetAsBinaryArray(), 0, array, i * 8, 8);
			}
			return new BSONValue(array);
		}

		public bool isNone
		{
			get { return mValueType == ValueType.None; }
		}

		public virtual BSONValue this[string key]
		{
			get { return null; }
			set { }
		}
		public virtual BSONValue this[int index]
		{
			get { return null; }
			set { }
		}
		public virtual void Clear() { }
		public virtual void Add(string key, BSONValue value) { }
		public virtual void Add(BSONValue value) { }
		public virtual bool Contains(BSONValue v) { return false; }
		public virtual bool ContainsKey(string key) { return false; }

		public static implicit operator BSONValue(double v)
		{
			return new BSONValue(v);
		}

		public static implicit operator BSONValue(Int32 v)
		{
			return new BSONValue(v);
		}

		public static implicit operator BSONValue(Int64 v)
		{
			return new BSONValue(v);
		}

		public static implicit operator BSONValue(byte[] v)
		{
			return new BSONValue(v);
		}

		public static implicit operator BSONValue(DateTime v)
		{
			return new BSONValue(v);
		}

		public static implicit operator BSONValue(string v)
		{
			return new BSONValue(v);
		}

		public static implicit operator BSONValue(bool v)
		{
			return new BSONValue(v);
		}


		public static implicit operator double(BSONValue v)
		{
			return v.doubleValue;
		}

		public static implicit operator Int32(BSONValue v)
		{
			return v.int32Value;
		}

		public static implicit operator Int64(BSONValue v)
		{
			return v.int64Value;
		}

		public static implicit operator byte[](BSONValue v)
		{
			return v.binaryValue;
		}

		public static implicit operator DateTime(BSONValue v)
		{
			return v.dateTimeValue;
		}

		public static implicit operator string(BSONValue v)
		{
			return v.stringValue;
		}

		public static implicit operator bool(BSONValue v)
		{
			return v.boolValue;
		}


		///
		protected BSONValue(ValueType valueType)
		{
			mValueType = valueType;
		}

		public BSONValue()
		{
			mValueType = ValueType.None;
		}

		public BSONValue(double v)
		{
			mValueType = ValueType.Double;
			_double = v;
		}

		public BSONValue(String v)
		{
			mValueType = ValueType.String;
			_string = v;
		}

		public BSONValue(byte[] v)
		{
			mValueType = ValueType.Binary;
			_binary = v;
		}

		public BSONValue(bool v)
		{
			mValueType = ValueType.Boolean;
			_bool = v;
		}

		public BSONValue(DateTime dt)
		{
			mValueType = ValueType.UTCDateTime;
			_dateTime = dt;
		}

		public BSONValue(Int32 v)
		{
			mValueType = ValueType.Int32;
			_int32 = v;
		}

		public BSONValue(Int64 v)
		{
			mValueType = ValueType.Int64;
			_int64 = v;
		}

		public static implicit operator List<int>(BSONValue v)
		{
			return v.int32ListValue;
		}

		// Token: 0x06001F67 RID: 8039 RVA: 0x000CCADE File Offset: 0x000CAEDE
		public static implicit operator List<long>(BSONValue v)
		{
			return v.int64ListValue;
		}

		// Token: 0x06001F68 RID: 8040 RVA: 0x000CCAE6 File Offset: 0x000CAEE6
		public static implicit operator List<string>(BSONValue v)
		{
			return v.stringListValue;
		}

		// Token: 0x06001F69 RID: 8041 RVA: 0x000CCAEE File Offset: 0x000CAEEE
		public static implicit operator List<Vector2i>(BSONValue v)
		{
			return v.vector2iListValue;
		}

		public static bool operator ==(BSONValue a, object b)
		{
			return System.Object.ReferenceEquals(a, b);
		}

		public static bool operator !=(BSONValue a, object b)
		{
			return !(a == b);
		}
	}


	public class BSONObject : BSONValue, IEnumerable, ICloneable
	{
		private Dictionary<string, BSONValue> mMap = new Dictionary<string, BSONValue>();

		public BSONObject(string ID = "")
			: base(BSONValue.ValueType.Object)
		{
			if (ID != "")
				this["ID"] = ID;
		}

		//
		// Properties
		//
		public ICollection<string> Keys
		{
			get { return mMap.Keys; }
		}

		public ICollection<BSONValue> Values
		{
			get { return mMap.Values; }
		}

		public object Clone()
		{
			return this.MemberwiseClone();
		}

		public int Count { get { return mMap.Count; } }

		//
		// Indexer
		//
		public override BSONValue this[string key]
		{
			get { return mMap[key]; }
			set { mMap[key] = value; }
		}
		//
		// Methods
		//
		public override void Clear()
		{
			mMap.Clear();
		}
		public override void Add(string key, BSONValue value)
		{
			mMap.Add(key, value);
		}


		public override bool Contains(BSONValue v)
		{
			return mMap.ContainsValue(v);
		}
		public override bool ContainsKey(string key)
		{
			return mMap.ContainsKey(key);
		}

		public bool Remove(string key)
		{
			return mMap.Remove(key);
		}

		public bool TryGetValue(string key, out BSONValue value)
		{
			return mMap.TryGetValue(key, out value);
		}


		IEnumerator IEnumerable.GetEnumerator()
		{
			return mMap.GetEnumerator();
		}
	}


	public class BSONArray : BSONValue, IEnumerable
	{

		List<BSONValue> mList = new List<BSONValue>();

		public BSONArray()
			: base(BSONValue.ValueType.Array)
		{
		}

		//
		// Indexer
		//
		public override BSONValue this[int index]
		{
			get { return mList[index]; }
			set { mList[index] = value; }
		}
		public int Count { get { return mList.Count; } }

		//
		// Methods
		//
		public override void Add(BSONValue v)
		{
			mList.Add(v);
		}

		public int IndexOf(BSONValue item)
		{
			return mList.IndexOf(item);
		}
		public void Insert(int index, BSONValue item)
		{
			mList.Insert(index, item);
		}
		public bool Remove(BSONValue v)
		{
			return mList.Remove(v);
		}
		public void RemoveAt(int index)
		{
			mList.RemoveAt(index);
		}
		public override void Clear()
		{
			mList.Clear();
		}

		public virtual bool Contains(BSONValue v)
		{
			return mList.Contains(v);
		}


		IEnumerator IEnumerable.GetEnumerator()
		{
			return mList.GetEnumerator();
		}
	}

	public class SimpleBSON
	{
		private MemoryStream mMemoryStream;
		private BinaryReader mBinaryReader;
		private BinaryWriter mBinaryWriter;

		public static BSONObject Load(byte[] buf)
		{
			SimpleBSON bson = new SimpleBSON(buf);

			return bson.decodeDocument();
		}

		public static byte[] Dump(BSONObject obj)
		{

			SimpleBSON bson = new SimpleBSON();
			MemoryStream ms = new MemoryStream();

			bson.encodeDocument(ms, obj);

			byte[] buf = new byte[ms.Position];
			ms.Seek(0, SeekOrigin.Begin);
			ms.Read(buf, 0, buf.Length);

			return buf;
		}

        public static string DumpBSON(BSONObject obj)
        {
            byte[] _obj = SimpleBSON.Dump(obj);
            BsonDocument bsonDocument = BsonSerializer.Deserialize<BsonDocument>(_obj);
            return bsonDocument.ToJson(new JsonWriterSettings { Indent = true });
        }


        private SimpleBSON(byte[] buf = null)
		{
			if (buf != null)
			{
				mMemoryStream = new MemoryStream(buf);
				mBinaryReader = new BinaryReader(mMemoryStream);
			}
			else
			{
				mMemoryStream = new MemoryStream();
				mBinaryWriter = new BinaryWriter(mMemoryStream);
			}
		}

		private BSONValue decodeElement(out string name)
		{
			byte elementType = mBinaryReader.ReadByte();

			if (elementType == 0x01)
			{ // Double
				name = decodeCString();
				return new BSONValue(mBinaryReader.ReadDouble());

			}
			else if (elementType == 0x02)
			{ // String
				name = decodeCString();
				return new BSONValue(decodeString());

			}
			else if (elementType == 0x03)
			{ // Document
				name = decodeCString();
				return decodeDocument();

			}
			else if (elementType == 0x04)
			{ // Array
				name = decodeCString();
				return decodeArray();

			}
			else if (elementType == 0x05)
			{ // Binary
				name = decodeCString();
				int length = mBinaryReader.ReadInt32();
				byte binaryType = mBinaryReader.ReadByte();

				return new BSONValue(mBinaryReader.ReadBytes(length));

			}
			else if (elementType == 0x08)
			{ // Boolean
				name = decodeCString();
				return new BSONValue(mBinaryReader.ReadBoolean());

			}
			else if (elementType == 0x09)
			{ // DateTime
				name = decodeCString();
				Int64 time = mBinaryReader.ReadInt64();
				return new BSONValue(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc) + new TimeSpan(time * 10000));
			}
			else if (elementType == 0x0A)
			{ // None
				name = decodeCString();
				return new BSONValue();
			}
			else if (elementType == 0x10)
			{ // Int32
				name = decodeCString();
				return new BSONValue(mBinaryReader.ReadInt32());
			}
			else if (elementType == 0x12)
			{ // Int64
				name = decodeCString();
				return new BSONValue(mBinaryReader.ReadInt64());
			}


			throw new Exception(string.Format("Don't know elementType={0}", elementType));
		}

		private BSONObject decodeDocument()
		{
			int length = mBinaryReader.ReadInt32() - 4;

			BSONObject obj = new BSONObject();

			int i = (int)mBinaryReader.BaseStream.Position;
			while (mBinaryReader.BaseStream.Position < i + length - 1)
			{
				string name;
				BSONValue value = decodeElement(out name);
				obj.Add(name, value);

			}

			mBinaryReader.ReadByte(); // zero
			return obj;
		}

		private BSONArray decodeArray()
		{
			BSONObject obj = decodeDocument();

			int i = 0;
			BSONArray array = new BSONArray();
			while (obj.ContainsKey(Convert.ToString(i)))
			{
				array.Add(obj[Convert.ToString(i)]);

				i += 1;
			}

			return array;
		}

		private string decodeString()
		{
			int length = mBinaryReader.ReadInt32();
			byte[] buf = mBinaryReader.ReadBytes(length);

			return Encoding.UTF8.GetString(buf);
		}

		private string decodeCString()
		{

			var ms = new MemoryStream();
			while (true)
			{
				byte buf = (byte)mBinaryReader.ReadByte();
				if (buf == 0)
					break;
				ms.WriteByte(buf);
			}

			return Encoding.UTF8.GetString(ms.GetBuffer(), 0, (int)ms.Position);
		}


		private void encodeElement(MemoryStream ms, string name, BSONValue v)
		{
			switch (v.valueType)
			{
				case BSONValue.ValueType.Double:
					ms.WriteByte(0x01);
					encodeCString(ms, name);
					encodeDouble(ms, v.doubleValue);
					return;
				case BSONValue.ValueType.String:
					ms.WriteByte(0x02);
					encodeCString(ms, name);
					encodeString(ms, v.stringValue);
					return;
				case BSONValue.ValueType.Object:
					ms.WriteByte(0x03);
					encodeCString(ms, name);
					encodeDocument(ms, v as BSONObject);
					return;
				case BSONValue.ValueType.Array:
					ms.WriteByte(0x04);
					encodeCString(ms, name);
					encodeArray(ms, v as BSONArray);
					return;
				case BSONValue.ValueType.Binary:
					ms.WriteByte(0x05);
					encodeCString(ms, name);
					encodeBinary(ms, v.binaryValue);
					return;
				case BSONValue.ValueType.Boolean:
					ms.WriteByte(0x08);
					encodeCString(ms, name);
					encodeBool(ms, v.boolValue);
					return;
				case BSONValue.ValueType.UTCDateTime:
					ms.WriteByte(0x09);
					encodeCString(ms, name);
					encodeUTCDateTime(ms, v.dateTimeValue);
					return;
				case BSONValue.ValueType.None:
					ms.WriteByte(0x0A);
					encodeCString(ms, name);
					return;
				case BSONValue.ValueType.Int32:
					ms.WriteByte(0x10);
					encodeCString(ms, name);
					encodeInt32(ms, v.int32Value);
					return;
				case BSONValue.ValueType.Int64:
					ms.WriteByte(0x12);
					encodeCString(ms, name);
					encodeInt64(ms, v.int64Value);
					return;
			};
		}

		private void encodeDocument(MemoryStream ms, BSONObject obj)
		{

			MemoryStream dms = new MemoryStream();
			foreach (string str in obj.Keys)
			{
				encodeElement(dms, str, obj[str]);
			}

			BinaryWriter bw = new BinaryWriter(ms);
			bw.Write((Int32)(dms.Position + 4 + 1));
			bw.Write(dms.GetBuffer(), 0, (int)dms.Position);
			bw.Write((byte)0);
		}

		private void encodeArray(MemoryStream ms, BSONArray lst)
		{

			var obj = new BSONObject();
			for (int i = 0; i < lst.Count; ++i)
			{
				obj.Add(Convert.ToString(i), lst[i]);
			}

			encodeDocument(ms, obj);
		}

		private void encodeBinary(MemoryStream ms, byte[] buf)
		{
			byte[] aBuf = BitConverter.GetBytes(buf.Length);
			ms.Write(aBuf, 0, aBuf.Length);
			ms.WriteByte(0);
			ms.Write(buf, 0, buf.Length);
		}

		private void encodeCString(MemoryStream ms, string v)
		{
			byte[] buf = new UTF8Encoding().GetBytes(v);
			ms.Write(buf, 0, buf.Length);
			ms.WriteByte(0);
		}

		private void encodeString(MemoryStream ms, string v)
		{

			byte[] strBuf = new UTF8Encoding().GetBytes(v);
			byte[] buf = BitConverter.GetBytes(strBuf.Length + 1);

			ms.Write(buf, 0, buf.Length);
			ms.Write(strBuf, 0, strBuf.Length);

			ms.WriteByte(0);
		}

		private void encodeDouble(MemoryStream ms, double v)
		{
			byte[] buf = BitConverter.GetBytes(v);
			ms.Write(buf, 0, buf.Length);
		}

		private void encodeBool(MemoryStream ms, bool v)
		{
			byte[] buf = BitConverter.GetBytes(v);
			ms.Write(buf, 0, buf.Length);
		}

		private void encodeInt32(MemoryStream ms, Int32 v)
		{
			byte[] buf = BitConverter.GetBytes(v);
			ms.Write(buf, 0, buf.Length);
		}
		private void encodeInt64(MemoryStream ms, Int64 v)
		{
			byte[] buf = BitConverter.GetBytes(v);
			ms.Write(buf, 0, buf.Length);
		}
		private void encodeUTCDateTime(MemoryStream ms, DateTime dt)
		{
			TimeSpan span;
			if (dt.Kind == DateTimeKind.Local)
			{
				span = (dt - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).ToLocalTime());
			}
			else
			{
				span = dt - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
			}
			byte[] buf = BitConverter.GetBytes((Int64)(span.TotalSeconds * 1000));
			ms.Write(buf, 0, buf.Length);
		}
	}
}

