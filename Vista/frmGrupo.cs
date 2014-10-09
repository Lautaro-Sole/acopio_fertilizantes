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
    public partial class frmGrupo : Form
    {
        string Modo;
        Modelo_Entidades.GRUPO oGrupo;
        Controladora.CCUGGrupos oCCUGGrupos = new Controladora.CCUGGrupos();
        public frmGrupo()
        {
            InitializeComponent();
            Modo = "Alta";
        }
        public frmGrupo(Modelo_Entidades.GRUPO oGrupoEnviado)
        {
            InitializeComponent();
            Modo = "Modificacion";
            oGrupo = oGrupoEnviado;
        }

        private bool validarObligatorios()
        {
            if (string.IsNullOrEmpty(this.tbCodigo.Text))
            {
                this.tbCodigo.Focus();
                MessageBox.Show("Primero debe ingresar el código del grupo.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(this.tbDescripcion.Text))
            {
                this.tbCodigo.Focus();
                MessageBox.Show("Primero debe ingresar la descripción del grupo.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(this.cbEstado.Text))
            {
                this.tbCodigo.Focus();
                MessageBox.Show("Primero debe elegir el estado del grupo.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else return true;
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (validarObligatorios())
            {
                bool resultado;

                if (Modo == "Alta")
                {
                    resultado = oCCUGGrupos.ObtenerGrupo(tbDescripcion.Text);
                    if (resultado)
                    {
                        MessageBox.Show("Ya existe un grupo con esa descripción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        oGrupo = new Modelo_Entidades.GRUPO();
                        oGrupo = asignardatos(oGrupo);
                        try
                        {
                            resultado = oCCUGGrupos.Agregar(oGrupo);
                            if (resultado)
                            {
                                MessageBox.Show("Guardado con éxito", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                frmGrupos.ObtenerInstancia().cargarGrillaGrupos();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("No guardado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }
                        catch (System.Data.DataException ex)
                        {
                            MessageBox.Show("No se ha podido guardar el nuevo grupo: " + ex.Message + ".", "Error de base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else //modificación
                {
                    oGrupo = asignardatos(oGrupo);
                    resultado = oCCUGGrupos.ObtenerGrupo(oGrupo.GRU_CODIGO, oGrupo.GRU_DESCRIPCION);
                    if (!resultado)
                    {
                        MessageBox.Show("Ya existe un grupo distinto con esa descripción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        try
                        {
                            resultado = oCCUGGrupos.Modificar(oGrupo);
                            if (resultado)
                            {
                                MessageBox.Show("Actualizado con éxito", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                frmGrupos.ObtenerInstancia().cargarGrillaGrupos();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("No actualizado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }
                        catch (System.Data.DataException ex)
                        {
                            MessageBox.Show("No se ha podido actualizar el grupo: " + ex.Message + ".", "Error de base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    
                }
            }
        }

        private Modelo_Entidades.GRUPO asignardatos(Modelo_Entidades.GRUPO unGrupo)
        {
            unGrupo.GRU_CODIGO = this.tbCodigo.Text;
            unGrupo.GRU_DESCRIPCION = this.tbDescripcion.Text;
            if (this.cbEstado.Text == "Activo")
            {
                unGrupo.GRU_ESTADO = true;
            }
            else
            {
                unGrupo.GRU_ESTADO = false;
            }
            return unGrupo;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGrupo_Load(object sender, EventArgs e)
        {
            if (Modo == "Modificacion")
            {
                this.tbCodigo.Text = oGrupo.GRU_CODIGO;
                this.tbCodigo.Enabled = false;
                this.tbDescripcion.Text = oGrupo.GRU_DESCRIPCION;
                if (oGrupo.GRU_ESTADO == true)
                {
                    this.cbEstado.Text = "Activo";
                }
                else
                {
                    this.cbEstado.Text = "Inactivo";
                }
            }
        }
    }
}
