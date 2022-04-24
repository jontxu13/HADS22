<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Lab2.Registro1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            REGISTRO DE USUARIOS
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                                Email:
                      <asp:TextBox ID="txtEmail" runat="server" AutoPostBack="True" OnTextChanged="txtEmail_TextChanged"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Formato de email incorrecto" ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <asp:Label ID="txtMatriculado" runat="server"></asp:Label>
                                <br />
                              Nombre: 
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombre" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            <br />
            Apellidos:
            <asp:TextBox ID="txtApellidos" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtApellidos" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            <br />
            Password:
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="Mínimo 6 carácteres" ForeColor="#FF3300" ValidationExpression="^.{6,}$"></asp:RegularExpressionValidator>
            <br />
            Repetir Psw:
            <asp:TextBox ID="txtRepPass" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtRepPass" ErrorMessage="*" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ErrorMessage="Las contraseñas no coinciden" ForeColor="#FF3300" ControlToValidate="txtRepPass"></asp:CompareValidator>
            <br />
            <br />
            Rol:<asp:RadioButtonList ID="rdbtnRol" runat="server">
                <asp:ListItem>Alumno</asp:ListItem>
                <asp:ListItem>Profesor</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="rdbtnRol" ErrorMessage="Seleccione rol." ForeColor="#FF3300"></asp:RequiredFieldValidator>
&nbsp;<br /> </div>
        &nbsp;<asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click1" />
                </ContentTemplate>
            </asp:UpdatePanel>

        <p>
            <asp:Label ID="error" runat="server" ForeColor="#FF3300"></asp:Label>
        </p>
    </form>
</body>
</html>
