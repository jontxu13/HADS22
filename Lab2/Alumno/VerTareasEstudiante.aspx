<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerTareasEstudiante.aspx.cs" Inherits="Lab2.VerTareasEstudiante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigo" DataValueField="codigo" AutoPostBack="True">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hadsConnectionString %>" SelectCommand= "SELECT Asignatura.codigo FROM Asignatura INNER JOIN GrupoClase ON Asignatura.codigo = GrupoClase.codigoAsig INNER JOIN EstudianteGrupo ON  GrupoClase.codigo = EstudianteGrupo.grupo WHERE (EstudianteGrupo.email = @email)">
            <SelectParameters>
                <asp:SessionParameter Name="email" SessionField="user" />
            </SelectParameters>
        </asp:SqlDataSource>
        
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource2" Width="738px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="codigo">
            <Columns>
                <asp:CommandField ButtonType="Button" HeaderText="Instanciar" SelectText="Instanciar" ShowSelectButton="True" />
                <asp:BoundField DataField="codigo" HeaderText="codigo" SortExpression="codigo" ReadOnly="True" />
                <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                <asp:BoundField DataField="hEstimadas" HeaderText="hEstimadas" SortExpression="hEstimadas" />
                <asp:BoundField DataField="tipoTarea" HeaderText="tipoTarea" SortExpression="tipoTarea" />
            </Columns>
        </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:hadsConnectionString %>" SelectCommand="SELECT [codigo], [descripcion], [hEstimadas], [tipoTarea] FROM [TareaGenerica] WHERE ([codAsig] = @codAsig)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownList1" Name="codAsig" PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
    </form>
</body>
</html>
