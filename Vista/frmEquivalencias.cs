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
    public partial class frmEquivalencias : Form
    {
        private static frmEquivalencias Instancia;
        private Controladora.CCUCore oCCUCore = new Controladora.CCUCore();
        Modelo_Entidades.USUARIO oUsuarioActual = new Modelo_Entidades.USUARIO();
        private frmEquivalencias()
        {
            InitializeComponent();
        }
        private frmEquivalencias(Modelo_Entidades.USUARIO oUsuario)
        {
            InitializeComponent();
            oUsuarioActual = oUsuario;
        }
        public static frmEquivalencias ObtenerInstancia()
        {
            if (Instancia == null || Instancia.IsDisposed == true)
            {
                Instancia = new frmEquivalencias();
            }
            return Instancia;
        }

        public static frmEquivalencias ObtenerInstancia(Modelo_Entidades.USUARIO oUsuario)
        {
            if (Instancia == null || Instancia.IsDisposed == true)
            {
                Instancia = new frmEquivalencias(oUsuario);
            }
            return Instancia;
        }

        private void lblKilogramos_Click(object sender, EventArgs e)
        {

        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(this.msktbBolsas.Text) & string.IsNullOrEmpty(this.msktbKilogramos.Text) & string.IsNullOrEmpty(this.msktbMetrosCuadrados.Text))
            {
                MessageBox.Show("Ingrese alguna unidad para convertir.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //si cualquier combinación de dos cajas está ocupada
            if ((!string.IsNullOrEmpty(this.msktbBolsas.Text) & !string.IsNullOrEmpty(this.msktbKilogramos.Text)) || (!string.IsNullOrEmpty(this.msktbBolsas.Text) & !string.IsNullOrEmpty(this.msktbMetrosCuadrados.Text)) || (!string.IsNullOrEmpty(this.msktbMetrosCuadrados.Text) & !string.IsNullOrEmpty(this.msktbKilogramos.Text)))
            {
                MessageBox.Show("Ingrese sólo un dato.", "Demasiados datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }

        private void btnConvertir_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (!string.IsNullOrEmpty(this.msktbBolsas.Text))
                {
                    this.msktbKilogramos.Text = oCCUCore.ConvertirBolsasaKG(Convert.ToInt32(this.msktbBolsas.Text)).ToString();
                    this.msktbMetrosCuadrados.Text = oCCUCore.ConvertirBolsasaM2(Convert.ToInt32(this.msktbBolsas.Text)).ToString();
                }
                else
                {
                    if (!string.IsNullOrEmpty(this.msktbKilogramos.Text))
                    {
                        this.msktbBolsas.Text = oCCUCore.ConvertirKGaBolsas(Convert.ToInt32(this.msktbKilogramos.Text)).ToString();
                        this.msktbMetrosCuadrados.Text = oCCUCore.ConvertirKGaM2(Convert.ToInt32(this.msktbKilogramos.Text)).ToString();
                    }
                    else
                    {
                        this.msktbBolsas.Text = oCCUCore.ConvertirM2aBolsas(Convert.ToInt32(this.msktbMetrosCuadrados.Text)).ToString();
                        this.msktbKilogramos.Text = oCCUCore.ConvertirM2aKG(Convert.ToInt32(this.msktbMetrosCuadrados.Text)).ToString();
                    }
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
