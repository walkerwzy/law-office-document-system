﻿using System;
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
            ShowInfo(Convert.ToInt32(Request["id"]));
        }

        hiduserid.Value = suser.uid.ToString();
    }


    private void ShowInfo(int caseid)
    {
        WZY.DAL.CASES bll = new WZY.DAL.CASES();
        WZY.Model.CASES model = bll.GetModel(caseid);
        hidcaseid.Value = model.caseid.ToString();
        ddlcateid.Text = model.cateid.ToString();
        WZY.Model.CUSTOMER c = new WZY.DAL.CUSTOMER().GetModel(model.custid.Value);
        this.txtcustid.Text = c == null ? "" : c.custname;
        hidcust.Value = model.custid.ToString();
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
        this.txtpanjuetime.Text = model.panjuetime.HasValue ? model.panjuetime.Value.ToString("yyyy-MM-dd") : "";
        this.txtfee.Text = model.fee.ToString();
        this.ltdetail.Text = genFileLink(model.detail.Value, model.caseid, "detail");
        this.ltsusong.Text = genFileLink(model.analysis.Value, model.caseid, "analysis");
        this.ltevidence.Text = genFileLink(model.evidence.Value, model.caseid, "evidence");
        this.ltopinion.Text = genFileLink(model.opinion.Value, model.caseid, "opinion");
        this.ltdaili.Text = genFileLink(model.quote.Value, model.caseid, "quote");
        this.ltresult.Text = genFileLink(model.result.Value, model.caseid, "result");
        this.ltresultreport.Text = genFileLink(model.resultreport.Value, model.caseid, "resultreport");
        this.ltqisu.Text = genFileLink(model.qisu, model.caseid, "qisu");
        this.lttaolun.Text = genFileLink(model.taolun, model.caseid, "taolun");
        this.txtremark.Text = model.remark;
        lbltip.Visible = true;

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
            string yuangao = this.txtyuangao.Text;
            string beigao = this.txtbeigao.Text;
            string anyou = this.txtanyou.Text;
            object shouan = string.IsNullOrEmpty(txtshouan.Text.Trim())?null: DateTime.Parse(this.txtshouan.Text) as object;
            object dijiaotime = string.IsNullOrEmpty(txtdijiaotime.Text.Trim())?null: DateTime.Parse(this.txtdijiaotime.Text) as object;
            string faguan = this.txtfaguan.Text;
            string faguantel = this.txtfaguantel.Text;
            string office = this.txtoffice.Text;
            string court = this.txtcourt.Text;
            object kaiting = string.IsNullOrEmpty(txtkaiting.Text.Trim())?null: DateTime.Parse(this.txtkaiting.Text) as object;
            object panjuetime = string.IsNullOrEmpty(txtpanjuetime.Text.Trim()) ? null : DateTime.Parse(this.txtpanjuetime.Text) as object;
            decimal fee = string.IsNullOrEmpty(txtfee.Text.Trim()) ? 0 : decimal.Parse(this.txtfee.Text);

            int detail = upfile(updetail);
            int analysis = upfile(upsusong);
            int evidence = upfile(upevidence);
            int opinion = upfile(upopinion);
            int quote = upfile(updali);
            int result = upfile(upresult);
            int resultreport = upfile(upresultreport);
            int qisu = upfile(upqisu);
            int taolun = upfile(uptaolun);
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
            model.yuangao = yuangao;
            model.beigao = beigao;
            model.anyou = anyou;
            model.shouan = (DateTime?)shouan;
            model.dijiaotime = (DateTime?)dijiaotime;
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
            model.remark = remark;

            WZY.DAL.CASES bll = new WZY.DAL.CASES();
            if (isAdd) { bll.Add(model); showDialogWithReload("添加成功"); }
            else { bll.Update(model); showDialogWithReload("保存成功"); }

        }
        catch (Exception ex)
        {
            Helper.log.error("更新案件失败", ex.Message);
            showDialogWithAlert(ex.Message);
            return;
        }
    }


    public void btnCancle_Click(object sender, EventArgs e)
    {
        runJS("location.href=location.href;");
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
            if (extName != ".doc" && extName != ".docx")
            {
                showDialogWithAlert("请上传扩展名为.doc或.docx的文件！");
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
                model.cateid = 7;
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
        fmt += "<a href='#' class='icona' onclick='deldoc(this,{0},{1},\"{2}\");'><img src='images/delete.gif' alt='' />删除</a>";
        //string value = Utility.getConfigFile().Root.Descendants("uploadpath").Single().Value + filepath;
        return string.Format(fmt, docid.ToString(), caseid.ToString(), field);
    }

}