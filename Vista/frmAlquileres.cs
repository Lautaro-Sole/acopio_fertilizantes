using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vista
{
    internal partial class frmAlquileres : Vista.frmABM
    {
        private static frmAlquileres Instancia;
        private BindingSource bsAlquileres = new BindingSource();
        private Controladora.CCUGAlquileres oCCUGAlquileres = Controladora.CCUGAlquileres.ObtenerInstancia();
        private Modelo_Entidades.Alquiler oAlquiler = new Modelo_Entidades.Alquiler();

        Modelo_Entidades.USUARIO oUsuarioActual;
        private frmAlquileres(Modelo_Entidades.USUARIO oUsu)
        {
            InitializeComponent();
            oUsuarioActual = oUsu;
        }
        public static frmAlquileres ObtenerInstancia(Modelo_Entidades.USUARIO oUsu)
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmAlquileres(oUsu);
            return Instancia;
        }
        public static frmAlquileres ObtenerInstancia()
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmAlquileres();
            return Instancia;
        }
        public frmAlquileres()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAlquiler ofrmAlquiler = new frmAlquiler();
            ofrmAlquiler.Show();
        }

        public void ActualizarDGVAlquileres()
        {
            bsAlquileres.DataSource = oCCUGAlquileres.ObtenerAlquileres();
            dgvAlquileres.DataSource = bsAlquileres;
            /*
            this.dgvAlquileres.Columns[2].Visible = false; //esconder id_alquiler
            this.dgvAlquileres.Columns[5].Visible = false; //esconder Documento
            this.dgvAlquileres.Columns[0].HeaderText = "Superficie Alquilada";
            this.dgvAlquileres.Columns[1].HeaderText = "Superficie no Utilizada";
            this.dgvAlquileres.Columns[4].HeaderText = "Nombre del Almacén";
            this.dgvAlquileres.Columns[5].HeaderText = "Nombre del Cliente";
             * */
        }

        private void frmAlquileres_Load(object sender, EventArgs e)
        {
            this.ArmaPerfil(oUsuarioActual, this.Name);
            ActualizarDGVAlquileres();

            /*
            //this.dgvAlquileres.Columns[0].HeaderText = "Capacidad Utilizada";
            this.dgvAlquileres.Columns[1].Visible = true; //esconder nro_alquiler
            this.dgvAlquileres.Columns[2].Visible = true; //esconder nro_almacen
            this.dgvAlquileres.Columns[3].Visible = true; //esconder nro_cliente
            //this.dgvAlquileres.Columns[4].HeaderText = "Estado";
            //this.dgvAlquileres.Columns[5].HeaderText = "Fecha de Inicio del Alquiler";
            //this.dgvAlquileres.Columns[6].HeaderText = "Fecha de Finalización del Alquiler";
            //this.dgvAlquileres.Columns[7].HeaderText = "Capacidad (en Kg)";
            //this.dgvAlquileres.Columns[8].HeaderText = "Almacén";
            this.dgvAlquileres.Columns[9].Visible = true; //esconder alquileres_productos
            //this.dgvAlquileres.Columns[10].HeaderText = "Cliente";
            this.dgvAlquileres.Columns[11].Visible = true; //esconder Operaciones
            */

            dgvAlquileres.Columns["Almacen"].DisplayIndex = 0;
            dgvAlquileres.Columns["Cliente"].DisplayIndex = 1;
            dgvAlquileres.Columns["fecha_inicio_alquiler"].DisplayIndex = 2;
            dgvAlquileres.Columns["fecha_fin_alquiler"].DisplayIndex = 3;
            dgvAlquileres.Columns["EstadoActual"].DisplayIndex = 4;
            dgvAlquileres.Columns["DistanciaAEmpresa"].DisplayIndex = 5;
            dgvAlquileres.Columns["capacidad"].DisplayIndex = 6;
            dgvAlquileres.Columns["EspacioUtilizado"].DisplayIndex = 7;
            dgvAlquileres.Columns["CantidadBolsa"].DisplayIndex = 8;
            dgvAlquileres.Columns["CantidadGranel"].DisplayIndex = 9;


            dgvAlquileres.Columns["fecha_inicio_alquiler"].HeaderText = "Fecha de Inicio";
            dgvAlquileres.Columns["fecha_fin_alquiler"].HeaderText = "Fecha de finalización";
            dgvAlquileres.Columns["EstadoActual"].HeaderText = "Estado";
            dgvAlquileres.Columns["DistanciaAEmpresa"].HeaderText = "Distancia a la Empresa";
            dgvAlquileres.Columns["capacidad"].HeaderText = "Capacidad";
            dgvAlquileres.Columns["EspacioUtilizado"].HeaderText = "Capacidad Utilizada";
            dgvAlquileres.Columns["CantidadBolsa"].HeaderText = "Cantidad de fertilizante en bolsa (kg)";
            dgvAlquileres.Columns["CantidadGranel"].HeaderText = "Cantidad de fertilizante a granel (kg)";

            dgvAlquileres.Columns["nro_alquiler"].Visible = false;
            dgvAlquileres.Columns["estado"].Visible = false;
            dgvAlquileres.Columns["nro_almacen"].Visible = false;
            dgvAlquileres.Columns["nro_cliente"].Visible = false;
            dgvAlquileres.Columns["Alquiler_Productos"].Visible = false;
            dgvAlquileres.Columns["Operaciones"].Visible = false;

        }

        private bool ComprobarRelaciones()
        {
            if ((oAlquiler.EspacioUtilizado == 0) && (oAlquiler.Operaciones.Count == 0))
                return true;
            else return false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oAlquiler = (Modelo_Entidades.Alquiler) bsAlquileres.Current;
            if (oAlquiler == null)
            {
                MessageBox.Show("Primero debe elegir un alquiler.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult oDialogResult = MessageBox.Show("¿Está seguro que desea eliminar el alquiler seleccionado?", "Confirmar eliminar.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oDialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (ComprobarRelaciones())
                        {
                            bool resultado = oCCUGAlquileres.Eliminar(oAlquiler);
                            if (resultado)
                            {
                                MessageBox.Show("Alquiler eliminado correctamente.", "Resultado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ActualizarDGVAlquileres();
                            }
                            else
                            {
                                MessageBox.Show("El alquiler no se pudo eliminar.", "Resultado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El alquiler no se pudo eliminar porque contiene fertilizantes o estuvo involucrado en una operación.", "Resultado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (EntitySqlException ex)
                    {
                        MessageBox.Show("" + ex,"Excepción.",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            oAlquiler = (Modelo_Entidades.Alquiler) bsAlquileres.Current;
            if (oAlquiler == null)
            {
                MessageBox.Show("Primero debe elegir un alquiler.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmAlquiler ofrmAlquiler = new frmAlquiler(oAlquiler);
                ofrmAlquiler.Show();
            }
        }

        protected override void btnFiltrar_Click(object sender, EventArgs e)
        {
            string _nombre_cliente = this.tbNombreCliente.Text;
            int _distancia_maxima = new int();
            if (string.IsNullOrEmpty(this.msktbDistMaxAEmpresa.Text))
            {
                _distancia_maxima = 0;
            }
            else
            {
                _distancia_maxima = Convert.ToInt32(this.msktbDistMaxAEmpresa.Text);
            }
            int _capacidad_minima = new int();
            if (string.IsNullOrEmpty(this.msktbCapacidadNoUtilizadaMinima.Text))
            {
                _capacidad_minima = 0;
            }
            else
            {
                _capacidad_minima = Convert.ToInt32(this.msktbCapacidadNoUtilizadaMinima.Text);
            }
            bsAlquileres.DataSource = oCCUGAlquileres.ObtenerAlquileres(_nombre_cliente, _distancia_maxima, _capacidad_minima);
            dgvAlquileres.DataSource = bsAlquileres;
        }
    }
}
