using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Linq;

/// <summary>
/// FlowControl 的摘要说明
/// </summary>
public class FlowControl
{
    public FlowControl()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public static void SaveLoginInfo(string userid, string userdata)
    {
        var t = Utility.getConfigFile().Root.Descendants("cookietimeout").SingleOrDefault().Value;
        int timeout = 20;
        int.TryParse(t, out timeout);
        string permission = userdata;// ManageUser.GetPermissionAction(userid, true);
        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
          1,//version
          userid,//user name
          System.DateTime.Now,//login time
          DateTime.Now.AddMinutes(timeout),// Expiration
          false,//persistent
          permission//user data
          );
        //Entrcy Ticket
        string entrcyedTicket = FormsAuthentication.Encrypt(authTicket);

        //create a cookie and save entrcyed authticket date to the cookie
        HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, entrcyedTicket);
        // Add the cookie to the outgoing cookies collection. 
        HttpContext.Current.Response.Cookies.Add(authCookie);

        //Redirect the user to originally requested page

        // HttpContext.Current.Response.Redirect(FormsAuthentication.GetRedirectUrl(userid, true));

    }

    public static void Logout()
    {
        FormsAuthentication.SignOut();
        HttpContext.Current.Session.Clear();
        HttpContext.Current.Session.Abandon();
        //HttpContext.Current.Response.Redirect(ConstantControl.REDIRECT_LOGIN, false);

    }
}
