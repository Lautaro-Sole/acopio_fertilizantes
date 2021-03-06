﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using AjaxControlToolkit;

namespace Vista_Web.Seguridad
{
    public partial class Cambiar_Clave : System.Web.UI.Page
    {
        // Declaro las variables que voy a utilizar en el formulario.
        //string modo;
        string usuario;
        Controladora.CCUGUsuarios oCCUGUsuario;
        //Controladora.cGrupo cGrupo;
        Modelo_Entidades.USUARIO oUsuario;
        //Modelo_Entidades.Grupo oGrupo;
        //string grupo;

        // Constructor
        public Cambiar_Clave()
        {
            oCCUGUsuario = Controladora.CCUGUsuarios.ObtenerInstancia();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            usuario = Server.UrlDecode(Request.QueryString["usuario"]);
            oUsuario = oCCUGUsuario.ObtenerUsuario(usuario);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    this.CargaDatos();
            //}
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/Seguridad/Principal.aspx", false);
        }

        // Valido los datos del usuario
        private bool ValidarObligatorios()
        {
            if (string.IsNullOrEmpty(txt_nuevacontraseña.Text) || string.IsNullOrEmpty(txt_repetircontraseña.Text) || string.IsNullOrEmpty(txt_contraseña_actual.Text) || txt_nuevacontraseña.Text != txt_repetircontraseña.Text)
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar una contraseña, ya que o no las ha ingresado, o no coinciden";
                return false;
            }
            else if (oCCUGUsuario.EncriptarClave(txt_contraseña_actual.Text) != oUsuario.USU_CLAVE)
            {
                message.Visible = true;
                lb_error.Text = "La contraseña actual es incorrecta, por favor introduscula nuevamente";
                return false;
            }

            return true;
        }

        protected void btn_cambiarpass_Click(object sender, EventArgs e)
        {
            if (ValidarObligatorios() == true)
            {

                try
                {
                    oUsuario.USU_CLAVE = oCCUGUsuario.EncriptarClave(txt_contraseña_actual.Text);
                    oCCUGUsuario.Modificar(oUsuario);
                    message.Visible = true;
                    lb_error.Text = "La contraseña se ha modificado con éxito";
                }

                catch (Exception Exc)
                {
                    message.Visible = true;
                    lb_error.Text = Exc.InnerException.Message.ToString();
                }

            }

            else
            {
                message.Visible = true;
                lb_error.Text = "Ha habido algún error de validación";
            }
        }
    }
}