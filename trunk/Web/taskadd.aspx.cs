using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LTP.Common;
using WZY.DAL;

public partial class taskadd : validateUser
{
    private bool isEdit = false;
    private int custid = -1;
    private int recid = -1;
    private WZY.Model.tasklog model = null;
    private WZY.DAL.tasklog dal = new tasklog();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        if (!int.TryParse(Request.QueryString["custid"], out custid))
        {
            Response.Write("参数错误");
            Response.End();
        }
        hidcustid.Value = custid.ToString();
        isEdit = Request.QueryString["act"] == "edit";
        if (isEdit) bindData();
        else
        {
            lbltimereceive.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lbluser.Text = suser.displayname;
        }
    }

    private void bindData()
    {
        if (!int.TryParse(Request.QueryString["id"], out recid))
        {
            Response.Write("参数错误");
            Response.End();
        }
        var userDao = new SYSUSER();
        hidid.Value = recid.ToString();
        model = dal.GetModel(recid);
        lbltimereceive.Text = model.rectime.ToString("yyyy-MM-dd");
        hidagent.Value = model.agentid.ToString();
        txtagent.Text = userDao.GetUserDisplayNameByID(model.agentid);
        txtfeedback.Text = model.feedback;
        txtfoot.Text = model.footlist;
        txttask.Text = model.tasklist;
        if(model.expiretime.HasValue) txttimeexpire.Text = model.expiretime.Value.ToString("yyyy-MM-dd");
        lbluser.Text = new SYSUSER().GetUserDisplayNameByID(model.userid);
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (isEdit)
            {
                //修改权限仅支持本人数据，部门负责人：部门数据，管理员：全部数据
                //if (info[1] == suser.uid.ToString() || (info[2] == suser.deptid.ToString() && suser.roleid == 1) || suser.roleid == 0)
                //{ }
                //else
                //{
                //    showDialogWithAlert("无权限");
                //    return;
                //}
            }
            else model=new WZY.Model.tasklog();
            string strErr = "";
            if (!PageValidate.IsNumber(hidagent.Value))
            {
                strErr += "请选择承办人！\\n";
            }
            if (strErr != "")
            {
                showDialogWithJs(strErr, "$(\"#txtagent\").attr(\"qid\", " + (string.IsNullOrEmpty(hidagent.Value) ? "-1" : hidagent.Value) + ");");
                return;
            }
            if (!isEdit)
            {
                model.rectime = DateTime.Now;
                model.userid = suser.uid;
                model.custid = int.Parse(hidcustid.Value);
            }
            model.agentid = int.Parse(hidagent.Value);
            if (!string.IsNullOrEmpty(txttimeexpire.Text.Trim())) model.expiretime = DateTime.Parse(txttimeexpire.Text);
            model.feedback = txtfeedback.Text;
            model.footlist = txtfoot.Text;
            model.tasklist = txttask.Text;
            if (isEdit) dal.Update(model);
            else
            {
                int id = dal.Add(model);
            }
            showDialogWithAlert("操作成功");
        }
        catch (Exception ex)
        {
            Helper.log.error("操作失败", ex.Message);
            showDialogWithAlert(ex.Message);
        }
    }


    public void btnCancle_Click(object sender, EventArgs e)
    {
        runJS("location.href=location.href;");
    }
}