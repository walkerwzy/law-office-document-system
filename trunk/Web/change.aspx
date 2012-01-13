<%@ Page Language="C#" AutoEventWireup="true" CodeFile="change.aspx.cs" Inherits="change" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/css/public.css" rel="stylesheet" type="text/css" />
    <link href="/css/main.css" rel="stylesheet" type="text/css" />
    <link href="/js/autoComplete/default.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #tree{margin:10px;}
        .tbchangecust td{ vertical-align:top;}
        .tdleft{padding-left:20px;}
        .hd-img{display:inline-block; width:15px; height:15px; background:url(images/jiahao.gif) 0 0 no-repeat;}
        .hd-img.clapse{background-image:url(images/jianhao.gif);}
        .cnode{margin-left:30px;}
        .childlist{display:none;}
    </style>
</head>
<body>
    <form id="form1" runat="server">&nbsp;
    <div id="tree">
    <table class="tbchangecust">
        <tr>
            <td class="tdleft" width="300">
    将下列客户：
        <ul>
            <asp:Repeater ID="rpt" runat="server" OnItemDataBound="addSubNode">
                <ItemTemplate>
                    <li class="pnode" data-id='<%# Eval("deptid") %>'>
                        <span class="hd-img"></span><input type="checkbox" id='root-<%# Eval("deptid") %>' class="cbxroot" /><label for='root-<%# Eval("deptid") %>'><%# Eval("deptname") %></label>
                        <ul class="childlist">
                            <asp:Repeater ID="rpt1" runat="server">
                                <ItemTemplate>
                                    <li class="cnode" data-id='<%# Eval("custid") %>'><input type="checkbox" id='cn-<%# Eval("custid") %>' name="suser" class="cbxchild" value='<%# Eval("custid") %>' /><label for='cn-<%# Eval("custid") %>'><%# Eval("custname") %></label></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
            </td>
            <td>
                转移给用户：<asp:TextBox runat="server" ID="txtuid" class="tinput" Width="200px"></asp:TextBox>
                <asp:HiddenField ID="hiduid" runat="server" />
                <asp:Button runat="server" ID="btnSave" Text="确定" OnClick="changerela" class="btn1" OnClientClick="return checkQuery();" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
<script type="text/javascript" src="/js/jquery-1.6.2.min.js"></script>
<script src="/js/autoComplete/autoComplete.js" type="text/javascript"></script>
<script type="text/javascript">
    var thisdg = frameElement.lhgDG;
    $(function () {
        $("#txtuid").autoCmpt({ url: "ajaxHandler.aspx?act=getuser", width: 200, hidden: $("#hiduid")});
        $(".hd-img").click(function () {
            $(this).toggleClass("clapse");
            var ul = $(this).parent("li");
            $(".childlist", ul).slideToggle();
        });
        $(".cbxroot").change(function () {
            var pli = $(this).parent("li");
            var f = $(this).prop("checked");
            $(".cbxchild", pli).prop("checked", f);
        });
        $(".cbxchild").change(function () {
            var pcbx = $(this).parents(".pnode").find(".cbxroot");
            var lis = $(this).parents(".childlist").find(":checkbox");
            pcbx.prop("checked", lis.length == lis.filter(":checked").length);
        });
    });
    thisdg.addBtn('btnClose', '取消', function () { top.popAction(false); thisdg.cancel(); });
    thisdg.addBtn('btnOk', '确定', function () { if (checkQuery()) $('#btnSave').click(); });
    function checkQuery() {
        if ($(".cbxchild:checked").length == 0) { alert("未选择客户"); return false; }
        if ($.trim($("#txtuid").val()) == "") { alert("未选择系统用户");return false ; }
        if ($("#hiduid").val() == "-1") {alert("无效的系统用户，请重新选择");return false;}
        return true;
    }
</script>
</html>
