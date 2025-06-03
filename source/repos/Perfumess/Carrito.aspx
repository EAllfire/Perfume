<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Perfumess.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Carrito de Compras</h2>
    <asp:GridView ID="gvCarrito" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:ImageField DataImageUrlField="Imagen" HeaderText="Imagen" ControlStyle-Width="80" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Marca" HeaderText="Marca" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
            <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="lblTotal" runat="server" Font-Bold="true"></asp:Label>
</asp:Content>