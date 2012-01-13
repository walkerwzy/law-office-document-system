<%@ page language="C#" autoeventwireup="true" inherits="cate_cust_add, App_Web_j3cfvcxm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/public.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
   <table style="width: 100%; margin-top:20px;" cellpadding="2" cellspacing="1" class="border">
        <tr>
            <td class="tdbg">
                
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		类别名称
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtcatename" runat="server" Width="200px" CssClass="tinput"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		排序标志
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtseq" runat="server" Width="200px" CssClass="tinput">0</asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		说明
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtremark" runat="server" Width="200px" CssClass="tinput"></asp:TextBox>
	</td></tr>
</table>

            </td>
        </tr>
        <tr style="display:none;">
            <td class="tdbg" align="center" valign="bottom">
                <asp:LinkButton ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />
                <asp:LinkButton ID="btnCancle" runat="server" Text="取消" OnClick="btnCancle_Click" />
            </td>
        </tr>
    </table>  
    </div>
    </form>
</body>
<script type="text/javascript" src="/js/jquery-1.6.2.min.js"></script>
<script type="text/javascript">
    var thisdg = frameElement.lhgDG;
    thisdg.addBtn('btnClose', '取消', function () { top.popAction(false); thisdg.cancel(); });
    thisdg.addBtn('btnClear', '清空', function () { __doPostBack('btnCancle', ''); });
    thisdg.addBtn('btnOk', '添加', function () { if (checkQuery()) __doPostBack('btnSave', ''); });
    function checkQuery() {
        if ($.trim($("#txtcatename").val()) == "") { alert("类别名称不能为空"); return false; }
        thisdg.dg.style.display = "none";
        top.popAction(true);
        return true;
    }
</script>
</html>
