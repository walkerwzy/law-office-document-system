<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cust_add.aspx.cs" Inherits="cust_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/public.css" rel="stylesheet" type="text/css" />
    <style type="text/css">.tred{margin-left:8px;}</style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:670px; margin:0 auto;">
    <br />
    <asp:HiddenField runat="server" ID="hidcustid" Value="" />
     <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
        <tr>
            <td class="tdbg">
<table cellspacing="0" cellpadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="110px" align="right">
		客户类别
	：</td>
	<td height="25" width="*" align="left">
		<asp:DropDownList runat="server" ID="ddlcate"></asp:DropDownList>
	</td>
    <td height="25" width="110px" align="right">客户编号
    ：</td>
	<td height="25" width="*" align="left">
		<asp:Label runat="server" ID="lblcustno">自动生成</asp:Label>
	</td>
    </tr>
	<tr>
	<td height="25" width="110px" align="right">
		客户/单位名称
	：</td>
	<td height="25" width="*" align="left" colspan="3">
		<asp:TextBox CssClass="tinput" id="txtcustname" runat="server" Width="515px"></asp:TextBox><span class="tred">*</span>
	</td></tr>
	<tr>
	<td height="25" width="110px" align="right">
		单位/联系地址
	：</td>
	<td height="25" width="*" align="left" colspan="3">
		<asp:TextBox CssClass="tinput" id="txtaddress" runat="server" Width="515px"></asp:TextBox><span class="tred">*</span>
	</td></tr>
	<tr>
	<td height="25" width="110px" align="right">
		单位/联系电话
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox CssClass="tinput" id="txttel" runat="server" Width="180px"></asp:TextBox><span class="tred">*</span>
	</td>
	<td height="25" width="110px" align="right">
		传真
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox CssClass="tinput" id="txtfax" runat="server" Width="180px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="110px" align="right">
		邮编
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox CssClass="tinput" id="txtpost" runat="server" Width="180px"></asp:TextBox>
	</td>
	<td height="25" width="110px" align="right">
		email
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox CssClass="tinput" id="txtemail" runat="server" Width="180px"></asp:TextBox>
	</td></tr>
    <tr>
    <td height="25" width="110px" align="right">联系人：</td>
    <td hei="25" width="*" align="left"><asp:TextBox runat="server" ID="txtcontact" Width="180px" CssClass="tinput"></asp:TextBox></td>
    <td height="25" width="110px" align="right">联系人电话：</td>
    <td hei="25" width="*" align="left"><asp:TextBox runat="server" ID="txtcontel" Width="180px" CssClass="tinput"></asp:TextBox></td>
    </tr>
	<tr>
	<td height="25" width="110px" align="right">
		法定代表人
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox CssClass="tinput" id="txtowner" runat="server" Width="180px"></asp:TextBox>
	</td>
	<td height="25" width="110px" align="right">
		法定代表人生日
	：</td>
	<td height="25" width="*" align="left" title="如果勾选农历，请不要选择农历不存在的日期">
		<asp:TextBox CssClass="tinput Wdate" id="txtownerbirthday" runat="server" Width="140px" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});"></asp:TextBox>
        <asp:CheckBox runat="server" ID="cbxluanr1" Text="农历" />
	</td></tr>
	<tr>
	<td height="25" width="110px" align="right">
		法定代表人电话
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox CssClass="tinput" id="txtownertel" runat="server" Width="180px"></asp:TextBox>
	</td>
	<td height="25" width="110px" align="right">
		法定代表人QQ
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox CssClass="tinput" id="txtownerqq" runat="server" Width="180px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="110px" align="right">
		主要负责人
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox CssClass="tinput" id="txtcharge" runat="server" Width="180px"></asp:TextBox>
	</td>
	<td height="25" width="110px" align="right">
		负责人生日
	：</td>
	<td height="25" width="*" align="left" title="如果勾选农历，请不要选择农历不存在的日期">
		<asp:TextBox CssClass="tinput Wdate" id="txtchargebirth" runat="server" Width="140px" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});"></asp:TextBox>
        <asp:CheckBox runat="server" ID="cbxlunar2" Text="农历" />
	</td></tr>
	<tr>
	<td height="25" width="110px" align="right">
		负责人电话
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox CssClass="tinput" id="txtchargetel" runat="server" Width="180px"></asp:TextBox>
	</td>
	<td height="25" width="110px" align="right">
		负责人QQ
	：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox CssClass="tinput" id="txtchargeqq" runat="server" Width="180px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="110px" align="right" valign="top">
		客户/单位简介
	：</td>
	<td height="25" width="*" align="left" colspan="3">
		<asp:TextBox CssClass="tinput" id="txtsummary" runat="server" Width="515px" TextMode="MultiLine" Height="50" style="margin-bottom:3px;"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" width="110px" align="right" valign="top">
		备注
	：</td>
	<td height="25" width="*" align="left" colspan="3">
		<asp:TextBox CssClass="tinput" id="txtremark" runat="server" Width="515px" TextMode="MultiLine" Height="70"></asp:TextBox>
	</td></tr>
</table>

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
<script src="/js/ca/WdatePicker.js" type="text/javascript"></script>
<script type="text/javascript" src="/js/jquery-1.8.2.min.js"></script>
<script type="text/javascript">
    var thisdg = frameElement.lhgDG;
    thisdg.addBtn('btnClose', '取消', function () { top.popAction(false); thisdg.cancel(); });
    var oktxt = "保存";
    if ($("#hidcustid").val() == "") { thisdg.addBtn('btnClear', '清空', function () { __doPostBack('btnCancle', ''); }); oktxt = "添加"; }
    thisdg.addBtn('btnOk', oktxt, function () { if (checkQuery()) __doPostBack('btnSave', ''); });
    function checkQuery(){
        if ($.trim($("#txtcustname").val()) == "") { alert("客户姓名/单位名称不能为空"); return false; }
        if ($.trim($("#txtaddress").val()) == "") { alert("单位地址不能为空"); return false; }
        if ($.trim($("#txttel").val()) == "") { alert("单位联系电话不能为空"); return false; }
        var email = $.trim($("#txtemail").val());
        var email_pattern = /^\w+[.+-]?\w+@\w+(\.\w+)+$/i;
        if($.trim(email)!="") if ( !email_pattern.test(email)) { alert("电子邮箱格式不正确"); return false; }
//        if ($.trim($("#txtowner").val()) == "") { alert("法定代表人不能为空"); return false; }
//        if ($.trim($("#txtownertel").val()) == "") { alert("法定代表人电话不能为空"); return false; }
//        if ($.trim($("#txtcharge").val()) == "") { alert("主要负责人不能为空"); return false; }
//        if ($.trim($("#txtchargetel").val()) == "") { alert("主要负责人电话不能为空"); return false; }
        thisdg.dg.style.display = "none";
        top.popAction(true);
        return true;
    }
</script>
</html>
