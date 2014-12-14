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

        public void Operaciones()
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
                Armar_Lista();
            }
        }

        private void Armar_Lista()
        {
            oListaOperaciones = oCCUCore.ObtenerOperaciones();
            gvOperaciones.DataSource = oListaOperaciones;
            gvOperaciones.DataBind();
        }

        protected void Click_Autorizar_Operacion(object sender, EventArgs e)
        {

        }

        protected void Click_Registrar_CargaDescarga(object sender, EventArgs e)
        {

        }

        protected void Click_Autorizar_Cierre(object sender, EventArgs e)
        {

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