using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista_Web.Seguridad
{
    public partial class Usuarios : System.Web.UI.Page
    {
        Controladora.CCUGUsuarios oCCUGUsuarios;
        Controladora.CCUGGrupos oCCUGGrupos;
        Modelo_Entidades.USUARIO oUsuario;
        List<Modelo_Entidades.USUARIO> lUsuarios;
        string usuario;
        string modo;

        // Constructor
        public Usuarios()
        {
            oCCUGUsuarios = Controladora.CCUGUsuarios.ObtenerInstancia();
            oCCUGGrupos = Controladora.CCUGGrupos.ObtenerInstancia();
        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                oUsuario = (Modelo_Entidades.USUARIO)HttpContext.Current.Session["sUsuario"];
                botonera1.ArmaPerfil(oUsuario, "frmUsuarios");
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
            usuario = "nuevo";
            modo = "Alta";
            Response.Redirect(String.Format("~/Seguridad/Usuario.aspx?usuario={0}&modo={1}", Server.UrlEncode(usuario), Server.UrlEncode(modo)));
        }

        // Al hacer click en "Ver detalle"
        protected void botonera1_Click_Consulta(object sender, EventArgs e)
        {
            message.Visible = true;

            if (gvUsuarios.SelectedRow == null)
            {
                lb_error.Text = "Debe seleccionar un usuario";
            }

            else
            {
                usuario = gvUsuarios.SelectedRow.Cells[1].Text;
                modo = "Consulta";
                Response.Redirect(String.Format("~/Seguridad/Usuario.aspx?usuario={0}&modo={1}", Server.UrlEncode(usuario), Server.UrlEncode(modo)));
            }
        }

        // Al hacer click en "Modificar"
        protected void botonera1_Click_Modificacion(object sender, EventArgs e)
        {
            message.Visible = true;

            if (gvUsuarios.SelectedRow == null)
            {
                lb_error.Text = "Debe seleccionar un usuario";
            }

            else
            {
                usuario = gvUsuarios.SelectedRow.Cells[1].Text;
                modo = "Modifica";
                Response.Redirect(String.Format("~/Seguridad/Usuario.aspx?usuario={0}&modo={1}", Server.UrlEncode(usuario), Server.UrlEncode(modo)));
            }
        }

        protected void botonera1_Click_Cerrar(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Principal.aspx"));
        }


        // Al hacer click en "Eliminar"
        protected void botonera1_Click_Baja(object sender, EventArgs e)
        {
            if (gvUsuarios.SelectedRow == null)
            {
                message.Visible = true;
                lb_error.Text = "Debe seleccionar un usuario";
            }

            else
            {
                usuario = gvUsuarios.SelectedRow.Cells[1].Text;
                oUsuario = oCCUGUsuarios.ObtenerUsuario(usuario);

                if (oUsuario.USU_ESTADO == false)
                {
                    message.Visible = true;
                    lb_error.Text = "El usuario ya se encuentra inactivo.";
                }

                else
                {
                    message.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openModal();", true);
                }
            }

        }

        // Armo la lista de la grilla de datos
        private void Arma_Lista()
        {
            lUsuarios = oCCUGUsuarios.ObtenerUsuarios();
            gvUsuarios.DataSource = lUsuarios;
            gvUsuarios.DataBind();

            cmb_grupos.DataSource = oCCUGGrupos.ObtenerGrupos();
            cmb_grupos.DataBind();
            cmb_grupos.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            cmb_grupos.SelectedIndex = 0;

            message.Visible = false;
        }

        protected void btn_filtrar_Click(object sender, EventArgs e)
        {
            message.Visible = false;

            string nombre;
            string apellido;
            string VarCombo_Grupo;
            string activa;

            if (txt_nombre.Text == "")
            {
                nombre = "0";
            }
            else
            {
                nombre = txt_nombre.Text;
            }

            if (txt_apellido.Text == "")
            {
                apellido = "0";
            }
            else
            {
                apellido = txt_nombre.Text;
            }

            if (cmb_grupos.SelectedValue == "")
            {
                VarCombo_Grupo = "0";
            }

            else
            {
                VarCombo_Grupo = cmb_grupos.SelectedValue.ToString();
            }

            if (chk_estado.Checked == true)
            {
                activa = "1";
            }

            else
            {
                activa = "0";
            }

            gvUsuarios.DataSource = oCCUGUsuarios.ObtenerUsuarios(nombre, apellido, VarCombo_Grupo, activa);
            gvUsuarios.DataBind();
        }

        protected void btn_nuevaconsulta_Click(object sender, EventArgs e)
        {
            Arma_Lista();
        }

        protected void btn_eliminar_modal_Click(object sender, EventArgs e)
        {
            usuario = gvUsuarios.SelectedRow.Cells[1].Text;
            oUsuario = oCCUGUsuarios.ObtenerUsuario(usuario);

            oUsuario.USU_ESTADO = false;
            // Nunca se borra un usuario, por eso solo se modifica el estado.
            oCCUGUsuarios.Modificar(oUsuario);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal();", true);
            message.Visible = true;
            lb_error.Text = "El usuario fue pasado a inactivo";
            Arma_Lista();
        }

        protected void btn_cancelar_modal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal();", true);
        }

        protected void gvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            message.Visible = false;
        }

        protected void gvUsuarios_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Text = "Código de usuario";
            e.Row.Cells[2].Text = "Nombre";
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
            e.Row.Cells[5].Text = "Apellido";
            e.Row.Cells[6].Text = "E-Mail";
        }
    }
}