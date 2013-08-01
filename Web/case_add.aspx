<%@ Page Language="C#" AutoEventWireup="true" CodeFile="case_add.aspx.cs" Inherits="case_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/css/public.css" rel="stylesheet" type="text/css" />
    <link href="/js/autoComplete/default.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .title{background: #F2F4F6;}
        body{overflow-x:hidden;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField runat="server" ID="hidcaseid" Value="" />
    <asp:HiddenField runat="server" ID="hiduserid" Value="" />
    <asp:HiddenField runat="server" ID="hiddeptid" Value=""/>
    <div id="formdiv">
        <table style="width:100%;" cellpadding="2" cellspacing="1" class="border">
            <tr>
                <td class="tdbg">
                    <table cellspacing="0" cellpadding="0" width="700" align="center" border="0" style="margin-top: 15px;
                        margin-left: 17px;">
                        <tr class="title">
                            <td height="25" width="150px" align="right">
                                <b>&#187;</b>
                            </td>
                            <td colspan="3">
                                <b>案件详情：</b>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="150px" align="right">承办律师：</td>
                            <td height="25" width="*" align="left">
                                <asp:TextBox runat="server" ID="txtlawid" CssClass="tinput" Width="190px"></asp:TextBox><span class="tred">*</span>
                                <asp:HiddenField runat="server" ID="hidlawid" Value="-1"/>
                            </td>
                            <td height="25" width="150px" align="right">协办律师：</td>
                            <td height="25" width="*" align="left">
                                <asp:TextBox runat="server" ID="txtxieban" CssClass="tinput" Width="190px"></asp:TextBox>
                                <asp:HiddenField runat="server" ID="hidxieban" Value="-1"/>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="150px" align="right">
                                案件类别 ：
                            </td>
                            <td height="25" width="*" align="left">
                                <asp:DropDownList runat="server" ID="ddlcateid"></asp:DropDownList><span class="tred">*</span>
                            </td>
                            <td height="25" width="150px" align="right">
                                案件编号 ：
                            </td>
                            <td height="25" width="*" align="left">
                                <asp:Label runat="server" ID="lblno">自动生成</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="150px" align="right">
                                委托人 ：
                            </td>
                            <td height="25" width="*" align="left" colspan="3">
                                <asp:TextBox ID="txtcustid" runat="server" Width="380px" CssClass="tinput"></asp:TextBox>
                                <span class="tgray"><a href="javascript:addcust();">添加客户</a></span><span class="tred">*</span>
                                <asp:HiddenField runat="server" ID="hidcust" Value="-1" />
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="150px" align="right">
                                原告/申请人 ：
                            </td>
                            <td height="25" width="*" align="left">
                                <asp:TextBox ID="txtyuangao" runat="server" Width="190px" CssClass="tinput"></asp:TextBox><span class="tred">*</span>
                            </td>
                            <td height="25" width="150px" align="right">
                                被告/被申请人 ：
                            </td>
                            <td height="25" width="*" align="left">
                                <asp:TextBox ID="txtbeigao" runat="server" Width="190px" CssClass="tinput"></asp:TextBox><span class="tred">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="150px" align="right">
                                案由 ：
                            </td>
                            <td height="25" width="*" align="left" colspan="3">
                                <asp:TextBox ID="txtanyou" runat="server" Width="534px" CssClass="tinput"></asp:TextBox><span class="tred">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="150px" align="right">
                                收案日期 ：
                            </td>
                            <td height="25" width="*" align="left">
                                <asp:TextBox ID="txtshouan" runat="server" Width="190px" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});"
                                    CssClass="tinput Wdate"></asp:TextBox>
                            </td>
                            <td height="25" width="150px" align="right">
                                递交委托手续/立案时间 ：
                            </td>
                            <td height="25" width="*" align="left">
                                <asp:TextBox ID="txtdijiaotime" runat="server" Width="190px" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});"
                                    CssClass="tinput Wdate"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="150px" align="right">
                                承办法官 ：
                            </td>
                            <td height="25" width="*" align="left">
                                <asp:TextBox ID="txtfaguan" runat="server" Width="190px" CssClass="tinput"></asp:TextBox>
                            </td>
                            <td height="25" width="150px" align="right">
                                法官电话 ：
                            </td>
                            <td height="25" width="*" align="left">
                                <asp:TextBox ID="txtfaguantel" runat="server" Width="190px" CssClass="tinput"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                        <td height="25" width="150px" align="right">法官办公室：</td>
                        <td colspan="3">
                                <asp:TextBox ID="txtoffice" runat="server" Width="534px" CssClass="tinput"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td height="25" width="150px" align="right">
                                审理法院：
                            </td>
                            <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtcourt" runat="server" Width="190px" CssClass="tinput"></asp:TextBox>
                            </td>
                            <td height="25" width="150px" align="right">
                                开庭时间 ：
                            </td>
                            <td height="25" width="*" align="left">
                                <asp:TextBox ID="txtkaiting" runat="server" Width="190px" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});"
                                    CssClass="tinput Wdate"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="150px" align="right">
                                判决时间 ：
                            </td>
                            <td height="25" width="*" align="left">
                                <asp:TextBox ID="txtpanjuetime" runat="server" Width="190px" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});"
                                    CssClass="tinput Wdate"></asp:TextBox>
                            </td>
                            <td height="25" width="150px" align="right">
                                代理费用 ：
                            </td>
                            <td height="25" width="*" align="left">
                                <asp:TextBox ID="txtfee" runat="server" Width="190px" CssClass="tinput"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="150px" align="right">
                                举证期限 ：
                            </td>
                            <td height="25" width="*" align="left" colspan="3">
                                <asp:TextBox ID="txtjuzheng" runat="server" Width="190px" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});"
                                    CssClass="tinput Wdate"></asp:TextBox>
                            </td>
                        </tr>
                        <tr class="title">
                            <td height="25" width="150px" align="right">
                                <b>&#187;</b>
                            </td>
                            <td colspan="3">
                                <b>附属文件：</b>
                                <%--<asp:Label runat="server" ID="lbltip" ForeColor="Gray" Visible="false">上传会覆盖之前的文件，请谨慎</asp:Label>--%>
                                <span class="tgray">请上传扩展名为.doc .docx .ppt .pptx .xls .xlsx的文件，或.jpg .png格式的图片</span>
                            </td>
                        </tr>
                        <%--<tr>
                            <td height="25" width="150px" align="right">
                                案件详情 ：
                            </td>
                            <td height="25" width="*" align="left" colspan="3">
                                <asp:FileUpload ID="updetail" runat="server" Width="400px"  /><asp:Literal runat="server" ID="ltdetail"></asp:Literal>
                            </td>
                        </tr>--%>
                        <%--<tr>
                            <td height="25" width="150px" align="right">
                                诉讼分析报告 ：
                            </td>
                            <td height="25" width="*" align="left" colspan="3">
                                <asp:FileUpload ID="upsusong" runat="server" Width="400px" /><asp:Literal runat="server" ID="ltsusong"></asp:Literal>
                            </td>
                        </tr>--%>
                        <tr>
                            <td height="25" width="150px" align="right">
                                证据目录 ：
                            </td>
                            <td height="25" width="*" align="left" colspan="3">
                                <asp:FileUpload ID="upevidence" runat="server" Width="400px"  /><asp:Literal runat="server" ID="ltevidence"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="150px" align="right">
                                起诉状/上诉状 ：
                            </td>
                            <td height="25" width="*" align="left" colspan="3">
                                <asp:FileUpload ID="upqisu" runat="server" Width="400px"  /><asp:Literal runat="server" ID="ltqisu"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="150px" align="right">
                                质证意见 ：
                            </td>
                            <td height="25" width="*" align="left" colspan="3">
                                <asp:FileUpload ID="upopinion" runat="server" Width="400px"  /><asp:Literal runat="server" ID="ltopinion"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="150px" align="right">
                                代理意见 ：
                            </td>
                            <td height="25" width="*" align="left" colspan="3">
                                <asp:FileUpload ID="updali" runat="server" Width="400px"  /><asp:Literal runat="server" ID="ltdaili"></asp:Literal>
                            </td>
                        </tr>
                        <%--<tr>
                            <td height="25" width="150px" align="right">
                                判决结果 ：
                            </td>
                            <td height="25" width="*" align="left" colspan="3">
                                <asp:FileUpload ID="upresult" runat="server" Width="400px"  /><asp:Literal runat="server" ID="ltresult"></asp:Literal>
                            </td>
                        </tr>--%>
                        <%--<tr>
                            <td height="25" width="150px" align="right">
                                结案报告 ：
                            </td>
                            <td height="25" width="*" align="left" colspan="3">
                                <asp:FileUpload ID="upresultreport" runat="server" Width="400px"  /><asp:Literal runat="server"
                                    ID="ltresultreport"></asp:Literal>
                            </td>
                        </tr>--%>
                        <%--<tr>
                            <td height="25" width="150px" align="right">
                                案件讨论记录 ：
                            </td>
                            <td height="25" width="*" align="left" colspan="3">
                                <asp:FileUpload ID="uptaolun" runat="server" Width="400px"  /><asp:Literal runat="server" ID="lttaolun"></asp:Literal>
                            </td>
                        </tr>--%>
                        <tr>
                            <td height="25" width="150px" align="right">
                                法庭提问 ：
                            </td>
                            <td height="25" width="*" align="left" colspan="3">
                                <asp:FileUpload ID="uptiwen" runat="server" Width="400px"  /><asp:Literal runat="server" ID="lttiwen"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="150px" align="right">
                                答辩意见 ：
                            </td>
                            <td height="25" width="*" align="left" colspan="3">
                                <asp:FileUpload ID="updabian" runat="server" Width="400px"  /><asp:Literal runat="server" ID="ltdabian"></asp:Literal>
                            </td>
                        </tr>
                        <tr class="attatch">
                            <td height="25" width="150px" align="right">
                                附加文件 ：
                            </td>
                            <td height="25" width="*" align="left" colspan="3">
                                <a href="javascript:viewAttatch();" class="btn1">查看文件</a>
                                <a href="javascript:addAttatch();" class="btn1">上传附加文件</a>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="150px" align="right" valign="top">
                                跟踪情况：
                            </td>
                            <td height="25" width="*" align="left" colspan="3">
                                <asp:TextBox ID="txtremark" runat="server" Width="534px" Height="95px" TextMode="MultiLine"
                                    CssClass="tinput"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="display: none;">
                <td class="tdbg" align="center" valign="bottom">
                    <asp:LinkButton ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />
                    <asp:LinkButton ID="btnCancle" runat="server" Text="清空" OnClick="btnCancle_Click" />
                </td>
            </tr>
        </table>
        <br />
    </div>
    </form>
