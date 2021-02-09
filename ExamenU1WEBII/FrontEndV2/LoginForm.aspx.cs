using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using BackEnd.datos;
using System.Text.RegularExpressions;
using BackEnd.modelo;

namespace FrontEndV2
{
    public partial class LoginForm : System.Web.UI.Page
    {

        UsuarioDAO objUsuarioDao = new UsuarioDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
     
        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
           int idUsr = objUsuarioDao.existeUsuario(txtEmail.Text, txtContrasena.Text);
                if (idUsr != 0)

            {
                lblInfoError.Text = "";
                txtEmail.CssClass = "form-control is-valid";
                txtContrasena.CssClass = "form-control is-valid";
                Session["idUsuario"] = idUsr;
                

                Response.Redirect("MenuForm.aspx");
            }
            else
            {
                lblInfoPositiva.Text = "";
                lblInfoError.Text = "Error al Iniciar Sesión, Usuario y/o Contraseña Invalidos";
                txtEmail.CssClass = "form-control is-invalid";
                txtContrasena.CssClass = "form-control is-invalid";
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (evaluarEmail(txtEmail.Text))
            {
                if (objUsuarioDao.registrarUsuario(txtEmail.Text, txtContrasena.Text) != 0)
                {
                    lblInfoError.Text = "";
                    lblInfoPositiva.Text = "Usuario Registrado Con Exito";
                    txtEmail.CssClass = "form-control is-valid";
                    txtContrasena.CssClass = "form-control is-valid";

                    int idUsr = objUsuarioDao.existeUsuario(txtEmail.Text, txtContrasena.Text);
                    if (idUsr != 0)
                    {
                        Session["idUsuario"] = idUsr;
                    }
                    Response.Write("<script>window.addEventListener('load', function () {$('#mdlAvisoRedireccionPorRegistro').modal('show');});</script>");


                }
                else
                {
                    lblInfoPositiva.Text = "";
                    lblInfoError.Text = "Error al registrar, verifique que su contraseña contenga solo numeros y su email tenga formato valido";
                    txtEmail.CssClass = "form-control is-invalid";
                    txtContrasena.CssClass = "form-control is-invalid";
                }
            }
            else {
                lblInfoPositiva.Text = "";
                lblInfoError.Text = "Error al registrar, verifique que su contraseña contenga solo numeros y su email tenga formato valido";
                txtEmail.CssClass = "form-control is-invalid";
                txtContrasena.CssClass = "form-control is-invalid";
            }
            

           
        }
        public bool evaluarEmail(String email)
        {
            string pattern = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
            Match match = Regex.Match(email.Trim(), pattern, RegexOptions.IgnoreCase);

            if (match.Success)
                return true;
            else
                return false;
        }
        protected void btnRedireccion_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuForm.aspx");
        }

    }
}
    
