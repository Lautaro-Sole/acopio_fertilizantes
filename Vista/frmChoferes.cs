using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vista
{
    internal partial class frmChoferes : Vista.frmABM
    {
        private static frmChoferes Instancia;
        private BindingSource bsChoferes = new BindingSource();
        private Controladora.CCUGChoferes oCCUGChoferes = new Controladora.CCUGChoferes();
        private Modelo_Entidades.Chofer oChofer;

        Modelo_Entidades.USUARIO oUsuarioActual;
        private frmChoferes(Modelo_Entidades.USUARIO oUsu)
        {
            InitializeComponent();
            oUsuarioActual = oUsu;
        }
        public static frmChoferes ObtenerInstancia(Modelo_Entidades.USUARIO oUsu)
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmChoferes(oUsu);
            return Instancia;
        }
        public static frmChoferes ObtenerInstancia()
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmChoferes();
            return Instancia;
        }
        private frmChoferes()
        {
            InitializeComponent();
        }
        public void ActualizarDGVChoferes()
        {
            bsChoferes.DataSource = oCCUGChoferes.ObtenerChoferes();
            dgvChoferes.DataSource = bsChoferes;


            
        }
        private void frmChoferes_Load(object sender, EventArgs e)
        {
            this.ArmaPerfil(oUsuarioActual, this.Name);
            ActualizarDGVChoferes();

            this.dgvChoferes.Columns[1].HeaderText = "Apellido";
            this.dgvChoferes.Columns[2].HeaderText = "Nombre";
            this.dgvChoferes.Columns[3].HeaderText = "Número de documento";
            this.dgvChoferes.Columns[4].HeaderText = "Tipo de documento";
            this.dgvChoferes.Columns[0].Visible = false; //esconder número de chofer
            this.dgvChoferes.Columns[5].Visible = false; //esconder Operaciones
            this.dgvChoferes.Columns[6].Visible = false; //esconder transportes
            this.dgvChoferes.Columns[7].Visible = false; //esconder clientes

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmChofer ofrmChofer = new frmChofer();
            ofrmChofer.Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChoferes_Load_1(object sender, EventArgs e)
        {
            ActualizarDGVChoferes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActualizarDGVChoferes();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            oChofer = (Modelo_Entidades.Chofer)bsChoferes.Current;
            if (oChofer == null)
            {
                MessageBox.Show("Primero debe elegir un chofer.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmChofer ofrmChofer = new frmChofer(oChofer);
                ofrmChofer.Show();
            }
        }

        public bool ComprobarRelaciones()
        {
            if ((oChofer.Operaciones.Count == 0) && (oChofer.Clientes.Count == 0))
                return true;
            else return false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oChofer = (Modelo_Entidades.Chofer)bsChoferes.Current;
            if (oChofer == null)
            {
                MessageBox.Show("Primero debe elegir un chofer.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult oDialogResult = MessageBox.Show("¿Está seguro que desea eliminar el chofer seleccionado?", "Confirmar eliminar.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oDialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (ComprobarRelaciones())
                        {
                            bool resultado = oCCUGChoferes.Eliminar(oChofer);
                            if (resultado)
                            {
                                MessageBox.Show("Chofer eliminado correctamente.", "Resultado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ActualizarDGVChoferes();
                            }
                            else
                            {
                                MessageBox.Show("El Chofer no se pudo eliminar.", "Resultado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El Chofer no se pudo eliminar porque estuvo involcrado en una operación.", "Resultado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (EntitySqlException ex)
                    {
                        MessageBox.Show("" + ex, "Excepción.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        protected override void btnFiltrar_Click(object sender, EventArgs e)
        {
            //ActualizarDGVChoferes();
            //bsChoferes.DataSource =oCCUGChoferes.ObtenerChoferes(this.tbNombre.Text, this.tbApellido.Text, this.cbTipo_Documento.Text, Convert.ToInt32(this.msktbDocumento.Text), this.tbCliente.Text);
            string _nombre = this.tbNombre.Text;
            string _apellido = this.tbApellido.Text;
            string _tipo_documento = this.cbTipo_Documento.Text;
            Int32 _nro_documento = new Int32();
            if (string.IsNullOrEmpty(this.msktbDocumento.Text))
            {
                _nro_documento = 0;
            }
            else
            {
                _nro_documento = Convert.ToInt32(this.msktbDocumento.Text);
            }
            string _nombre_cliente = this.tbCliente.Text;
            bsChoferes.DataSource = oCCUGChoferes.ObtenerChoferes(_nombre, _apellido, _tipo_documento, _nro_documento, _nombre_cliente);
            dgvChoferes.DataSource = bsChoferes;
        }
    }
}
