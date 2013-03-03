<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cases.aspx.cs" Inherits="cases" ValidateRequest="false" %>
<%@ Register TagPrefix="walker" TagName="header" Src="~/controls/header.ascx" %>
<%@ Register TagPrefix="walker" TagName="navi" Src="~/controls/navi.ascx" %>
<%@ Register TagPrefix="walker" TagName="shared" Src="~/controls/shared.ascx" %>
<%@ Register TagPrefix="walker" TagName="popover" Src="~/controls/popover.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <%--<link href="/css/public.css?v=0" rel="stylesheet" type="text/css" />
    <link href="/css/main.css?v=1" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="/js/lhgdialog.min.js"></script>--%>
    <walker:header runat="server" ID="myheader" mytitle="案件管理" />
    <script type="text/javascript" src="/js/core.js?type=single&v=5"></script>
      
	<script type="text/javascript">
	    $(function () {
	        //弹窗_高级搜索
//	        var dlgQuery = $('#btnHighQuery').dialog({ id: 'd1',
//	            title: '高级查询',
//	            page: 'dialog.html?url=' + location.pathname + "&t=" + new Date().getMilliseconds(),
//	            resize: true,
//	            width: 500,
//	            height: 320,
//	            cover: true,
//	            cancelBtn: false,
//	            rang: true
//	        });
	        //添加
	        var dlgAdd = $("#btnAdd").dialog({ id: 'd2', title: '添加案件', page: 'case_add.aspx?act=add&t=' + new Date().getMilliseconds() + '&url=' + location.pathname,
	            resize: true, width: 750, height: 600, cover: true, cancelBtn: false, rang: true
	        });
	    });
	    //弹窗_编辑
	    function detail() {
	        if ($(".selected").length == 0) {
	            alert("请选择一条记录！");
	            return;
	        }
	        var id = $(".selected input:checked").data("id");
	        var info = $(".selected input:checked").val();
	        var dlg = new $.dialog({ id: "dg02", title: '修改案件信息', page: "case_add.aspx?act=modify&info="+info+"&t=" + new Date().getMilliseconds() + "&id="+ id +"&url=" + location.href, resize: false, width: 750, height: 600, cover: true, rang: true, cancelBtn: false });
	        dlg.ShowDialog();
	    }
        </script>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="LinkButton1">
    <walker:navi runat="server" ID="mynavi" menu="cases" />
	<div id="container" class="container">
    <div class="div_top container">
         <div class="nav breadcrumb">
          当前位置&nbsp;&nbsp;>&nbsp;&nbsp;
             <%if (usecustid){ %>
             <a href='/clients.aspx?f=<%=Request.QueryString["f"] %>' style="text-decoration:none; color:Blue;">客户管理</a>&nbsp;&nbsp;>&nbsp;&nbsp;
             <%} %>案件管理
             <%--<a href="javascript:void(0);" onclick='location.href=&#39;/clients.aspx?f=&#39;+encodeURIComponent(&#39;<%= Request.QueryString["f"] %>&#39;);' class="btn1" id="A1">客户管理</a>--%>
        </div>
        <!--简单过滤开始-->
        <div class="toolbar form-inline" <% if(usecustid){ %>style="display:none;"<%} %>>
            <fieldset>
                <legend>查询条件</legend>
                <label>案件类别：<asp:DropDownList ID="ddlcasecate" runat="server"></asp:DropDownList></label>
                <label>案件编号：<input type="text" title="案件编号" id="txtno" class="tinput shortTxt input-small" runat="server" /></label>
                <label>委托人：<input type="text" title="委托人" id="txtpeople" class="tinput shortTxt input-small" runat="server" /></label>
                <label>案由：<input type="text" title="案由" id="txtreason" class="tinput shortTxt input-small" runat="server" /></label>
                <label>数据范围：<asp:DropDownList runat="server" ID="ddlrange" CssClass="input-small"><asp:ListItem>本人</asp:ListItem><asp:ListItem>本部门</asp:ListItem></asp:DropDownList></label><br />
                <label>收案日期：<input id="txtsdate" type="text" class="Wdate shortTxt input-small" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd',doubleCalendar:'true',startDate:'%y-{%M-1}-%d',maxDate:'%y-{%M}-%d'});" runat="server" /></label>
                <label>至：<input id="txtedate" type="text" class="Wdate shortTxt input-small" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd',minDate:'#F{$dp.$D(\'txtsdate\')}',maxDate:'%y-%M-%d'});" runat="server" /></label>&nbsp;&nbsp;
                <div class="btn-group">
                    <asp:Button runat="server" ID="LinkButton1" Text="查询" OnClick="btnsearch" CssClass="btn1 btn btn-primary" />
                    <a href="javascript:void(0);" class="btn1 btn" id="btnEdit" onclick="detail();">编辑</a>
                    <a href="javascript:void(0);" class="btn1 btn" id="btnAdd">添加</a>
                    <a href="javascript:void(0);" class="btn1 btn" id="btnDelShow" onclick="return checkQuery();">删除</a>
                </div>
            </fieldset>
            <%--<table class="tab1">
                <tr>
                    <td>案件类别：</td>
                    <td><div class="select"><div><asp:DropDownList ID="ddlcasecate" runat="server"></asp:DropDownList></div></div></td>
                    <td valign="middle">案件编号：</td>
                    <td valign="top">
                        <input type="text" title="合同编号" id="txtno" class="tinput shortTxt" runat="server" />
                    </td>
                    <td valign="middle">委托人：</td>
                    <td valign="top">
                        <input type="text" title="委托人" id="txtpeople" class="tinput shortTxt" runat="server" />
                    </td>
                    <td valign="middle">案由：</td>
                    <td valign="top">
                        <input type="text" title="案由" id="txtreason" class="tinput shortTxt" runat="server" />
                    </td>
                    <td valign="middle">数据范围：</td>
                    <td valign="top">
                        <div class="select"><div><asp:DropDownList runat="server" ID="ddlrange"><asp:ListItem>本人</asp:ListItem><asp:ListItem>本部门</asp:ListItem></asp:DropDownList></div></div>
                    </td>
                </tr>
            </table>--%>
        </div> 
        <%--<div class="toolbar" <% if(usecustid){ %>style="display:none;"<%} %>>
            <table class="tab1">
                <tr>
                    <td>收案日期：</td>
                    <td>
                        <input id="txtsdate" type="text" class="Wdate shortTxt" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd',doubleCalendar:'true',startDate:'%y-{%M-1}-%d',maxDate:'%y-{%M}-%d'});" runat="server" />至：
                        <input id="txtedate" type="text" class="Wdate shortTxt" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd',minDate:'#F{$dp.$D(\'txtsdate\')}',maxDate:'%y-%M-%d'});" runat="server" />
                    </td>
                <td valign="top">
                    <asp:Button runat="server" ID="LinkButton1" Text="查询" OnClick="btnsearch" CssClass="btn1" />
                </td>
                <td valign="top">
                    <a href="javascript:void(0);" class="btn1" id="btnHighQuery">高级搜索</a>
                </td>
                <td valign="top">
                    <a href="javascript:void(0);" class="btn1" id="btnEdit" onclick="detail();">编辑</a>
                </td>
                <td valign="top">
                    <a href="javascript:void(0);" class="btn1" id="btnAdd">添加</a>
                </td>
                <td valign="top">
                    <a href="javascript:void(0);" class="btn1" id="btnDelShow" onclick="return checkQuery();">删除</a>
                    <asp:Button runat="server" ID="btnDel" OnClick="delcase" Text="" style="display:none;"/>
                </td>
                </tr>
            </table>
        </div>--%>
        <!--简单过滤结束-->
        <%--<div class="fixheader" id="fixheader"></div>--%>
    </div>
    <asp:HiddenField runat="server" ID="hiduinfo" />
    <div class="rightcontent container" id="rightcontent">
    <asp:GridView ID="gridlist" CssClass="table1 detailtb  table table-bordered table-condensed" runat="server" DataKeyNames="caseid" AutoGenerateColumns="false" OnRowDataBound="gvdatabind" GridLines="None" CellSpacing="-1" EnableViewState="false">
    <Columns>
        <asp:TemplateField HeaderStyle-Width="20px" ItemStyle-Width="20px">
            <HeaderTemplate><input type="checkbox" id="cbxall" /></HeaderTemplate>
            <ItemTemplate>
                <input type="checkbox" class="GVcbx" value='<%# Eval("caseid") %>|<%# Eval("uid") %>|<%# Eval("deptid") %>' name="ids" data-id='<%# Eval("caseid") %>'/>
                <asp:HiddenField runat="server" ID="hiddetail" Value="" />
            </ItemTemplate>
        </asp:TemplateField>
		<asp:BoundField DataField="caseno" HeaderText="案件编号" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" ItemStyle-Width="80px" />
		<asp:BoundField HeaderText="案件类别" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" ItemStyle-Width="80px" />
        <asp:TemplateField HeaderText="委托人" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="nodetail" HeaderStyle-Width="140px" ItemStyle-Width="140px">
            <ItemTemplate>
                <span title='<%# Eval("custname") %>'><%# Helper.HelperString.cutString(Eval("custname").ToString(),10) %></span>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="原告/申请人" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="nodetail" HeaderStyle-Width="104px" ItemStyle-Width="104px">
            <ItemTemplate>
                <span title='<%# Eval("yuangao") %>'><%# Helper.HelperString.cutString(Eval("yuangao").ToString(),7)%></span>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="被告/被申请人" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="nodetail" HeaderStyle-Width="104px" ItemStyle-Width="104px">
            <ItemTemplate>
                <span title='<%# Eval("beigao") %>'><%# Helper.HelperString.cutString(Eval("beigao").ToString(),7)%></span>
            </ItemTemplate>
        </asp:TemplateField>
		<asp:BoundField DataField="dijiaotime" HeaderText="递交手续时间" SortExpression="dijiaotime" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" ItemStyle-Width="80px" DataFormatString="{0:d}" /> 
		<asp:BoundField DataField="fee" HeaderText="代理费用" SortExpression="fee" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="60px" ItemStyle-Width="60px" /> 
        <%--<asp:TemplateField HeaderText="案件详情" HeaderStyle-Width="60px" ItemStyle-Width="60px" ItemStyle-CssClass="nodetail">
            <ItemTemplate>
                <%# getDocPath(Convert.ToInt32(Eval("detail").ToString()),Eval("caseid").ToString(),"detail",Eval("deptid").ToString()) %>
            </ItemTemplate>
        </asp:TemplateField>--%>
        <%--<asp:TemplateField HeaderText="诉讼分析报告" HeaderStyle-Width="80px" ItemStyle-Width="80px" ItemStyle-CssClass="nodetail">
            <ItemTemplate>
                <%# getDocPath(Convert.ToInt32(Eval("analysis").ToString()), Eval("caseid").ToString(), "analysis", Eval("deptid").ToString())%>
            </ItemTemplate>
        </asp:TemplateField>--%>
        <asp:TemplateField HeaderText="证据目录" HeaderStyle-Width="60px" ItemStyle-Width="60px" ItemStyle-CssClass="nodetail">
            <ItemTemplate>
                <%# getDocPath(Convert.ToInt32(Eval("evidence").ToString()), Eval("caseid").ToString(), "evidence", Eval("deptid").ToString())%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="质证意见" HeaderStyle-Width="60px" ItemStyle-Width="60px" ItemStyle-CssClass="nodetail">
            <ItemTemplate>
                <%# getDocPath(Convert.ToInt32(Eval("opinion").ToString()), Eval("caseid").ToString(), "opinion", Eval("deptid").ToString())%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="代理意见" HeaderStyle-Width="85px" ItemStyle-Width="85px" ItemStyle-CssClass="nodetail">
            <ItemTemplate>
                <%# getDocPath(Convert.ToInt32(Eval("quote").ToString()), Eval("caseid").ToString(), "quote", Eval("deptid").ToString())%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="上诉状/起诉状" HeaderStyle-Width="85px" ItemStyle-Width="85px" ItemStyle-CssClass="nodetail">
            <ItemTemplate>
                <%# getDocPath(Convert.ToInt32(Eval("qisu").ToString()), Eval("caseid").ToString(), "quote", Eval("deptid").ToString())%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="法庭提问" HeaderStyle-Width="60px" ItemStyle-Width="60px" ItemStyle-CssClass="nodetail">
            <ItemTemplate>
                <%# getDocPath(Convert.ToInt32(Eval("tiwen").ToString()), Eval("caseid").ToString(), "tiwen", Eval("deptid").ToString())%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="答辩意见" HeaderStyle-Width="60px" ItemStyle-Width="60px" ItemStyle-CssClass="nodetail">
            <ItemTemplate>
                <%# getDocPath(Convert.ToInt32(Eval("dabian").ToString()), Eval("caseid").ToString(), "dabian", Eval("deptid").ToString())%>
            </ItemTemplate>
        </asp:TemplateField>
        <%--<asp:TemplateField HeaderText="判决结果" HeaderStyle-Width="60px" ItemStyle-Width="60px" ItemStyle-CssClass="nodetail">
            <ItemTemplate>
                <%# getDocPath(Convert.ToInt32(Eval("result").ToString()), Eval("caseid").ToString(), "result", Eval("deptid").ToString())%>
            </ItemTemplate>
        </asp:TemplateField>--%>
        <%--<asp:TemplateField HeaderText="结案报告" HeaderStyle-Width="60px" ItemStyle-Width="60px" ItemStyle-CssClass="nodetail">
            <ItemTemplate>
                <%# getDocPath(Convert.ToInt32(Eval("resultreport").ToString()), Eval("caseid").ToString(), "resultreport", Eval("deptid").ToString())%>
            </ItemTemplate>
        </asp:TemplateField>--%>
        <%--<asp:TemplateField HeaderText="案件讨论记录" HeaderStyle-Width="85px" ItemStyle-Width="85px" ItemStyle-CssClass="nodetail">
            <ItemTemplate>
                <%# getDocPath(Convert.ToInt32(Eval("taolun").ToString()), Eval("caseid").ToString(), "quote", Eval("deptid").ToString())%>
            </ItemTemplate>
        </asp:TemplateField>--%>
		<%--<asp:BoundField DataField="detail" HeaderText="案件详情" SortExpression="detail" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="140px" ItemStyle-Width="140px" ItemStyle-CssClass="nodetail" /> 
		<asp:BoundField DataField="analysis" HeaderText="诉讼分析报告" SortExpression="analysis" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ItemStyle-Width="100px" ItemStyle-CssClass="nodetail" /> 
		<asp:BoundField DataField="evidence" HeaderText="证件材料" SortExpression="evidence" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ItemStyle-Width="100px" ItemStyle-CssClass="nodetail" /> 
		<asp:BoundField DataField="opinion" HeaderText="质证意见" SortExpression="opinion" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ItemStyle-Width="100px" ItemStyle-CssClass="nodetail" /> 
		<asp:BoundField DataField="quote" HeaderText="代理意见" SortExpression="quote" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ItemStyle-Width="100px" ItemStyle-CssClass="nodetail" /> 
		<asp:BoundField DataField="result" HeaderText="判决结果" SortExpression="result" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ItemStyle-Width="100px" ItemStyle-CssClass="nodetail" /> 
		<asp:BoundField DataField="resultreport" HeaderText="结案报告" SortExpression="resultreport" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ItemStyle-Width="100px" ItemStyle-CssClass="nodetail" />
		<asp:BoundField DataField="remark" HeaderText="备注" SortExpression="remark" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ItemStyle-Width="100px" ItemStyle-CssClass="nodetail" />  --%>
        <%--<asp:TemplateField HeaderText="&nbsp;"><ItemTemplate>&nbsp;</ItemTemplate></asp:TemplateField>--%>
    </Columns>
    </asp:GridView>
    </div>
    <div class="divpager">
        <asp:Label runat="server" ID="lblpager"></asp:Label>
    </div>
    <div id="divdetail"><walker:popover runat="server" ID="mypopover" poptitle="案件详情" /></div>
    </div>
    </form>
