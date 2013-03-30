using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class resetpwd : validateUser
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetUserName(this);
        }
    }

    protected void btnsaveclick(object sender, EventArgs e)
    {
        WZY.Model.SYSUSER u = new WZY.DAL.SYSUSER().GetModel(suser.uid);
        if (u.password!=txtoldpwd.Text)
        {
            alert("当前密码错误，请重新再试");
            return;
        }
        Regex r = new Regex(@"^[0-9a-zA-z]{6,20}$", RegexOptions.IgnoreCase);
        if (!r.IsMatch(txtpwd1.Text))
        {
            alert("密码格式不正确");
            return;
        }
        if (txtpwd1.Text!=txtpwd2.Text)
        {
            alert("两次输入密码不符，请重新再试");
            return;
        }
        try
        {
            new WZY.DAL.SYSUSER().Update(suser.uid, txtpwd1.Text);
            //runJS("alert('修改密码成功，请重新登录');top.location.href='/logout.aspx';");
            runJS("mconfirm('修改密码成功，请重新登录','',function(){location.href='/logout.aspx';})");
        }
        catch (Exception ex)
        {
            alert("修改密码失败，原因：" + ex.Message);
        }
    }
}