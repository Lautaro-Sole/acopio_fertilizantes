using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    public partial class ModeloSeguridadContainer
    {
        private static ModeloSeguridadContainer Instancia;
        public static ModeloSeguridadContainer ObtenerInstancia()
        {
            if (Instancia == null) //|| Instancia.IsDisposed == true
                Instancia = new ModeloSeguridadContainer();
            return Instancia;
        }
    }
}
