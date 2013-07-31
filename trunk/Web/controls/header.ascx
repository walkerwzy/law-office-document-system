<%@ Control Language="C#" AutoEventWireup="true" CodeFile="header.ascx.cs" Inherits="controls_header" %>
    <title><%=mytitle %>|湖南炜弘律师事务所文档管理系统</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"/>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <%--<link href="//netdna.bootstrapcdn.com/twitter-bootstrap/2.3.0/css/bootstrap-combined.min.css" rel="stylesheet">--%>
    <%--<link href="//netdna.bootstrapcdn.com/bootswatch/2.3.0/united/bootstrap.min.css" rel="stylesheet">--%>
    <%--<link href="//netdna.bootstrapcdn.com/twitter-bootstrap/2.3.0/css/bootstrap-responsive.min.css" rel="stylesheet">--%>
    <link rel="stylesheet" href="/css/bootstrap/default/bootstrap.min.css" id="btstyle"/>
    <link rel="stylesheet" href="/css/bootstrap/bootstrap-responsive.min.css"/>
    <script type="text/javascript" src="/js/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/js/lhgdialog.min.js"></script>
    <script type="text/javascript" src="/js/bootstrap/bootstrap.min.js"></script>
    <%--<script src="//netdna.bootstrapcdn.com/twitter-bootstrap/2.3.0/js/bootstrap.min.js"></script>--%>
<style type="text/css">
    :focus {outline:none;}
    /*input.btn{height:30px;}
    .div_top{ margin-top:55px;}*/
    body{position:relative;}
    /*popover*/
    #divdetail{ position:absolute;}
    #divdetail .popover{ min-width:250px; _width:300px; }
    /*float div style*/
    .floatdiv{ position:fixed; _position:absolute; display:none; background:white;}
    #float_bg{ width:100%; height:100%; opacity:0.7; filter:alpha(opacity=70); top:0; left:0;}
    #float_cont{border:5px solid #ccc; height:100px; width:600px; text-align:center; left:50%; top:40%; margin-left:-300px; border-radius:7px; -moz-border-radius:7px; z-index:9999;}
    /*fix for dropdown in nav-bar*/
    /*ul.nav li.dropdown:hover ul.dropdown-menu{display: block;}
    a.menu:after, .dropdown-toggle:after {content: none;}*/
    .hide{ display: none;}
</style>