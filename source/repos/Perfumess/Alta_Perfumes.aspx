<%@ Page Title="Alta Perfume" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Alta_Perfumes.aspx.cs" Inherits="Perfumess.AltaPerfume" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <div class="perfume-card">
    <h2>Agregar Nuevo Perfume</h2>
    <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre" /><br />
    <asp:TextBox ID="txtMarca" runat="server" placeholder="Marca" /><br />
    <asp:TextBox ID="txtDescripcion" runat="server" placeholder="Descripción" TextMode="MultiLine" /><br />
    <asp:TextBox ID="txtPrecio" runat="server" placeholder="Precio" /><br />
    <asp:TextBox ID="txtStock" runat="server" placeholder="Stock" /><br />
    <asp:FileUpload ID="fuImagen" runat="server" /><br />
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
    <asp:Label ID="lblResultado" runat="server" ForeColor="Green"></asp:Label></div>
</asp:Content>