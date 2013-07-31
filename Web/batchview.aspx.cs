using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*
 * 本页面用于查看案件附加文档/用户维护日志原始资料 * 
 */
public partial class batchview : validateUser
{
    private bool casefile = true;
    private int caseid = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        //custid needed
        if (IsPostBack) return;
        if (!int.TryParse(Request.QueryString["id"], out caseid))
        {
            Response.Write("参数错误");
            Response.End();
        }
        hidid.Value = caseid.ToString();
        casefile = Request.QueryString["type"] == "case";
        binddata();
    }

    private void binddata()
    {
        var prefix = casefile ? "case:" : "log:";
        var filter = " remark='" + prefix + hidid.Value + "'";

        AspNetPager1.RecordCount = new WZY.DAL.DOCS().GetRecordCount(filter);
        AspNetPager1.PageSize = 15;// cfg.pagesize;

        //filter += " order by uptime desc ";

        ods.SelectParameters[0].DefaultValue = filter;
        gridlist.DataSourceID = "ods";
    }


    protected void gvdatabind(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView dr = e.Row.DataItem as DataRowView;
            //删除权限仅支持【本人数据，部门负责人：部门数据，管理员：全部数据】
            bool candel = dr["uid"].ToString() == suser.uid.ToString() || (dr["deptid"].ToString() == suser.deptid.ToString() && suser.roleid == 1) || suser.roleid == 0;
            e.Row.Cells[4].Text = tools.getDocViewDel(Convert.ToInt32(dr["docid"]), candel);
            (e.Row.Cells[0].FindControl("hidcandel") as HiddenField).Value = candel ? "1" : "0";
        }
    }
}