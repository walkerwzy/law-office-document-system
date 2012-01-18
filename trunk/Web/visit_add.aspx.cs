using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LTP.Common;
using System.Data;
using System.IO;
using System.Xml.Linq;

public partial class visit_add : validateUser
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hiduserid.Value = suser.uid.ToString();
            DataTable dt = new WZY.DAL.CATE_DOC().GetList("").Tables[0];
            Helper.HelperDropDownList.BindData(ddldoctype, dt, "catename", "cateid", 0);
            if (!string.IsNullOrEmpty(Request["id"]) && !string.IsNullOrEmpty(Request["custname"]))
            {
                txtcustid.Visible = false;
                hidcustid.Value = Request["id"];
                lblcustid.Text = Request["custname"];
                lblcustid.Visible = true;
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string strErr = "";
        if (!PageValidate.IsNumber(hidcustid.Value) && hidcustid.Value == "-1")
        {
            strErr += "请重新选择拜访客户！\\n";
        }
        if (this.txtreason.Text.Trim().Length == 0)
        {
            strErr += "拜访事由不能为空！\\n";
        }
        if (!PageValidate.IsDateTime(txttime.Text))
        {
            strErr += "拜访时间格式错误！\\n";
        }

        if (strErr != "")
        {
            showDialogWithJs(strErr, "$(\"#txtcustid\").attr(\"qid\", " + (string.IsNullOrEmpty(hidcustid.Value) ? "-1" : hidcustid.Value) + ");");
            return;
        }
        try
        {
            upfile(fupfile);//有文件的话顺便上传
            int uid = suser.uid;
            int custid = int.Parse(hidcustid.Value);
            string reason = this.txtreason.Text;
            DateTime time = DateTime.Parse(this.txttime.Text);
            string result = this.txtresult.Text;
            string remark = this.txtremark.Text;

            WZY.Model.VISIT model = new WZY.Model.VISIT();
            model.uid = uid;
            model.custid = custid;
            model.reason = reason;
            model.time = time;
            model.result = result;
            model.remark = remark;

            WZY.DAL.VISIT bll = new WZY.DAL.VISIT();
            bll.Add(model);

            showDialogWithReload("添加记录成功");
        }
        catch (Exception ex)
        {
            showDialogWithAlert(ex.Message);
        }
    }

    private int upfile(FileUpload fu)
    {
        XDocument xdoc = Utility.getConfigFile();
        string uploadpath = xdoc.Root.Descendants("uploadpath").SingleOrDefault().Value;
        string beckpath = xdoc.Root.Descendants("beckpath").SingleOrDefault().Value;
        if (fu.HasFile)
        {
            string extName = System.IO.Path.GetExtension(fu.FileName).ToLower(); //获取文件扩展名
            string orName = System.IO.Path.GetFileNameWithoutExtension(fu.FileName);//不带扩展名的文件名
            orName = orName.Replace(" ", "");//去除文件名里的空格
            if (extName != ".doc" && extName != ".docx" && extName != ".pptx" && extName != ".ppt" && extName != ".xls" && extName != ".xlsx"
            && extName != ".jpg" && extName != ".png")
            {
                showDialogWithAlert("请上传扩展名为.doc|.docx|.ppt|.pptx|.xls|.xlsx的文件！\n或.jpg|.png格式的图片");
                return -1;
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
                model.cateid = int.Parse(ddldoctype.Text);
                model.custid = Helper.HelperDigit.ConvertToInt32(hidcustid.Value, -1);
                model.docname = orName;
                model.docpath = suser.displayname + @"\" + docname;
                model.remark = "";
                model.uid = suser.uid;
                model.uptime = DateTime.Now;

                int docid;
                try
                {
                    docid = new WZY.DAL.DOCS().Add(model);
                    return docid;
                }
                catch
                {
                    return -1;
                }
                //return suser.displayname + @"\" + docname;
            }
        }
        return -1;

    }

    public void btnCancle_Click(object sender, EventArgs e)
    {
        runJS("location.href=location.href;");
    }
}