</body>
<script src="/js/ca/WdatePicker.js" type="text/javascript"></script>
<script type="text/javascript">
    var delflag = 0;
    function checkQuery() { if ($(".selected").length == 0) { alert("请选择一条记录"); return false; }if (!auth()) {alert("无权限");return false;}   if(!confirm("删除案件会自动删除关联的文件，确认删除？"))return false; return deldocs(); }
    function auth(o) {
        var caseinfo, uinfo;
        if (o) caseinfo = $(o).parents("tr").find(".GVcbx").val().split("|");
        else caseinfo = $(".selected").find(".GVcbx").val().split("|");
        uinfo = $("#hiduinfo").val().split("|");
        if (caseinfo[1] != uinfo[0]) { //不是本人数据
            if (caseinfo[2] != uinfo[1]) { //不是本部门数据
                if (uinfo[2] != "0") {//不是管理员
                    return false;
                }
            }
            else {
                if (uinfo[2] != "1" || uinfo[2] != 0) {//是本部门数据，但不是部门负责人，也不是管理员
                    return false;
                }
            }
        }
        return true;
    }
    //删除单个文件
    function deldoc(obj, id, caseid, field) {
        if(!auth(obj)) alert("无权限");
        if (!confirm("确认删除？")) return;
        //ajax删除文件
        $.get("ajaxHandler.aspx", { act: "delcasefile", t: new Date().getMilliseconds(), id: id, caseid: caseid, field: field }, function (d) {
            if (d == "1") {
                $(obj).closest("td").html("尚未上传");
            } else { alert("删除失败"); }
        });
    }
    //删除案件下所有文件
    function deldocs() {
        if (!auth()) return;
        var docs = $(".selected .afordel");
        if (docs.length == 0) {
            //没有需要删除的文件，直接删除记录
            __doPostBack("btnDel", "");
            return;
        }
        delflag = 0;
        var inner = "<div id='delinfo' style='margin:20px'>案件关联文件删除记录：</div>";
        var deldlg = new $.dialog({ id: "dg07", title: '删除文件', html: inner, resize: false, width: 550, height: 380, cover: true, rang: true, cancelBtn: false });
        deldlg.ShowDialog();
        var info = $(top.window.document).find("#delinfo");
        docs.each(function (i, m) {
            deldocseq(info, $(m).data("docid"), $(m).data("caseid"),$(m).data("field"), getDocname($(m).data("field")));
        });
        var m;
        m = setInterval(function () { if (delflag == docs.length) clearInterval(m); info.append("<br/><p>关联文件已全部删除，正在删除案件资料...</p>"); setTimeout(function () { __doPostBack('btnDel', ''); }, 8000) }, 1000);
    }
    function getDocname(field){
        switch (field) {
            case "detail":
                return "案件详情";
            case "analysis":
                return "诉讼分析报告";
            case "evidence":
                return "证据材料";
            case "opinion":
                return "质证意见";
            case "quote":
                return "代理意见";
            case "result":
                return "判决结果";
            case "qisu":
                return "起诉状";
            case "taolun":
                return "案件讨论记录";
            case "tiwen":
                return "法庭提问";
            case "dabian":
                return "答辩意见";
            default:
            return "结案报告";
        
        }
    }
    function deldocseq(obj, docid, caseid, field, docname) {
        $(obj).append("<p>正在删除" + docname + "...</p>");
        $.get("ajaxHandler.aspx", { act: "delcasefile", t: new Date().getMilliseconds(), id: docid, caseid: caseid, field: field }, function (d) {
            if (d == "1") {
                $(obj).append("<p>" + docname + "已删除.</p>");
            } else {
                $(obj).append("<p>" + docname + "删除失败，或文件不存在.</p>");
            } //不处理删除失败的情况
            delflag++;
        });
    }
    $(function () {
        if ($(".tree2 .curli", top.document).index() != 0) {
            $(".curli", top.document).removeClass("curli");
            $(".tree2 a", top.document).eq(0).addClass("curli");
        }
        if ($(".curnav", top.document).index() != 1) {
            $(".curnav", top.document).removeClass("curnav");
            $("#navMenu .menulv1", top.document).eq(1).addClass("curnav");
        }
    });
</script>
</html>
