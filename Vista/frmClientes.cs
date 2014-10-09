using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vista
{
    internal partial class frmClientes : Vista.frmABM
    {
        private static frmClientes Instancia;
        private BindingSource bsClientes = new BindingSource();
        private Controladora.CCUGClientes oCCUGClientes = new Controladora.CCUGClientes();
        private Modelo_Entidades.Cliente oCliente;

        Modelo_Entidades.USUARIO oUsuarioActual;
        private frmClientes(Modelo_Entidades.USUARIO oUsu)
        {
            InitializeComponent();
            oUsuarioActual = oUsu;
        }
        public static frmClientes ObtenerInstancia(Modelo_Entidades.USUARIO oUsu)
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmClientes(oUsu);
            return Instancia;
        }
        public static frmClientes ObtenerInstancia()
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmClientes();
            return Instancia;
        }
        private frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            this.ArmaPerfil(oUsuarioActual, this.Name);
            ActualizarDGVClientes();
            
        }

        public void ActualizarDGVClientes()
        {
            bsClientes.DataSource = oCCUGClientes.ObtenerClientes();
            dgvClientes.DataSource = bsClientes;
            this.dgvClientes.Columns[0].Visible = false; //esconder id de cliente
            this.dgvClientes.Columns[4].Visible = false; //esconder alquileres
            this.dgvClientes.Columns[5].Visible = false; //esconder choferes
            this.dgvClientes.Columns[1].HeaderText = "Nombre del cliente";
            this.dgvClientes.Columns[2].HeaderText = "Teléfono";
            this.dgvClientes.Columns[3].HeaderText = "E-Mail";
            this.dgvClientes.Columns["Operaciones"].Visible = false; 
        }
        /*
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmCliente ofrmCliente = new frmCliente("Alta");
            ofrmCliente.Show();
        }
         * */
        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            frmCliente ofrmCliente = new frmCliente();
            ofrmCliente.Show();
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gbFiltros_Enter(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oCliente = (Modelo_Entidades.Cliente)bsClientes.Current;
            if (oCliente == null)
            {
                MessageBox.Show("Primero debe elegir un cliente.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult oDialogResult = MessageBox.Show("¿Está seguro que desea eliminar el cliente seleccionado?", "Confirmar eliminar.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oDialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (ComprobarRelaciones())
                        {
                            bool resultado = oCCUGClientes.Eliminar(oCliente);
                            if (resultado)
                            {
                                MessageBox.Show("Cliente eliminado correctamente.", "Resultado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ActualizarDGVClientes();
                            }
                            else
                            {
                                MessageBox.Show("El cliente no se pudo eliminar.", "Resultado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El cliente no se pudo eliminar porque tiene al menos un chofer o alquiler, o estuvo involucrado en una operación.", "Resultado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (EntitySqlException ex)
                    {
                        MessageBox.Show("" + ex, "Excepción.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            oCliente = (Modelo_Entidades.Cliente)bsClientes.Current;
            if (oCliente == null)
            {
                MessageBox.Show("Primero debe elegir un cliente.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmCliente ofrmCliente = new frmCliente(oCliente);
                ofrmCliente.Show();
            }
        }

        protected override void btnFiltrar_Click(object sender, EventArgs e)
        {
            //ActualizarDGVClientes();
            bsClientes.DataSource = oCCUGClientes.ObtenerClientes(this.tbNombre.Text);
            dgvClientes.DataSource = bsClientes;
        }

        private bool ComprobarRelaciones()
        {
            if ((oCliente.Alquileres.Count == 0) && (oCliente.Choferes.Count == 0) && (oCliente.Operaciones.Count == 0))
                return true;
            else return false;
        }
    }
}
