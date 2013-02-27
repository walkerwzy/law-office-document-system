using System;
using System.Collections.Generic;
using System.Text;

namespace Helper
{
    public class HelperJS
    {
        private static readonly string redirect = "window.location.href=";

        public HelperJS()
        { }

        public static string InitFunction(string str)
        {
            return "<script>"+str+"</script>";
        }
        public static string DoFunction(string function)
        {
            return "<script>" + function + "</script>";
        }

        public static string AlertMsg(string msg)
        {
            return "<script>alert('" + msg + "');</script>";
        }

        public static string AlertMsg(string msg,bool isFunction)
        {
            if (isFunction)
            {
                return "<script>alert('" + msg + "');</script>";
            }
            else
            {
                return "alert('" + msg + "');";
            }
        }

        public static string RedirectUrl(string url)
        {
            return InitFunction(redirect+"'"+url+"';");
        }

        public static string Refresh()
        {
            return InitFunction("window.location = reload;");
        }
    }
}
