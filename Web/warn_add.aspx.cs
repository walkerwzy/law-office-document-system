using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LTP.Common;

public partial class warn_add : validateUser
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        string strErr = "";
        if (this.txtcont.Text.Trim().Length == 0)
        {
            strErr += "事件内容不能为空！\\n";
        }
        if (!PageValidate.IsDateTime(txtalerttime.Text))
        {
            strErr += "事件时间格式错误！\\n";
        }
        //if (!PageValidate.IsNumber(txtisprivate.Text))
        //{
        //    strErr += "isprivate格式错误！\\n";
        //}

        if (strErr != "")
        {
            MessageBox.Show(this, strErr);
            return;
        }
        int uid = suser.uid;
        string cont = this.txtcont.Text;
        DateTime alerttime = DateTime.Parse(this.txtalerttime.Text);
        int isprivate = cbxprivate.Checked ? 1 : 0;

        WZY.Model.alert model = new WZY.Model.alert();
        model.uid = uid;
        model.cont = cont;
        model.alerttime = alerttime;
        model.isprivate = isprivate;

        WZY.DAL.alert bll = new WZY.DAL.alert();
        bll.Add(model);
        showDialogWithReload2("添加成功");

    }


    public void btnCancle_Click(object sender, EventArgs e)
    {
        runJS("location.href=location.href;");
    }
}