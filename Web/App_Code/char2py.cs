using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;

/// <summary>
///char2py 的摘要说明
/// </summary>

public static class char2py
{
    public static string CVT(string str)
    {
        if (str.CompareTo("吖") < 0)
        {
            string s = str.Substring(0, 1).ToUpper();
            //if (char.IsNumber(s, 0))
            //{
            //    return s;// "0";
            //}
            //else
            //{
            return s;
            //}

        }
        else if (str.CompareTo("八") < 0)
        {
            return "A";
        }
        else if (str.CompareTo("嚓") < 0)
        {
            return "B";
        }
        else if (str.CompareTo("咑") < 0)
        {
            return "C";
        }
        else if (str.CompareTo("妸") < 0)
        {
            return "D";
        }
        else if (str.CompareTo("发") < 0)
        {
            return "E";
        }
        else if (str.CompareTo("旮") < 0)
        {
            return "F";
        }
        else if (str.CompareTo("铪") < 0)
        {
            return "G";
        }
        else if (str.CompareTo("讥") < 0)
        {
            return "H";
        }
        else if (str.CompareTo("咔") < 0)
        {
            return "J";
        }
        else if (str.CompareTo("垃") < 0)
        {
            return "K";
        }
        else if (str.CompareTo("嘸") < 0)
        {
            return "L";
        }
        else if (str.CompareTo("拏") < 0)
        {
            return "M";
        }
        else if (str.CompareTo("噢") < 0)
        {
            return "N";
        }
        else if (str.CompareTo("妑") < 0)
        {
            return "O";
        }
        else if (str.CompareTo("七") < 0)
        {
            return "P";
        }
        else if (str.CompareTo("亽") < 0)
        {
            return "Q";
        }
        else if (str.CompareTo("仨") < 0)
        {
            return "R";
        }
        else if (str.CompareTo("他") < 0)
        {
            return "S";
        }
        else if (str.CompareTo("哇") < 0)
        {
            return "T";
        }
        else if (str.CompareTo("夕") < 0)
        {
            return "W";
        }
        else if (str.CompareTo("丫") < 0)
        {
            return "X";
        }
        else if (str.CompareTo("帀") < 0)
        {
            return "Y";
        }
        else if (str.CompareTo("咗") < 0)
        {
            return "Z";
        }
        else
        {
            return "0";
        }


    }

    public static string toPinYin(this string source)
    {
        char[] inc = source.ToCharArray();
        string ouc = "";
        foreach (char item in inc)
        {
            ouc += CVT(item.ToString()).ToUpper();
        }
        return ouc;
    }

}
