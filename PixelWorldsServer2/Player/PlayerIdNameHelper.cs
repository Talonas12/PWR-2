using System;

namespace PWS
{
    public static class PlayerIdNameHelper
	{
		// Token: 0x06001ED8 RID: 7896 RVA: 0x000CA096 File Offset: 0x000C8496
		public static string CombineIdAndName(string playerId, string name)
		{
			return playerId + PlayerIdNameHelper.splitChar + name;
		}

		// Token: 0x06001ED9 RID: 7897 RVA: 0x000CA0A9 File Offset: 0x000C84A9
		public static string[] SplitCombined(string combinedString)
		{
			return combinedString.Split(new char[]
			{
			PlayerIdNameHelper.splitChar
			});
		}

		// Token: 0x06001EDA RID: 7898 RVA: 0x000CA0BF File Offset: 0x000C84BF
		public static string GetPlayerIdFromCombined(string combinedString)
		{
			return combinedString.Split(new char[]
			{
			PlayerIdNameHelper.splitChar
			})[0];
		}

		// Token: 0x06001EDB RID: 7899 RVA: 0x000CA0D7 File Offset: 0x000C84D7
		public static string GetPlayerNameFromCombined(string combinedString)
		{
			return combinedString.Split(new char[]
			{
			PlayerIdNameHelper.splitChar
			})[1];
		}

		// Token: 0x06001EDC RID: 7900 RVA: 0x000CA0F0 File Offset: 0x000C84F0
		public static bool IsValidCombined(string combinedString)
		{
			int num = -1;
			for (int i = 0; i < combinedString.Length; i++)
			{
				if (combinedString[i] == PlayerIdNameHelper.splitChar)
				{
					if (num != -1)
					{
						return false;
					}
					num = i;
				}
			}
			return num >= 1 && num != combinedString.Length - 1;
		}

		// Token: 0x06001EDD RID: 7901 RVA: 0x000CA15F File Offset: 0x000C855F
		public static char GetSplitChar()
		{
			return PlayerIdNameHelper.splitChar;
		}

		// Token: 0x0400212A RID: 8490
		private static readonly char splitChar = ';';
	}

}