using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Vista
{
    public partial class frmPrincipalAntiguo : Form
    {
        
        private static frmPrincipalAntiguo Instancia;
        private Modelo_Entidades.USUARIO oUsuario;
        Controladora.CCURPF oCCURPF = new Controladora.CCURPF();
        Controladora.CCULogOut oCCULogOut = new Controladora.CCULogOut();
        private Form miFORM;
        public static frmPrincipalAntiguo ObtenerInstancia()
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmPrincipalAntiguo();
            return Instancia;
        }
        
        private frmPrincipalAntiguo()
        {
            InitializeComponent();
        }


        private void frmPrincipalAntiguo_Load(object sender, EventArgs e)
        {
            this.Hide();
            //frmLogin.ObtenerInstancia().ShowDialog();

            if (frmLogin.ObtenerInstancia().ShowDialog() == DialogResult.OK)
            {
                oUsuario = frmLogin.ObtenerInstancia().oUsuario;
                armarMenu();
                this.Show();
            }
            else
            {
                this.Closing += new System.ComponentModel.CancelEventHandler(this.FormPrincipal_Closing);
                this.Close();
            }

        }

        public void armarMenu()
        {
            

            if (oUsuario == null)
            {
                MessageBox.Show("Error de login.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Closing -= new System.ComponentModel.CancelEventHandler(this.FormPrincipal_Closing);
                this.Close();
            }

            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormPrincipal_Closing);

            
            List<Modelo_Entidades.PERFIL> collPerfilesUsuario = Controladora.FachadaModuloSeguridad.ObtenerInstancia().recuperarPerfil(oUsuario);
            List<Modelo_Entidades.MODULO> ModulosExistentes = Controladora.FachadaModuloSeguridad.ObtenerInstancia().obtenerModulos();
            
            
            //
            ToolStripDropDownButton Menu_Modulo;


            foreach (Modelo_Entidades.PERFIL oPerfil in collPerfilesUsuario)
            {
                switch (oPerfil.FORMULARIOS.FRM_MODULO)
                {
                    case "seguridad":
                        this.btnMenuSeguridad.Enabled = true;
                        this.btnMenuSeguridad.Visible = true;
                        break;

                    case "core":
                        this.btnMenuAutorizaciones.Enabled = true;
                        this.btnMenuAutorizaciones.Visible = true;
                        break;

                    case "gestiones":
                        this.btnMenuGestiones.Enabled = true;
                        this.btnMenuGestiones.Visible = true;
                        break;
                }
            }
            foreach (Modelo_Entidades.PERFIL oPerfil in collPerfilesUsuario)
            {
                Modelo_Entidades.FORMULARIO oForm = oCCURPF.obtenerFormularios().Find(delegate(Modelo_Entidades.FORMULARIO oFormularioBuscado) { return oFormularioBuscado.FRM_CODIGO == oPerfil.FRM_CODIGO; });
                switch (oForm.FRM_FORMULARIO)
                {
                    case "frmAlmacenes":
                        this.btnAlmacenes.Visible = true;
                        break;
                    case "frmAlquileres":
                        this.btnAlquileres.Visible = true;
                        break;
                    case "frmAutorizaciones":
                        this.btnAutorizaciones.Visible = true;
                        break;
                    case "frmCargaYDescarga":
                        this.btnCargaYDescarga.Visible = true;
                        break;
                    case "frmChoferes":
                        this.btnChoferes.Visible = true;
                        break;
                    case "frmClientes":
                        this.btnClientes.Visible = true;
                        break;
                    case "frmGrupos":
                        this.btnGrupos.Visible = true;
                        break;
                    case "frmPerfiles":
                        this.btnPerfiles.Visible = true;
                        break;
                    case "frmRegistroIngreso":
                        this.btnReg_Ingreso.Visible = true;
                        break;
                    case "frmTransportes":
                        this.btnTransportes.Visible = true;
                        break;
                    case "frmUsuarios":
                        this.btnUsuarios.Visible = true;
                        break;
                }
            }

            lblUsuario.Text = "Usuario: " + oUsuario.USU_CODIGO;
        }


        public void armarMenu(Modelo_Entidades.USUARIO oUsuarioActual)
        {
            oUsuario = oUsuarioActual;

            if (oUsuarioActual == null)
            {
                MessageBox.Show("Error de login.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Closing -= new System.ComponentModel.CancelEventHandler(this.FormPrincipal_Closing);
                this.Close();
            }
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormPrincipal_Closing);

            Controladora.CCULogin oCCULogin = new Controladora.CCULogin();
            List<Modelo_Entidades.PERFIL> collPerfilesUsuario = oCCULogin.recuperarPerfil(oUsuario);
            List<Modelo_Entidades.MODULO> ModulosExistentes = oCCULogin.obtenerModulos();
            foreach (Modelo_Entidades.PERFIL oPerfil in collPerfilesUsuario)
            {
                switch (oPerfil.FORMULARIOS.FRM_MODULO)
                {
                    case "seguridad":
                        this.btnMenuSeguridad.Enabled = true;
                        this.btnMenuSeguridad.Visible = true;
                        break;

                    case "core":
                        this.btnMenuAutorizaciones.Enabled = true;
                        this.btnMenuAutorizaciones.Visible = true;

                        break;

                    case "gestiones":
                        this.btnMenuGestiones.Enabled = true;
                        this.btnMenuGestiones.Visible = true;

                        break;
                }
            }
            foreach (Modelo_Entidades.PERFIL oPerfil in collPerfilesUsuario)
            {
                Modelo_Entidades.FORMULARIO oForm = oCCURPF.obtenerFormularios().Find(delegate(Modelo_Entidades.FORMULARIO oFormularioBuscado){return oFormularioBuscado.FRM_CODIGO == oPerfil.FRM_CODIGO;});
                switch (oForm.FRM_FORMULARIO)
                {
                    case "frmAlmacenes":
                        this.btnAlmacenes.Visible = true;
                        break;
                    case "frmAlquileres":
                        this.btnAlquileres.Visible = true;
                        break;
                    case "frmAutorizaciones":
                        this.btnAutorizaciones.Visible = true;
                        break;
                    case "frmCargaYDescarga":
                        this.btnCargaYDescarga.Visible = true;
                        break;
                    case "frmChoferes":
                        this.btnChoferes.Visible = true;
                        break;
                    case "frmClientes":
                        this.btnClientes.Visible = true;
                        break;
                    case "frmGrupos":
                        this.btnGrupos.Visible = true;
                        break;
                    case "frmPerfiles":
                        this.btnPerfiles.Visible = true;
                        break;
                    case "frmRegistroIngreso":
                        this.btnReg_Ingreso.Visible = true;
                        break;
                    case "frmTransportes":
                        this.btnTransportes.Visible = true;
                        break;
                    case "frmUsuarios":
                        this.btnUsuarios.Visible = true;
                        break;
                }
            }

            lblUsuario.Text = "Usuario: " + oUsuario.USU_CODIGO;
        }
        
        /*
        public void armarMenu(Modelo_Entidades.USUARIO oUsuarioActual)
        {
            
            ToolStripDropDownButton MENU_MODULO;
            foreach (Modelo_Entidades.MODULO oModulo in oCCURPF.obtenerModulos())
            {
                // por cáda módulo creo un objeto ToolStripDropDownButton
                MENU_MODULO = new ToolStripDropDownButton();
                // le asigno los parámetros name y text al objeto
                MENU_MODULO.Name = oModulo.MOD_CODIGO;
                MENU_MODULO.Text = oModulo.MOD_DESCRIPCION;

                //inserto el objeto creado a la barra de menúes del formulario
                this.msMenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { MENU_MODULO });

                //busco las funciones asociadas al formulario
                agregarFormularios(oModulo, MENU_MODULO);
            }
        }

        private void agregarFormularios(Modelo_Entidades.MODULO oModulo, ToolStripDropDownButton MEN_FUNCION)
        {
            //le solicito a la controladora la lista de funciones de
            //un módulo determinado
            //defino un objeto ToolStripMenuItem para asignar las funciones recuperadas
            ToolStripMenuItem MENU_FUNCIONES;

            //recorro el listado de funciones
            foreach (Modelo_Entidades.FORMULARIO oForm in oCCURPF.obtenerFormularios(oUsuario.USU_CODIGO, oModulo.MOD_CODIGO))
            {
                // creo el objeto ToolStripMenuItem para cargar la funcion recibida
                MENU_FUNCIONES = new ToolStripMenuItem();
                MENU_FUNCIONES.Name = oForm.FRM_CODIGO.ToString();
                MENU_FUNCIONES.Text = oForm.FRM_DESCRIPCION;
                MENU_FUNCIONES.Tag = oForm.FRM_FORMULARIO;

                //agrego la función al módulo asociado
                MEN_FUNCION.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { MENU_FUNCIONES });

                //le asigno el método que tiene que ejecutar cuando se 
                //dispare el evento click de la función
                MENU_FUNCIONES.Click += new EventHandler(this.ITEM_CLICK);
            }
        }

        private void ITEM_CLICK(object sender, EventArgs e)
        {
            // al hacer click en algún objeto ToolStripMenuItem
            // se dispara este evento
            // el atributo sender me permite identificar que opción
            // del menú generó el evento
            ToolStripMenuItem seleccion = (ToolStripMenuItem)sender;
            // si el atributo tag es distinto de 0 es porque tiene definido 
            // el nombre dle formulario
            if ((string)seleccion.Tag != "0")
            {
                // le pido al compilador que me recupere todos los elementos del
                // asembly (proyecto VISTA)
                // comienzo a recorrer cada elemento devuelto
                foreach (System.Type type in Assembly.GetExecutingAssembly().GetTypes())
                {
                    //pregunto si es de tipo Formulario
                    if (type.IsSubclassOf(typeof(Form)))
                    {
                        // verifico si el nombre del formulario es igual al
                        // atributo tag que tiene el nombre del formulario
                        // a abrir
                        if (type.Name.ToString() == (string)seleccion.Tag)
                        {
                            try
                            {
                                //si corresponde creo una instancia de ese objeto
                                Type t = type as Type;
                                // aplicando reflection invoco el metodo getINSTANCIA del formulario
                                miFORM = (Form)t.InvokeMember("obtener_instancia", BindingFlags.Default | BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.InvokeMethod, null, null, new object[] { this.oUsuario }) as System.Windows.Forms.Form;
                                //ejecuto el método show del formulario para que lo muestre
                                miFORM.Show();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }
            }
        }  
        */



        private void recuperarClaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegenerarClave.ObtenerInstancia().ShowDialog();
        }

        private void btnRec_Clave_Click(object sender, EventArgs e)
        {
            frmCClave.ObtenerInstancia(oUsuario).Show();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            frmUsuarios.ObtenerInstancia(oUsuario).Show();
        }

        private void btnPerfiles_Click(object sender, EventArgs e)
        {
            frmPerfiles.ObtenerInstancia(oUsuario).Show();
        }

        private void btnGrupos_Click(object sender, EventArgs e)
        {
            frmGrupos.ObtenerInstancia(oUsuario).Show();
        }

        private void btnAlmacenes_Click(object sender, EventArgs e)
        {
            frmAlmacenes.ObtenerInstancia(oUsuario).Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmClientes.ObtenerInstancia(oUsuario).Show();
        }

        private void btnChoferes_Click(object sender, EventArgs e)
        {
            frmChoferes.ObtenerInstancia(oUsuario).Show();
        }

        private void btnTransportes_Click(object sender, EventArgs e)
        {
            frmTransportes.ObtenerInstancia(oUsuario).Show();
        }

        private void btnAlquileres_Click(object sender, EventArgs e)
        {
            frmAlquileres.ObtenerInstancia(oUsuario).Show();
        }

        private void btnReg_Ingreso_Click(object sender, EventArgs e)
        {
            frmRegistroIngreso.ObtenerInstancia(oUsuario).Show();
        }

        private void btnAutorizaciones_Click(object sender, EventArgs e)
        {
            frmOperaciones.ObtenerInstancia(oUsuario).Show();
        }

        private void btnCargaYDescarga_Click(object sender, EventArgs e)
        {
            frmCargaYDescarga.ObtenerInstancia(oUsuario).Show();
        }

        private void btnEquivalencias_Click(object sender, EventArgs e)
        {
            frmEquivalencias.ObtenerInstancia().Show();
        }

        private void FormPrincipal_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea salir?", "Confirmar Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                try
                {
                    bool resultado = oCCULogOut.LogOut(oUsuario);
                    if (resultado == true)
                    {
                        this.Closing -= new System.ComponentModel.CancelEventHandler(this.FormPrincipal_Closing);
                        this.Close();
                    }
                }
                catch (System.Data.DataException ex)
                {
                    MessageBox.Show("Error al registrar la salida del sistema. " + ex.Message, "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
