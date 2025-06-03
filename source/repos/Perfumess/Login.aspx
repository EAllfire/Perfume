<%@ Page Title="Iniciar Sesión" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Perfumess.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/login-glass.css" rel="stylesheet" />
    <div class="login-container">
        <div class="login-card">
            <h2 class="login-title">Iniciar Sesión</h2>
            <asp:Label ID="lblMensaje" runat="server" CssClass="login-error" ForeColor="Red" />
            <asp:TextBox ID="txtUsuario" runat="server" CssClass="login-input" placeholder="Usuario"></asp:TextBox>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="login-input" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
            <asp:Button ID="btnLogin" runat="server" Text="Entrar" CssClass="login-btn" OnClick="btnLogin_Click" />
        </div>
    </div>
</asp:Content>