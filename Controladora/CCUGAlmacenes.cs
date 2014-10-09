using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class CCUGAlmacenes
    {
        public List<Modelo_Entidades.Almacen> ObtenerAlmacenes()
        {
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatAlmacenes.ToList<Modelo_Entidades.Almacen>();
        }

        public List<Modelo_Entidades.Almacen> ObtenerAlmacenes(string _nombre_almacen, int _distancia_maxima, int _espacio_minimo)
        {
            List<Modelo_Entidades.Almacen> oListaAlmacenes = new List<Modelo_Entidades.Almacen>();
            oListaAlmacenes = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatAlmacenes.ToList<Modelo_Entidades.Almacen>();
            if (_nombre_almacen != null)
            {
                oListaAlmacenes = oListaAlmacenes.FindAll(delegate(Modelo_Entidades.Almacen oAlmacenBuscado) { return oAlmacenBuscado.nombre.StartsWith(_nombre_almacen); });
            }
            if (_distancia_maxima != 0)
            {
                oListaAlmacenes = oListaAlmacenes.FindAll(delegate(Modelo_Entidades.Almacen oAlmacenBuscado) { return oAlmacenBuscado.distancia_a_empresa <= _distancia_maxima; });
            }
            if (_espacio_minimo != 0)
            {
                oListaAlmacenes = oListaAlmacenes.FindAll(delegate(Modelo_Entidades.Almacen oAlmacenBuscado) { return oAlmacenBuscado.capacidad >= _espacio_minimo; });
            }
            return oListaAlmacenes;
        }

        public Modelo_Entidades.Almacen ObtenerAlmacen(string nombre, string direccion)
        {
            return ObtenerAlmacenes().Find(delegate(Modelo_Entidades.Almacen oAlmacenBuscado) { return ((oAlmacenBuscado.direccion == direccion)&&(oAlmacenBuscado.nombre == nombre)); });
        }

        public bool Agregar(Modelo_Entidades.Almacen oAlmacen)
        {

            Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatAlmacenes.AddObject(oAlmacen);
            int resultado = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().SaveChanges();
            if (resultado != -1) return true;
            else return false;


        }
        public bool Eliminar(Modelo_Entidades.Almacen oAlmacen)
        {
            Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatAlmacenes.DeleteObject(oAlmacen);
            int resultado = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().SaveChanges();
            if (resultado != -1) return true;
            else return false;
        }
        public bool Modificar(Modelo_Entidades.Almacen oAlmacen)
        {
            Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatAlmacenes.ApplyCurrentValues(oAlmacen);
            int resultado = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().SaveChanges();
            if (resultado != -1) return true;
            else return false;
        }
    }
}

