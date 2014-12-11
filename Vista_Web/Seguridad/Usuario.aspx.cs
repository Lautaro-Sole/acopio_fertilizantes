using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using AjaxControlToolkit;

namespace Vista_Web.Seguridad
{
    public partial class Usuario : System.Web.UI.Page
    {
        // Declaro las variables que voy a utilizar en el formulario.
        string modo;
        string usuario;
        Controladora.CCUGUsuarios oCCUGUsuarios;
        Controladora.CCUGGrupos oCCUGGrupos;
        Modelo_Entidades.USUARIO oUsuario;
        Modelo_Entidades.GRUPO oGrupo;
        string grupo;
        string clave;

        // Constructor
        public Usuario()
        {
            oCCUGUsuarios = Controladora.CCUGUsuarios.ObtenerInstancia();
            oCCUGGrupos = Controladora.CCUGGrupos.ObtenerInstancia();

        }

        //evento que se ejecuta antes de llamar al load
        protected void Page_Init(object sender, EventArgs e)
        {
            usuario = Server.UrlDecode(Request.QueryString["usuario"]);
            modo = Server.UrlDecode(Request.QueryString["modo"]);


            if (usuario == "nuevo")
            {
                oUsuario = new Modelo_Entidades.USUARIO();
            }

            else
            {
                oUsuario = oCCUGUsuarios.ObtenerUsuario(usuario);
            }

            message.Visible = false;

            txt_nuevacontraseña.Enabled = false;
            txt_repetircontraseña.Enabled = false;
            txt_contraseña_actual.Enabled = false;
            btn_cambiarpass.Enabled = false;

            if (modo != "Alta")
            {
                txt_apellido.Text = oUsuario.USU_APELLIDO;
                txt_nombre.Text = oUsuario.USU_NOMBRE;
                txt_email.Text = oUsuario.USU_EMAIL;
                txt_nombreusuario.Text = oUsuario.USU_CODIGO;
                chk_estado.Checked = (bool)oUsuario.USU_ESTADO;

                if (modo == "Consulta") 
                {
                    txt_apellido.Enabled = false;
                    txt_nombre.Enabled = false;
                    txt_nombreusuario.Enabled = false;
                    txt_email.Enabled = false;
                    btn_guardar.Enabled = false;
                    btn_cancelar.Text = "Cerrar";
                    chk_estado.Enabled = false;
                    chklstbox_grupos.Enabled = false;
                    btn_cambiarpass.Enabled = false;
                }

                else
                {
                    chk_estado.Enabled = true;
                    btn_cambiarpass.Enabled = true;
                }
            }

            else
            {
                txt_nuevacontraseña.Enabled = true;
                txt_repetircontraseña.Enabled = true;
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
            Page.Response.Redirect("~/Seguridad/Gestion de Usuarios.aspx");
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {

            if (ValidarObligatorios() == true)
            {
                oUsuario.USU_APELLIDO = txt_apellido.Text;
                oUsuario.USU_NOMBRE = txt_nombre.Text;
                oUsuario.USU_EMAIL = txt_email.Text;
                oUsuario.USU_CODIGO = txt_nombreusuario.Text;
                oUsuario.USU_ESTADO = chk_estado.Checked;
                clave = oCCUGUsuarios.generarClaveAleatoria(8, false);
                


                oUsuario.GRUPOS.Clear();

                for (int i = 0; i < chklstbox_grupos.Items.Count; i++)
                {
                    grupo = chklstbox_grupos.Items[i].Text;
                    oGrupo = oCCUGGrupos.ObtenerGrupo(grupo);

                    if (chklstbox_grupos.Items[i].Selected == true)
                    {
                        oUsuario.GRUPOS.Add(oGrupo);
                    }
                }

                if (modo == "Alta")
                {
                    oUsuario.USU_CLAVE = clave;
                    oCCUGUsuarios.EnviarCorreo(oUsuario);
                    oUsuario.USU_CLAVE = oCCUGUsuarios.EncriptarClave(clave);
                    oCCUGUsuarios.Agregar(oUsuario);
                    Page.Response.Redirect("~/Seguridad/Gestion de Usuarios.aspx");
                }

                else
                {
                    //oUsuario.USU_CLAVE = oCCUGUsuarios.EncriptarClave(txt_nuevacontraseña.Text);
                    oCCUGUsuarios.Modificar(oUsuario);
                    Page.Response.Redirect("~/Seguridad/Gestion de Usuarios.aspx");
                }
            }
        }

        // Valido los datos del usuario
        private bool ValidarObligatorios()
        {
            if (string.IsNullOrEmpty(txt_apellido.Text))
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar el apellido del usuario";
                return false;
            }

            if (string.IsNullOrEmpty(txt_nombre.Text))
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar el nombre del usuario";
                return false;
            }

            if (string.IsNullOrEmpty(txt_email.Text))
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar el e-mail del usuario";
                return false;
            }

