<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profesor.aspx.cs" Inherits="Lab2.Profesor.Profesor1" %>

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
            <a href="#">Asignaturas</a><br />
            <a href="VerTareasProfesor.aspx">Tareas</a><br />
            <a href="#">Grupos</a><br />
            <a href="../Coordinador/ImportarXML.aspx">Importar v. XMLDocument</a><br />
            <a href="../Coordinador/ExportarTareas.aspx">Exportar</a><br />
            <a href="../Coordinador/MediaHoras.aspx">Ver media de horas</a><br />
            <a href="#">Importar v. DataSet</a><br />
        </div>
        </br>
        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton1_Click">Cerrar Sesion</asp:LinkButton>
                   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <uc1:UsuariosOnline runat="server" ID="UsuariosOnline" />
        </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
