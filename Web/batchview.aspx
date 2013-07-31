<%@ Page Language="C#" AutoEventWireup="true" CodeFile="batchview.aspx.cs" Inherits="batchview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="css/public.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .hide{ display: none;}
        th{background:#f3f3f3; color:#1E5494; font-weight:400;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hidid"/>
        <div style="padding:10px;">
            <asp:GridView ID="gridlist" runat="server" CssClass="" DataKeyNames="docid" AutoGenerateColumns="false" OnRowDataBound="gvdatabind" GridLines="None" CellSpacing="-1" EnableViewState="True">
                <Columns>
                    <asp:TemplateField HeaderStyle-Width="20px" ItemStyle-Width="20px" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide">
                        <HeaderTemplate>
                            <input type="checkbox" id="cbxall" /></HeaderTemplate>
                        <ItemTemplate>
                            <input type="checkbox" class="GVcbx" value='<%# Eval("docid") %>' />
                            <asp:HiddenField runat="server" ID="hidcandel" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="上传人" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="80px" HeaderStyle-Width="80px" DataField="displayname" />
                    <asp:TemplateField HeaderText="文件名" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="nodetail" HeaderStyle-Width="250px" ItemStyle-Width="250px">
                        <ItemTemplate>
                            <span title='<%# Eval("docname") %>'><%# Helper.HelperString.cutString(Eval("docname").ToString(), 14)%></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="上传时间" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="120px" HeaderStyle-Width="80px" DataField="uptime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
                    <asp:BoundField HeaderText="文件操作" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px" HeaderStyle-Width="80px" />
                </Columns>
            </asp:GridView>
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" ShowCustomInfoSection="Right"
                ShowMoreButtons="true" ShowDisabledButtons="true" FirstPageText="首页" LastPageText="尾页" PrevPageText="上页" NextPageText="下页"
                Direction="LeftToRight" CustomInfoStyle="text-align:right;">
            </webdiyer:AspNetPager>
        </div>
        
        
        <asp:ObjectDataSource ID="ods" runat="server" 
            DataObjectTypeName="WZY.Model.DOCS" DeleteMethod="Delete"
            SelectMethod="GetPage" TypeName="WZY.DAL.DOCS" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="docid" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:Parameter DefaultValue="1=1 order by uptime desc" Name="strWhere" Type="String" />
                <asp:ControlParameter ControlID="AspNetPager1" PropertyName="CurrentPageIndex" DefaultValue="1" Name="pageindex" Type="Int32" />
                <asp:ControlParameter ControlID="AspNetPager1" PropertyName="PageSize" DefaultValue="10" Name="pagesize" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
    <script type="text/javascript" src="/js/jquery-1.8.2.min.js"></script>  
    <script type="text/javascript">
        var thisdg = frameElement.lhgDG;
        thisdg.addBtn('btnClose', '关闭', function () { top.popAction(false); thisdg.cancel(); });
        $(function() {
            
        });
    </script>
</body>
</html>
