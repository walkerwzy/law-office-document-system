using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LTP.Common;
using System.IO;
using System.Xml.Linq;
using System.Data;

public partial class multiupload : validateUser
{
    WZY.DAL.DOCS bll = new WZY.DAL.DOCS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = new WZY.DAL.CATE_DOC().GetList(" 1=1 order by seq ").Tables[0];
            //for (int i = 1; i < 9; i++)
            //{
            //    DropDownList ddl = Page.FindControl("DropDownList" + i) as DropDownList;
            //    Helper.HelperDropDownList.BindData(ddl, dt, "catename", "cateid", 0);
            //}
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
        if (strErr != "")
        {
            showDialogWithJs(strErr, "$(\"#txtcustid\").attr(\"qid\", " + (string.IsNullOrEmpty(hidcateid.Value) ? "-1" : hidcateid.Value) + ");");
            return;
        }
        int ctrfile = 0;//有文件就加1
        int ctr = 0;//文件成功上传才加1
        for (int i = 1; i < 9; i++)
        {
            FileUpload fuctrl = Page.FindControl("FileUpload" + i) as FileUpload;
            DropDownList ddlcate = Page.FindControl("DropDownList" + i) as DropDownList;
            DropDownList ddltype = Page.FindControl("DropDownList" + (i + 8)) as DropDownList;
            if (fuctrl.HasFile)
            {
                ctrfile++;
                if (fileupload(fuctrl, ddltype, ddlcate)) ctr++;
            }
        }
        if (ctrfile == 0) showDialogWithAlert("请至少上传一个文件");
        if (ctr == ctrfile) showDialogWithReload("上传成功");
        else showDialogWithAlert("部分上传失败");
    }

    //上传单个文件的方法
    private bool fileupload(FileUpload fu, DropDownList ddltype, DropDownList ddlcate)
    {
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
            return false;
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
            model.typeid = Helper.HelperDigit.ConvertToInt32(Request[ddltype.ID], -1);
            model.cateid = Helper.HelperDigit.ConvertToInt32(Request[ddlcate.ID], -1);
            model.custid = Helper.HelperDigit.ConvertToInt32(hidcateid.Value, -1);
            model.docname = orName;
            model.docpath = suser.displayname + @"\" + docname;
            model.remark = "";
            model.uid = suser.uid;
            model.uptime = DateTime.Now;

            int docid;
            try
            {
                docid = new WZY.DAL.DOCS().Add(model);
                return true;
            }
            catch (Exception ex)
            {
                Helper.log.error("批量上传文件失败", ex.Message);
                return false;
            }
        }
    }

    public void btnCancle_Click(object sender, EventArgs e)
    {
        runJS("location.href=location.href;");
    }

}