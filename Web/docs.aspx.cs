using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class docs : validateUser
{
    WZY.DAL.SYSUSER userbll = new WZY.DAL.SYSUSER();
    WZY.DAL.CUSTOMER custbll = new WZY.DAL.CUSTOMER();
    WZY.DAL.DOCS docbll = new WZY.DAL.DOCS();
    protected bool usecustid = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["custid"])) usecustid = true;
        if (!IsPostBack)
        {
            Helper.HelperDropDownList.BindData(ddlcate, new WZY.DAL.CATE_DOC().GetList(" 1=1 order by seq ").Tables[0], "catename", "cateid", 0, true);
            Helper.HelperDropDownList.BindData(ddltype, new WZY.DAL.cate_yewu().GetList(" 1=1 order by cate_index").Tables[0], "cate_name", "cate_id", 0, true);
            if (suser.roleid == 0 || suser.roleid == 1)
            {
                tools.addAdminOption(ddlrange);
            }
            if (cfg.depart)
            {
                ddlrange.SelectedIndex = 1;
            }
            bindData();
        }
    }

    private void bindData()
    {
        string filter = " 1=1 ";
        if (usecustid)
        {
            filter += " and custid=" + Request["custid"];
        }
        else
        {
            if (!string.IsNullOrEmpty(txtcust.Value.Trim()))
            {
                filter += " and custname like '%" + txtcust.Value.Trim() + "%' ";
            }
            if (!string.IsNullOrEmpty(txtuser.Value.Trim()))
            {
                filter += " and displayname like '%" + txtuser.Value.Trim() + "%' ";
            }
            if (!string.IsNullOrEmpty(txtfilename.Value.Trim()))
            {
                filter += " and docname like '%" + txtfilename.Value.Trim() + "%' ";
            }
            if (!string.IsNullOrEmpty(txtsdate.Value.Trim()))
            {
                filter += " and uptime >= '" + txtsdate.Value.Trim() + "' ";
            }
            if (!string.IsNullOrEmpty(txtedate.Value.Trim()))
            {
                filter += " and uptime <= '" + txtedate.Value.Trim() + "' ";
            }
            if (ddlcate.SelectedIndex > 0)
            {
                filter += " and cateid=" + ddlcate.Text;
            }
            if (!cbxCase.Checked)
            {
                filter += " and cateid<>7 ";
            }
            if (ddltype.SelectedIndex>0)
            {
                filter += " and typeid=" + ddltype.Text;
            }
            switch (ddlrange.SelectedIndex)
            {
                case 0:
                    filter += " and uid=" + suser.uid;
                    break;
                case 1:
                    filter += " and deptid=" + suser.deptid;
                    break;
                case 2:
                default:
                    break;
            }
        }
        filter += " order by uptime desc ";

        ods.SelectParameters[0].DefaultValue = filter;
        gridlist.DataSourceID = "ods";

        AspNetPager1.RecordCount = new WZY.DAL.DOCS().GetList(filter).Tables[0].Rows.Count;
        AspNetPager1.PageSize = cfg.pagesize;
    }

    protected void gvdatabind(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView dr = e.Row.DataItem as DataRowView;
            //e.Row.Cells[1].Text = userbll.GetModel(Convert.ToInt32(dr["uid"])).displayname;
            //e.Row.Cells[3].Text = custbll.GetModel(Convert.ToInt32(dr["custid"])).custname;
            //删除权限仅支持本人数据，部门负责人：部门数据，管理员：全部数据
            bool candel = false;
            if (dr["uid"].ToString() == suser.uid.ToString() || (dr["deptid"].ToString() == suser.deptid.ToString() && suser.roleid == 1) || suser.roleid == 0)
            { candel = true; }
            e.Row.Cells[6].Text = tools.getDocViewDel(Convert.ToInt32(dr["docid"]), candel);
            (e.Row.Cells[0].FindControl("hidcandel") as HiddenField).Value = candel ? "1" : "0";
        }
    }
    
    protected void btnsearch(object sender, EventArgs e)
    {
        bindData();
    }
}