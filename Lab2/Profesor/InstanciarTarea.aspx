<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstanciarTarea.aspx.cs" Inherits="Lab2.InstanciarTarea" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #txtDes {
            width: 267px;
            height: 46px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Profesor: Gestión de tareas genéricas</h1>
        </div>
        <p>Código</p>
        <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
        <p>Descripción</p>
        <textarea id="txtDes"></textarea>
        <p>Asignatura</p>
        <asp:DropDownList ID="dplAsignatura" runat="server"></asp:DropDownList>
        <p>Horas Estimadas</p>
        <asp:TextBox ID="txtHestimadas" runat="server"></asp:TextBox>
        <p>Tipo tarea</p>
        <asp:DropDownList ID="dplTipoTarea" runat="server"></asp:DropDownList>
        </br>
        </br>
        <asp:Button ID="btnAñadir" runat="server" Text="Añadir Tarea" OnClick="btnAñadir_Click" />
        </br>
        </br>
        <a href="GestionarTareas.aspx">Ver Tareas</a><br />
    </form>
</body>
</html>
