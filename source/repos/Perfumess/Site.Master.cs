using System;

namespace Perfumes
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Controlar la visibilidad del enlace de admin
            adminLink.Visible = Session["Tipo"] != null && Session["Tipo"].ToString() == "admin";

            // Mostrar info de usuario y botón de logout si está logueado
            if (Session["Nombre"] != null && Session["Tipo"] != null)
            {
                userInfo.Text = $"Usuario: {Session["Nombre"]} ({Session["Tipo"]})";
                btnLogout.Visible = true;
            }
            else
            {
                userInfo.Text = "";
                btnLogout.Visible = false;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}