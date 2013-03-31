using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LTP.Common;

public partial class depart_add : validateUser
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (0 != suser.roleid && 1 != suser.roleid)
        {
            showDialogWithAlert("无权限");
        }
        string strErr = "";
        if (this.txtdeptname.Text.Trim().Length == 0)
        {
            strErr += "部门名称不能为空！\\n";
        }
        //if (this.txtremark.Text.Trim().Length == 0)
        //{
        //    strErr += "remark不能为空！\\n";
        //}

        if (strErr != "")
        {
            showDialogWithAlert(strErr);
            return;
        }
        int seq = 0;
        if (PageValidate.IsNumber(txtseq.Text))
        {
            seq = int.Parse(this.txtseq.Text);
        }
        string deptname = this.txtdeptname.Text;
        string remark = this.txtremark.Text;

        WZY.Model.DEPART model = new WZY.Model.DEPART();
        model.deptname = deptname;
        model.seq = seq;
        model.remark = remark;

        WZY.DAL.DEPART bll = new WZY.DAL.DEPART();
        bll.Add(model);
        showDialogWithReload("添加部门成功");

    }


    public void btnCancle_Click(object sender, EventArgs e)
    {
        runJS("location.href=location.href;");
    }
}