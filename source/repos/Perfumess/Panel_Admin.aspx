<%@ Page Title="Panel Admin" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Panel_Admin.aspx.cs" Inherits="Perfumes.PanelAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Panel de Administración</h2>
    <ul>
        <li><a href="Alta_Perfumes.aspx">Agregar nuevo perfume</a></li>
        <li><a href="Modificar_Perfumes.aspx">Modificar perfumes</a></li>
        <li><a href="Alta_Usuario.aspx">Agregar usuario</a></li>
    </ul>
</asp:Content>