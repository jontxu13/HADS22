<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionarTareas.aspx.cs" Inherits="Lab2.VerTareasEstudiante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigoAsig" DataValueField="codigoAsig" AutoPostBack="True">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hadsConnectionString %>" SelectCommand= "SELECT [codigoAsig] FROM [GrupoClase] INNER JOIN [ProfesorGrupo] ON GrupoClase.codigo = ProfesorGrupo.codigoGrupo WHERE ([email] = @email)">
            <SelectParameters>
                <asp:SessionParameter Name="email" SessionField="user" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource2" Width="738px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="codigo">
            <Columns>
                <asp:CommandField HeaderText="Editar" SelectText="Editar" ShowSelectButton="True" />
                <asp:BoundField DataField="codigo" HeaderText="codigo" SortExpression="codigo" ReadOnly="True" />
                <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                <asp:BoundField DataField="codAsig" HeaderText="codAsig" SortExpression="codAsig" />
                <asp:BoundField DataField="hEstimadas" HeaderText="hEstimadas" SortExpression="hEstimadas" />
                <asp:CheckBoxField DataField="explotacion" HeaderText="explotacion" SortExpression="explotacion" />
                <asp:BoundField DataField="tipoTarea" HeaderText="tipoTarea" SortExpression="tipoTarea" />
            </Columns>
        </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:hadsConnectionString %>" SelectCommand="SELECT [codigo], [descripcion], [codAsig], [hEstimadas], [explotacion], [tipoTarea] FROM [TareaGenerica] WHERE ([codAsig] = @codAsig)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownList1" Name="codAsig" PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
    </form>
</body>
</html>
