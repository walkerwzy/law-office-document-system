using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Web.UI.WebControls;
using System.Globalization;

/// <summary>
///tools 的摘要说明
/// </summary>
public static class tools
{
    /// <summary>
    /// 将Unix时间戳转换为DateTime类型时间
    /// </summary>
    /// <param name="d">double 型数字</param>
    /// <returns>DateTime</returns>
    public static DateTime ConvertIntDateTime(double d)
    {
        DateTime time = DateTime.MinValue;
        DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        time = startTime.AddSeconds(d);
        return time;
    }

    /// <summary>
    /// 将c# DateTime时间格式转换为Unix时间戳格式
    /// </summary>
    /// <param name="time">时间</param>
    /// <returns>double</returns>
    public static double ConvertDateTimeInt(DateTime time)
    {
        double intResult = 0;
        DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        intResult = (time - startTime).TotalSeconds;
        return intResult;
    }

    /// <summary>
    /// 将毫秒表示的时间戳转换为DateTime类型时间
    /// </summary>
    /// <param name="d">double 型数字</param>
    /// <returns>DateTime</returns>
    public static DateTime ConvertMMIntDateTime(double d)
    {
        DateTime time = DateTime.MinValue;
        DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
        time = startTime.AddMilliseconds(d);
        return time;
    }

    public static string md5(string str)
    {
        MD5 m = new MD5CryptoServiceProvider();
        byte[] s = m.ComputeHash(UnicodeEncoding.UTF8.GetBytes(str));
        return BitConverter.ToString(s);
    }

    public static string toMD5(this string str)
    {
        return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5");
    }

    public static string tosha1(this string str)
    {
        return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "sha1");
    }

    public static string ToBase64(this string srcStr)
    {
        byte[] b = System.Text.Encoding.UTF8.GetBytes(srcStr);
        return Convert.ToBase64String(b);
    }

    public static string FromBase64(this string base64str)
    {
        byte[] b = Convert.FromBase64String(base64str);
        return System.Text.Encoding.UTF8.GetString(b);
    }

    //生成列表里显示用的下载、预览和删除链接
    public static string getDocViewDel(int docno, bool candel)
    {
        string fmt = "<a href='ProcessFile.aspx?act=download&d={0}' target='_blank' class='icona'><img title='下载' src='/images/download.gif' alt='' /></a>&nbsp;<a href='ProcessFile.aspx?act=preview&d={0}' target='_blank' class='icona'><img src='/images/preview.gif' title='预览' alt='' /></a>";
        if (candel)
        {
            fmt += "&nbsp;<a href='javascript:void(0);' class='icona' onclick=\"deldoc({0});\"><img title='删除' src='/images/delete.gif' alt='' /></a>";
        }
        if (docno == -1)
        {
            return "尚未上传";
        }
        return string.Format(fmt, docno);
    }

    public static void addAdminOption(DropDownList ddl)
    {
        ddl.Items.Add(new ListItem("全部数据"));
    }

}