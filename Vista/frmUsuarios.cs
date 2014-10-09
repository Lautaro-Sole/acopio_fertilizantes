using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vista
{
    internal partial class frmUsuarios : Vista.frmABM
    {
        private static frmUsuarios Instancia;
        private BindingSource bsUsuarios = new BindingSource();
        private Controladora.CCUGUsuarios oCCUGUsuarios = new Controladora.CCUGUsuarios();
        private Modelo_Entidades.USUARIO oUsuario;
        private DataTable TablaGrupos;
        private Controladora.CCUGGrupos oCCUGrupos = new Controladora.CCUGGrupos();

        Controladora.CCURPF oCCURPF = new Controladora.CCURPF();
        Modelo_Entidades.USUARIO oUsuarioActual;
        List<Modelo_Entidades.PERFIL> collPerfilesObtenidos = new List<Modelo_Entidades.PERFIL>();
        Modelo_Entidades.FORMULARIO oForm;

        public static frmUsuarios ObtenerInstancia()
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmUsuarios();
            return Instancia;
        }
        private frmUsuarios()
        {
            InitializeComponent();
        }


        private frmUsuarios(Modelo_Entidades.USUARIO oUsu)
        {
            InitializeComponent();
            oUsuarioActual = oUsu;
        }
        public static frmUsuarios ObtenerInstancia(Modelo_Entidades.USUARIO oUsu)
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmUsuarios(oUsu);
            return Instancia;
        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmUsuario ofrmUsuario = new frmUsuario();
            ofrmUsuario.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            oUsuario = (Modelo_Entidades.USUARIO)bsUsuarios.Current;
            if (oUsuario == null)
            {
                MessageBox.Show("Primero debe elegir un usuario.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmUsuario ofrmUsuario = new frmUsuario(oUsuario);
                ofrmUsuario.Show();
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oUsuario = (Modelo_Entidades.USUARIO)bsUsuarios.Current;
            if (oUsuario == null)
            {
                MessageBox.Show("Primero debe elegir un usuario.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult oDialogResult = MessageBox.Show("¿Está seguro que desea eliminar el usuario seleccionado?", "Confirmar eliminar.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oDialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (oCCUGUsuarios.ComprobarRelaciones(oUsuario.USU_CODIGO))
                        {
                            bool resultado = oCCUGUsuarios.Eliminar(oUsuario);
                            if (resultado)
                            {
                                MessageBox.Show("Usuario eliminado correctamente.", "Resultado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cargarGrillaUsuarios();
                            }
                            else
                            {
                                MessageBox.Show("El usuario no se pudo eliminar.", "Resultado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El usuario no se pudo eliminar porque ha intervenido en alguna operación.", "Resultado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (EntitySqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Excepción.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            Modelo_Entidades.PERFIL oPerfil = collPerfilesObtenidos.Find(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return oPerfilBuscado.PERMISOS.PER_CODIGO == "R"; });
            if (oPerfil == null)
            {
                this.btnResetearClave.Enabled = false;
                this.btnResetearClave.Visible = false;
            }

            BindingSource bsGrupos = new BindingSource();
            bsGrupos.DataSource = oCCUGrupos.ObtenerGrupos();
            Modelo_Entidades.GRUPO oGrupo = new Modelo_Entidades.GRUPO();
            oGrupo.GRU_DESCRIPCION= "TODOS";
            oGrupo.GRU_CODIGO ="TODOS";
            oGrupo.GRU_ESTADO = true;

            //bsGrupos.Add(oGrupo);
            bsGrupos.Insert(0, oGrupo);

            cbGrupo.DataSource = bsGrupos;
            cbGrupo.DisplayMember = "GRU_DESCRIPCION";
            //TablaGrupos = oCCUGrupos.ObtenerGrupos();


            cargarGrillaUsuarios();
            this.dgvUsuarios.Columns[3].Visible = false; //esconder clave
            this.dgvUsuarios.Columns[6].Visible = false; //esconder grupos
            this.dgvUsuarios.Columns[0].HeaderText = "Código de Usuario";
            this.dgvUsuarios.Columns[1].HeaderText = "Nombre del Usuario";
            this.dgvUsuarios.Columns[2].HeaderText = "Estado del Usuario";
            this.dgvUsuarios.Columns[4].HeaderText = "Apellido del Usuario";
            this.dgvUsuarios.Columns[5].HeaderText = "E-Mail del Usuario";

            this.ArmaPerfil(oUsuarioActual, this.Name);
            if (collPerfilesObtenidos.Find(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return oPerfilBuscado.PER_CODIGO == "R"; }) == null)
            {
                this.btnResetearClave.Enabled = true;
                this.btnResetearClave.Visible = true;
            }
            
            /*
            oForm = oCCURPF.obtenerFormulario(frmGrupos.ObtenerInstancia().Name);
            collPerfilesObtenidos = oCCURPF.recuperarPerfilForm(oUsuarioActual, oForm);
            if (collPerfilesObtenidos.Find(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return oPerfilBuscado.PER_CODIGO == "A"; }) == null)
            {
                this.btnAgregar.Enabled = true;
            }
            if (collPerfilesObtenidos.Find(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return oPerfilBuscado.PER_CODIGO == "B"; }) == null)
            {
                this.btnEliminar.Enabled = true;
            }
            if (collPerfilesObtenidos.Find(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return oPerfilBuscado.PER_CODIGO == "M"; }) == null)
            {
                this.btnModificar.Enabled = true;
            }
            */


            
        }

        public void cargarGrillaUsuarios()
        {
            bsUsuarios.DataSource = oCCUGUsuarios.ObtenerUsuarios();
            dgvUsuarios.DataSource = bsUsuarios;
        }

        private void btnResetearClave_Click(object sender, EventArgs e)
        {
            oUsuario = (Modelo_Entidades.USUARIO)bsUsuarios.Current;
            if (oUsuario == null)
            {
                MessageBox.Show("Primero debe elegir un usuario.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult oDialogResult = MessageBox.Show("¿Está seguro que desea resetear la clave del usuario seleccionado?", "Confirmar resetear.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oDialogResult == DialogResult.Yes)
                {
                    try
                    {
                        bool resultado = oCCUGUsuarios.ResetearClave(oUsuario);
                        if (resultado)
                        {
                            MessageBox.Show("Clave reseteada correctamente.", "Resultado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Clave no reseteada.", "Resultado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (EntitySqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Excepción.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        protected override void btnFiltrar_Click(object sender, EventArgs e)
        {
            bsUsuarios.DataSource = oCCUGUsuarios.ObtenerUsuarios(tbNombre.Text, tbApellido.Text, cbGrupo.Text, cbEstado.Text);
            //cargarGrillaUsuarios();


        }
    }
}
