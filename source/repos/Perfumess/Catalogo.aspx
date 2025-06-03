<%@ Page Title="Catálogo" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="Perfumess.Catalogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/catalogo-glass-opacity.css" rel="stylesheet" />
    <h2 class="catalogo-titulo">Catálogo de Perfumes</h2>
    <div class="catalogo-grid">
        <asp:Repeater ID="rptPerfumes" runat="server" OnItemCommand="rptPerfumes_ItemCommand">
            <ItemTemplate>
                <div class="perfume-card">
                    <img src='<%# ResolveUrl(Eval("Imagen") != DBNull.Value && !string.IsNullOrEmpty((string)Eval("Imagen")) ? Eval("Imagen").ToString() : "~/Imagenes/default.png") %>' 
                         alt="Imagen Perfume" class="perfume-img" />
                    <h3 class="nombre"><%# Eval("Nombre") %></h3>
                    <div class="marca"><%# Eval("Marca") %></div>
                    <div class="precio"><%# String.Format("{0:C}", Eval("Precio")) %></div>
                    <asp:Button ID="btnAgregarCarrito" runat="server" CssClass="btn-carrito" Text="Añadir al carrito"
                        CommandName="AgregarCarrito" CommandArgument='<%# Eval("Id") %>' />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <asp:Label ID="lblMensaje" runat="server" ForeColor="Green"></asp:Label>
</asp:Content>