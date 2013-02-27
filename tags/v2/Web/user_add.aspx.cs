using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LTP.Common;

public partial class user_add : validateUser
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Helper.HelperDropDownList.BindData(ddlrole, new WZY.DAL.SYSROLE().GetList("").Tables[0], "rolename", "roleid", 0);
            Helper.HelperDropDownList.BindData(ddldept, new WZY.DAL.DEPART().GetList("").Tables[0], "deptname", "deptid", 0);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        string strErr = "";
        //if (!PageValidate.IsNumber(txtroleid.Text))
        //{
        //    strErr += "roleid格式错误！\\n";
        //}
        //if (!PageValidate.IsNumber(txtdeptid.Text))
        //{
        //    strErr += "deptid格式错误！\\n";
        //}
        if (this.txtusername.Text.Trim().Length == 0)
        {
            strErr += "username不能为空！\\n";
        }
        if (this.txtpassword.Text.Trim().Length == 0)
        {
            strErr += "password不能为空！\\n";
        }
        if (this.txtpassword.Text.Trim()!=this.txtpassword2.Text.Trim())
        {
            strErr += "两次密码不符！\\n";
        }
        if (this.txtdisplayname.Text.Trim().Length == 0)
        {
            strErr += "displayname不能为空！\\n";
        }
        //if (this.txtremark.Text.Trim().Length == 0)
        //{
        //    strErr += "remark不能为空！\\n";
        //}
        //if (!PageValidate.IsNumber(txtstat.Text))
        //{
        //    strErr += "stat格式错误！\\n";
        //}

        if (strErr != "")
        {
            showDialogWithAlert(strErr);
            return;
        }
        int roleid = int.Parse(ddlrole.Text);
        int deptid = int.Parse(ddldept.Text);
        string username = this.txtusername.Text;
        string password = this.txtpassword.Text;
        string displayname = this.txtdisplayname.Text;
        string remark = this.txtremark.Text;
        int stat = int.Parse(this.ddlstat.Text);

        WZY.Model.SYSUSER model = new WZY.Model.SYSUSER();
        model.roleid = roleid;
        model.deptid = deptid;
        model.username = username;
        model.password = password;
        model.displayname = displayname;
        model.remark = remark;
        model.stat = stat;

        WZY.DAL.SYSUSER bll = new WZY.DAL.SYSUSER();
        bll.Add(model);
        showDialogWithReload("保存成功！");

    }


    public void btnCancle_Click(object sender, EventArgs e)
    {
        runJS("location.href=location.href;");
    }
}