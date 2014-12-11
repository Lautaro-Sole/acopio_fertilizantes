using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista_Web.Seguridad
{
    public partial class RegenerarClave : System.Web.UI.Page
    {
        Modelo_Entidades.USUARIO oUsuario;
        Controladora.CCUGUsuarios oCCUGUsuarios;

        string usuario;

         // Constructor
        public RegenerarClave()
        {
            oCCUGUsuarios = Controladora.CCUGUsuarios.ObtenerInstancia();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            usuario = Server.UrlDecode(Request.QueryString["usuario"]);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Valido los datos
        public bool ValidarDatos()
        {
            oUsuario = oCCUGUsuarios.ObtenerUsuario(this.txt_nombreusuario.Text);

            if (string.IsNullOrEmpty(this.txt_email.Text))
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar el email del usuario";
                return false;
            }

            if (this.txt_email.Text != oUsuario.USU_EMAIL)
            {
                message.Visible = true;
                lb_error.Text = "El e-mail no pertenece al usuario introducido";
                return false;
            }

            string expresionregular = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            if (!(Regex.IsMatch(this.txt_email.Text, expresionregular))) //si el mail no concuerda con la expresion regular
            {
                message.Visible = true;
                lb_error.Text = "El E-Mail ingresado tiene un formato incorrecto.";
                return false;
            }
            return true;
        }

        protected void btn_recuperarclave_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                oUsuario = oCCUGUsuarios.ObtenerUsuario(this.txt_nombreusuario.Text);
                if (oUsuario != null)
                {
                    if (oUsuario.USU_ESTADO != false)
                    {
                        try
                        {
                            oCCUGUsuarios.ResetearClave(oUsuario);
                            message.Visible = true;
                            lb_error.Text = "Contraseña regenerada con éxito. Revise su correo para volver a ingresar";
                        }

                        catch (System.Data.EntitySqlException ex)
                        {
                            message.Visible = true;
                            lb_error.Text = "No se ha podido resetear la contraseña: " + ex.InnerException.Message + ".";
                        }
                    }
                    else
                    {
                        message.Visible = true;
                        lb_error.Text = "El usuario ingresado está deshabilitado.";
                    }
                }
                else
                {
                    message.Visible = true;
                    lb_error.Text = "El usuario ingresado no existe.";
                }
            }
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/Seguridad/Login.aspx");
        }
    }
}