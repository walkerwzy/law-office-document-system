<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tasklist.aspx.cs" Inherits="tasklist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>业务交接记录</title>
    <link href="css/public.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #wndbody{ padding: 15px;}
        th{background:#f3f3f3; color:#1E5494; font-weight:400;}
        #gridlist td{ padding: 3px 2px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hidcustname"/>
    <div id="wndbody">
        <asp:GridView runat="server" ID="gridlist" DataKeyNames="recid" AutoGenerateColumns="False" Width="100%" GridLines="None" CellSpacing="-1">
            <Columns>
                <asp:BoundField HeaderText="提交人" DataField="usera" ItemStyle-Width="70px" />
                <asp:BoundField HeaderText="提交时间" DataField="rectime" DataFormatString="{0:d}" ItemStyle-Width="80px"/>
                <asp:BoundField HeaderText="接收人" DataField="userb" ItemStyle-Width="70px"/>
                <asp:BoundField HeaderText="截止期限" DataField="expiretime" DataFormatString="{0:d}" ItemStyle-Width="80px"/>
                <asp:TemplateField HeaderText="事项" ItemStyle-Width="180px">
                    <ItemTemplate>
                        <span title='<%# Eval("tasklist") %>'><%# Helper.HelperString.cutString(Eval("tasklist").ToString(),15) %></span>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="操作" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <a href="javascript:editTask(<%# string.Format("{0},{1},{2}",Eval("recid"),Eval("depta"),Eval("deptb")) %>);">详细</a>&nbsp;
                        <a href="javascript:;">删除</a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <webdiyer:aspnetpager id="AspNetPager1" runat="server" AlwaysShow="True" ShowCustomInfoSection="Right"
        width="100%" CustomInfoHTML="共<b> %RecordCount% </b>条记录 <b>%CurrentPageIndex%</b> / <b>%PageCount%</b>"
             ShowMoreButtons="true" ShowDisabledButtons="true" FirstPageText="首页" LastPageText="尾页" PrevPageText="上页" NextPageText="下页"
             Direction="LeftToRight" CustomInfoStyle="text-align:right;"></webdiyer:aspnetpager>
    </div>
        <asp:ObjectDataSource runat="server" ID="ods" DataObjectTypeName="WZY.Model.tasklog" TypeName="WZY.DAL.tasklog" SelectMethod="GetListByPage">
            <SelectParameters>
                <asp:Parameter Name="strWhere" Type="String" DefaultValue="1=1"/>
                <asp:Parameter Name="orderby" Type="String" DefaultValue="rectime desc"/>
                <asp:ControlParameter ControlID="AspNetPager1" PropertyName="CurrentPageIndex" DefaultValue="1" Name="pageindex" Type="Int32" />
                <asp:ControlParameter ControlID="AspNetPager1" PropertyName="PageSize" DefaultValue="10" Name="pagesize" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
    <script type="text/javascript" src="/js/jquery-1.8.2.min.js"></script>  
    <script type="text/javascript">
        var thisdg = frameElement.lhgDG;
        thisdg.addBtn('btnClose', '关闭', function () { top.popAction(false); thisdg.cancel(); });
        $(function () {

        });
        //添加业务接收记录
        function editTask(id,depta,deptb) {
            var name = $("#hidcustname").val();
            var dlg = new thisdg.curWin.$.dialog({
                id: 'dga07',
                title: '业务接收记录-' + name,
                page: 'taskadd.aspx?act=edit&id=' + id + '&depta=' + depta + '&deptb=' + deptb + '&t=' + new Date().getMilliseconds() + '&url=' + location.pathname,
                resize: true,
                width: 650,
                height: 450,
                cover: true,
                cancelBtn: false,
                rang: true
            });
            dlg.ShowDialog();
        }
    </script>
</body>
</html>
