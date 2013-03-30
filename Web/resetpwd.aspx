<%@ Page Language="C#" AutoEventWireup="true" CodeFile="resetpwd.aspx.cs" Inherits="resetpwd" %>
<%@ Register TagPrefix="walker" TagName="header" Src="~/controls/header.ascx" %>
<%@ Register TagPrefix="walker" TagName="navi" Src="~/controls/navi.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <walker:header ID="myheader" runat="server" mytitle="修改密码" />
    <script type="text/javascript" src="/js/core.js?type=single&v=5"></script>
    <%--<link href="/css/public.css?v=0" rel="stylesheet" type="text/css" />--%>
    <%--<style type="text/css">
        #rightcontent{width:400px; margin:30px auto;}
        #rightcontent tr{ height:30px;}
        #rightcontent th{ color:#1e5494;}
    </style>--%>
</head>
<body>
    <form id="form1" runat="server">
    <walker:navi ID="mynavi" runat="server" menu="resetpwd" />
	<div id="container" class="container">
    <div class="div_top container">
         <div class="nav breadcrumb">
          当前位置&nbsp;&nbsp;>&nbsp;&nbsp;修改密码
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
    <div class="rightcontent" id="rightcontent">
    <table>
        <tr><th>原密码：</th><td><asp:TextBox runat="server" ID="txtoldpwd" TextMode="Password" CssClass="tinput"></asp:TextBox></td></tr>
        <tr><th>新密码：</th><td><asp:TextBox runat="server" ID="txtpwd1" TextMode="Password" CssClass="tinput"></asp:TextBox><span class="tgray">&nbsp;6-20位字母和数字</span></td></tr>
        <tr><th>密码确认：</th><td><asp:TextBox runat="server" ID="txtpwd2" TextMode="Password" CssClass="tinput"></asp:TextBox></td></tr>
        <tr><th>&nbsp;</th><td><asp:Button ID="btnsave" runat="server" OnClick="btnsaveclick" Text="确定" CssClass="btn1 btn btn-primary" OnClientClick="return checkQuery();" />&nbsp;
            <input type="reset" value="重置" class="btn1 btn btn-success" />
        </td></tr>
    </table>
    </div>
    </div>
    </form>
</body>
<script type="text/javascript">
    function checkQuery() {
        var p = /^[0-9a-zA-z]{6,20}$/i;
        if($.trim($("#txtoldpwd").val())==""){
            malert("请输入当前密码");
            return false;
        }
        if (!p.test($("#txtpwd1").val())) {
            malert("密码不符合要求");
            return false;
        }
        if ($("#txtpwd1").val() != $("#txtpwd2").val()) {
            malert("两次输入密码不一致");
            return false;
        }
        return true;
    }
</script>
</html>
