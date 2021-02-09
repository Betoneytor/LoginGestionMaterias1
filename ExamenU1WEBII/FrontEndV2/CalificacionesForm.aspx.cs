using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackEnd.modelo;
using BackEnd.datos;

namespace FrontEndV2
{
    public partial class CalificacionesForm : System.Web.UI.Page
    {
        List<Unidad> listaDeUnidades = new List<Unidad>();

        protected void Page_Load(object sender, EventArgs e)
        {
            btnAceptar.Enabled = false;

            if (Session["idMateriaG"] != null)
            {
                lblAgregarEditarNUnidad.Text= "Numero Unidad";
                lblAgregarEditarCalificacion.Text = "Agregar Calificacion";
                btnAceptar.Text = "Agregar Calificacion";
               
                lblUsr.Text = "Bienvenido: " + Session["email"];

                lblMatereriaGestionando.Text = "Gestionando: "+ new MateriaDAO().getOne(int.Parse(Session["idMateriaG"].ToString())).Nombre;

                listaDeUnidades = new UnidadDAO().getAllForMat(int.Parse(Session["idMateriaG"].ToString()));
                //Evitar que agregue más columnas a la tabla
                gvUnidades.AutoGenerateColumns = false;
                gvUnidades.DataSource =listaDeUnidades;
                gvUnidades.DataBind();
                //gvMaterias.Columns[2].Visible = false;

                if (Request["ClaveUnidad"] != null)
                {
                    Unidad u = new UnidadDAO().getOne(int.Parse(Request["ClaveUnidad"].ToString()));

                    idAgregarUnidad.Value = u.idUnidad.ToString();
                    txtAgregarEditarNUnidad.Text = u.NumeroUnidad.ToString();
                    lblAgregarEditarNUnidad.Text = "Editar Unidad";

                    txtAgregarEditarCalificacion.Text = u.CalificacionUnidad.ToString();
                    lblAgregarEditarCalificacion.Text = "Editar Calificacion";

                    btnAceptar.Text = "Editar Unidad";
                }

            }
            else
            {
                Response.Redirect("LoginForm.aspx");
            }
        }

       
        protected void gvUnidades_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                Dictionary<String, String> info = new Dictionary<string, string>();
                info.Add("ClaveUnidad", gvUnidades.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text);
                enviar("CalificacionesForm.aspx", info);
                


            }
            else if (e.CommandName == "Eliminar")
            {
                IdUnidad.Value = gvUnidades.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text;
                Response.Write("<script>window.addEventListener('load', function () {$('#mdlConfirmarEliminar').modal('show');});</script>");



            }

        }
        public void enviar(String url, Dictionary<String, String> valores)
        {
            Response.Clear();
            Response.Write("<html><head>");
            Response.Write("</head><body onload=\"document.frm.submit()\">");
            Response.Write(string.Format("<form name=\"frm\" method=\"post\" action=\"{0}\" >", url));
            foreach (KeyValuePair<String, String> item in valores)
            {
                Response.Write(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", item.Key, item.Value));
            }
            Response.Write("</form>");
            Response.Write("</body></html>");
            Response.End();

        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Unidad u = new Unidad();

            u.NumeroUnidad = int.Parse(txtAgregarEditarNUnidad.Text.Trim());
            u.CalificacionUnidad = int.Parse(txtAgregarEditarCalificacion.Text.Trim());
            u.idMateria = int.Parse(Session["idMateriaG"].ToString());
            if (verificarRepetido(u))
            {
                lblInfoError.Text = "Error: no se puede repetir el numero de unidad ya existe la unidad: "+txtAgregarEditarNUnidad.Text;
            }
            else
            {
                lblInfoError.Text = "";
                //Identificar si es agregar o editar
                if (idAgregarUnidad.Value == "0")
                {
                    lblAgregarEditarNUnidad.Text = "Numero Unidad";
                    lblAgregarEditarCalificacion.Text = "Calificacion";
                    int resultado = new UnidadDAO().insert(u);
                    if (resultado > 0)
                        Response.Redirect("CalificacionesForm.aspx");
                    else
                    {
                        //Mostrar errores
                        Response.Redirect("LoginForm.aspx");
                    }
                }
                else
                {
                    //Editar
                    lblAgregarEditarNUnidad.Text = "Editar Numero Unidad";
                    lblAgregarEditarCalificacion.Text = "Editar Calificacion";
                    u.idUnidad = int.Parse(idAgregarUnidad.Value);
                    bool resultado = new UnidadDAO().update(u);
                    if (resultado)
                    {
                        idAgregarUnidad.Value = "0";
                        Response.Redirect("CalificacionesForm.aspx");
                    }
                    else
                    {
                        //Mostrar errores
                        Response.Redirect("LoginForm.aspx");
                    }
                }
            }
        }
        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            bool resultado = new UnidadDAO().delete(int.Parse(IdUnidad.Value));
            if (resultado)
            {
                listaDeUnidades = new UnidadDAO().getAllForMat(int.Parse(Session["idMateriaG"].ToString()));
                //Evitar que agregue más columnas a la tabla
                gvUnidades.DataSource = null;
                gvUnidades.DataSource = listaDeUnidades;
                gvUnidades.DataBind();
            }
            else
            {
                //hay errores
            }
        }
        protected void btnValidar_Click(object sender, EventArgs e)
        {
            if (txtAgregarEditarNUnidad.CssClass.Contains("is-valid") && txtAgregarEditarCalificacion.CssClass.Contains("is-valid"))
            {
                btnAceptar.Enabled = true;
            }
            else if (txtAgregarEditarNUnidad.CssClass.Contains("is-invalid") &&  txtAgregarEditarCalificacion.CssClass.Contains("is-invalid"))
            {
                btnAceptar.Enabled = false;
            }

        }
        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["idUsuario"] = null;
            Session["email"] = null;
            Session["idMateriaG"] = null;
            Response.Redirect("LoginForm.aspx");
        }
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Session["idMateriaG"] = null;
            Response.Redirect("MateriasForm.aspx");
        }
        public bool verificarRepetido(Unidad unidadAVerificar)
        {
            bool esRepetido = false;
            foreach (Unidad u in listaDeUnidades)
            {
                if (u.NumeroUnidad.Equals(unidadAVerificar.NumeroUnidad))
                {
                    esRepetido = true;
                    break;
                }

            }
            return esRepetido;
        }
    }
}