<%@ Page Language="C#" AutoEventWireup="true" CodeFile="multiupload.aspx.cs" Inherits="multiupload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>上传文件</title>
    <link href="css/public.css" rel="stylesheet" type="text/css" />
    <link href="/js/autoComplete/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:HiddenField runat="server" ID="hiddocid" Value="" />
    <asp:HiddenField runat="server" ID="hiduserid" />
    <br />
<table cellSpacing="0" cellPadding="0" width="100%" border="0" class="mytable">
	<tr>
	<td height="32" width="80px" align="right">
		客户
	：</td>
	<td height="32" width="*" align="left" colspan="3">
        <asp:HiddenField runat="server" ID="hidcateid" />
        <asp:TextBox CssClass="tinput" Width="324px" ID="txtcust" runat="server"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="32" width="80px" align="right">
		上传文件
	：</td>
	<td height="32" width="330px" align="left">
		<asp:FileUpload runat="server" ID="FileUpload1" CssClass="tinput" style="width:324px; height:24px; border:1px solid #ccc;" />
        <asp:Literal runat="server" ID="ltpreview"></asp:Literal>
	</td>
	<td height="32" width="80px" align="right">
		文档类别
	：</td>
	<td height="32" width="*" align="left">
		<asp:DropDownList runat="server" ID="DropDownList1" CssClass="tinput"></asp:DropDownList>
	</td></tr>
	<tr>
	<td height="32" width="80px" align="right">
		上传文件
	：</td>
	<td height="32" width="330px" align="left">
		<asp:FileUpload runat="server" ID="FileUpload2" CssClass="tinput" style="width:324px; height:24px; border:1px solid #ccc;" />
        <asp:Literal runat="server" ID="Literal1"></asp:Literal>
	</td>
	<td height="32" width="80px" align="right">
		文档类别
	：</td>
	<td height="32" width="*" align="left">
		<asp:DropDownList runat="server" ID="DropDownList2" CssClass="tinput"></asp:DropDownList>
	</td></tr>
	<tr>
	<td height="32" width="80px" align="right">
		上传文件
	：</td>
	<td height="32" width="330px" align="left">
		<asp:FileUpload runat="server" ID="FileUpload3" CssClass="tinput" style="width:324px; height:24px; border:1px solid #ccc;" />
        <asp:Literal runat="server" ID="Literal2"></asp:Literal>
	</td>
	<td height="32" width="80px" align="right">
		文档类别
	：</td>
	<td height="32" width="*" align="left">
		<asp:DropDownList runat="server" ID="DropDownList3" CssClass="tinput"></asp:DropDownList>
	</td></tr>
	<tr>
	<td height="32" width="80px" align="right">
		上传文件
	：</td>
	<td height="32" width="330px" align="left">
		<asp:FileUpload runat="server" ID="FileUpload4" CssClass="tinput" style="width:324px; height:24px; border:1px solid #ccc;" />
        <asp:Literal runat="server" ID="Literal3"></asp:Literal>
	</td>
	<td height="32" width="80px" align="right">
		文档类别
	：</td>
	<td height="32" width="*" align="left">
		<asp:DropDownList runat="server" ID="DropDownList4" CssClass="tinput"></asp:DropDownList>
	</td></tr>
	<tr>
	<td height="32" width="80px" align="right">
		上传文件
	：</td>
	<td height="32" width="330px" align="left">
		<asp:FileUpload runat="server" ID="FileUpload5" CssClass="tinput" style="width:324px; height:24px; border:1px solid #ccc;" />
        <asp:Literal runat="server" ID="Literal4"></asp:Literal>
	</td>
	<td height="32" width="80px" align="right">
		文档类别
	：</td>
	<td height="32" width="*" align="left">
		<asp:DropDownList runat="server" ID="DropDownList5" CssClass="tinput"></asp:DropDownList>
	</td></tr>
	<tr>
	<td height="32" width="80px" align="right">
		上传文件
	：</td>
	<td height="32" width="330px" align="left">
		<asp:FileUpload runat="server" ID="FileUpload6" CssClass="tinput" style="width:324px; height:24px; border:1px solid #ccc;" />
        <asp:Literal runat="server" ID="Literal5"></asp:Literal>
	</td>
	<td height="32" width="80px" align="right">
		文档类别
	：</td>
	<td height="32" width="*" align="left">
		<asp:DropDownList runat="server" ID="DropDownList6" CssClass="tinput"></asp:DropDownList>
	</td></tr>
	<tr>
	<td height="32" width="80px" align="right">
		上传文件
	：</td>
	<td height="32" width="330px" align="left">
		<asp:FileUpload runat="server" ID="FileUpload7" CssClass="tinput" style="width:324px; height:24px; border:1px solid #ccc;" />
        <asp:Literal runat="server" ID="Literal6"></asp:Literal>
	</td>
	<td height="32" width="80px" align="right">
		文档类别
	：</td>
	<td height="32" width="*" align="left">
		<asp:DropDownList runat="server" ID="DropDownList7" CssClass="tinput"></asp:DropDownList>
	</td></tr>
	<tr>
	<td height="32" width="80px" align="right">
		上传文件
	：</td>
	<td height="32" width="330px" align="left">
		<asp:FileUpload runat="server" ID="FileUpload8" CssClass="tinput" style="width:324px; height:24px; border:1px solid #ccc;" />
        <asp:Literal runat="server" ID="Literal7"></asp:Literal>
	</td>
	<td height="32" width="80px" align="right">
		文档类别
	：</td>
	<td height="32" width="*" align="left">
		<asp:DropDownList runat="server" ID="DropDownList8" CssClass="tinput"></asp:DropDownList>
	</td></tr>
        <tr style="display:none;">
            <td class="tdbg" align="center" valign="bottom">
                <asp:LinkButton ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click"></asp:LinkButton>
                <asp:LinkButton ID="btnCancle" runat="server" Text="取消" OnClick="btnCancle_Click"></asp:LinkButton>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
<script type="text/javascript" src="/js/jquery-1.6.2.min.js"></script>
<script type="text/javascript" src="/js/autoComplete/autoComplete.js"></script>
<script type="text/javascript">
    $(function () {
        $("#txtcust").autoCmpt({ url: "ajaxHandler.aspx?act=customer&uid=" + $("#hiduserid").val(), width: 324 });
        $("#txtcust").attr("qid", $("#hidcateid").val() || "");
    });
    var thisdg = frameElement.lhgDG;
    thisdg.addBtn('btnClose', '取消', function () { top.popAction(false); thisdg.cancel(); });
    if($("#hiddocid").val()=="") thisdg.addBtn('btnClear', '清空', function () { __doPostBack('btnCancle', ''); });
    thisdg.addBtn('btnOk', '保存', function () { if (checkQuery()) __doPostBack('btnSave', ''); });
    function checkQuery() {
        var hidcateid = $.trim($("#hidcateid").val($("#txtcust").attr("qid")).val());
        if (hidcateid == "" || hidcateid == "-1") { alert("请选择客户"); return false; }
        thisdg.dg.style.display = "none";
        top.popAction(true);
        return true;
    }
</script>
</html>
