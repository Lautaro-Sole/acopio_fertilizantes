using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista_Web.Seguridad
{
    public partial class Grupo : System.Web.UI.Page
    {
        string modo;
        Controladora.CCUGUsuarios oCCUGUsuarios;
        Controladora.CCUGGrupos oCCUGGrupos;
        Controladora.CCURPF oCCURPF;
        //Controladora.cPermiso cPermiso;
        //Controladora.cFormulario cFormulario;
        Controladora.CCUGPerfiles oCCUGPerfiles;

        Modelo_Entidades.USUARIO oUsuario;
        Modelo_Entidades.GRUPO oGrupo;
        Modelo_Entidades.PERMISO oPermiso;
        Modelo_Entidades.FORMULARIO oFormulario;
        List<Modelo_Entidades.FORMULARIO> oListaFormularios;
        List<Modelo_Entidades.PERMISO> oListaPermisos;

        string grupo;
        string usuario;

        public Grupo()
        {
            oCCUGUsuarios = Controladora.CCUGUsuarios.ObtenerInstancia();
            oCCUGGrupos = Controladora.CCUGGrupos.ObtenerInstancia();
            oCCURPF = Controladora.CCURPF.ObtenerInstancia();
            //cPermiso = Controladora.cPermiso.ObtenerInstancia();
            //cFormulario = Controladora.cFormulario.ObtenerInstancia();
            oCCUGPerfiles = Controladora.CCUGPerfiles.ObtenerInstancia();
        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {
            grupo = Server.UrlDecode(Request.QueryString["grupo"]);
            modo = Server.UrlDecode(Request.QueryString["modo"]);

            if (grupo == "nuevo")
            {
                oGrupo = new Modelo_Entidades.GRUPO();
            }
            else
            {
                oGrupo = oCCUGGrupos.ObtenerGrupo(descripcion: grupo);
            }

            message.Visible = false;

            txt_descripcion.Enabled = true;
            chklstbox_persmisos.Enabled = false;
            chklstbox_usuarios.Enabled = true;

            if (modo != "Alta")
            {
                txt_descripcion.Text = oGrupo.GRU_DESCRIPCION;
                txt_codigo.Text = oGrupo.GRU_CODIGO;
                txt_codigo.Enabled = false;

                if (modo == "Consulta")
                {
                    txt_descripcion.Enabled = false;
                    btn_guardar.Enabled = false;
                    btn_cancelar.Text = "Cerrar";
                    chklstbox_persmisos.Enabled = false;
                    chklstbox_usuarios.Enabled = false;
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
            Page.Response.Redirect("~/Seguridad/Gestion de Grupos.aspx", false);
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            if (ValidarObligatorios() == true)
            {
                oGrupo.GRU_DESCRIPCION = txt_descripcion.Text;
                oGrupo.GRU_CODIGO = txt_codigo.Text;

                oGrupo.USUARIOS.Clear();
                for (int i = 0; i < chklstbox_usuarios.Items.Count; i++)
                {
                    usuario = chklstbox_usuarios.Items[i].Text;

                    //oUsuario = oCCUGUsuarios.ObtenerUsuarioPorNyA(usuario);
                    oUsuario = oCCUGUsuarios.ObtenerUsuarioPorApellidoYNombre(usuario);

                    if (chklstbox_usuarios.Items[i].Selected == true)
                    {
                        oGrupo.USUARIOS.Add(oUsuario);
                    }
                }

                if (modo == "Alta")
                {
                    oCCUGGrupos.Agregar(oGrupo);
                }

                else
                {
                    oCCUGGrupos.Modificar(oGrupo);
                }
            }

            Page.Response.Redirect("~/Seguridad/Gestion de Grupos.aspx", false);
        }

        // Valido los datos del usuario
        private bool ValidarObligatorios()
        {
            if (oCCUGGrupos.ComprobarGrupo(txt_descripcion.Text) == true)
            {
                if (oGrupo.GRU_DESCRIPCION != txt_descripcion.Text)
                {
                    lb_error.Text = "Debe cambiar la descipción para el grupo, ya existe otro grupo con el mismo nombre.";
                    return false;
                }
            }

            if (string.IsNullOrEmpty(txt_descripcion.Text))
            {
                lb_error.Text = "Debe ingresar una descipción para el grupo.";
                return false;
            }

            if (string.IsNullOrEmpty(txt_codigo.Text))
            {
                lb_error.Text = "Debe ingresar un código para el grupo.";
                return false;
            }

            return true;
        }

        // Cargo los datos en los controles correspondientes
        private void CargaDatos()
        {
            string usuario;

            chklstbox_usuarios.DataSource = null;
            chklstbox_usuarios.DataSource = oCCUGUsuarios.ObtenerNombresDeUsuarios();
            chklstbox_usuarios.DataBind();

            chklstbox_persmisos.DataSource = null;
            chklstbox_persmisos.DataSource = oCCURPF.ObtenerPermisos();
            chklstbox_persmisos.DataBind();

            oListaFormularios = oCCURPF.obtenerFormularios();
            cmb_formularios.DataSource = oListaFormularios;
            cmb_formularios.DataBind();

            if (modo != "Alta")
            {
                for (int i = 0; i < chklstbox_usuarios.Items.Count; i++)
                {
                    usuario = chklstbox_usuarios.Items[i].Text;
                    //oUsuario = oCCUGUsuarios.ObtenerUsuarioPorNyA(usuario);
                    oUsuario = oCCUGUsuarios.ObtenerUsuarioPorApellidoYNombre(usuario);

                    foreach (Modelo_Entidades.USUARIO miUsuario in oGrupo.USUARIOS.ToList())
                    {
                        if (oUsuario.USU_CODIGO == miUsuario.USU_CODIGO)
                        {
                            chklstbox_usuarios.Items[i].Selected = true;
                        }
                    }
                }
            }
        }

        protected void cmb_formularios_SelectedIndexChanged(object sender, EventArgs e)
        {
            string formulario;
            formulario = cmb_formularios.SelectedValue.ToString();
            oFormulario = oCCURPF.obtenerFormulariopordesc(formulario);

            string permiso;

            for (int i = 0; i < chklstbox_persmisos.Items.Count; i++)
            {
                permiso = chklstbox_persmisos.Items[i].Text;
                oPermiso = oCCURPF.ObtenerPermiso(permiso);

                oListaPermisos = oCCURPF.ObtenerPermisosPorFormulario(oGrupo.GRU_CODIGO, oFormulario.FRM_DESCRIPCION);

                foreach (Modelo_Entidades.PERMISO miPermiso in oListaPermisos)
                {
                    if (miPermiso.PER_CODIGO == oPermiso.PER_CODIGO)
                    {
                        chklstbox_persmisos.Items[i].Selected = true;
                    }
                }
            }
        }
    }
}