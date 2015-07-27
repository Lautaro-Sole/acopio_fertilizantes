using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class CCULogOut
    {
        private static CCULogOut Instancia;
        public static CCULogOut ObtenerInstancia()
        {
            if (Instancia == null) //|| Instancia.IsDisposed == true
                Instancia = new CCULogOut();
            return Instancia;
        }

        public bool LogOut(Modelo_Entidades.USUARIO oUsuario)
        {
            Modelo_Entidades.Log oLogOut = new Modelo_Entidades.Log();
            oLogOut.USU_CODIGO = oUsuario.USU_CODIGO;
            oLogOut.fecha_y_hora = System.DateTime.Now;
            oLogOut.accion = "LOGOUT";
            Modelo_Entidades.Modelo_Auditoria.ObtenerInstancia().Log_Historia.AddObject(oLogOut);
            int resultado = Modelo_Entidades.Modelo_Auditoria.ObtenerInstancia().SaveChanges();
            if (resultado != -1)
            {
                return true;
            }
            return false;
        }
    }
}
