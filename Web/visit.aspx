<%@ Page Language="C#" AutoEventWireup="true" CodeFile="visit.aspx.cs" Inherits="visit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>案件管理</title>
    <link href="/css/public.css?v=0" rel="stylesheet" type="text/css" />
    <link href="/css/main.css?v=1" rel="stylesheet" type="text/css" />
    <script src="js/ca/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/js/lhgdialog.min.js"></script>
    <script type="text/javascript" src="/js/core.js?type=single&v=5"></script>
    <script type="text/javascript">
        $(function () {
            //添加
            var dlgAdd = $("#btnAdd").dialog({ id: 'd2', title: '添加拜访记录', page: 'visit_add.aspx?act=add&t=' + new Date().getMilliseconds() + '&url=' + location.pathname,
                resize: true, width: 550, height: 420, cover: true, cancelBtn: false, rang: true
            });
        });
        //弹窗_编辑
        function detail() {

        }
        //上传
        function upload(custid) {
            var dlg = new $.dialog({ id: "dg02", title: '快速上传文件', page: "quickupload.aspx?custid=" +custid + "&t=" + new Date().getMilliseconds()  + "&url=" + location.href, resize: false, width: 500, height: 360, cover: true, rang: true, cancelBtn: false });
            dlg.ShowDialog();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="LinkButton1">
    <div id="container">
        <div class="div_top">
            <div class="nav">
                当前位置&nbsp;&nbsp;>&nbsp;&nbsp;拜访记录
            </div>
            <!--简单过滤开始-->
            <div class="toolbar">
                <table class="tab1">
                    <tr>
                        <td valign="middle">
                            客户名称：
                        </td>
                        <td>
                            <input type="text" title="客户名称" id="txtpeople" class="tinput shortTxt" runat="server" />
                        </td>
                        <td>
                            拜访日期：
                        </td>
                        <td>
                            <input id="txtsdate" type="text" class="Wdate shortTxt" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd',doubleCalendar:'true',startDate:'%y-{%M-1}-%d',maxDate:'%y-{%M}-%d'});"
                                runat="server" />至：
                            <input id="txtedate" type="text" class="Wdate shortTxt" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd',minDate:'#F{$dp.$D(\'txtsdate\')}',maxDate:'%y-%M-%d'});"
                                runat="server" />
                        </td>
                        <td valign="middle">
                            数据范围：
                        </td>
                        <td valign="top">
                            <div class="select">
                                <div>
                                    <asp:DropDownList runat="server" ID="ddlrange">
                                        <asp:ListItem>本人</asp:ListItem>
                                        <asp:ListItem>本部门</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </td>
                        <td valign="top">
                            <asp:Button runat="server" ID="LinkButton1" Text="查询" OnClick="btnsearch" CssClass="btn1" />
                        </td>
                        <td valign="top">
                            <a href="javascript:void(0);" class="btn1" id="btnAdd">添加</a>
                        </td>
                        <%--<td valign="top">
                            <a href="javascript:void(0);" class="btn1" id="btnEdit" onclick="detail();">编辑</a>
                        </td>--%>
                        <%--<td valign="top">
                            <a href="javascript:void(0);" class="btn1" id="btnDelShow" onclick="return checkQuery();">删除</a>
                        </td>--%>
                    </tr>
                </table>
            </div>
            <!--简单过滤结束-->
            <div class="fixheader" id="fixheader">
            </div>
        </div>
        <div class="rightcontent" id="rightcontent">
            <asp:ValidationSummary runat="server" ID="valisum" ShowMessageBox="true" ShowSummary="false" EnableClientScript="true" HeaderText="错误：" />
            <asp:GridView ID="gridlist" CssClass="table1" runat="server" Width="100%" CellPadding="3" AutoGenerateColumns="false" DataKeyNames="recid">
                <Columns>
                    <asp:TemplateField HeaderStyle-Width="20px" ItemStyle-Width="20px" Visible="false">
                        <HeaderTemplate><input type="checkbox" id="cbxall" /></HeaderTemplate>
                        <ItemTemplate>
                            <input type="checkbox" class="GVcbx" value='<%# Eval("recid") %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="拜访律师" SortExpression="result" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="60px" ItemStyle-Width="60px">
                        <ItemTemplate><%# Eval("displayname") %></ItemTemplate>
                        <EditItemTemplate>
                            <%# Eval("displayname") %><asp:HiddenField runat="server" ID="hiduid" Value='<%# Bind("uid") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="拜访客户" SortExpression="result" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="162px" ItemStyle-Width="162px">
                        <ItemTemplate><span title='<%# Eval("custname") %>'><%# Helper.HelperString.cutString(Eval("custname").ToString(),12) %></span></ItemTemplate>
                        <EditItemTemplate>
                            <%# Eval("custname") %><asp:HiddenField runat="server" ID="hidcustid" Value='<%# Bind("custid") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="拜访事由" SortExpression="result" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="160px" ItemStyle-Width="160px">
                        <ItemTemplate><%# Eval("reason") %></ItemTemplate>
                        <EditItemTemplate>
                            <div class="cellTextArea"><asp:TextBox ID="txtreason" runat="server" Text='<%# Bind("reason") %>' CssClass="tinput" Width="155px" TextMode="MultiLine"></asp:TextBox></div>
                            <asp:RequiredFieldValidator ID="rqvalids" runat="server" ControlToValidate="txtreason" ErrorMessage="拜访事由不能为空！" Display="None"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="拜访结果" SortExpression="result" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="160px" ItemStyle-Width="160px">
                        <ItemTemplate><%# Eval("result") %></ItemTemplate>
                        <EditItemTemplate>
                            <div class="cellTextArea"><asp:TextBox ID="txtresult" runat="server" Text='<%# Bind("result") %>' CssClass="tinput" Width="155px" TextMode="MultiLine"></asp:TextBox></div>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="time" HeaderText="拜访时间" SortExpression="time" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="90px" ItemStyle-Width="90px" ReadOnly="true" DataFormatString="{0:d}" />
                    <asp:TemplateField HeaderText="备注" SortExpression="result" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="140px" ItemStyle-Width="140px">
                        <ItemTemplate><%# Eval("remark") %></ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtremark" runat="server" Text='<%# Bind("remark") %>' CssClass="tinput" Width="130px"></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作"  HeaderStyle-Width="120px" ItemStyle-Width="120px">
                        <ItemTemplate>
                            <a href="#" onclick='upload(<%# Eval("custid") %>);'>上传文件</a>
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
        <webdiyer:aspnetpager id="AspNetPager1" runat="server" AlwaysShow="True" ShowCustomInfoSection="Left"
        width="100%" CustomInfoHTML="共<b> %RecordCount% </b>条记录 <b>%CurrentPageIndex%</b> / <b>%PageCount%</b>" ShowMoreButtons="true" ShowDisabledButtons="false" FirstPageText="第一页" LastPageText="最后页" PrevPageText="上一页" NextPageText="下一页" Direction="RightToLeft" CustomInfoStyle="text-align:left;"></webdiyer:aspnetpager>
    </div>
        </div>
        <asp:ObjectDataSource ID="ods" runat="server" 
            DataObjectTypeName="WZY.Model.VISIT" DeleteMethod="Delete" InsertMethod="Add" 
            SelectMethod="GetPage" TypeName="WZY.DAL.VISIT" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="recid" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:Parameter DefaultValue="1=1" Name="strWhere" Type="String" />
                <asp:ControlParameter ControlID="AspNetPager1" PropertyName="CurrentPageIndex" DefaultValue="1" Name="pageindex" Type="Int32" />
                <asp:ControlParameter ControlID="AspNetPager1" PropertyName="PageSize" DefaultValue="10" Name="pagesize" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
<%--        <asp:ObjectDataSource ID="odsuser" runat="server" SelectMethod="GetList" TypeName="WZY.DAL.SYSUSER">
            <SelectParameters>
                <asp:Parameter DefaultValue="1=1" Name="strWhere" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odscust" runat="server" SelectMethod="GetList" TypeName="WZY.DAL.CUSTOMER">
            <SelectParameters>
                <asp:Parameter DefaultValue="1=1" Name="strWhere" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>--%>
    </form>
</body>
</html>
