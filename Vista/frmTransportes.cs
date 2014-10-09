using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vista
{
    internal partial class frmTransportes : Vista.frmABM
    {
        private static frmTransportes Instancia;
        private Controladora.CCUGTransportes oCCUGTransportes = new Controladora.CCUGTransportes();
        private BindingSource bsTransportes = new BindingSource();
        private Modelo_Entidades.Transporte oTransporte;

        Modelo_Entidades.USUARIO oUsuarioActual;
        private frmTransportes(Modelo_Entidades.USUARIO oUsu)
        {
            InitializeComponent();
            oUsuarioActual = oUsu;
        }
        public static frmTransportes ObtenerInstancia(Modelo_Entidades.USUARIO oUsu)
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmTransportes(oUsu);
            return Instancia;
        }
        public static frmTransportes ObtenerInstancia()
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmTransportes();
            return Instancia;
        }
        private frmTransportes()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmTransporte ofrmTransporte = new frmTransporte();
            ofrmTransporte.Show();
        }

        private void frmTransportes_Load(object sender, EventArgs e)
        {
            this.ArmaPerfil(oUsuarioActual, this.Name);

            ActualizarDGVTransportes();
        }

        public void ActualizarDGVTransportes()
        {
            bsTransportes.DataSource = oCCUGTransportes.ObtenerTransportes();
            dgvTransportes.DataSource = bsTransportes;

            this.dgvTransportes.Columns[0].Visible = false; //esconder id de transporte
            this.dgvTransportes.Columns[5].Visible = false; //esconder operaciones
            this.dgvTransportes.Columns[6].Visible = false; //esconder choferes
            this.dgvTransportes.Columns[1].HeaderText = "Número de Matrícula";
            this.dgvTransportes.Columns[2].HeaderText = "Carga máxima (en Kg)";
            this.dgvTransportes.Columns[3].HeaderText = "Tara (en Kg)";
            this.dgvTransportes.Columns[4].HeaderText = "Tipo de Matrícula";

        }

        private bool ComprobarRelaciones()
        {
            if ((oTransporte.Choferes.Count == 0) && (oTransporte.Operaciones.Count == 0))
                return true;
            else return false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oTransporte = (Modelo_Entidades.Transporte)bsTransportes.Current;
            if (oTransporte == null)
            {
                MessageBox.Show("Primero debe elegir un transporte.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult oDialogResult = MessageBox.Show("¿Está seguro que desea eliminar el transporte seleccionado?", "Confirmar eliminar.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oDialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (ComprobarRelaciones())
                        {
                            bool resultado = oCCUGTransportes.Eliminar(oTransporte);
                            if (resultado)
                            {
                                MessageBox.Show("Transporte eliminado correctamente.", "Resultado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ActualizarDGVTransportes();
                            }
                            else
                            {
                                MessageBox.Show("El transporte no se pudo eliminar.", "Resultado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el transporte porque estuvo involucrado en una operación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (EntitySqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Excepción.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            oTransporte = (Modelo_Entidades.Transporte)bsTransportes.Current;
            if (oTransporte == null)
            {
                MessageBox.Show("Primero debe elegir un transporte.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmTransporte ofrmTransporte = new frmTransporte(oTransporte);
                ofrmTransporte.Show();
            }
            
        }

        protected override void btnFiltrar_Click(object sender, EventArgs e)
        {
            bsTransportes.DataSource = oCCUGTransportes.ObtenerTransportes(this.cbTipo_Matricula.Text, this.tbNum_Matricula.Text, this.tbNombreCliente.Text, this.tbNombreChofer.Text);
            dgvTransportes.DataSource = bsTransportes;
        }

        
    }
}
