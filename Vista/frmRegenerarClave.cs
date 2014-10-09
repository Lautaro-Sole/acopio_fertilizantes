using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Vista
{
    public partial class frmRegenerarClave : Form
    {
        private Controladora.CCURecuperarClave oCCURecuperarClave = new Controladora.CCURecuperarClave();
        private Modelo_Entidades.USUARIO oUsuario;
        private static frmRegenerarClave Instancia;
        public static frmRegenerarClave ObtenerInstancia()
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmRegenerarClave();
            return Instancia;
        }
        private frmRegenerarClave()
        {
            InitializeComponent();
        }
        public static frmRegenerarClave ObtenerInstancia(Modelo_Entidades.USUARIO oUsuario)
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmRegenerarClave(oUsuario);
            return Instancia;
        }
        private frmRegenerarClave(Modelo_Entidades.USUARIO oUsuario)
        {
            InitializeComponent();
            
        }


        public bool validarObligatorios()
        {
            if (string.IsNullOrEmpty(this.tbUsuario.Text))
            {
                this.tbEMail.Focus();
                MessageBox.Show("Primero debe escribir el nombre de usuario.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(this.tbEMail.Text))
            {
                this.tbEMail.Focus();
                MessageBox.Show("Primero debe escribir el E-Mail del usuario.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string expresionregular = @"^((([\w]+\.[\w]+)+)|([\w]+))@(([\w]+\.)+)([A-Za-z]{1,3})$";
            if (!(Regex.IsMatch(this.tbEMail.Text, expresionregular))) //si el mail no concuerda con la expresion regular
            {
                this.tbEMail.Focus();
                MessageBox.Show("El E-Mail ingresado tiene un formato incorrecto.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validarObligatorios())
            {
                //oUsuario = oCCURecuperarClave.obtenerUsuario(this.tbUsuario.Text, this.tbEMail.Text);
                oUsuario = Controladora.FachadaModuloSeguridad.ObtenerInstancia().ObtenerUsuario(this.tbUsuario.Text, this.tbEMail.Text);
                if (oUsuario != null)
                {
                    if (oUsuario.USU_ESTADO != false)
                    {
                        Controladora.CCUGUsuarios oCCUGUsuarios= new Controladora.CCUGUsuarios();
                        try
                        {
                            //bool resultado = oCCUGUsuarios.ResetearClave(oUsuario);
                            bool resultado = Controladora.FachadaModuloSeguridad.ObtenerInstancia().ResetearClave(oUsuario);
                            if (resultado)
                            {
                                MessageBox.Show("Contraseña reseteada con éxito.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //frmUsuarios.ObtenerInstancia().cargarGrillaUsuarios();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Contraseña no reseteada.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }
                        catch (System.Data.EntitySqlException ex)
                        {
                            MessageBox.Show("No se ha podido resetear la contraseña: " + ex.InnerException.Message + ".", "Error de base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Datos Inválidos.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); //usuario inactivo
                    }
                }
                else
                {
                    MessageBox.Show("Datos Inválidos.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);//usuario inexistente
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
