<%@ Page Title="Modificar Perfume" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Modificar_Perfumes.aspx.cs" Inherits="Perfumess.ModificarPerfume" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="perfume-card">
    <h2>Modificar Perfumes</h2>
    <asp:GridView ID="gvPerfumes" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
        OnRowEditing="gvPerfumes_RowEditing"
        OnRowUpdating="gvPerfumes_RowUpdating"
        OnRowCancelingEdit="gvPerfumes_RowCancelingEdit"
        OnRowDeleting="gvPerfumes_RowDeleting">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Marca" HeaderText="Marca" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
            <asp:BoundField DataField="Stock" HeaderText="Stock" />
            <asp:TemplateField HeaderText="Imagen actual">
                <ItemTemplate>
                    <asp:Image ID="imgPerfume" runat="server" ImageUrl='<%# Eval("Imagen") != DBNull.Value && !string.IsNullOrEmpty((string)Eval("Imagen")) ? Eval("Imagen") : "~/Imagenes/default.png" %>' Width="80" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Image ID="imgPerfumeEdit" runat="server" ImageUrl='<%# Eval("Imagen") != DBNull.Value && !string.IsNullOrEmpty((string)Eval("Imagen")) ? Eval("Imagen") : "~/Imagenes/default.png" %>' Width="80" />
                    <br />
                    <asp:FileUpload ID="fuImagenEdit" runat="server" />
                    <asp:HiddenField ID="hfImagenActual" runat="server" Value='<%# Eval("Imagen") %>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="lblResultado" runat="server" ForeColor="Green"></asp:Label></div>
</asp:Content>