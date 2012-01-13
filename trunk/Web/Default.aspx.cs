using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Lunar;

public partial class _Default : validateUser
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lbluser.Text = suser.displayname;
            Lunar.Lunar today = LunarApi.GetLunarDate(DateTime.Today);
            lbltime.Text = DateTime.Today.ToString("yyyy年MM月dd日 农历：" + LunarApi.GetLunarYearString(today.Year) + "年" + LunarApi.GetLunarMonthString(today.Year, today.Month) + LunarApi.GetLunarDayString(today.Day));
        }
    }

    protected void clearcache(object sender, EventArgs e)
    {
        try
        {
            string parentFolder = Server.MapPath("~/Temp/Prev/");
            if (!Directory.Exists(parentFolder))
            {
                return;
            }
            DirectoryInfo directory = new DirectoryInfo(parentFolder);
            DirectoryInfo[] ds = directory.GetDirectories();
            if (ds.Length == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "", "alert('清除缓存成功');", true);
                return;
            }
            foreach (DirectoryInfo d in ds)
            {
                DateTime now = DateTime.Now;
                if (d.CreationTime.Year < now.Year)
                {
                    //删除不是同一年创建的文件夹
                    d.Delete(true);
                }
                else if (d.CreationTime.Month < now.Month)
                {
                    //删除当月以前创建的文件夹
                    d.Delete(true);
                }
            }
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "", "alert('清除缓存成功');", true);
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "", "alert('清除缓存成功');", true);
        }
    }
}