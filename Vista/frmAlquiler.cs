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
    public partial class frmAlquiler : Form
    {
        private string Modo;
        private BindingSource bsAlmacenes = new BindingSource();
        private BindingSource bsClientes = new BindingSource();
        private Controladora.CCUGAlmacenes oCCUGAlmacenes = new Controladora.CCUGAlmacenes();
        private Controladora.CCUGClientes oCCUGClientes = new Controladora.CCUGClientes();
        private Controladora.CCUGAlquileres oCCUGAlquileres = Controladora.CCUGAlquileres.ObtenerInstancia();
        private Modelo_Entidades.Alquiler oAlquiler;
        private Modelo_Entidades.Almacen oAlmacen;
        private Modelo_Entidades.Cliente oCliente;
        public frmAlquiler()
        {
            InitializeComponent();
            Modo = "Alta";
        }
        public frmAlquiler(Modelo_Entidades.Alquiler AlquilerEnviado)
        {
            InitializeComponent();
            Modo = "Modificacion";
            oAlquiler = AlquilerEnviado;
        }

        private void ActualizarDGVAlmacenes()
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
            this.dgvAlmacenes.Columns[0].DisplayIndex = 5;

        }

        private void ActualizarDGVClientes()
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


        private void frmAlquiler_Load(object sender, EventArgs e)
        {
            ActualizarDGVAlmacenes();
            ActualizarDGVClientes();
            this.msktbCapacidadNoUtilizada.Enabled = false;
            if (Modo == "Alta")
            {
                this.msktbCapacidadNoUtilizada.Enabled = false;
            }
            else
            {
                oAlmacen = oAlquiler.Almacen;
                oCliente = oAlquiler.Cliente;
                this.msktbEspacioAlquilado.Text = Convert.ToString(oAlquiler.capacidad);
                this.cbActivo.Checked = Convert.ToBoolean(oAlquiler.estado);
                this.msktbFecha_Hora_Inicio.Text = oAlquiler.fecha_inicio_alquiler.ToString();
                this.msktbFecha_Hora_Fin.Text = oAlquiler.fecha_fin_alquiler.ToString();
                //this.msktbEspacioNoUtilizado.Text = Convert.ToString(oAlquiler);
                this.msktbCapacidadNoUtilizada.Enabled = false;
                //deshabilitar los datagridview para impedir el cambio de el almacen o el cliente
                this.dgvAlmacenes.Enabled = false;
                this.gbFiltrosAlmacenes.Enabled = false;
                this.dgvClientes.Enabled = false;
                this.gbFiltrosClientes.Enabled = false;
                
                //seleccionar los objetos en los dgv
            }
        }

        private bool ValidarObligatorios()
        {
            if (string.IsNullOrEmpty(this.msktbEspacioAlquilado.Text))
            {
                this.msktbEspacioAlquilado.Focus();
                MessageBox.Show("Primero debe ingresar el espacio a alquilar.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(this.msktbFecha_Hora_Inicio.Text))
            {
                this.msktbEspacioAlquilado.Focus();
                MessageBox.Show("Primero debe ingresar la fecha y la hora de inicio del alquiler.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(this.msktbFecha_Hora_Fin.Text))
            {
                this.msktbEspacioAlquilado.Focus();
                MessageBox.Show("Primero debe ingresar la fecha y la hora de finalización del alquiler.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            Modelo_Entidades.Cliente oCliente = (Modelo_Entidades.Cliente)bsClientes.Current;
            if (oCliente == null)
            {
                MessageBox.Show("Primero debe elegir un Cliente.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            Modelo_Entidades.Almacen oAlmacen = (Modelo_Entidades.Almacen)bsAlmacenes.Current;
            if (oAlmacen == null)
            {
                MessageBox.Show("Primero debe elegir un Almacén.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Modo == "Alta")
            {
                if (ValidarObligatorios())
                {

                    AsignarValores();
                    bool resultado, resultado_2;
                    resultado = oCCUGAlquileres.ComprobarEspacioNecesario(oAlquiler);
                    if (resultado)
                    {
                        try
                        {
                            resultado_2 = oCCUGAlquileres.Agregar(oAlquiler);
                            if (resultado)
                            {
                                MessageBox.Show("Guardado con éxito", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                frmAlquileres.ObtenerInstancia().ActualizarDGVAlquileres();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("No guardado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                            
                        }
                        catch (System.Data.EntitySqlException ex)
                        {
                            MessageBox.Show("No se ha podido guardar el nuevo almacén: " + ex + ".", "Error de base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El espacio alquilado no puede exceder al espacio disponible en el almacén.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
            {
                if (ValidarObligatorios())
                {
                    AsignarValores();

                    bool resultado, resultado_2;
                    resultado = oCCUGAlquileres.ComprobarEspacioNecesarioModificacion(oAlquiler, oAlmacen);
                    if (resultado)
                    {
                        try
                        {
                            resultado_2 = oCCUGAlquileres.Modificar(oAlquiler);
                            if (resultado)
                            {
                                MessageBox.Show("Actualizado con éxito", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                frmAlquileres.ObtenerInstancia().ActualizarDGVAlquileres();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("No Actualizado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }
                        catch (System.Data.EntitySqlException ex)
                        {
                            MessageBox.Show("No se ha podido guardar el nuevo almacén: " + ex.Message + ".", "Error de base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El espacio alquilado no puede exceder al espacio disponible en el almacén.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void AsignarValores()
        {
            if (Modo == "Alta")
            {
                oAlmacen = (Modelo_Entidades.Almacen)bsAlmacenes.Current;
                oCliente = (Modelo_Entidades.Cliente)bsClientes.Current;
                oAlquiler = new Modelo_Entidades.Alquiler();
            }
            
            oAlquiler.Almacen = oAlmacen;
            oAlquiler.Cliente = oCliente;
            oAlquiler.capacidad = Convert.ToInt32(this.msktbEspacioAlquilado.Text);
            oAlquiler.fecha_inicio_alquiler = Convert.ToDateTime(this.msktbFecha_Hora_Inicio.Text);
            oAlquiler.fecha_fin_alquiler = Convert.ToDateTime(this.msktbFecha_Hora_Fin.Text);
            oAlquiler.estado = this.cbActivo.Checked;
        }

        private void btnFiltrarClientes_Click(object sender, EventArgs e)
        {
            bsClientes.DataSource = oCCUGClientes.ObtenerClientes(this.tbNombreCliente.Text);
            dgvClientes.DataSource = bsClientes;
        }

        private void btnFiltrarAlmacenes_Click(object sender, EventArgs e)
        {
            int _distancia_maxima = new int();
            if (string.IsNullOrEmpty(this.mskDistanciaAEmpresMax.Text))
            {
                _distancia_maxima = 0;
            }
            else
            {
                _distancia_maxima = Convert.ToInt32(this.mskDistanciaAEmpresMax.Text);
            }
            int _capacidad_minima = new int();
            if (string.IsNullOrEmpty(this.msktbEspacioNoAlquiladoMin.Text))
            {
                _capacidad_minima = 0;
            }
            else
            {
                _capacidad_minima = Convert.ToInt32(this.msktbEspacioNoAlquiladoMin.Text);
            }
            bsAlmacenes.DataSource = oCCUGAlmacenes.ObtenerAlmacenes(null, _distancia_maxima, _capacidad_minima);
            dgvAlmacenes.DataSource = bsAlmacenes;
        }


    }
}
