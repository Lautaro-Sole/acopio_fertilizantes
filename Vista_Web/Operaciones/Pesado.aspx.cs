using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Vista_Web.Operaciones
{
    public partial class RegistrarCargaDescarga : System.Web.UI.Page
    {
        Controladora.CCUCore oCCUCore;
        Controladora.CCUGAlquileres oCCUGAlquileres;
        Modelo_Entidades.Operacion oOperacion;
        Modelo_Entidades.USUARIO oUsuario;
        List<Modelo_Entidades.Estado_Operacion> oListaEstadosOperacion;
        string nrooperacion;
        float peso;
        string pesado;

        public RegistrarCargaDescarga()
        {
            oCCUCore = Controladora.CCUCore.ObtenerInstancia();
            oCCUGAlquileres = Controladora.CCUGAlquileres.ObtenerInstancia();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                oUsuario = (Modelo_Entidades.USUARIO)HttpContext.Current.Session["sUsuario"];
                ArmarPerfil(oUsuario, "frmAutorizarOperacion");

                //obtener la operacion de la base de datos o de la sesión
                nrooperacion = Server.UrlDecode(Request.QueryString["operacion"]);
                oOperacion = oCCUCore.ObtenerOperacion(Convert.ToInt64(nrooperacion));
                
            }
            else
            {
                oUsuario = (Modelo_Entidades.USUARIO)HttpContext.Current.Session["sUsuario"];
                ArmarPerfil(oUsuario, "frmAutorizarOperacion");

                //obtener la operacion de la base de datos o de la sesión
                nrooperacion = Server.UrlDecode(Request.QueryString["operacion"]);
                oOperacion = oCCUCore.ObtenerOperacion(Convert.ToInt64(nrooperacion)); 
                
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            try
            {
                //cambiar //
                txt_notas.Text = oOperacion.notas;
                //esto era para establecer el nombre de la ventana
                switch (oOperacion.Tipo_Operacion.descripcion)
                {
                    case "Carga":
                        oOperacion.EstablecerEstrategia(new Modelo_Entidades.EstrategiaCarga());
                        break;
                    case "Descarga":
                        oOperacion.EstablecerEstrategia(new Modelo_Entidades.EstrategiaDescarga());
                        break;
                }

                if (oOperacion.Estado_Operacion.descripcion == "Autorizado")
                {
                    pesado = "Pesado Inicial";
                    //this.txt_peso.Text = "Peso Inicial medido";
                }
                else if (oOperacion.Estado_Operacion.descripcion == "En Proceso")
                {
                    pesado = "Pesado Final";
                    //this.txt_peso.Text = "Peso Final medido";
                }
                this.Title = pesado + " - " + oOperacion.Tipo_Operacion.descripcion;
            }
            catch(Exception ex)
            {
                lb_error.Text = ex.InnerException.Message;
            }
        }

        protected void ArmarPerfil(Modelo_Entidades.USUARIO oUsuario, string formulario)
        { 

        }

        private bool ValidarObligatorios()
        {
            if (string.IsNullOrEmpty(txt_peso.Text))
            {
                lb_error.Text = "Debe ingresar el peso medido.";
                return false;
            }
            
            //todo: if para si es pesado inicial o pesado final
            /*
            switch (oOperacion.Tipo_Operacion.descripcion)
            {
                case "Descarga":
                    if (Convert.ToInt32(txt_pesofinal.Text) >= Convert.ToInt32(txt_pesoinicial.Text))
                    {
                        lb_error.Text = "El peso final no puede ser mayor o igual que el peso inicial.";
                        return false;
                    }
                    break;
                case "Carga":
                    if (Convert.ToInt32(txt_pesoinicial.Text) <= Convert.ToInt32(txt_pesofinal.Text))
                    {
                        lb_error.Text = "El peso final no puede ser menor o igual que el peso inicial.";
                        return false;
                    }
                    break;
            }
            peso = Convert.ToSingle(txt_pesofinal.Text) - Convert.ToSingle(txt_pesoinicial.Text);
            */

            //si lo entregado está dentro de la tolerancia -> movido a la clase
            /*
            if (!((oOperacion.Documentos.peso * 0.95 <= _peso) & (_peso <= oOperacion.Documentos.peso * 1.05)))
            {
                MessageBox.Show("La diferencia entre el peso en la orden de carga y la cargada realmente está fuera de la tolerancia establecida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            */
            return true;
        }

        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("~/Operaciones/Operaciones.aspx", false);
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            if (ValidarObligatorios())
            {
                
                oOperacion.notas = txt_notas.Text;
                if (oOperacion.Estado_Operacion.descripcion == "Autorizado")
                {
                    //oOperacion.Estado_Operacion.descripcion = "En Proceso";
                    oOperacion.peso_inicial = Convert.ToSingle(txt_peso.Text);
                    //datos auditoría
                    oOperacion.accion = "Modificacion - Registrar Pesado Inicial";
                }
                else
                {
                    //oOperacion.Estado_Operacion.descripcion = "Finalizado";
                    oOperacion.peso_final = Convert.ToSingle(txt_peso.Text);
                    //datos auditoría
                    oOperacion.accion = "Modificacion - Registrar Pesado Final";
                }
                

                //obtener datos de usuario
                oUsuario = (Modelo_Entidades.USUARIO)Session["sUsuario"];
                //datos auditoría
                oOperacion.USU_CODIGO = oUsuario.USU_CODIGO;
                oOperacion.fecha_y_hora_accion = DateTime.Now;
                

                try
                {
                    //llamar comprobacion (comprobar si lo movido concuerda con lo que está en el documento)
                    //bool resultado = oCCUCore.ComprobarFertilizanteMovido(oOperacion);

                    bool resultado = oCCUCore.ComprobarTolerancia(oOperacion);
                    List<Modelo_Entidades.Estado_Operacion> oListaTiposOperacion = oCCUCore.ObtenerEstadosOperacion();
                    if (resultado)
                    {
                        if (oOperacion.Estado_Operacion.descripcion == "Autorizado")
                        {
                            //oOperacion.Estado_Operacion.descripcion = "En Proceso";
                            oOperacion.Estado_Operacion = oListaTiposOperacion.Find(delegate(Modelo_Entidades.Estado_Operacion oEstadoBuscado) { return oEstadoBuscado.descripcion == "En Proceso"; });
                            oOperacion.estado = oOperacion.Estado_Operacion.id_estado_operacion;
                        }
                        else
                        {
                            //oOperacion.Estado_Operacion.descripcion = "Finalizado";
                            oOperacion.Estado_Operacion = oListaTiposOperacion.Find(delegate(Modelo_Entidades.Estado_Operacion oEstadoBuscado) { return oEstadoBuscado.descripcion == "Finalizado"; });
                            oOperacion.estado = oOperacion.Estado_Operacion.id_estado_operacion;
                        }

                        if ( oOperacion.Estado_Operacion.descripcion=="Finalizado")
                        {
                            //actualizar los valores del alquiler
                            oCCUCore.ActualizarAlquiler(oOperacion);
                        }




                        bool resultado2 = oCCUCore.Modificar(oOperacion);

                        if (resultado2)
                        {
                            lb_error.Text = this.oOperacion.tipo_operacion + " registrada correctamente. Será redireccionado a Operaciones en 5 segundos.";

                            Page.Response.Redirect("~/Operaciones/Operaciones.aspx", false);
                        }
                        else
                        {
                            lb_error.Text = pesado + " no registrado.";
                        }
                    }
                    else
                    {
                        lb_error.Text = pesado + " no registrado.";                        
                    }
                }
                catch (System.Data.DataException ex)
                {
                    lb_error.Text = "Excepción: " + ex.InnerException.Message;
                }
            }
        }
    }
}