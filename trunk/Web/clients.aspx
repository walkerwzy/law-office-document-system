<%@ Page Language="C#" AutoEventWireup="true" CodeFile="clients.aspx.cs" Inherits="clients" ValidateRequest="false" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<%--    <link href="/css/public.css?v=0" rel="stylesheet" type="text/css" />
    <link href="/css/main.css?v=1" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="/js/lhgdialog.min.js"></script>--%>
    <walker:header runat="server" ID="myheader" mytitle="客户管理" />
    <script type="text/javascript" src="/js/core.js?type=single&v=5"></script>
      
	<script type="text/javascript">
	    $(function () {
	        //添加
	        var dlgAdd = $("#btnAdd").dialog({ id: 'cdg01', title: '添加客户', page: 'cust_add.aspx?act=add&t=' + new Date().getMilliseconds() + '&url=' + location.pathname,
	            resize: true, width: 750, height: 480, cover: true, cancelBtn: false, rang: true
	        });
	        //高亮菜单fix
	        if ($(".tree2 .curli", top.document).index() != 2) {
	            $(".curli", top.document).removeClass("curli");
	            $(".tree2 a", top.document).eq(2).addClass("curli");
	        }
	        if ($(".curnav", top.document).index() != 1) {
	            $(".curnav", top.document).removeClass("curnav");
	            $("#navMenu .menulv1", top.document).eq(1).addClass("curnav");
	        }
	    });
	    //弹窗_编辑
	    function detail() {
	        if ($(".selected").length == 0) {
	            malert("请选择一位客户！");
	            return;
	        }
	        var auth = $(".selected :hidden").eq(1).val();
	        var id = $(".selected input:checked").val();
	        var dlg = new $.dialog({ id: "cdg02", title: '编辑客户资料', page: "cust_add.aspx?act=modify&auth="+auth+"&t=" + new Date().getMilliseconds() + "&id=" + id + "&url=" + location.href, resize: true, width: 750, height: 480, cover: true, rang: true, cancelBtn: false });
	        dlg.ShowDialog();
	    }
	    //判断是否有权限删除
	    function candel() {
	        if ($(".selected").length == 0) { malert("请选择一位客户！"); return false; }
	        if ($(".selected :hidden").eq(1).val() != "1") { malert("无权限"); return false; }
	        return true;
	    }
	    //签约历史窗口
	    function getContract() {
	        if ($(".selected").length == 0) {
	            malert("请选择一位客户！");
	            return;
	        }
	        var id = $(".selected input:checked").val();
	        var name = $(".selected .spcustname").attr("title");
	        //所有人都有权限来添加签约历史，一旦添加，该客户即与当前操作人员建立关联，与之前人员的关系即解除
	        var dlg = new $.dialog({ id: "cdg03", title: '签约记录', page: "contract.aspx?t=" + new Date().getMilliseconds() + "&id=" + id + "&name="+encodeURI(name)+"&url=" + location.href, resize: true, width: 750, height: 500, cover: true, rang: true, cancelBtn: false });
	        dlg.ShowDialog();
	    }
	    //转移客户
	    function change() {
	        var dlg = new $.dialog({ id: "cdg04", title: '转移客户', page: "change.aspx?t=" + new Date().getMilliseconds() + "&url=" + location.href, resize: true, width: 750, height: 500, cover: true, rang: true, cancelBtn: false });
	        dlg.ShowDialog();
	    }
	    //快速上传
	    function upload() {
	        if ($(".selected").length == 0) {
	            malert("请选择一位客户！");
	            return;
	        }
	        var id = $(".selected input:checked").val();
	        var dlg = new $.dialog({ id: "dg05", title: '快速上传文件', page: "quickupload.aspx?custid=" + id + "&t=" + new Date().getMilliseconds() + "&url=" + location.href, resize: false, width: 500, height: 360, cover: true, rang: true, cancelBtn: false });
	        dlg.ShowDialog();
	    }
	    //添加拜访记录
	    function addVisit() {
	        if ($(".selected").length == 0) {
	            malert("请选择一位客户！");
	            return;
	        }
	        var id = $(".selected input:checked").val();
	        var name = $(".selected .spcustname").attr("title");
	        var dlg = new $.dialog({ id: 'dg06', title: '添加拜访记录', page: 'visit_add.aspx?act=add&id=' + id + '&custname=' + name + '&t=' + new Date().getMilliseconds() + '&url=' + location.pathname,
	            resize: true, width: 550, height: 420, cover: true, cancelBtn: false, rang: true
	        });
	        dlg.ShowDialog();
	    }
	    //文档管理
	    function getDocs() {
	        if ($(".selected").length == 0) {
	            malert("请选择一位客户！");
	            return;
	        }
	        var id = $(".selected input:checked").val();
	        location.href = "/docs.aspx?custid=" + id + "&t=" + new Date().getMilliseconds()+"&f="+encodeURIComponent($("#hidquery").val());
        }
        //案件管理
        function getCases() {
            if ($(".selected").length == 0) {
                malert("请选择一位客户！");
                return;
            }
            var id = $(".selected input:checked").val();
            location.href = "/cases.aspx?custid=" + id + "&t=" + new Date().getMilliseconds() + "&f=" + encodeURIComponent($("#hidquery").val());
        }
	    //添加业务接收记录
        function addTaskLog() {
            if ($(".selected").length == 0) {
                malert("请选择一位客户！");
                return;
            }
            var id = $(".selected input:checked").val();
            var name = $(".selected .spcustname").attr("title");
            var dlg = new $.dialog({
                id: 'dg07',
                title: '添加业务接收记录-' + name,
                page: 'taskadd.aspx?act=add&custid=' + id + '&t=' + new Date().getMilliseconds() + '&url=' + location.pathname,
                resize: true,
                width: 650,
                height: 430,
                cover: true,
                cancelBtn: false,
                rang: true
            });
            dlg.ShowDialog();
        }
	    //查看业务接收记录
        function viewTaskLog() {
            if ($(".selected").length == 0) {
                malert("请选择一位客户！");
                return;
            }
            var id = $(".selected input:checked").val();
            var name = $(".selected .spcustname").attr("title");
            var dlg = new $.dialog({
                id: 'dg08',
                title: '业务接收记录-' + name,
                page: 'tasklist.aspx?act=view&custid=' + id + '&custname=' + encodeURI(name) + '&t=' + new Date().getMilliseconds() + '&url=' + location.pathname,
                resize: true,
                width: 650,
                height: 420,
                cover: true,
                cancelBtn: false,
                rang: true
            });
            dlg.ShowDialog();
        }
        </script>
