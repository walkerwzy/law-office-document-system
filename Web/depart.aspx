﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="depart.aspx.cs" Inherits="depart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <%--<title>部门管理</title>
    <link href="/css/public.css?v=0" rel="stylesheet" type="text/css" />
    <link href="/css/main.css?v=1" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/js/lhgdialog.min.js"></script>--%>
    <walker:header runat="server" ID="myheader" mytitle="部门管理" />
    <script type="text/javascript" src="/js/core.js?type=single&v=5"></script>
      
	<script type="text/javascript">
	    $(function () {
	    });
	    //弹窗_编辑
	    function detail(o) {
	        if ($("#btnAdd[disabled]").length > 0) return false;
	        var dlg = new $.dialog({ id: "dg02", title: '添加部门', page: "depart_add.aspx", resize: false, width: 500, height: 200, cover: true, rang: true, cancelBtn: false });
	        dlg.ShowDialog();
	    }        
        </script>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="LinkButton1">
    <walker:navi ID="mynavi" runat="server" menu="deptmanager" />
	<div id="container" class="container">
    <div class="div_top container">
         <div class="nav breadcrumb">
          当前位置&nbsp;&nbsp;>&nbsp;&nbsp;部门管理
        </div>
        <!--简单过滤开始-->
        <div class="toolbar form-inline">
            <label>部门名称：<asp:TextBox runat="server" ID="txtdeptname" CssClass="tinput shortTxt"></asp:TextBox></label>
            <div class="btn-group">
                <asp:LinkButton runat="server" ID="LinkButton1" OnClientClick="return checkQuery();" OnClick="btnsearch" CssClass="btn1 btn btn-primary"><i class="icon-search icon-white"></i> 查询</asp:LinkButton>
                <%--<a href="javascript:void(0);" class="btn1 btn" id="btnHighQuery" onclick="detail(this);"><i class="icon-plus"></i> 添加</a>--%>
                <asp:LinkButton runat="server" ID="btnAdd" CssClass="btn1 btn" OnClientClick="detail(); return false;"><i class="icon-plus"></i> 添加</asp:LinkButton>
            </div>
            <%--<table class="tab1">
                <tr>
                    <td valign="middle">部门名称：</td>
                    <td valign="top">
                        <asp:TextBox runat="server" ID="txtdeptname" CssClass="tinput shortTxt"></asp:TextBox>
                    </td>
                <td valign="top">
                    <asp:Button runat="server" ID="LinkButton1" Text="查询" OnClick="btnsearch" CssClass="btn1" />
                </td>
                <td valign="top">
                    <a href="javascript:void(0);" class="btn1" id="btnHighQuery" onclick="detail();">添加</a>
                </td>
                </tr>
            </table>--%>
        </div>
        <!--简单过滤结束-->
        <%--<div class="fixheader" id="fixheader"></div>--%>
    </div>
    <div class="rightcontent" id="rightcontent">
    <asp:ValidationSummary runat="server" ID="valisum" ShowMessageBox="true" ShowSummary="false" EnableClientScript="true" HeaderText="错误：" />
    <asp:GridView ID="gridlist" runat="server" DataKeyNames="deptid" 
            AutoGenerateColumns="false" CssClass="table1 table table-condensed table-bordered" DataSourceID="ods"  GridLines="None" CellSpacing="-1"
            onrowupdated="gridlist_RowUpdated" onrowdeleted="gridlist_RowDeleted">
        <Columns>
        <%--<asp:TemplateField HeaderStyle-Width="20px" ItemStyle-Width="20px">
            <HeaderTemplate><input type="checkbox" id="cbxall" value='<%# Eval("deptid") %>' /></HeaderTemplate>
            <ItemTemplate>
                <input type="checkbox" class="GVcbx"/>
            </ItemTemplate>
        </asp:TemplateField>--%>        
        <asp:TemplateField HeaderText="部门名称" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="140px" HeaderStyle-Width="140px">
            <ItemTemplate><%# Eval("deptname") %></ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtdeptname" runat="server" Text='<%# Bind("deptname") %>' CssClass="tinput" Width="130px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqvalids" runat="server" ControlToValidate="txtdeptname" ErrorMessage="部门名称不能为空！" Display="None"></asp:RequiredFieldValidator>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="排序标志" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="60px" HeaderStyle-Width="60px">
            <ItemTemplate><%# Eval("seq") %></ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtseq" runat="server" Text='<%# Bind("seq") %>' CssClass="tinput" Width="50px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rqvalid9" runat="server" ControlToValidate="txtseq" ErrorMessage="排序标志不能为空！" Display="None"></asp:RequiredFieldValidator>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="说明" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="200px" HeaderStyle-Width="200px">
            <ItemTemplate><%# Eval("remark") %></ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtremark" runat="server" Text='<%# Bind("remark") %>' CssClass="tinput" Width="190px"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="操作" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="120px" HeaderStyle-Width="120px" ItemStyle-CssClass="btn-group">
            <ItemTemplate>
                <asp:LinkButton runat="server" ID="lbtnedit" CommandName="Edit" CssClass="btn btn-small" Enabled='<%# canedit(Eval("deptid").ToString()) %>'>编辑</asp:LinkButton>
                <asp:LinkButton runat="server" ID="lbtndel" CommandName="Delete" CssClass='<%# "btn btn-small user-" + Eval("deptid") %>'
                    OnClientClick='<%# "if($(\".user-"+ Eval("deptid")+"[disabled]\").length>0) return false;return confirm(\"确认删除？\")" %>'
                    Enabled='<%# canedit(Eval("deptid").ToString()) %>'>删除</asp:LinkButton>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:LinkButton runat="server" ID="lbtnupdate" CommandName="Update" CssClass="btn btn-small btn-info">保存</asp:LinkButton>
                <asp:LinkButton runat="server" ID="lbtncancel" CommandName="Cancel" CausesValidation="false" CssClass="btn btn-small">取消</asp:LinkButton>
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
            DataObjectTypeName="WZY.Model.DEPART" DeleteMethod="Delete" InsertMethod="Add" 
            SelectMethod="GetList" TypeName="WZY.DAL.DEPART" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="deptid" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:Parameter DefaultValue="1=1 order by seq" Name="strWhere" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
