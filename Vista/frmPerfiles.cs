using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vista
{
    internal partial class frmPerfiles : Vista.frmABM
    {
        private static frmPerfiles Instancia;
        private BindingSource bsGrupos = new BindingSource();
        private BindingSource bsFormularios = new BindingSource();
        private BindingSource bsPermisos = new BindingSource();
        private BindingSource bsPerfiles = new BindingSource();
        private Controladora.CCUGPerfiles oCCUGPerfiles = new Controladora.CCUGPerfiles();
        private Modelo_Entidades.PERFIL oPerfil;

        Controladora.CCURPF oCCURPF = new Controladora.CCURPF();
        Modelo_Entidades.USUARIO oUsuarioActual;
        List<Modelo_Entidades.PERFIL> collPerfilesObtenidos = new List<Modelo_Entidades.PERFIL>();
        Modelo_Entidades.FORMULARIO oForm;

        public static frmPerfiles ObtenerInstancia()
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmPerfiles();
            return Instancia;
        }
        private frmPerfiles()
        {
            InitializeComponent();
        }

        private frmPerfiles(Modelo_Entidades.USUARIO oUsu)
        {
            InitializeComponent();
            oUsuarioActual = oUsu;
        }
        public static frmPerfiles ObtenerInstancia(Modelo_Entidades.USUARIO oUsu)
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmPerfiles(oUsu);
            return Instancia;
        }


        

        private void frmPerfiles_Load(object sender, EventArgs e)
        {
            this.btnModificar.Enabled = false;
            this.btnModificar.Visible = false;
            bsGrupos.DataSource = oCCUGPerfiles.obtenerGrupos();
            cargarComboGrupos();
            bsFormularios.DataSource = oCCUGPerfiles.obtenerFormularios();
            cargarComboFormularios();
            bsPermisos.DataSource = oCCUGPerfiles.obtenerPermisos();
            cargarComboPermisos();
            cargarGrillaPerfiles();

            this.ArmaPerfil(oUsuarioActual, this.Name);

            /*
            oForm = oCCURPF.obtenerFormulario(frmGrupos.ObtenerInstancia().Name);
            collPerfilesObtenidos = oCCURPF.recuperarPerfilForm(oUsuarioActual, oForm);
            if (collPerfilesObtenidos.Find(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return oPerfilBuscado.PER_CODIGO == "A"; }) == null)
            {
                this.btnAgregar.Enabled = false;
            }
            if (collPerfilesObtenidos.Find(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return oPerfilBuscado.PER_CODIGO == "B"; }) == null)
            {
                this.btnEliminar.Enabled = false;
            }
            if (collPerfilesObtenidos.Find(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return oPerfilBuscado.PER_CODIGO == "M"; }) == null)
            {
                this.btnModificar.Enabled = false;
            }
            */            
        }

        private void cargarComboGrupos()
        {
            Modelo_Entidades.GRUPO oGrupo = new Modelo_Entidades.GRUPO();
            oGrupo.GRU_CODIGO = "TODOS";
            oGrupo.GRU_DESCRIPCION = "TODOS";
            bsGrupos.Insert(0, oGrupo);
            cbGrupos.DataSource = bsGrupos;
            cbGrupos.DisplayMember = "GRU_DESCRIPCION";
            //cbGrupos.SelectedIndex = 0;
            
        }
        private void cargarComboFormularios()
        {
            //cbFormularios.DataSource = oCCUGPerfiles.obtenerFormularios();
            Modelo_Entidades.FORMULARIO oFormulario = new Modelo_Entidades.FORMULARIO();
            oFormulario.FRM_CODIGO = "TODOS";
            oFormulario.FRM_DESCRIPCION = "TODOS";
            bsFormularios.Insert(0, oFormulario);
            cbFormularios.DataSource = bsFormularios;
            cbFormularios.DisplayMember = "FRM_DESCRIPCION";
            
            //cbGrupos.SelectedIndex = 0;
            
        }
        private void cargarComboPermisos()
        {
            Modelo_Entidades.PERMISO oPermiso = new Modelo_Entidades.PERMISO();
            oPermiso.PER_CODIGO = "TODOS";
            oPermiso.PER_DESCRIPCION = "TODOS";
            bsPermisos.Insert(0, oPermiso);
            cbPermisos.DataSource = bsPermisos;
            cbPermisos.DisplayMember = "MOD_DESCRIPCION";
            //cbPermisos.SelectedIndex = 0;

        }

        public void cargarGrillaPerfiles()
        {
            bsPerfiles.DataSource=oCCUGPerfiles.obtenerPerfiles();
            dgvPerfiles.DataSource = bsPerfiles;

            dgvPerfiles.Columns["FORMULARIOS"].DisplayIndex = 0;
            dgvPerfiles.Columns["GRUPOS"].DisplayIndex = 1;
            dgvPerfiles.Columns["PERMISOS"].DisplayIndex = 2;
            dgvPerfiles.Columns["AU_USUARIO"].DisplayIndex = 3;
            dgvPerfiles.Columns["AU_MOVIMIENTO"].DisplayIndex = 4;
            dgvPerfiles.Columns["AU_FECHA"].DisplayIndex = 5;

            dgvPerfiles.Columns["FORMULARIOS"].HeaderText = "Formulario";
            dgvPerfiles.Columns["GRUPOS"].HeaderText = "Grupo";
            dgvPerfiles.Columns["PERMISOS"].HeaderText = "Permiso";
            dgvPerfiles.Columns["AU_USUARIO"].HeaderText = "Usuario";
            dgvPerfiles.Columns["AU_MOVIMIENTO"].HeaderText = "Movimiento";
            dgvPerfiles.Columns["AU_FECHA"].HeaderText = "Fecha";

            dgvPerfiles.Columns["PRF_CODIGO"].Visible = false;
            dgvPerfiles.Columns["FRM_CODIGO"].Visible = false;
            dgvPerfiles.Columns["GRU_CODIGO"].Visible = false;
            dgvPerfiles.Columns["PER_CODIGO"].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmPerfil ofrmPerfil = frmPerfil.ObtenerInstancia(oUsuarioActual);
            ofrmPerfil.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oPerfil = (Modelo_Entidades.PERFIL)bsPerfiles.Current;
            if (oPerfil == null)
            {
                MessageBox.Show("Primero debe elegir un Perfil.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult oDialogResult = MessageBox.Show("¿Está seguro que desea eliminar el Perfil seleccionado?", "Confirmar eliminar.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oDialogResult == DialogResult.Yes)
                {
                    try
                    {
                        bool resultado = oCCUGPerfiles.Eliminar(oPerfil);
                        if (resultado)
                        {
                            MessageBox.Show("Perfil eliminado correctamente.", "Resultado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cargarGrillaPerfiles();
                        }
                        else
                        {
                            MessageBox.Show("El Perfil no se pudo eliminar.", "Resultado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (System.Data.DataException ex)
                    {
                        MessageBox.Show("No se puede borrar el Perfil. Excepción interna: " + ex.InnerException.Message, "Excepción.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void gbAcciones_Enter(object sender, EventArgs e)
        {

        }

        protected override void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (cbFormularios.Text == "TODOS" || string.IsNullOrWhiteSpace(cbFormularios.Text))
            {
                if (cbGrupos.Text == "TODOS" || string.IsNullOrWhiteSpace(cbGrupos.Text))
                {
                    if (cbPermisos.Text == "TODOS" || string.IsNullOrWhiteSpace(cbPermisos.Text))
                    {
                        cargarGrillaPerfiles();
                    }
                    else
                    {
                        bsPerfiles.DataSource = oCCUGPerfiles.obtenerPerfiles((Modelo_Entidades.PERMISO)bsPermisos.Current);
                        dgvPerfiles.DataSource = bsPerfiles;
                    }
                }
                else
                {
                    if (cbPermisos.Text == "TODOS" || string.IsNullOrWhiteSpace(cbPermisos.Text))
                    {
                        bsPerfiles.DataSource = oCCUGPerfiles.obtenerPerfiles((Modelo_Entidades.GRUPO)bsGrupos.Current);
                        dgvPerfiles.DataSource = bsPerfiles;
                    }
                    else
                    {
                        bsPerfiles.DataSource = oCCUGPerfiles.obtenerPerfiles((Modelo_Entidades.GRUPO)bsGrupos.Current, (Modelo_Entidades.PERMISO)bsPermisos.Current);
                        dgvPerfiles.DataSource = bsPerfiles;
                    }
                }
            }
            else
            {
                if (cbGrupos.Text == "TODOS" || string.IsNullOrWhiteSpace(cbGrupos.Text))
                {
                    if (cbPermisos.Text == "TODOS" || string.IsNullOrWhiteSpace(cbPermisos.Text))
                    {
                        bsPerfiles.DataSource = oCCUGPerfiles.obtenerPerfiles((Modelo_Entidades.FORMULARIO)bsFormularios.Current);
                        dgvPerfiles.DataSource = bsPerfiles;
                    }
                    else
                    {
                        bsPerfiles.DataSource = oCCUGPerfiles.obtenerPerfiles((Modelo_Entidades.FORMULARIO)bsFormularios.Current, (Modelo_Entidades.PERMISO)bsPermisos.Current);
                        dgvPerfiles.DataSource = bsPerfiles;
                    }
                }
                else
                {
                    if (cbPermisos.Text == "TODOS" || string.IsNullOrWhiteSpace(cbPermisos.Text))
                    {
                        bsPerfiles.DataSource = oCCUGPerfiles.obtenerPerfiles((Modelo_Entidades.FORMULARIO)bsFormularios.Current, (Modelo_Entidades.GRUPO)bsGrupos.Current);
                        dgvPerfiles.DataSource = bsPerfiles;
                    }
                    else
                    {
                        bsPerfiles.DataSource = oCCUGPerfiles.obtenerPerfiles((Modelo_Entidades.FORMULARIO)bsFormularios.Current, (Modelo_Entidades.GRUPO)bsGrupos.Current, (Modelo_Entidades.PERMISO)bsPermisos.Current);
                        dgvPerfiles.DataSource = bsPerfiles;
                    }
                }
            }
        }

    }
}
