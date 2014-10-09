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
    public partial class frmCargaYDescarga : Form
    {
        private static frmCargaYDescarga Instancia;
        private BindingSource bsOperaciones=new BindingSource();
        private Controladora.CCUCore oCCUCore = new Controladora.CCUCore();
        private Modelo_Entidades.Operacion oOperacion;


        Controladora.CCURPF oCCURPF = new Controladora.CCURPF();
        Modelo_Entidades.FORMULARIO oForm;
        List<Modelo_Entidades.PERFIL> collPerfilesObtenidos;

        Modelo_Entidades.USUARIO oUsuarioActual;
        private frmCargaYDescarga(Modelo_Entidades.USUARIO oUsu)
        {
            InitializeComponent();
            oUsuarioActual = oUsu;
        }
        public static frmCargaYDescarga ObtenerInstancia(Modelo_Entidades.USUARIO oUsu)
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmCargaYDescarga(oUsu);
            return Instancia;
        }

        private void frmCargaYDescarga_Load(object sender, EventArgs e)
        {
            ActualizarDGVOperaciones();
            this.ArmaPerfil(oUsuarioActual, this.Name);
            this.dgvOperaciones.Columns[0].HeaderText = "Estado";
            this.dgvOperaciones.Columns[1].HeaderText = "Fecha y Hora de inicio";
            this.dgvOperaciones.Columns[2].HeaderText = "Fecha y Hora de fin";
            this.dgvOperaciones.Columns[3].HeaderText = "Peso Inicial";
            this.dgvOperaciones.Columns[4].HeaderText = "Peso Final";
            this.dgvOperaciones.Columns[5].HeaderText = "Tara";
            this.dgvOperaciones.Columns[6].Visible = false;
            this.dgvOperaciones.Columns[7].HeaderText = "Notas";
            this.dgvOperaciones.Columns[8].HeaderText = "Transporte";
            this.dgvOperaciones.Columns[9].HeaderText = "Alquiler";

        }
        public void ActualizarDGVOperaciones()
        {
            //bsOperaciones.DataSource = oCCUCore.ObtenerOperaciones(_tipo_matricula: null, _nro_matricula: null, _tipo_operacion: null, _estado: "Autorizado", _nombre_cliente: null, _nombre_chofer: null);
            bsOperaciones.DataSource = oCCUCore.ObtenerOperaciones();
            dgvOperaciones.DataSource = bsOperaciones;
        }
        protected void ArmaPerfil(Modelo_Entidades.USUARIO oUsuarioActual, string nombre_formulario)
        {
            /*
            Controladora.CCURPF oCCURPF = new Controladora.CCURPF();
            Modelo_Entidades.FORMULARIO oForm = oCCURPF.obtenerFormulario(frmGrupos.ObtenerInstancia().Name);
            List<Modelo_Entidades.PERFIL> collPerfilesObtenidos = oCCURPF.recuperarPerfilForm(oUsuarioActual, oForm);
            */
            /*
            oForm = oCCURPF.obtenerFormulario(frmGrupos.ObtenerInstancia().Name);
            collPerfilesObtenidos = oCCURPF.recuperarPerfilForm(oUsuarioActual, oForm);
            if (collPerfilesObtenidos.Find(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return oPerfilBuscado.PER_CODIGO == "A"; }) != null)
            {
                this.btnbtnAutorizarCargaDescarga.Enabled = true;
            }
            if (collPerfilesObtenidos.Find(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return oPerfilBuscado.PER_CODIGO == "B"; }) != null)
            {
                this.btnEliminar.Enabled = true;
            }
            if (collPerfilesObtenidos.Find(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return oPerfilBuscado.PER_CODIGO == "M"; }) != null)
            {
                this.btnModificar.Enabled = true;
            }
             * */
        }

        private void btnRegistrarCarga_Click(object sender, EventArgs e)
        {
            if (bsOperaciones.Current == null)
            {
                MessageBox.Show("Primero debe elegir una operación.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                oOperacion = (Modelo_Entidades.Operacion)bsOperaciones.Current;
                if (oOperacion.estado != "Autorizado")
                {
                    MessageBox.Show("La operación seleccionada aún no ha sido autorizada o ya ha sido terminada.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    frmCargaDescarga.ObtenerInstancia(oUsuarioActual, oOperacion).Show();
                }
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

        }

    }
}
