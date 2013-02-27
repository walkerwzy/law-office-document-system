using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LTP.Common;

public partial class contract : validateUser
{
    int custid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Request["id"]) || string.IsNullOrEmpty(Request.QueryString["name"]))
        {
            Response.Write("illeagle access");
            Response.End();
        }
        try
        {
            custid = int.Parse(Request["id"]);
            hidcustid.Value = Request["id"];
            txtcustid.Text = Request.QueryString["name"];
        }
        catch
        {
            Response.Write("illeagle access");
            Response.End();
        }
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        ods.SelectParameters[0].DefaultValue = " custid=" + custid + " order by c_stime desc";
        gridlist.DataSourceID = "ods";
        gridlist.DataBind();
    }

    protected void btnadds(object sender, EventArgs e)
    {

        string strErr = "";
        if (!PageValidate.IsNumber(hidcustid.Value))
        {
            strErr += "无效的签约客户，请重新选择！\\n";
        }
        if (!PageValidate.IsNumber(hiduid.Value))
        {
            strErr += "无效的签约人，请重新选择！\\n";
        }
        if (!PageValidate.IsDateTime(txtstime.Text))
        {
            strErr += "签约时间格式错误！\\n";
        }
        if (!PageValidate.IsDecimal(txtfee.Text))
        {
            strErr += "签约费用请输入数字！\\n";
        }
        if (!PageValidate.IsDateTime(txtetime.Text))
        {
            strErr += "到期时间格式错误！\\n";
        }
        if (!string.IsNullOrEmpty(txtctime.Text.Trim())&& !PageValidate.IsDateTime(txtctime.Text))
        {
            strErr += "付款时间格式错误！\\n";
        }
        if (strErr != "")
        {
            alert(strErr);
            return;
        }
        try
        {
            int custid = int.Parse(hidcustid.Value);
            int uid = int.Parse(hiduid.Value);
            DateTime c_stime = DateTime.Parse(this.txtstime.Text);
            decimal c_fee = decimal.Parse(this.txtfee.Text);
            DateTime c_etime = DateTime.Parse(this.txtetime.Text);
            object c_ctime = string.IsNullOrEmpty(this.txtctime.Text.Trim()) ? null : DateTime.Parse(this.txtctime.Text.Trim()) as object;
            string remark = this.txtremark.Text;
            WZY.Model.CONTRACT model = new WZY.Model.CONTRACT();
            model.custid = custid;
            model.c_stime = c_stime;
            model.c_fee = c_fee;
            model.c_etime = c_etime;
            model.c_ctime = (DateTime?)c_ctime;
            model.remark = remark;
            model.username = txtuid.Text.Trim();

            WZY.DAL.CONTRACT bll = new WZY.DAL.CONTRACT();
            bll.Add(model, uid);
            alert("添加成功");
            BindData();
        }
        catch (Exception ex)
        {
            alert(ex.Message.Replace('\'', ' ').Replace('"', ' '));
        }
    }
}