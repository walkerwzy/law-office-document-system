using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LTP.Common;

public partial class cate_case_add : validateUser
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        string strErr = "";
        if (this.txtcatename.Text.Trim().Length == 0)
        {
            strErr += "类别名称不能为空！\\n";
        }
        if (this.txtpre.Text.Trim().Length == 0)
        {
            strErr += "类别前缀不能为空！\\n";
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
        try
        {
            int seq = 0;
            if (PageValidate.IsNumber(txtseq.Text))
            {
                seq = int.Parse(this.txtseq.Text);
            }
            string catename = this.txtcatename.Text;
            string remark = this.txtremark.Text;
            string prefix = this.txtpre.Text.Trim().ToUpper();

            WZY.Model.CATE_CASE model = new WZY.Model.CATE_CASE();
            model.catename = catename;
            model.seq = seq;
            model.remark = remark;
            model.prefix = prefix;

            WZY.DAL.CATE_CASE bll = new WZY.DAL.CATE_CASE();
            bll.Add(model);
            showDialogWithReload("添加类别成功");
        }
        catch (Exception ex)
        {
            showDialogWithAlert("操作失败，原因：" + ex.Message);
        }

    }


    public void btnCancle_Click(object sender, EventArgs e)
    {
        runJS("location.href=location.href;");
    }

}