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
    public partial class frmPerfil : Form
    {
        private BindingSource bsGrupos = new BindingSource();
        private BindingSource bsFormularios = new BindingSource();
        private BindingSource bsPermisos = new BindingSource();
        private Controladora.CCUGPerfiles oCCUGPerfiles = new Controladora.CCUGPerfiles();
        private Modelo_Entidades.USUARIO oUsuarioActual;
        private static frmPerfil Instancia;
        private frmPerfil(Modelo_Entidades.USUARIO oUsu)
        {
            InitializeComponent();
            oUsuarioActual = oUsu;
        }
        public static frmPerfil ObtenerInstancia(Modelo_Entidades.USUARIO oUsu)
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmPerfil(oUsu);
            return Instancia;
        }

        private void frmPerfil_Load(object sender, EventArgs e)
        {
            bsGrupos.DataSource = oCCUGPerfiles.obtenerGrupos();
            cargarComboGrupos();
            bsFormularios.DataSource = oCCUGPerfiles.obtenerFormularios();
            cargarComboFormularios();
            bsPermisos.DataSource = oCCUGPerfiles.obtenerPermisos();
            cargarComboPermisos();
        }

        private void cargarComboGrupos()
        {
            cbGrupos.DataSource = bsGrupos;
            cbGrupos.DisplayMember = "GRU_DESCRIPCION";
            /*
            Modelo_Entidades.GRUPO oGrupo = new Modelo_Entidades.GRUPO();
            oGrupo.GRU_CODIGO = "TODOS";
            oGrupo.GRU_DESCRIPCION = "TODOS";
            cbGrupos.Items.Insert(0, oGrupo);
            cbGrupos.SelectedIndex = 0;
            
            cbGrupos.Text = null;
            cbGrupos.Text = "TODOS";
            */
            return;
        }
        private void cargarComboFormularios()
        {
            cbFormularios.DataSource = bsFormularios;
            cbFormularios.DisplayMember = "FRM_DESCRIPCION";
        }
        private void cargarComboPermisos()
        {
            cbPermisos.DataSource = bsPermisos;
            cbPermisos.DisplayMember = "MOD_DESCRIPCION";
        }

        private bool validarObligatorios()
        {
            if (string.IsNullOrEmpty(this.cbFormularios.Text))
            {
                this.cbFormularios.Focus();
                MessageBox.Show("Primero debe elegir un formulario.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(this.cbGrupos.Text))
            {
                this.cbGrupos.Focus();
                MessageBox.Show("Primero debe elegir un grupo.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(this.cbPermisos.Text))
            {
                this.cbPermisos.Focus();
                MessageBox.Show("Primero debe elegir un permiso.", "Faltan Datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarObligatorios())
            {
                Modelo_Entidades.PERFIL oPerfil = new Modelo_Entidades.PERFIL();
                oPerfil.AU_FECHA = DateTime.Now;
                oPerfil.AU_MOVIMIENTO = "A";
                oPerfil.AU_USUARIO = oUsuarioActual.USU_CODIGO;
                oPerfil.FORMULARIOS = (Modelo_Entidades.FORMULARIO)cbFormularios.SelectedItem;
                oPerfil.FRM_CODIGO = oPerfil.FORMULARIOS.FRM_CODIGO;
                //oPerfil.FRM_CODIGO = (Modelo_Entidades.FORMULARIO)cbFormularios.SelectedItem;
                //oPerfil.GRU_CODIGO = (Modelo_Entidades.GRUPO)cbGrupos.SelectedItem;
                oPerfil.GRUPOS = (Modelo_Entidades.GRUPO)cbGrupos.SelectedItem;
                oPerfil.GRU_CODIGO = oPerfil.GRUPOS.GRU_CODIGO;
                oPerfil.PERMISOS = (Modelo_Entidades.PERMISO)cbPermisos.SelectedItem;
                oPerfil.PER_CODIGO = oPerfil.PERMISOS.PER_CODIGO;

                try
                {
                    bool resultado = oCCUGPerfiles.ValidarPerfil(oPerfil);
                    if (!resultado)
                    {
                        resultado = oCCUGPerfiles.Agregar(oPerfil);
                        if (resultado)
                        {
                            MessageBox.Show("Guardado con éxito", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frmPerfiles.ObtenerInstancia().cargarGrillaPerfiles();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No guardado.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ya existe ese perfil.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (System.Data.DataException ex)
                {
                    MessageBox.Show("No se ha podido guardar el nuevo perfil: " + ex.Message + ".", "Error de base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
