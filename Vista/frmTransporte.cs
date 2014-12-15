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
    public partial class frmTransporte : Form
    {
        private string Modo;
        private BindingSource bsChoferes = new BindingSource();
        private BindingSource bsTransportes = new BindingSource();
        private Controladora.CCUGChoferes oCCUGChoferes = new Controladora.CCUGChoferes();
        private Controladora.CCUGTransportes oCCUGTransportes = new Controladora.CCUGTransportes();
        Modelo_Entidades.Chofer oChofer;
        Modelo_Entidades.Transporte oTransporte;
        public frmTransporte()
        {
            InitializeComponent();
            Modo = "Alta";
        }
        public frmTransporte(Modelo_Entidades.Transporte TransporteEnviado)
        {
            InitializeComponent();
            Modo = "Modificacion";
            oTransporte = TransporteEnviado;
        }

        private void frmTransporte_Load(object sender, EventArgs e)
        {
            bsChoferes.DataSource = oCCUGChoferes.ObtenerChoferes();
            foreach (Modelo_Entidades.Chofer oChoferActual in bsChoferes)
            {
                clbChoferes.Items.Add(oChoferActual);
            }
            if (Modo == "Modificacion")
            {
                //bsChoferes.Current = oTransporte.Chofer;//seleccionar el chofer en el dgv
                this.cbTipoMatricula.Text = oTransporte.Tipo_Matricula.descripcion;
                this.tbNumMatricula.Text = oTransporte.nro_matricula;
                this.msktbTara.Text = Convert.ToString(oTransporte.tara);
                this.msktbCargaMaxima.Text = oTransporte.carga_maxima.ToString();

                this.cbTipoMatricula.Enabled = false;
                this.tbNumMatricula.Enabled = false;

                for (int i = 0; i < clbChoferes.Items.Count; i++) //para i desde 0 hasta la cantidad de items en clbCchoferes(todos)
                {
                    oChofer = (Modelo_Entidades.Chofer)clbChoferes.Items[i];//mover el cliente con el índice i a oChofer
                    foreach (Modelo_Entidades.Chofer oChoferActual in oTransporte.Choferes)//por cada uno de los choferes en la colección clientes de oTransporte
                    {
                        if (oChoferActual.nro_chofer == oChofer.nro_chofer)// si el número del chofer actual es el mismo que el del chofer del checked list box seleccionado actualmente (i)
                        {
                            clbChoferes.SetItemChecked(i, true);//entonces establezco como checkeado el chofer de índice i
                        }
                    }
                }
            }
        }

        private bool ValidarObligatorios()
        {
            if (string.IsNullOrEmpty(this.cbTipoMatricula.Text))
            {
                this.cbTipoMatricula.Focus();
                MessageBox.Show("Primero debe ingresar el Tipo de ID.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(this.tbNumMatricula.Text))
            {
                this.tbNumMatricula.Focus();
                MessageBox.Show("Primero debe ingresar el número de ID.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //Modelo_Entidades.Chofer oChofer= (Modelo_Entidades.Chofer) bsChoferes.Current;
            if( oTransporte.Choferes.Count==0)
            {
                MessageBox.Show("Primero debe seleccionar al menos un chofer.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    oTransporte = new Modelo_Entidades.Transporte();
                    oChofer = (Modelo_Entidades.Chofer)bsChoferes.Current;
                    oTransporte.tipo_matricula = this.cbTipoMatricula.SelectedIndex;
                    oTransporte.nro_matricula = this.tbNumMatricula.Text;
                    oTransporte.tara = Convert.ToDouble(this.msktbTara.Text);
                    oTransporte.carga_maxima = Convert.ToDouble(this.msktbCargaMaxima);
                    foreach (object item in clbChoferes.CheckedItems)//por cada objeto "item" de la lista de objetos checkeados en clbchoferes
                    {
                        oTransporte.Choferes.Add((Modelo_Entidades.Chofer)item);//agrego el item, después de transformarlo en Chofer, a la colección
                    }
                    bool resultado;
                    try
                    {
                        if (oCCUGTransportes.ObtenerTransporte(this.cbTipoMatricula.Text, this.tbNumMatricula.Text) == null)
                        {
                            resultado = oCCUGTransportes.Agregar(oTransporte);
                            if (resultado)
                            {
                                MessageBox.Show("Guardado con éxito", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                frmTransportes.ObtenerInstancia().ActualizarDGVTransportes();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("No guardado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se pudo guardar el transporte porque ya existe uno con el tipo y número de matrícula ingresados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    oChofer = (Modelo_Entidades.Chofer)bsChoferes.Current;
                    oTransporte.tipo_matricula = this.cbTipoMatricula.SelectedIndex;
                    oTransporte.nro_matricula = this.tbNumMatricula.Text;
                    oTransporte.Choferes.Clear();
                    oTransporte.tara = Convert.ToDouble(this.msktbTara.Text);
                    oTransporte.carga_maxima = Convert.ToDouble(this.msktbCargaMaxima);
                    foreach (object item in clbChoferes.CheckedItems)//por cada objeto "item" de la lista de objetos checkeados en clbchoferes
                    {
                        oTransporte.Choferes.Add((Modelo_Entidades.Chofer)item);//agrego el item, después de transformarlo en Chofer, a la colección
                    }
                    bool resultado;
                    try
                    {
                        resultado = oCCUGTransportes.Modificar(oTransporte);
                        if (resultado)
                        {
                            MessageBox.Show("Actualizado con éxito", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmTransportes.ObtenerInstancia().ActualizarDGVTransportes();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No actualizado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    catch (System.Data.EntitySqlException ex)
                    {
                        MessageBox.Show("No se ha podido actualizar el transporte: " + ex + ".", "Error de base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
