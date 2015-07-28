using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista_Web.Seguridad
{
    public partial class Login : System.Web.UI.Page
    {
        Controladora.CCULogin oCCULogin;
        Controladora.FachadaModuloSeguridad oFachada;
        Modelo_Entidades.USUARIO oUsuario;
        //Controladora.cGrupo cGrupo;

        //revisar luego
        public Modelo_Entidades.USUARIO UsuarioLogin
        {
            get { return oUsuario; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            message.Visible = false;
        }
        // Valido los datos obligatorios
        private bool ValidarObligatorios()
        {
            if (txt_nombreUsuario.Text == "")
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar un usuario";
                return false;
            }

            else if (txt_contraseña.Text == "")
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar una contraseña";
                return false;
            }

            else
            {
                return true;
            }
        }
    
    protected void btn_ingresa_Click(object sender, EventArgs e)
        {
            // Ingreso al sistema - 
            ValidarObligatorios();
            oUsuario = new Modelo_Entidades.USUARIO();
            oFachada = Controladora.FachadaModuloSeguridad.ObtenerInstancia();
            oCCULogin = new Controladora.CCULogin();

            try
            {
                oUsuario = oFachada.RealizarLogIn(txt_nombreUsuario.Text, txt_contraseña.Text);
                //oUsuario = oCCULogin.login(txt_nombreUsuario.Text, txt_contraseña.Text);
                Session["sUsuario"] = oUsuario;
                Page.Response.Redirect("~/Principal.aspx", false);
            }

            catch (Exception Exc)
            {
                message.Visible = true;
                lb_error.Text = Exc.Message;
            }
        }
        }
}

 