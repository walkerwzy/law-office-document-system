<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_add.aspx.cs" Inherits="user_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/public.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
            <tr>
                <td class="tdbg">
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td height="25" width="30%" align="right">
                                角色 ：
                            </td>
                            <td height="25" width="*" align="left">
                                <asp:DropDownList runat="server" ID="ddlrole" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="30%" align="right">
                                部门 ：
                            </td>
                            <td height="25" width="*" align="left">
                                <asp:DropDownList runat="server" ID="ddldept" Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="30%" align="right">
                                用户状态 ：
                            </td>
                            <td height="25" width="*" align="left">
                                <asp:DropDownList runat="server" ID="ddlstat" Width="150px">
                                    <asp:ListItem Text="正常" Value="1" />
                                    <asp:ListItem Text="禁用" Value="0" />
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="30%" align="right">
                                用户名 ：
                            </td>
                            <td height="25" width="*" align="left">
                                <asp:TextBox ID="txtusername" runat="server" Width="200px" CssClass="tinput"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="30%" align="right">
                                用户密码 ：
                            </td>
                            <td height="25" width="*" align="left">
                                <asp:TextBox ID="txtpassword" runat="server" Width="200px" CssClass="tinput" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="30%" align="right">
                                重输一次 ：
                            </td>
                            <td height="25" width="*" align="left">
                                <asp:TextBox ID="txtpassword2" runat="server" Width="200px" CssClass="tinput" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="30%" align="right">
                                真实姓名 ：
                            </td>
                            <td height="25" width="*" align="left">
                                <asp:TextBox ID="txtdisplayname" runat="server" Width="200px" CssClass="tinput"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="30%" align="right">
                                备注 ：
                            </td>
                            <td height="25" width="*" align="left">
                                <asp:TextBox ID="txtremark" runat="server" Width="200px" CssClass="tinput"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="display: none;">
                <td class="tdbg" align="center" valign="bottom">
                    <asp:LinkButton ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click"></asp:LinkButton>
                    <asp:LinkButton ID="btnCancle" runat="server" Text="取消" OnClick="btnCancle_Click"></asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
<script type="text/javascript" src="/js/jquery-1.8.2.min.js"></script>
<script type="text/javascript">
    var thisdg = frameElement.lhgDG;
    thisdg.addBtn('btnClose', '取消', function () { top.popAction(false); thisdg.cancel(); });
    thisdg.addBtn('btnClear', '清空', function () { __doPostBack('btnCancle', ''); });
    thisdg.addBtn('btnOk', '添加', function () { if (checkQuery()) __doPostBack('btnSave', ''); });
    function checkQuery() {
        if ($.trim($("#txtusername").val()) == "") { alert("用户名不能为空"); return false; }
        if (!/[0-9a-zA-z]{6,20}/.test($.trim($("#txtpassword").val()))) { alert("密码应为6-20位字母和数字"); return false; }
        if ($.trim($("#txtpassword2").val()) != $.trim($("#txtpassword").val())) { alert("密码输入不一致"); return false;}
        if ($.trim($("#txtdisplayname").val()) == "") { alert("真实姓名不能为空"); return false;}
        thisdg.dg.style.display = "none";
        top.popAction(true);
        return true;
    }
</script>
</html>
