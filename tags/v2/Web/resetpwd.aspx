<%@ Page Language="C#" AutoEventWireup="true" CodeFile="resetpwd.aspx.cs" Inherits="resetpwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="/js/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="/js/core.js?type=single&v=5"></script>
    <link href="/css/public.css?v=0" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #rightcontent{width:400px; margin:30px auto;}
        #rightcontent tr{ height:30px;}
        #rightcontent th{ color:#1e5494;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
	<div id="container">
    <div class="div_top">
         <div class="nav">
          当前位置&nbsp;&nbsp;>&nbsp;&nbsp;修改密码
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
    <table>
        <tr><th>原密码：</th><td><asp:TextBox runat="server" ID="txtoldpwd" TextMode="Password" CssClass="tinput"></asp:TextBox></td></tr>
        <tr><th>新密码：</th><td><asp:TextBox runat="server" ID="txtpwd1" TextMode="Password" CssClass="tinput"></asp:TextBox><span class="tgray">&nbsp;6-20位字母和数字</span></td></tr>
        <tr><th>密码确认：</th><td><asp:TextBox runat="server" ID="txtpwd2" TextMode="Password" CssClass="tinput"></asp:TextBox></td></tr>
        <tr><th>&nbsp;</th><td><asp:Button ID="btnsave" runat="server" OnClick="btnsaveclick" Text="确定" CssClass="btn1" OnClientClick="return checkQuery();" />
            <input type="reset" value="重置" class="btn1" />
        </td></tr>
    </table>
    </div>
    </div>
    </form>
</body>
<script src="js/jquery-1.6.2.min.js" type="text/javascript"></script>
<script type="text/javascript">
    function checkQuery() {
        var p = /^[0-9a-zA-z]{6,20}$/i;
        if($.trim($("#txtoldpwd").val())==""){
            alert("请输入当前密码");
            return false;
        }
        if (!p.test($("#txtpwd1").val())) {
            alert("密码不符合要求");
            return false;
        }
        if ($("#txtpwd1").val() != $("#txtpwd2").val()) {
            alert("两次输入不一致");
            return false;
        }
        return true;
    }
</script>
</html>
