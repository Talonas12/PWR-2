using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWS
{
    public static class ProfanityFilter
    {
		public static void StripTags(ref string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				text = "";
				return;
			}

			if (text.Length > 0 && text[text.Length - 1].Equals('>'))
			{
				int num = text.Length - 1;
				while (num != 0)
				{
					if (text[num - 1].Equals('<'))
					{
						if (!text[num].Equals('/') && text.LastIndexOf("<sprite=\"emj\" name=\"") != num - 1)
						{
							text = string.Empty;
							return;
						}
						break;
					}
					else
					{
						num--;
					}
				}
			}
			string[] array = new string[]
			{
			"cspace",
			"font",
			"indent",
			"line-height",
			"line-indent",
			"link",
			"margin",
			"mspace",
			//"noparse",
			"page",
			"pos",
			"space",
			"style",
			"voffset",
			"width",
			"size",
			"scale"
			};
			for (int i = 0; i < array.Length; i++)
			{
				string text2 = "<" + array[i];
				for (int num2 = text.IndexOf(text2); num2 != -1; num2 = text.IndexOf(text2))
				{
					int num3 = text2.Length;
					bool flag = false;
					while (num2 + num3 < text.Length && !flag)
					{
						if (text[num2 + num3].Equals('>'))
						{
							flag = true;
						}
						num3++;
					}
					if (flag)
					{
						text = text.Remove(num2, num3);
					}
				}
			}
		}
	}
}
