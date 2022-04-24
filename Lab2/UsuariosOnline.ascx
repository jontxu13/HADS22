<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UsuariosOnline.ascx.cs" Inherits="Lab2.UsuariosOnline" %>
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Timer ID="Timer1" runat="server" Interval="3000" OnTick="Timer1_Tick">
        </asp:Timer>
        <br />
        Usuarios online:
        <asp:Label ID="alumnos" runat="server" Text=""></asp:Label>
        &nbsp;Alumno/s y
        <asp:Label ID="profesores" runat="server" Text=""></asp:Label>
        &nbsp;Profesor/es
        <br />
        <br />
        <asp:ListBox ID="listAlumnos" runat="server"></asp:ListBox>
        <asp:ListBox ID="listProfesores" runat="server"></asp:ListBox>
    </ContentTemplate>
</asp:UpdatePanel>
<p>
    &nbsp;</p>

