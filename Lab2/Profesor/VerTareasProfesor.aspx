<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerTareasProfesor.aspx.cs" Inherits="Lab2.Profesor.VerTareasProfesor1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Profesor: Gestión de tareas genéricas</h1>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="codigoAsig" DataValueField="codigoAsig">
                </asp:DropDownList>
                        <br />
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource2" Width="738px" DataKeyNames="codigo" AutoGenerateEditButton="True">
            <Columns>
                <asp:BoundField DataField="codigo" HeaderText="codigo" SortExpression="codigo" ReadOnly="True" />
                <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                <asp:BoundField DataField="codAsig" HeaderText="codAsig" SortExpression="codAsig" />
                <asp:BoundField DataField="hEstimadas" HeaderText="hEstimadas" SortExpression="hEstimadas" />
                <asp:CheckBoxField DataField="explotacion" HeaderText="explotacion" SortExpression="explotacion" />
                <asp:BoundField DataField="tipoTarea" HeaderText="tipoTarea" SortExpression="tipoTarea" />
            </Columns>
        </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hadsConnectionString %>" SelectCommand= "SELECT [codigoAsig] FROM [GrupoClase] INNER JOIN [ProfesorGrupo] ON GrupoClase.codigo = ProfesorGrupo.codigoGrupo WHERE ([email] = @email)">
            <SelectParameters>
                <asp:SessionParameter Name="email" SessionField="user" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        

                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:hadsConnectionString %>" SelectCommand="SELECT [codigo], [descripcion], [codAsig], [hEstimadas], [explotacion], [tipoTarea] FROM [TareaGenerica] WHERE ([codAsig] = @codAsig)" UpdateCommand="UPDATE TareaGenerica SET codigo = @codigo, descripcion = @descripcion, codAsig = @codAsig, hEstimadas = @hEstimadas, explotacion = @explotacion, tipoTarea = @tipoTarea WHERE codigo = @codigo">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownList1" Name="codAsig" PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="codigo" />
                        <asp:Parameter Name="descripcion" />
                        <asp:Parameter Name="codAsig" />
                        <asp:Parameter Name="hEstimadas" />
                        <asp:Parameter Name="explotacion" />
                        <asp:Parameter Name="tipoTarea" />
                    </UpdateParameters>
                </asp:SqlDataSource>
    			<p>
					<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Insertar nueva tarea" />
				</p>
        <p>
            &nbsp;</p>
        <a href="Profesor.aspx">Volver</a><br />
        </br>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Cerrar Sesion</asp:LinkButton>
    </form>
</body>
</html>
