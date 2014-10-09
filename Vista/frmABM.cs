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
    partial class frmABM : Form
    {

        //private static frmABM Instancia;
        /*public static frmABM ObtenerInstancia()
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmABM();
            return Instancia;
        }
        */
        public frmABM()
        {
            InitializeComponent();
        }

        Controladora.CCURPF oCCURPF = new Controladora.CCURPF();
        Modelo_Entidades.FORMULARIO oForm;
        List<Modelo_Entidades.PERFIL> collPerfilesObtenidos;

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected virtual void btnFiltrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Erorr", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        protected void ArmaPerfil(Modelo_Entidades.USUARIO oUsuarioActual, string nombre_formulario)
        {
            /*
            Controladora.CCURPF oCCURPF = new Controladora.CCURPF();
            Modelo_Entidades.FORMULARIO oForm = oCCURPF.obtenerFormulario(frmGrupos.ObtenerInstancia().Name);
            List<Modelo_Entidades.PERFIL> collPerfilesObtenidos = oCCURPF.recuperarPerfilForm(oUsuarioActual, oForm);
            */
            oForm = oCCURPF.obtenerFormulario(nombre_formulario);
            collPerfilesObtenidos = oCCURPF.recuperarPerfilForm(oUsuarioActual, oForm);
            if (collPerfilesObtenidos.Find(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return oPerfilBuscado.PER_CODIGO == "A"; }) != null)
            {
                this.btnAgregar.Enabled = true;
            }
            if (collPerfilesObtenidos.Find(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return oPerfilBuscado.PER_CODIGO == "B"; }) != null)
            {
                this.btnEliminar.Enabled = true;
            }
            if (collPerfilesObtenidos.Find(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return oPerfilBuscado.PER_CODIGO == "M"; }) != null)
            {
                this.btnModificar.Enabled = true;
            }
        }


    }
}
