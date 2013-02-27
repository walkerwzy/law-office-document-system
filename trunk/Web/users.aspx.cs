﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class users : validateUser
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Helper.HelperDropDownList.BindData(ddldeptsearch, new WZY.DAL.DEPART().GetList("").Tables[0], "deptname", "deptid", 0, true);
            bindData();
        }
    }

    private void bindData()
    {
        string filter = " uid!=0 ";
        if (ddldeptsearch.SelectedIndex > 0)
        {
            filter += " and deptid=" + ddldeptsearch.Text;
        }
        if (!string.IsNullOrEmpty(txtusername.Text.Trim()))
        {
            filter += " and displayname like '%" + txtusername.Text.Trim() + "%' ";
        }
        ods.SelectParameters[0].DefaultValue = filter;
        gridlist.DataSourceID = "ods";

        AspNetPager1.RecordCount = new WZY.DAL.SYSUSER().GetList(filter).Tables[0].Rows.Count;
        AspNetPager1.PageSize = cfg.pagesize;
    }

    protected void btnsearch(object sender, EventArgs e)
    {
        bindData();
    }

    //protected void ODS_Selecting(object src, ObjectDataSourceSelectingEventArgs e)
    //{
    //    if (!e.ExecutingSelectCount)
    //    {
    //        Response.Write("ODSselect事件被引发，当前页索引是：" + AspNetPager1.CurrentPageIndex);
    //    }
    //}
    protected void gridlist_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        if (e.Exception != null)
        {
            if (e.Exception.InnerException != null)
            {
                alert(e.Exception.InnerException.Message);
            }
            else
            {
                alert("有错误发生，请稍候再试");
            }
            e.ExceptionHandled = true;
        }
    }

    protected bool canedit(string deptid)
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
}