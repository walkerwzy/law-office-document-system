using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class path : validateUser
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            XDocument xdoc = Utility.getConfigFile();
            txtupload.Text = xdoc.Root.Descendants("uploadpath").SingleOrDefault().Value;
            txtbeckup.Text = xdoc.Root.Descendants("beckpath").SingleOrDefault().Value;
            txtlog.Text = xdoc.Root.Descendants("logpath").SingleOrDefault().Value;
        }
    }
    protected void golog(object sender, EventArgs e)
    {
        try
        {
            System.Diagnostics.Process.Start(txtlog.Text);
        }
        catch (Exception ex)
        {
            alert("操作失败，原因：" + ex.Message);
        }
    }
    protected void goupload(object sender, EventArgs e)
    {
        try
        {
            System.Diagnostics.Process.Start(txtupload.Text);
        }
        catch (Exception ex)
        {
            alert("操作失败，原因：" + ex.Message);
        }
    }
    protected void gobeckup(object sender, EventArgs e)
    {
        try
        {
            System.Diagnostics.Process.Start(txtbeckup.Text);
        }
        catch (Exception ex)
        {
            alert("操作失败，原因：" + ex.Message);
        }
    }
}