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
    public partial class frmOperaciones : Form
    {
        private static frmOperaciones Instancia;
        private BindingSource bsOperaciones=new BindingSource();
        private Controladora.CCUCore oCCUCore = Controladora.CCUCore.ObtenerInstancia();
        private Modelo_Entidades.Operacion oOperacion;


        Controladora.CCURPF oCCURPF = new Controladora.CCURPF();
        Modelo_Entidades.FORMULARIO oForm;
        List<Modelo_Entidades.PERFIL> collPerfilesObtenidos;

        Modelo_Entidades.USUARIO oUsuarioActual;
        private frmOperaciones(Modelo_Entidades.USUARIO oUsu)
        {
            InitializeComponent();
            oUsuarioActual = oUsu;
        }
        public static frmOperaciones ObtenerInstancia(Modelo_Entidades.USUARIO oUsu)
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmOperaciones(oUsu);
            return Instancia;
        }
        private frmOperaciones()
        {
            InitializeComponent();
        }
        public static frmOperaciones ObtenerInstancia()
        {
            {
                if (Instancia == null || Instancia.IsDisposed == true)
                    Instancia = new frmOperaciones();
                return Instancia;
            }
        }

        private void frmAutorizaciones_Load(object sender, EventArgs e)
        {
            ActualizarDGVOperaciones();
            this.ArmaPerfil(oUsuarioActual, this.Name);

            OrdenarColumnas();
        }

        public void ActualizarDGVOperaciones()
        {
            bsOperaciones.DataSource = oCCUCore.ObtenerOperaciones();
            dgvOperaciones.DataSource = bsOperaciones;
        }
        protected void ArmaPerfil(Modelo_Entidades.USUARIO oUsuarioActual, string nombre_formulario)
        {
            
            Controladora.CCURPF oCCURPF = new Controladora.CCURPF();
            
            oForm = oCCURPF.obtenerFormulario(frmOperaciones.ObtenerInstancia().Name);
            collPerfilesObtenidos = oCCURPF.recuperarPerfilForm(oUsuarioActual, oForm);
            if (collPerfilesObtenidos.Find(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return oPerfilBuscado.PER_CODIGO == "Z"; }) != null)
            {
                this.btnAutorizarOperacion.Enabled = true;
                this.btnAutCierre.Enabled = true;
            }
            else
            {
                this.btnAutorizarOperacion.Enabled = false;
                this.btnAutCierre.Enabled = false;
            }
            if (collPerfilesObtenidos.Find(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return oPerfilBuscado.PER_CODIGO == "G"; }) != null)
            {
                this.btnRegistrarCargaDescarga.Enabled = true;
            }
            else
            {
                this.btnRegistrarCargaDescarga.Enabled = false;            
            }
            
        }

        private void btnAutorizarCargaDescarga_Click(object sender, EventArgs e)
        {
            if (bsOperaciones.Current == null)
            {
                MessageBox.Show("Primero debe elegir una operación.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                oOperacion = (Modelo_Entidades.Operacion)bsOperaciones.Current;
                if (oOperacion.Estado_Operacion.descripcion != "Ingresa")
                {
                    MessageBox.Show("La operación seleccionada ya ha sido autorizada.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    /*
                    if (oOperacion.tipo_operacion=="Descarga")
                    {
                        frmAutDescarga.ObtenerInstancia(oUsuarioActual, oOperacion).Show();
                    }
                    */
                    frmAutorizarOperacion.ObtenerInstancia(oUsuarioActual, oOperacion).Show();
                }
            }
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAutCierre_Click(object sender, EventArgs e)
        {
            if (bsOperaciones.Current == null)
            {
                MessageBox.Show("Primero debe elegir una operación.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                oOperacion = (Modelo_Entidades.Operacion) bsOperaciones.Current;
                if (oOperacion.Estado_Operacion.descripcion == "Finalizado")
                {
                    oOperacion = (Modelo_Entidades.Operacion)bsOperaciones.Current;
                    DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea cerrar la operación elegida?", "Confirmar Cerrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes)
                    {
                        oOperacion.Estado_Operacion.descripcion = "Cerrado";

                        //datos auditoría
                        oOperacion.USU_CODIGO = oUsuarioActual.USU_CODIGO;
                        oOperacion.fecha_y_hora_accion = DateTime.Now;
                        oOperacion.accion = "Modificacion - Autorizar Cierre";

                        try
                        {
                            bool resultado = oCCUCore.Modificar(oOperacion);
                        }
                        catch (System.Data.DataException ex)
                        {
                            MessageBox.Show("Excepción: " + ex.InnerException.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se puede cerrar la operación elegida porque su estado actual no es 'Finalizado'.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRegistrarCargaDescarga_Click(object sender, EventArgs e)
        {
            if (bsOperaciones.Current == null)
            {
                MessageBox.Show("Primero debe elegir una operación.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                oOperacion = (Modelo_Entidades.Operacion)bsOperaciones.Current;
                if (oOperacion.Estado_Operacion.descripcion == "Autorizado")
                {

                    frmCargaDescarga.ObtenerInstancia(oUsuarioActual, oOperacion).Show();
                }
                else
                {
                    MessageBox.Show("La operación aún no ha sido autorizada.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            bsOperaciones.DataSource = oCCUCore.ObtenerOperaciones(cbTipo_Id.Text, tbNum_Id.Text, cbOperacion.Text, cbEstado.Text, tbNombreCliente.Text, tbNombreChofer.Text);
            dgvOperaciones.DataSource = bsOperaciones;
            OrdenarColumnas();
        }

        private void OrdenarColumnas()
        {
            dgvOperaciones.Columns["nro_operacion"].DisplayIndex = 0;
            dgvOperaciones.Columns["tipo_operacion"].DisplayIndex = 1;
            dgvOperaciones.Columns["estado"].DisplayIndex = 2;
            dgvOperaciones.Columns["tipo_documento"].DisplayIndex = 3;
            dgvOperaciones.Columns["nro_documento"].DisplayIndex = 4;
            dgvOperaciones.Columns["peso_inicial"].DisplayIndex = 5;
            dgvOperaciones.Columns["peso_final"].DisplayIndex = 6;
            dgvOperaciones.Columns["Alquiler"].DisplayIndex = 7;
            dgvOperaciones.Columns["Chofer"].DisplayIndex = 8;
            dgvOperaciones.Columns["Transporte"].DisplayIndex = 9;
            dgvOperaciones.Columns["Cliente"].DisplayIndex = 10;
            dgvOperaciones.Columns["fecha_y_hora_inicio"].DisplayIndex = 11;
            dgvOperaciones.Columns["fecha_y_hora_fin"].DisplayIndex = 12;
            dgvOperaciones.Columns["notas"].DisplayIndex = 13;
            dgvOperaciones.Columns["USU_CODIGO"].DisplayIndex = 14;
            dgvOperaciones.Columns["fecha_y_hora_accion"].DisplayIndex = 15;
            dgvOperaciones.Columns["accion"].DisplayIndex = 16;

            dgvOperaciones.Columns["nro_operacion"].HeaderText = "Número de operación";
            dgvOperaciones.Columns["estado"].HeaderText = "Estado";
            dgvOperaciones.Columns["fecha_y_hora_inicio"].HeaderText = "Fecha y hora de inicio";
            dgvOperaciones.Columns["fecha_y_hora_fin"].HeaderText = "Fecha y hora de finalización";
            dgvOperaciones.Columns["notas"].HeaderText = "Notas";
            dgvOperaciones.Columns["nro_documento"].HeaderText = "Número de documento";
            dgvOperaciones.Columns["peso_inicial"].HeaderText = "Peso Inicial";
            dgvOperaciones.Columns["peso_final"].HeaderText = "Peso Final";
            dgvOperaciones.Columns["tipo_documento"].HeaderText = "Tipo de documento";
            dgvOperaciones.Columns["tipo_operacion"].HeaderText = "Tipo de operación";
            dgvOperaciones.Columns["USU_CODIGO"].HeaderText = "Código de Usuario";
            dgvOperaciones.Columns["fecha_y_hora_accion"].HeaderText = "Fecha y hora de acción";
            dgvOperaciones.Columns["accion"].HeaderText = "Acción";

            dgvOperaciones.Columns["nro_alquiler"].Visible = false;
            dgvOperaciones.Columns["nro_chofer"].Visible = false;
            dgvOperaciones.Columns["nro_transporte"].Visible = false;
            dgvOperaciones.Columns["Documento"].Visible = false;
            dgvOperaciones.Columns[17].Visible = false;
        }
    }
}
