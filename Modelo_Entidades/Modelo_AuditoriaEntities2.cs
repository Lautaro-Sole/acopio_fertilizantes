using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    partial class Modelo_Auditoria
    {
        private static Modelo_Auditoria Instancia;
        public static Modelo_Auditoria ObtenerInstancia()
        {
            if (Instancia == null) //|| Instancia.IsDisposed == true
                Instancia = new Modelo_Auditoria();
            return Instancia;
        }
    }
}
