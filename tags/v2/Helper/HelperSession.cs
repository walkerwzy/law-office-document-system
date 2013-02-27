using System;
using System.Web;
using System.Web.Security;
namespace Helper
{
	/// <summary>
	/// HelperSession
	/// </summary>
	public class HelperSession
	{
		private HelperSession(){}

		#region Set/Get in Session
		public static int GetSessionInt(string field)
		{
			return Convert.ToInt32(HttpContext.Current.Session[field].ToString(),10);
		}

		public static string GetSessionString(string field)
		{
			return HttpContext.Current.Session[field].ToString();
		}
			
		public static void SetSession(string field,string value)
		{
			HttpContext.Current.Session[field]=value;
		}

		public static void SetSession(string field,int value)
		{
			HttpContext.Current.Session[field]=value;
		}

		#endregion

		public static int GetAuthenticatedUserID()
		{
			return HelperDigit.ConvertToInt32(System.Web.HttpContext.Current.User.Identity.Name);
		}

        public static string GetAuthenticatedUserName()
        {
            return System.Web.HttpContext.Current.User.Identity.Name;
        }

        public static string[] GetAuthenticatedUserData()
        {
            string[] role = null;
           
            try
            {
                string cookieName = FormsAuthentication.FormsCookieName;
                HttpCookie authCookie = HttpContext.Current.Request.Cookies[cookieName];
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                role=authTicket.UserData.Split(new char[] {','});
            }
            catch
            {
               role=new string[1];
            }
            return role;
        }

        public static string[] GetAuthenticatedUserData(string split)
        {
            string[] role = null;

            try
            {
                string cookieName = FormsAuthentication.FormsCookieName;
                HttpCookie authCookie = HttpContext.Current.Request.Cookies[cookieName];
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                role = authTicket.UserData.Split(split.ToCharArray());
            }
            catch
            {
                role = new string[1];
            }
            return role;
        }

        public static string GetAuthenticatedUserUnit()
        {
            string userunit = "-1";
            try
            {
                string cookieName = FormsAuthentication.FormsCookieName;
                HttpCookie authCookie = HttpContext.Current.Request.Cookies[cookieName];
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                string[] userdata = authTicket.UserData.Split(new char[] { ',' });
                userunit = userdata[0];
            }
            catch
            { }
            return userunit;
        }
	}
}
