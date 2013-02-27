using System;

namespace Helper
{
	/// <summary>
	/// HelperInt
	/// </summary>
	public class HelperDigit
	{
		private HelperDigit(){}

		public static double ConvertToDouble(string inputString)
		{
			try
			{
				if ((inputString != null) && (inputString != String.Empty))
				{
					return Convert.ToDouble(inputString);
				}
				else
				{
					return 0;
				}
			}
			catch 
			{
				return 0;
			}
		}
		
 public static double ConvertToDouble(string inputString,double defvalue)
        {
            try
            {
                if ((inputString != null) && (inputString != String.Empty))
                {
                    return Convert.ToDouble(inputString);
                }
                else
                {
                    return defvalue;
                }
            }
            catch
            {
                return defvalue;
            }
        }

		public static int ConvertToInt32(string inputString)
		{
			try
			{
				if ((inputString != null) && (inputString != String.Empty))
				{
					return Convert.ToInt32(inputString);
				}
				else
				{
					return 0;
				}
			}
			catch 
			{
				return 0;
			}
		}

		 public static int ConvertToInt32(string inputString,int defvalue)
        {
            try
            {
                if ((inputString != null) && (inputString != String.Empty))
                {
                    return Convert.ToInt32(inputString);
                }
                else
                {
                    return defvalue;
                }
            }
            catch
            {
                return defvalue;
            }
        }
		public static int ConvertToInt32(object inputString)
		{
			return ConvertToInt32(inputString.ToString());
		}

		public static short ConvertToShort(string inputString)
		{
			try
			{
				if ((inputString != null) && (inputString != String.Empty))
				{
					return Convert.ToInt16(inputString);
				}
				else
				{
					return 0;
				}
			}
			catch 
			{
				return 0;
			}
		}
	}
}
