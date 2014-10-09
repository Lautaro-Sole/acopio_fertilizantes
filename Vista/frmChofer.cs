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
    public partial class frmChofer : Form
    {
        private string Modo;
        Controladora.CCUGClientes oCCUGClientes = new Controladora.CCUGClientes();
        Controladora.CCUGChoferes oCCUGChoferes = new Controladora.CCUGChoferes();
        Modelo_Entidades.Chofer oChofer;
        Modelo_Entidades.Cliente oCliente;
        BindingSource bsClientes = new BindingSource();
        public frmChofer()
        {
            InitializeComponent();
            Modo = "Alta";
        }
        public frmChofer(Modelo_Entidades.Chofer oChoferEnviado)
        {
            InitializeComponent();
            Modo = "Modificacion";
            oChofer = oChoferEnviado;
        }

        private void frmChofer_Load(object sender, EventArgs e)
        {
            bsClientes.DataSource = oCCUGClientes.ObtenerClientes();
            foreach (Modelo_Entidades.Cliente oClienteActual in bsClientes)
            {
                clbClientes.Items.Add(oClienteActual);
            }
            if (Modo == "Modificacion")
            {
                this.tbApellido.Text = oChofer.apellido;
                this.tbNombre.Text = oChofer.nombre;
                this.msktbDocumento.Text = Convert.ToString(oChofer.num_documento);
                this.cbTipo_Documento.Text = oChofer.tipo_documento;

                //this.dgvClientes.CurrentRow.DataBoundItem = oChofer.Cliente;

                for (int i = 0; i < clbClientes.Items.Count; i++) //para i desde 0 hasta la cantidad de items en clbClientes(todos)
                {
                    oCliente = (Modelo_Entidades.Cliente)clbClientes.Items[i];//mover el cliente con el índice 1 a oCliente
                    foreach (Modelo_Entidades.Cliente oClienteActual in oChofer.Clientes)//por cada uno de los clientes en la colección clientes de oChofer
                    {
                        if (oClienteActual.nro_cliente == oCliente.nro_cliente)// si el número del cliente actual es el mismo que el del cliente del checked list box seleccionado actualmente (i)
                        {
                            clbClientes.SetItemChecked(i, true);//entonces establezco como checkeado el cliene de índice i
                        }
                    }
                }

            }
        }

        private bool ValidarObligatorios()
        {
            if (string.IsNullOrEmpty(this.tbNombre.Text))
            {
                this.tbNombre.Focus();
                MessageBox.Show("Primero debe ingresar el nombre del chofer.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(this.cbTipo_Documento.Text))
            {
                this.cbTipo_Documento.Focus();
                MessageBox.Show("Primero debe ingresar el tipo de documento del chofer.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(this.msktbDocumento.Text))
            {
                this.msktbDocumento.Focus();
                MessageBox.Show("Primero debe ingresar el número de documento del chofer.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //Modelo_Entidades.Cliente oCliente= (Modelo_Entidades.Cliente) bsClientes.Current;
            if (oChofer.Clientes.Count==0)
            {
                MessageBox.Show("Primero debe seleccionar al menos un Cliente.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    oChofer = new Modelo_Entidades.Chofer();
                    oChofer.apellido = this.tbApellido.Text;
                    oChofer.nombre = this.tbNombre.Text;
                    oChofer.tipo_documento = this.cbTipo_Documento.Text;
                    oChofer.num_documento = Convert.ToInt32(this.msktbDocumento.Text);
                    oCliente=(Modelo_Entidades.Cliente)bsClientes.Current;
                    //agregar todos los clientes checkeados a la lista de grupos
                    foreach (object item in clbClientes.CheckedItems)//por cada objeto "item" de la lista de objetos checkeados en clbclientes
                    {
                        oChofer.Clientes.Add((Modelo_Entidades.Cliente)item);//agrego el item, después de transformarlo en cliente, a la colección
                    }
                    bool resultado;
                    try
                    {
                        if (oCCUGChoferes.ObtenerChofer(this.cbTipo_Documento.Text, Convert.ToInt32(this.msktbDocumento.Text)) == null)
                        {
                            resultado = oCCUGChoferes.Agregar(oChofer);
                            if (resultado)
                            {
                                MessageBox.Show("Guardado con éxito", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                frmChoferes.ObtenerInstancia().ActualizarDGVChoferes();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("No guardado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                frmChoferes.ObtenerInstancia().ActualizarDGVChoferes();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se pudo guardar el chofer porque ya existe uno con el tipo y número de documento ingresados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (System.Data.EntitySqlException ex)
                    {
                        MessageBox.Show("No se ha podido guardar el nuevo Chofer: " + ex + ".", "Error de base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (ValidarObligatorios())
                {
                    oChofer.apellido = this.tbApellido.Text;
                    oChofer.nombre = this.tbNombre.Text;
                    oChofer.tipo_documento = this.cbTipo_Documento.Text;
                    oChofer.num_documento = Convert.ToInt32(this.msktbDocumento.Text);
                    oCliente = (Modelo_Entidades.Cliente)bsClientes.Current;
                    oChofer.Clientes.Clear();//vaciar la lista de clientes del chofer
                    //agregar todos los clientes checkeados a la lista de grupos
                    foreach (object item in clbClientes.CheckedItems)//por cada objeto "item" de la lista de objetos checkeados en clbclientes
                    {
                        oChofer.Clientes.Add((Modelo_Entidades.Cliente)item);//agrego el item, después de transformarlo en cliente, a la colección
                    }
                    bool resultado;
                    try
                    {
                        resultado = oCCUGChoferes.Modificar(oChofer);
                        if (resultado)
                        {
                            MessageBox.Show("Actualizado con éxito", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmChoferes.ObtenerInstancia().ActualizarDGVChoferes();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No actualizado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    catch (System.Data.EntitySqlException ex)
                    {
                        MessageBox.Show("No se ha podido actualizar el Chofer: " + ex + ".", "Error de base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void gbFiltros_Enter(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
