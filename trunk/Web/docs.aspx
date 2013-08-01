<%@ Page Language="C#" AutoEventWireup="true" CodeFile="docs.aspx.cs" Inherits="docs" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--<link href="/css/public.css?v=0" rel="stylesheet" type="text/css" />
    <link href="/css/main.css?v=1" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/js/lhgdialog.min.js"></script>--%>
    <walker:header ID="myheader" runat="server" mytitle="文档管理" />
    <script type="text/javascript" src="/js/core.js?type=single&v=5"></script>
	<script type="text/javascript">
        <%="var cates=" + cates + ";" %>
	    $(function () {
	        //添加
	        var dlgAdd = $("#btnAdd").dialog({ id: 'd2', title: '上传文档', page: 'upload.aspx?act=add&t=' + new Date().getMilliseconds() + '&url=' + location.pathname,
	            resize: false, width: 500, height: 400, cover: true, cancelBtn: false, rang: true
	        });
	        //批量上传
	        var dlgAddMulti = $("#btnAddm").dialog({ id: 'd2f3', title: '批量上传文档', page: 'multiupload.aspx?act=add&t=' + new Date().getMilliseconds() + '&url=' + location.pathname,
	            resize: false, width: 670, height: 400, cover: true, cancelBtn: false, rang: true
	        });
	        $("#ddltype").change(function () {
	            var o = $(this);
	            var ddl = $("#ddlcate").empty().append($("<option/>", { text: '全部', value: -1 }));
	            var data = cates;
	            if ($("option:selected", o).index() > 0) data = $(cates).filter(function (i, m) { return m.typeid == o.val(); });
	            $(data).each(function (i, m) { $("<option/>", { text: m.name, value: m.id }).appendTo(ddl); });
	        }).trigger("change");
	        fakeviewstate();
	    });
	    //回发后还原非服务器控件的值
	    function fakeviewstate() {
	        $("#ddlcate option[value=<%=request_cateid%>]").attr("selected", true);
	    }
	    //弹窗_编辑
	    function detail() {
	        if ($(".selected").length == 0) {
	            malert("请选择一条记录！");
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
    <walker:navi ID="mynavi" runat="server" menu="docs" />
	<div id="container" class="container">
    <div class="div_top container">
         <div class="nav breadcrumb">
          当前位置&nbsp;&nbsp;>
                <% if (usecustid){ %>
                    &nbsp;&nbsp;<a href="javascript:void(0);" onclick='location.href=&#39;/clients.aspx?f=&#39;+encodeURIComponent(&#39;<%=Request.QueryString["f"] %>&#39;);' class="btn1" id="A1324">客户管理</a>&nbsp;&nbsp;>
                <%} %>&nbsp;&nbsp;文档管理
        </div>
        <!--简单过滤开始-->
        <div class="toolbar form-inline" <% if(usecustid){ %>style="display:none;"<%} %>>
            <fieldset>
                <legend>查询条件</legend>
                <label>主营业务：<asp:DropDownList ToolTip="主营业务" runat="server" ID="ddltype" CssClass="input-small"></asp:DropDownList></label>
                <label>文档类别：<asp:DropDownList ToolTip="文档类别" runat="server" ID="ddlcate" CssClass="input-small"></asp:DropDownList></label>
                <label>上传人：<input type="text" title="上传人" id="txtuser" class="tinput shortTxt input-small" runat="server" /></label>
                <label>客户名：<input type="text" title="客户名" id="txtcust" class="tinput shortTxt input-small" runat="server" /></label>
                <label>案由：<input type="text" title="案由" id="txtfilename" class="tinput shortTxt" runat="server" /></label>
                <%--<label>数据范围：<asp:DropDownList ToolTip="数据范围" runat="server" ID="ddlrange" CssClass="input-small"><asp:ListItem>本人</asp:ListItem><asp:ListItem>本部门</asp:ListItem></asp:DropDownList></label>--%><br />
                <label>开始时间：<input id="txtsdate" type="text" class="Wdate shortTxt input-small" onclick="WdatePicker({dateFmt:'yyyy-MM-dd',doubleCalendar:'true',maxDate:'%y-{%M}-%d',onpicked:function(){$('#txtedate')[0].focus();}});" runat="server" /></label>
                <label>结束时间：<input id="txtedate" type="text" class="Wdate shortTxt input-small" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd',maxDate:'%y-%M-%d'});" runat="server" /></label>
                &nbsp;&nbsp;
                <div class="btn-group">
                    <%--<asp:Button runat="server" ID="LinkButton1" Text="查询" OnClientClick="return checkQuery();" OnClick="btnsearch" CssClass="btn1 btn btn-primary" />--%>
                    <asp:LinkButton runat="server" ID="LinkButton1" OnClientClick="return checkQuery();" OnClick="btnsearch" CssClass="btn1 btn btn-primary"><i class="icon-search icon-white"></i> 查询</asp:LinkButton>
                    <a href="javascript:detail();" class="btn1 btn"><i class="icon-pencil"></i> 编辑</a>
                    <a href="javascript:void(0);" class="btn1 btn" id="btnAdd"><i class="icon-upload"></i> 上传文档</a>
                    <a href="javascript:void(0);" class="btn1 btn" id="btnAddm"><i class="icon-th"></i> 批量上传</a>
                </div>
            </fieldset>
            <%--<table class="tab1">
                <tr>
                    <td valign="middle">主营业务：</td>
                    <td valign="middle">
                        <div class="select"><div></div></div>
                    </td>
                    <td valign="middle">文档类别：</td>
                    <td valign="middle">
                        <div class="select"><div></div></div>
                    </td>
                    <td valign="middle">上传人：</td>
                    <td valign="middle">
                    </td>
                    <td valign="middle">客户名：</td>
                    <td valign="middle">
                    </td>
                    <td valign="middle">文件名：</td>
                    <td valign="middle">
                    </td>
                    <td valign="middle">数据范围：</td>
                    <td valign="middle">
                        <div class="select"><div></div></div>
                    </td>
                </tr>
            </table>--%>
        </div> 
        <%--<div class="toolbar" <% if(usecustid){ %>style="display:none;"<%} %>>
            <table class="tab1">
                <tr>
                    <td>上传时间：</td>
                    <td>
                    </td>
                    <td>
                        &nbsp;<asp:CheckBox ID="cbxCase" runat="server" Text="包括案件文档" Visible="false" />
                    </td>
                <td valign="top">
                </td>
                <td valign="top"></td>
                <td valign="top">
                </td>
                <td valign="top">
                </td>
                </tr>
            </table>
        </div>--%>
        <!--简单过滤结束-->
        <%--<div class="fixheader" id="fixheader"></div>--%>
    </div>
    <div class="rightcontent container" id="rightcontent">
<asp:GridView ID="gridlist" runat="server" CssClass="table1 table table-bordered table-condensed" DataKeyNames="docid" AutoGenerateColumns="false" OnRowDataBound="gvdatabind" GridLines="None" CellSpacing="-1" EnableViewState="True">
        <Columns>
        <asp:TemplateField HeaderStyle-Width="20px" ItemStyle-Width="20px">
            <HeaderTemplate><input type="checkbox" id="cbxall" /></HeaderTemplate>
            <ItemTemplate>
                <input type="checkbox" class="GVcbx" value='<%# Eval("docid") %>'/>
                <asp:HiddenField runat="server" ID="hidcandel" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="上传人" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="80px" HeaderStyle-Width="80px" DataField="displayname" />
        <asp:TemplateField HeaderText="主营业务" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="80px">
            <ItemTemplate>
                <asp:DropDownList ID="ddltype" runat="server" DataSourceID="odstype" CssClass="tinput input-small" DataTextField="cate_name" DataValueField="cate_id" selectedvalue='<%# Bind("typeid") %>' Enabled="false"></asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="文档类别" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="130px">
            <ItemTemplate>
                <asp:DropDownList ID="ddlcate" runat="server" DataSourceID="odscate" CssClass="tinput" Width="130px" DataTextField="catename" DataValueField="cateid" selectedvalue='<%# Bind("cateid") %>' Enabled="false"></asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="客户名称" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="nodetail" HeaderStyle-Width="180px" ItemStyle-Width="162px">
            <ItemTemplate>
                <span title='<%# Eval("custname") %>'><%# Helper.HelperString.cutString(Eval("custname").ToString(),13) %></span>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="文件名" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="nodetail" HeaderStyle-Width="250px" ItemStyle-Width="250px">
            <ItemTemplate>
                <span title='<%# Eval("docname") %>'><%# Helper.HelperString.cutString(Eval("docname").ToString(), 14)%></span>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="上传时间" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="120px" HeaderStyle-Width="80px" DataField="uptime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
        <asp:BoundField HeaderText="文件操作" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="80px" HeaderStyle-Width="80px" />
        <%--<asp:TemplateField HeaderText="&nbsp;"><ItemTemplate>&nbsp;</ItemTemplate></asp:TemplateField>--%>
            </Columns>
    </asp:GridView>
    </div>
    <div class="divpager"><%--<asp:Label runat="server" ID="lblpager"></asp:Label>--%>
        <webdiyer:aspnetpager id="AspNetPager1" runat="server" AlwaysShow="True" ShowCustomInfoSection="Right"
        width="100%" CustomInfoHTML="共<b> %RecordCount% </b>条记录 <b>%CurrentPageIndex%</b> / <b>%PageCount%</b>"
             ShowMoreButtons="true" ShowDisabledButtons="true" FirstPageText="首页" LastPageText="尾页" PrevPageText="上页" NextPageText="下页"
             Direction="LeftToRight" CustomInfoStyle="text-align:right;"></webdiyer:aspnetpager>
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
        <asp:ObjectDataSource ID="odstype" runat="server" SelectMethod="GetList" TypeName="WZY.DAL.cate_yewu">
            <SelectParameters>
                <asp:Parameter DefaultValue="1=1 order by cate_index" Name="strWhere" Type="String" />
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
            } else { malert("删除失败"); }
        });
    }
</script>
</html>
