<%@ Page Language="C#" AutoEventWireup="true" CodeFile="employee.aspx.cs" Inherits="employee" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/css/public.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
     body{background:#fff; overflow:hidden;}
	#whyg{border-collapse:collapse; font-size:12px; margin-top:15px;}
	#whyg, #whyg td{border:1px solid #888;}
	#whyg td{height:24px; line-height:24px; padding:5px 8px;overflow:hidden;}
	#whyg td input,#whyg td textarea{border:none;}
	.tanoborder{ width:100%; height:120px; overflow-x:hidden; overflow-y:auto;}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left:10px;">
    <br />
    <span style="color:Gray;">照片请用图片工具处理成120*140或同比率的图片再上传，支持gif,jpg,png格式图片</span>
        <table id="whyg" align="center">
        <colgroup>
            <col width="100px" />
            <col width="120px" />
            <col width="100px" />
            <col width="120px" />
            <col width="140px" />
        </colgroup>
        <tr><td>姓名：</td><td><asp:Label runat="server" ID="lblname"></asp:Label></td><td>性别：</td><td><asp:DropDownList Width="80px" runat="server" ID="ddlsex"><asp:ListItem>男</asp:ListItem><asp:ListItem>女</asp:ListItem></asp:DropDownList></td><td rowspan="4"><img src='<%=photourl %>' alt="" width="120" height="140" /></td></tr>
        <tr><td>户籍：</td><td><asp:TextBox runat="server" ID="txthuji"></asp:TextBox></td><td>从业执照号：</td><td><asp:TextBox runat="server" ID="txtcertno"></asp:TextBox></td></tr>
        <tr><td>出生日期：</td><td><asp:TextBox runat="server" ID="txtbirthday"  onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});"></asp:TextBox></td><td>民族：</td><td><asp:TextBox runat="server" ID="txtrace"></asp:TextBox></td></tr>
        <tr><td>入职时间：</td><td><asp:TextBox runat="server" ID="txtruzhi"  onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});"></asp:TextBox></td><td>转正时间：</td><td><asp:TextBox runat="server" ID="txtzhuanzheng"  onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});"></asp:TextBox></td></tr>
        <tr><td>办保险时间：</td><td><asp:TextBox runat="server" ID="txtbaoxian"  onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});"></asp:TextBox></td><td>离职时间：</td><td><asp:TextBox runat="server" ID="txtlizhi"  onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});"></asp:TextBox></td>
        <td><asp:FileUpload ID="fu" runat="server" Width="130px" /></td></tr>
        <tr><td valign="top">家庭成员：</td><td colspan="4">
        <asp:TextBox runat="server" ID="txtfamily" CssClass="tanoborder" TextMode="MultiLine"></asp:TextBox></td></tr>
        <tr><td valign="top">个人简介：</td><td colspan="4">
        <asp:TextBox runat="server" CssClass="tanoborder" ID="txtsummary" TextMode="MultiLine"></asp:TextBox></td>
        </tr>
        </table>
        <div style="display:none;">
            <asp:LinkButton ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click"></asp:LinkButton>
            <asp:LinkButton ID="btnCancle" runat="server" Text="取消" OnClick="btnCancle_Click"></asp:LinkButton>
        </div>
    </div>
    </form>
</body>
<script src="/js/ca/WdatePicker.js" type="text/javascript"></script>
<script type="text/javascript" src="/js/jquery-1.6.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="/js/editor/kindeditor-min.js"></script>
<script type="text/javascript">
    var thisdg = frameElement.lhgDG;
    thisdg.addBtn('btnClose', '取消', function () { top.popAction(false); thisdg.cancel(); });
    thisdg.addBtn('btnOk', '保存', function () { if (checkQuery()) __doPostBack('btnSave', ''); });
    $(function () {

    });
    function checkQuery() {
        return true;
    }
</script>
</html>
