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

public partial class case_add : validateUser
{
    protected int fileCount = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        DataTable dt = new WZY.DAL.CATE_CASE().GetList("").Tables[0];
        Helper.HelperDropDownList.BindData(ddlcateid, dt, "catename", "cateid", 0);

        if (Request["act"] == "modify")
        {
            var deptid = Request.QueryString["dept"];
            if (string.IsNullOrEmpty(deptid))
            {
                Response.Write("参数错误");
                Response.End();
            }
            hiddeptid.Value = deptid;
            ShowInfo(Convert.ToInt32(Request["id"]));
        }

        hiduserid.Value = suser.uid.ToString();
    }


    private void ShowInfo(int caseid)
    {
        fileCount = new WZY.DAL.DOCS().GetRecordCount("remark='case:" + caseid + "'");
        WZY.DAL.CASES bll = new WZY.DAL.CASES();
        var userDao = new WZY.DAL.SYSUSER();
        WZY.Model.CASES model = bll.GetModel(caseid);
        hidcaseid.Value = caseid.ToString();
        ddlcateid.Text = model.cateid.ToString();
        this.txtcustid.Text = new WZY.DAL.CUSTOMER().GetCustNameById(model.custid.Value);
        hidcust.Value = model.custid.ToString();
        this.txtlawid.Text = userDao.GetUserDisplayNameByID(model.lawid);
        hidlawid.Value = model.lawid.ToString();
        this.txtxieban.Text = userDao.GetUserDisplayNameByID(model.xieban);
        this.txtyuangao.Text = model.yuangao;
        this.txtbeigao.Text = model.beigao;
        this.txtanyou.Text = model.anyou;
        this.txtcourt.Text = model.court;
        this.txtshouan.Text = model.shouan.HasValue ? model.shouan.Value.ToString("yyyy-MM-dd") : "";
        this.txtdijiaotime.Text = model.dijiaotime.HasValue ? model.dijiaotime.Value.ToString("yyyy-MM-dd") : "";
        this.txtfaguan.Text = model.faguan;
        this.txtfaguantel.Text = model.faguantel;
        this.txtoffice.Text = model.office;
        this.txtkaiting.Text = model.kaiting.HasValue ? model.kaiting.Value.ToString("yyyy-MM-dd") : "";
        this.txtjuzheng.Text = model.juzheng.HasValue ? model.juzheng.Value.ToString("yyyy-MM-dd") : "";
        this.txtpanjuetime.Text = model.panjuetime.HasValue ? model.panjuetime.Value.ToString("yyyy-MM-dd") : "";
        this.txtfee.Text = model.fee.ToString();
        //this.ltdetail.Text = genFileLink(model.detail.Value, model.caseid, "detail");
        //this.ltsusong.Text = genFileLink(model.analysis.Value, model.caseid, "analysis");
        this.ltevidence.Text = genFileLink(model.evidence.Value, model.caseid, "evidence");
        this.ltopinion.Text = genFileLink(model.opinion.Value, model.caseid, "opinion");
        this.ltdaili.Text = genFileLink(model.quote.Value, model.caseid, "quote");
        //this.ltresult.Text = genFileLink(model.result.Value, model.caseid, "result");
        //this.ltresultreport.Text = genFileLink(model.resultreport.Value, model.caseid, "resultreport");
        this.ltqisu.Text = genFileLink(model.qisu, model.caseid, "qisu");
        //this.lttaolun.Text = genFileLink(model.taolun, model.caseid, "taolun");
        this.lttiwen.Text = genFileLink(model.tiwen, model.caseid, "tiwen");
        this.ltdabian.Text = genFileLink(model.dabian, model.caseid, "dabian");
        this.txtremark.Text = model.remark;

        updabian.Enabled = model.dabian == -1;
        updali.Enabled = model.quote.Value == -1;
        upevidence.Enabled = model.evidence.Value == -1;
        upopinion.Enabled = model.opinion.Value == -1;
        upqisu.Enabled = model.qisu == -1;
        uptiwen.Enabled = model.tiwen == -1;

        //lbltip.Visible = true;

        this.lblno.Text = model.caseno;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool isAdd = Request["act"] == "add";
        if (!isAdd)
        {
            string[] info = Request["info"].Split('|');
            //修改权限仅支持本人数据，部门负责人：部门数据，管理员：全部数据
            if (info[1] == suser.uid.ToString() || (info[2] == suser.deptid.ToString() && suser.roleid == 1) || suser.roleid == 0)
            { }
            else
            {
                showDialogWithAlert("无权限");
                return;
            }
        }
        string strErr = "";
        //if (ddlcateid.SelectedIndex == 0)
        //{
        //    strErr += "请选择案件分类！\\n";
        //}
        if (!PageValidate.IsNumber(hidcust.Value))
        {
            strErr += "请从客户中选择委托人！\\n";
        }
        if (!PageValidate.IsNumber(hidlawid.Value))
        {
            strErr += "请选择承办律师！\\n";
        }
        if (this.txtyuangao.Text.Trim().Length == 0)
        {
            strErr += "原告/申请人不能为空！\\n";
        }
        if (this.txtbeigao.Text.Trim().Length == 0)
        {
            strErr += "被告/被申请人不能为空！\\n";
        }
        if (this.txtanyou.Text.Trim().Length == 0)
        {
            strErr += "案由不能为空！\\n";
        }
        //if (!PageValidate.IsDateTime(txtshouan.Text))
        //{
        //    strErr += "收案时期格式错误！\\n";
        //}
        //if (!PageValidate.IsDateTime(txtdijiaotime.Text))
        //{
        //    strErr += "递交日期格式错误！\\n";
        //}
        //if (this.txtfaguan.Text.Trim().Length == 0)
        //{
        //    strErr += "承办法官不能为空！\\n";
        //}
        //if (this.txtfaguantel.Text.Trim().Length == 0)
        //{
        //    strErr += "法官电话不能为空！\\n";
        //}
        //if (this.txtoffice.Text.Trim().Length == 0)
        //{
        //    strErr += "法官办公室不能为空！\\n";
        //}
        //if (!PageValidate.IsDateTime(txtkaiting.Text))
        //{
        //    strErr += "开庭日期格式错误！\\n";
        //}
        //if (!PageValidate.IsDateTime(txtpanjuetime.Text))
        //{
        //    strErr += "判决时间格式错误！\\n";
        //}
        if (!string.IsNullOrEmpty(txtfee.Text.Trim()) && !PageValidate.IsDecimal(txtfee.Text))
        {
            strErr += "代理费用格式错误！\\n";
        }
        //if (!updetail.HasFile)
        //{
        //    strErr += "请上传案件详情！\\n";
        //}
        //if (!upsusong.HasFile)
        //{
        //    strErr += "请上传诉讼分析报告！\\n";
        //}
        //if (!upevidence.HasFile)
        //{
        //    strErr += "请上传当事人证据材料！\\n";
        //}
        //if (!upevidence.HasFile)
        //{
        //    strErr += "请上传质证意见！\\n";
        //}
        //if (!upopinion.HasFile)
        //{
        //    strErr += "请上传代理词/辩护词！\\n";
        //}
        //if (!upresult.HasFile)
        //{
        //    strErr += "请上传判决结果！\\n";
        //}
        //if (!upresultreport.HasFile)
        //{
        //    strErr += "请上传结案报告！\\n";
        //}
        //if (this.txtremark.Text.Trim().Length == 0)
        //{
        //    strErr += "remark不能为空！\\n";
        //}
        if (strErr != "")
        {
            showDialogWithJs(strErr, "$(\"#txtcustid\").attr(\"qid\", " + (string.IsNullOrEmpty(hidcust.Value) ? "-1" : hidcust.Value) + ");");
            return;
        }
        try
        {
            int cateid = int.Parse(ddlcateid.Text);
            int custid = int.Parse(hidcust.Value);
            int lawid = int.Parse(hidlawid.Value);
            int? xieban = hidxieban.Value == "-1" ? null : (int?)int.Parse(hidxieban.Value);
            string yuangao = this.txtyuangao.Text;
            string beigao = this.txtbeigao.Text;
            string anyou = this.txtanyou.Text;
            object shouan = string.IsNullOrEmpty(txtshouan.Text.Trim()) ? null : DateTime.Parse(this.txtshouan.Text) as object;
            object dijiaotime = string.IsNullOrEmpty(txtdijiaotime.Text.Trim()) ? null : DateTime.Parse(this.txtdijiaotime.Text) as object;
            string faguan = this.txtfaguan.Text;
            string faguantel = this.txtfaguantel.Text;
            string office = this.txtoffice.Text;
            string court = this.txtcourt.Text;
            object kaiting = string.IsNullOrEmpty(txtkaiting.Text.Trim()) ? null : DateTime.Parse(this.txtkaiting.Text) as object;
            object panjuetime = string.IsNullOrEmpty(txtpanjuetime.Text.Trim()) ? null : DateTime.Parse(this.txtpanjuetime.Text) as object;
            object juzheng = string.IsNullOrEmpty(txtjuzheng.Text.Trim()) ? null : DateTime.Parse(this.txtjuzheng.Text) as object;
            decimal fee = string.IsNullOrEmpty(txtfee.Text.Trim()) ? 0 : decimal.Parse(this.txtfee.Text);

            int detail = -1;// upfile(updetail);
            int analysis = -1;//upfile(upsusong);
            int evidence = upfile(upevidence, 11);
            int opinion = upfile(upopinion, 12);
            int quote = upfile(updali, 14);
            int result = -1;//upfile(upresult);
            int resultreport = -1;//upfile(upresultreport);
            int qisu = upfile(upqisu, 10);
            int taolun = -1;//upfile(uptaolun);
            int tiwen = upfile(uptiwen, 13);
            int dabian = upfile(updabian, 15);

            string remark = this.txtremark.Text;

            WZY.Model.CASES model = new WZY.Model.CASES();
            if (!isAdd)
            {
                model = new WZY.DAL.CASES().GetModel(int.Parse(hidcaseid.Value));
                if (model == null)
                {
                    showDialogWithAlert("数据出错");
                    return;
                }
            }
            else
            {
                model.uid = suser.uid;
            }
            model.cateid = cateid;
            model.custid = custid;
            model.lawid = lawid;
            if (isAdd || xieban != null) model.xieban = xieban;
            model.yuangao = yuangao;
            model.beigao = beigao;
            model.anyou = anyou;
            model.shouan = (DateTime?)shouan;
            model.dijiaotime = (DateTime?)dijiaotime;
            model.juzheng = (DateTime?)juzheng;
            model.faguan = faguan;
            model.faguantel = faguantel;
            model.court = court;
            model.office = office;
            model.kaiting = (DateTime?)kaiting;
            model.panjuetime = (DateTime?)panjuetime;
            model.fee = fee;
            if (detail != -1 || isAdd)
                model.detail = detail;
            if (analysis != -1 || isAdd)
                model.analysis = analysis;
            if (evidence != -1 || isAdd)
                model.evidence = evidence;
            if (opinion != -1 || isAdd)
                model.opinion = opinion;
            if (quote != -1 || isAdd)
                model.quote = quote;
            if (result != -1 || isAdd)
                model.result = result;
            if (resultreport != -1 || isAdd)
                model.resultreport = resultreport;
            if (qisu != -1 || isAdd)
                model.qisu = qisu;
            if (taolun != -1 || isAdd)
                model.taolun = taolun;
            if (tiwen != -1 || isAdd)
                model.tiwen = tiwen;
            if (dabian != -1 || isAdd)
                model.dabian = dabian;
            model.remark = remark;

            WZY.DAL.CASES bll = new WZY.DAL.CASES();
            if (isAdd) { bll.Add(model); showDialogWithReload("添加成功"); }
            else { bll.Update(model); showDialogWithReload("保存成功"); }

        }
        catch (Exception ex)
        {
            Helper.log.error("操作失败", ex.Message);
            showDialogWithAlert(ex.Message);
            return;
        }
    }


    public void btnCancle_Click(object sender, EventArgs e)
    {
        runJS("location.href=location.href;");
    }


    private int upfile(FileUpload fu, int cateid)
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
                showDialogWithAlert("请上传扩展名为.doc|.docx|.ppt|.pptx|.xls|.xlsx的文件！\\n或.jpg|.png格式的图片");
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
                model.typeid = 2;//诉讼业务
                model.cateid = cateid;
                model.custid = Helper.HelperDigit.ConvertToInt32(hidcust.Value, -1);
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

    //private void showDialogWithReload(string msg)
    //{
    //    runJS("alert('" + msg + "');frameElement.lhgDG.curWin.location.href='" + Request.QueryString["url"] + "';");
    //}
    //private void showDialogWithAlert(string msg)
    //{
    //    runJS("alert('" + msg + "');frameElement.lhgDG.dg.style.display = 'block'; top.popAction(false);");
    //}
    //private void showDialog()
    //{
    //    runJS("frameElement.lhgDG.dg.style.display = 'block'; top.popAction(false);");
    //}

    protected string genFileLink(int docid, int caseid, string field)
    {
        if (docid == -1)
        {
            return "";
        }
        string fmt = "<a href='ProcessFile.aspx?act=preview&d={0}' target='_blank' title='预览' class='icona'><img src='/images/preview.gif' alt='' />预览</a>";
        fmt += "<a href='ProcessFile.aspx?act=download&d={0}' target='_blank' class='icona' title='下载'><img src='/images/download.gif' title='下载' alt='' />下载</a>";
        if (canDel(hiddeptid.Value))
            fmt += "<a href='#' class='icona' onclick='deldoc(this,{0},{1},\"{2}\");'><img src='images/delete.gif' alt='' />删除</a>";
        else fmt += "<img src='images/delete.gif' alt='' style='vertical-align:middle;' /><span class='tgray'>&nbsp;删除</span>";
        //string value = Utility.getConfigFile().Root.Descendants("uploadpath").Single().Value + filepath;
        return string.Format(fmt, docid.ToString(), caseid.ToString(), field);
    }

    private bool canDel(string deptid)
    {
        if (suser.roleid == 0)
        {
            return true;
        }
        if (suser.roleid == 1 && suser.deptid.ToString() == deptid)
        {
            return true;
        }
        return false;
    }
}