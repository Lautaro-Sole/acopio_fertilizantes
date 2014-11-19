﻿using System;
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

        List<Modelo_Entidades.MODULO> lModulos;
        List<Modelo_Entidades.FORMULARIO> lFormularios;

        protected void Page_Init(object sender, EventArgs e)
        {
            //Compruebo si el usuario se ha logueado viendo si existe una sesión
            if (Session["sUsuario"] == null)
            {
                Response.Redirect("~/Seguridad/Login.aspx");
            }


            //Instancio a las controladoras del modulo
            oCCUGPerfiles = new Controladora.CCUGPerfiles();
            oCCUGUsuarios = new Controladora.CCUGUsuarios();
            oCCURPF = new Controladora.CCURPF();
            

            oUsuario = (Modelo_Entidades.USUARIO)Session["sUsuario"];
            // oAuditoria = new Modelo_Entidades.Auditoria_Log();
            lModulos = new List<Modelo_Entidades.MODULO>();
            lFormularios = new List<Modelo_Entidades.FORMULARIO>();

            //agregar el log de login en la otra página

            //oAuditoria.usuario = oUsuario.nombre_apellido;
            //oAuditoria.fecha = DateTime.Now;
            //oAuditoria.accion = "Ingreso al Sistema";
            //cAuditoria.AuditarLogUsuario(oAuditoria);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                user_menu.InnerText = oUsuario.USU_NOMBRE + oUsuario.USU_APELLIDO;

                HtmlGenericControl SpanFlechaUser = new HtmlGenericControl("span");

                SpanFlechaUser.Attributes.Add("class", "caret");
                user_menu.Controls.Add(SpanFlechaUser);

                //MenuItem Menu_Modulo;
                Control Menu_Formularios = FindControl("ulmenu");

                foreach (Modelo_Entidades.GRUPO oGrupo in oCCURPF.obtenerGruposUsuario(oUsuario))
                {
                    foreach (Modelo_Entidades.Modulo oModulo in cPerfil.ObtenerModulosPorGrupo(oGrupo.id))
                    {
                        if (lModulos.Contains(oModulo) == false)
                        {
                            HtmlGenericControl Formulario = new HtmlGenericControl("li");
                            //Formulario.ID = oModulo.descripcion;
                            //Formulario.InnerHtml = oModulo.descripcion;
                            //Formulario.Attributes.Add("class", "dropdown");
                            Menu_Formularios.Controls.Add(Formulario);

                            HtmlGenericControl Link_Formularios = new HtmlGenericControl("a");
                            //Link_Formularios.ID = "Link_Formularios";
                            Link_Formularios.InnerHtml = oModulo.descripcion;
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
                            lModulos.Add(oModulo);
                            ArmaFormularios(oGrupo.id, SubMenu_Formularios, oModulo);
                        }
                    }
                }
            }
        }
    }
}