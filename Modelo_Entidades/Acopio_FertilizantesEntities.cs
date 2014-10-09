using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    public partial class Acopio_FertilizantesEntities
    {

        private static Acopio_FertilizantesEntities Instancia;
        public static Acopio_FertilizantesEntities ObtenerInstancia()
        {
            if (Instancia == null) //|| Instancia.IsDisposed == true
                Instancia = new Acopio_FertilizantesEntities();
            return Instancia;
        }
    }
}
