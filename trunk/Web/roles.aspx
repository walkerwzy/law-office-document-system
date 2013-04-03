<%@ Page Language="C#" AutoEventWireup="true" CodeFile="roles.aspx.cs" Inherits="roles" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>角色管理</title>
    <link href="/css/public.css?v=0" rel="stylesheet" type="text/css" />
    <link href="/css/main.css?v=1" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/js/core.js?type=single&v=5"></script>
</head>
<body>
<script type="text/javascript">
    //~ var LODOP=$("#LODOP")[0];//必须用这个变量名，否则CheckLodop()方法不作用，也必须放在这个位置
    //~ CheckLodop();
</script>
    <form id="form1" runat="server">
	<div id="container">
    <div class="div_top">
         <div class="nav">
          当前位置&nbsp;&nbsp;>&nbsp;&nbsp;角色管理
        </div>
        <!--简单过滤开始-->
        <div class="toolbar">
            &nbsp;
        </div> 
        <!--简单过滤结束-->
        <div class="fixheader" id="fixheader"></div>
    </div>
    <div class="rightcontent" id="rightcontent">
    <asp:ValidationSummary runat="server" ID="valisum" ShowMessageBox="true" ShowSummary="false" EnableClientScript="true" HeaderText="错误：" />
    <asp:GridView ID="gridlist" runat="server" CssClass="table1" DataKeyNames="roleid" AutoGenerateColumns="false" DataSourceID="ods">
        <Columns>
        <asp:BoundField DataField="rolename" ReadOnly="true" HeaderText="角色名" HeaderStyle-Width="100px" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Left" />
        <asp:TemplateField HeaderText="显示名称" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="140px" HeaderStyle-Width="140px">
            <ItemTemplate><%# Eval("displayname") %></ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtdisplayname" runat="server" Text='<%# Bind("displayname") %>' CssClass="tinput" Width="130px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqvalid9" runat="server" ControlToValidate="txtdisplayname" ErrorMessage="角色显示名称不能为空！" Display="None"></asp:RequiredFieldValidator>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="备注" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="220px" HeaderStyle-Width="220px">
            <ItemTemplate><%# Eval("remark") %></ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtremark" runat="server" Text='<%# Bind("remark") %>' CssClass="tinput" Width="210px"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="操作" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px" HeaderStyle-Width="80px">
            <ItemTemplate>
                <asp:LinkButton runat="server" ID="lbtnedit" CommandName="Edit" Enabled="<%# suser.roleid==0 %>">编辑</asp:LinkButton>
                <asp:LinkButton runat="server" ID="lbtndel" CommandName="Delete" Enabled="false" OnClientClick="alert('基础数据不允许删？');return false;" ForeColor="Gray">删除</asp:LinkButton>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:LinkButton runat="server" ID="lbtnupdate" CommandName="Update">保存</asp:LinkButton>
                <asp:LinkButton runat="server" ID="lbtncancel" CommandName="Cancel" CausesValidation="false">取消</asp:LinkButton>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="&nbsp;"><ItemTemplate>&nbsp;</ItemTemplate></asp:TemplateField>
            </Columns>
    </asp:GridView>
    </div>
    <div class="divpager">
        <asp:Label runat="server" ID="lblpager"></asp:Label>
    </div>
        <asp:ObjectDataSource ID="ods" runat="server" 
            DataObjectTypeName="WZY.Model.SYSROLE" DeleteMethod="Delete" InsertMethod="Add" 
            SelectMethod="GetList" TypeName="WZY.DAL.SYSROLE" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="roleid" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:Parameter DefaultValue="1=1" Name="strWhere" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
