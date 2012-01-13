<%@ Page Language="C#" AutoEventWireup="true" CodeFile="docs.aspx.cs" Inherits="docs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>文档管理</title>
    <link href="/css/public.css?v=0" rel="stylesheet" type="text/css" />
    <link href="/css/main.css?v=1" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="/js/lhgdialog.min.js"></script>
    <script type="text/javascript" src="/js/core.js?type=single&v=5"></script>
      
	<script type="text/javascript">
	    $(function () {
	        //添加
	        var dlgAdd = $("#btnAdd").dialog({ id: 'd2', title: '上传文档', page: 'upload.aspx?act=add&t=' + new Date().getMilliseconds() + '&url=' + location.pathname,
	            resize: false, width: 500, height: 400, cover: true, cancelBtn: false, rang: true
	        });
	        //批量上传
	        var dlgAddMulti = $("#btnAddm").dialog({ id: 'd2f3', title: '批量上传文档', page: 'multiupload.aspx?act=add&t=' + new Date().getMilliseconds() + '&url=' + location.pathname,
	            resize: false, width: 650, height: 400, cover: true, cancelBtn: false, rang: true
	        });
	    });
	    //弹窗_编辑
	    function detail() {
	        if ($(".selected").length == 0) {
	            alert("请选择一条记录！");
	            return;
	        }
	        var id = $(".selected input:checked").val();
	        var auth = $(".selected input:hidden").val();
	        var dlg = new $.dialog({ id: "dg02", title: '编辑文档', page: 'upload.aspx?act=modify&auth='+auth+'&id=' + id + '&t=' + new Date().getMilliseconds() + '&url=' + location.pathname,
             resize: false, width: 500, height: 400, cover: true, rang: true, cancelBtn: false });
	        dlg.ShowDialog();
	    }        
        </script>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="LinkButton1">
	<div id="container">
    <div class="div_top">
         <div class="nav">
          当前位置&nbsp;&nbsp;>&nbsp;&nbsp;<%if (usecustid)
                                         { %><a href='/clients.aspx?f=<%=Request.QueryString["f"] %>' style="text-decoration:none; color:Blue;">客户管理</a>&nbsp;&nbsp;>&nbsp;&nbsp;<%} %>文档管理
        </div>
        <!--简单过滤开始-->
                <% if (usecustid)
                   { %>
        <div class="toolbar">
            <table class="tab1">
                <tr>
                <td valign="top">
                    <a href="javascript:void(0);" onclick='location.href=&#39;/clients.aspx?f=&#39;+encodeURIComponent(&#39;<%=Request.QueryString["f"] %>&#39;);' class="btn1" id="A1324">返回客户管理</a>
                </td>
                </tr>
            </table>
        </div>
                <%} %>
        <div class="toolbar" <% if(usecustid){ %>style="display:none;"<%} %>>
            <table class="tab1">
                <tr>
                    <td valign="middle">文档类别：</td>
                    <td valign="middle">
                        <div class="select"><div><asp:DropDownList ToolTip="文档类别" runat="server" ID="ddlcate"></asp:DropDownList></div></div>
                    </td>
                    <td valign="middle">上传人：</td>
                    <td valign="middle">
                        <input type="text" title="上传人" id="txtuser" class="tinput shortTxt" runat="server" />
                    </td>
                    <td valign="middle">客户名：</td>
                    <td valign="middle">
                        <input type="text" title="客户名" id="txtcust" class="tinput shortTxt" runat="server" />
                    </td>
                    <td valign="middle">文件名：</td>
                    <td valign="middle">
                        <input type="text" title="案由" id="txtfilename" class="tinput shortTxt" runat="server" />
                    </td>
                    <td valign="middle">数据范围：</td>
                    <td valign="middle">
                        <div class="select"><div><asp:DropDownList runat="server" ID="ddlrange"><asp:ListItem>本人</asp:ListItem><asp:ListItem>本部门</asp:ListItem></asp:DropDownList></div></div>
                    </td>
                </tr>
            </table>
        </div> 
        <div class="toolbar" <% if(usecustid){ %>style="display:none;"<%} %>>
            <table class="tab1">
                <tr>
                    <td>上传时间：</td>
                    <td>
                        <input id="txtsdate" type="text" class="Wdate shortTxt" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd',doubleCalendar:'true',maxDate:'%y-{%M}-%d',onpicked:function(){$('#txteTime')[0].focus();}});" runat="server" />至：
                        <input id="txtedate" type="text" class="Wdate shortTxt" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd',maxDate:'%y-%M-%d'});" runat="server" />
                    </td>
                    <td>
                        &nbsp;<asp:CheckBox ID="cbxCase" runat="server" Text="包括案件文档" />
                    </td>
                <td valign="top">
                    <asp:Button runat="server" ID="LinkButton1" OnClientClick="return checkQuery();" Text="查询" OnClick="btnsearch" CssClass="btn1" />
                </td>
                <td valign="top"><input type="button" class="btn1" value="编辑" onclick="detail();" /></td>
                <td valign="top">
                    <a href="javascript:void(0);" class="btn1" id="btnAdd">上传文档</a>
                </td>
                <td valign="top">
                    <a href="javascript:void(0);" class="btn1" id="btnAddm">批量上传</a>
                </td>
                </tr>
            </table>
        </div>
        <!--简单过滤结束-->
        <div class="fixheader" id="fixheader"></div>
    </div>
    <div class="rightcontent" id="rightcontent">
