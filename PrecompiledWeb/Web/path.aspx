<%@ page language="C#" autoeventwireup="true" inherits="path, App_Web_j3cfvcxm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript" src="/js/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="/js/core.js?type=single&v=5"></script>
    <link href="/css/public.css?v=0" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .tab1{color:red;}
        #rightcontent{width:400px; margin-left:30px; margin-top:20px;}
        p{height:30px; line-height:30px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
	<div id="container">
    <div class="div_top">
         <div class="nav">
          当前位置&nbsp;&nbsp;>&nbsp;&nbsp;路径设置
        </div>
        <!--简单过滤开始-->
        <div class="toolbar">
            <table class="tab1">
                <tr>
                    <td>为保证上传文件安全，此路径只供查看本系统文件物理路径使用，不提供修改</td>
                </tr>
            </table>
        </div> 
        
        <!--简单过滤结束-->
        <div class="fixheader" id="fixheader"></div>
    </div>
    <div class="rightcontent" id="rightcontent">
    <p>日志文件夹路径: <asp:Label runat="server" ID="txtlog"></asp:Label>
    <asp:LinkButton runat="server" ID="lbtnlog" OnClick="golog" CssClass="btn1">查看</asp:LinkButton></p>
    <p>上传文件夹路径: <asp:Label runat="server" ID="txtupload"></asp:Label>
    <asp:LinkButton runat="server" ID="LinkButton1" OnClick="goupload" CssClass="btn1">查看</asp:LinkButton></p>
    <p>备份文件夹路径: <asp:Label runat="server" ID="txtbeckup"></asp:Label>
    <asp:LinkButton runat="server" ID="LinkButton2" OnClick="gobeckup" CssClass="btn1">查看</asp:LinkButton></p>
    </div>
    </div>
    </form>
</body>
</html>
