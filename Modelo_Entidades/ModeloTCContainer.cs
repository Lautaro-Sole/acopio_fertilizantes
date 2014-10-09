using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    partial class ModeloTCContainer
    {
        private static ModeloTCContainer Instancia;
        public static ModeloTCContainer ObtenerInstancia()
        {
            if (Instancia == null) //|| Instancia.IsDisposed == true
                Instancia = new ModeloTCContainer();
            return Instancia;
        }
    }
}
