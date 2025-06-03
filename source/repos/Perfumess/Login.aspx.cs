using System;
using System.Data.SqlClient;
using System.Web.Security;

namespace Perfumess
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Si ya está logueado, redirige al inicio
            if (Session["Usuario"] != null)
                Response.Redirect("Default.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (ValidarUsuario(usuario, password))
            {
                Session["Usuario"] = usuario;
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblMensaje.Text = "Usuario o contraseña incorrectos.";
            }
        }

        // AJUSTA la cadena de conexión según tu base de datos
        private bool ValidarUsuario(string usuario, string password)
        {
            string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["PerfumesDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Usuarios WHERE Email=@usuario AND Contraseña=@password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@password", password);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
    }
}