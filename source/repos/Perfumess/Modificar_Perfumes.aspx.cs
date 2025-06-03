using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Web.UI.WebControls;

namespace Perfumess
{
    public partial class ModificarPerfume : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verifica si el usuario está logueado y si su tipo es "admin"
            if (Session["Nombre"] == null || Session["Tipo"] == null || Session["Tipo"].ToString() != "admin")
            {
                Response.Redirect("Login.aspx");
                // O Response.Redirect("AccesoDenegado.aspx");
            }

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
                gvPerfumes.DataSource = dt;
                gvPerfumes.DataBind();
            }
        }

        protected void gvPerfumes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPerfumes.EditIndex = e.NewEditIndex;
            CargarPerfumes();
        }

        protected void gvPerfumes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPerfumes.EditIndex = -1;
            CargarPerfumes();
        }

        protected void gvPerfumes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvPerfumes.Rows[e.RowIndex];
            int id = Convert.ToInt32(gvPerfumes.DataKeys[e.RowIndex].Value);

            string nombre = ((TextBox)row.Cells[1].Controls[0]).Text;
            string marca = ((TextBox)row.Cells[2].Controls[0]).Text;
            decimal precio = decimal.Parse(((TextBox)row.Cells[3].Controls[0]).Text.Replace("$", "").Replace(",", ""));
            int stock = int.Parse(((TextBox)row.Cells[4].Controls[0]).Text);

            // Imagen
            FileUpload fuImagenEdit = (FileUpload)row.FindControl("fuImagenEdit");
            HiddenField hfImagenActual = (HiddenField)row.FindControl("hfImagenActual");
            string nuevaImagenPath = hfImagenActual.Value; // Por defecto, conservar la imagen actual

            // Si el usuario subió una nueva imagen, la guardamos y actualizamos la ruta
            if (fuImagenEdit != null && fuImagenEdit.HasFile)
            {
                string folder = "~/Imagenes/";
                string fullPath = Server.MapPath(folder);
                if (!Directory.Exists(fullPath))
                    Directory.CreateDirectory(fullPath);

                string fileName = Path.GetFileName(fuImagenEdit.FileName);
                string savePath = Path.Combine(fullPath, fileName);
                fuImagenEdit.SaveAs(savePath);
                nuevaImagenPath = folder + fileName;
            }

            string connStr = ConfigurationManager.ConnectionStrings["PerfumesDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Perfume SET Nombre=@Nombre, Marca=@Marca, Precio=@Precio, Stock=@Stock, Imagen=@Imagen WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Marca", marca);
                cmd.Parameters.AddWithValue("@Precio", precio);
                cmd.Parameters.AddWithValue("@Stock", stock);
                cmd.Parameters.AddWithValue("@Imagen", (object)nuevaImagenPath ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            gvPerfumes.EditIndex = -1;
            CargarPerfumes();
            lblResultado.Text = "Perfume actualizado correctamente.";
        }

        protected void gvPerfumes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvPerfumes.DataKeys[e.RowIndex].Value);
            string connStr = ConfigurationManager.ConnectionStrings["PerfumesDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Perfume WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            CargarPerfumes();
            lblResultado.Text = "Perfume eliminado correctamente.";
        }
    }
}