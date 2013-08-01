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
        if (!int.TryParse(Request.QueryString["custid"], out custid))
        {
            Response.Write("参数错误");
            Response.End();
        }
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
}