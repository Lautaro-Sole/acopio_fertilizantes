using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class CCUGProductos
    {
        public List<Modelo_Entidades.Producto> ObtenerProductos()
        {
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatProductos.ToList<Modelo_Entidades.Producto>();
        }
    }
}
