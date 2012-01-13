<%@ page language="C#" autoeventwireup="true" inherits="officeedit, App_Web_j3cfvcxm" validaterequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/css/public.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="/js/editor/themes/default/default.css" />
<style type="text/css">
    .hdiv{display:none;}    
</style>
<script type="text/javascript" src="/js/jquery-1.6.2.min.js"></script>
<script type="text/javascript" charset="utf-8" src="/js/editor/kindeditor-min.js"></script>
<script type="text/javascript" charset="utf-8" src="/js/editor/lang/zh_CN.js"></script>
<script type="text/javascript">
    var thisdg = frameElement.lhgDG;
    thisdg.addBtn('btnClose', '取消', function () { top.popAction(false); thisdg.cancel(); });
    thisdg.addBtn('btnOk', '修改', function () { if (checkQuery()) $("#btnupdate").click(); });
    var editor1, editor2, editor3;
    KindEditor.ready(function(K) {
            editor1 = K.create('#txtzongzhi', {
            width: "100%",
            height:"320px",
		    resizeType : 1,
		    allowPreviewEmoticons : false,
		    allowImageUpload: false,
		    items : [
			    'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
			    'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
			    'insertunorderedlist', '|', 'emoticons', 'image', 'link']
		});
		editor2 = K.create('#txtzhanlue', {
		    width: "100%",
		    height: "320px",
		    resizeType: 1,
		    allowPreviewEmoticons: false,
		    allowImageUpload: false,
		    items: [
			    'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
			    'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
			    'insertunorderedlist', '|', 'emoticons', 'image', 'link']
		});
		editor3 = K.create('#txtzhidu', {
		    width: "100%",
		    height: "320px",
		    resizeType: 1,
		    allowPreviewEmoticons: false,
		    allowImageUpload: false,
		    items: [
			    'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
			    'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
			    'insertunorderedlist', '|', 'emoticons', 'image', 'link']
		});
});
$(function () {
    $(".div" + $("#hidtype").val()).removeClass("hdiv");
});
function checkQuery() {
    editor1.sync();
    editor2.sync();
    editor3.sync();
    thisdg.dg.style.display = "none";
    top.popAction(true);
    return true;
}
</script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField runat="server" ID="hidtype"  Value="1"/>
    <div>
        <div class="div1 hdiv"><asp:TextBox runat="server" ID="txtzongzhi" TextMode="MultiLine" style="visibility:hidden;"></asp:TextBox></div>
        <div class="div2 hdiv"><asp:TextBox runat="server" ID="txtzhanlue" TextMode="MultiLine" style="visibility:hidden;"></asp:TextBox></div>
        <div class="div3 hdiv"><asp:TextBox runat="server" ID="txtzhidu" TextMode="MultiLine" style="visibility:hidden;"></asp:TextBox></div>
    <div style="display:none;">
        <asp:Button runat="server" ID="btnupdate" OnClick="upentry" />
    </div>
    </div>
    </form>
</body>
</html>
