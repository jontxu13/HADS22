<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerTareasEstudiante.aspx.cs" Inherits="Lab2.Alumno.VerTareasEstudiante1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Alumno: Gestión de tareas genéricas</h1>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" ></asp:DropDownList>
        </br>
        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
            <Columns>
                <asp:CommandField showselectbutton="true"
            selecttext="Instanciar" ButtonType="Button"/>
            </Columns>
        </asp:GridView>
        </br>
        <a href="Alumno.aspx">Volver</a><br />
        </br>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Cerrar Sesion</asp:LinkButton>
    </form>
    
</body>
</html>
