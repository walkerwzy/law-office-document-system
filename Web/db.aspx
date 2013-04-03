<%@ Page Language="C#" AutoEventWireup="true" CodeFile="db.aspx.cs" Inherits="db" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript" src="/js/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/js/core.js?type=single&v=5"></script>
    <link href="/css/public.css?v=0" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .tab1{color:red;}
        p{height:30px; line-height:30px;}
        fieldset{margin:10px; padding:10px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
	<div id="container">
    <div class="div_top">
         <div class="nav">
          当前位置&nbsp;&nbsp;>&nbsp;&nbsp;备份数据库
        </div>
        <!--简单过滤开始-->
        <div class="toolbar">
            <table class="tab1">
                <tr>
                    <td>请谨慎操作</td>
                </tr>
            </table>
        </div> 
        
        <!--简单过滤结束-->
        <div class="fixheader" id="fixheader"></div>
    </div>
    <div class="rightcontent" id="rightcontent">
        <fieldset>
            <legend>备份</legend>
            <p>数据库备份文件夹路径: <asp:Label runat="server" ID="txtdb"></asp:Label></p>
            <p>
                <asp:LinkButton runat="server" ID="lbtnlog" OnClick="godb" CssClass="btn1">查看文件夹</asp:LinkButton>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="beckupclick" CssClass="btn1">备份数据库</asp:LinkButton>
            </p>
        </fieldset>
        <fieldset>
            <legend>恢复</legend>
            <p><asp:FileUpload runat="server" ID="fu" /></p>
            <p><asp:LinkButton runat="server" OnClick="recoveryclick" CssClass="btn1">恢复数据库</asp:LinkButton></p>
        </fieldset>
    </div>
    </div>
    </form>
</body>
</html>