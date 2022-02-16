<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="Lab2.Welcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Hola señorit@
            <asp:Label ID="labelEmail" runat="server"></asp:Label>
            !</div>
        <p>
            <asp:Button ID="btnSalir" runat="server" OnClick="btnSalir_Click" Text="Salir" />
        </p>
    </form>
</body>
</html>
