using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista_Web.Seguridad
{
    public partial class Grupos : System.Web.UI.Page
    {
        Controladora.CCUGUsuarios oCCUGUUsuarios;
        Controladora.CCUGGrupos oCCUGGrupos;
        Modelo_Entidades.USUARIO oUsuario;
        Modelo_Entidades.GRUPO oGrupo;
        List<Modelo_Entidades.GRUPO> oListaGrupos;
        string grupo;
        string modo;

        // Constructor
        public Grupos()
        {
            oCCUGUUsuarios = Controladora.CCUGUsuarios.ObtenerInstancia();
            oCCUGGrupos = Controladora.CCUGGrupos.ObtenerInstancia();
        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                oUsuario = (Modelo_Entidades.USUARIO)HttpContext.Current.Session["sUsuario"];
                botonera1.ArmaPerfil(oUsuario, "frmGrupos");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Arma_Lista();
            }

        }

        // Al hacer click en "Agregar"
        protected void botonera1_Click_Alta(object sender, EventArgs e)
        {
            grupo = "nuevo";
            modo = "Alta";
            Response.Redirect(String.Format("~/Seguridad/Grupo.aspx?grupo={0}&modo={1}", Server.UrlEncode(grupo), Server.UrlEncode(modo)));
        }

        // Al hacer click en "Ver detalle"
        protected void botonera1_Click_Consulta(object sender, EventArgs e)
        {
            message.Visible = true;

            if (gvGrupos.SelectedRow == null)
            {
                lb_error.Text = "Debe seleccionar un grupo";
            }

            else
            {
                grupo = gvGrupos.SelectedRow.Cells[2].Text;
                modo = "Consulta";
                Response.Redirect(String.Format("~/Seguridad/Grupo.aspx?grupo={0}&modo={1}", Server.UrlEncode(grupo), Server.UrlEncode(modo)));
            }
        }

        // Al hacer click en "Modificar"
        protected void botonera1_Click_Modificacion(object sender, EventArgs e)
        {
            message.Visible = true;

            if (gvGrupos.SelectedRow == null)
            {
                lb_error.Text = "Debe seleccionar un grupo";
            }

            else
            {
                grupo = gvGrupos.SelectedRow.Cells[2].Text;
                modo = "Modifica";
                Response.Redirect(String.Format("~/Seguridad/Grupo.aspx?grupo={0}&modo={1}", Server.UrlEncode(grupo), Server.UrlEncode(modo)));
            }
        }

        protected void botonera1_Click_Cerrar(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Principal.aspx"));
        }

        // Al hacer click en "Modificar"
        protected void botonera1_Click_Baja(object sender, EventArgs e)
        {
            if (gvGrupos.SelectedRow == null)
            {
                message.Visible = true;
                lb_error.Text = "Debe seleccionar un grupo";
            }

            else
            {
                grupo = gvGrupos.SelectedRow.Cells[1].Text;
                oGrupo = oCCUGGrupos.ObtenerGrupoPorCodigo(grupo);

                if (oCCUGGrupos.ComprobarUso(oGrupo) == true)
                {
                    message.Visible = true;
                    lb_error.Text = "Para eliminar el grupo, primero debe desasociar a todos sus miembros y eliminar todos sus perfiles";
                    return;
                }

                message.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openModal();", true);
            }

        }

        // Armo la lista de la grilla de datos
        private void Arma_Lista()
        {
            gvGrupos.DataSource = oCCUGGrupos.ObtenerGrupos();
            gvGrupos.DataBind();

            message.Visible = false;
        }

        protected void btn_filtrar_Click(object sender, EventArgs e)
        {
            message.Visible = false;

            string nombre_grupo;

            if (txt_nombregrupo.Text == "")
            {
                nombre_grupo = "0";
            }

            else
            {
                nombre_grupo = txt_nombregrupo.Text;
            }

            oListaGrupos = oCCUGGrupos.ObtenerGrupos(descripcion: nombre_grupo);
            gvGrupos.DataSource = oListaGrupos;
            gvGrupos.DataBind();
        }

        protected void btn_nuevaconsulta_Click(object sender, EventArgs e)
        {
            Arma_Lista();
        }

        protected void btn_eliminar_modal_Click(object sender, EventArgs e)
        {
            grupo = gvGrupos.SelectedRow.Cells[1].Text;
            oGrupo = oCCUGGrupos.ObtenerGrupoPorCodigo(grupo);

            oCCUGGrupos.Eliminar(oGrupo);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal();", true);
            message.Visible = true;

            lb_error.Text = "El grupo fue eliminado";
            Arma_Lista();
        }

        protected void btn_cancelar_modal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal();", true);
        }

        protected void gvGrupos_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Text = "Descripción";
        }

        protected void gvGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            message.Visible = false;
        }
    }
}