<asp:GridView ID="gridlist" runat="server" CssClass="table1" DataKeyNames="docid" AutoGenerateColumns="false" OnRowDataBound="gvdatabind">
        <Columns>
        <asp:TemplateField HeaderStyle-Width="20px" ItemStyle-Width="20px">
            <HeaderTemplate><input type="checkbox" id="cbxall" /></HeaderTemplate>
            <ItemTemplate>
                <input type="checkbox" class="GVcbx" value='<%# Eval("docid") %>'/>
                <asp:HiddenField runat="server" ID="hidcandel" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="上传人" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="80px" HeaderStyle-Width="80px" DataField="displayname" />
        <asp:TemplateField HeaderText="文档类别" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100px" HeaderStyle-Width="100px">
            <ItemTemplate>
                <asp:DropDownList ID="ddlcate" runat="server" DataSourceID="odscate" CssClass="tinput" Width="85px" DataTextField="catename" DataValueField="cateid" selectedvalue='<%# Bind("cateid") %>' Enabled="false"></asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="客户名称" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="nodetail" HeaderStyle-Width="162px" ItemStyle-Width="162px">
            <ItemTemplate>
                <span title='<%# Eval("custname") %>'><%# Helper.HelperString.cutString(Eval("custname").ToString(),12) %></span>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="文件名" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="nodetail" HeaderStyle-Width="250px" ItemStyle-Width="250px">
            <ItemTemplate>
                <span title='<%# Eval("docname") %>'><%# Helper.HelperString.cutString(Eval("docname").ToString(), 12)%></span>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="上传时间" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="80px" HeaderStyle-Width="80px" DataField="uptime" DataFormatString="{0:d}" />
        <asp:BoundField HeaderText="文件操作" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px" HeaderStyle-Width="80px" />
        <asp:TemplateField HeaderText="&nbsp;"><ItemTemplate>&nbsp;</ItemTemplate></asp:TemplateField>
            </Columns>
    </asp:GridView>
    </div>
    <div class="divpager"><%--<asp:Label runat="server" ID="lblpager"></asp:Label>--%>
        <webdiyer:aspnetpager id="AspNetPager1" runat="server" AlwaysShow="True" ShowCustomInfoSection="Left"
        width="100%" CustomInfoHTML="共<b> %RecordCount% </b>条记录 <b>%CurrentPageIndex%</b> / <b>%PageCount%</b>" ShowMoreButtons="true" ShowDisabledButtons="false" FirstPageText="第一页" LastPageText="最后页" PrevPageText="上一页" NextPageText="下一页" Direction="RightToLeft" CustomInfoStyle="text-align:left;"></webdiyer:aspnetpager>
    </div>
    <div id="divdetail"></div>
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
        
        <asp:ObjectDataSource ID="odscate" runat="server" SelectMethod="GetList" TypeName="WZY.DAL.CATE_DOC">
            <SelectParameters>
                <asp:Parameter DefaultValue="1=1 order by seq" Name="strWhere" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</body>
<script src="/js/ca/WdatePicker.js" type="text/javascript"></script>
<script type="text/javascript">
    function checkQuery() {return true;}
    function deldoc(id) {
        if (!confirm("确认删除？")) return;
        //ajax删除文件
        $.get("ajaxHandler.aspx", { act: "deldoc", t: new Date().getMilliseconds(), id: id }, function (d) {
            if (d == "1") {
                __doPostBack("LinkButton1", "");
            } else { alert("删除失败"); }
        });
    }
</script>
</html>
