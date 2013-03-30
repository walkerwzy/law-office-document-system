using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WZY.DAL;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void loginclick(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtusername.Text.Trim()))
        {
            alert("用户名不能为空");
            return;
        }
        if (string.IsNullOrEmpty(txtpwd.Text.Trim()))
        {
            alert("密码不能为空");
            return;
        }
        myPrincipal principle = new myPrincipal(txtusername.Text.Trim(), txtpwd.Text.Trim());
        switch (principle.returncode)
        {
            case 0:
                alert("用户名不存在");
                return;
            case 2:
                alert("密码错误");
                return;
            case 3:
                alert("账号被锁定");
                return;
            case 4:
                alert("账号异常");
                return;
            default:
                break;
        }
        //登录成功
        Context.User = principle;
        try
        {
            WZY.Model.SYSUSER model = new WZY.DAL.SYSUSER().GetModel(int.Parse(principle.Identity.Name));
            string userdata = model.uid + "|" + model.displayname + "|" + model.deptid + "|" + model.roleid.Value.ToString();
            WZY.Model.settings m = new WZY.DAL.settings().GetModel(model.uid);
            userdata += "|" + (m == null ? "20" : m.pagesize.Value.ToString()) + "|" + (m == null ? "0" : m.depart.Value.ToString());
            FlowControl.SaveLoginInfo(model.uid.ToString(), userdata);

            //跳转
            runJS("location.href='agendar.aspx';");
        }
        catch (Exception ex)
        {
            Helper.log.error("登录发生错误", ex.Message);
            alert("发生异常，原因：" + ex.Message);
            return;
        }
    }

    protected void runJS(string js)
    {
        ClientScript.RegisterClientScriptBlock(GetType(), DateTime.Now.ToString(), js, true);
    }
    protected void alert(string js)
    {
        runJS("alert('" + js + "');");
    }
}