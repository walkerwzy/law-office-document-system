using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class zhidu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(string.IsNullOrEmpty(Request["id"])) Response.Write("非法入口");
            WZY.Model.entry model = new WZY.DAL.entry().GetModel(int.Parse(Request["id"]));
            if (model != null)
            {
                lbltitle.Text = model.etitle;
                lblcont.Text = model.econt;
            }
        }
    }
}