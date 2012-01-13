using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class zongzhi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WZY.Model.office model = new WZY.DAL.office().GetModel();
        if (model != null) {
            lblcont.Text = model.zongzhi;
        }
    }
}