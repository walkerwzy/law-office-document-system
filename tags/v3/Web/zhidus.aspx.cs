using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class zhidus : validateUser
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
}