<%@ Page Language="C#" AutoEventWireup="true" CodeFile="warn.aspx.cs" Inherits="warn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>文档类别管理</title>
    <link href="/css/public.css?v=0" rel="stylesheet" type="text/css" />
    <link href="/css/main.css?v=1" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="/js/lhgdialog.min.js"></script>
    <script type="text/javascript" src="/js/core.js?type=single&v=5"></script>
      
	<script type="text/javascript">
	    $(function () {
	    });
	    //弹窗_添加
	    function detail() {
	        var dlg = new $.dialog({ id: "dg02", title: '添加事件', page: "warn_add.aspx", resize: false, width: 500, height: 260, cover: true, rang: true, cancelBtn: false });
	        dlg.ShowDialog();
	    }        
        </script>
</head>
<body>
    <form id="form1" runat="server">
	<div id="container">
    <div class="div_top">
         <div class="nav">
          当前位置&nbsp;&nbsp;>&nbsp;&nbsp;重大事件
        </div>
        <!--简单过滤开始-->
        <div class="toolbar">
            <table class="tab1">
                <tr>
                <td valign="top">
                    <a href="javascript:void(0);" class="btn1" id="btnHighQuery" onclick="detail();">添加</a>
                </td>
                </tr>
            </table>
        </div>
        <!--简单过滤结束-->
        <div class="fixheader" id="fixheader"></div>
    </div>
    <div class="rightcontent" id="rightcontent">
    <asp:GridView ID="gridlist" runat="server" EmptyDataText="近期没有重大事件"
            AutoGenerateColumns="False" CssClass="table1" DataSourceID="ods" 
            EnableModelValidation="True">
        <Columns>
		<asp:BoundField DataField="displayname" HeaderStyle-Width="60px" ItemStyle-Width="60px" HeaderText="添加人" SortExpression="uid" ItemStyle-HorizontalAlign="Left"  /> 
		<asp:TemplateField HeaderText="事件内容" HeaderStyle-Width="450px" ItemStyle-Width="450px" ItemStyle-HorizontalAlign="Left" >
            <ItemTemplate>
                <span title='<%# Eval("cont") %>'><%# Helper.HelperString.cutString(Eval("cont").ToString(),35) %></span>
            </ItemTemplate>
        </asp:TemplateField>
		<asp:BoundField DataField="alerttime" HeaderText="事件时间" HeaderStyle-Width="80px" ItemStyle-Width="80px" SortExpression="alerttime" ItemStyle-HorizontalAlign="Left" DataFormatString="{0:d}" /> 
		<asp:BoundField DataField="isp" HeaderText="事件属性" HeaderStyle-Width="50px" ItemStyle-Width="50px" SortExpression="isprivate" ItemStyle-HorizontalAlign="Left"  /> 
        <asp:TemplateField HeaderText="&nbsp;"><ItemTemplate>&nbsp;</ItemTemplate></asp:TemplateField>
        </Columns>
    </asp:GridView>
    </div>
    <div class="divpager">
        <asp:Label runat="server" ID="lblpager"></asp:Label>
    </div>
    
        <asp:ObjectDataSource ID="ods" runat="server" SelectMethod="GetList" TypeName="WZY.DAL.alert">
            <SelectParameters>
                <asp:Parameter DefaultValue="1=2" Name="strWhere" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>