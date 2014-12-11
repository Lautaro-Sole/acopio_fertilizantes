using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista_Web.Botoneras
{
    public delegate void Eventos_Botonera(object sender, EventArgs e);

    public partial class Botonera1 : System.Web.UI.UserControl
    {
        public event Eventos_Botonera Click_Alta;
        public event Eventos_Botonera Click_Baja;
        public event Eventos_Botonera Click_Modificacion;
        public event Eventos_Botonera Click_Consulta;
        public event Eventos_Botonera Click_Cerrar;

        Controladora.CCUGPerfiles oCCUGPerfiles;
        Controladora.CCUGGrupos oCCUGGrupos;
        Controladora.CCUGUsuarios oCCUGUsuarios;
        Controladora.CCURPF oCCURPF;

        public Botonera1()
        {
            oCCUGPerfiles = Controladora.CCUGPerfiles.ObtenerInstancia();
            oCCUGGrupos = Controladora.CCUGGrupos.ObtenerInstancia();
            oCCUGUsuarios = Controladora.CCUGUsuarios.ObtenerInstancia();
            oCCURPF = Controladora.CCURPF.ObtenerInstancia();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_agregar_Click(object sender, EventArgs e)
        {
            Click_Alta(sender, e);
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            Click_Baja(sender, e);
        }

        protected void btn_modificar_Click(object sender, EventArgs e)
        {
            Click_Modificacion(sender, e);
        }

        protected void btn_verdetalle_Click(object sender, EventArgs e)
        {
            Click_Consulta(sender, e);
        }

        protected void btn_cerrar_Click(object sender, EventArgs e)
        {
            Click_Cerrar(sender, e);
        }

        public void ArmaPerfil(Modelo_Entidades.USUARIO oUsuario, string form)
        {
            oCCUGPerfiles = Controladora.CCUGPerfiles.ObtenerInstancia();
            oCCUGGrupos = Controladora.CCUGGrupos.ObtenerInstancia();
            oCCUGUsuarios = Controladora.CCUGUsuarios.ObtenerInstancia();
            
            btn_agregar.Enabled = false;
            btn_eliminar.Enabled = false;
            btn_modificar.Enabled = false;
            btn_verdetalle.Enabled = false;
            
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
                            case "ALTA":
                                if (form == "frmAuditorias")
                                {
                                    btn_agregar.Text = "Formatear";
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
    }
}