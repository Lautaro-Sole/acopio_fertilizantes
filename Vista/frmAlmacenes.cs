using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vista
{
    internal partial class frmAlmacenes : Vista.frmABM
    {
        private static frmAlmacenes Instancia;
        private BindingSource bsAlmacenes=new BindingSource();
        private Controladora.CCUGAlmacenes oCCUGAlmacenes = new Controladora.CCUGAlmacenes();
        private Modelo_Entidades.Almacen oAlmacen = new Modelo_Entidades.Almacen();

        Modelo_Entidades.USUARIO oUsuarioActual;
        private frmAlmacenes(Modelo_Entidades.USUARIO oUsu)
        {
            InitializeComponent();
            oUsuarioActual = oUsu;
        }
        public static frmAlmacenes ObtenerInstancia(Modelo_Entidades.USUARIO oUsu)
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmAlmacenes(oUsu);
            return Instancia;
        }
        public static frmAlmacenes ObtenerInstancia()
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmAlmacenes();
            return Instancia;
        }
        private frmAlmacenes()
        {
            InitializeComponent();
        }

        private void frmAlmacenes_Load(object sender, EventArgs e)
        {
            this.ArmaPerfil(oUsuarioActual, this.Name);
            ActualizarDGVAlmacenes();
            

        }

        public void ActualizarDGVAlmacenes()
        {
            bsAlmacenes.DataSource = oCCUGAlmacenes.ObtenerAlmacenes();
            dgvAlmacenes.DataSource = bsAlmacenes;
            this.dgvAlmacenes.Columns[1].Visible = false;
            this.dgvAlmacenes.Columns[6].Visible = false;
            this.dgvAlmacenes.Columns[0].HeaderText = "Capacidad Utilizada";
            this.dgvAlmacenes.Columns[2].HeaderText = "Nombre";
            this.dgvAlmacenes.Columns[3].HeaderText = "Dirección";
            this.dgvAlmacenes.Columns[4].HeaderText = "Distancia a la empresa";
            this.dgvAlmacenes.Columns[5].HeaderText = "Capacidad";

        }
        /*
        // Declare a new DataGridTableStyle in the
        // declarations area of your form.
        DataGridTableStyle ts = new DataGridTableStyle();

        private void hideColumn()
        {
            // Set the DataGridTableStyle.MappingName property
            // to the table in the data source to map to.
            ts.MappingName = this.dgvAlmacenes.DataMember;

            // Add it to the datagrid's TableStyles collection
            this.dgvAlmacenes.TableStyles.Add(ts);
            this.dgvAlmacenes.ce

            // Hide the first column (index 0)
            this.dgvAlmacenes.TableStyles[0].GridColumnStyles[0].Width = 0;
        }
        */

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAlmacen ofrmAlmacen = new frmAlmacen();
            ofrmAlmacen.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oAlmacen = (Modelo_Entidades.Almacen)bsAlmacenes.Current;
            if (oAlmacen == null)
            {
                MessageBox.Show("Primero debe elegir un almacén.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult oDialogResult = MessageBox.Show("¿Está seguro que desea eliminar el almacén seleccionado?", "Confirmar eliminar.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oDialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (ComprobarRelaciones())
                        {
                            bool resultado = oCCUGAlmacenes.Eliminar(oAlmacen);
                            if (resultado)
                            {
                                MessageBox.Show("Almacén eliminado correctamente.", "Resultado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ActualizarDGVAlmacenes();
                            }
                            else
                            {
                                MessageBox.Show("El almacén no se pudo eliminar.", "Resultado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El almacén no se puede eliminar porque se ha alquilado parcial o totalmente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("El almacén no se puede eliminar porque se ha alquilado parcial o totalmente. " + ex, "Excepción.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            oAlmacen = (Modelo_Entidades.Almacen)bsAlmacenes.Current;
            if (oAlmacen == null)
            {
                MessageBox.Show("Primero debe elegir un almacén.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmAlmacen ofrmAlmacen = new frmAlmacen(oAlmacen);
                ofrmAlmacen.Show();
            }
        }

        protected override void btnFiltrar_Click(object sender, EventArgs e)
        {
            string _nombre_almacen = this.tbNombre.Text;
            int _distancia_maxima = new int();
            if (string.IsNullOrEmpty(this.msktbDistancia.Text))
            {
                _distancia_maxima = 0;
            }
            else
            {
                _distancia_maxima = Convert.ToInt32(this.msktbDistancia.Text);
            }
            int _capacidad_minima = new int();
            if (string.IsNullOrEmpty(this.msktbCapacidad.Text))
            {
                _capacidad_minima = 0;
            }
            else
            {
                _capacidad_minima = Convert.ToInt32(this.msktbCapacidad.Text);
            }
            bsAlmacenes.DataSource = oCCUGAlmacenes.ObtenerAlmacenes(_nombre_almacen, _distancia_maxima, _capacidad_minima);
            dgvAlmacenes.DataSource = bsAlmacenes;
        }

        private bool ComprobarRelaciones()
        {
            if ((oAlmacen.Alquileres.Count == 0))
                return true;
            else return false;
        }
    }
}
