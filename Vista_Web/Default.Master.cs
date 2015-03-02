using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Vista_Web
{
    public partial class Default : System.Web.UI.MasterPage
    {

        Modelo_Entidades.USUARIO oUsuario;
        Controladora.CCUGPerfiles oCCUGPerfiles;
        Controladora.CCUGUsuarios oCCUGUsuarios;
        Controladora.CCURPF oCCURPF;
        Controladora.FachadaModuloSeguridad oFachada;

        List<Modelo_Entidades.MODULO> oListaModulos;
        List<Modelo_Entidades.FORMULARIO> oListaFormularios;
        Modelo_Entidades.Log oLog;

        protected void Page_Init(object sender, EventArgs e)
        {
            //Compruebo si el usuario se ha logueado viendo si existe una sesión
            if (Session["sUsuario"] == null)
            {
                Response.Redirect("~/Seguridad/Login.aspx");
            }

            oCCUGPerfiles = Controladora.CCUGPerfiles.ObtenerInstancia();
            oCCUGUsuarios = Controladora.CCUGUsuarios.ObtenerInstancia();
            oCCURPF = Controladora.CCURPF.ObtenerInstancia();
            oFachada = Controladora.FachadaModuloSeguridad.ObtenerInstancia();
            

            oUsuario = (Modelo_Entidades.USUARIO)Session["sUsuario"];
            oListaModulos = new List<Modelo_Entidades.MODULO>();
            oListaFormularios = new List<Modelo_Entidades.FORMULARIO>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArmarMenu();
            }
        }
        
        private void ArmarMenu()
        {
            user_menu.InnerText = oUsuario.USU_NOMBRE + " " + oUsuario.USU_APELLIDO;

            HtmlGenericControl SpanFlechaUser = new HtmlGenericControl("span");

            SpanFlechaUser.Attributes.Add("class", "caret");
            user_menu.Controls.Add(SpanFlechaUser);

            //MenuItem Menu_Modulo;
            Control Menu_Formularios = FindControl("ulmenu");

            foreach (Modelo_Entidades.GRUPO oGrupoActual in oFachada.ObtenerGrupos(oUsuario))
            {
                foreach (Modelo_Entidades.MODULO oModuloActual in oFachada.ObtenerModulos(oGrupoActual))
                {
                    if (oListaModulos.Contains(oModuloActual) == false)
                    {
                        HtmlGenericControl Formulario = new HtmlGenericControl("li");
                        //Formulario.ID = oModulo.descripcion;
                        //Formulario.InnerHtml = oModulo.descripcion;
                        //Formulario.Attributes.Add("class", "dropdown");
                        Menu_Formularios.Controls.Add(Formulario);

                        HtmlGenericControl Link_Formularios = new HtmlGenericControl("a");
                        //Link_Formularios.ID = "Link_Formularios";
                        Link_Formularios.InnerHtml = oModuloActual.MOD_DESCRIPCION;
                        Link_Formularios.Attributes.Add("class", "dropdown-toggle");
                        Link_Formularios.Attributes.Add("href", "#");
                        Link_Formularios.Attributes.Add("data-toggle", "dropdown");
                        Formulario.Controls.Add(Link_Formularios);

                        HtmlGenericControl SpanFlecha = new HtmlGenericControl("span");

                        SpanFlecha.Attributes.Add("class", "caret");
                        Link_Formularios.Controls.Add(SpanFlecha);

                        HtmlGenericControl SubMenu_Formularios = new HtmlGenericControl("ul");
                        SubMenu_Formularios.ID = "SubMenu_Formularios";
                        //SubMenu_Formularios.InnerHtml = oFormulario.nombredemuestra;
                        SubMenu_Formularios.Attributes.Add("class", "dropdown-menu");
                        SubMenu_Formularios.Attributes.Add("role", "menu");
                        Formulario.Controls.Add(SubMenu_Formularios);


                        // Inserto el objeto creado a la barra de menúes del formulario
                        //msMenu.Items.Add(Menu_Modulo);

                        // Busco las funciones asociadas al formulario
                        oListaModulos.Add(oModuloActual);
                        ArmarSubMenu(oGrupoActual, SubMenu_Formularios, oModuloActual);
                    }
                }
            }
        }

        private void ArmarSubMenu(Modelo_Entidades.GRUPO oGrupo, Control SubMenu_Formularios, Modelo_Entidades.MODULO oModulo)
        {
            // Le solicito a la controladora la lista de funciones de un módulo determinado.
            // Defino un objeto ToolStripMenuItem para asignar los permisos recuperados.
            //MenuItem SubMenu_Formularios;
            //HtmlGenericControl SubMenu_Formularios = new HtmlGenericControl("ul");

            // Recorro el listado de los permisos según el perfil

            foreach (Modelo_Entidades.FORMULARIO oFormulario in oFachada.ObtenerFormularios(oModulo))
            {
                if (oListaFormularios.Contains(oFormulario) == false)
                {
                    //SubMenu_Formularios.ID = "Link_Formulario";
                    //SubMenu_Formularios.InnerHtml = oModulo.descripcion;
                    ////Link_Formulario.Attributes.Add("href", oModulo.descripcion);
                    //SubMenu_Formularios.Attributes.Add("data-toggle", "dropdown");
                    //SubMenu_Formularios.Attributes.Add("role", "button");
                    //Formulario.Controls.Add(SubMenu_Formularios);

                    HtmlGenericControl SubFormulario = new HtmlGenericControl("li");

                    //SubFormulario.ID = "SubFormulario";
                    //SubFormulario.Attributes.Add("href", oModulo.descripcion + "/" + oFormulario.nombredemuestra + ".aspx");
                    //SubFormulario.Attributes.Add("role", "presentation");
                    SubMenu_Formularios.Controls.Add(SubFormulario);

                    HyperLink Link_SubFormulario = new HyperLink();

                    Link_SubFormulario.Text = oFormulario.FRM_DESCRIPCION;
                    Link_SubFormulario.NavigateUrl = "~/" + oModulo.MOD_DESCRIPCION + "/" + oFormulario.FRM_DESCRIPCION + ".aspx";
                    SubFormulario.Controls.Add(Link_SubFormulario);
                    oListaFormularios.Add(oFormulario);
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            oLog = new Modelo_Entidades.Log();
            oLog.USU_CODIGO = oUsuario.USU_CODIGO;
            oLog.fecha_y_hora = DateTime.Now;
            oLog.accion = "Egreso del Sistema";
            Controladora.FachadaModuloSeguridad.ObtenerInstancia().RealizarLogOut(oUsuario);
            

            Session.Abandon();
            Page.Response.Redirect("~/Seguridad/Login.aspx");
        }
    }
}