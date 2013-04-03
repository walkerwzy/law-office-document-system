<%@ Page Language="C#" AutoEventWireup="true" CodeFile="serverinfo.aspx.cs" Inherits="hospital_serverinfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
        *{margin:0; padding:0;}
        body{font-size:12px;background:#fff!important;}
        #main{ margin:20px 30px;}
        dt{font-weight:600; font-size:1.5; border-bottom:3px solid rgb(137,181,233); padding-bottom:3px; color:Navy;}
        dd{padding:5px;}
        .odd{ background:#eee;}
	   .themegray{border-bottom-color:#afafaf!important;}
    </style>
    <script type="text/javascript" src="/js/jquery-1.8.2.min.js"></script>
	<script type="text/javascript">
	$(function(){setTheme();	});
	 function getCookie(name) {
		 var arr = document.cookie.match(new RegExp("(^|;\\s*)" + name + "=([^;]*)(;|$)"));
		 if (arr != null) return unescape(decodeURI(arr[2])); return "";
	 }
	 function setTheme(){
		if(getCookie("theme")=="gray") $("dt").addClass("themegray");
		else $("dt").removeClass("themegray");
	 }
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
<dl>
    <dt>&#187;服务器信息</dt>
<dd>本机IP:<%=Request.ServerVariables["remote_addr"]%></dd>
<dd class="odd">服务器地址:<%=Request.ServerVariables["SERVER_NAME"]%></dd>
<dd>服务器IP:<%=Request.ServerVariables["LOCAL_ADDR"]%></dd>
<dd class="odd">服务器端口:<%=Request.ServerVariables["SERVER_PORT"]%></dd>
<dd>服务器时间:<%=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")%></dd>
<dd class="odd">IIS版本:<%=Request.ServerVariables["SERVER_SOFTWARE"]%></dd>
<dd>脚本超时时间:<%=Server.ScriptTimeout%></dd>
<dd class="odd">本文件路径:<%=Server.MapPath(Request.ServerVariables["SCRIPT_NAME"])%></dd>
<dd>服务器CPU数量:<%=Request.ServerVariables["NUMBER_OF_PROCESSORS"]%></dd>
<dd class="odd">服务器操作系统:<%=Request.ServerVariables["OS"]%></dd>
<dd>支持的文件类型：<%=Request.ServerVariables["HTTP_Accept"]%></dd>
<dd class="odd">访问的文件路径：<%=Request.ServerVariables["HTTP_url"]%></dd>
<dd>浏览器信息：<%=Request.ServerVariables["HTTP_USER_AGENT"]%></dd>
</dl>
<dl>
    <dt>&#187;关于程序</dt>
<dd>程序版本：V0.8</dd>
<dd class="odd">程序开发：walker</dd>
<dd>官方网站：<a href="http://walkerwang.cnblogs.com" target="_blank">http://walkerwang.cnblogs.com</a></dd>
<dd class="odd">电子信箱：<a href="mailto:walkerwzy@gmail.com">walkerwzy@gmail.com</a></dd>
</dl>
    </div>
    </form>
</body>
</html>
