using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Windows.Forms;

namespace Vista
{
    public partial class frmCliente : Form
    {
        private string Modo;
        Controladora.CCUGClientes oCCUGClientes = new Controladora.CCUGClientes();
        Modelo_Entidades.Cliente oCliente;
        public frmCliente()
        {
            InitializeComponent();
            Modo = "Alta";
        }
        public frmCliente(Modelo_Entidades.Cliente ClienteEnviado)
        {
            InitializeComponent();
            Modo = "Modificacion";
            oCliente = ClienteEnviado;
        }
        private bool ValidarObligatorios()
        {
            if (string.IsNullOrEmpty(this.tbNombre.Text))
            {
                this.tbNombre.Focus();
                MessageBox.Show("Primero debe ingresar el nombre del cliente.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(this.msktbTelefono.Text))
            {
                this.tbEMail.Focus();
                MessageBox.Show("Primero debe escribir el teléfono del cliente.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(this.tbEMail.Text))
            {
                this.tbEMail.Focus();
                MessageBox.Show("Primero debe escribir el E-Mail del cliente.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string expresionregular = @"^((([\w]+\.[\w]+)+)|([\w]+))@(([\w]+\.)+)([A-Za-z]{1,3})$";
            if (!(Regex.IsMatch(this.tbEMail.Text, expresionregular))) //si el mail no concuerda con la expresion regular
            {
                this.tbEMail.Focus();
                MessageBox.Show("El E-Mail ingresado tiene un formato incorrecto.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else return true;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Modo == "Alta")
            {
                if (ValidarObligatorios())
                {
                    Modelo_Entidades.Cliente oCliente = new Modelo_Entidades.Cliente();
                    oCliente.nombre = this.tbNombre.Text;
                    oCliente.telefono = Convert.ToString(this.msktbTelefono.Text);
                    oCliente.email = this.tbEMail.Text;
                    bool resultado;
                    try
                    {
                        if (oCCUGClientes.ObtenerCliente(this.tbNombre.Text) == null)
                        {
                            resultado = oCCUGClientes.Agregar(oCliente);
                            if (resultado)
                            {
                                MessageBox.Show("Guardado con éxito", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                frmClientes.ObtenerInstancia().ActualizarDGVClientes();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("No guardado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ya existe un cliente con ese nombre.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (System.Data.EntitySqlException ex)
                    {
                        MessageBox.Show("No se ha podido guardar el nuevo cliente: " + ex + ".", "Error de base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (ValidarObligatorios())
                {
                    oCliente.nombre = this.tbNombre.Text;
                    oCliente.telefono = Convert.ToString(this.msktbTelefono.Text);
                    oCliente.email = this.tbEMail.Text;
                    bool resultado;
                    try
                    {
                        resultado = oCCUGClientes.Modificar(oCliente);
                        if (resultado)
                        {
                            MessageBox.Show("Actualizado con éxito", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmClientes.ObtenerInstancia().ActualizarDGVClientes();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No actualizado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    catch (System.Data.EntitySqlException ex)
                    {
                        MessageBox.Show("No se ha podido actualizar el cliente: " + ex + ".", "Error de base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            this.tbNombre.Text = oCliente.nombre;
            this.msktbTelefono.Text = oCliente.telefono;
            this.tbEMail.Text = oCliente.email;
        }
    }
    
}
