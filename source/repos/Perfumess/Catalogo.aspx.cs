using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;

namespace Perfumess
{
    public partial class Catalogo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPerfumes();
            }
        }

        private void CargarPerfumes()
        {
            string connStr = ConfigurationManager.ConnectionStrings["PerfumesDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT Id, Nombre, Marca, Precio, Stock, Imagen FROM Perfume", conn);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                rptPerfumes.DataSource = dt;
                rptPerfumes.DataBind();
            }
        }

        protected void rptPerfumes_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AgregarCarrito")
            {
                int perfumeId = Convert.ToInt32(e.CommandArgument);

                // Obtener datos del perfume
                string connStr = ConfigurationManager.ConnectionStrings["PerfumesDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand("SELECT Id, Nombre, Marca, Precio, Imagen FROM Perfume WHERE Id=@Id", conn);
                    cmd.Parameters.AddWithValue("@Id", perfumeId);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Carrito en sesión (lista de objetos)
                        List<CarritoItem> carrito = Session["Carrito"] as List<CarritoItem>;
                        if (carrito == null)
                            carrito = new List<CarritoItem>();

                        // Verificar si ya está en el carrito
                        CarritoItem itemExistente = carrito.Find(p => p.Id == perfumeId);
                        if (itemExistente != null)
                        {
                            itemExistente.Cantidad += 1;
                        }
                        else
                        {
                            carrito.Add(new CarritoItem
                            {
                                Id = (int)reader["Id"],
                                Nombre = reader["Nombre"].ToString(),
                                Marca = reader["Marca"].ToString(),
                                Precio = Convert.ToDecimal(reader["Precio"]),
                                Imagen = reader["Imagen"] == DBNull.Value ? "~/Imagenes/default.png" : reader["Imagen"].ToString(),
                                Cantidad = 1
                            });
                        }

                        Session["Carrito"] = carrito;
                        lblMensaje.Text = "¡Producto añadido al carrito!";
                    }
                }
            }
        }
    }

    [Serializable]
    public class CarritoItem
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public int Cantidad { get; set; }
    }
}