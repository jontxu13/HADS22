<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportarXML.aspx.cs" Inherits="Lab2.Profesor.ImportarXML" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Profesor: Importar de tareas genéricas</h1>
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigoAsig" DataValueField="codigoAsig" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hadsConnectionString %>" SelectCommand= "SELECT [codigoAsig] FROM [GrupoClase] INNER JOIN [ProfesorGrupo] ON GrupoClase.codigo = ProfesorGrupo.codigoGrupo WHERE ([email] = @email)">
            <SelectParameters>
                <asp:SessionParameter Name="email" SessionField="user" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        
        <asp:Xml ID="Xml1" runat="server"></asp:Xml>
            			<p>
					<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Importar tareas" />
				</p>
        <p>
            <asp:Label ID="error" runat="server" Text=""></asp:Label>
        </p>
        <a href="../Profesor/Profesor.aspx">Volver</a><br />
        </br>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Cerrar Sesion</asp:LinkButton>
    </form>
</body>
</html>
