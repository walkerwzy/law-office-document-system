using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using LTP.Common;
using System.IO;

public partial class employee : validateUser
{
    protected string photourl = "images/nopicture.gif";
    private bool isedit = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (string.IsNullOrEmpty(Request.QueryString["id"]) || string.IsNullOrEmpty(Request.QueryString["name"]))
            {
                Response.Write("illeage access");
                Response.End();
            }
            lblname.Text = Request.QueryString["name"];
            WZY.Model.employee model = new WZY.DAL.employee().GetModel(Request["id"]);
            if (model != null)
            {
                txtcertno.Text = model.cert;
                txtfamily.Text = model.family;
                txthuji.Text = model.hukou;
                txtrace.Text = model.nation;
                txtsummary.Text = model.summary;
                if(model.lizhi.HasValue) txtlizhi.Text = model.lizhi.Value.ToString("yyyy-MM-dd");
                if(model.baoxian.HasValue) txtbaoxian.Text = model.baoxian.Value.ToString("yyyy-MM-dd");
                if(model.birthday.HasValue) txtbirthday.Text = model.birthday.Value.ToString("yyyy-MM-dd");
                if(model.intime.HasValue) txtruzhi.Text = model.intime.Value.ToString("yyyy-MM-dd");
                if(model.formtime.HasValue) txtzhuanzheng.Text = model.formtime.Value.ToString("yyyy-MM-dd");
                if (!string.IsNullOrEmpty(model.photo))//如果有照片
                {
                    photourl = model.photo;
                }
                ddlsex.SelectedIndex = model.gender.Value;
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //有效性检测
        string strErr = "";
        if (!string.IsNullOrEmpty(txtbirthday.Text) && !PageValidate.IsDateTime(txtbirthday.Text))
        {
            strErr += "生日格式错误！\\n";
        }
        if (!string.IsNullOrEmpty(txtruzhi.Text) && !PageValidate.IsDateTime(txtruzhi.Text))
        {
            strErr += "入职时间格式错误！\\n";
        }
        if (!string.IsNullOrEmpty(txtzhuanzheng.Text) && !PageValidate.IsDateTime(txtzhuanzheng.Text))
        {
            strErr += "转正时间格式错误！\\n";
        }
        if (!string.IsNullOrEmpty(txtbaoxian.Text) && !PageValidate.IsDateTime(txtbaoxian.Text))
        {
            strErr += "买保险时间格式错误！\\n";
        }
        if (!string.IsNullOrEmpty(txtlizhi.Text) && !PageValidate.IsDateTime(txtlizhi.Text))
        {
            strErr += "离职时间格式错误！\\n";
        }

        if (strErr != "")
        {
            showDialogWithAlert(strErr);
            return;
        }
        WZY.DAL.employee bll = new WZY.DAL.employee();
        //编辑
        WZY.Model.employee model =  new WZY.DAL.employee().GetModel(Request.QueryString["id"]);
        if (model != null) isedit = true;
        else
        {
            isedit = false;
            model = new WZY.Model.employee();
        }
        string photo = "";
        if (isedit) photo = model.photo;
        if (fu.HasFile)
        {
            photo = upload();
            if (photo == "type error")
            {
                showDialogWithAlert("只支持.gif, .jpg, .png格式的图片");
                return;
            }
        }
        model.gender = ddlsex.SelectedIndex;
        model.hukou = txthuji.Text.Trim();
        model.cert = txtcertno.Text.Trim();
        model.family = txtfamily.Text.Trim();
        if(!string.IsNullOrEmpty(txtbaoxian.Text.Trim())) model.baoxian =Convert.ToDateTime(txtbaoxian.Text);
        if(!string.IsNullOrEmpty(txtbirthday.Text.Trim())) model.birthday = Convert.ToDateTime(txtbirthday.Text);
        if(!string.IsNullOrEmpty(txtzhuanzheng.Text.Trim())) model.formtime = Convert.ToDateTime(txtzhuanzheng.Text);
        if(!string.IsNullOrEmpty(txtruzhi.Text.Trim())) model.intime = Convert.ToDateTime(txtruzhi.Text);
        if(!string.IsNullOrEmpty(txtlizhi.Text.Trim())) model.lizhi = Convert.ToDateTime(txtlizhi.Text);
        model.nation = txtrace.Text.Trim();
        model.photo = photo;
        model.remark = "";
        model.summary = txtsummary.Text.Trim();
        model.uid = int.Parse(Request.QueryString["id"]);
        try
        {
            if (isedit)
            {
                bll.Update(model);
            }
            else
            {
                bll.Add(model);
            }
            showDialogWithReload("保存成功");
        }
        catch (Exception ex)
        {
            showDialogWithAlert(ex.Message);
        }
    }

    private string upload()
    {
        XDocument xdoc = Utility.getConfigFile();
        string uploadpath = Server.MapPath("~/pic/"); //xdoc.Root.Descendants("imgpath").SingleOrDefault().Value;
        string extName = System.IO.Path.GetExtension(fu.FileName).ToLower(); //获取文件扩展名
        string orName = System.IO.Path.GetFileNameWithoutExtension(fu.FileName);//不带扩展名的文件名
        orName = orName.Replace(" ", "");//去除文件名里的空格
        if (extName != ".gif" && extName != ".jpg" && extName != ".png")
        {
            return "type error";
        }
        else
        {
            //创建相关文件夹
            if (!Directory.Exists(uploadpath))
            {
                Directory.CreateDirectory(uploadpath);
            }
            string prefix = DateTime.Now.ToString("yyMMddHHmmss_");
            string docname = prefix + orName + extName;
            //判断文件是否存在
            if (!File.Exists(uploadpath + docname))
            {
                fu.PostedFile.SaveAs(uploadpath + docname);
            }
            return "/pic/" + docname;
        }
    }

    protected void btnCancle_Click(object sender, EventArgs e)
    {

    }
}