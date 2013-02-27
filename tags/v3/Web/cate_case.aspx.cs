using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class cate_case : validateUser
{
    private DataTable dtcate;
    protected void Page_Load(object sender, EventArgs e)
    {
        dtcate = new WZY.DAL.CATE_CUST().GetList("").Tables[0];
    }

    protected void btnsearch(object sender, EventArgs e)
    {
        string filter = " 1=1 ";
        if (!string.IsNullOrEmpty(txtcatename.Text.Trim()))
        {
            filter += " and catename like '%" + txtcatename.Text.Trim() + "%' ";
        }
        filter += " order by seq ";
        ods.SelectParameters[0].DefaultValue = filter;
        gridlist.DataSourceID = "ods";
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
}