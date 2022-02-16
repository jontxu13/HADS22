<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Lab2.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                <p>
        E-mail:
                    </br>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
    </p>
    <p>
        Password:
        </br>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
    </p>
    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                <br />
                <asp:Label ID="error" runat="server" ForeColor="#FF3300"></asp:Label>
                <br />
    <a href="Registro.aspx">Quiero registrarme</a><br />
    <a href="javascript:__doPostBack('LinkButton1','')">Modificar Contraseña</a></form>
        </div>
    </form>
</body>
</html>
