using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Web;

    public static class Utility
    {
        public static XDocument getConfigFile()
        {
            if (Helper.HelperCache.GetCache("xmlconfig")==null)
            {
                string path = HttpContext.Current.Server.MapPath("~/configuration/site.xml");
                XDocument xdoc = XDocument.Load(path);
                Helper.HelperCache.Insert("xmlconfig", xdoc, path);
            }
            return Helper.HelperCache.GetCache("xmlconfig") as XDocument;
        }
    }