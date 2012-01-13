using System;

namespace Helper
{
	/// <summary>
	/// Summary description for HelperEnum.
	/// </summary>
	public class HelperEnum
	{
		private HelperEnum() {}

		public static string GetEnumNameByValue(Type enumType,object enumObject)
		{
			return Enum.GetName(enumType, enumObject).Replace("_"," ");
		}
	}
}