</body>
<script src="/js/ca/WdatePicker.js" type="text/javascript"></script>
<script type="text/javascript" src="/js/jquery-1.8.2.min.js"></script>
<script src="/js/autoComplete/autoComplete.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $("#txtcustid").autoCmpt({ url: "/ajaxHandler.aspx?act=customer&uid=" + $("#hiduserid").val(), width: 380, hidden: $("#hidcust") });
        $("#txtlawid").autoCmpt({ url: "/ajaxhandler.aspx?act=getuser", width: 190, hidden: $("#hidlawid") });
        $("#txtxieban").autoCmpt({ url: "/ajaxHandler.aspx?act=getuser", width: 190, hidden: $("#hidxieban") });
    });
    var thisdg = frameElement.lhgDG;
    var savebtntxt = "添加";
    thisdg.addBtn('btnClose', '取消', function () { top.popAction(false); thisdg.cancel(); });
    if ($("#hidcaseid").val() == "") {
        thisdg.addBtn('btnClear', '清空', function () { __doPostBack('btnCancle', ''); });
        $("tr.attatch").hide();
    } else {
        savebtntxt = "保存";
        $("#txtcustid").attr("qid", $("#hidcust").val());
        $("#txtlawid").attr("qid", $("#hidlawid").val());
    }
    thisdg.addBtn('btnOk', savebtntxt, function () { if (checkQuery()) __doPostBack('btnSave', ''); });
    function checkQuery() {
        if ($("#ddlcateid").val() == "") { alert('请选择案件分类'); return false; }
        if ($.trim($("#txtlawid").val()) == "") { alert("承办律师不能为空"); return false; } else { $("#hidlawid").val($.trim($("#txtlawid").attr("qid"))); var hlaw = $("#hidlawid").val(); if (hlaw == "" || hlaw == "-1") { alert("无效的承办律师，请重新选择"); return false; } }
        if ($.trim($("#txtcustid").val()) == "") { alert("委托人不能为空"); return false; } else { $("#hidcust").val($.trim($("#txtcustid").attr("qid"))); var hust = $("#hidcust").val(); if (hust == "" || hust == "-1") { alert("无效的委托人，请重新选择"); return false; } }
        if ($.trim($("#txtyuangao").val()) == "") { alert("原告/申请人不能为空"); return false; }
        if ($.trim($("#txtbeigao").val()) == "") { alert("被告/被申请人不能为空"); return false; }
        if ($.trim($("#txtanyou").val()) == "") { alert("案由不能为空");return false;}
//        if ($.trim($("#txtfaguan").val()) == "") { alert("承办法官不能为空"); return }
//        if ($.trim($("#txtfaguantel").val()) == "") { alert("法官电话不能为空"); return }
//        if ($.trim($("#txtoffice").val()) == "") { alert("法官办公室不能为空"); return }
        if (!/^[0-9\]+\.?[0-9]*$/.test($.trim($("#txtfee").val()))) {if ($.trim($("#txtfee").val()) != "") { alert('代理费用请输入数字'); return false; } }
//        if ($.trim($("#txtshouan").val()) == "") { alert("收案时间不能为空"); return false; }
//        if ($.trim($("#txtdijiaotime").val()) == "") { alert("递交委托手续时间不能为空"); return false; }
//        if ($.trim($("#txtkaiting").val()) == "") { alert("开庭时间不能为空"); return false; }
        //        if ($.trim($("#txtpanjuetime").val()) == "") { alert("判决时间不能为空"); return false; }
        //        if ($.trim($("#updali").val()) == "") { alert("挂号起始时间不能为空"); return }
        //        if ($.trim($("#upresult").val()) == "") { alert("挂号起始时间不能为空"); return }
        //        if ($.trim($("#upresultreport").val()) == "") { alert("挂号结束时间不能为空"); return }
        //        if (flag) {
        thisdg.dg.style.display = "none";
        top.popAction(true);
        //        }
        //        return flag;
        return true;
    }
    function addqid(id) { $("#txtcustid").attr("qid", id); }
    function deldoc(obj, id, caseid, field) {
        if (!confirm("确认删除？")) return;
        //ajax删除文件
        $.get("ajaxHandler.aspx", { act: "delcasefile", t: new Date().getMilliseconds(), id: id,caseid:caseid, field: field }, function (d) {
            if (d == "1") {
                alert("删除成功"); $(obj).closest("td").find("a").remove();
                location.reload();
            } else { alert("删除失败"); }
        });
    }
    function addcust() {
        var dgaddcust = new thisdg.curWin.$.dialog({ id: 'd2add', title: '添加客户', page: 'cust_add.aspx?act=add&frompage=inner&t=' + new Date().getMilliseconds() + '&url=' + location.pathname,
            resize: true, width: 750, height: 540, cover: false, cancelBtn: false, rang: true
        });
        dgaddcust.ShowDialog();
    }
    function addAttatch() {
        var caseid = $("#hidcaseid").val(),
            custid=$("#hidcust").val(),
            dgaddattatch = new thisdg.curWin.$.dialog({
                id: 'd2f3m', title: '上传案件附加文档', page: 'specialupload.aspx?type=case&caseid='+caseid+'&custid='+custid+'&t=' + new Date().getMilliseconds(),
                resize: false, width: 570, height: 360, cover: true, cancelBtn: false, rang: true
            });
        dgaddattatch.ShowDialog();
    }
    function viewAttatch() {
        var caseid = $("#hidcaseid").val(),
            dgviewattatch = new thisdg.curWin.$.dialog({
                id: 'd2f3t', title: '查看案件附加文档', page: 'batchview.aspx?type=case&id=' + caseid + '&t=' + new Date().getMilliseconds(),
                resize: false, width: 570, height: 390, cover: true, cancelBtn: false, rang: true
            });
        dgviewattatch.ShowDialog();
    }
</script>   
</html>
