using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class officeedit : validateUser
{
    string type = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        type = Request["type"];
        if (string.IsNullOrEmpty(type))
        {
            type = "zongzhi";
        }
        if (type == "zhidu") hidtype.Value = "3";
        else if (type == "zhanlue") hidtype.Value = "2";
        else hidtype.Value = "1";
        if (!IsPostBack)
        {
            binddata();
        }
    }

    private void binddata()
    {
        WZY.Model.office model = new WZY.DAL.office().GetModel();
        if (model == null) 
        {
            WZY.Model.office m = new WZY.Model.office();
            m.bak1 = "";
            m.bak2 = "";
            m.bak3 = "";
            m.zhanlue = "战略";
            m.zhidu = "制度";
            m.zongzhi = "宗旨";
            new WZY.DAL.office().Add(m);
            model = m;
        }
        txtzhanlue.Text = model.zhanlue;
        txtzhidu.Text = model.zhidu;
        txtzongzhi.Text = model.zongzhi;
    }

    protected void upentry(object sender, EventArgs e)
    {
        try
        {
            WZY.Model.office model = new WZY.DAL.office().GetModel();
            model.zongzhi = txtzongzhi.Text;
            model.zhidu = txtzhidu.Text;
            model.zhanlue = txtzhanlue.Text;
            new WZY.DAL.office().Update(model);
            showDialogWithReload2("修改成功");
        }
        catch (Exception ex)
        {
            showDialogWithAlert(ex.Message);
        }
    }
}