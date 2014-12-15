using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista_Web.Operaciones
{
    public partial class Operaciones : System.Web.UI.Page
    {
        private Controladora.CCUCore oCCUCore;
        private Controladora.CCURPF oCCURPF;
        private Modelo_Entidades.Operacion oOperacion;
        private Modelo_Entidades.USUARIO oUsuario;
        private List<Modelo_Entidades.Operacion> oListaOperaciones;
        private List<Modelo_Entidades.Tipo_Matricula> oListaTiposMatricula;
        private List<Modelo_Entidades.Tipo_Operacion> oListaTiposOperacion;
        private List<Modelo_Entidades.Estado_Operacion> oListaEstadoOperacion;
        private string operacion;

        public Operaciones()
        {
            oCCUCore = Controladora.CCUCore.ObtenerInstancia();
            oCCURPF = Controladora.CCURPF.ObtenerInstancia();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                oUsuario = (Modelo_Entidades.USUARIO)HttpContext.Current.Session["sUsuario"];
                botonera1.ArmaPerfil(oUsuario, "frmOperaciones");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //cargar combos
                oListaTiposMatricula = oCCUCore.ObtenerTiposMatricula();
                this.cmb_tipomatricula.DataSource = oListaTiposMatricula;

                oListaTiposOperacion = oCCUCore.ObtenerTiposOperacion();
                this.cmb_tipooperacion.DataSource = oListaTiposOperacion;

                oListaEstadoOperacion = oCCUCore.ObtenerEstadosOperacion();
                this.cmb_estado.DataSource = oListaEstadoOperacion;

                Armar_Lista();
            }
        }

        private void Armar_Lista()
        {
            oListaOperaciones = oCCUCore.ObtenerOperaciones();
            gvOperaciones.DataSource = oListaOperaciones;
            gvOperaciones.DataBind();

            //mostrar a qué estado, tipo de op, alquiler y cliente corresponden los números
            int cantidadfilas = gvOperaciones.Rows.Count; 
            for (int i = 0; i < cantidadfilas; i++)
            {
                int estado = Convert.ToInt32(gvOperaciones.Rows[i].Cells[2].Text) -1;
                gvOperaciones.Rows[i].Cells[2].Text = oListaEstadoOperacion[estado].descripcion;
                int tipo = Convert.ToInt32(gvOperaciones.Rows[i].Cells[10].Text) -1;
                gvOperaciones.Rows[i].Cells[10].Text = oListaEstadoOperacion[tipo].descripcion;
                /*
                int alquiler = Convert.ToInt32(gvOperaciones.Rows[i].Cells[14].Text);
                gvOperaciones.Rows[i].Cells[14].Text = oListaEstadoOperacion[alquiler].ToString();
                int cliente = Convert.ToInt32(gvOperaciones.Rows[i].Cells[17].Text);
                gvOperaciones.Rows[i].Cells[17].Text = oListaEstadoOperacion[cliente].ToString();
                */
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
            e.Row.Cells[6].Visible = e.Row.Cells[9].Visible = e.Row.Cells[9].Visible = e.Row.Cells[11].Visible = e.Row.Cells[12].Visible = e.Row.Cells[13].Visible = e.Row.Cells[15].Visible = e.Row.Cells[16].Visible = false;

            
        }

        protected void gvOperaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            message.Visible = false;
        }

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
                if (gvOperaciones.SelectedRow.Cells[2].Text =="Autorizado")
                {
                    operacion = gvOperaciones.SelectedRow.Cells[1].Text;
                    Response.Redirect(String.Format("~/Operaciones/RegistrarCargaDescarga.aspx?operacion={0}", Server.UrlEncode(operacion)));
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
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "openModal();", true);
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

        protected void btn_cerrar_operacion_modal_Click(object sender, EventArgs e)
        {
            operacion = gvOperaciones.SelectedRow.Cells[1].Text;
            oOperacion = oCCUCore.ObtenerOperacion(Convert.ToInt64(operacion));

            oOperacion.Estado_Operacion = oListaEstadoOperacion.Find(delegate(Modelo_Entidades.Estado_Operacion oEstadoBuscado) { return oEstadoBuscado.descripcion == "Finalizado"; });
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

            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal();", true);
            message.Visible = true;
            lb_error.Text = "Se ha cerrado la operación.";
            Armar_Lista();
        }

        protected void btn_cancelar_modal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "pop", "closeModal();", true);
        }

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