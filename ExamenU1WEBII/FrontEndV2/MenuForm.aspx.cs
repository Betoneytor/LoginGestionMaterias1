using BackEnd.datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackEnd.modelo;

namespace FrontEndV2
{
    public partial class MenuForm : System.Web.UI.Page
    {
        UsuarioDAO objUsuarioDao = new UsuarioDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idUsuario"] != null)
            {
                cargarUsuarioASesion();
                lblUsr.Text = "Bienvenido: " + Session["email"];
               
            }
            else
            {
                Response.Redirect("LoginForm.aspx");
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["idUsuario"] = null;
            Session["email"] = null;
            Response.Redirect("LoginForm.aspx");
        }

        protected void btnGestionarMaterias_Click(object sender, EventArgs e)
        {
            Response.Redirect("MateriasForm.aspx");
        }

        public void cargarUsuarioASesion()
        {
            Usuario usr = objUsuarioDao.getEmailById(Int32.Parse(Session["idUsuario"].ToString()));
            Session["email"] = usr.Email;

        }
    }
}