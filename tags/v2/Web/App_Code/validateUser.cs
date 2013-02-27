﻿using System;
using System.Web.UI;
using System.Collections;
using WZY.DAL;

/// <summary>
/// validateStu 的摘要说明
/// </summary>
public class validateUser : System.Web.UI.Page
{
    protected myPrincipal principal;
    protected WZY.Model.SYSUSER suser = new WZY.Model.SYSUSER();
    protected bool timeout = true;
    private string[] userdata = new string[1] { "" };//用户数据
    protected Uconfig cfg = new Uconfig();
    protected class Uconfig { public int pagesize = 20; public bool depart = false;}

    public validateUser()
    {
        userdata = Helper.HelperSession.GetAuthenticatedUserData("|");
        if (userdata.Length <= 1)
        {
            timeout = false;
            return;
        }
        if (!(Context.User is myPrincipal))
        {
            int uid = -1;
            int.TryParse(Context.User.Identity.Name, out uid);
            principal = new myPrincipal(uid);
            try
            {
                suser.uid = int.Parse(userdata[0]);
                suser.displayname = userdata[1];
                suser.deptid = int.Parse(userdata[2]);
                suser.roleid = int.Parse(userdata[3]);
                cfg.pagesize = int.Parse(userdata[4]);
                cfg.depart = userdata[5] == "1";
            }
            catch (Exception)
            {
                timeout = false;
            }
            Context.User = principal;
        }

    }

    protected override void OnInit(EventArgs e)
    {

        base.OnInit(e);

        this.Load += new EventHandler(validateMember_Load);

    }

    protected void runJS(string js)
    {
        ClientScript.RegisterClientScriptBlock(GetType(), DateTime.Now.ToString(), js, true);
    }
    protected void alert(string msg)
    {
        runJS("alert('" + msg.Replace("'","").Replace("\"","") + "');");
    }

    //在页面加载的时候从缓存中提取用户信息

    private void validateMember_Load(object sender, System.EventArgs e)
    {
        if (!timeout)
        {
            FlowControl.Logout();
            Response.Write("<script type='text/javascript'>location.href='login.aspx';</script>");
            Response.End();
        }
    }

    //一些js

    public void showDialogWithReload(string msg)
    {
        //runJS("alert('" + msg + "');var w=frameElement.lhgDG.curWin; w.location.href=w.location.href;");
        runJS("alert('" + msg.Replace("'", "").Replace("\"", "") + "');var w=frameElement.lhgDG.curWin; w.__doPostBack('LinkButton1','');");
    }
    public void showDialogWithReload2(string msg)
    {
        runJS("alert('" + msg.Replace("'", "").Replace("\"", "") + "');var w=frameElement.lhgDG.curWin;top.popAction(false);w.location.href=w.location.href;");
    }
    public void showDialogWithAlert(string msg)
    {
        runJS("alert('" + msg.Replace("'", "").Replace("\"", "") + "');frameElement.lhgDG.dg.style.display = 'block'; top.popAction(false);");
    }
    public void showDialog()
    {
        runJS("frameElement.lhgDG.dg.style.display = 'block'; top.popAction(false);");
    }
    public void showDialogWithJs(string msg, string js)
    {
        ClientScript.RegisterClientScriptBlock(GetType(), DateTime.Now.ToString(), "onload=function(){$('.autoCmpt-q-last').removeClass('autoCmpt-q-last');alert('" + msg + "');" + js + "frameElement.lhgDG.dg.style.display = 'block'; top.popAction(false);}", true);
    }
    public void closeDialog()
    {
        runJS("top.popAction(false);frameElement.lhgDG.cancel();");
    }
}
