using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Vista
{
    internal partial class frmGrupos : Vista.frmABM
    {
        private static frmGrupos Instancia;
        BindingSource bsGrupos = new BindingSource();
        Controladora.CCUGGrupos oCCUGGrupos = new Controladora.CCUGGrupos();
        Modelo_Entidades.GRUPO oGrupo;

        //Controladora.CCURPF oCCURPF = new Controladora.CCURPF();
        
        //List<Modelo_Entidades.PERFIL> collPerfilesObtenidos = new List<Modelo_Entidades.PERFIL>();
        private frmGrupos()
        {
            InitializeComponent();
        }
        
        public static frmGrupos ObtenerInstancia()
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmGrupos();
            return Instancia;
        }
        Modelo_Entidades.USUARIO oUsuarioActual;
        private frmGrupos(Modelo_Entidades.USUARIO oUsu)
        {
            InitializeComponent();
            oUsuarioActual = oUsu;
        }
        public static frmGrupos ObtenerInstancia(Modelo_Entidades.USUARIO oUsu)
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmGrupos(oUsu);
            return Instancia;
        }

        public void cargarGrillaGrupos()
        {
            bsGrupos.DataSource = oCCUGGrupos.ObtenerGrupos();
            dgvGrupos.DataSource = bsGrupos;
        }
        private void frmGrupos_Load(object sender, EventArgs e)
        {

            cargarGrillaGrupos();
            this.dgvGrupos.Columns[3].Visible = false; //esconder perfiles
            this.dgvGrupos.Columns[4].Visible = false; //esconder usuarios
            this.dgvGrupos.Columns[0].HeaderText = "Código de Grupo";
            this.dgvGrupos.Columns[1].HeaderText = "Descripción del grupo";
            this.dgvGrupos.Columns[2].HeaderText = "Estado del Grupo";

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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmGrupo ofrmGrupo = new frmGrupo();
            ofrmGrupo.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            oGrupo = (Modelo_Entidades.GRUPO)bsGrupos.Current;
            if (oGrupo == null)
            {
                MessageBox.Show("Primero debe elegir un grupo.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmGrupo ofrmGrupo = new frmGrupo(oGrupo);
                ofrmGrupo.Show();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            oGrupo = (Modelo_Entidades.GRUPO)bsGrupos.Current;
            if (oGrupo == null)
            {
                MessageBox.Show("Primero debe elegir un grupo.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult oDialogResult = MessageBox.Show("¿Está seguro que desea eliminar el grupo seleccionado?", "Confirmar eliminar.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oDialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (ComprobarRelaciones())
                        {
                            bool resultado = oCCUGGrupos.Eliminar(oGrupo);
                            if (resultado)
                            {
                                MessageBox.Show("Grupo eliminado correctamente.", "Resultado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cargarGrillaGrupos();
                            }
                            else
                            {
                                MessageBox.Show("El grupo no se pudo eliminar.", "Resultado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El grupo no se puede eliminar porque se le han asignado uno o más usuarios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (System.Data.DataException ex)
                    {
                        MessageBox.Show("No se puede borrar un grupo que contenga usuarios. Excepción interna: " + ex.InnerException.Message, "Excepción.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        protected override void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.tbDescripcionGrupo.Text))
            {
                switch (cbEstadoGrupo.Text)
                {
                    case "TODOS":
                        bsGrupos.DataSource = oCCUGGrupos.ObtenerGrupos();
                        dgvGrupos.DataSource = bsGrupos;
                        break;
                    case "Activos":
                        bsGrupos.DataSource = oCCUGGrupos.ObtenerGrupos(true);
                        dgvGrupos.DataSource = bsGrupos;
                        break;
                    case "Inactivos":
                        bsGrupos.DataSource = oCCUGGrupos.ObtenerGrupos(false);
                        dgvGrupos.DataSource = bsGrupos;
                        break;
                }
            }
            else
            {
                switch (cbEstadoGrupo.Text)
                {
                    case "TODOS":
                        bsGrupos.DataSource = oCCUGGrupos.ObtenerGrupos(this.tbDescripcionGrupo.Text);
                        dgvGrupos.DataSource = bsGrupos;
                        break;
                    case "Activos":
                        bsGrupos.DataSource = oCCUGGrupos.ObtenerGrupos(this.tbDescripcionGrupo.Text, true);
                        dgvGrupos.DataSource = bsGrupos;
                        break;
                    case "Inactivos":
                        bsGrupos.DataSource = oCCUGGrupos.ObtenerGrupos(this.tbDescripcionGrupo.Text, false);
                        dgvGrupos.DataSource = bsGrupos;
                        break;
                }
            }
        }

        private void btnFiltrar_Click_1(object sender, EventArgs e)
        {
            switch (cbEstadoGrupo.Text)
            {
                case "TODOS":
                    bsGrupos.DataSource = oCCUGGrupos.ObtenerGrupos();
                    dgvGrupos.DataSource = bsGrupos;
                    break;
                case "Activos":
                    bsGrupos.DataSource = oCCUGGrupos.ObtenerGrupos(true);
                    dgvGrupos.DataSource = bsGrupos;
                    break;
                case "Inactivos":
                    bsGrupos.DataSource = oCCUGGrupos.ObtenerGrupos(false);
                    dgvGrupos.DataSource = bsGrupos;
                    break;
            }
        }

        private void btnFiltrar_Click_2(object sender, EventArgs e)
        {
            switch (cbEstadoGrupo.Text)
            {
                case "TODOS":
                    bsGrupos.DataSource = oCCUGGrupos.ObtenerGrupos();
                    dgvGrupos.DataSource = bsGrupos;
                    break;
                case "Activos":
                    bsGrupos.DataSource = oCCUGGrupos.ObtenerGrupos(true);
                    dgvGrupos.DataSource = bsGrupos;
                    break;
                case "Inactivos":
                    bsGrupos.DataSource = oCCUGGrupos.ObtenerGrupos(false);
                    dgvGrupos.DataSource = bsGrupos;
                    break;
            }
        }

        private void btnFiltrar_Click_3(object sender, EventArgs e)
        {
            switch (cbEstadoGrupo.Text)
            {
                case "TODOS":
                    bsGrupos.DataSource = oCCUGGrupos.ObtenerGrupos();
                    dgvGrupos.DataSource = bsGrupos;
                    break;
                case "Activos":
                    bsGrupos.DataSource = oCCUGGrupos.ObtenerGrupos(true);
                    dgvGrupos.DataSource = bsGrupos;
                    break;
                case "Inactivos":
                    bsGrupos.DataSource = oCCUGGrupos.ObtenerGrupos(false);
                    dgvGrupos.DataSource = bsGrupos;
                    break;
            }
        }

        private void btnFiltrar_Click_4(object sender, EventArgs e)
        {

        }

        private bool ComprobarRelaciones()
        {
            if ((oGrupo.USUARIOS.Count == 0) && (oGrupo.PERFILES.Count == 0))
                return true;
            else return false;
        }

    }
}
