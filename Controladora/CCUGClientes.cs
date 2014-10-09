using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class CCUGClientes
    {
        public List<Modelo_Entidades.Cliente> ObtenerClientes()
        {
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatClientes.ToList<Modelo_Entidades.Cliente>();
        }

        public List<Modelo_Entidades.Cliente> ObtenerClientes(string nombre)
        {
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatClientes.ToList<Modelo_Entidades.Cliente>().FindAll(delegate(Modelo_Entidades.Cliente oClienteBuscado) { return oClienteBuscado.nombre.StartsWith(nombre); });
        }

        public Modelo_Entidades.Cliente ObtenerCliente(string nombre)
        {
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatClientes.ToList<Modelo_Entidades.Cliente>().Find(delegate(Modelo_Entidades.Cliente oClienteBuscado) { return oClienteBuscado.nombre == nombre; });
        }

        public bool Agregar(Modelo_Entidades.Cliente oCliente)
        {

            Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatClientes.AddObject(oCliente);
            int resultado = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().SaveChanges();
            if (resultado != -1) return true;
            else return false;
        }

        public bool Eliminar(Modelo_Entidades.Cliente oCliente)
        {
            Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatClientes.DeleteObject(oCliente);
            int resultado = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().SaveChanges();
            if (resultado != -1) return true;
            else return false;
        }
        public bool Modificar(Modelo_Entidades.Cliente oCliente)
        {
            Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatClientes.ApplyCurrentValues(oCliente);
            int resultado = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().SaveChanges();
            if (resultado != -1) return true;
            else return false;
        }
    }
}
