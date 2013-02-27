<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zhidus.aspx.cs" Inherits="zhidus" %>

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
	    //弹窗_编辑
	    function detail(eid) {
	        var id = eid || '-1';
	        var dlgAdd = new $.dialog({ id: 'cdg01', title: '添加制度', page: 'entry_add.aspx?id='+id+'&t=' + new Date().getMilliseconds() + '&url=' + location.pathname,
	            resize: true, width: 750, height: 550, cover: true, cancelBtn: false, rang: true
	        });
	        dlgAdd.ShowDialog();
	    }        
        </script>
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
    <asp:GridView ID="gridlist" runat="server" DataKeyNames="eid"  AutoGenerateColumns="false" CssClass="table1" DataSourceID="ods"  onrowdeleted="gridlist_RowDeleted">
        <Columns>
        <asp:TemplateField HeaderText="标题"  ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="350px" ItemStyle-Width="350px" >
            <ItemTemplate>
                <a href='zhidu.aspx?id=<%# Eval("eid") %>'><%# Eval("etitle") %></a>
            </ItemTemplate>
        </asp:TemplateField>
		<%--<asp:BoundField DataField="econt" HeaderText="econt" SortExpression="econt" ItemStyle-HorizontalAlign="Center"  />--%> 
		<asp:BoundField DataField="createdate" HeaderText="创建时间" SortExpression="createdate" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="120px" ItemStyle-Width="120px"  /> 
		<asp:BoundField DataField="modifydate" HeaderText="修改时间" SortExpression="modifydate" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="120px" ItemStyle-Width="120px"  /> 
        <asp:TemplateField HeaderText="操作" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px" HeaderStyle-Width="80px">
            <ItemTemplate>
                <a href="javascript:void(0);" onclick='detail(<%# Eval("eid") %>);'>修改</a>
                <asp:LinkButton runat="server" ID="lbtndel" CommandName="Delete" OnClientClick="return confirm('确认删除？');">删除</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="&nbsp;"><ItemTemplate>&nbsp;</ItemTemplate></asp:TemplateField>
        </Columns>
    </asp:GridView>
    </div>
    <div class="divpager">
        <asp:Label runat="server" ID="lblpager"></asp:Label>
    </div>
    
        <asp:ObjectDataSource ID="ods" runat="server" 
            DataObjectTypeName="WZY.Model.entry" DeleteMethod="Delete"
            SelectMethod="GetList" TypeName="WZY.DAL.entry" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="cateid" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:Parameter DefaultValue=" etype='规章制度' " Name="strWhere" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>

