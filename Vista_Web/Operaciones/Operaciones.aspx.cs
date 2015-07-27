using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista_Web.Operaciones
{
    public partial class OperacionesIntento2 : System.Web.UI.Page
    {
        #region Propiedades y controladoras
        private Controladora.CCUCore oCCUCore;
        private Controladora.CCURPF oCCURPF;

        private Modelo_Entidades.Operacion oOperacion;
        private Modelo_Entidades.USUARIO oUsuario;

        private List<Modelo_Entidades.Operacion> oListaOperaciones;
        private List<Modelo_Entidades.Tipo_Matricula> oListaTiposMatricula;
        private List<Modelo_Entidades.Tipo_Operacion> oListaTiposOperacion;
        private List<Modelo_Entidades.Estado_Operacion> oListaEstadosOperacion;

        private string operacion;

        private global::System.Web.UI.WebControls.Button btn_agregar;
        private global::System.Web.UI.WebControls.Button btn_cerrar;
        private global::System.Web.UI.WebControls.Button btn_eliminar;
        private global::System.Web.UI.WebControls.Button btn_modificar;
        private global::System.Web.UI.WebControls.Button btn_verdetalle;

        ClientScriptManager oClientScriptManager;
        #endregion

        #region Constructor e inicialización
        public OperacionesIntento2()
        {
            oCCUCore = Controladora.CCUCore.ObtenerInstancia();
            oCCURPF = Controladora.CCURPF.ObtenerInstancia();

            oClientScriptManager = Page.ClientScript;
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                oUsuario = (Modelo_Entidades.USUARIO)HttpContext.Current.Session["sUsuario"];

                if (oUsuario == null)
                {
                    Response.Redirect("~/Seguridad/Login.aspx");
                }
                else
                {
                    botonera1.ArmaPerfil(oUsuario, "frmOperaciones");
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //cargar combos
                oListaTiposMatricula = oCCUCore.ObtenerTiposMatricula();
                this.cmb_tipomatricula.DataSource = oListaTiposMatricula;
                this.cmb_tipomatricula.DataTextField = "descripcion";
                this.cmb_tipomatricula.DataValueField = "id_tipo_matricula";
                this.cmb_tipomatricula.DataBind();

                oListaTiposOperacion = oCCUCore.ObtenerTiposOperacion();
                this.cmb_tipooperacion.DataSource = oListaTiposOperacion;
                this.cmb_tipooperacion.DataTextField = "descripcion";
                this.cmb_tipooperacion.DataValueField = "id_tipo_operacion";
                this.cmb_tipooperacion.DataBind();

                oListaEstadosOperacion = oCCUCore.ObtenerEstadosOperacion();
                this.cmb_estado.DataSource = oListaEstadosOperacion;
                this.cmb_estado.DataTextField = "descripcion";
                this.cmb_estado.DataValueField = "id_estado_operacion";
                this.cmb_estado.DataBind();

                //agregar objetos vacíos a las listas desplegables para la opción por defecto
                cmb_tipomatricula.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                cmb_tipooperacion.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                cmb_estado.Items.Insert(0, new ListItem(String.Empty, String.Empty));
                cmb_tipomatricula.SelectedIndex = 0;
                cmb_tipooperacion.SelectedIndex = 0;
                cmb_estado.SelectedIndex = 0;

                Armar_Lista();

                //habilitar el ViewState de las listas y la grilla
                gvOperaciones.EnableViewState = true;
                gvOperaciones.ViewStateMode = ViewStateMode.Enabled;

                cmb_estado.EnableViewState = true;
                cmb_estado.ViewStateMode = ViewStateMode.Enabled;

                cmb_tipomatricula.EnableViewState = true;
                cmb_tipomatricula.ViewStateMode = ViewStateMode.Enabled;

                cmb_tipooperacion.EnableViewState = true;
                cmb_tipooperacion.ViewStateMode = ViewStateMode.Enabled;

                botonera1.EnableViewState = true;
                botonera1.ViewStateMode = ViewStateMode.Enabled;


                GuardarEnSesion();

            }
            else
            {
                LeerDeSesion();
            }

            AgregarEventosABotones();
        }

        private void AgregarEventosABotones()
        {
            /*
            btn_agregar = (System.Web.UI.WebControls.Button)botonera1.FindControl("btn_agregar");
            btn_agregar.Click -= new EventHandler(botonera1_Click_Alta);
            btn_agregar.Click += new EventHandler(botonera1_Click_Alta);

            btn_cerrar = (System.Web.UI.WebControls.Button)botonera1.FindControl("btn_cerrar");
            btn_cerrar.Click -= new EventHandler(botonera1_Click_Cerrar);
            btn_cerrar.Click += new EventHandler(botonera1_Click_Cerrar);

            btn_eliminar = (System.Web.UI.WebControls.Button)botonera1.FindControl("btn_eliminar");
            btn_eliminar.Click -= new EventHandler(botonera1_Click_Baja);
            btn_eliminar.Click += new EventHandler(botonera1_Click_Baja);

            btn_modificar = (System.Web.UI.WebControls.Button)botonera1.FindControl("btn_modificar");
            btn_modificar.Click -= new EventHandler(botonera1_Click_Modificacion);
            btn_modificar.Click += new EventHandler(botonera1_Click_Modificacion);

            btn_verdetalle = (System.Web.UI.WebControls.Button)botonera1.FindControl("btn_verdetalle");
            btn_verdetalle.Click -= new EventHandler(botonera1_Click_Consulta);
            btn_verdetalle.Click += new EventHandler(botonera1_Click_Consulta);

            */

            //btn_eliminar.Attributes.Add("OnClientClick", "javascript: return openModalCerrar();");
            //btn_eliminar.Attributes.Add("onClick", "javascript: return openModalCerrar();");

            //btn_cerrar_operacion_modal.Attributes.Add("onclick", "javascript: return closeModalCerrar();");
        }

        #endregion

        #region Sesión
        private void GuardarEnSesion()
        {
            HttpContext.Current.Session["Operacion"] = oOperacion;
            HttpContext.Current.Session["ListaOperaciones"] = oListaOperaciones;
            HttpContext.Current.Session["ListaTipos"] = oListaTiposOperacion;
            HttpContext.Current.Session["ListaMatriculas"] = oListaTiposMatricula;
            HttpContext.Current.Session["ListaEstado"] = oListaEstadosOperacion;
            HttpContext.Current.Session["sUsuario"] = oUsuario;
        }

        private void LeerDeSesion()
        {
            oOperacion = (Modelo_Entidades.Operacion)HttpContext.Current.Session["Operacion"];
            oListaOperaciones = (List<Modelo_Entidades.Operacion>)HttpContext.Current.Session["ListaOperaciones"];
            oListaTiposOperacion = (List<Modelo_Entidades.Tipo_Operacion>)HttpContext.Current.Session["ListaTipos"];
            oListaTiposMatricula = (List<Modelo_Entidades.Tipo_Matricula>)HttpContext.Current.Session["ListaMatriculas"];
            oListaEstadosOperacion = (List<Modelo_Entidades.Estado_Operacion>)HttpContext.Current.Session["ListaEstado"];
            oUsuario = (Modelo_Entidades.USUARIO)HttpContext.Current.Session["sUsuario"];
        }

        private void LimpiarSesion(Modelo_Entidades.USUARIO oUsuario)
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session["sUsuario"] = oUsuario;
        }

        #endregion

        #region Grilla
        private void Armar_Lista()
        {
            //oListaOperaciones = oCCUCore.ObtenerOperaciones();
            oListaOperaciones = oCCUCore.ObtenerOperaciones(this.cmb_tipomatricula.Text, this.txt_numeromatricula.Text, this.cmb_tipooperacion.Text, this.cmb_estado.Text, this.txt_nombrecliente.Text, this.txt_nombrechofer.Text);
            gvOperaciones.DataSource = oListaOperaciones;
            gvOperaciones.DataBind();

            HttpContext.Current.Session["ListaOperaciones"] = oListaOperaciones;

            //mostrar a qué estado, tipo de op, alquiler y cliente corresponden los números
            int cantidadfilas = gvOperaciones.Rows.Count;
            for (int i = 0; i < cantidadfilas; i++)
            {
                int estado = Convert.ToInt32(gvOperaciones.Rows[i].Cells[2].Text);
                gvOperaciones.Rows[i].Cells[2].Text = oListaEstadosOperacion[estado - 1].descripcion;
                int tipo = Convert.ToInt32(gvOperaciones.Rows[i].Cells[10].Text);
                gvOperaciones.Rows[i].Cells[10].Text = oListaTiposOperacion[tipo - 1].descripcion;
                /*
                int alquiler = Convert.ToInt32(gvOperaciones.Rows[i].Cells[14].Text);
                gvOperaciones.Rows[i].Cells[14].Text = oListaEstadoOperacion[alquiler].ToString();
                int cliente = Convert.ToInt32(gvOperaciones.Rows[i].Cells[17].Text);
                gvOperaciones.Rows[i].Cells[17].Text = oListaEstadoOperacion[cliente].ToString();
                 * */

            }
        }

        protected void gvOperaciones_RowCreated(object sender, GridViewRowEventArgs e)
        {

            e.Row.Cells[1].Text = "Número de operación";
            e.Row.Cells[2].Text = "Estado";
            e.Row.Cells[3].Text = "Inicio";
            e.Row.Cells[4].Text = "Fin";
            e.Row.Cells[5].Text = "Notas";
            e.Row.Cells[6].Text = "Número de documento";
            e.Row.Cells[7].Text = "Peso inicial";
            e.Row.Cells[8].Text = "Peso final";
            e.Row.Cells[9].Text = "Tipo de documento";
            e.Row.Cells[10].Text = "Tipo de Operación";
            e.Row.Cells[11].Text = "Usuario";
            e.Row.Cells[12].Text = "Fecha";
            e.Row.Cells[13].Text = "Acción";
            e.Row.Cells[14].Text = "Alquiler";
            e.Row.Cells[15].Text = "Chofer";
            e.Row.Cells[16].Text = "Transporte";
            e.Row.Cells[17].Text = "Cliente";

            //ocultar
            e.Row.Cells[11].Visible = e.Row.Cells[12].Visible = e.Row.Cells[13].Visible = e.Row.Cells[15].Visible = e.Row.Cells[16].Visible = false;
        }
        #endregion

        #region Selección de items
        protected void gvOperaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            message.Visible = false;
            int nrooperacion = gvOperaciones.SelectedIndex;
            oOperacion = oListaOperaciones[nrooperacion];
            HttpContext.Current.Session["Operacion"] = oOperacion;
        }

        protected void cmb_tipooperacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cmb_tipomatricula_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cmb_estado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Filtrado
        protected void btn_filtrar_Click(object sender, EventArgs e)
        {
            message.Visible = false;

            Armar_Lista();
        }

        protected void btn_nuevabusqueda_Click(object sender, EventArgs e)
        {
            txt_nombrechofer.Text = "";
            txt_nombrecliente.Text = "";
            txt_numeromatricula.Text = "";

            cmb_tipomatricula.SelectedIndex = 0;
            cmb_tipooperacion.SelectedIndex = 0;
            cmb_estado.SelectedIndex = 0;

            Armar_Lista();
        }

        #endregion

        #region Botonera
        protected void botonera1_Click_Alta(object sender, EventArgs e)
        {
            message.Visible = true;

            if (gvOperaciones.SelectedRow == null)
            {
                lb_error.Text = "Debe seleccionar una operación";
            }

            else
            {
                //comprobar estado
                if (gvOperaciones.SelectedRow.Cells[2].Text == "Ingresa")
                {
                    operacion = gvOperaciones.SelectedRow.Cells[1].Text;
                    Response.Redirect(String.Format("~/Operaciones/AutorizarOperacion.aspx?operacion={0}", Server.UrlEncode(operacion)));
                }
                else
                {
                    lb_error.Text = "La operación seleccionada no tiene el estado correcto.";
                }
            }
        }

        protected void botonera1_Click_Modificacion(object sender, EventArgs e)
        {
            message.Visible = true;

            if (gvOperaciones.SelectedRow == null)
            {
                lb_error.Text = "Debe seleccionar una operación";
            }
            else
            {
            //comprobar estado
            if ((gvOperaciones.SelectedRow.Cells[2].Text =="Autorizado")||(gvOperaciones.SelectedRow.Cells[2].Text=="En Proceso"))
            {
            operacion = gvOperaciones.SelectedRow.Cells[1].Text;
            Response.Redirect(String.Format("~/Operaciones/Pesado.aspx?operacion={0}", Server.UrlEncode(operacion)));
            }
                else
                {
                    lb_error.Text = "La operación seleccionada no tiene el estado correcto.";
                }
            }
        }

        protected void botonera1_Click_Baja(object sender, EventArgs e)
        {
            message.Visible = true;

            if (gvOperaciones.SelectedRow == null)
            {
                lb_error.Text = "Debe seleccionar una operación";
            }
            else
            {
                //comprobar estado
                if (gvOperaciones.SelectedRow.Cells[2].Text == "Finalizado")
                {
                    //mostrar modal
                    message.Visible = false;
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "pop", "openModalCerrar();", true);

                    //StringBuilder sb = new StringBuilder();
                    //sb.Append("<script type=\"text/javascript\"> function openModalCerrar() {)");
                    //sb.Append("$('#modal_cerrar').modal('hide');");
                    //sb.Append("$('body').removeClass('modal-open');");
                    //sb.Append("$('.modal-backdrop').remove();");
                    //sb.Append("return false;</script>");

                    //this.ScriptManager.RegisterClientScriptBlock(this.GetType(), "funcioncerrarmodal", sb.ToString());
                }
                else
                {
                    lb_error.Text = "La operación seleccionada no tiene el estado correcto.";
                }
            }
        }

        protected void botonera1_Click_Consulta(object sender, EventArgs e)
        {
            message.Visible = true;

            if (gvOperaciones.SelectedRow == null)
            {
                lb_error.Text = "Debe seleccionar una operación";
            }

            else
            {
                //mostrar detalles
            }
        }

        protected void botonera1_Click_Cerrar(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Principal.aspx"));
        }

        #endregion

        #region Modal

        protected void btn_cerrar_operacion_modal_Click(object sender, EventArgs e)
        {
            //operacion = gvOperaciones.SelectedRow.Cells[1].Text;
            operacion = "9";
            oOperacion = oCCUCore.ObtenerOperacion(Convert.ToInt64(operacion));

            oOperacion.Estado_Operacion = oListaEstadosOperacion.Find(delegate(Modelo_Entidades.Estado_Operacion oEstadoBuscado) { return oEstadoBuscado.descripcion == "Cerrado"; });
            oOperacion.USU_CODIGO = oUsuario.USU_CODIGO;
            oOperacion.accion = "Modificación - Cerrado";
            oOperacion.fecha_y_hora_accion = DateTime.Now;

            try
            {
                bool resultado = oCCUCore.Modificar(oOperacion);
            }
            catch (System.Data.DataException ex)
            {
                lb_error.Text = "Excepción: " + ex.InnerException.Message;
            }

            ScriptManager.RegisterStartupScript(this.btn_cerrar_operacion_modal, typeof(System.Web.UI.WebControls.Button), "popout", "closeModalCerrar();", true);
            message.Visible = true;
            lb_error.Text = "Se ha cerrado la operación.";
            Armar_Lista();
        }

        protected void btn_cancelar_modal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.btn_cerrar_operacion_modal, typeof(System.Web.UI.WebControls.Button), "popout", "closeModalCerrar();", true);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal();", true);
        }
        #endregion

        /*
        public void ArmaPerfil(Modelo_Entidades.USUARIO oUsuario, string form)
        {
            btn_autorizarcierreoperacion.Enabled = false;
            btn_autorizaroperacion.Enabled = false;
            btn_registrarcargadescarga.Enabled = false;

            try
            {
                //por cada grupo al que pertenece el usuario
                foreach (Modelo_Entidades.GRUPO oGrupo in oCCURPF.obtenerGruposUsuario(oUsuario.USU_CODIGO))
                {
                    //por cada permiso del grupo en el formulario
                    foreach (Modelo_Entidades.PERMISO oPermiso in oCCURPF.ObtenerPermisosPorFormulario(oGrupo.GRU_CODIGO, form))
                    {
                        switch (oPermiso.PER_DESCRIPCION)
                        {
                            case "AUTORIZAR":
                                if (form == "frmAuditorias")
                                {
                                    btn_autorizarcierreoperacion.Text = "Formatear";
                                }

                                btn_agregar.Enabled = true;
                                break;

                            case "BAJA":
                                if (form == "frmProfesionales" || form == "frmExpedientes" || form == "frmAuditorias")
                                {
                                    btn_eliminar.Visible = false;
                                }

                                btn_eliminar.Enabled = true;
                                break;

                            case "MODIFICAR":
                                if (form == "frmAuditorias" || form == "frmPerfiles")
                                {
                                    btn_modificar.Visible = false;
                                }

                                btn_modificar.Enabled = true;

                                break;

                            case "CONSULTA":
                                btn_verdetalle.Enabled = true;
                                break;
                        }
                    }
                }
            }

            catch (Exception Exc)
            {
                throw new Exception(Exc.Message);
            }
        }
         * */
    }
}