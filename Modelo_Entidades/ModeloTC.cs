using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    public partial class ModeloTC
    {
        private static ModeloTC Instancia;
        public static ModeloTC ObtenerInstancia()
        {
            if (Instancia == null) //|| Instancia.IsDisposed == true
                Instancia = new ModeloTC();
            return Instancia;
        }
    }
}
