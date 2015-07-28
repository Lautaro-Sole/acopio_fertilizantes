using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Vista_Web.Operaciones
{
    public partial class AutorizarOperacion : System.Web.UI.Page
    {
        Modelo_Entidades.Documento oDocumento;
        Modelo_Entidades.Operacion oOperacion;
        Modelo_Entidades.Producto oProducto;
        Modelo_Entidades.Alquiler oAlquiler;
        Modelo_Entidades.USUARIO oUsuario;

        Controladora.CCUCore oCCUCore;
        Controladora.CCUGAlquileres oCCUGAlquileres;
        Controladora.CCUGProductos oCCUGProductos;

        List<Modelo_Entidades.Alquiler> oListaAlquileres;
        List<Modelo_Entidades.Producto> oListaProductos;
        List<Modelo_Entidades.Tipo_Operacion> oListaTiposOperacion;
        List<Modelo_Entidades.Estado_Operacion> oListaEstadosOperacion;

        string nrooperacion;
        string tipofertilizante;
        int nroalquiler;

        //rpf
        Controladora.CCUGPerfiles oCCUGPerfiles;
        Controladora.CCUGGrupos oCCUGGrupos;
        Controladora.CCUGUsuarios oCCUGUsuarios;
        Controladora.CCURPF oCCURPF;
        Controladora.FachadaModuloSeguridad oFachada;
        public AutorizarOperacion()
        {
            oCCUCore = Controladora.CCUCore.ObtenerInstancia();
            oCCUGProductos = Controladora.CCUGProductos.ObtenerInstancia();
            oCCUGAlquileres = Controladora.CCUGAlquileres.ObtenerInstancia();

            //rpf
            oCCUGPerfiles = Controladora.CCUGPerfiles.ObtenerInstancia();
            oCCUGGrupos = Controladora.CCUGGrupos.ObtenerInstancia();
            oCCUGUsuarios = Controladora.CCUGUsuarios.ObtenerInstancia();
            oCCURPF = Controladora.CCURPF.ObtenerInstancia();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                oUsuario = (Modelo_Entidades.USUARIO)HttpContext.Current.Session["sUsuario"];
                botonera1.ArmaPerfil(oUsuario, "frmAutorizarOperacion");

                //obtener la operacion de la base de datos o de la sesión
                nrooperacion = Server.UrlDecode(Request.QueryString["operacion"]);
                oOperacion = oCCUCore.ObtenerOperacion(Convert.ToInt64(nrooperacion));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //comprobar que la operación sea válida
                if (oOperacion.Estado_Operacion.descripcion != "Ingresa")
                {
                    LimpiarYSalir();
                }

                //lista de productos
                oListaProductos = oCCUGProductos.ObtenerProductos();
                cmb_tipofertilizante.DataSource = oListaProductos;
                cmb_tipofertilizante.DataTextField = "descripcion";
                cmb_tipofertilizante.DataValueField = "codigo_producto";
                cmb_tipofertilizante.DataBind();

                oListaEstadosOperacion = oCCUCore.ObtenerEstadosOperacion();
                oListaTiposOperacion = oCCUCore.ObtenerTiposOperacion();

                Armar_Lista();

                gvAlquileres.EnableViewState = true;
                gvAlquileres.ViewStateMode = ViewStateMode.Enabled;

                cmb_tipofertilizante.EnableViewState = true;
                cmb_tipofertilizante.ViewStateMode = ViewStateMode.Enabled;

                GuardarEnSesion();
            }
            else
            {
                LeerDeSesion();
            }
        }

        private void GuardarEnSesion()
        {
            HttpContext.Current.Session["Operacion"] = oOperacion;
            HttpContext.Current.Session["Alquiler"] = oAlquiler;
            HttpContext.Current.Session["Producto"] = oProducto;
            HttpContext.Current.Session["ListaAlquileres"] = oListaAlquileres;
            HttpContext.Current.Session["ListaTipos"] = oListaTiposOperacion;
            HttpContext.Current.Session["ListaProductos"] = oListaProductos;
            HttpContext.Current.Session["ListaEstado"] = oListaEstadosOperacion;
        }

        private void LeerDeSesion()
        {
            oOperacion = (Modelo_Entidades.Operacion)HttpContext.Current.Session["Operacion"];
            oAlquiler = (Modelo_Entidades.Alquiler)HttpContext.Current.Session["Alquiler"];
            oProducto = (Modelo_Entidades.Producto)HttpContext.Current.Session["Producto"];
            oListaAlquileres = (List<Modelo_Entidades.Alquiler>)HttpContext.Current.Session["ListaAlquileres"];
            oListaTiposOperacion = (List<Modelo_Entidades.Tipo_Operacion>)HttpContext.Current.Session["ListaTipos"];
            oListaProductos = (List<Modelo_Entidades.Producto>)HttpContext.Current.Session["ListaProductos"];
            oListaEstadosOperacion = (List<Modelo_Entidades.Estado_Operacion>)HttpContext.Current.Session["ListaEstado"];
        }

        private void LimpiarSesion(Modelo_Entidades.USUARIO oUsuario)
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session["sUsuario"] = oUsuario;
        }

        private void LimpiarSesion()
        {
            oUsuario = (Modelo_Entidades.USUARIO)HttpContext.Current.Session["sUsuario"];
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session["sUsuario"] = oUsuario;
        }

        private void Armar_Lista()
        {
            //el nombre del cliente debe ser el que está en la operación, por eso se deshabilita el textbox durante Load()
            int espacio_minimo;
            if (string.IsNullOrEmpty(this.txt_capacidadlibreminima.Text))
            {
                espacio_minimo = 0;
            }
            else
            {
                espacio_minimo = Convert.ToInt32(this.txt_capacidadlibreminima.Text);
            }
            int distancia_maxima;
            if (string.IsNullOrEmpty(this.txt_distanciamaximaempresa.Text))
            {
                distancia_maxima = 0;
            }
            else
            {
                distancia_maxima = Convert.ToInt32(this.txt_distanciamaximaempresa.Text);
            }
            if (oOperacion == null)
            {
                nrooperacion = Server.UrlDecode(Request.QueryString["operacion"]);
                oOperacion = oCCUCore.ObtenerOperacion(Convert.ToInt64(nrooperacion));
            }

            oListaAlquileres = oCCUGAlquileres.ObtenerAlquileres(oOperacion.Cliente.nombre, distancia_maxima, espacio_minimo);
            gvAlquileres.DataSource = oListaAlquileres;
            gvAlquileres.DataBind();

            HttpContext.Current.Session["ListaAlquileres"] = oListaAlquileres;
        }

        protected void gvAlquileres_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Text = "Espacio Utilizado";
            e.Row.Cells[2].Text = "Distancia";
            e.Row.Cells[3].Text = "Cantidad en Bolsa";
            e.Row.Cells[4].Text = "Cantidad a Granel";
            e.Row.Cells[5].Text = "Estado";
            e.Row.Cells[6].Text = "Cliente";
            e.Row.Cells[7].Text = "Almacen";
            e.Row.Cells[8].Text = "Número de alquiler";
            e.Row.Cells[9].Text = "Estado (bool)";
            e.Row.Cells[10].Text = "Fecha de inicio";
            e.Row.Cells[11].Text = "Fecha de finalización";
            e.Row.Cells[12].Text = "Capacidad";
            e.Row.Cells[13].Text = "Número de almacén";
            e.Row.Cells[14].Text = "Número de cliente";

            e.Row.Cells[8].Visible = e.Row.Cells[9].Visible = e.Row.Cells[13].Visible = e.Row.Cells[14].Visible = false;
        }

        protected void gvAlquileres_SelectedIndexChanged(object sender, EventArgs e)
        {
            message.Visible = false;
            nroalquiler = gvAlquileres.SelectedIndex;
            oAlquiler = oListaAlquileres[nroalquiler];

            HttpContext.Current.Session["Alquiler"] = oAlquiler; 
        }


        protected void btn_filtrar_Click(object sender, EventArgs e)
        {
            message.Visible = false;

            Armar_Lista();
        }

        protected void btn_nuevabusqueda_Click(object sender, EventArgs e)
        {
            txt_capacidadlibreminima.Text = "";
            txt_distanciamaximaempresa.Text = "";
            

            Armar_Lista();
        }

        protected void cmb_tipofertilizante_SelectedIndexChanged(object sender, EventArgs e)
        {
            message.Visible = false;

            tipofertilizante = cmb_tipofertilizante.Text.ToString();
            //oProducto = oCCUGProductos.ObtenerProducto(tipofertilizante);
            oProducto = oListaProductos[cmb_tipofertilizante.SelectedIndex];

        }

        protected void btn_autorizar_Click(object sender, EventArgs e)
        {
            message.Visible = true;

            bool resultado;
            oDocumento = new Modelo_Entidades.Documento();

            if (ValidarDatos())
            {
                if (oOperacion.Tipo_Operacion.descripcion == "Carga")
                {
                    oDocumento.tipo_documento = "Orden de carga";
                    oOperacion.tipo_documento = "Orden de carga";
                    //establecer estrategia
                    oOperacion.EstablecerEstrategia(new Modelo_Entidades.EstrategiaCarga());
                }
                else
                {
                    oDocumento.tipo_documento = "Remito";
                    oOperacion.tipo_documento = "Remito";
                    //establecer estrategia
                    oOperacion.EstablecerEstrategia(new Modelo_Entidades.EstrategiaDescarga());
                }

                oDocumento.nro_documento = Convert.ToInt32(this.txt_numerodocumento.Text);
                //oDocumento.Producto = (Modelo_Entidades.Producto)oListaProductos[this.cmb_tipofertilizante.SelectedIndex];
                //oDocumento.Producto = oListaProductos.Find(delegate(Modelo_Entidades.Producto oProductoBuscado) { return oProductoBuscado.codigo_producto == Convert.ToInt32(cmb_tipofertilizante.SelectedValue); });
                //oProducto = (Modelo_Entidades.Producto) cmb_tipofertilizante.Items[cmb_tipofertilizante.SelectedIndex];
                //oDocumento.Producto = oListaProductos.Find(delegate(Modelo_Entidades.Producto oProductoBuscado) { return oProductoBuscado.descripcion == cmb_tipofertilizante.Text; });
                //oDocumento.Producto = oListaProductos.Find(delegate(Modelo_Entidades.Producto oProductoBuscado) { return oProductoBuscado.codigo_producto == Convert.ToInt32(cmb_tipofertilizante.SelectedItem); });
                //oDocumento.Producto = oListaProductos.Find(delegate(Modelo_Entidades.Producto oProductoBuscado) { return oProductoBuscado.codigo_producto == Convert.ToInt32(cmb_tipofertilizante.SelectedIndex); });

                oDocumento.Producto = oProducto;

                oDocumento.peso = Convert.ToInt32(this.txt_cantidadenkg.Text);
                oDocumento.fecha_hora = Convert.ToDateTime(this.txt_fecha.Text);

                oOperacion.Documento = oDocumento;
                //oOperacion.Estado_Operacion.descripcion = "Autorizado";
                oOperacion.Estado_Operacion = oListaEstadosOperacion.Find(delegate(Modelo_Entidades.Estado_Operacion oEstadoBuscado) { return oEstadoBuscado.descripcion == "Autorizado"; });
                //oOperacion.notas = this.txt_notas.Text;

                //oOperacion.Alquiler = oListaAlquileres[this.gvAlquileres.SelectedIndex];
                oOperacion.Alquiler = oAlquiler;

                //datos auditoría
                oUsuario = (Modelo_Entidades.USUARIO)HttpContext.Current.Session["sUsuario"];
                oOperacion.USU_CODIGO = oUsuario.USU_CODIGO;
                oOperacion.fecha_y_hora_accion = DateTime.Now;
                oOperacion.accion = "Modificacion - Autorizar Operacion";

                try
                {
                    //llamar comprobacion
                    resultado = oCCUCore.ComprobrarPosibilidadDeOperacion(oOperacion);
                    if (resultado)
                    {
                        resultado = oCCUCore.Modificar(oOperacion);
                        if (resultado)
                        {
                            this.lb_error.Text = "Guardado con éxito.";

                            LimpiarSesion();

                            //Response.AddHeader("REFRESH", "2;URL=test.aspx");
                            Page.Response.Redirect("~/Operaciones/Operaciones.aspx", false);
                        }
                        else
                        {
                            this.lb_error.Text = "No guardado.";
                        }
                    }
                    else
                    {
                        this.lb_error.Text = "No es posible realizar la operación deseada en el alquiler seleccionado.";
                    }
                }
                catch (System.Data.DataException ex)
                {
                    this.lb_error.Text = "No se ha podido actualizar la operación: " + ex.Message;
                }
            }
        }

        protected void botonera1_Click_Alta(object sender, EventArgs e)
        {
            message.Visible = true;

            bool resultado;
            oDocumento = new Modelo_Entidades.Documento();

            if (ValidarDatos())
            {
                if (oOperacion.Tipo_Operacion.descripcion == "Carga")
                {
                    oDocumento.tipo_documento = "Orden de carga";
                    oOperacion.tipo_documento = "Orden de carga";
                    //establecer estrategia
                    oOperacion.EstablecerEstrategia(new Modelo_Entidades.EstrategiaCarga());
                }
                else
                {
                    oDocumento.tipo_documento = "Remito";
                    oOperacion.tipo_documento = "Remito";
                    //establecer estrategia
                    oOperacion.EstablecerEstrategia(new Modelo_Entidades.EstrategiaDescarga());
                }

                oDocumento.nro_documento = Convert.ToInt32(this.txt_numerodocumento.Text);
                //oDocumento.Producto = (Modelo_Entidades.Producto)oListaProductos[this.cmb_tipofertilizante.SelectedIndex];
                //oDocumento.Producto = oListaProductos.Find(delegate(Modelo_Entidades.Producto oProductoBuscado) { return oProductoBuscado.codigo_producto == Convert.ToInt32(cmb_tipofertilizante.SelectedValue); });
                //oProducto = (Modelo_Entidades.Producto) cmb_tipofertilizante.Items[cmb_tipofertilizante.SelectedIndex];
                //oDocumento.Producto = oListaProductos.Find(delegate(Modelo_Entidades.Producto oProductoBuscado) { return oProductoBuscado.descripcion == cmb_tipofertilizante.Text; });
                //oDocumento.Producto = oListaProductos.Find(delegate(Modelo_Entidades.Producto oProductoBuscado) { return oProductoBuscado.codigo_producto == Convert.ToInt32(cmb_tipofertilizante.SelectedItem); });
                //oDocumento.Producto = oListaProductos.Find(delegate(Modelo_Entidades.Producto oProductoBuscado) { return oProductoBuscado.codigo_producto == Convert.ToInt32(cmb_tipofertilizante.SelectedIndex); });

                oDocumento.Producto = oProducto;

                oDocumento.peso = Convert.ToInt32(this.txt_cantidadenkg.Text);
                oDocumento.fecha_hora = Convert.ToDateTime(this.txt_fecha.Text);

                oOperacion.Documento = oDocumento;
                //oOperacion.Estado_Operacion.descripcion = "Autorizado";
                oOperacion.Estado_Operacion = oListaEstadosOperacion.Find(delegate(Modelo_Entidades.Estado_Operacion oEstadoBuscado) { return oEstadoBuscado.descripcion == "Autorizado"; });
                //oOperacion.notas = this.txt_notas.Text;

                //oOperacion.Alquiler = oListaAlquileres[this.gvAlquileres.SelectedIndex];
                oOperacion.Alquiler = oAlquiler;

                //datos auditoría
                oUsuario = (Modelo_Entidades.USUARIO)HttpContext.Current.Session["sUsuario"];
                oOperacion.USU_CODIGO = oUsuario.USU_CODIGO;
                oOperacion.fecha_y_hora_accion = DateTime.Now;
                oOperacion.accion = "Modificacion - Autorizar Operacion";

                try
                {
                    //llamar comprobacion
                    resultado = oCCUCore.ComprobrarPosibilidadDeOperacion(oOperacion);
                    if (resultado)
                    {
                        resultado = oCCUCore.Modificar(oOperacion);
                        if (resultado)
                        {
                            this.lb_error.Text = "Guardado con éxito.";

                            LimpiarYSalir();
                        }
                        else
                        {
                            this.lb_error.Text = "No guardado.";
                        }
                    }
                    else
                    {
                        this.lb_error.Text = "No es posible realizar la operación deseada en el alquiler seleccionado.";
                    }
                }
                catch (System.Data.DataException ex)
                {
                    this.lb_error.Text = "No se ha podido actualizar la operación: " + ex.Message;
                }
            }
        }

        protected bool ValidarDatos()
        {
            if (this.gvAlquileres.SelectedRow == null)
            {
                lb_error.Text = "Debe seleccionar un alquiler.";
                return false;
            }
            else
            {
                //Modelo_Entidades.Alquiler oAlquiler = oListaAlquileres[this.gvAlquileres.SelectedIndex];
                if (gvAlquileres.SelectedRow.Cells[5].Text != "Activo")
                {
                    lb_error.Text = "Debe seleccionar un alquiler válido.";
                    return false;
                }
            }
            //if (string.IsNullOrEmpty(this.cmb_tipofertilizante.Text))
            //{
            //    lb_error.Text = "Primero debe seleccionar un tipo de fertilizante.";
            //    return false;
            //}
            if ((cmb_tipofertilizante.SelectedIndex == null) || (cmb_tipofertilizante.SelectedIndex == -1))
            {
                lb_error.Text = "Primero debe seleccionar un tipo de fertilizante.";
                return false;
            }
            oProducto = oListaProductos[cmb_tipofertilizante.SelectedIndex];
            if(oProducto == null)
            {
                oProducto = oListaProductos[cmb_tipofertilizante.SelectedIndex];
            }
            if (string.IsNullOrEmpty(this.txt_cantidadenkg.Text))
            {
                lb_error.Text = "Primero debe ingresar la cantidad de fertilizante.";
                return false;
            }
            if (string.IsNullOrEmpty(this.txt_numerodocumento.Text))
            {
                lb_error.Text = "Primero debe ingresar el número del documento.";
                return false;
            }
            //if (oProducto == null)
            //{
            //    lb_error.Text = "Primero debe sellecionar un tipo de fertilizante. oProducto Nulo.";
            //    return false;
            //}
            return true;


        }

        protected void botonera1_Click_Cerrar(object sender, EventArgs e)
        {
            LimpiarYSalir();
        }

        private void LimpiarYSalir()
        {
            LimpiarSesion();

            //código para redireccionar http://www.aspsnippets.com/Articles/Redirect-to-another-page-after-5-seconds-in-ASPNet.aspx
            //HtmlMeta meta = new HtmlMeta();
            //meta.HttpEquiv = "Refresh";
            //meta.Content = "3;url=/Operaciones/Operaciones.aspx";
            //this.Page.Controls.Add(meta);
            
            //Response.AppendHeader("Refresh", "3; url=/Operaciones/Operaciones.aspx");
            lb_error.Text = "Será redireccionado en 3 segundos.";
            Page.Response.Redirect("~/Operaciones/Operaciones.aspx", false);
        }
    }
}