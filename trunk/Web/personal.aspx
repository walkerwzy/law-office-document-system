<%@ Page Language="C#" AutoEventWireup="true" CodeFile="personal.aspx.cs" Inherits="personal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript" src="/js/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="/js/core.js?type=single&v=5"></script>
    <link href="/css/public.css?v=0" rel="stylesheet" type="text/css" />
    <style type="text/css">
        fieldset{margin:10px; padding:10px;}
        legend{color:#1E5494; font-weight:600;}
        p{height:30px; line-height:30px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
	<div id="container">
    <div class="div_top">
         <div class="nav">
          当前位置&nbsp;&nbsp;>&nbsp;&nbsp;个人设置
        </div>
        <!--简单过滤开始-->
        <div class="toolbar">
            <table class="tab1">
                <tr>
                    <td ></td>
                </tr>
            </table>
        </div> 
        
        <!--简单过滤结束-->
        <div class="fixheader" id="fixheader"></div>
    </div>
    <div class="rightcontent" id="rightcontent">
    <%--<table>
        <tr><th>每页显示记录条数：</th><td><asp:TextBox runat="server" ID="txtoldpwd" TextMode="Password" CssClass="tinput"></asp:TextBox></td></tr>
        <tr><th>默认查看全部门数据：</th><td><asp:CheckBox runat="server" ID="cbxDepart" /></td></tr>
        <tr><th>&nbsp;</th><td>
        </td></tr>
    </table>--%>
    <fieldset>
        <legend>个人信息</legend>
        <p>用户角色：<asp:Label runat="server" ID="lblrole"></asp:Label></p>
        <p>所属部门：<asp:Label runat="server" ID="lbldepart"></asp:Label></p>
        <p>&nbsp;&nbsp;用户名：<asp:TextBox runat="server" ID="txtusername" CssClass="tinput" MaxLength="20"></asp:TextBox></p>
        <p>真实姓名：<asp:TextBox runat="server" ID="txtdisplayname" CssClass="tinput" MaxLength="20"></asp:TextBox></p>
        <p><asp:Button ID="Button1" runat="server" OnClick="btnsave1click" Text="保存" CssClass="btn1" OnClientClick="return checkQuery();" /></p>
    </fieldset>
    <fieldset>
        <legend>偏好设置</legend>
        <p>每页记录条数：<asp:TextBox runat="server" ID="txtpagesize" CssClass="tinput" Width="35px"></asp:TextBox></p>
        <p><asp:CheckBox runat="server" ID="cbxdepart" Text="默认查看全部门数据" /></p>
        <p><asp:Button ID="btnsave" runat="server" OnClick="btnsaveclick" Text="保存" CssClass="btn1" OnClientClick="return checkQuery();" /></p>
    </fieldset>
    </div>
    </div>
    </form>
</body>
<script src="js/jquery-1.6.2.min.js" type="text/javascript"></script>
<script type="text/javascript">
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
