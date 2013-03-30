using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Lunar;

public partial class clients : validateUser
{
    private bool usedate = false;
    private bool usecontract = false;
    private bool usecustid = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetUserName(this);
            if (!string.IsNullOrEmpty(Request["usedate"]) && Request["usedate"] == "yes") usedate = true;
            if (!string.IsNullOrEmpty(Request["custid"])) usecustid = true;
            if (!string.IsNullOrEmpty(Request["usecontract"]) && Request["usecontract"] == "yes") usecontract = true;
            //if (suser.roleid == 0 || suser.roleid == 2)//管理员和律师可以看所有客户和文档
            //{
            //    tools.addAdminOption(ddlrange);
            //}
            var clienttype = string.IsNullOrEmpty(Request["clienttype"]) ? "-1" : Request["clienttype"];
            Helper.HelperDropDownList.BindData(ddlcustcate, new WZY.DAL.CATE_CUST().GetList("").Tables[0], "catename", "cateid", clienttype, true);
            //if (cfg.depart)
            //{
            //    ddlrange.SelectedIndex = 1;
            //}
            bindData();
        }
    }

    private void bindData()
    {
        string filter = getSqlStr();
        ods.SelectParameters[0].DefaultValue = filter;
        gridlist.DataSourceID = "ods";

        AspNetPager1.RecordCount = new WZY.DAL.CUSTOMER().GetRecordCount(filter);
        AspNetPager1.PageSize = cfg.pagesize;
    }

    private string getSqlStr()
    {
        string filter = "";
        if (hidbackaction.Value == "0" && !string.IsNullOrEmpty(Request.QueryString["f"]))
        {
            try
            {
                string q = Request.QueryString["f"].FromBase64();
                filter += q;
                hidquery.Value = Request.QueryString["f"];
                hidbackaction.Value = "1";
            }
            catch
            {
            }
        }
        else
        {
            filter = "1=1 ";
            if (usecustid)
            {
                filter += " and custid=" + Request["custid"];
                return filter;
            }
            if (!string.IsNullOrEmpty(txtstime.Text.Trim()))
            {
                filter += " and c_stime>='" + txtstime.Text.Trim() + "' ";
            }
            if (!string.IsNullOrEmpty(txtetime.Text.Trim()))
            {
                filter += " and c_stime<='" + txtetime.Text.Trim() + "' ";
            }
            //if (!string.IsNullOrEmpty(txtcustname.Value.Trim()))
            //{
            //    filter += " and custname like '%" + txtcustname.Value.Trim() + "%' ";
            //}
            //if (!string.IsNullOrEmpty(txtcharge.Text.Trim()))
            //{
            //    filter += " and charge like '%" + txtcharge.Text.Trim() + "%' ";
            //}
            //if (!string.IsNullOrEmpty(txtown.Value.Trim()))
            //{
            //    filter += " and owner like '%" + txtown.Value.Trim() + "%' ";
            //}
            if (ddlcustcate.SelectedIndex > 0)
            {
                filter += " and cateid=" + ddlcustcate.Text;
            }
            switch (ddlnametype.SelectedIndex)
            {
                case 0:
                    filter += " and custname like '%" + txtcustname.Value.Trim() + "%' ";
                    break;
                case 1:
                    filter += " and owner like '%" + txtcustname.Value.Trim() + "%' ";
                    break;
                default:
                    filter += " and charge like '%" + txtcustname.Value.Trim() + "%' ";
                    break;
            }
            //switch (ddlrange.SelectedIndex)
            //{
            //    case 0:
            //        filter += " and uid=" + suser.uid;
            //        break;
            //    case 1:
            //        filter += " and deptid=" + suser.deptid;
            //        break;
            //    case 2:
            //    default:
            //        break;
            //}
            switch (ddlqianyue.SelectedIndex)
            {
                case 0://签约
                    filter += " and c_etime>='" + DateTime.Now.ToString("yyyy-MM-dd") + "' ";
                    break;
                case 1://意向
                    filter += " and c_etime is null ";
                    break;
                case 2://过期
                    filter += " and c_etime<'" + DateTime.Now.ToString("yyyy-MM-dd") + "' ";
                    break;
                default:
                    break;
            }
            int predays = int.Parse(Utility.getConfigFile().Root.Descendants("predays").SingleOrDefault().Value);
            if (usedate)
            {
                //公历生日
                filter += " and ((lunar1<>1 and ownerbirth>='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and ownerbirth<= '" + DateTime.Now.AddDays(predays).ToString("yyyy-MM-dd") + "')";
                filter += " or (lunar2<>1 and chargebirth>='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and chargebirth <= '" + DateTime.Now.AddDays(predays).ToString("yyyy-MM-dd") + "')";
                //农历生日
                Lunar.Lunar today = LunarApi.GetLunarDate(DateTime.Today);
                Lunar.Lunar lastday = LunarApi.GetLunarDate(DateTime.Today.AddDays(predays));
                filter += " or (lunar1=1 and ownerbirth>='" + string.Format("{0}-{1}-{2}", today.Year, today.Month, today.Day) + "' and ownerbirth<= '" + string.Format("{0}-{1}-{2}", lastday.Year, lastday.Month, lastday.Day) + "')";
                filter += " or (lunar2=1 and chargebirth>='" + string.Format("{0}-{1}-{2}", today.Year, today.Month, today.Day) + "' and chargebirth <= '" + string.Format("{0}-{1}-{2}", lastday.Year, lastday.Month, lastday.Day) + "') )";
            }
            if (usecontract)
            {
                filter += " and c_etime>='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and c_etime<= '" + DateTime.Now.AddDays(predays).ToString("yyyy-MM-dd") + "'";
                filter += " and deptid=" + suser.deptid;
            }
            hidquery.Value = filter.ToBase64();
        }
        return filter;
    }

    protected void gvdatabind(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView dr = e.Row.DataItem as DataRowView;
            //删除权限仅支持本人数据，部门负责人：部门数据，管理员：全部数据
            bool candel = dr["uid"].ToString() == suser.uid.ToString() || (dr["deptid"].ToString() == suser.deptid.ToString() && suser.roleid == 1) || suser.roleid == 0;
            (e.Row.Cells[0].FindControl("hidcandel") as HiddenField).Value = candel ? "1" : "0";
        }
    }

    protected void btnsearch(object sender, EventArgs e)
    {
        bindData();
    }

    protected void delcust(object sender, EventArgs e)
    {
        try
        {
            int id = Convert.ToInt32(Request["ids"]);
            new WZY.DAL.CUSTOMER().Delete(id);
            alert("删除成功");
            bindData();
        }
        catch (Exception ex)
        {
            alert("删除失败，原因：" + ex.Message);
        }
    }

    //protected string getCustCateName(string cateid)
    //{
    //    if (ViewState["custcate"]==null)
    //    {
    //        ViewState["custcate"] = new WZY.DAL.CATE_CUST().GetList("").Tables[0];
    //    }
    //    DataTable dt = ViewState["custcate"] as DataTable;
    //    return dt.Select("cateid=" + cateid)[0]["catename"].ToString();
    //}
    //protected string getUserName(string cateid)
    //{
    //    if (ViewState["sysuser"] == null)
    //    {
    //        ViewState["sysuser"] = new WZY.DAL.SYSUSER().GetList("").Tables[0];
    //    }
    //    DataTable dt = ViewState["sysuser"] as DataTable;
    //    return dt.Select("uid=" + cateid)[0]["displayname"].ToString();
    //}

    //导出excel
    public override void VerifyRenderingInServerForm(Control control) { }
    protected void export(object sender, EventArgs e)
    {
        gridlist.AllowPaging = false;
        string filter = getSqlStr();
        gridlist.DataSourceID = null;
        gridlist.DataSource = new WZY.DAL.CUSTOMER().GetList(filter).Tables[0].DefaultView;
        gridlist.DataBind();

        DataControlFieldCollection dc = gridlist.Columns;
        dc[0].Visible = false;

        HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("客户名单_" + DateTime.Today.ToString("yyyyMMdd") + ".xls", System.Text.Encoding.UTF8));
        Response.ContentType = "application/vnd-ms-excel";
        HttpContext.Current.Response.Charset = "UTF-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
        Page.EnableViewState = false;
        System.IO.StringWriter tw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
        gridlist.RenderControl(hw);
        Response.Write(tw.ToString());
        Response.End();
    }

}