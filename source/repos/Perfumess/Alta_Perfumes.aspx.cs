using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;


namespace Perfumess
{

    public partial class AltaPerfume : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null || Session["Rol"] == null || Session["Rol"].ToString() != "admin")
            {
                // Redirige a login o a una página de acceso denegado
                Response.Redirect("Login.aspx");
                // O Response.Redirect("AccesoDenegado.aspx");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string imagenPath = null;

            if (fuImagen.HasFile)
            {
                string folder = "~/Imagenes/";
                string fullPath = Server.MapPath(folder);
                if (!Directory.Exists(fullPath))
                    Directory.CreateDirectory(fullPath);

                string fileName = Path.GetFileName(fuImagen.FileName);
                string savePath = Path.Combine(fullPath, fileName);
                fuImagen.SaveAs(savePath);
                imagenPath = folder + fileName; // Guardamos la ruta relativa
            }

            string connStr = ConfigurationManager.ConnectionStrings["PerfumesDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "INSERT INTO Perfume (Nombre, Marca, Descripcion, Precio, Stock, Imagen) VALUES (@Nombre, @Marca, @Descripcion, @Precio, @Stock, @Imagen)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Marca", txtMarca.Text);
                cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@Precio", decimal.Parse(txtPrecio.Text));
                cmd.Parameters.AddWithValue("@Stock", int.Parse(txtStock.Text));
                cmd.Parameters.AddWithValue("@Imagen", (object)imagenPath ?? DBNull.Value);
                conn.Open();
                cmd.ExecuteNonQuery();
                lblResultado.Text = "Perfume agregado correctamente.";
            }
        }
    }
}