using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class CCURecuperarClave
    {
        private static CCURecuperarClave Instancia;
        public static CCURecuperarClave ObtenerInstancia()
        {
            if (Instancia == null) //|| Instancia.IsDisposed == true
                Instancia = new CCURecuperarClave();
            return Instancia;
        }

        public Modelo_Entidades.USUARIO obtenerUsuario(string usuario, string e_mail)
        {
            return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().USUARIOS.ToList<Modelo_Entidades.USUARIO>().Find(delegate(Modelo_Entidades.USUARIO unUsuario) { return (unUsuario.USU_CODIGO == usuario)&(unUsuario.USU_EMAIL==e_mail); });
        }


    }
}
