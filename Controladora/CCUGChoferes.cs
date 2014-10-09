using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class CCUGChoferes
    {
        public List<Modelo_Entidades.Chofer> ObtenerChoferes()
        {
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatChoferes.ToList<Modelo_Entidades.Chofer>();
        }

        public List<Modelo_Entidades.Chofer> ObtenerChoferes(string nombre, string apellido, string tipo_documento, int nro_documento, Modelo_Entidades.Cliente oClienteRecibido)
        {
            List<Modelo_Entidades.Chofer> oListaChoferes = new List<Modelo_Entidades.Chofer>();
            oListaChoferes = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatChoferes.ToList<Modelo_Entidades.Chofer>();
            if (!(string.IsNullOrWhiteSpace(nombre)))
            {
                //oListaChoferes = oListaChoferes.FindAll(delegate(Modelo_Entidades.Chofer oChoferBuscado) { return oChoferBuscado.nombre == nombre; });
                oListaChoferes = oListaChoferes.FindAll(delegate(Modelo_Entidades.Chofer oChoferBuscado) { return oChoferBuscado.nombre.StartsWith(Convert.ToString(nombre)); });
            }
            if (!(string.IsNullOrWhiteSpace(apellido)))
            {
                oListaChoferes = oListaChoferes.FindAll(delegate(Modelo_Entidades.Chofer oChoferBuscado) { return oChoferBuscado.apellido.StartsWith(apellido.ToString()); });
            }
            if (!(string.IsNullOrWhiteSpace(tipo_documento)))
            {
                oListaChoferes = oListaChoferes.FindAll(delegate(Modelo_Entidades.Chofer oChoferBuscado) { return oChoferBuscado.tipo_documento.StartsWith(tipo_documento.ToString()); });
            }
            if (oClienteRecibido != null)
            {
                //copiar la lista actual en una lista temporal, ya que no es posible modificar una lista que se está recorriendo
                //List<Modelo_Entidades.Chofer> oListaTemporal = oListaChoferes;
                List<Modelo_Entidades.Chofer> oListaTemporal = new List<Modelo_Entidades.Chofer>();
                /* si el chofer trabaja para al menos uno de los clientes que tienen este nombre no se lo quita de la lista
                //obtener la lista de los clientes para los que trabaja cada chofer
                foreach (Modelo_Entidades.Chofer oChoferActual in oListaTemporal)
                {
                    List<Modelo_Entidades.Cliente> oListaClientes = oChoferActual.Clientes.ToList<Modelo_Entidades.Cliente>().FindAll(delegate(Modelo_Entidades.Cliente oClienteBuscado) { return oClienteBuscado.nombre.StartsWith(nombre_cliente.ToString()); });
                    //si la lista está vacía quitar el chofer de la lista de choferes
                    if (oListaClientes.Count == 0)
                    {
                        oListaChoferes.Remove(oChoferActual);
                    }
                }
                */

                // si el chofer trabaja para el cliente especificado no se lo borra de la lista no temporal
                foreach (Modelo_Entidades.Chofer oChoferActual in oListaChoferes)
                {
                    Modelo_Entidades.Cliente oCliente = oChoferActual.Clientes.ToList<Modelo_Entidades.Cliente>().Find(delegate(Modelo_Entidades.Cliente oClienteBuscado) { return oClienteBuscado == oClienteRecibido; });
                    //si la lista está vacía quitar el chofer de la lista de choferes
                    if (oCliente != null)
                    {
                        oListaTemporal.Add(oChoferActual);
                    }
                }
                oListaChoferes = oListaTemporal;
            }
            if (nro_documento != 0)
            {
                oListaChoferes = oListaChoferes.FindAll(delegate(Modelo_Entidades.Chofer oChoferBuscado) { return Convert.ToString(oChoferBuscado.num_documento).StartsWith(Convert.ToString(nro_documento)); });
            }
            return oListaChoferes;
        }

        public List<Modelo_Entidades.Chofer> ObtenerChoferes(string nombre, string apellido, string tipo_documento, int nro_documento, string nombre_cliente)
        {
            List<Modelo_Entidades.Chofer> oListaChoferes = new List<Modelo_Entidades.Chofer>();
            oListaChoferes = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatChoferes.ToList<Modelo_Entidades.Chofer>();
            if (!(string.IsNullOrWhiteSpace(nombre)))
            {
                //oListaChoferes = oListaChoferes.FindAll(delegate(Modelo_Entidades.Chofer oChoferBuscado) { return oChoferBuscado.nombre == nombre; });
                oListaChoferes = oListaChoferes.FindAll(delegate(Modelo_Entidades.Chofer oChoferBuscado) { return oChoferBuscado.nombre.StartsWith(Convert.ToString(nombre)); });
            }
            if (!(string.IsNullOrWhiteSpace(apellido)))
            {
                oListaChoferes = oListaChoferes.FindAll(delegate(Modelo_Entidades.Chofer oChoferBuscado) { return oChoferBuscado.apellido.StartsWith(apellido.ToString()); });
            }
            if (!(string.IsNullOrWhiteSpace(tipo_documento)))
            {
                oListaChoferes = oListaChoferes.FindAll(delegate(Modelo_Entidades.Chofer oChoferBuscado) { return oChoferBuscado.tipo_documento.StartsWith(tipo_documento.ToString()); });
            }
            if (!(string.IsNullOrWhiteSpace(nombre_cliente)))
            {
                //copiar la lista actual en una lista temporal, ya que no es posible modificar una lista que se está recorriendo
                List<Modelo_Entidades.Chofer> oListaTemporal = oListaChoferes;

                // si el chofer trabaja para al menos uno de los clientes que tienen este nombre no se lo quita de la lista
                //obtener la lista de los clientes para los que trabaja cada chofer
                foreach (Modelo_Entidades.Chofer oChoferActual in oListaTemporal)
                {
                    List<Modelo_Entidades.Cliente> oListaClientes = oChoferActual.Clientes.ToList<Modelo_Entidades.Cliente>().FindAll(delegate(Modelo_Entidades.Cliente oClienteBuscado) { return oClienteBuscado.nombre.StartsWith(nombre_cliente.ToString()); });
                    //si la lista está vacía quitar el chofer de la lista de choferes
                    if (oListaClientes.Count == 0)
                    {
                        oListaChoferes.Remove(oChoferActual);
                    }
                }
                
                /*
                // si el chofer trabaja para el cliente del nombre especificado no se lo borra de la lista no temporal
                foreach (Modelo_Entidades.Chofer oChoferActual in oListaTemporal)
                {
                    Modelo_Entidades.Cliente oCliente = oChoferActual.Clientes.ToList<Modelo_Entidades.Cliente>().Find(delegate(Modelo_Entidades.Cliente oClienteBuscado) { return oClienteBuscado.nombre == nombre_cliente; });
                    //si la lista está vacía quitar el chofer de la lista de choferes
                    if (oCliente == null)
                    {
                        oListaChoferes.Remove(oChoferActual);
                    }
                }
                */
            }
            if (nro_documento != 0)
            {
                oListaChoferes = oListaChoferes.FindAll(delegate(Modelo_Entidades.Chofer oChoferBuscado) { return Convert.ToString(oChoferBuscado.num_documento).StartsWith(Convert.ToString(nro_documento)); });
            }
            return oListaChoferes;
        }

        public Modelo_Entidades.Chofer ObtenerChofer(string tipo_documento, Int32 numero_documento)
        {
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatChoferes.ToList<Modelo_Entidades.Chofer>().Find(delegate(Modelo_Entidades.Chofer oChoferBuscado) { return (oChoferBuscado.tipo_documento == tipo_documento) && (oChoferBuscado.num_documento == numero_documento); });
        }

        public bool Agregar(Modelo_Entidades.Chofer oChofer)
        {
            Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatChoferes.AddObject(oChofer);
            int resultado = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().SaveChanges();
            if (resultado != -1) return true;
            else return false;
        }

        public bool Eliminar(Modelo_Entidades.Chofer oChofer)
        {
            Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatChoferes.DeleteObject(oChofer);
            int resultado = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().SaveChanges();
            if (resultado != -1) return true;
            else return false;
        }

        public bool Modificar(Modelo_Entidades.Chofer oChofer)
        {
            Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatChoferes.ApplyCurrentValues(oChofer);
            int resultado = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().SaveChanges();
            if (resultado != -1) return true;
            else return false;
        }
    }
}
