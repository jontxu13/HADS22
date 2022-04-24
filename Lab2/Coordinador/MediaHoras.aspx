<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MediaHoras.aspx.cs" Inherits="Lab2.Coordinador.MediaHoras" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:hadsConnectionString %>" SelectCommand="SELECT [codigo] FROM [Asignatura]"></asp:SqlDataSource>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigo" DataValueField="codigo" Height="31px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br />
                    La media de horas en
                    <asp:Label ID="lblAsig" runat="server"></asp:Label>
                    &nbsp;es:<br />
                    <asp:Label ID="lblMedia" runat="server"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
