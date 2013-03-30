<%@ Page Language="C#" AutoEventWireup="true" CodeFile="visit_add.aspx.cs" Inherits="visit_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="/css/public.css" rel="stylesheet" type="text/css" />
    <link href="/js/autoComplete/default.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body{overflow-y:auto;}
        table{margin-top:30px;}
        td{ padding-bottom:3px;}
        textarea{height:60px;}
        input,textarea{border:1px solid #ddd;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField runat="server" ID="hiduserid" />
    <div id="formdiv">
        <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
    	<%--<tr>
	<td height="25" width="120px" align="right">
		拜访人：
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtuid" runat="server" Width="324px"></asp:TextBox>
	</td></tr>--%>
	<tr>
	<td height="25" width="120px" align="right">
		拜访客户
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtcustid" runat="server" Width="324px" CssClass="tinput" Height="24px"></asp:TextBox>
        <asp:HiddenField runat="server" ID="hidcustid" Value="" />
        <asp:Label runat="server"  ID="lblcustid" Width="324px" Visible="false" style="overflow:visible; white-space:nowrap;"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="120px" align="right" valign="top">
		拜访事由
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtreason" runat="server" CssClass="tinput" TextMode="MultiLine" style="width:324px; height:50px;"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="120px" align="right">
		拜访时间
	：</td>
	<td height="25" width="*" align="left">
        <asp:TextBox ID="txttime" runat="server" Width="324px" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" CssClass="tinput Wdate"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="120px" align="right" valign="top">
		拜访结果
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtresult" runat="server" CssClass="tinput" TextMode="MultiLine" style="width:324px; height:50px;"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="120px" align="right" valign="top">
		附加文件
	：</td>
	<td height="25" width="*" align="left">
		<asp:DropDownList runat="server" ID="ddldoctype" CssClass="tinput"></asp:DropDownList>
        <asp:FileUpload ID="fupfile" runat="server" />
	</td></tr>
	<tr>
	<td height="25" width="120px" align="right" valign="top">
		备注
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtremark" runat="server" TextMode="MultiLine" CssClass="tinput" style="width:324px;height:80px;"></asp:TextBox>
	</td></tr>
    <tr style="display:none;">
        <td class="tdbg" align="center" valign="bottom">
            <asp:LinkButton ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click"></asp:LinkButton>
            <asp:LinkButton ID="btnCancle" runat="server" Text="取消" OnClick="btnCancle_Click"></asp:LinkButton>
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
        $("#txtcustid").autoCmpt({ url: "ajaxHandler.aspx?act=customer&uid=" + $("#hiduserid").val() ,width:324});
    });
    var thisdg = frameElement.lhgDG;
    var savebtntxt = "添加";
    thisdg.addBtn('btnClose', '取消', function () { top.popAction(false); thisdg.cancel(); });
    thisdg.addBtn('btnClear', '清空', function () { __doPostBack('btnCancle', ''); });
    thisdg.addBtn('btnOk', '保存', function () { if (checkQuery()) __doPostBack('btnSave', ''); });
    function checkQuery() {
        if ($("#txtcustid").length > 0) {
            if ($.trim($("#txtcustid").val()) == "") { alert("拜访客户不能为空"); return false; } else { $("#hidcustid").val($.trim($("#txtcustid").attr("qid") || "-1")); var hust = $("#hidcustid").val(); if (hust == "" || hust == "-1") { alert("无效的客户，请重新选择"); return false; } }
        }
        if ($.trim($("#txtreason").val()) == "") { alert("拜访事由不能为空"); return false; }
        if(!/\d{4}-\d{2}-\d{2}/ig.test($.trim($("#txttime").val()))){alert("拜访时间不能为空，或格式不正确");return false;}
        thisdg.dg.style.display = "none";
        top.popAction(true);
        return true;
    }
</script>
</html>