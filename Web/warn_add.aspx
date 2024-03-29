﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="warn_add.aspx.cs" Inherits="warn_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/public.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <br /><br />
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		事件内容
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtcont" runat="server" Width="200px" CssClass="tinput" TextMode="MultiLine" style="height:70px;"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		事件时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtalerttime" runat="server" Width="200px" CssClass="Wdate tinput" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" ></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		不公开
	：</td>
	<td height="25" width="*" align="left">
    <asp:CheckBox runat="server" ID="cbxprivate"  Checked="true" /><span class="tgray">不公开的日程只有本人能查看</span>
	</td></tr>
    <tr style="display:none;">
            <td class="tdbg" align="center" valign="bottom">
                <asp:LinkButton ID="btnSave" runat="server" Text="保存"
                    OnClick="btnSave_Click" ></asp:LinkButton>
                <asp:LinkButton ID="btnCancle" runat="server" Text="取消"
                    OnClick="btnCancle_Click"></asp:LinkButton>
            </td>
        </tr>
</table>
    </div>
    </form>
</body>
<script src="/js/ca/WdatePicker.js" type="text/javascript"></script>
<script type="text/javascript" src="/js/jquery-1.8.2.min.js"></script>
<script type="text/javascript">
    var thisdg = frameElement.lhgDG;
    thisdg.addBtn('btnClose', '取消', function () { top.popAction(false); thisdg.cancel(); });
    thisdg.addBtn('btnClear', '清空', function () { __doPostBack('btnCancle', ''); });
    thisdg.addBtn('btnOk', '添加', function () { if (checkQuery()) __doPostBack('btnSave', ''); });
    function checkQuery() {
        if ($.trim($("#txtcont").val()) == "") { alert("事件内容不能为空"); return false; }
        if ($.trim($("#txtalerttime").val()) == "") { alert("事件时间不能为空"); return false; }
        thisdg.dg.style.display = "none";
        top.popAction(true);
        return true;
    }
</script>
</html>
