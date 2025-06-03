using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Perfumes
{
    public partial class AltaUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["PerfumesDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "INSERT INTO Usuario (Nombre, Email, Password, Tipo) VALUES (@Nombre, @Email, @Password, @Tipo)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.Parameters.AddWithValue("@Tipo", ddlTipo.SelectedValue);
                conn.Open();
                cmd.ExecuteNonQuery();
                lblResultado.Text = "Usuario registrado correctamente.";
            }
        }
    }
}