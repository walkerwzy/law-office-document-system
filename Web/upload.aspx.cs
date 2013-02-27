using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LTP.Common;
using System.IO;
using System.Xml.Linq;

public partial class upload : validateUser
{
    WZY.DAL.DOCS bll = new WZY.DAL.DOCS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Helper.HelperDropDownList.BindData(ddltype, new WZY.DAL.cate_yewu().GetList(" 1=1 order by cate_index").Tables[0], "cate_name", "cate_id", 0);
            ddltype_TextChanged(null, null);
            hiduserid.Value = suser.uid.ToString();
            if (Request["act"] == "modify")
            {
                int docid = Helper.HelperDigit.ConvertToInt32(Request["id"], -1);
                if (docid != -1)
                {
                    ShowInfo(docid);
                }
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Request["act"] == "modify" && Request.QueryString["auth"] != "1")
        {
            showDialogWithAlert("无权限");
            return;
        }
        string strErr = "";
        if (!PageValidate.IsNumber(hidcateid.Value))
        {
            strErr += "请选择客户！\\n";
        }
        if (Request["act"].ToLower() != "modify" && !this.fu.HasFile)
        {
            strErr += "请选择上传文件！\\n";
        }

        if (strErr != "")
        {
            showDialogWithJs(strErr, "$(\"#txtcustid\").attr(\"qid\", " + (string.IsNullOrEmpty(hidcateid.Value) ? "-1" : hidcateid.Value) + ");");
            return;
        }
        if (Request["act"].ToLower() == "modify")
        {
            WZY.Model.DOCS model = bll.GetModel(Helper.HelperDigit.ConvertToInt32(hiddocid.Value, -1));
            model.custid = Convert.ToInt32(hidcateid.Value);
            model.typeid = Helper.HelperDigit.ConvertToInt32(Request["ddltype"], -1);
            model.cateid = Helper.HelperDigit.ConvertToInt32(ddlcate.Text, -1);
            model.docname = txtdocname.Text.Trim();
            model.remark = txtremark.Text.Trim();

            try
            {
                bll.Update(model);
                showDialogWithReload("保存成功");
            }
            catch (Exception ex)
            {
                Helper.log.error("修改文档失败：\n" + ex.Message);
                showDialogWithAlert("保存失败：\n" + ex.Message);
            }
            return;
        }
        XDocument xdoc = Utility.getConfigFile();
        string uploadpath = xdoc.Root.Descendants("uploadpath").SingleOrDefault().Value;
        string beckpath = xdoc.Root.Descendants("beckpath").SingleOrDefault().Value;
        string extName = System.IO.Path.GetExtension(fu.FileName).ToLower(); //获取文件扩展名
        string orName = System.IO.Path.GetFileNameWithoutExtension(fu.FileName);//不带扩展名的文件名
        orName = orName.Replace(" ", "");//去除文件名里的空格
        if (extName != ".doc" && extName != ".docx")
        {
            showDialogWithAlert("请上传扩展名为.doc或.docx的文件！");
        }
        else
        {
            //创建相关文件夹
            string userfolder = uploadpath + suser.displayname + @"\";
            if (!Directory.Exists(userfolder))
            {
                Directory.CreateDirectory(userfolder);
            }
            string prefix = DateTime.Now.ToString("yyMMddHHmmss_");
            string docname = prefix + orName + extName;
            //判断文件是否存在
            if (!File.Exists(userfolder + docname))
            {
                fu.PostedFile.SaveAs(userfolder + docname);
            }

            //上传备份文件
            string beckfolder = beckpath + suser.displayname + @"\";
            if (!Directory.Exists(beckfolder))
            {
                Directory.CreateDirectory(beckfolder);
            }
            if (!File.Exists(beckfolder + docname))
            {
                fu.PostedFile.SaveAs(beckfolder + docname);
            }

            //保存文档记录到数据库
            WZY.Model.DOCS model = new WZY.Model.DOCS();
            model.cateid = Helper.HelperDigit.ConvertToInt32(ddlcate.Text, -1);
            model.typeid = Helper.HelperDigit.ConvertToInt32(ddltype.Text, -1);
            model.custid = Helper.HelperDigit.ConvertToInt32(hidcateid.Value, -1);
            model.docname = string.IsNullOrEmpty(txtdocname.Text.Trim()) ? orName : txtdocname.Text.Trim();
            model.docpath = suser.displayname + @"\" + docname;
            model.remark = "";
            model.uid = suser.uid;
            model.uptime = DateTime.Now;

            int docid;
            try
            {
                docid = new WZY.DAL.DOCS().Add(model);
                showDialogWithReload("上传成功!");

            }
            catch (Exception ex)
            {
                showDialogWithAlert("上传失败:" + ex.Message);
            }
        }

    }

    private void ShowInfo(int docid)
    {
        WZY.Model.DOCS model = bll.GetModel(docid);
        this.hiddocid.Value = model.docid.ToString();
        this.hidcateid.Value = model.custid.ToString();
        this.ddlcate.Text = model.cateid.ToString();
        if (model.cateid == 7) ddlcate.Enabled = false;
        this.txtcust.Text = new WZY.DAL.CUSTOMER().GetModel(Convert.ToInt32(model.custid)).custname;
        this.ltpreview.Text = "<a href='ProcessFile.aspx?act=preview&d=" + model.docid + "' target='_blank' title='预览' class='icona'><img src='/images/preview.gif' alt='' />预览</a>";
        this.fu.Visible = false;
        this.txtdocname.Text = model.docname;
        this.lbldate.Text = model.uptime.ToString();
        this.txtremark.Text = model.remark;

    }

    public void btnCancle_Click(object sender, EventArgs e)
    {
        runJS("location.href=location.href;");
    }

    protected void ddltype_TextChanged(object sender, EventArgs e)
    {
        Helper.HelperDropDownList.BindData(ddlcate, new WZY.DAL.CATE_DOC().GetListByType(ddltype.Text).Tables[0], "catename", "cateid", 0);
    }
}