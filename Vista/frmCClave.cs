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
    public partial class frmCClave : Form
    {
        private static frmCClave Instancia;
        private Modelo_Entidades.USUARIO oUsuarioActual;
        private Controladora.CCUCClave oCCUCClave = new Controladora.CCUCClave();
        private frmCClave(Modelo_Entidades.USUARIO oUsu)
        {
            InitializeComponent();
            oUsuarioActual = oUsu;
        }
        public static frmCClave ObtenerInstancia(Modelo_Entidades.USUARIO oUsu)
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmCClave(oUsu);
            return Instancia;
        }


        private frmCClave()
        {
            InitializeComponent();
        }



        private bool validarObligatorios()
        {
            if (string.IsNullOrEmpty(this.tbClaveActual.Text))
            {
                this.tbClaveActual.Focus();
                MessageBox.Show("Primero debe ingresar la clave actual.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(this.tbClaveNueva.Text))
            {
                this.tbClaveNueva.Focus();
                MessageBox.Show("Primero debe ingresar la clave nueva.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(this.tbClaveNueva2.Text))
            {
                this.tbClaveNueva2.Focus();
                MessageBox.Show("Primero debe volver a ingresar la clave nueva.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool validarClaveNueva()
        {
            if (tbClaveNueva.Text != tbClaveNueva2.Text)
            {
                MessageBox.Show("Las claves nuevas no coinciden.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validarObligatorios())
            {
                if (validarClaveNueva())
                {
                    try
                    {
                        bool resultado = oCCUCClave.cambiarClave(this.tbClaveActual.Text, this.tbClaveNueva.Text, oUsuarioActual);
                        if (resultado)
                        {
                            MessageBox.Show("Clave cambiada exitosamente.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("La clave no se pudo cambiar.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch(System.Data.DataException ex)
                    {
                        MessageBox.Show("No se pudo cambiar la clave. Excepción: " + ex.InnerException.Message, "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCClave_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("El usuario es : " + oUsuarioActual.USU_NOMBRE + " y su email es : " + oUsuarioActual.USU_EMAIL + ".", "Usuario Actual", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
