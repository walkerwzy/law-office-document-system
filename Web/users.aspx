<%@ Page Language="C#" AutoEventWireup="true" CodeFile="users.aspx.cs" Inherits="users" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <%--<title>用户管理</title>
    <link href="/css/public.css?v=0" rel="stylesheet" type="text/css" />
    <link href="/css/main.css?v=1" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="/js/lhgdialog.min.js"></script>--%>
    <walker:header runat="server" ID="myheader" mytitle="用户管理" />
    <script type="text/javascript" src="/js/core.js?type=single&v=5"></script>
    <script type="text/javascript">
        $(function () {
        });
        //弹窗_编辑
        function detail(o) {
            if ($("#btnAdd[disabled]").length > 0) return false;
            var dlg = new $.dialog({ id: "dg02", title: '添加用户', page: "user_add.aspx", resize: false, width: 500, height: 280, cover: true, rang: true, cancelBtn: false });
            dlg.ShowDialog();
        }
        //员工
        function employee(uid, uname) {
            var dlg = new $.dialog({ id: "dg02mep", title: '添加用户', page: "employee.aspx?t=" + new Date().getMilliseconds() + "&id=" + uid + "&name=" + uname, resize: false, width: 750, height: 590, cover: true, rang: true, cancelBtn: false });
            dlg.ShowDialog();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="LinkButton1">
    <walker:navi ID="mynavi" runat="server" menu="usermanager" />
    <div id="container" class="container">
        <div class="div_top container">
            <div class="nav breadcrumb">
                当前位置&nbsp;&nbsp;>&nbsp;&nbsp;用户管理
            </div>
            <!--简单过滤开始-->
            <div class="toolbar form-inline">
                <fieldset>
                    <legend>查询条件</legend>
                    <label>所属部门：<asp:DropDownList runat="server" ID="ddldeptsearch" CssClass="input-medium"></asp:DropDownList></label>
                    <label>用户姓名：<asp:TextBox ID="txtusername" runat="server" CssClass="tinput shortTxt input-medium"></asp:TextBox></label>
                    <div class="btn-group">
                        <asp:LinkButton runat="server" ID="LinkButton1" OnClientClick="return checkQuery();" OnClick="btnsearch" CssClass="btn1 btn btn-primary"><i class="icon-search icon-white"></i> 查询</asp:LinkButton>
                        <%--<a href="javascript:void(0);" class="btn1 btn" id="btnHighQuery" onclick="detail();"><i class="icon-plus"></i> 添加</a>--%>
                        <asp:LinkButton runat="server" ID="btnAdd" OnClientClick="detail(); return false;" CssClass="btn1 btn"><i class="icon-plus"></i> 添加</asp:LinkButton>
                    </div>
                </fieldset>
                <%--<table class="tab1">
                    <tr>
                        <td valign="middle">
                            所属部门：
                        </td>
                        <td valign="top">
                            <div class="select">
                                <div>
                                    <asp:DropDownList runat="server" ID="ddldeptsearch">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </td>
                        <td valign="middle">
                            用户姓名：
                        </td>
                        <td valign="top">
                            <asp:TextBox ID="txtusername" runat="server" CssClass="tinput shortTxt"></asp:TextBox>
                        </td>
                        <td valign="top">
                            <asp:Button runat="server" ID="LinkButton1" OnClientClick="return checkQuery();"
                                Text="查询" OnClick="btnsearch" CssClass="btn1" />
                        </td>
                        <td valign="top">
                            <a href="javascript:void(0);" class="btn1" id="btnHighQuery" onclick="detail();">添加</a>
                        </td>
                    </tr>
                </table>--%>
            </div>
            <!--简单过滤结束-->
            <%--<div class="fixheader" id="fixheader">
            </div>--%>
        </div>
        <div class="rightcontent" id="rightcontent">
            <asp:ValidationSummary runat="server" ID="valisum" ShowMessageBox="true" ShowSummary="false"
                EnableClientScript="true" HeaderText="错误：" />
            <asp:GridView ID="gridlist" runat="server" CssClass="table1 table table-condensed table-bordered" DataKeyNames="uid" AutoGenerateColumns="false" GridLines="None" CellSpacing="-1"
                DataSourceID="ods" OnRowUpdated="gridlist_RowUpdated">
                <Columns>
                    <asp:TemplateField HeaderStyle-Width="20px" ItemStyle-Width="20px" Visible="false">
                        <HeaderTemplate>
                            <input type="checkbox" id="cbxall" /></HeaderTemplate>
                        <ItemTemplate>
                            <input type="checkbox" class="GVcbx" value='<%# Eval("uid") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="编号" HeaderStyle-Width="40px" ItemStyle-Width="40px" DataField="uid"
                        ReadOnly="true" />
                    <asp:TemplateField HeaderText="角色" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px"
                        HeaderStyle-Width="100px">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlrole2" runat="server" DataSourceID="odsrole" CssClass="tinput"
                                Width="100px" DataTextField="rolename" DataValueField="roleid" SelectedValue='<%# Bind("roleid") %>'
                                Enabled="false" ForeColor="Black" BackColor="White">
                            </asp:DropDownList>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlrole" runat="server" DataSourceID="odsrole" CssClass="tinput"
                                Width="100px" DataTextField="rolename" DataValueField="roleid" SelectedValue='<%# Bind("roleid") %>'>
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="部门" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="120px"
                        HeaderStyle-Width="120px">
                        <ItemTemplate>
                            <asp:DropDownList ID="ddldeptcode2" runat="server" DataSourceID="odsdept" CssClass="tinput"
                                Width="120px" DataTextField="deptname" DataValueField="deptid" SelectedValue='<%# Bind("deptid") %>'
                                Enabled="false" ForeColor="Black" BackColor="White">
                            </asp:DropDownList>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddldeptcode" runat="server" DataSourceID="odsdept" CssClass="tinput"
                                Width="120px" DataTextField="deptname" DataValueField="deptid" SelectedValue='<%# Bind("deptid") %>'>
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="用户名" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="90px"
                        HeaderStyle-Width="80px">
                        <ItemTemplate>
                            <%# Eval("username") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtusername" runat="server" Text='<%# Bind("username") %>' CssClass="tinput"
                                Width="80px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqvalid1" runat="server" ControlToValidate="txtusername"
                                ErrorMessage="用户名不能为空！" Display="None"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="真实姓名" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="90px"
                        HeaderStyle-Width="90px">
                        <ItemTemplate>
                            <%# Eval("displayname") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtdisplayname" runat="server" Text='<%# Bind("displayname") %>'
                                CssClass="tinput" Width="80px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqvalid2" runat="server" ControlToValidate="txtdisplayname"
                                ErrorMessage="显示名称不能为空！" Display="None"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="密码" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="80px"
                        HeaderStyle-Width="80px">
                        <ItemTemplate>
                            ******</ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtguserpwd" value='<%# Eval("password") %>' runat="server" Text='<%# Bind("password") %>'
                                CssClass="tinput" Width="75px" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rqvalid37" runat="server" ControlToValidate="txtguserpwd"
                                ErrorMessage="密码不能为空！" Display="None"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="regqvali09" runat="server" ControlToValidate="txtguserpwd"
                                ErrorMessage="密码应为5-20位字母和数字！" ValidationExpression="^[0-9a-zA-Z]{5,20}$" Display="None"></asp:RegularExpressionValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="状态" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="60px"
                        HeaderStyle-Width="60px">
                        <ItemTemplate>
                            <%# Eval("stat").ToString()=="0"?"禁用":"正常" %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlstatus" runat="server" CssClass="tinput input-small" SelectedValue='<%# Bind("stat") %>'>
                                <asp:ListItem Value="1">正常</asp:ListItem>
                                <asp:ListItem Value="0">禁用</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="备注" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="200px"
                        HeaderStyle-Width="200px">
                        <ItemTemplate>
                            <%# Eval("remark") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtremark" runat="server" Text='<%# Bind("remark") %>' CssClass="tinput"
                                Width="195px"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="140px"
                        HeaderStyle-Width="140px" ItemStyle-CssClass="btn-group">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CssClass="btn btn-small" ID="lbtnedit" CommandName="Edit" Enabled='<%# canedit(Eval("deptid").ToString()) %>'>编辑</asp:LinkButton>
                            <asp:LinkButton runat="server" CssClass='<%# "btn btn-small user-" + Eval("uid") %>' ID="lbtndel" CommandName="Delete"
                                 OnClientClick='<%# "if($(\".user-"+ Eval("uid")+"[disabled]\").length>0) return false;return confirm(\"确认删除？\")" %>'
                                 Enabled='<%# canedit(Eval("deptid").ToString()) %>'>删除</asp:LinkButton>
                            <a href="javascript:void(0);" class="btn btn-small btn" onclick='employee(&#039;<%# Eval("uid") %>&#039;,&#039;<%# Eval("displayname") %>&#039;);'>资料</a>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton runat="server" CssClass="btn btn-small btn-primary" ID="lbtnupdate" CommandName="Update">保存</asp:LinkButton>
                            <asp:LinkButton runat="server" CssClass="btn btn-small" ID="lbtncancel" CommandName="Cancel" CausesValidation="false">取消</asp:LinkButton>
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div class="divpager">
            <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" ShowCustomInfoSection="Right"
                Width="100%" CustomInfoHTML="共<b> %RecordCount% </b>条记录 <b>%CurrentPageIndex%</b> / <b>%PageCount%</b>"
                ShowMoreButtons="true" ShowDisabledButtons="true"  FirstPageText="首页" LastPageText="尾页" PrevPageText="上页" NextPageText="下页"
                Direction="LeftToRight" CustomInfoStyle="text-align:Right;">
            </webdiyer:AspNetPager>
        </div>
        <asp:ObjectDataSource ID="ods" runat="server" DataObjectTypeName="WZY.Model.SYSUSER"
            DeleteMethod="Delete" InsertMethod="Add" SelectMethod="GetPage" TypeName="WZY.DAL.SYSUSER"
            UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="deptid" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:Parameter DefaultValue="1=1" Name="strWhere" Type="String" />
                <asp:ControlParameter ControlID="AspNetPager1" PropertyName="CurrentPageIndex" DefaultValue="1"
                    Name="pageindex" Type="Int32" />
                <asp:ControlParameter ControlID="AspNetPager1" PropertyName="PageSize" DefaultValue="10"
                    Name="pagesize" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsrole" runat="server" SelectMethod="GetList" TypeName="WZY.DAL.SYSROLE">
            <SelectParameters>
                <asp:Parameter DefaultValue="1=1" Name="strWhere" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsdept" runat="server" SelectMethod="GetList" TypeName="WZY.DAL.DEPART">
            <SelectParameters>
                <asp:Parameter DefaultValue="1=1 order by seq" Name="strWhere" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
    <script src="/js/ca/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        function checkQuery() { return true; }
    </script>
</body>
</html>
