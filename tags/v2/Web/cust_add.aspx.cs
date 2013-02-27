using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LTP.Common;
using System.Text.RegularExpressions;

public partial class cust_add : validateUser
{
    bool isedit = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Helper.HelperDropDownList.BindData(ddlcate, new WZY.DAL.CATE_CUST().GetList(" 1=1 order by seq").Tables[0], "catename", "cateid", 0);
            if (Request["act"] == "modify" && (Request.Params["id"] != null && Request.Params["id"].Trim() != ""))
            {
                int custid = (Convert.ToInt32(Request.Params["id"]));
                ShowInfo(custid);
            }
        }
    }

    private void ShowInfo(int custid)
    {
        WZY.DAL.CUSTOMER bll = new WZY.DAL.CUSTOMER();
        WZY.Model.CUSTOMER model = bll.GetModel(custid);
        this.hidcustid.Value = model.custid.ToString();
        this.ddlcate.Text = model.cateid.ToString();
        //this.txtuid.Text = model.uid.ToString();
        this.txtcustname.Text = model.custname;
        //this.txtpycode.Text = model.pycode;
        this.txtaddress.Text = model.address;
        this.txttel.Text = model.tel;
        this.txtfax.Text = model.fax;
        this.txtpost.Text = model.post;
        this.txtemail.Text = model.email;
        this.txtowner.Text = model.owner;
        this.txtownertel.Text = model.ownertel;
        this.txtownerqq.Text = model.ownerqq;
        this.txtcharge.Text = model.charge;
        this.txtchargetel.Text = model.chargetel;
        this.txtchargeqq.Text = model.chargeqq;
        this.txtsummary.Text = model.summary;
        this.txtremark.Text = model.remark;
        this.lblcustno.Text = model.custno;
        this.txtcontact.Text = model.contact;
        this.txtcontel.Text = model.contel;

        this.txtownerbirthday.Text = model.ownerbirth.HasValue ? model.ownerbirth.Value.ToString("yyyy-MM-dd") : "";
        this.txtchargebirth.Text = model.chargebirth.HasValue ? model.chargebirth.Value.ToString("yyyy-MM-dd") : "";
        this.cbxluanr1.Checked = model.lunar1 == 1;
        this.cbxlunar2.Checked = model.lunar2 == 1;

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Request["act"] == "modify" && (Request.Params["id"] != null && Request.Params["id"].Trim() != ""))
                isedit = true;
            if (isedit && Request.QueryString["auth"] != "1")
            {
                showDialogWithAlert("无权限");
                return;
            }
            string strErr = "";
            WZY.DAL.CUSTOMER bll = new WZY.DAL.CUSTOMER();
            //if (!PageValidate.IsNumber(txtcateid.Text))
            //{
            //    strErr += "cateid格式错误！\\n";
            //}
            //if (!PageValidate.IsNumber(txtuid.Text))
            //{
            //    strErr += "uid格式错误！\\n";
            //}
            if (this.txtcustname.Text.Trim().Length == 0)
            {
                strErr += "客户/单位名称不能为空！\\n";
            }
            if (!isedit && bll.isNameExists(txtcustname.Text.Trim()))
            {
                strErr = "客户/单位名称重复！\\n";
            }
            //if (this.txtpycode.Text.Trim().Length == 0)
            //{
            //    strErr += "pycode不能为空！\\n";
            //}
            if (this.txtaddress.Text.Trim().Length == 0)
            {
                strErr += "单位地址不能为空！\\n";
            }
            if (this.txttel.Text.Trim().Length == 0)
            {
                strErr += "单位联系电话不能为空！\\n";
            }
            //if (this.txtfax.Text.Trim().Length == 0)
            //{
            //    strErr += "fax不能为空！\\n";
            //}
            //if (this.txtpost.Text.Trim().Length == 0)
            //{
            //    strErr += "post不能为空！\\n";
            //}
            if (!string.IsNullOrEmpty(txtemail.Text.Trim()))
            {
                Regex regex = new Regex(@"^\w+[.+-]?\w+@\w+(\.\w+)+$", RegexOptions.IgnoreCase);
                if (!regex.IsMatch(this.txtemail.Text.Trim()))
                {
                    strErr += "电子邮箱格式不正确！\\n";
                }
            }
            //if (this.txtowner.Text.Trim().Length == 0)
            //{
            //    strErr += "法定代表人不能为空！\\n";
            //}
            //if (this.txtownertel.Text.Trim().Length == 0)
            //{
            //    strErr += "法定代表人电话不能为空！\\n";
            //}
            //if (this.txtownerqq.Text.Trim().Length == 0)
            //{
            //    strErr += "ownerqq不能为空！\\n";
            //}
            //if (this.txtcharge.Text.Trim().Length == 0)
            //{
            //    strErr += "主要负责人不能为空！\\n";
            //}
            //if (this.txtchargetel.Text.Trim().Length == 0)
            //{
            //    strErr += "主要负责人电话不能为空！\\n";
            //}
            //if (this.txtchargeqq.Text.Trim().Length == 0)
            //{
            //    strErr += "chargeqq不能为空！\\n";
            //}
            //if (this.txtsummary.Text.Trim().Length == 0)
            //{
            //    strErr += "summary不能为空！\\n";
            //}
            //if (this.txtremark.Text.Trim().Length == 0)
            //{
            //    strErr += "remark不能为空！\\n";
            //}

            if (strErr != "")
            {
                showDialogWithAlert(strErr);
                return;
            }
            WZY.Model.CUSTOMER model = new WZY.Model.CUSTOMER();
            if (isedit)
            {
                model = bll.GetModel(Convert.ToInt32(hidcustid.Value));
            }
            int cateid = int.Parse(this.ddlcate.Text);
            string custname = this.txtcustname.Text;
            string pycode = this.txtcustname.Text.Trim().toPinYin();
            string address = this.txtaddress.Text;
            string tel = this.txttel.Text;
            string fax = this.txtfax.Text;
            string post = this.txtpost.Text;
            string email = this.txtemail.Text;
            string owner = this.txtowner.Text;
            string ownertel = this.txtownertel.Text;
            string ownerqq = this.txtownerqq.Text;
            string charge = this.txtcharge.Text;
            string chargetel = this.txtchargetel.Text;
            string chargeqq = this.txtchargeqq.Text;
            string summary = this.txtsummary.Text;
            string remark = this.txtremark.Text;
            object ownerbirth = string.IsNullOrEmpty(this.txtownerbirthday.Text.Trim()) ? null : DateTime.Parse(this.txtownerbirthday.Text) as object;
            object chargebirth = string.IsNullOrEmpty(this.txtchargebirth.Text.Trim()) ? null : DateTime.Parse(this.txtchargebirth.Text) as object;
            string contact = this.txtcontel.Text;
            string contel = this.txtcontel.Text;

            model.cateid = cateid;
            if (!isedit) model.uid = suser.uid;//编辑状态暂不允许更改关联律师
            model.custname = custname;
            model.pycode = pycode;
            model.address = address;
            model.tel = tel;
            model.fax = fax;
            model.post = post;
            model.email = email;
            model.owner = owner;
            model.ownertel = ownertel;
            model.ownerqq = ownerqq;
            model.charge = charge;
            model.chargetel = chargetel;
            model.chargeqq = chargeqq;
            model.summary = summary;
            model.remark = remark;
            model.ownerbirth = (DateTime?)ownerbirth;
            model.chargebirth = (DateTime?)chargebirth;
            model.lunar1 = cbxluanr1.Checked ? 1 : 0;
            model.lunar2 = cbxlunar2.Checked ? 1 : 0;
            model.custno = lblcustno.Text;
            model.contact = txtcontact.Text;
            model.contel = txtcontel.Text;

            if (isedit)
            {
                bll.Update(model);
            }
            else
            {
                bll.Add(model);
                //外部链接的“添加客户”逻辑
                if (Request["frompage"] == "inner")
                {
                    closeDialog();
                    return;
                }
            }
            showDialogWithReload("保存成功");
        }
        catch (Exception ex)
        {
            showDialogWithAlert(ex.Message);
        }
    }


    public void btnCancle_Click(object sender, EventArgs e)
    {
        runJS("location.href=location.href;");
    }
}