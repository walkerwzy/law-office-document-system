<%@ Page Language="C#" AutoEventWireup="true" CodeFile="upload.aspx.cs" Inherits="upload" %>

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
<table cellSpacing="0" cellPadding="0" width="100%" border="0" class="mytable">
	<tr>
	<td height="32" width="100px" align="right">
		主营业务
	：</td>
	<td height="32" width="*" align="left">
		<asp:DropDownList ToolTip="主营业务" runat="server" ID="ddltype"></asp:DropDownList>
	</td></tr>
	<tr>
	<td height="32" width="100px" align="right">
		文档类别
	：</td>
	<td height="32" width="*" align="left">
		<asp:DropDownList runat="server" ID="ddlcate" Width="324px" CssClass="tinput"></asp:DropDownList>
	</td></tr>
	<tr>
	<td height="32" width="100px" align="right">
		客户
	：</td>
	<td height="32" width="*" align="left">
        <asp:HiddenField runat="server" ID="hidcateid" />
        <asp:TextBox CssClass="tinput" Width="324px" ID="txtcust" runat="server"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="32" width="100px" align="right" runat="server">
		文件名
	：</td>
	<td height="32" width="*" align="left">
		<asp:TextBox CssClass="tinput" Width="200px" ID="txtdocname" runat="server" MaxLength="50"></asp:TextBox>
        <asp:Label runat="server" ID="lbldocname" CssClass="tgray">留空表示自动生成，推荐</asp:Label>
	</td></tr>
	<tr>
	<td height="32" width="100px" align="right">
		上传文件
	：</td>
	<td height="32" width="*" align="left">
		<asp:FileUpload runat="server" ID="fu" CssClass="tinput" style="width:324px; height:24px; border:1px solid #ccc;" />
        <asp:Literal runat="server" ID="ltpreview"></asp:Literal>
	</td></tr>
	<tr>
	<td id="Td1" height="32" width="100px" align="right" runat="server">
		上传时间
	：</td>
	<td height="32" width="*" align="left">
		<asp:Label runat="server" ID="lbldate" Text="自动生成"></asp:Label>
	</td></tr>
	<tr>
	<td height="32" width="100px" align="right" valign="top">
		备注
	：</td>
	<td height="32" width="*" align="left">
		<asp:TextBox CssClass="tinput" id="txtremark" runat="server" Width="324px" TextMode="MultiLine" Height="100" MaxLength="100"></asp:TextBox>
	</td>
    </tr>
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
        if ($.trim($("#fu").val()) == ""&&$("#hiddocid").val()=="") { alert("请选择上传文件"); return false; }
        thisdg.dg.style.display = "none";
        top.popAction(true);
        return true;
    }
</script>
</html>
