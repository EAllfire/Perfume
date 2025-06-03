using System;
using System.Collections.Generic;
using System.Linq;

namespace Perfumess
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarCarrito();
        }

        private void CargarCarrito()
        {
            List<CarritoItem> carrito = Session["Carrito"] as List<CarritoItem>;
            if (carrito == null) carrito = new List<CarritoItem>();

            // Agregar columna de subtotal
            var datos = carrito.Select(item => new
            {
                item.Imagen,
                item.Nombre,
                item.Marca,
                item.Precio,
                item.Cantidad,
                Subtotal = item.Precio * item.Cantidad
            }).ToList();

            gvCarrito.DataSource = datos;
            gvCarrito.DataBind();

            lblTotal.Text = "Total: " + datos.Sum(i => i.Subtotal).ToString("C");
        }
    }
}