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
    public partial class frmPrincipal : Form
    {
        
        private static frmPrincipal Instancia;
        private Modelo_Entidades.USUARIO oUsuario;
        Controladora.CCURPF oCCURPF = new Controladora.CCURPF();
        Controladora.CCULogOut oCCULogOut = new Controladora.CCULogOut();
        private Form miFORM;

        List<Modelo_Entidades.PERFIL> collPerfilesUsuario;
        List<Modelo_Entidades.MODULO> ModulosExistentes;


        public static frmPrincipal ObtenerInstancia()
        {
            if (Instancia == null || Instancia.IsDisposed == true)
                Instancia = new frmPrincipal();
            return Instancia;
        }
        
        private frmPrincipal()
        {
            InitializeComponent();
        }


        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            this.Hide();
            //frmLogin.ObtenerInstancia().ShowDialog();

            if (frmLogin.ObtenerInstancia().ShowDialog() == DialogResult.OK)
            {
                oUsuario = frmLogin.ObtenerInstancia().oUsuario;
                armarMenu();
                //habilitar botones extra
                habilitarBotones();
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

            
            collPerfilesUsuario = Controladora.FachadaModuloSeguridad.ObtenerInstancia().recuperarPerfil(oUsuario);
            ModulosExistentes = Controladora.FachadaModuloSeguridad.ObtenerInstancia().obtenerModulos();
            
            
            //
            ToolStripDropDownButton Menu_Modulo;
            List<string> oListaNombresMenuesCreados = new List<string>();
            //tomar la colección de perfiles del usuario y recorrerla
            foreach (Modelo_Entidades.PERFIL oPerfilActual in collPerfilesUsuario)
            {
                //obtener el módulo al que pertenece el formulario
                Modelo_Entidades.MODULO oModuloActual = oPerfilActual.FORMULARIOS.MODULOS;

                //si no existe el dropdownbutton del módulo agregarlo
                /*
                ToolStripDropDownButton oTSDDBEncontrado = msMenuPrincipal.Items.Find(oModuloActual.MOD_DESCRIPCION, true);
                //Find(delegate(ToolStripItem oTSDDBActual){return (oTSDDBActual.Text == oModuloActual.MOD_DESCRIPCION) ;});
                if ((oTSDDBEncontrado == null)||(oTSDDBEncontrado.Count<ToolStripItem>() == 0))
                 * */
                if (null == oListaNombresMenuesCreados.Find(delegate(string cadenabuscada){return cadenabuscada == oModuloActual.MOD_DESCRIPCION;}))
                {
                    // no existe, entonces creo el botón
                    Menu_Modulo = new ToolStripDropDownButton();
                    Menu_Modulo.Name = "tsddb" + oModuloActual.MOD_DESCRIPCION;
                    Menu_Modulo.Text = oModuloActual.MOD_DESCRIPCION;
                    //agrego el botón a la barra
                    msMenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { Menu_Modulo });
                    // llamar la función que llena el menú con los botones de los formularios a los que puede acceder el usuario
                    AgregarBotones(Menu_Modulo, oModuloActual.MOD_DESCRIPCION);

                    //agregar el manejador del botón
                    Menu_Modulo.Click += new EventHandler(this.ItemClick);

                    //agregar el nombre del menú a la lista de módulos con menú generado
                    oListaNombresMenuesCreados.Add(oModuloActual.MOD_DESCRIPCION);
                }

            }
            lblUsuario.Text = "Usuario: " + oUsuario.USU_CODIGO;

            //agregar los menúes y formularios universales
            ToolStripMenuItem botonFormulario;
            //barra herramientas
            Menu_Modulo = new ToolStripDropDownButton();
            Menu_Modulo.Name = "tsddb" + "Herramientas";
            Menu_Modulo.Text = "Herramientas";
            msMenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { Menu_Modulo });
            //botón equivalencias
            botonFormulario = new ToolStripMenuItem();
            botonFormulario.Name = "tsmi" + "frmEquivalencias";
            botonFormulario.Text = "Equivalencias";
            botonFormulario.Tag = "frmEquivalencias";
            // agrego el botón a el menú del módulo
            Menu_Modulo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { botonFormulario });
            // agregar el manejador del click al botón
            botonFormulario.Click += new EventHandler(this.ItemClick);

            //barra Usuario
            Menu_Modulo = new ToolStripDropDownButton();          
            Menu_Modulo.Name = "tsddb" + "Usuario";
            Menu_Modulo.Text = "Usuario";
            msMenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { Menu_Modulo });
            //botón RecuperarClave
            botonFormulario = new ToolStripMenuItem();
            botonFormulario.Name = "tsmi" + "frmCClave";
            botonFormulario.Text = "Cambiar Clave";
            botonFormulario.Tag = "frmCClave";
            // agrego el botón a el menú del módulo
            Menu_Modulo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { botonFormulario });
            // agregar el manejador del click al botón
            botonFormulario.Click += new EventHandler(this.ItemClick);
        }

        // Armo los menues y submenues
        private void AgregarBotones(ToolStripDropDownButton Menu_Modulo, string modulo)
        {
            // Le solicito a la controladora la lista de funciones de un módulo determinado.
            ToolStripMenuItem botonFormulario;
            List<String> oListaBotonesAgregados = new List<string>();

            // Obtener la lista de formularios del módulo
            List<Modelo_Entidades.FORMULARIO> oListaFormularios = new List<Modelo_Entidades.FORMULARIO>();
            foreach (Modelo_Entidades.PERFIL oPerfilActual in collPerfilesUsuario)
            {
                if (oPerfilActual.FORMULARIOS.MODULOS.MOD_DESCRIPCION == modulo)
                {
                    oListaFormularios.Add(oPerfilActual.FORMULARIOS);
                }
            }

            foreach (Modelo_Entidades.FORMULARIO oFormularioActual in oListaFormularios)
            {
                // si el botón aún no ha sido agregado
                if (null == oListaBotonesAgregados.Find(delegate(string cadenabuscada) { return cadenabuscada == oFormularioActual.FRM_FORMULARIO; }))
                {
                    // creo el botón para el formulario
                    botonFormulario = new ToolStripMenuItem();
                    botonFormulario.Name = oFormularioActual.FRM_FORMULARIO;
                    botonFormulario.Text = oFormularioActual.FRM_DESCRIPCION;
                    botonFormulario.Tag = oFormularioActual.FRM_FORMULARIO;

                    // agrego el botón a el menú del módulo
                    Menu_Modulo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { botonFormulario });

                    // agregar el manejador del click al botón
                    botonFormulario.Click += new EventHandler(this.ItemClick);
                    //agrego el botón a la lista
                    oListaBotonesAgregados.Add(oFormularioActual.FRM_FORMULARIO);
                }
            }
        }


        // Establecer lo que pasa cuando al clickear en los menúes y botones
        private void ItemClick(object sender, EventArgs e)
        {
            // Al hacer click en algún objeto ToolStripMenuItem se dispara este evento.
            // El objeto sender me permite identificar que opción del menú generó el evento.
            
            
            //verificar si el el objeto sender es un botón
            if (sender.GetType() == typeof(ToolStripMenuItem))
            {
                ToolStripMenuItem seleccion = (ToolStripMenuItem)sender;
                // Si el atributo tag es distinto de 0 es porque tiene definido el nombre del formulario.
                if ((string)seleccion.Tag != "0")
                {
                    // Le pido al compilador que me recupere todos los elementos del asembly (proyecto Vista)               
                    // Comienzo a recorrer cada elemento devuelto
                    foreach (System.Type type in Assembly.GetExecutingAssembly().GetTypes())
                    {
                        // Pregunto si es de tipo Formulario
                        if (type.IsSubclassOf(typeof(Form))||type.IsSubclassOf(typeof(Vista.frmABM)))
                        {
                            // Verifico si el nombre del formulario es igual al atributo tag que tiene el nombre del formulario al abrir
                            if (type.Name.ToString() == (string)seleccion.Tag)
                            {
                                try
                                {
                                    // Si corresponde creo una instancia de ese objeto
                                    Type t = type as Type;
                                    // Aplicando reflection invoco el metodo getINSTANCIA del formulario
                                    miFORM = (Form)t.InvokeMember("ObtenerInstancia", BindingFlags.Default | BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.InvokeMethod, null, null, new object[] { this.oUsuario }) as System.Windows.Forms.Form;
                                    // Ejecuto el método show del formulario para que lo muestre
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
        }

        private void habilitarBotones()
        {
            //collPerfilesUsuario = Controladora.FachadaModuloSeguridad.ObtenerInstancia().recuperarPerfil(oUsuario);
            if (collPerfilesUsuario.ToList<Modelo_Entidades.PERFIL>().Find(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return oPerfilBuscado.FORMULARIOS.FRM_CODIGO == "regingreso"; }) == null)
            {
                this.btnRegistroIngreso.Enabled = false;
            }
            if (collPerfilesUsuario.ToList<Modelo_Entidades.PERFIL>().Find(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return (oPerfilBuscado.FORMULARIOS.FRM_CODIGO == "opera") && (oPerfilBuscado.PERMISOS.PER_CODIGO == "G"); }) == null)
            {
                this.btnCargaDescarga.Enabled = false;
            }

            if (collPerfilesUsuario.ToList<Modelo_Entidades.PERFIL>().Find(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return (oPerfilBuscado.FORMULARIOS.FRM_CODIGO == "opera") && (oPerfilBuscado.PERMISOS.PER_CODIGO == "Z"); }) == null)
            {
                this.btnAutorizacion.Enabled = false;
            }

            if (collPerfilesUsuario.ToList<Modelo_Entidades.PERFIL>().Find(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return oPerfilBuscado.FORMULARIOS.FRM_CODIGO == "infestalq"; }) == null)
            {
                this.btnEstadoAlquileres.Enabled = false;
            }

            if (collPerfilesUsuario.ToList<Modelo_Entidades.PERFIL>().Find(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return oPerfilBuscado.FORMULARIOS.FRM_CODIGO == "inffertmov"; }) == null)
            {
                this.btnMovimientos.Enabled = false;
            }
        }



        /*
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
        */
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
                    //bool resultado = oCCULogOut.LogOut(oUsuario);
                    bool resultado = Controladora.FachadaModuloSeguridad.ObtenerInstancia().RealizarLogOut(oUsuario);
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

        private void btnRegistroIngreso_Click(object sender, EventArgs e)
        {
            frmRegistroIngreso.ObtenerInstancia(oUsuario).Show();
        }

        private void btnCargaDescarga_Click(object sender, EventArgs e)
        {
            frmCargaYDescarga.ObtenerInstancia(oUsuario).Show();
        }

        private void btnAutorizacion_Click(object sender, EventArgs e)
        {
            frmOperaciones.ObtenerInstancia(oUsuario).Show();
        }

        private void btnEstadoAlquileres_Click(object sender, EventArgs e)
        {
            frmInformeEstadoAlquileres.ObtenerInstancia(oUsuario).Show();
        }

        private void btnEquivalentes_Click(object sender, EventArgs e)
        {
            frmEquivalencias.ObtenerInstancia(oUsuario).Show();
        }

        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            frmInformeFertMovido.ObtenerInstancia(oUsuario).Show();
        }

    }
}
