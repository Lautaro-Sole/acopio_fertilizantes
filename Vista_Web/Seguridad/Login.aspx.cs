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
        // Declaro las variables a utilizar en el formualario
        Controladora.CCULogin oCCULogin;
        //Controladora.cUsuario cUsuario;
        Modelo_Entidades.USUARIO oUSUARIO;
        //Controladora.cGrupo cGrupo;

        //revisar luego
        public Modelo_Entidades.USUARIO UsuarioLogin
        {
            get { return oUSUARIO; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Creo una controladora de usuario para trabajarla durante el formulario
            //cUsuario = Controladora.cUsuario.ObtenerInstancia();
            //cGrupo = Controladora.cGrupo.ObtenerInstancia();

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
            oUSUARIO = new Modelo_Entidades.USUARIO();
            oCCULogin = new Controladora.CCULogin();

            try
            {
                oUSUARIO = oCCULogin.login(txt_nombreUsuario.Text, txt_contraseña.Text);
                Session["sUsuario"] = oUSUARIO;
                Page.Response.Redirect("~/Principal.aspx");
            }

            catch (Exception Exc)
            {
                message.Visible = true;
                lb_error.Text = Exc.Message;
            }
        }
        }
}

 