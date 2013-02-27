using System;

namespace Helper
{
	/// <summary>
	/// HelperFormatter
	/// </summary>
	public class HelperFormatter: ICustomFormatter, IFormatProvider 
	{
		private HelperFormatter(){}

		public object GetFormat(Type format) 
		{ 
			if (format == typeof (ICustomFormatter)) 
				return this; 
			return null; 
		} 
 
		public string Format (string format, object arg, IFormatProvider provider) 
		{ 
			if (format == null) 
			{ 
				if (arg is IFormattable) 
					return ((IFormattable)arg).ToString(format, provider); 
				return arg.ToString(); 
			} 
			else 
			{ 
				if (format=="HelperFormatter")   
				{ 
					return "***"+arg.ToString(); 
				} 
				else 
				{ 
					if (arg is IFormattable) 
						return ((IFormattable)arg).ToString(format, provider); 
					return arg.ToString(); 
				} 
			} 
		}
	}
}