            string expresionregular = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            if (!(Regex.IsMatch(this.txt_email.Text, expresionregular))) //si el mail no concuerda con la expresion regular
            {
                message.Visible = true;
                this.txt_email.Focus();
                lb_error.Text = "El E-Mail ingresado tiene un formato incorrecto.";
                return false;
            }

            if (string.IsNullOrEmpty(txt_nombreusuario.Text))
            {
                message.Visible = true;
                lb_error.Text = "Debe ingresar el nombre de usuario";
                return false;
            }

            if (oCCUGUsuarios.ObtenerUsuario(txt_nombreusuario.Text) != null)
            {
                //if (oUsuario.USU_CODIGO != txt_nombreusuario.Text)
                //{
                    message.Visible = true;
                    lb_error.Text = "Debe ingresar otro usuario ya que el nombre no se encuentra disponible";
                    return false;
                //}
            }

            //if (string.IsNullOrEmpty(txt_nuevacontraseña.Text) || string.IsNullOrEmpty(txt_repetircontraseña.Text) || string.IsNullOrEmpty(txt_nuevacontraseña.Text))
            //{
            //    if (modo != "Alta" && txt_contraseña_actual.Enabled == true)
            //    {
            //        if (string.IsNullOrEmpty(txt_nuevacontraseña.Text) && string.IsNullOrEmpty(txt_repetircontraseña.Text) && string.IsNullOrEmpty(txt_nuevacontraseña.Text))
            //        {
            //            message.Visible = true;
            //            lb_error.Text = "Debe ingresar una contraseña, ya que o no las ha ingresado, o no coinciden";
            //            return false;
            //        }

            //        else if (oCCUGUsuarios.EncriptarClave(txt_contraseña_actual.Text) != oUsuario.USU_CLAVE || string.IsNullOrEmpty(txt_contraseña_actual.Text))
            //        {
            //            message.Visible = true;
            //            lb_error.Text = "La contraseña actual es incorrecta, por favor introduscula nuevamente";
            //            return false;
            //        }
            //    }
            //}

            //if (modo != "Alta" && txt_contraseña_actual.Enabled == true)
            //{
            //    if (oCCUGUsuarios.EncriptarClave(txt_contraseña_actual.Text) != oUsuario.USU_CLAVE || string.IsNullOrEmpty(txt_contraseña_actual.Text) || txt_nuevacontraseña.Text != txt_repetircontraseña.Text)
            //    {
            //        message.Visible = true;
            //        lb_error.Text = "La contraseña actual es incorrecta o las claves no coinciden, por favor introdusca los datos nuevamente";
            //        return false;
            //    }
            //}

            //if (modo == "Alta")
            //{
            //    if (string.IsNullOrEmpty(txt_nuevacontraseña.Text) || string.IsNullOrEmpty(txt_repetircontraseña.Text) || txt_nuevacontraseña.Text != txt_repetircontraseña.Text)
            //    {
            //        message.Visible = true;
            //        lb_error.Text = "No ha introducido una contraseña o las claves no coinciden, por favor introdusca los datos nuevamente";
            //        return false;
            //    }
            //}

            if (chklstbox_grupos.SelectedIndex == -1)
            {
                message.Visible = true;
                lb_error.Text = "Debe elegir al menos un grupo para el usuario";
                return false;
            }

            return true;
        }

        // Cargo los datos en los controles correspondientes
        private void CargaDatos()
        {
            chklstbox_grupos.DataSource = null;
            chklstbox_grupos.DataSource = oCCUGGrupos.ObtenerGrupos();
            chklstbox_grupos.DataBind();

            if (modo != "Alta")
            {
                for (int i = 0; i < chklstbox_grupos.Items.Count; i++)
                {
                    grupo = chklstbox_grupos.Items[i].Text;
                    oGrupo = oCCUGGrupos.ObtenerGrupo(grupo);
                    foreach (Modelo_Entidades.GRUPO miGrupo in oUsuario.GRUPOS.ToList())
                    {
                        if (oGrupo.GRU_CODIGO == miGrupo.GRU_CODIGO)
                        {
                            chklstbox_grupos.Items[i].Selected = true;
                        }
                    }
                }
            }
        }

        protected void btn_cambiarpass_Click(object sender, EventArgs e)
        {
            txt_nuevacontraseña.Enabled = true;
            txt_repetircontraseña.Enabled = true;
            txt_contraseña_actual.Enabled = true;
            btn_cambiarpass.Enabled = false;
        }
    }
}