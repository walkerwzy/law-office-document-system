using System.Data;
using System.Web;
using System.Xml.Linq;

public static class Utility
{
    public static XDocument getConfigFile()
    {
        if (Helper.HelperCache.GetCache("xmlconfig") == null)
        {
            string path = HttpContext.Current.Server.MapPath("~/configuration/site.xml");
            XDocument xdoc = XDocument.Load(path);
            Helper.HelperCache.Insert("xmlconfig", xdoc, path);
        }
        return Helper.HelperCache.GetCache("xmlconfig") as XDocument;
    }

    public static DataSet FilterData(DataSet source, string filter)
    {
        if (source == null)
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(new DataTable());
            return ds;
        }
        if (source.Tables.Count == 0)
        {
            source.Tables.Add(new DataTable());
            return source;
        }
        if (source.Tables[0].Rows.Count == 0)
        {
            return source;
        }
        if (string.IsNullOrEmpty(filter.Trim()))
        {
            return source;
        }
        var dv = source.Tables[0].DefaultView;
        string order;
        filter = ParseOrderBy(filter, out order);
        dv.RowFilter = filter;
        dv.Sort = order;
        var dt = dv.ToTable();
        var ds2 = new DataSet();
        ds2.Tables.Add(dt);
        return ds2;
    }

    private static string ParseOrderBy(string filter, out string order)
    {
        var i = filter.IndexOf("order by");
        if (i < 0)
        {
            order = "";
            return filter;
        }
        order = filter.Substring(filter.IndexOf("order by"));
        order = order.Replace("order by", "");
        return filter.Substring(0, i);
    }
}