using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LTP.Common;
using System.IO;
using System.Xml.Linq;

public partial class qkupload : validateUser
{
    WZY.DAL.DOCS bll = new WZY.DAL.DOCS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Request["custid"]))
        {
            Response.Write("非法入口");
            Response.End();
        }
        if (!IsPostBack)
        {
            hidcateid.Value=Request["custid"];
            WZY.Model.CUSTOMER c=new WZY.DAL.CUSTOMER().GetModel(int.Parse(hidcateid.Value));
            if(c==null)
            {
                Response.Write("非法入口");
                Response.End();
            }
            txtcust.Text = c.custname;
            Helper.HelperDropDownList.BindData(ddltype, new WZY.DAL.cate_yewu().GetList(" 1=1 order by cate_index").Tables[0], "cate_name", "cate_id", 0);
            ddltype_TextChanged(null, null);
            hiduserid.Value = suser.uid.ToString();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string strErr = "";
        if (!PageValidate.IsNumber(hidcateid.Value))
        {
            strErr += "请选择客户！\\n";
        }
        if (!this.fu.HasFile)
        {
            strErr += "请选择上传文件！\\n";
        }

        if (strErr != "")
        {
            showDialogWithAlert(strErr);
            return;
        }
        XDocument xdoc = Utility.getConfigFile();
        string uploadpath = xdoc.Root.Descendants("uploadpath").SingleOrDefault().Value;
        string beckpath = xdoc.Root.Descendants("beckpath").SingleOrDefault().Value;
        string extName = System.IO.Path.GetExtension(fu.FileName).ToLower(); //获取文件扩展名
        string orName = System.IO.Path.GetFileNameWithoutExtension(fu.FileName);//不带扩展名的文件名
        orName = orName.Replace(" ", "");//去除文件名里的空格
        if (extName != ".doc" && extName != ".docx" && extName != ".pptx" && extName != ".ppt" && extName != ".xls" && extName != ".xlsx"
                    && extName != ".jpg" && extName != ".png")
        {
            showDialogWithAlert("请上传扩展名为.doc|.docx|.ppt|.pptx|.xls|.xlsx的文件！\n或.jpg|.png格式的图片");
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
            model.typeid = Helper.HelperDigit.ConvertToInt32(Request["ddltype"], -1);
            model.cateid = Helper.HelperDigit.ConvertToInt32(ddlcate.Text, -1);
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

    public void btnCancle_Click(object sender, EventArgs e)
    {
        runJS("location.href=location.href;");
    }

    protected void ddltype_TextChanged(object sender, EventArgs e)
    {
        Helper.HelperDropDownList.BindData(ddlcate, new WZY.DAL.CATE_DOC().GetListByType(ddltype.Text).Tables[0], "catename", "cateid", 0);
    }

}