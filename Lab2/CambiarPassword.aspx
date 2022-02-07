<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambiarPassword.aspx.cs" Inherits="Lab2.CambiarPassword" %>

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
        </div>
        <p>
            <asp:Button ID="btnCambiarContraseña" runat="server" Text="Solicitar Cambiar contraseña" />
        </p>
        Pregunta:
        <span id="pregunta"></span>
        </br>
        </br>
        Respuesta:
        </br>
        <asp:TextBox ID="txtRespuesta" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRespuesta" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
&nbsp;<p>
            <asp:Button ID="btnModificar" runat="server" Text="Modificar Contraseña" /></p>
</body>
</html>


