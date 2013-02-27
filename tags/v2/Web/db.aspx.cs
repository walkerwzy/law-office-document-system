using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.IO;

public partial class db : validateUser
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            XDocument xdoc = Utility.getConfigFile();
            txtdb.Text = xdoc.Root.Descendants("dbpath").SingleOrDefault().Value;
        }
    }
    protected void godb(object sender, EventArgs e)
    {
        if (!System.IO.Directory.Exists(txtdb.Text))
        {
            System.IO.Directory.CreateDirectory(txtdb.Text);
        }
        try
        {
            System.Diagnostics.Process.Start(txtdb.Text);
        }
        catch (Exception ex)
        {
            alert("操作失败，原因：" + ex.Message);
        }
    }
    protected void beckupclick(object sender, EventArgs e)
    {
        try
        {
            WZY.DAL.tools.beckupDB(txtdb.Text);
        }
        catch (Exception ex)
        {
            alert(ex.Message);
        }
        alert("备份成功，打开文件夹查看");
    }
    protected void recoveryclick(object sender, EventArgs e)
    {
        if (!fu.HasFile)
        {
            alert("请选择需要恢复的数据库备份文件，本系统默认以bak为扩展名");
            return;
        }
        string extName = System.IO.Path.GetExtension(fu.FileName).ToLower(); //获取文件扩展名
        if (extName != ".bak")
        {
            alert("请选择扩展名为.bak的文件！");
            return;
        }
        try
        {
            WZY.DAL.tools.recoveryDB(fu.PostedFile.FileName);
            alert("恢复数据库成功");
        }
        catch (Exception ex)
        {
            alert(ex.Message);
        }
    }
}