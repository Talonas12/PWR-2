using System;

namespace PWS.DataManagement
{
	public class KeyTriple<T1, T2, T3>
	{
		public T1 Key { get; set; }
		public T2 Value1 { get; set; }
		public T3 Value2 { get; set; }

		public KeyTriple(T1 key, T2 value1, T3 value2)
		{
			this.Key = key;
			this.Value1 = value1;
			this.Value2 = value2;
		}
	}
}
