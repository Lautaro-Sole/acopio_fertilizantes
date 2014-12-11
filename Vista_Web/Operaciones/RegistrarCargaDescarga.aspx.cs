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
        Modelo_Entidades.USUARIO oUsuarioActual;
        Int64 id_operacion;
        float peso;


        public RegistrarCargaDescarga()
        {
            oCCUCore = Controladora.CCUCore.ObtenerInstancia();
            oCCUGAlquileres = new Controladora.CCUGAlquileres();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            id_operacion = Convert.ToInt64(Server.UrlDecode(Request.QueryString["operacion"]));
            oOperacion = oCCUCore.ObtenerOperacion(id_operacion);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txt_notas.Text = oOperacion.notas;
                //esto era para establecer el nombre de la ventana
                //this.Text = "Registrar " + oOperacion.tipo_operacion;
                switch (oOperacion.tipo_operacion)
                {
                    case "Carga":
                        oOperacion.EstablecerEstrategia(new Modelo_Entidades.EstrategiaCarga());
                        break;
                    case "Descarga":
                        oOperacion.EstablecerEstrategia(new Modelo_Entidades.EstrategiaDescarga());
                        break;
                }
            }
        }

        private bool ValidarObligatorios()
        {
            if (string.IsNullOrEmpty(txt_pesoinicial.Text))
            {
                lb_error.Text = "Debe ingresar el peso inicial.";
                return false;
            }
            if (string.IsNullOrEmpty(txt_pesofinal.Text))
            {
                lb_error.Text = "Debe ingresar el peso final";
                return false;
            }
            switch (oOperacion.tipo_operacion)
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
            Page.Response.Redirect("~/Operaciones/Operaciones.aspx");
        }

        protected void btnbtn_guardar_Click(object sender, EventArgs e)
        {
            if (ValidarObligatorios())
            {
                oOperacion.peso_inicial = Convert.ToSingle(txt_pesoinicial.Text);
                oOperacion.peso_final = Convert.ToSingle(txt_pesofinal.Text);
                oOperacion.notas = txt_notas.Text;
                oOperacion.estado = "Finalizado";

                //obtener datos de usuario
                oUsuarioActual = (Modelo_Entidades.USUARIO)Session["sUsuario"];
                //datos auditoría
                oOperacion.USU_CODIGO = oUsuarioActual.USU_CODIGO;
                oOperacion.fecha_y_hora_accion = DateTime.Now;
                oOperacion.accion = "Modificacion - Registrar " + oOperacion.tipo_operacion;

                try
                {
                    //llamar comprobacion (comprobar si lo movido concuerda con lo que está en el documento)
                    bool resultado = oCCUCore.ComprobarFertilizanteMovido(oOperacion);

                    if (resultado)
                    {
                        //actualizar los valores del alquiler
                        oCCUCore.ActualizarAlquiler(oOperacion);

                        bool resultado2 = oCCUCore.Modificar(oOperacion);
                        if (resultado2)
                        {
                            lb_error.Text = this.oOperacion.tipo_operacion + " registrada correctamente. Será redireccionado a Operaciones en 5 segundos.";

                            //código para redireccionar http://www.aspsnippets.com/Articles/Redirect-to-another-page-after-5-seconds-in-ASPNet.aspx
                            HtmlMeta meta = new HtmlMeta();
                            meta.HttpEquiv = "Refresh";
                            meta.Content = "5;url=~/Operaciones/Operaciones.aspx";
                            this.Page.Controls.Add(meta);
                            //Label1.Text = "You will now be redirected in 5 seconds";
                        }
                        else
                        {
                            lb_error.Text = oOperacion.tipo_operacion + " no registrada.";
                        }
                    }
                    else
                    {
                        lb_error.Text = oOperacion.tipo_operacion + " no registrada.";                        
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