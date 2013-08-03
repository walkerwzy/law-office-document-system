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
    private WZY.DAL.tasklog dal = new tasklog();
    protected int fileCount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        isEdit = Request.QueryString["act"] == "edit";
        if (IsPostBack) return;
        if (isEdit) bindData();
        else initData();
    }

    private void initData()
    {
        if (!int.TryParse(Request.QueryString["custid"], out custid))
        {
            Response.Write("参数错误");
            Response.End();
        }
        hidcustid.Value = custid.ToString();
        lbltimereceive.Text = DateTime.Now.ToString("yyyy-MM-dd");
        lbluser.Text = suser.displayname;
    }

    private void bindData()
    {
        if (!int.TryParse(Request.QueryString["id"], out recid))
        {
            Response.Write("参数错误");
            Response.End();
        }
        fileCount = new WZY.DAL.DOCS().GetRecordCount("remark='log:" + recid + "'");
        var userDao = new SYSUSER();
        hidid.Value = recid.ToString();
        WZY.Model.tasklog model = dal.GetModel(recid);
        hidcustid.Value = model.custid.ToString();
        lbltimereceive.Text = model.rectime.ToString("yyyy-MM-dd");
        hidagent.Value = model.agentid.ToString();
        txtagent.Text = userDao.GetUserDisplayNameByID(model.agentid);
        txtfeedback.Text = model.feedback;
        txtfoot.Text = model.footlist;
        txttask.Text = model.tasklist;
        if (model.expiretime.HasValue) txttimeexpire.Text = model.expiretime.Value.ToString("yyyy-MM-dd");
        lbluser.Text = new SYSUSER().GetUserDisplayNameByID(model.userid);
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            WZY.Model.tasklog model = null;
            if (isEdit)
            {
                recid = int.Parse(hidid.Value);
                int depta = -1;
                int deptb = -1;
                if (!int.TryParse(Request.QueryString["depta"], out depta) ||
                    !int.TryParse(Request.QueryString["deptb"], out deptb))
                {
                    showDialogWithAlert("无权限"); //无部门信息，不予采用
                    return;
                }
                model = dal.GetModel(recid);
                //修改权限仅支持本人数据，部门负责人：部门数据，管理员：全部数据
                //本人在此例中为“提交人，或承办人”
                if (model.userid == suser.uid
                    || model.agentid == suser.uid
                    || (depta == suser.deptid && suser.roleid == 1)
                    || (deptb == suser.deptid && suser.roleid == 1)
                    || suser.roleid == 0)
                { }
                else
                {
                    showDialogWithAlert("无权限");
                    return;
                }
            }
            else model = new WZY.Model.tasklog();
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
            if (isEdit)
            {
                dal.Update(model);
                closeDialogWithReload("操作成功");
            }
            else
            {
                int id = dal.Add(model);
                closeDialogWithReload("操作成功");
            }
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