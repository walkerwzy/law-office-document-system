using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LTP.Common;

public partial class entry_add : validateUser
{
    int eid;
    protected void Page_Load(object sender, EventArgs e)
    {
        eid = int.Parse(Request["id"]);
        if (!IsPostBack)
        {
            if (eid != -1) ShowInfo(eid);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        string strErr = "";
        if (this.txtetitle.Text.Trim().Length == 0)
        {
            strErr += "etitle不能为空！\\n";
        }
        if (this.txtecont.Text.Trim().Length == 0)
        {
            strErr += "econt不能为空！\\n";
        }

        if (strErr != "")
        {
            showDialogWithAlert(strErr);
            return;
        }
        int uid = suser.uid;
        string etype = "规章制度";
        string etitle = this.txtetitle.Text;
        string econt = this.txtecont.Text;
        DateTime createdate = DateTime.Now;
        //DateTime modifydate = DateTime.Parse(this.txtmodifydate.Text);

        WZY.DAL.entry bll = new WZY.DAL.entry();
        WZY.Model.entry model = new WZY.Model.entry();
        try
        {
            if (eid == -1)
            {
                model.uid = uid;
                model.etype = etype;
                model.etitle = etitle;
                model.econt = econt;
                model.createdate = createdate;
                bll.Add(model);
                showDialogWithReload2("添加成功！");
            }
            else
            {
                model = new WZY.DAL.entry().GetModel(eid);
                model.uid = uid;
                model.etype = etype;
                model.etitle = etitle;
                model.econt = econt;
                model.modifydate = DateTime.Now;
                bll.Update(model);
                showDialogWithReload2("修改成功！");
            }
        }
        catch (Exception ex)
        {
            showDialogWithAlert(ex.Message);
        }
    }


    private void ShowInfo(int eid)
    {
        WZY.DAL.entry bll = new WZY.DAL.entry();
        WZY.Model.entry model = bll.GetModel(eid);
        this.txtetitle.Text = model.etitle;
        this.txtecont.Text = model.econt;
        this.txtcreatedate.Text = model.createdate.Value.ToString("yyyy-MM-dd HH:mm:ss");
        this.txtmodifydate.Text = model.modifydate.HasValue ? model.modifydate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "";

    }
}