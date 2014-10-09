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
    public partial class frmRegistroIngreso : Form
    {
        BindingSource bsTransportes = new BindingSource();
        BindingSource bsClientes = new BindingSource();
        BindingSource bsChoferes = new BindingSource();
        private static frmRegistroIngreso Instancia;
        Modelo_Entidades.Cliente oCliente;
        Modelo_Entidades.Chofer oChofer;
        Modelo_Entidades.Transporte oTransporte;
        Controladora.CCUGTransportes oCCUGTransportes = new Controladora.CCUGTransportes();
        Controladora.CCUGChoferes oCCUChoferes = new Controladora.CCUGChoferes();
        Controladora.CCUGClientes oCCUClientes = new Controladora.CCUGClientes();
        Controladora.CCUCore oCCUCore = new Controladora.CCUCore();

        Controladora.CCURPF oCCURPF = new Controladora.CCURPF();
        Modelo_Entidades.FORMULARIO oForm;
        List<Modelo_Entidades.PERFIL> collPerfilesObtenidos;

        Modelo_Entidades.USUARIO oUsuarioActual;
        private frmRegistroIngreso(Modelo_Entidades.USUARIO oUsu)
        {
            InitializeComponent();
            oUsuarioActual = oUsu;
        }
        public static frmRegistroIngreso ObtenerInstancia(Modelo_Entidades.USUARIO oUsu)
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmRegistroIngreso(oUsu);
            return Instancia;
        }
        private frmRegistroIngreso()
        {
            InitializeComponent();
        }
        public static frmRegistroIngreso ObtenerInstancia()
        {
            {
                if (Instancia == null || Instancia.IsDisposed == true)
                    Instancia = new frmRegistroIngreso();
                return Instancia;
            }
        }
        private void frmRegistroIngreso_Load(object sender, EventArgs e)
        {
            //bsChoferes.ListChanged += new System.EventHandler(this.btnFiltrar_Click);
            //llenar el combobox de clientes con todos los existentes
            bsClientes.DataSource = oCCUClientes.ObtenerClientes();
            cbCliente.DataSource = bsClientes;

            ActualizarDGVTransportes();
            this.ArmaPerfil(oUsuarioActual, this.Name);
        }

        public void ActualizarDGVTransportes()
        {
            bsTransportes.DataSource = oCCUGTransportes.ObtenerTransportes(cbTipo_Matricula.Text, tbNum_Matricula.Text, ((Modelo_Entidades.Cliente)bsClientes.Current).nombre, ((Modelo_Entidades.Chofer)bsChoferes.Current).nombre);
            dgvTransportes.DataSource = bsTransportes;
            this.dgvTransportes.Columns["nro_transporte"].Visible = false; //esconder id de transporte
            this.dgvTransportes.Columns["Operaciones"].Visible = false; //esconder Operacion
            this.dgvTransportes.Columns["Choferes"].Visible = false; //esconder chofer?
            this.dgvTransportes.Columns["carga_maxima"].Visible = false;
            this.dgvTransportes.Columns["tara"].Visible = false;
            this.dgvTransportes.Columns["Choferes"].Visible = false;
            this.dgvTransportes.Columns["tipo_matricula"].HeaderText = "Tipo de Matrícula";
            this.dgvTransportes.Columns["nro_matricula"].HeaderText = "Número de matrícula";
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(this.cbPermiso.Text))
            {
                this.cbPermiso.Focus();
                MessageBox.Show("Primero debe especificar si permite o no el acceso del transporte a planta.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(this.cbTipoOperacion.Text))
            {
                this.cbPermiso.Focus();
                MessageBox.Show("Primero debe especificar si la operación será una carga o descarga.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            oTransporte = (Modelo_Entidades.Transporte)bsTransportes.Current;
            if (oTransporte == null)
            {
                MessageBox.Show("Primero debe seleccionar un transporte.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(this.cbCliente.Text))
            {
                this.cbPermiso.Focus();
                MessageBox.Show("Primero debe seleccionar un Cliente.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(this.cbChofer.Text))
            {
                this.cbPermiso.Focus();
                MessageBox.Show("Primero debe seleccionar un Chofer.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                oTransporte = (Modelo_Entidades.Transporte)bsTransportes.Current;
                Modelo_Entidades.Operacion oOperacion = new Modelo_Entidades.Operacion();
                if (this.cbPermiso.Text == "Si")
                    oOperacion.estado = "Ingresa";
                else oOperacion.estado = "Rechazado";
                oOperacion.tipo_operacion = this.cbTipoOperacion.Text;
                oOperacion.notas = this.tbNotas.Text;
                oOperacion.fecha_y_hora_inicio = DateTime.Now;
                oOperacion.Transporte = oTransporte;
                oOperacion.Cliente = (Modelo_Entidades.Cliente)bsClientes.Current;
                oOperacion.Chofer = (Modelo_Entidades.Chofer)bsChoferes.Current;

                //datos auditoría
                oOperacion.USU_CODIGO = oUsuarioActual.USU_CODIGO;
                oOperacion.fecha_y_hora_accion = DateTime.Now;
                if (oOperacion.estado == "Ingresa")
                {
                    oOperacion.accion = "Alta - Autorizar Ingreso";
                }
                else
                {
                    oOperacion.accion = "Alta - Rechazar Ingreso";
                }

                bool resultado;
                try
                {
                    resultado = oCCUCore.Agregar(oOperacion);
                    if (resultado)
                    {
                        MessageBox.Show("Registrado con éxito", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmClientes.ObtenerInstancia().ActualizarDGVClientes();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No registrado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                catch (System.Data.EntitySqlException ex)
                {
                    MessageBox.Show("No se ha podido registrar el nuevo ingreso: " + ex.Message + ".", "Error de base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
                this.btnRegistrar.Enabled = true;
            }
            else
            {
                btnRegistrar.Enabled = false;
            }
            
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            //lo siguiente no funciona porque se ejecuta antes de que se actualize cuál es el objeto actual en el currency manager
            //oCliente = (Modelo_Entidades.Cliente)bsClientes.Current;
            oCliente = (Modelo_Entidades.Cliente)cbCliente.SelectedItem;
            //oChofer = (Modelo_Entidades.Chofer)bsChoferes.Current;
            oChofer = (Modelo_Entidades.Chofer)cbChofer.SelectedItem;
            bsTransportes.DataSource = oCCUGTransportes.ObtenerTransportes(this.cbTipo_Matricula.Text, this.tbNum_Matricula.Text, this.oCliente.nombre, this.oChofer.nombre);
            dgvTransportes.DataSource = bsTransportes;
            //MessageBox.Show(oCliente.nombre + " y " + oChofer.nombre + " fueron seleccionados.", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbChofer_SelectedIndexChanged(object sender, EventArgs e)
        {
            //llamar a la actualización de la grilla
            //this.ActualizarDGVTransportes();
            this.btnFiltrar.PerformClick();
        }

        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            //obtener el cliente seleccionado
            //cargar la lista de choferes con los que trabajan para el cliente seleccionado
            bsChoferes.DataSource = oCCUChoferes.ObtenerChoferes(nombre: null, apellido: null, tipo_documento: null, nro_documento: 0, oClienteRecibido: (Modelo_Entidades.Cliente)bsClientes.Current);
            cbChofer.DataSource = bsChoferes;
            this.btnFiltrar.PerformClick();
        }
    }
}
