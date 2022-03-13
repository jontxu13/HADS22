<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstanciarTarea.aspx.cs" Inherits="Lab2.Alumno.InstanciarTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
   <form id="form1" runat="server">
        <div>
            <h1>Alumno: Instanciar tarea génerica</h1>
        </div>
 <p>Usuario</p>
        <asp:TextBox ID="txtUsuario" runat="server" ReadOnly="True" Enabled="False"></asp:TextBox>
       <p>Tarea</p>
        <asp:TextBox ID="txtTarea" runat="server" ReadOnly="True" Enabled="False"></asp:TextBox>
        <p>Horas Estimadas</p>
        <asp:TextBox ID="txtHestimadas" runat="server" ReadOnly="True" Enabled="False"></asp:TextBox>
        <p>Horas Reales</p>
       <asp:TextBox ID="txtHreales" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtHreales" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
       </br>
       </br>
       <asp:Button ID="Button1" runat="server" Text="Crear Tarea" OnClick="Button1_Click"/>
       </br>
       </br>
       <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </br>
        <a href="VerTareasEstudiante.aspx">Página anterior</a><br />
       </br>
       <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Cerrar Sesion</asp:LinkButton>
    </form>
</body>
</html>
