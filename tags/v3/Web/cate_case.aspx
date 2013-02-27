<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cate_case.aspx.cs" Inherits="cate_case" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>案件类别管理</title>
    <link href="/css/public.css?v=0" rel="stylesheet" type="text/css" />
    <link href="/css/main.css?v=1" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="/js/lhgdialog.min.js"></script>
    <script type="text/javascript" src="/js/core.js?type=single&v=5"></script>
      
	<script type="text/javascript">
	    $(function () {
	    });
	    //弹窗_编辑
	    function detail() {
	        var dlg = new $.dialog({ id: "dg02", title: '添加案件类别', page: "cate_case_add.aspx", resize: false, width: 500, height: 250, cover: true, rang: true, cancelBtn: false });
	        dlg.ShowDialog();
	    }        
        </script>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="LinkButton1">
	<div id="container">
    <div class="div_top">
         <div class="nav">
          当前位置&nbsp;&nbsp;>&nbsp;&nbsp;案件类别管理
        </div>
        <!--简单过滤开始-->
        <div class="toolbar">
            <table class="tab1">
                <tr>
                    <td valign="middle">类别名：</td>
                    <td valign="top">
                        <asp:TextBox runat="server" ID="txtcatename" CssClass="tinput shortTxt"></asp:TextBox>
                    </td>
                <td valign="top">
                    <asp:Button runat="server" ID="LinkButton1" Text="查询" OnClick="btnsearch" CssClass="btn1" />
                </td>
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
    <asp:ValidationSummary runat="server" ID="valisum" ShowMessageBox="true" ShowSummary="false" EnableClientScript="true" HeaderText="错误：" />
    <asp:GridView ID="gridlist" runat="server" DataKeyNames="cateid" 
            AutoGenerateColumns="false" CssClass="table1" DataSourceID="ods" 
            onrowdeleted="gridlist_RowDeleted" OnRowUpdated="gridlist_RowUpdated">
        <Columns>
        <%--<asp:TemplateField HeaderStyle-Width="20px" ItemStyle-Width="20px">
            <HeaderTemplate><input type="checkbox" id="cbxall" value='<%# Eval("deptid") %>' /></HeaderTemplate>
            <ItemTemplate>
                <input type="checkbox" class="GVcbx"/>
            </ItemTemplate>
        </asp:TemplateField>--%>
        <asp:TemplateField HeaderText="案件类别" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="140px" HeaderStyle-Width="140px">
            <ItemTemplate><%# Eval("catename") %></ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtcatename1" runat="server" Text='<%# Bind("catename") %>' CssClass="tinput" Width="130px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqvalids" runat="server" ControlToValidate="txtcatename1" ErrorMessage="类别名称不能为空！" Display="None"></asp:RequiredFieldValidator>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="排序标志" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="60px" HeaderStyle-Width="60px">
            <ItemTemplate><%# Eval("seq") %></ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtseq" runat="server" Text='<%# Bind("seq") %>' CssClass="tinput" Width="50px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqvalid9" runat="server" ControlToValidate="txtseq" ErrorMessage="排序标志不能为空！" Display="None"></asp:RequiredFieldValidator>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="类别前缀" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="60px" HeaderStyle-Width="60px">
            <ItemTemplate><%# Eval("prefix") %></ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtfix" runat="server" Text='<%# Bind("prefix") %>' CssClass="tinput" Width="50px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqvalid12" runat="server" ControlToValidate="txtfix" ErrorMessage="类别前缀不能为空！" Display="None"></asp:RequiredFieldValidator>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="说明" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="200px" HeaderStyle-Width="200px">
            <ItemTemplate><%# Eval("remark") %></ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtremark" runat="server" Text='<%# Bind("remark") %>' CssClass="tinput" Width="190px"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="操作" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px" HeaderStyle-Width="80px">
            <ItemTemplate>
                <asp:LinkButton runat="server" ID="lbtnedit" CommandName="Edit">编辑</asp:LinkButton>
                <asp:LinkButton runat="server" ID="lbtndel" CommandName="Delete" OnClientClick="return confirm('确认删除？');">删除</asp:LinkButton>
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
            DataObjectTypeName="WZY.Model.CATE_CASE" DeleteMethod="Delete" InsertMethod="Add" 
            SelectMethod="GetList" TypeName="WZY.DAL.CATE_CASE" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="cateid" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:Parameter DefaultValue="1=1 order by seq" Name="strWhere" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>

