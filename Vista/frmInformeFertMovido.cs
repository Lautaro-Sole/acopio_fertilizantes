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
    public partial class frmInformeFertMovido : Form
    {
        private static frmInformeFertMovido Instancia;

        BindingSource bsClientesYCantidadDeFertilizanteMovido = new BindingSource();
        Controladora.CCUInformes oCCUInformes = new Controladora.CCUInformes();

        Modelo_Entidades.USUARIO oUsuarioActual;

         public static frmInformeFertMovido ObtenerInstancia(Modelo_Entidades.USUARIO oUsu)
         {
             if (Instancia == null || Instancia.IsDisposed == true)
                 Instancia = new frmInformeFertMovido(oUsu);
             return Instancia;
         }

        private frmInformeFertMovido(Modelo_Entidades.USUARIO oUsu)
        {
            InitializeComponent();
            oUsuarioActual = oUsu;
            this.FertilizanteMovido_ClientesTableAdapter.ClearBeforeFill = true;
            DateTime fechainicial= new DateTime(2012, 1, 1, 0, 0, 0);
            DateTime fechafinal= new DateTime(2013, 7, 1, 0, 0, 0);
            this.FertilizanteMovido_ClientesTableAdapter.Fill(this.DataSetInformes.FertilizanteMovido_Clientes, fechainicial, fechafinal);
            //this.rvFertilizanteMovido.LocalReport.DisplayName = "Fertilizante Movido - Desde Enero de 2012 a Diciembre de 2013";
        }

        public frmInformeFertMovido()
        {
            InitializeComponent();
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(dtpAnio.Text))
            {
                MessageBox.Show("Primero debe elegir un año.", "Faltan datos.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpAnio.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(cbSemestre.Text))
            {
                MessageBox.Show("Primero debe elegir un semestre.", "Faltan datos.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbSemestre.Focus();
                return false;
            }
            return true;
        }


        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {

                //establecer los meses
                //int mesinicial, mesfinal;
                DateTime fechainicial, fechafinal;
                if (cbSemestre.Text=="Primero")
                {
                    fechainicial = new DateTime(this.dtpAnio.Value.Year, 1, 1, 0, 0, 0);
                    fechafinal = new DateTime(this.dtpAnio.Value.Year, 6, 30, 23, 59, 59);
                    //mesinicial =1;
                    //mesfinal=6;
                }
                else
                {
                    fechainicial = new DateTime(this.dtpAnio.Value.Year, 7, 1, 0, 0, 0);
                    fechafinal = new DateTime(this.dtpAnio.Value.Year, 12, 31, 23, 59, 59);
                    //mesinicial=7;
                    //mesfinal=12;
                }

                try
                {
                    this.FertilizanteMovido_ClientesTableAdapter.Fill(this.DataSetInformes.FertilizanteMovido_Clientes, fechainicial, fechafinal);
                    this.rvFertilizanteMovido.RefreshReport();
                    //bsClientesYCantidadDeFertilizanteMovido.DataSource= oCCUInformes.ObtenerMayorCantidadDeFertilizanteMovido(10, Convert.ToInt32(dtpAnio.Text), mesinicial, Convert.ToInt32(dtpAnio.Text), mesfinal);
                    //dgvCantidadFertMovido.DataSource = bsClientesYCantidadDeFertilizanteMovido;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " +ex.Message, "Excepción.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInformeFertMovido_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSetInformes.FertilizanteMovido_Clientes' Puede moverla o quitarla según sea necesario.
            //this.FertilizanteMovido_ClientesTableAdapter.Fill(this.DataSetInformes.FertilizanteMovido_Clientes);
            dtpAnio.Format = DateTimePickerFormat.Custom;
            dtpAnio.CustomFormat = "yyyy";
            dtpAnio.ShowUpDown = true;

            //if (DateTime.Today >= 01-01)
            this.cbSemestre.SelectedIndex = 1;
            this.rvFertilizanteMovido.RefreshReport();
           
            //this.rvFertilizanteMovido.Name = 
        }
    }
}
