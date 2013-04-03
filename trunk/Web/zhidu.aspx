<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zhidu.aspx.cs" Inherits="zhidu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/css/public.css?v=0" rel="stylesheet" type="text/css" />
    <link href="/css/main.css?v=1" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #fixheader{height:3px; font-size:0;}
        #article{white-space: normal; padding:20px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
<div id="container">
    <div class="div_top">
         <div class="nav">
          当前位置&nbsp;&nbsp;>&nbsp;&nbsp;行政办公&nbsp;&nbsp;>&nbsp;&nbsp;规章制度
        </div>
        <!--简单过滤开始-->
        <div class="toolbar">
            <table class="tab1">
                <tr>
                    <td valign="middle">
                        <a href="javascript:void(0);" onclick="history.go(-1);" class="btn1">返回</a>
                     </td>
                </tr>
            </table>
        </div>         
        <!--简单过滤结束-->
        <div class="fixheader" id="fixheader"></div>
    </div>
    <div class="rightcontent" id="rightcontent">
        <div id="article">
        <center><h2><asp:Literal runat="server" ID="lbltitle"></asp:Literal></h2></center>
            <asp:Literal runat="server" ID="lblcont"></asp:Literal>
        </div>
    </div>
    <div class="divpager"></div>
    </div>
    </form>
</body>
    <script type="text/javascript" src="/js/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/js/lhgdialog.min.js"></script>
    <script type="text/javascript" src="/js/core.js?type=single&v=5"></script>
</html>
