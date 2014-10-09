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
    public partial class frmAlmacen : Form
    {
        //private static frmAlmacen Instancia;
        private string Modo;
        Controladora.CCUGAlmacenes oCCUGAlmacenes = new Controladora.CCUGAlmacenes();
        Modelo_Entidades.Almacen oAlmacen;
        public frmAlmacen()
        {
            InitializeComponent();
            Modo = "Alta";
        }
        public frmAlmacen(Modelo_Entidades.Almacen AlmacenEnviado)
        {
            InitializeComponent();
            Modo = "Modificacion";
            oAlmacen = AlmacenEnviado;

        }
        /*public static frmAlmacen ObtenerInstancia()
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmAlmacen();
            return Instancia;
        }
         * */
        private void frmAlmacen_Load(object sender, EventArgs e)
        {
            if (Modo == "Alta")
            {
                msktbCapacidad_no_Alquilada.Enabled = false;
            }
            else
            {
                tbDireccion.Text = oAlmacen.direccion;
                tbNombre.Text = oAlmacen.nombre;
                msktbDistancia.Text = Convert.ToString(oAlmacen.distancia_a_empresa);
                msktbCapacidad_no_Alquilada.Text = Convert.ToString(oAlmacen.ObtenerCapacidadNoAlquilada());
                msktbCapacidadTotal.Text = Convert.ToString(oAlmacen.capacidad);
                msktbDistancia.Enabled = false;
                tbDireccion.Enabled = false;
            }
        }

        private bool ValidarObligatorios()
        {
            if (string.IsNullOrEmpty(this.tbNombre.Text))
            {
                this.tbNombre.Focus();
                MessageBox.Show("Primero debe ingresar el nombre del almacén.","Faltan Datos.",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(this.tbDireccion.Text))
            {
                this.tbDireccion.Focus();
                MessageBox.Show("Primero debe ingresar la dirección del almacén.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(this.msktbDistancia.Text))
            {
                this.msktbDistancia.Focus();
                MessageBox.Show("Primero debe ingresar la distancia del almacén a la empresa.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(this.msktbCapacidadTotal.Text))
            {
                this.msktbCapacidadTotal.Focus();
                MessageBox.Show("Primero debe ingresar la superficie total del almacén.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    oAlmacen = new Modelo_Entidades.Almacen();
                    oAlmacen.nombre = this.tbNombre.Text;
                    oAlmacen.direccion = this.tbDireccion.Text;
                    oAlmacen.distancia_a_empresa = Convert.ToInt32(this.msktbDistancia.Text);
                    oAlmacen.capacidad = Convert.ToInt32(this.msktbCapacidadTotal.Text);
                    this.msktbCapacidad_no_Alquilada.Text = this.msktbCapacidadTotal.Text;
                    //oAlmacen.superficie_no_alquilada = Convert.ToInt32(this.msktbSupTotal.Text);
                    bool resultado;
                    try
                    {
                        if (oCCUGAlmacenes.ObtenerAlmacen(this.tbNombre.Text, this.tbDireccion.Text) == null)
                        {
                            resultado = oCCUGAlmacenes.Agregar(oAlmacen);
                            if (resultado)
                            {
                                MessageBox.Show("Guardado con éxito", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                frmAlmacenes.ObtenerInstancia().ActualizarDGVAlmacenes();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("No guardado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }
                        else
                        {
                            DialogResult oDialogResult = MessageBox.Show("Ya existe un Almacén con este Nombre o dirección, ¿Desea agregarlo de todas maneras?", "Confirmar.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (oDialogResult == DialogResult.Yes)
                            {
                                resultado = oCCUGAlmacenes.Agregar(oAlmacen);
                                if (resultado)
                                {
                                    MessageBox.Show("Guardado con éxito", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    frmAlmacenes.ObtenerInstancia().ActualizarDGVAlmacenes();
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("No guardado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Cancelado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }
                    }
                    catch (System.Data.DataException ex)
                    {
                        MessageBox.Show("No se ha podido guardar el nuevo almacén: " + ex + ".", "Error de base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (ValidarObligatorios())
                {
                    if (oAlmacen.CapacidadAlquilada <= Convert.ToDouble(msktbCapacidadTotal.Text))
                    {
                        oAlmacen.nombre = this.tbNombre.Text;
                        oAlmacen.direccion = this.tbDireccion.Text;
                        oAlmacen.distancia_a_empresa = Convert.ToInt32(this.msktbDistancia.Text);
                        oAlmacen.capacidad = Convert.ToInt32(this.msktbCapacidadTotal.Text);
                        //oAlmacen.superficie_no_alquilada = Convert.ToInt32(this.msktbSup_no_Alquilada.Text);
                        bool resultado;
                        try
                        {
                            resultado = oCCUGAlmacenes.Modificar(oAlmacen);
                            if (resultado)
                            {
                                MessageBox.Show("Actualizado con éxito", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                frmAlmacenes.ObtenerInstancia().ActualizarDGVAlmacenes();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("No guardado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }
                        catch (System.Data.EntitySqlException ex)
                        {
                            MessageBox.Show("No se ha podido actualizar el almacén: " + ex + ".", "Error de base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La capacidad nueva del almacén no puede ser menor a la capacidad alquilada.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
