using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vista
{
    public partial class frmLogin : Form
    {
        private Controladora.CCULogin oCCULogin = new Controladora.CCULogin();
        private Controladora.CCUGUsuarios oCCUGUsuarios = new Controladora.CCUGUsuarios();
        private Modelo_Entidades.USUARIO _oUsuario = new Modelo_Entidades.USUARIO();

        public Modelo_Entidades.USUARIO oUsuario
        {
            get { return _oUsuario; }
            set { _oUsuario = value; }
        }

        private static frmLogin Instancia;
        public static frmLogin ObtenerInstancia()
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmLogin();
            return Instancia;
        }
        private frmLogin()
        {
            InitializeComponent();
        }

        private bool validarObligatorios()
        {
            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                tbPassword.Focus();
                MessageBox.Show("Primero debe ingresar la contraseña.", "Obligatorios Incompletos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(tbUsuario.Text))
            {
                tbUsuario.Focus();
                MessageBox.Show("Primero debe ingresar el código de usuario.", "Obligatorios Incompletos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frmPrincipal.ObtenerInstancia().Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validarObligatorios())
            {
                _oUsuario = null;
                try
                {
                    //_oUsuario = oCCULogin.login(this.tbUsuario.Text, this.tbPassword.Text);
                    _oUsuario = Controladora.FachadaModuloSeguridad.ObtenerInstancia().RealizarLogIn(this.tbUsuario.Text, this.tbPassword.Text);
                }
                catch (System.Data.DataException ex)
                {
                    MessageBox.Show("Error de conexión a la base de datos: " + ex.InnerException.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (_oUsuario != null)
                {
                    if (_oUsuario.USU_CLAVE == this.tbPassword.Text) //si el usuario devuelto tiene la clave igual a la que ingresaron en el textbox
                    {
                        MessageBox.Show("Contraseña errónea.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.tbPassword.Text = "";
                        this.tbPassword.Focus();
                    }
                    else
                    {
                        /*
                        frmPrincipal.ObtenerInstancia().armarMenu(_oUsuario);
                        frmPrincipal.ObtenerInstancia().Show();
                        this.Close();
                        */

                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    MessageBox.Show("Usuario inexistente.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnResetearPassword_Click(object sender, EventArgs e)
        {
            frmRegenerarClave.ObtenerInstancia().ShowDialog();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            frmPrincipal.ObtenerInstancia().Hide();
        }

        private void CheckKeys(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.btnAceptar.PerformClick();
            }
        }

    }
}