</head>
<body>
<form id="form1" runat="server" defaultbutton="LinkButton1">
    <walker:navi runat="server" ID="mynavi" menu="clients" />
    <asp:HiddenField runat="server" ID="hidquery" />
    <asp:HiddenField runat="server" ID="hidbackaction" Value="0" />
	<div id="container" class="container">
    <div class="div_top container">
         <div class="nav breadcrumb">
          当前位置&nbsp;&nbsp;>&nbsp;&nbsp;客户管理
        </div>
        <!--简单过滤开始-->
        <div class="toolbar form-inline">
            <fieldset>
                <legend>查询条件</legend>
                <label>签约状态：<asp:DropDownList runat="server" ID="ddlqianyue" style="width:100px;"><asp:ListItem>签约客户</asp:ListItem><asp:ListItem>意向客户</asp:ListItem><asp:ListItem>未续约客户</asp:ListItem><asp:ListItem>全部</asp:ListItem></asp:DropDownList></label>
                <label>客户类别：<asp:DropDownList runat="server" ID="ddlcustcate" style="width:125px;"></asp:DropDownList></label>
                <label>签约时间：<asp:TextBox runat="server" ID="txtstime" CssClass="tinput shortTxt Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" style="width:80px!important;"></asp:TextBox></label>
                <label>至：<asp:TextBox runat="server" ID="txtetime" CssClass="tinput shortTxt Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" style="width:80px!important;"></asp:TextBox></label>
                <asp:DropDownList runat="server" ID="ddlnametype" style="width:140px;"><asp:ListItem>客户名称</asp:ListItem><asp:ListItem>法定代表人名称</asp:ListItem><asp:ListItem>负责人名称</asp:ListItem></asp:DropDownList>
                    ：
                <input type="text" id="txtcustname" class="tinput shortTxt input-small" runat="server" />
                <br />
                <label>收案日期：<input id="txtsdate" type="text" class="Wdate shortTxt" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd',doubleCalendar:'true',maxDate:'%y-{%M}-%d',onpicked:function(){$('#txteTime')[0].focus();}});" runat="server" style="width:80px!important;" /></label>
                <label>至：<input id="txtedate" type="text" class="Wdate shortTxt" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd',maxDate:'%y-%M-%d'});" runat="server" style="width:80px!important;" /></label>
                <%--<label>数据范围：<asp:DropDownList runat="server" ID="ddlrange" CssClass="input-small"><asp:ListItem>本人</asp:ListItem><asp:ListItem>本部门</asp:ListItem></asp:DropDownList></label>--%>&nbsp;&nbsp;
                    <%--<asp:Button runat="server" ID="LinkButton1" OnClientClick="return checkQuery();" Text="查询" OnClick="btnsearch" CssClass="btn1 btn btn-primary" />--%>
                    <div class="btn-group">
                    	<asp:LinkButton runat="server" ID="LinkButton1" OnClientClick="return checkQuery();" OnClick="btnsearch" CssClass="btn1 btn btn-primary"><i class="icon-search icon-white"></i> 查询</asp:LinkButton>
                    </div>
                <%--<label>
                对选定客户操作：--%>
                    <%--<div class="btn-group">
                        <%--<a href="javascript:void(0);" class="btn1 btn" id="btnHighQuery" onclick="detail();"><i class="icon-pencil"></i> 编辑</a>--%>
                        <%--<asp:Button runat="server" ID="btnDel" Text="删除" OnClick="delcust" OnClientClick="return candel();" CssClass="btn1 btn" />--%>
                        <%--<asp:LinkButton runat="server" ID="btnDel" OnClick="delcust" OnClientClick="return candel();" CssClass="btn1 btn"><i class="icon-trash"></i> 删除</asp:LinkButton>--%>
                        <%--<a href="javascript:void(0);" class="btn1 btn" id="A11" onclick="getCases();"><i class="icon-book"></i> 相关案件</a>--%>
                        <%--<a href="javascript:void(0);" class="btn1 btn" id="A12" onclick="getDocs();"><i class="icon-list"></i> 相关文档</a>--%>
                        <%--<a href="javascript:void(0);" class="btn1 btn" id="A13" onclick="getContract();"><i class="icon-list-alt"></i> 签约记录</a>--%>
                        <%--<a href="javascript:void(0);" class="btn1 btn" id="A14" onclick="addVisit();"><i class="icon-thumbs-up"></i> 拜访记录</a>--%>
                        <%--<a href="javascript:void(0);" class="btn1 btn" id="A15  " onclick="upload();"><i class="icon-upload"></i> 上传资料</a>--%>
                    <%--<div class="btn-group">
                        <a href="" class="btn"><i class="icon-thumbs-up"></i>业务接收</a>
                        <a href="" class="btn"><i class="icon-th"></i>接收记录</a>
                    </div>--%>
                <%--</label>--%>
                <div class="btn-group">
                  <button class="btn btn-success dropdown-toggle" data-toggle="dropdown"><i class=" icon-cog icon-white"></i> 操作 <span class="caret"></span></button>
                  <ul class="dropdown-menu">
                        <li><a href="javascript:void(0);" id="A5" onclick="detail();"><i class="icon-pencil"></i> 编辑</a></li>
                        <li><asp:LinkButton runat="server" ID="btnDel" OnClick="delcust" OnClientClick="return candel();"><i class="icon-trash"></i> 删除</asp:LinkButton></li>
                        <li class="divider"</li>
                        <li><a href="javascript:void(0);" id="A11" onclick="getCases();"><i class="icon-book"></i> 相关案件</a></li>
                        <li><a href="javascript:void(0);" id="A12" onclick="getDocs();"><i class="icon-list"></i> 相关文档</a></li>
                        <li><a href="javascript:void(0);" id="A13" onclick="getContract();"><i class="icon-list-alt"></i> 签约记录</a></li>
                        <li><a href="javascript:void(0);" id="A14" onclick="upload();"><i class="icon-upload"></i> 上传资料</a></li>
                        <li class="divider"></li>
                        <li><a href="javascript:viewTaskLog();"><i class="icon-th"></i> 业务接收记录</a></li>
                        <li><a href="javascript:addTaskLog();"><i class="icon-thumbs-up"></i> 添加业务记录</a></li>   
                  </ul>
                </div>
                <div class="btn-group">
                    <button class="btn btn-warning dropdown-toggle" data-toggle="dropdown"><i class=" icon-wrench icon-white"></i> 更多 <span class="caret"></span></button>
                    <ul class="dropdown-menu">
                        <li><a href="javascript:void(0);" id="btnAdd"><i class="icon-plus"></i> 添加客户</a></li>
                        <li><a href="javascript:void(0);" id="btnChange" onclick="change();"><i class="icon-random"></i> 转移客户</a></li>
                        <li class="divider"></li>
                        <li><a href="javascript:cprint();"><i class="icon-print"></i> 打印</a></li>
                        <li><asp:LinkButton runat="server" ID="lbtnexcel" OnClick="export"><i class="icon-share"></i> 导出</asp:LinkButton></li>
                    </ul>
                </div>
            </fieldset>
            <%--<table class="tab1">
                <tr>
                    <td valign="middle">签约状态：</td>
                    <td valign="top">
                        <div class="select" style="margin-right:5px;"><div><asp:DropDownList runat="server" ID="ddlqianyue"><asp:ListItem>签约客户</asp:ListItem><asp:ListItem>意向客户</asp:ListItem><asp:ListItem>未续约客户</asp:ListItem><asp:ListItem>全部</asp:ListItem></asp:DropDownList></div></div>
                    </td>
                    <td valign="middle">客户类别：</td>
                    <td valign="top">
                        <div class="select"><div><asp:DropDownList runat="server" ID="ddlcustcate"></asp:DropDownList></div></div>
                    </td>
                    <td valign="middle">签约时间：</td>
                    <td valign="top">
                        <asp:TextBox runat="server" ID="txtstime" CssClass="tinput shortTxt Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" style="width:80px!important;"></asp:TextBox>
                    </td>
                    <td valign="middle">至</td>
                    <td valign="top">
                        <asp:TextBox runat="server" ID="txtetime" CssClass="tinput shortTxt Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" style="width:80px!important;"></asp:TextBox>
                    </td>
                    <td valign="top">
                        <div class="select"><div><asp:DropDownList runat="server" ID="ddlnametype"><asp:ListItem>客户名称</asp:ListItem><asp:ListItem>法定代表人名称</asp:ListItem><asp:ListItem>负责人名称</asp:ListItem></asp:DropDownList></div></div>
                    </td>
                    <td valign="middle">：</td>
                    <td valign="top">
                        <input type="text" id="txtcustname" class="tinput shortTxt" runat="server" />
                    </td>
                    <td valign="middle">法定代表人：</td>
                    <td valign="top">
                        <input type="text" title="法定代表人" id="txtown" class="tinput shortTxt" runat="server" />
                    </td>
                    <td valign="middle">负责人：</td>
                    <td valign="top"><asp:TextBox runat="server" ID="txtcharge" CssClass="tinput shortTxt"></asp:TextBox></td>
                </tr>
            </table>--%>
        </div> 
        <%--<div class="toolbar">
            <table class="tab1">
                <tr>
                    <td>收案日期：</td>
                    <td>
                        <input id="txtsdate" type="text" class="Wdate shortTxt" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd',doubleCalendar:'true',maxDate:'%y-{%M}-%d',onpicked:function(){$('#txteTime')[0].focus();}});" runat="server" />至：
                        <input id="txtedate" type="text" class="Wdate shortTxt" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd',maxDate:'%y-%M-%d'});" runat="server" />
                    </td>
                    <td valign="middle">数据范围：</td>
                    <td valign="top">
                        <div class="select"><div><asp:DropDownList runat="server" ID="ddlrange"><asp:ListItem>本人</asp:ListItem><asp:ListItem>本部门</asp:ListItem></asp:DropDownList></div></div>
                    </td>
                <td valign="top">
                    <asp:Button runat="server" ID="LinkButton1" OnClientClick="return checkQuery();" Text="查询" OnClick="btnsearch" CssClass="btn1" />
                </td>
                <td valign="top">
                    <a href="javascript:void(0);" class="btn1" id="btnHighQuery">高级搜索</a>
                </td>
                <td valign="top">
                    <a href="javascript:void(0);" class="btn1" id="btnAdd">添加</a>
                </td>
                <td valign="top">
                    <a href="javascript:void(0);" class="btn1" id="btnChange" onclick="change();">转移客户</a>
                </td>
                <td valign="top">
                    <a href="javascript:cprint();" class="btn1">打印</a>
                </td>
                <td valign="top">
                    <asp:LinkButton runat="server" ID="lbtnexcel" OnClick="export" CssClass="btn1">导出</asp:LinkButton>
                </td>
                <td valign="middle">
                    对选定客户操作：
                </td>
                <td valign="top">
                    <a href="javascript:void(0);" class="btn1" id="btnHighQuery" onclick="detail();">编辑</a>
                </td>
                <td valign="top">
                    <asp:Button runat="server" ID="btnDel" Text="删除" OnClick="delcust" OnClientClick="return candel();" CssClass="btn1" />
                </td>
                <td valign="top">
                    <a href="javascript:void(0);" class="btn1" id="A11" onclick="getCases();">相关案件</a>
                </td>
                <td valign="top">
                    <a href="javascript:void(0);" class="btn1" id="A12" onclick="getDocs();">相关文档</a>
                </td>
                <td valign="top">
                    <a href="javascript:void(0);" class="btn1" id="A13" onclick="getContract();">签约记录</a>
                </td>
                <td valign="top">
                    <a href="javascript:void(0);" class="btn1" id="A14" onclick="addVisit();">拜访记录</a>
                </td>
                <td valign="top">
                    <a href="javascript:void(0);" class="btn1" id="A15  " onclick="upload();">上传资料</a>
                </td>
                </tr>
            </table>
        </div>--%>
        <!--简单过滤结束-->
        <%--<div class="fixheader" id="fixheader"></div>--%>
    </div>
    <div class="rightcontent" id="rightcontent">
    
            <asp:GridView ID="gridlist" runat="server" DataKeyNames="custid" AutoGenerateColumns="false" CssClass="table1 detailtb table table-condensed table-bordered" style="width:1150px;" OnRowDataBound="gvdatabind" GridLines="None" CellSpacing="-1" EnableViewState="True">
                    <Columns>
        <asp:TemplateField HeaderStyle-Width="20px" ItemStyle-Width="20px" ItemStyle-CssClass="nodetail">
            <HeaderTemplate><%--<input type="checkbox" id="cbxall" />--%></HeaderTemplate>
            <ItemTemplate>
                <input type="checkbox" class="GVcbx" value='<%# Eval("custid") %>' name="ids"/>
                <asp:HiddenField runat="server" ID="hiddetail" Value='<%# string.Format("<b>联系电话：</b>{0}<br /><b>联系地址：</b>{1}<br /><b>邮编：</b>{2}<br /><b>传真：</b>{3}<br /><b>电子邮箱：</b>{4}<br /><b>联系人：</b>{13}<br/><b>联系人电话：</b>{14}</br/><b>法定代表人电话：</b>{5}<br /><b>法定代表人QQ：</b>{6}<br /><b>法定代表人生日：</b>{11}<br/><b>负责人电话：</b>{7}<br /><b>负责人QQ：</b>{8}<br /><b>负责人生日：</b>{12}<br/><b>客户简介：</b>{9}<br /><b>备注：</b>",Eval("tel"),Eval("address"),Eval("post"),Eval("fax"),Eval("email"),Eval("ownertel"),Eval("ownerqq"),Eval("chargetel"),Eval("chargeqq"),Eval("summary"),Eval("remark"),
                (Eval("ownerbirth")==null||Eval("ownerbirth")==DBNull.Value)?"":(Convert.ToDateTime(Eval("ownerbirth")).ToString("yyyy-MM-dd")+"("+(Eval("lunar1").ToString()=="1"?"农历":"公历")+")"),
                (Eval("chargebirth")==null||Eval("chargebirth")==DBNull.Value)?"":(Convert.ToDateTime(Eval("chargebirth")).ToString("yyyy-MM-dd")+"("+(Eval("lunar2").ToString()=="1"?"农历":"公历")+")"),
                Eval("contact"),Eval("contel") ) %>' />
                <asp:HiddenField runat="server" ID="hidcandel" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="序号" HeaderStyle-Width="40px" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Left" DataField="recno" ItemStyle-CssClass="nodetail" />
        <asp:TemplateField HeaderText="客户名称" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="nodetail" HeaderStyle-Width="210px" ItemStyle-Width="210px">
            <ItemTemplate>
                <span title='<%# Eval("custname") %>' class="spcustname txtoverflow" style="width:210px;"><%# Helper.HelperString.cutString(Eval("custname").ToString(),15) %></span>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField HeaderText="客户编号" HeaderStyle-Width="70px" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Left" DataField="custno" />
        <asp:BoundField HeaderText="客户类别" HeaderStyle-Width="90px" ItemStyle-Width="90px" DataField="catename" />
        <asp:BoundField HeaderText="添加人" HeaderStyle-Width="70px" ItemStyle-Width="80px" DataField="displayname" />
		<%--<asp:BoundField DataField="pycode" HeaderText="pycode" SortExpression="pycode" ItemStyle-HorizontalAlign="Center"  />--%>
		<%--<asp:BoundField DataField="tel" HeaderText="单位/联系电话" SortExpression="tel" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px" ItemStyle-Width="100px"  />--%> 
        <%--<asp:TemplateField HeaderText="单位/联系地址" HeaderStyle-Width="140px" ItemStyle-Width="140px" ItemStyle-CssClass="nodetail">
            <ItemTemplate>
                <span title='<%# Eval("address") %>'><%# Helper.HelperString.cutString(Eval("address").ToString(),10) %></span>
            </ItemTemplate>
        </asp:TemplateField>--%>
		<%--<asp:BoundField DataField="fax" HeaderText="fax" SortExpression="fax" ItemStyle-HorizontalAlign="Center"  />--%> 
		<%--<asp:BoundField DataField="post" HeaderText="post" SortExpression="post" ItemStyle-HorizontalAlign="Center"  />--%> 
		<%--<asp:BoundField DataField="email" HeaderText="电子邮箱" SortExpression="email" ItemStyle-HorizontalAlign="Center"  HeaderStyle-Width="140px" ItemStyle-Width="140px" />--%> 
		<asp:BoundField DataField="owner" HeaderText="法定代表人" SortExpression="owner" ItemStyle-HorizontalAlign="Center"  HeaderStyle-Width="100px" ItemStyle-Width="100px"  /> 
		<%--<asp:BoundField DataField="ownertel" HeaderText="ownertel" SortExpression="ownertel" ItemStyle-HorizontalAlign="Center"  />--%> 
		<%--<asp:BoundField DataField="ownerqq" HeaderText="ownerqq" SortExpression="ownerqq" ItemStyle-HorizontalAlign="Center"  />--%> 
		<asp:BoundField DataField="charge" HeaderText="主要负责人" SortExpression="charge" ItemStyle-HorizontalAlign="Center"  HeaderStyle-Width="100px" ItemStyle-Width="100px" /> 
		<%--<asp:BoundField DataField="chargetel" HeaderText="负责人电话" SortExpression="chargetel" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="110px" ItemStyle-Width="110px"  />--%> 
		<%--<asp:BoundField DataField="chargeqq" HeaderText="负责人QQ" SortExpression="chargeqq" ItemStyle-HorizontalAlign="Center"  HeaderStyle-Width="90px" ItemStyle-Width="90px" />--%> 
		<asp:BoundField DataField="c_stime" HeaderText="签约日期"  ItemStyle-HorizontalAlign="Center"  HeaderStyle-Width="90px" ItemStyle-Width="90px" DataFormatString="{0:d}" /> 
		<asp:BoundField DataField="c_etime" HeaderText="截止日期"  ItemStyle-HorizontalAlign="Center"  HeaderStyle-Width="90px" ItemStyle-Width="90px" DataFormatString="{0:d}" /> 
		<asp:BoundField DataField="c_ctime" HeaderText="付款日期"  ItemStyle-HorizontalAlign="Center"  HeaderStyle-Width="90px" ItemStyle-Width="90px" DataFormatString="{0:d}" /> 
		<%--<asp:TemplateField HeaderText="快捷功能" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="nodetail" HeaderStyle-Width="160px" ItemStyle-Width="160px">
            <ItemTemplate>
                <a href="javascript:void(0);" onclick='getContract(<%# string.Format("{0},\"{1}\"",Eval("custid"), Eval("custname") )%>);'>签约记录</a>
                <a href="javascript:void(0);" onclick='addVisit(<%# string.Format("{0},\"{1}\"",Eval("custid"), Eval("custname") )%>);'>拜访记录</a>
                <a href="javascript:void(0);" onclick='upload(<%# Eval("custid") %>);'>上传资料</a>
            </ItemTemplate>
        </asp:TemplateField>--%>
        <%--<asp:TemplateField HeaderText=" "><ItemTemplate>&nbsp;</ItemTemplate></asp:TemplateField>--%>
    </Columns>
                </asp:GridView>
    </div>
    <div class="divpager">
        <webdiyer:aspnetpager id="AspNetPager1" runat="server" AlwaysShow="True" ShowCustomInfoSection="Right"
        width="100%" CustomInfoHTML="共<b> %RecordCount% </b>条记录 <b>%CurrentPageIndex%</b> / <b>%PageCount%</b>" 
            ShowMoreButtons="true" ShowDisabledButtons="true" FirstPageText="首页" LastPageText="尾页" PrevPageText="上页" NextPageText="下页"
            Direction="LeftToRight" CustomInfoStyle="text-align:right;"></webdiyer:aspnetpager>
    </div>
    <div id="divdetail"><walker:popover runat="server" ID="mypopover" poptitle="详细资料" /></div>
    </div>
        <asp:ObjectDataSource ID="ods" runat="server" 
            DataObjectTypeName="WZY.Model.CUSTOMER" DeleteMethod="Delete" 
            SelectMethod="GetPage" TypeName="WZY.DAL.CUSTOMER" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="custid" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:Parameter DefaultValue="1=1 order by custid desc" Name="strWhere" Type="String" />
                <asp:ControlParameter ControlID="AspNetPager1" PropertyName="CurrentPageIndex" DefaultValue="1" Name="pageindex" Type="Int32" />
                <asp:ControlParameter ControlID="AspNetPager1" PropertyName="PageSize" DefaultValue="10" Name="pagesize" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</body>
<script src="/js/ca/WdatePicker.js" type="text/javascript"></script>
<script type="text/javascript">
    function checkQuery() { return true; }
</script>
</html>
