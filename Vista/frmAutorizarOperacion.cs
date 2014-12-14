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
    public partial class frmAutorizarOperacion : Form
    {
        BindingSource bsAlquileres = new BindingSource();
        BindingSource bsProductos = new BindingSource();
        Controladora.CCUGAlquileres oCCUGAlquileres = new Controladora.CCUGAlquileres();
        private Modelo_Entidades.Documento _oDocumento = new Modelo_Entidades.Documento();
        Controladora.CCUGProductos oCCUGProductos = new Controladora.CCUGProductos();
        Controladora.CCUCore oCCUCore = Controladora.CCUCore.ObtenerInstancia();
        Modelo_Entidades.Operacion oOperacion;
        Modelo_Entidades.Documento oDocumento = new Modelo_Entidades.Documento();


        Modelo_Entidades.USUARIO oUsuarioActual;
        private static frmAutorizarOperacion Instancia;
        private frmAutorizarOperacion(Modelo_Entidades.USUARIO oUsu, Modelo_Entidades.Operacion oOperacionEnviado)
        {
            InitializeComponent();
            oUsuarioActual = oUsu;
            oOperacion = oOperacionEnviado;
            //oOperacion = oOperacionEnviado;
        }        
        public static frmAutorizarOperacion ObtenerInstancia(Modelo_Entidades.USUARIO oUsu, Modelo_Entidades.Operacion oOperacionEnviado)
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmAutorizarOperacion(oUsu, oOperacionEnviado);
            return Instancia;
        }
        private frmAutorizarOperacion()
        {
            InitializeComponent();
        }

        public void ActualizarDGVAlquileres()
        {
            try
            {
                bsAlquileres.DataSource = oCCUGAlquileres.ObtenerAlquileres(_nombre_cliente:oOperacion.Cliente.nombre, _espacio_minimo:0, _distancia_maxima:0); 
                dgvAlquileres.DataSource = bsAlquileres;



            }
            catch (System.Data.DataException ex)
            {
                MessageBox.Show("Excepcion: " + ex.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarDatos()
        {
            if (this.bsAlquileres.Current == null)
            {
                MessageBox.Show("Primero debe seleccionar un alquiler.", "Faltan datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            Modelo_Entidades.Alquiler oAlquiler = (Modelo_Entidades.Alquiler)this.bsAlquileres.Current;
            if (oAlquiler.estado == false)
            {
                MessageBox.Show("El alquiler seleccionado no debe estar vencido.", "Faltan datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(this.cbTipoFertilizante.Text))
            {
                MessageBox.Show("Primero debe seleccionar un tipo de fertilizante.", "Faltan datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cbTipoFertilizante.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.msktbCantidad.Text))
            {
                MessageBox.Show("Primero debe ingresar la cantidad de fertilizante.", "Faltan datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cbTipoFertilizante.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(this.msktbNro_Documento.Text))
            {
                MessageBox.Show("Primero debe ingresar el número del documento.", "Faltan datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cbTipoFertilizante.Focus();
                return false;
            }
            return true;

        }

        /*
        private void btnAgregarDocumento_Click(object sender, EventArgs e)
        {
            //frmDocumento.ObtenerInstancia(oUsuarioActual).Show();
            if (oOperacion.tipo_operacion == "Descarga")
            {
                DialogResult resultado = frmDocumento.ObtenerInstancia(oUsuarioActual, "Remito").ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    oDocumento = frmDocumento.ObtenerInstancia(oUsuarioActual).oDocumento;
                }
            }
            else
            {
                DialogResult resultado = frmDocumento.ObtenerInstancia(oUsuarioActual, "Orden de Carga").ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    oDocumento = frmDocumento.ObtenerInstancia(oUsuarioActual).oDocumento;
                }
            }
            
        }
        */

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool resultado;
            if (ValidarDatos())
            {
                if (oOperacion.Tipo_Operacion.descripcion == "Carga")
                {
                    oDocumento.tipo_documento = "Orden de carga";
                    oOperacion.tipo_documento = "Orden de carga";
                    //establecer estrategia
                    oOperacion.EstablecerEstrategia(new Modelo_Entidades.EstrategiaCarga());
                }
                else
                {
                    oDocumento.tipo_documento = "Remito";
                    oOperacion.tipo_documento = "Remito";
                    //establecer estrategia
                    oOperacion.EstablecerEstrategia(new Modelo_Entidades.EstrategiaDescarga());
                }

                oDocumento.nro_documento = Convert.ToInt32(this.msktbNro_Documento.Text);
                oDocumento.Producto = (Modelo_Entidades.Producto)bsProductos.Current;
                oDocumento.peso = Convert.ToInt32(this.msktbCantidad.Text);
                oDocumento.fecha_hora = this.dtpFechaYHora.Value;

                oOperacion.Documento = oDocumento;
                oOperacion.Estado_Operacion.descripcion = "Autorizado";
                oOperacion.notas = this.tbNotas.Text;

                oOperacion.Alquiler = (Modelo_Entidades.Alquiler)this.bsAlquileres.Current;

                //datos auditoría
                oOperacion.USU_CODIGO = oUsuarioActual.USU_CODIGO;
                oOperacion.fecha_y_hora_accion = DateTime.Now;
                oOperacion.accion = "Modificacion - Autorizar Operacion";

                try
                {
                    //llamar comprobacion
                    resultado = oCCUCore.ComprobrarPosibilidadDeOperacion(oOperacion);
                    if (resultado)
                    {
                        resultado = oCCUCore.Modificar(oOperacion);
                        if (resultado)
                        {
                            MessageBox.Show("Guardado con éxito", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmOperaciones.ObtenerInstancia().ActualizarDGVOperaciones();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No guardado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No es posible realizar la operación deseada en el alquiler seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (System.Data.DataException ex)
                {
                    MessageBox.Show("No se ha podido actualizar la operación: " + ex.Message + ".", "Error de base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAutorizarOperacion_Load(object sender, EventArgs e)
        {

            this.tbNotas.Text = this.oOperacion.notas;
            //el siguiente es el problema
            this.tbNombreCliente.Text = oOperacion.Cliente.nombre;
            this.tbNombreCliente.Enabled = false;

            bsProductos.DataSource = oCCUGProductos.ObtenerProductos();
            cbTipoFertilizante.DataSource = bsProductos;

            //cbTipoFertilizante.DataSource = oCCUGProductos.ObtenerProductos();
            cbTipoFertilizante.DisplayMember = "descripcion";
            //si el tipo de documento ya está elegido deshabilitar el combobox

            ActualizarDGVAlquileres();

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

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            //el nombre del cliente debe ser el que está en la operación, por eso se deshabilita el textbox durante Load()
            int espacio_minimo;
            if (string.IsNullOrEmpty(this.msktbSupNoUtilizadaMinima.Text))
            {
                espacio_minimo = 0;
            }
            else
            {
                espacio_minimo = Convert.ToInt32(this.msktbSupNoUtilizadaMinima.Text);
            }
            int distancia_maxima;
            if (string.IsNullOrEmpty(this.msktbDistMaxAEmpresa.Text))
            {
                distancia_maxima = 0;
            }
            else
            {
                distancia_maxima = Convert.ToInt32(this.msktbDistMaxAEmpresa.Text);
            }
            bsAlquileres.DataSource = oCCUGAlquileres.ObtenerAlquileres(this.tbNombreCliente.Text, espacio_minimo, distancia_maxima);
            //bsAlquileres.DataSource = oCCUGAlquileres.ObtenerAlquileres(oOperacion.Alquileres.Clientes.nombre, Convert.ToInt32(this.msktbSupNoUtilizadaMinima.Text), Convert.ToInt32(this.msktbDistMaxAEmpresa.Text));
            dgvAlquileres.DataSource = bsAlquileres;
        }


    }
}
