using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LTP.Common;

public partial class personal : validateUser
{
    WZY.DAL.settings bll = new WZY.DAL.settings();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetUserName(this);
            WZY.Model.SYSUSER mu = new WZY.DAL.SYSUSER().GetModel(suser.uid);
            txtusername.Text = mu.username;
            txtdisplayname.Text = mu.displayname;
            WZY.Model.SYSROLE mr = new WZY.DAL.SYSROLE().GetModel(mu.roleid.Value);
            WZY.Model.DEPART md = new WZY.DAL.DEPART().GetModel(mu.deptid.Value);
            lbldepart.Text = md.deptname;
            lblrole.Text = mr.displayname;

            WZY.Model.settings m = bll.GetModel(suser.uid);
            if (m != null)
            {
                txtpagesize.Text = m.pagesize.Value.ToString();
                cbxdepart.Checked = m.depart == 1;
            }
            else
            {
                txtpagesize.Text = "20";
                cbxdepart.Checked = false;
            }
        }
    }


    protected void btnsave1click(object sender, EventArgs e)
    {
        WZY.DAL.SYSUSER ubll = new WZY.DAL.SYSUSER();
        WZY.Model.SYSUSER model = ubll.GetModel(suser.uid);
        model.username = txtusername.Text.Trim();
        model.displayname = txtdisplayname.Text.Trim();
        try
        {
            ubll.Update(model);
            //alert("保存成功");
            runJS("mconfirm('修改成功，重新登录后生效，是否重新登录？','',function(){location.href='/logout.aspx';})");
        }
        catch (Exception ex)
        {
            alert(ex.Message);
        }
    }


    protected void btnsaveclick(object sender, EventArgs e)
    {
        if (!PageValidate.IsNumber(txtpagesize.Text.Trim()))
        {
            alert("每页记录条数请输入数字");
            return;
        }
        int p = int.Parse(txtpagesize.Text.Trim());
        if (p < 0 || p > 100)
        {
            alert("每页记录条数请输入100以内的有效数字");
        }
        int d = cbxdepart.Checked ? 1 : 0;
        WZY.Model.settings model = bll.GetModel(suser.uid);
        bool isadd = model == null;
        if (isadd) model = new WZY.Model.settings();
        model.depart = d;
        model.pagesize = p;
        model.uid = suser.uid;
        try
        {
            if (isadd)
            {
                bll.Add(model);
            }
            else
            {
                bll.Update(model);
            }
            //runJS("if(confirm('修改成功，重新登录后生效，是否重新登录？')) top.location='logout.aspx';");
            runJS("mconfirm('修改成功，重新登录后生效，是否重新登录？','',function(){location.href='/logout.aspx';})");
        }
        catch (Exception ex)
        {
            alert(ex.Message);
        }
    }
}