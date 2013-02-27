<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        a{margin:0 5px;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:LinkButton runat="server" ID="lbtndown" Text="download" OnClick="down"></asp:LinkButton>
    <asp:FileUpload ID="FileUpload_Img" runat="server" /><asp:Button runat="server" ID="btnupload" Text="upload" OnClick="up" />
    <asp:GridView ID="gv" runat="server"></asp:GridView>
    <asp:Label runat="server" ID="lblpager"></asp:Label>
    </div>
    </form>
</body>
</html>
