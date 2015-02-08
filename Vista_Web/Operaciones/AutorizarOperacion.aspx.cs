using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista_Web.Operaciones
{
    public partial class AutorizarOperacion : System.Web.UI.Page
    {
        Modelo_Entidades.Documento oDocumento;
        Modelo_Entidades.Operacion oOperacion;
        Modelo_Entidades.USUARIO oUsuario;

        Controladora.CCUCore oCCUCore;
        Controladora.CCUGAlquileres oCCUGAlquileres;
        Controladora.CCUGProductos oCCUGProductos;

        List<Modelo_Entidades.Alquiler> oListaAlquileres;
        List<Modelo_Entidades.Producto> oListaProductos;

        string nrooperacion;

        public AutorizarOperacion()
        {
            oCCUCore = Controladora.CCUCore.ObtenerInstancia();
            oCCUGProductos = Controladora.CCUGProductos.ObtenerInstancia();
            oCCUGAlquileres = Controladora.CCUGAlquileres.ObtenerInstancia();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                oUsuario = (Modelo_Entidades.USUARIO)HttpContext.Current.Session["sUsuario"];
                ArmarPerfil(oUsuario, "frmAutorizarOperacion");

                nrooperacion = Server.UrlDecode(Request.QueryString["operacion"]);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //lista de productos
            oListaProductos = oCCUGProductos.ObtenerProductos();
            cmb_tipofertilizante.DataSource = oListaProductos;
            cmb_tipofertilizante.DataTextField = "descripcion";
            cmb_tipofertilizante.DataValueField = "codigo_producto";
            cmb_tipofertilizante.DataBind();

            Armar_Lista();
        }

        private void Armar_Lista()
        {
            oListaAlquileres = oCCUGAlquileres.ObtenerAlquileres(oOperacion.Cliente.nombre, Convert.ToInt32(txt_distanciamaximaempresa.Text), Convert.ToInt32(txt_capacidadlibreminima));
            gvAlquileres.DataSource = oListaAlquileres;
            gvAlquileres.DataBind();



        }

        protected void gvAlquileres_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvAlquileres_SelectedIndexChanged(object sender, EventArgs e)
        {
            message.Visible = false;
        }

        private void ArmarPerfil(Modelo_Entidades.USUARIO oUsuario, string formulario)
        {

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
            txt_nombrecliente.Text = "";

            Armar_Lista();
        }


    }
}