using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class CCUGProductos
    {
        private static CCUGProductos Instancia;

        public static CCUGProductos ObtenerInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new CCUGProductos();
            }
            return Instancia;
        }

        private CCUGProductos()
        {

        }

        public List<Modelo_Entidades.Producto> ObtenerProductos()
        {
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatProductos.ToList<Modelo_Entidades.Producto>();
        }


    }
}
