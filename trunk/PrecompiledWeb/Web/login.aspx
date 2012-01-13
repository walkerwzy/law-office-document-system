<%@ page language="C#" autoeventwireup="true" inherits="login, App_Web_j3cfvcxm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>湖南炜弘律师事务所管理系统</title>
    <style type="text/css">
        body {margin-left: 0px;margin-top: 0px;margin-right: 0px;margin-bottom: 0px;background-color: #016aa9;overflow:hidden;}
        .STYLE1 {color: #000000;font-size: 12px;}
        #maintable{ position:absolute; top:50%; margin-top:-260px; left:50%; margin-left:-481px;}
    </style>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="lbtnlogin">
<table width="962" border="0" align="center" cellpadding="0" cellspacing="0" id="maintable">
      <tr>
        <td height="235" background="images/login/login_03.gif">&nbsp;</td>

      </tr>
      <tr>
        <td height="53"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="394" height="53" background="images/login/login_05.gif">&nbsp;</td>
            <td width="206" background="images/login/login_06.gif"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="16%" height="25"><div align="right"><span class="STYLE1">用户</span></div></td>

                <td width="57%" height="25"><div align="center">
                  <asp:TextBox ID="txtusername" runat="server" style="width:105px; height:17px; background-color:#292929; border:solid 1px #7dbad7; font-size:12px; color:#6cd0ff" MaxLength="20"></asp:TextBox>
                </div></td>
                <td width="27%" height="25">&nbsp;</td>
              </tr>
              <tr>
                <td height="25"><div align="right"><span class="STYLE1">密码</span></div></td>
                <td height="25"><div align="center">
                  <asp:TextBox runat="server" ID="txtpwd" MaxLength="20" TextMode="Password" style="width:105px; height:17px; background-color:#292929; border:solid 1px #7dbad7; font-size:12px; color:#6cd0ff;"></asp:TextBox>
                </div></td>
                <td height="25"><div align="left"><asp:ImageButton ImageUrl="images/login/dl.gif" runat="server" ID="lbtnlogin" OnClick="loginclick" /></div></td>
              </tr>
            </table></td>
            <td width="362" background="images/login/login_07.gif">&nbsp;</td>
          </tr>
        </table></td>
      </tr>

      <tr>
        <td height="213" background="images/login/login_08.gif">&nbsp;</td>
      </tr>
    </table>
    </form>
</body>
</html>
