using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class controls_navi : System.Web.UI.UserControl
{
    //当前页
    public string menu { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = new WZY.DAL.CATE_CASE().GetList(" 1=1 order by seq ").Tables[0];
            rptcase.DataSource = dt.DefaultView;
            rptcase.DataBind();

            dt = new WZY.DAL.cate_yewu().GetList(" 1=1 order by cate_index ").Tables[0];
            rptdocs.DataSource = dt.DefaultView;
            rptdocs.DataBind();

            dt = new WZY.DAL.CATE_CUST().GetList(" 1=1 order by seq ").Tables[0];
            rptclients.DataSource = dt.DefaultView;
            rptclients.DataBind();
        }
    }

    protected string getclassname(string type)
    {
        return string.Equals(type, menu, StringComparison.OrdinalIgnoreCase) ? "active" : "";
    }
}