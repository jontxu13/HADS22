<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertarTarea.aspx.cs" Inherits="Lab2.Profesor.InsertarTarea1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Profesor: Gestión de tareas genéricas</h1>
        </div>
        <p>Código</p>
        <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
        <p>Descripción</p>
		<asp:TextBox ID="txtDes" runat="server" TextMode="MultiLine"></asp:TextBox>
        &nbsp;<p>Asignatura</p>
        <asp:DropDownList ID="dplAsignatura" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigoAsig" DataValueField="codigoAsig"></asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hadsConnectionString %>" SelectCommand="SELECT [codigoAsig] FROM [GrupoClase] INNER JOIN [ProfesorGrupo] ON GrupoClase.codigo = ProfesorGrupo.codigoGrupo WHERE ([email] = @email)">
			<SelectParameters>
				<asp:SessionParameter Name="email" SessionField="user" />
			</SelectParameters>
		</asp:SqlDataSource>
        <p>Horas Estimadas</p>
        <asp:TextBox ID="txtHestimadas" runat="server"></asp:TextBox>
        <p>Tipo tarea</p>
        <asp:DropDownList ID="dplTipoTarea" runat="server">
			<asp:ListItem>Laboratorio</asp:ListItem>
			<asp:ListItem>Examen</asp:ListItem>
			<asp:ListItem>Informe</asp:ListItem>
		</asp:DropDownList>
        </br>
        </br>
        <asp:Button ID="btnAñadir" runat="server" Text="Añadir Tarea" OnClick="btnAñadir_Click" />
        </br>
        </br>
        <a href="VerTareasProfesor.aspx">Ver Tareas</a><br />
        </br>
        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton1_Click">Cerrar Sesion</asp:LinkButton>
    </form>
</body>
</html>
