using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    partial class Modelo_AuditoriaEntities2
    {
        private static Modelo_AuditoriaEntities2 Instancia;
        public static Modelo_AuditoriaEntities2 ObtenerInstancia()
        {
            if (Instancia == null) //|| Instancia.IsDisposed == true
                Instancia = new Modelo_AuditoriaEntities2();
            return Instancia;
        }
    }
}
