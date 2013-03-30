<%@ Page Language="C#" AutoEventWireup="true" CodeFile="personal.aspx.cs" Inherits="personal" %>
<%@ Register TagPrefix="walker" TagName="header" Src="~/controls/header.ascx" %>
<%@ Register TagPrefix="walker" TagName="navi" Src="~/controls/navi.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <%--<script type="text/javascript" src="/js/jquery-1.6.2.min.js"></script>--%>
    <%--<link href="/css/public.css?v=0" rel="stylesheet" type="text/css" />--%>
    <walker:header ID="myheader" runat="server" mytitle="个人设置" />
    <script type="text/javascript" src="/js/core.js?type=single&v=5"></script>
    <%--<style type="text/css">
        fieldset{margin:10px; padding:10px;}
        legend{color:#1E5494; font-weight:600;}
        p{height:30px; line-height:30px;}
    </style>--%>
</head>
<body>
    <form id="form1" runat="server">
    <walker:navi ID="mynavi" runat="server" menu="personal" />
	<div id="container" class="container">
    <div class="div_top container">
         <div class="nav breadcrumb">
          当前位置&nbsp;&nbsp;>&nbsp;&nbsp;个人设置
        </div>
        <!--简单过滤开始-->
        <%--<div class="toolbar">
            <table class="tab1">
                <tr>
                    <td ></td>
                </tr>
            </table>
        </div>--%> 
        
        <!--简单过滤结束-->
        <%--<div class="fixheader" id="fixheader"></div>--%>
    </div>
    <div class="rightcontent row" id="rightcontent">
    <%--<table>
        <tr><th>每页显示记录条数：</th><td><asp:TextBox runat="server" ID="txtoldpwd" TextMode="Password" CssClass="tinput"></asp:TextBox></td></tr>
        <tr><th>默认查看全部门数据：</th><td><asp:CheckBox runat="server" ID="cbxDepart" /></td></tr>
        <tr><th>&nbsp;</th><td>
        </td></tr>
    </table>--%>
    <fieldset class="form-inline span6">
        <legend>个人信息</legend>
        <p>用户角色：<asp:Label runat="server" ID="lblrole"></asp:Label></p>
        <p>所属部门：<asp:Label runat="server" ID="lbldepart"></asp:Label></p>
        <p>&nbsp;&nbsp;用户名：<asp:TextBox runat="server" ID="txtusername" CssClass="tinput" MaxLength="20"></asp:TextBox></p>
        <p>真实姓名：<asp:TextBox runat="server" ID="txtdisplayname" CssClass="tinput" MaxLength="20"></asp:TextBox></p>
        <p><asp:Button ID="Button1" runat="server" OnClick="btnsave1click" Text="保存" CssClass="btn1 btn btn-primary" OnClientClick="return checkQuery();" /></p>
    </fieldset>
    <fieldset class="form-inline span6">
        <legend>偏好设置</legend>
        <p>每页记录条数：<asp:TextBox runat="server" ID="txtpagesize" CssClass="tinput" Width="35px"></asp:TextBox></p>
        <p><label>主题皮肤：
            <asp:DropDownList runat="server" ID="ddltheme" CssClass="input-small">
                <asp:ListItem>default</asp:ListItem>
                <asp:ListItem>amelia</asp:ListItem>
                <asp:ListItem>cerulean</asp:ListItem>
                <asp:ListItem>cosmo</asp:ListItem>
                <asp:ListItem>cyborg</asp:ListItem>
                <asp:ListItem>journal</asp:ListItem>
                <asp:ListItem>readable</asp:ListItem>
                <asp:ListItem>simplex</asp:ListItem>
                <asp:ListItem>slate</asp:ListItem>
                <asp:ListItem>spacelab</asp:ListItem>
                <asp:ListItem>spruce</asp:ListItem>
                <asp:ListItem>superhero</asp:ListItem>
                <asp:ListItem>united</asp:ListItem>
            </asp:DropDownList>
        </label></p>
        <p><asp:CheckBox runat="server" ID="cbxdepart" Text="&nbsp;默认查看全部门数据" /></p>
        <p><asp:Button ID="btnsave" runat="server" OnClick="btnsaveclick" Text="保存" CssClass="btn1 btn btn-primary" OnClientClick="return checkQuery();" /></p>
    </fieldset>
    </div>
    </div>
    </form>
</body>
<script type="text/javascript">
    $(function () {
        $("#ddltheme").change(function() {
            setTheme($(this).val());
        })
        .val(getCookie('theme')||'default');
    });
    function checkQuery() {
        var p=$.trim($("#txtpagesize").val());
        if (!/^[0-9]{1,2}$/.test(p)) {
            alert("每页记录条数请输入100以内的数字");
            return false;
        }
        return true;
    }
</script>
</html>
