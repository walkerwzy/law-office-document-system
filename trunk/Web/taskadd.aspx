<%@ Page Language="C#" AutoEventWireup="true" CodeFile="taskadd.aspx.cs" Inherits="taskadd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="/css/public.css" rel="stylesheet" type="text/css" />
    <link href="/js/autoComplete/default.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #formdiv{ padding-top: 7px;}
        #formdiv textarea{ width: 500px;height: 75px;}
        .text-right{ text-align: right;vertical-align: top;}
        td{ padding: 5px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hidcustid"/>
        <asp:HiddenField runat="server" ID="hidid"/>
        <asp:HiddenField runat="server" ID="hidagent"/>
    <div id="formdiv">
        <table style="width:100%;" cellpadding="2" cellspacing="1" class="border">
            <tr>
                <td class="text-right" width="80">接收时间：</td><td width="170"><asp:Label runat="server" ID="lbltimereceive"></asp:Label></td>
                <td class="text-right" width="80">处理期限：</td><td width="240"><asp:TextBox runat="server" ID="txttimeexpire" CssClass="Wdate tinput" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" Width="220px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="text-right">提交人：</td><td><asp:Label runat="server" ID="lbluser"></asp:Label></td>
                <td class="text-right">承办人：</td><td><asp:TextBox runat="server" ID="txtagent" CssClass="tinput" Width="220px"></asp:TextBox><span class="tred"> *</span></td>
            </tr>
            <tr id="docs">
                <td class="text-right">原始资料：</td>
                <td colspan="3">
                    <% if (fileCount > 0)
                       { %><input type="button" class="btn1" onclick="viewAttatch();" value="查看" id="viewfile"/>已上传的<span class="tred" id="filecount" style="margin:0 2px; font-weight: 600;"><%= fileCount %></span>份文件，<% } else {%>
                    还未上传任何文件，
                    <%} %>
                    <a href="javascript:addAttatch();" class="btn1">点此<%if(fileCount>0){ %>继续<%} %>上传</a>
                </td>
            </tr>
            <tr>
                <td class="text-right">事项：</td>
                <td colspan="3">
                    <asp:TextBox ID="txttask" runat="server" TextMode="MultiLine" CssClass="tinput" Columns="10" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-right">跟踪：</td>
                <td colspan="3">
                    <asp:TextBox ID="txtfoot" runat="server" TextMode="MultiLine" CssClass="tinput" Columns="10" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="text-right">反馈：</td>
                <td colspan="3">
                    <asp:TextBox ID="txtfeedback" runat="server" TextMode="MultiLine" CssClass="tinput" Columns="10" Rows="5"></asp:TextBox>
                </td>
            </tr>
        </table>
        <div class="hide">
            <asp:LinkButton ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />
            <asp:LinkButton ID="btnCancle" runat="server" Text="清空" OnClick="btnCancle_Click" />
        </div>
    </div>
    </form>
<script src="/js/ca/WdatePicker.js" type="text/javascript"></script>
<script type="text/javascript" src="/js/jquery-1.8.2.min.js"></script>
<script src="/js/autoComplete/autoComplete.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function() {
            $("#txtagent").autoCmpt({ url: "/ajaxhandler.aspx?act=getuser", width: 220, hidden: $("#hidagent") });
            if ($("#filecount").text() == "0") $("#viewfile").prop("disabled", true);
        });
        var thisdg = frameElement.lhgDG,
            savebtntxt = "添加",
            reloadflag;
        thisdg.addBtn('btnClose', '取消', function () { top.popAction(false); thisdg.cancel(); });
        if ($("#hidid").val() == "") {
            thisdg.addBtn('btnClear', '清空', function () { __doPostBack('btnCancle', ''); });
            $("#docs").hide();
        } else {
            savebtntxt = "保存";
            $("#docs").show();
            $("#txtagent").attr("qid", $("#hidagent").val());
        }
        thisdg.addBtn('btnOk', savebtntxt, function () { if (checkQuery()) __doPostBack('btnSave', ''); });

        function checkQuery() {
            if ($.trim($("#hidagent").val()) == "") {
                alert("请选择承办人");
                return false;
            }
            thisdg.dg.style.display = "none";
            top.popAction(true);
            return true;
        }
        
        function addAttatch() {
            var recid = $("#hidid").val(),
                custid = $("#hidcustid").val(),
                dgaddattatch = new thisdg.curWin.$.dialog({
                    id: 'd2f3m', title: '上传原始资料', page: 'specialupload.aspx?type=task&caseid=' + recid + '&custid=' + custid + '&t=' + new Date().getMilliseconds(),
                    resize: false, width: 570, height: 360, cover: true, cancelBtn: false, rang: true
                });
            dgaddattatch.ShowDialog();
            watchFile();
        }
        function viewAttatch() {
            var recid = $("#hidid").val(),
                dgviewattatch = new thisdg.curWin.$.dialog({
                    id: 'd2f3t', title: '查看原始资料', page: 'batchview.aspx?type=task&id=' + recid + '&t=' + new Date().getMilliseconds(),
                    resize: false, width: 570, height: 390, cover: true, cancelBtn: false, rang: true
                });
            dgviewattatch.ShowDialog();
            watchFile();
        }
        function watchFile() {
            top.lhgflag = true;
            reloadflag = setInterval(function () {
                if (!top.lhgflag) {
                    location.href = location.href;
                    clearInterval(reloadflag);
                }
            }, 1000);
        }
    </script>
</body>
</html>
