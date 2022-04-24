<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alumno.aspx.cs" Inherits="Lab2.Alumno.Alumno1" %>

<%@ Register Src="~/UsuariosOnline.ascx" TagPrefix="uc1" TagName="UsuariosOnline" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="VerTareasEstudiante.aspx">Tareas Genéricas</a><br />
            <a href="#">Tareas Propias</a><br />
            <a href="#">Grupos</a><br />
        </div>
        </br>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Cerrar Sesion</asp:LinkButton>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <uc1:UsuariosOnline runat="server" ID="UsuariosOnline" />
        </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
