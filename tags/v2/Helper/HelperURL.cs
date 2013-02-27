using System;
using System.Web;
using System.Web.UI;

namespace Helper
{
	/// <summary>
	/// HelperURL
	/// </summary>
	public class HelperURL
	{
		private HelperURL(){}

		#region Url Helper Method

        /// <summary>
        /// 获得当前网址
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static string GetCurrentUrl(Page page)
        {
            string protocol;
            string https;
            string ip;
            string port;
            string path;
            string url;
            int result = 0;
            protocol = page.Request.ServerVariables["SERVER_PROTOCOL"];
            ip = page.Request.ServerVariables["SERVER_NAME"];
            port = page.Request.ServerVariables["SERVER_PORT"];
            path = page.Request.ServerVariables["PATH_INFO"];
            https = "https";

            //result = StrComp(protocol,https,1);
            if (result == 1)
            {
                protocol = "https://";
            }
            else
            {
                protocol = "http://";
            }

            if (port == "80")
            {
                port = "";
            }
            else
            {
                port = ":" + port;
            }

            url = protocol + ip + port + path;

            return url;
        }
		public static int GetIntFromUrlString(string key)
		{
			int returnValue = -1 ;
			string queryStringValue = String.Empty  ;
			
			try
			{ 
				queryStringValue = System.Web.HttpContext.Current.Request.QueryString[key] ;
				if((queryStringValue == null)||(queryStringValue == string.Empty))
					return returnValue;
				returnValue = Convert.ToInt32(queryStringValue);
			}
			catch 
			{
				throw new Exception("Wrong QueryString");
			}
			return returnValue ;
		} 	

		public static string GetStrFromUrlString(string key)
		{
			string queryStringValue = String.Empty  ;
			
			try
			{ 
				queryStringValue = System.Web.HttpContext.Current.Request.QueryString[key] ;
				if((queryStringValue == null)||(queryStringValue == string.Empty))
					return null;
			}
			catch 
			{
				throw new Exception("Wrong QueryString");
			}
			return queryStringValue ;
		} 	

		public static void Transfer(string url)
		{
			HttpContext.Current.Server.Transfer(url);
		}
		
		public static void Redirect(string url)
		{
			HttpContext.Current.Response.Redirect(url);
		}

		public static string GetShowWindowString(string url)
		{
			return "window.open('"+url+"','','menubar=no,width=1000,height=600,top=5,left=2,scrollbars=yes,status=no,resizable=yes,address=no')";
		}

		public static string GetShowWindowString(string openAspxPage,int width,int height)
		{
			string js = string.Format("window.open('{0}','window','status:false;dialogWidth:{1}px;dialogHeight:{2}px');",openAspxPage,width,height);
			return js;
		}
		
		public static string GetShowWindowModalString(string url)
		{
			return "window.showModalDialog(\""+url+"?open=1&temp="+Guid.NewGuid()+"\",null,\"dialogHeight:500px; dialogWidth:950px; edge: Raised; center: Yes; help: no; resizable: no; status: no;\");";
		}

		public static string GetShowWindowModalStringWithParams(string url)
		{
			return "window.showModalDialog(\""+url+"&open=1&temp="+Guid.NewGuid()+"\",null,\"dialogHeight:500px; dialogWidth:950px; edge: Raised; center: Yes; help: no; resizable: no; status: no;\");";
		}
		
		public static string GetShowWindowModalString(string url,int width,int height)
		{
			string js = string.Format("javascript:window.showModalDialog('{0}?temp="+Guid.NewGuid()+ "',window,'status:false;dialogWidth:{1}px;dialogHeight:{2}px');",url,width,height);
			return js;
		}

		public static string GetShowWindowModalStringWithParams(string url,int width,int height)
		{
			string js = string.Format("javascript:window.showModalDialog('{0}&temp="+Guid.NewGuid()+"',null,\"dialogHeight:{1}px; dialogWidth:{2}px; edge: Raised; center: Yes; help: no; resizable: no; status: no;\");",url,width,height);
			return js;
		}
		
		public static string GetHrefPopUp(string url,int width,int height,string href)
		{
			string str = string.Format("<a href='#' onclick=\"ShowModel('{0}',{1},{2});\">{3}</a>",url,width,height,href);
			return str;
		}
		
		public static string GetRefreshString()
		{
			return "window.document.forms[0].submit();";
		}
		#endregion
	}
}
