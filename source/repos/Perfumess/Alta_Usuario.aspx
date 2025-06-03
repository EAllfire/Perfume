<%@ Page Title="Alta Usuario" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Alta_Usuario.aspx.cs" Inherits="Perfumes.AltaUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="perfume-card">
    <h2>Registrar Nuevo Usuario</h2>
    <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre" /><br />
    <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" /><br />
    <asp:TextBox ID="txtPassword" runat="server" placeholder="Contraseña" TextMode="Password" /><br />
    <asp:DropDownList ID="ddlTipo" runat="server">
        <asp:ListItem Text="Cliente" Value="Cliente" />
        <asp:ListItem Text="Administrador" Value="Administrador" />
    </asp:DropDownList><br />
    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
    <asp:Label ID="lblResultado" runat="server" ForeColor="Green"></asp:Label></div>
</asp:Content>