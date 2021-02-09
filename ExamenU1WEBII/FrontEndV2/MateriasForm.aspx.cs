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
    public partial class MateriasForm : System.Web.UI.Page
    {
        
        List<Materia> listaMaterias = new List<Materia>();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            btnAceptar.Enabled = false;
           
            if (Session["idUsuario"] != null)
            {
                lblAgregarEditarMaterias.Text = "Agregar Materia";
                btnAceptar.Text = "Agregar Materia";
              
                lblUsr.Text = "Bienvenido: " + Session["email"];

                listaMaterias = new MateriaDAO().getAllForUsr(int.Parse(Session["idUsuario"].ToString()));
                //Evitar que agregue más columnas a la tabla
                gvMaterias.AutoGenerateColumns = false;
                gvMaterias.DataSource = listaMaterias;
                gvMaterias.DataBind();
                //gvMaterias.Columns[2].Visible = false;

                //se pregunta si existe Clave materia porque solo existe si se clickeo en la tabla al editar
                if (Request["ClaveMateria"] != null)
                {
                    Materia m = new MateriaDAO().getOne(int.Parse(Request["ClaveMateria"].ToString()));

                    txtAgregarEditarMaterias.Text = m.Nombre;
                    idAgregarMateria.Value = m.idMateria.ToString();
                    lblAgregarEditarMaterias.Text = "Editar Materia";
                    btnAceptar.Text = "Editar Materia";
                }
                 
            }
            else
            {
                Response.Redirect("LoginForm.aspx");
            }
        }

       
        protected void gvMaterias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                Dictionary<String, String> info = new Dictionary<string, string>();
                info.Add("ClaveMateria", gvMaterias.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text);
                enviar("MateriasForm.aspx", info);

                

            }
            else if (e.CommandName == "Eliminar")
            {
                IdMateria.Value = gvMaterias.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text;
                Response.Write("<script>window.addEventListener('load', function () {$('#mdlConfirmarEliminar').modal('show');});</script>");



            }
            else if (e.CommandName == "Gestionar")
            {
                Session["idMateriaG"] = gvMaterias.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text;
                Response.Redirect("CalificacionesForm.aspx");
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
            Materia m = new Materia();
            
            m.Nombre =  txtAgregarEditarMaterias.Text.Trim();
            m.idUsuario = int.Parse(Session["idUsuario"].ToString());
            if (verificarRepetido(m))
            {
                lblInfoError.Text = "Error: no se puede repetir el nombre de materia ya existe la materia: " + txtAgregarEditarMaterias.Text;
            }
            else
            {
                lblInfoError.Text = "";
                

                //Identificar si es agregar o editar
                if (idAgregarMateria.Value == "0")
                {
                    lblAgregarEditarMaterias.Text = "Nombre Materia";

                    int resultado = new MateriaDAO().insert(m);
                    if (resultado > 0)
                        Response.Redirect("MateriasForm.aspx");
                    else
                    {
                        //Mostrar errores
                        Response.Redirect("LoginForm.aspx");
                    }


                }
                else
                {
                    //Editar
                    lblAgregarEditarMaterias.Text = "Editar Nombre Materia";
                    m.idMateria = int.Parse(idAgregarMateria.Value);
                    bool resultado = new MateriaDAO().update(m);
                    if (resultado)
                    {
                        idAgregarMateria.Value = "0";
                        Response.Redirect("MateriasForm.aspx");
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
            bool resultado = new MateriaDAO().delete(int.Parse(IdMateria.Value));
            if (resultado)
            {
                listaMaterias = new MateriaDAO().getAllForUsr(int.Parse(Session["idUsuario"].ToString()));
                //Evitar que agregue más columnas a la tabla
                gvMaterias.DataSource = null;
                gvMaterias.DataSource = listaMaterias;
                gvMaterias.DataBind();
            }
            else
            {
                //hay errores
            }
        }

        protected void btnValidar_Click(object sender, EventArgs e)
        {
            if (txtAgregarEditarMaterias.CssClass.Contains("is-valid"))
            {
                btnAceptar.Enabled = true;
            }
            else if(txtAgregarEditarMaterias.CssClass.Contains("is-invalid")) {
                btnAceptar.Enabled = false;
            }
            
        }
        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["idUsuario"] = null;
            Session["email"] = null;
            Response.Redirect("LoginForm.aspx");
        }
        
        public bool verificarRepetido(Materia materiaAVerificar)
        {
            bool esRepetido = false;
            foreach (Materia m in listaMaterias)
            {
                if( m.Nombre.Equals(materiaAVerificar.Nombre))
                {
                    esRepetido = true;
                    break;
                }
                
             }
            return esRepetido;
        }
    }
}