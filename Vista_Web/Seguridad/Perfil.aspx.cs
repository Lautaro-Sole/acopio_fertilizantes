using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using AjaxControlToolkit;

namespace Vista_Web
{
    public partial class Perfil : System.Web.UI.Page
    {
        // Declaro las variables que voy a utilizar en el formulario.
        string modo;
        Controladora.CCUGUsuarios cUsuario;
        Controladora.CCUGGrupos cGrupo;
        Controladora.CCURPF cRPF;
        Controladora.CCUGPerfiles cPerfil;

        //Modelo_Entidades.Usuario oUsuario;
        Modelo_Entidades.GRUPO oGrupo;
        Modelo_Entidades.PERMISO oPermiso;
        Modelo_Entidades.FORMULARIO oFormulario;
        Modelo_Entidades.PERFIL oPerfil;

        List<Modelo_Entidades.GRUPO> lGrupos;
        List<Modelo_Entidades.PERMISO> lPermisos;
        List<Modelo_Entidades.FORMULARIO> lFormularios;

        string grupo;
        string permiso;
        string formulario;
        string perfil;

        // Constructor
        public Perfil()
        {
            cUsuario = Controladora.CCUGUsuarios.ObtenerInstancia();
            cGrupo = Controladora.CCUGGrupos.ObtenerInstancia();
            cRPF = Controladora.CCURPF.ObtenerInstancia();
            cPerfil = Controladora.CCUGPerfiles.ObtenerInstancia();
        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {
            perfil = Server.UrlDecode(Request.QueryString["perfil"]);
            modo = Server.UrlDecode(Request.QueryString["modo"]);

            if (perfil == "nuevo")
            {
                oPerfil = new Modelo_Entidades.PERFIL();
            }
            else
            {
                oPerfil = cPerfil.ObtenerPerfil(Convert.ToInt32(perfil));
            }

            message.Visible = false;

            cmb_grupos.Enabled = true;
            cmb_permisos.Enabled = true;
            cmb_formularios.Enabled = true;

            if (modo != "Alta")
            {
                cmb_grupos.SelectedValue = oPerfil.GRUPOS.ToString();
                cmb_permisos.SelectedValue = oPerfil.PERMISOS.ToString();
                cmb_formularios.SelectedValue = oPerfil.FORMULARIOS.ToString();

                if (modo == "Consulta")
                {
                    cmb_grupos.Enabled = false;
                    cmb_permisos.Enabled = false;
                    cmb_formularios.Enabled = false;
                    btn_guardar.Enabled = false;
                    btn_cancelar.Text = "Cerrar";
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.CargaDatos();
            }
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/Seguridad/Gestion de Perfiles.aspx");
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            if (ValidarObligatorios() == true)
            {
                oPerfil.GRUPOS = oGrupo;
                oPerfil.FORMULARIOS = oFormulario;
                oPerfil.PERMISOS = oPermiso;

                cPerfil.Agregar(oPerfil);
                Page.Response.Redirect("~/Seguridad/Gestion de Perfiles.aspx");
            }
        }

        // Valido los datos del usuario
        private bool ValidarObligatorios()
        {
            if (cmb_grupos.SelectedValue == null)
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar un grupo";
                return false;
            }

            if (cmb_formularios.SelectedValue == null)
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar un formulario";
                return false;
            }

            if (cmb_permisos.SelectedValue == null)
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar un permiso";
                return false;
            }

            grupo = cmb_grupos.SelectedValue.ToString();
            oGrupo = cGrupo.ObtenerGrupo(grupo);

            permiso = cmb_permisos.SelectedValue.ToString();
            oPermiso = cRPF.ObtenerPermiso(permiso);

            formulario = cmb_formularios.SelectedValue.ToString();
            oFormulario = cRPF.obtenerFormulariopordesc(formulario);


            if (cPerfil.ValidarPerfil(oGrupo, oPermiso, oFormulario) == false)
            {
                message.Visible = true;
                lb_error.Text = "El perfil ya existe, ingrese otros parámetros";
                return false;
            }

            return true;
        }

        // Cargo los datos en los controles correspondientes
        private void CargaDatos()
        {
            lGrupos = cGrupo.ObtenerGrupos();
            cmb_grupos.DataSource = lGrupos;
            cmb_grupos.DataBind();

            lPermisos = cRPF.ObtenerPermisos();
            cmb_permisos.DataSource = lPermisos;
            cmb_permisos.DataBind();

            lFormularios = cRPF.obtenerFormularios();
            cmb_formularios.DataSource = lFormularios;
            cmb_formularios.DataBind();
        }
    }
}