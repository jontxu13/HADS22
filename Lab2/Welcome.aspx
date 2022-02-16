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
            Hola señorit@!<br />
            Estos son tus datos:<br />
            <br />
            Email:
            <asp:Label ID="labelEmail" runat="server"></asp:Label>
            <br />
            Nombre:
            <asp:Label ID="labelNombre" runat="server"></asp:Label>
            <br />
            Apellidos:
            <asp:Label ID="labelApellidos" runat="server"></asp:Label>
            <br />
            Numconfir:
            <asp:Label ID="labelNumconfir" runat="server"></asp:Label>
            <br />
            Tipo:
            <asp:Label ID="labelTipo" runat="server"></asp:Label>
            <br />
            Contraseña:
            <asp:Label ID="labelPass" runat="server"></asp:Label>
            <br />
            Codpass:
            <asp:Label ID="labelCodpass" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
