using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class CCUGAlquileres
    {
        public List<Modelo_Entidades.Alquiler> ObtenerAlquileres()
        {
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatAlquileres.ToList<Modelo_Entidades.Alquiler>();
        }

        public List<Modelo_Entidades.Alquiler> ObtenerAlquileres(string _nombre_cliente, int? _distancia_maxima, int? _espacio_minimo)
        {
            List<Modelo_Entidades.Alquiler> oListaAlquileres = new List<Modelo_Entidades.Alquiler>();
            oListaAlquileres = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatAlquileres.ToList<Modelo_Entidades.Alquiler>();
            if (_nombre_cliente != null)
            {
                //oListaAlquileres = oListaAlquileres.FindAll(delegate(Modelo_Entidades.Alquiler oAlquilerBuscado) { return oAlquilerBuscado.Cliente.nombre.StartsWith(_nombre_cliente); });
                oListaAlquileres = oListaAlquileres.FindAll(delegate(Modelo_Entidades.Alquiler oAlquilerBuscado) { return oAlquilerBuscado.Cliente.nombre.StartsWith(Convert.ToString(_nombre_cliente)); });
            }
            if (_distancia_maxima != 0)
            {
                //oListaAlquileres = oListaAlquileres.FindAll(delegate(Modelo_Entidades.Alquiler oAlquilerBuscado) { return oAlquilerBuscado.Almacen.distancia_a_empresa <= _distancia_maxima; });
                oListaAlquileres = oListaAlquileres.FindAll(delegate(Modelo_Entidades.Alquiler oAlquilerBuscado) { return oAlquilerBuscado.Almacen.distancia_a_empresa <= _distancia_maxima; });
            }
            if (_espacio_minimo != 0)
            {
                oListaAlquileres = oListaAlquileres.FindAll(delegate(Modelo_Entidades.Alquiler oAlquilerBuscado) { return oAlquilerBuscado.capacidad >= _espacio_minimo; });
            }
            return oListaAlquileres;
        }

        /*
        /// <summary>
        /// Obtener los alquileres de los clientes cuyos nombres comienzen con lo ingresado
        /// </summary>
        /// <returns></returns>
        public List<Modelo_Entidades.Alquiler> ObtenerAlquileres(string nombre_cliente)
        {
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatAlquileres.ToList<Modelo_Entidades.Alquiler>().FindAll(delegate(Modelo_Entidades.Alquiler oAlquilerBuscado) { return oAlquilerBuscado.Cliente.nombre.StartsWith(nombre_cliente); });
        }

        /// <summary>
        /// Obtener los alquileres del cliente
        /// </summary>
        /// <returns></returns>
        public List<Modelo_Entidades.Alquiler> ObtenerAlquileres(Modelo_Entidades.Cliente oCliente)
        {
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatAlquileres.ToList<Modelo_Entidades.Alquiler>().FindAll(delegate(Modelo_Entidades.Alquiler oAlquilerBuscado) { return oAlquilerBuscado.Cliente.nombre == oCliente.nombre; });
        }
        /*
        /// <summary>
        /// Obtener los alquileres del cliente con una capacidad mínima
        /// </summary>
        /// <returns></returns>
        public List<Modelo_Entidades.Alquiler> ObtenerAlquileres(Modelo_Entidades.Cliente oCliente, int SupNoUtilizadaMinima)
        {
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatAlquileres.ToList<Modelo_Entidades.Alquiler>().FindAll(delegate(Modelo_Entidades.Alquiler oAlquilerBuscado) { return (oAlquilerBuscado.Cliente.nombre == oCliente.nombre)&(oAlquilerBuscado.superficie_no_utilizada>=SupNoUtilizadaMinima); });
        }

        /// <summary>
        /// Obtener los alquileres del cliente con una distancia máxima
        /// </summary>
        /// <returns></returns>
        public List<Modelo_Entidades.Alquiler> ObtenerAlquileres(Modelo_Entidades.Cliente oCliente, int DistanciaMaxima)
        {
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatAlquileres.ToList<Modelo_Entidades.Alquiler>().FindAll(delegate(Modelo_Entidades.Alquiler oAlquilerBuscado) { return (oAlquilerBuscado.Cliente.nombre == oCliente.nombre) & (oAlquilerBuscado.Alquiler.distancia_a_empresa <= DistanciaMaxima); });
        }
        

        /// <summary>
        /// Obtener los alquileres del cliente con una capacidad mínima y una distancia máxima
        /// </summary>
        /// <returns></returns>
        public List<Modelo_Entidades.Alquiler> ObtenerAlquileres(Modelo_Entidades.Cliente oCliente, int SupNoUtilizadaMinima, int DistanciaMaxima)
        {
            //si la distancia máxima es 0 busco cualquier alquiler con la superficie mínima especificada, no usando la distancia máxima
            if (DistanciaMaxima == 0)
            {
                return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatAlquileres.ToList<Modelo_Entidades.Alquiler>().FindAll(delegate(Modelo_Entidades.Alquiler oAlquilerBuscado) { return (oAlquilerBuscado.Cliente.nombre == oCliente.nombre) & (oAlquilerBuscado.superficie_no_utilizada >= SupNoUtilizadaMinima); });
            }
            //si tanto superfici mínima como distancia máxima sin distintos de cero busco usando ambas
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatAlquileres.ToList<Modelo_Entidades.Alquiler>().FindAll(delegate(Modelo_Entidades.Alquiler oAlquilerBuscado) { return (oAlquilerBuscado.Cliente.nombre == oCliente.nombre) & (oAlquilerBuscado.superficie_no_utilizada >= SupNoUtilizadaMinima) & (oAlquilerBuscado.Alquiler.distancia_a_empresa <= DistanciaMaxima); });
        }

         * */
         
        public bool ComprobarEspacioNecesario(Modelo_Entidades.Alquiler oAlquiler)
        {
            // si la capacidad asignada al alquiler es mayor que (la capacidad total del almacén menos la capacidad alquilada hasta entonces) 
            if (oAlquiler.capacidad > (oAlquiler.Almacen.capacidad - oAlquiler.Almacen.CapacidadAlquilada))
            {
                return false;
            }
            else return true;
        }

        /*
        public double CalcularEspacioLibreSinUnAlquiler(Modelo_Entidades.Alquiler oAlquiler)
        {
            //capacidad alquilada actual menos la capacidad del alquiler en cuestión
            return SuperficieAlquilada - Convert.ToDouble(oAlquiler.capacidad);
        }
        */

        public bool ComprobarEspacioNecesarioModificacion(Modelo_Entidades.Alquiler oAlquiler, Modelo_Entidades.Almacen oAlmacen)
        {
            Modelo_Entidades.Alquiler oAlquilerActualizado = oAlquiler;
            //buscar los datos guardados del almacén con el nro_almacen del alquiler a modificar
            Modelo_Entidades.Alquiler oAlquilerAntiguo = oAlmacen.Alquileres.ToList<Modelo_Entidades.Alquiler>().Find(delegate(Modelo_Entidades.Alquiler oAlquilerBuscado) { return oAlquilerBuscado.nro_alquiler == oAlquilerActualizado.nro_alquiler; });
            // si la capacidad asignada al alquiler es mayor que (la capacidad total del almacén menos la capacidad alquilada hasta entonces menos la capacidad actual del almacén) 
            if (oAlquilerActualizado.capacidad > (oAlmacen.capacidad - (oAlmacen.CapacidadAlquilada - oAlquilerAntiguo.capacidad)  ))
            {
                return false;
            }
            else return true;
        }

        public bool Agregar(Modelo_Entidades.Alquiler oAlquiler)
        {

            Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatAlquileres.AddObject(oAlquiler);
            int resultado = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().SaveChanges();
            if (resultado != -1) return true;
            else return false;


        }
        public bool Eliminar(Modelo_Entidades.Alquiler oAlquiler)
        {
            Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatAlquileres.DeleteObject(oAlquiler);
            int resultado = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().SaveChanges();
            if (resultado != -1) return true;
            else return false;
        }
        public bool Modificar(Modelo_Entidades.Alquiler oAlquiler)
        {
            Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatAlquileres.ApplyCurrentValues(oAlquiler);
            int resultado = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().SaveChanges();
            if (resultado != -1) return true;
            else return false;
        }

    }
}
