using System;


namespace Helper
{
	/// <summary>
	/// HelperMessage
	/// </summary>
	public class HelperMessage
	{
		private HelperMessage(){}

		public static void Message(string input)
		{
          // System.Web.UI.ClientScriptManager cm=
			System.Web.HttpContext.Current.Response.Write(alertMessage(input));
		}

		public static void MessageUrl(string input, string goUrl)
		{
			string output = alertMessage(input)+alertUrl(goUrl);
			System.Web.HttpContext.Current.Response.Write(output);
		}

		private static string alertMessage(string _input)
		{
			return "<script>alert('"+_input+"');</script>";
		}

		private static string alertUrl(string _url)
		{
			return "<script>window.parent.location='"+_url+"'</script>";
		}
      
	}
}
