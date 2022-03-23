<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExportarTareas.aspx.cs" Inherits="Lab2.Profesor.ExportarTareas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Profesor: Importar de tareas genéricas</h1>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hadsConnectionString %>" SelectCommand= "SELECT [codigoAsig] FROM [GrupoClase] INNER JOIN [ProfesorGrupo] ON GrupoClase.codigo = ProfesorGrupo.codigoGrupo WHERE ([email] = @email)">
            <SelectParameters>
                <asp:SessionParameter Name="email" SessionField="user" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            			<p>
					<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Exportar tareas XML" />
				</p>
        <p>
            <asp:Label ID="error" runat="server" Text=""></asp:Label>
        </p>
        <a href="Profesor.aspx">Volver</a><br />
        </br>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Cerrar Sesion</asp:LinkButton>
    </form>
</body>
</html>
