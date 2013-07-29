using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class cases : validateUser
{
    DataTable cate_case;
    private bool usedate = false;
    protected bool usecustid = false;
    protected bool usecaseid = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ViewState["cate_case"] == null)
        {
            cate_case = new WZY.DAL.CATE_CASE().GetList("").Tables[0];
            ViewState["cate_case"] = cate_case;
        }
        else
        {
            cate_case = ViewState["cate_case"] as DataTable;
        }
        if (!IsPostBack)
        {
            SetUserName(this);
            if (!string.IsNullOrEmpty(Request["custid"])) usecustid = true;
            if (!string.IsNullOrEmpty(Request["caseid"])) usecaseid = true;
            if (!string.IsNullOrEmpty(Request["usedate"]) && Request["usedate"] == "yes") usedate = true;
            //if (suser.roleid == 0 || suser.roleid == 2)
            //{
            //    tools.addAdminOption(ddlrange);
            //}
            hiduinfo.Value = suser.uid + "|" + suser.deptid + "|" + suser.roleid;
            var cateid = string.IsNullOrEmpty(Request["casetype"]) ? "-1" : Request["casetype"];
            Helper.HelperDropDownList.BindData(ddlcasecate, cate_case, "catename", "cateid", cateid, true);
            //if (cfg.depart)
            //{
            //    ddlrange.SelectedIndex = 1;
            //}
            btnsearch(null, null);
        }
    }

    private void bindData(string filter)
    {
        int pagesize = cfg.pagesize;
        int page;
        if (!int.TryParse(Request["page"], out page))
        {
            page = 1;
        }

        ods.SelectParameters[0].DefaultValue = filter;
        gridlist.DataSourceID = "ods";

        AspNetPager1.RecordCount = new WZY.DAL.CASES().GetRecordCount(filter);
        AspNetPager1.PageSize = cfg.pagesize;
        //PagedDataSource ps = new PagedDataSource
        //    {
        //        DataSource = new WZY.DAL.CASES().GetList(filter).Tables[0].DefaultView,
        //        AllowPaging = true,
        //        PageSize = pagesize
        //    };
        //if (page > ps.PageCount) page = 1;
        //ps.CurrentPageIndex = page - 1;

        //gridlist.DataSource = ps;
        //gridlist.DataBind();

        //string url = Request.Url.ToString();
        //lblpager.Text = Pager.getPagerstring(ps, url, 1, 7);
    }

    protected void gvdatabind(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView dr = e.Row.DataItem as DataRowView;
            string detail = "<b>数据上传：</b>{10}<br/><b>承办律师：</b>{8}<br /><b>承办法官：</b>{0}<br/ ><b>法官电话：</b>{1}<br/ ><b>审理法院：</b>{9}<br/><b>法官办公室：</b>{2}<br/ ><b>开庭日期：</b>{3}<br/ ><b>判决日期：</b>{4}<br/ ><b>收案日期：</b>{5}<br /><b>案由：</b>{6}<br /><b>跟踪情况：</b>{7}";
            //e.Row.Attributes["data-role"] = "popover";
            //e.Row.Attributes["data-placement"] = "right";
            //e.Row.Attributes["data-content"] = string.Format(detail, dr["faguan"].ToString(), dr["faguantel"].ToString(), dr["office"].ToString(), getdatetime(dr["kaiting"]), getdatetime(dr["panjuetime"]), getdatetime(dr["shouan"]), dr["anyou"].ToString(), dr["remark"].ToString(), dr["displayname"].ToString(), dr["court"].ToString());
            //e.Row.Attributes["data-original-title"] = "案件详情";
            //e.Row.Attributes["data-trigger"] = "manual";
            (e.Row.Cells[0].FindControl("hiddetail") as HiddenField).Value = string.Format(detail, dr["faguan"].ToString(), dr["faguantel"].ToString(), dr["office"].ToString(), getdatetime(dr["kaiting"]), getdatetime(dr["panjuetime"]), getdatetime(dr["shouan"]), dr["anyou"].ToString(), Helper.HelperString.cutString(dr["remark"].ToString(), 50), dr["lawname"].ToString(), dr["court"].ToString(), dr["displayname"].ToString());
            e.Row.Cells[2].Text = cate_case.Select("cateid=" + dr["cateid"].ToString())[0]["catename"].ToString();
        }
    }

    protected void btnsearch(object sender, EventArgs e)
    {
        //得到查询字符串
        string sql = " 1=1 ";
        if (usecustid)
        {
            sql += " and custid=" + Request["custid"];
            bindData(sql);
            return;
        }
        if (usecaseid)
        {
            sql += " and caseid=" + Request["caseid"];
            bindData(sql);
            return;
        }
        if (!string.IsNullOrEmpty(txtno.Value.Trim()))
        {
            sql += " and caseno='" + txtno.Value.Trim() + "' ";
        }
        if (!string.IsNullOrEmpty(txtpeople.Value.Trim()))
        {
            sql += " and (custname like '%" + txtpeople.Value.Trim() + "%' or pycode like '%" + txtpeople.Value.Trim() + "%') ";
        }
        if (!string.IsNullOrEmpty(txtreason.Value.Trim()))
        {
            sql += " and anyou like '%" + txtreason.Value.Trim() + "%' ";
        }
        if (!string.IsNullOrEmpty(txtsdate.Value.Trim()))
        {
            sql += " and shouan >= '" + txtsdate.Value.Trim() + "' ";
        }
        if (!string.IsNullOrEmpty(txtedate.Value.Trim()))
        {
            sql += " and shouan <= '" + txtedate.Value.Trim() + "' ";
        }
        if (ddlcasecate.SelectedIndex > 0)
        {
            sql += " and cateid=" + ddlcasecate.Text;
        }
        //数据范围
        //switch (ddlrange.SelectedIndex)
        //{
        //    case 0:
        //        sql += " and uid=" + suser.uid;
        //        break;
        //    case 1:
        //        sql += " and (deptid=" + suser.deptid.Value + " or chargedeptid=" + suser.deptid.Value + ")";//本部门上传的，或客户类别属于本部门的，都可以查看
        //        break;
        //    case 2:
        //    default:
        //        break;
        //}
        if (usedate)
        {
            int predays = int.Parse(Utility.getConfigFile().Root.Descendants("predays").SingleOrDefault().Value);
            sql += " and kaiting>='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and kaiting<= '" + DateTime.Now.AddDays(predays).ToString("yyyy-MM-dd") + "'";
        }
        bindData(sql);
    }

    protected string getDocPath(string docno)
    {
        string fmt = "<a href='ProcessFile.aspx?act=download&d={0}' target='_blank' title='下载' class='icona'><img src='/images/download.ico' alt='' /></a>&nbsp;<a href='ProcessFile.aspx?act=preview&d={0}' target='_blank' title='预览' class='icona'><img src='/images/preview.gif' alt='' /></a>";
        if (docno == "-1")
        {
            return "尚未上传";
        }
        return string.Format(fmt, docno);
    }

    protected void delcase(object sender, EventArgs e)
    {
        string ids = Request["ids"];
        if (!string.IsNullOrEmpty(ids))
        {
            try
            {
                string[] info = ids.Split('|');
                if (info.Length > 1)
                {
                    //目前只做单删的逻辑
                    //删除权限仅支持本人数据，部门负责人：部门数据，管理员：全部数据
                    if (info[1] == suser.uid.ToString() || (info[2] == suser.deptid.ToString() && suser.roleid == 1) || suser.roleid == 0)
                    {
                        new WZY.DAL.CASES().Delete(info[0]);
                        alert("删除成功");
                        btnsearch(null, null);
                    }
                    else
                    {
                        alert("无权限");
                    }
                }
            }
            catch (Exception ex)
            {
                alert("删除失败，原因：" + ex.Message);
            }
        }
    }

    private bool canDel(string deptid)
    {

        if (suser.roleid == 0)
        {
            return true;
        }
        if (suser.roleid == 1 && suser.deptid.ToString() == deptid)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    ///生成列表里显示用的下载、预览和删除链接
    ///并且有字段标记，以供ajax删除用
    /// </summary>
    /// <param name="docno">文档编号</param>
    /// <param name="caseid">案件编号</param>
    /// <param name="field">文档对应字段名</param>
    /// <param name="deptid">创建人所属部门</param>
    /// <returns></returns>
    public string getDocPath(int docno, string caseid, string field, string deptid)
    {
        string fmt = "<a href='ProcessFile.aspx?act=download&d={0}' target='_blank' class='icona afordel' data-field='{2}' data-caseid='{1}' data-docid='{0}' title='下载'><img src='/images/download.gif' title='下载' alt='' /></a><a href='ProcessFile.aspx?act=preview&d={0}' target='_blank' class='icona' title='预览'><img title='预览' src='/images/preview.gif' alt='' /></a>";
        if (canDel(deptid))
        {
            fmt += "<a href='#' class='icona' onclick='deldoc(this,{0},{1},\"{2}\");' title='删除'><img src='/images/delete.gif' title='删除' alt='' /></a>";
        }
        if (docno == -1)
        {
            return "尚未上传";
        }
        return string.Format(fmt, docno, caseid, field);
    }

    //把datarow里面的日期时间字段转化成时间
    //null字段转成空
    private string getdatetime(object o)
    {
        if (string.IsNullOrEmpty(o.ToString())) return "";
        try
        {
            return Convert.ToDateTime(o).ToString("d");
        }
        catch
        {
            return o.ToString();
        }
    }
}