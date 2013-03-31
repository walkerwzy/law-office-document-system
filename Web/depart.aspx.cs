using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class depart : validateUser
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetUserName(this);
            btnAdd.Enabled = 0 == suser.roleid || 1 == suser.roleid;
        }
    }

    protected void btnsearch(object sender, EventArgs e)
    {
        string filter = " 1=1 ";
        if (!string.IsNullOrEmpty(txtdeptname.Text.Trim()))
        {
            filter += " and deptname like '%" + txtdeptname.Text.Trim() + "%' ";
        }
        filter += " order by seq ";
        ods.SelectParameters[0].DefaultValue = filter;
        gridlist.DataSourceID = "ods";
    }

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
    protected void gridlist_RowDeleted(object sender, GridViewDeletedEventArgs e)
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
        bool f=false;
        if (suser.roleid == 1)
        {
            if (deptid == suser.deptid.ToString())
            {
                f = true;
            }
        }
        else if (suser.roleid == 0) f = true;
        return f;
    }
}