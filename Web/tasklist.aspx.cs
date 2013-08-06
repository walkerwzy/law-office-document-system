using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class tasklist : validateUser
{
    private int custid = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        if (Request.QueryString["act"] == "del") del();
        if (!int.TryParse(Request.QueryString["custid"], out custid))
        {
            Response.Write("参数错误");
            Response.End();
        }
        hidcustid.Value = Request.QueryString["custid"];
        hidcustname.Value = Request.QueryString["custname"];
        bindData();
    }

    private void bindData()
    {
        string filter = " custid=" + custid;

        AspNetPager1.RecordCount = new WZY.DAL.tasklog().GetRecordCount(filter);
        AspNetPager1.PageSize = 13;// cfg.pagesize;
        ods.SelectParameters[0].DefaultValue = filter;
        gridlist.DataSourceID = "ods";
    }

    protected void del()
    {
        Response.Clear();
        Response.ContentType = "text/plain";
        var id = Request.QueryString["id"];
        var usera = Request.QueryString["userid"];
        var userb = Request.QueryString["agentid"];
        var depta = Request.QueryString["depta"];
        var deptb = Request.QueryString["deptb"];
        try
        {

            if (usera == suser.uid.ToString() || userb == suser.uid.ToString()
                || ((depta == suser.deptid.ToString() || deptb == suser.deptid.ToString()) && suser.roleid == 1)
                || suser.roleid == 0)
            {
                new WZY.DAL.tasklog().Delete(int.Parse(id));
                Response.Write("1");
            }
        }
        catch (Exception ex)
        {
            Helper.log.error("删除业务交接记录：" + id + "时出错", ex.Message);
            Response.Write(ex.Message.Replace("'", "").Replace("\"", ""));
        }
        Response.End();
    }
}