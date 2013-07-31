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

/*
 * 本页面为上传案件附加文件、上传客户维护日志用
 * 如果为案件附加文档，则借用了文档的“备注”字段，用来保存案件ID
 * 如果为客户维护日志，虽然文档类型用即有的【常规业务>原始资料】，为了关联，还是用了“备注”字段标识是哪一条维护记录的文档，用【log+记录ID】标识
 */
public partial class specialupload : validateUser
{
    WZY.DAL.DOCS bll = new WZY.DAL.DOCS();
    private int custid = -1;
    private int caseid = -1;//案件ID或维护日志记录ID
    private bool caseFile = true;
    private int typeid = 2;//诉讼业务
    private int cateid = 18;//案件附加文件
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        caseFile = Request.QueryString["type"] == "case";
        var custok = int.TryParse(Request.QueryString["custid"], out custid);
        var caseok = int.TryParse(Request.QueryString["caseid"], out caseid);
        if (caseFile && (!custok || !caseok)) //上传案件附件文件
        {
            Response.Write("参数不全");
            Response.End();
        }
        else if (!caseFile && !custok) //上传客户维护文件
        {
            Response.Write("参数不全");
            Response.End();
        }
        hidcateid.Value = custid.ToString();//cust
        hiduserid.Value = suser.uid.ToString();//user
        hidcaseid.Value = caseid.ToString(); //case
        if (!caseFile)
        {
            typeid = 1;//常年业务
            cateid = 17;//原始资料
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
    //    string strErr = "";
    //    if (!PageValidate.IsNumber(hidcateid.Value))
    //    {
    //        strErr += "请选择客户！\\n";
    //    }
    //    if (strErr != "")
    //    {
    //        showDialogWithAlert(strErr);
    //        return;
    //    }
    //    int ctrfile = 0;//有文件就加1
    //    int ctr = 0;//文件成功上传才加1
    //    for (int i = 1; i < 9; i++)
    //    {
    //        FileUpload fuctrl = Page.FindControl("FileUpload" + i) as FileUpload;
    //        if (fuctrl.HasFile)
    //        {
    //            ctrfile++;
    //            if (fileupload(fuctrl)) ctr++;
    //        }
    //    }
    //    if (ctrfile == 0) showDialogWithAlert("请至少上传一个文件");
    //    if (ctr == ctrfile) showDialogWithReload3("上传成功");
    //    else showDialogWithAlert("部分上传失败");
        //showDialogWithReload3("fsda");
        closeDialog();
}

    //上传单个文件的方法
    private bool fileupload(FileUpload fu)
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
            showDialogWithAlert("请上传扩展名为.doc|.docx|.ppt|.pptx|.xls|.xlsx的文件！\\n或.jpg|.png格式的图片");
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
            caseid = int.Parse(hidcaseid.Value);
            custid = int.Parse(hidcateid.Value);
            WZY.Model.DOCS model = new WZY.Model.DOCS();
            model.typeid = typeid;
            model.cateid = cateid;
            model.custid = custid;
            model.docname = orName;
            model.docpath = suser.displayname + @"\" + docname;
            model.remark = (caseFile ? "case:" : "log:") + caseid;
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
                Helper.log.error("上传" + (caseFile ? "案件附加" : "客户维护原始资料") + "文件失败", ex.Message);
                return false;
            }
        }
    }

    public void btnCancle_Click(object sender, EventArgs e)
    {
        runJS("location.href=location.href;");
    }

}