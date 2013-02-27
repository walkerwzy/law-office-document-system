<%@ Page Language="C#" AutoEventWireup="true" CodeFile="entry_add.aspx.cs" Inherits="entry_add" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/css/public.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="/js/editor/themes/default/default.css" />
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <div style="margin:0 20px;">
    <table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="70px" align="left">
		标题
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtetitle" runat="server" Width="500px" CssClass="tinput"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="70px" align="left" colspan="2">
		内容
	：</td>
    </tr>
    <tr>
	<td height="25" width="*" align="left" colspan="2">
		<asp:TextBox id="txtecont" runat="server" Width="500px" TextMode="MultiLine" style="visibility:hidden;"></asp:TextBox>
	</td></tr>
	<tr runat="server">
	<td height="25" width="70px" align="left">
		添加日期
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label ID="txtcreatedate" runat="server" Width="500px"></asp:Label>
	</td></tr>
	<tr runat="server">
	<td height="25" width="70px" align="left">
		修改日期
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label ID="txtmodifydate" runat="server" Width="500px"></asp:Label>
	</td></tr>
    <tr style="display:none;">
            <td class="tdbg" align="center" valign="bottom">
                <asp:LinkButton ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click"></asp:LinkButton>
                <%--<asp:LinkButton ID="btnCancle" runat="server" Text="取消" OnClick="btnCancle_Click"></asp:LinkButton>--%>
            </td>
    </tr>
</table>
    </div>
    </form>
</body>
<script type="text/javascript" src="/js/jquery-1.6.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="/js/editor/kindeditor-min.js"></script>
<script type="text/javascript">
    var thisdg = frameElement.lhgDG;
    thisdg.addBtn('btnClose', '取消', function () { top.popAction(false); thisdg.cancel(); });
    thisdg.addBtn('btnOk', '保存', function () { if (checkQuery()) __doPostBack('btnSave', ''); });
    $(function () {

    });
    var editor1;
    KindEditor.ready(function(K) {
            editor1 = K.create('#txtecont', {
            width: "100%",
            height:"320px",
		    resizeType : 1,
		    allowPreviewEmoticons : false,
		    allowImageUpload: false,
		    items : [
			    'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
			    'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyleft', 'insertorderedlist',
			    'insertunorderedlist', '|', 'emoticons', 'image', 'link']
		});
    });
    function checkQuery() {
        if ($.trim($("#txtetitle").val()) == "") { alert("制度标题不能为空"); return false; }
        editor1.sync();
        thisdg.dg.style.display = "none";
        top.popAction(true);
        return true;
    }
</script>
</html>
