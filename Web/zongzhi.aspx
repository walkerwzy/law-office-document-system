<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zongzhi.aspx.cs" Inherits="zongzhi" %>
<%@ Register TagPrefix="walker" TagName="header" Src="~/controls/header.ascx" %>
<%@ Register TagPrefix="walker" TagName="navi" Src="~/controls/navi.ascx" %>
<%@ Register TagPrefix="walker" TagName="shared" Src="~/controls/shared.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--<link href="/css/public.css?v=0" rel="stylesheet" type="text/css" />
    <link href="/css/main.css?v=1" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #fixheader{height:3px; font-size:0;}
        #article{white-space: normal; padding:20px;}
    </style>--%>
    <walker:header ID="myheader" runat="server" mytitle="公告" />
</head>
<body>
    <form id="form1" runat="server">
    <walker:navi ID="mynavi" runat="server" menu="notice" />
<div id="container" class="container">
    <div class="div_top container">
         <div class="nav breadcrumb">
          当前位置&nbsp;&nbsp;>&nbsp;&nbsp;公告栏
             <asp:Button runat="server" ID="btnedit" CssClass="btn1 btn btn-primary pull-right" Text="编辑" OnClientClick="event.returnValue=false;return false;" />
        </div>
        <!--简单过滤开始-->
        <%--<div class="toolbar form-inline">
            <table class="tab1">
                <tr>
                    <td valign="middle">
                        <asp:Button runat="server" ID="btnedit" CssClass="btn1" Text="编辑" OnClientClick="event.returnValue=false;return false;" />
                     </td>
                </tr>
            </table>
        </div>--%>         
        <!--简单过滤结束-->
        <%--<div class="fixheader" id="fixheader"></div>--%>
    </div>
    <div class="rightcontent" id="rightcontent">
        <div id="article">
    <asp:Literal runat="server" ID="lblcont"></asp:Literal>
    </div>
    </div>
    <div class="divpager"></div>
    </div>
    </form>
    <!--ajax弹出层开始-->
    <div id="float_bg" class="floatdiv"></div>
    <div id="float_cont" class="floatdiv"><div><img src="images/loading46.gif" /><a href="javascript:popAction();" id="ajaxclose">关闭</a></div></div>
    <!--ajax弹层结束-->
</body>
    <script type="text/javascript" src="/js/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="/js/lhgdialog.min.js"></script>
    <script type="text/javascript" src="/js/core.js?type=single&v=5"></script>
    <script type="text/javascript">
        $(function () { 
	        var dlgAdd = $("#btnedit").dialog({ id: 'cdg01', title: '编辑', page: 'officeedit.aspx?type=zongzhi&t=' + new Date().getMilliseconds() + '&url=' + location.pathname,
	            resize: true, width: 750, height: 450, cover: true, cancelBtn: false, rang: true
	        });
        });
    </script>
</html>
