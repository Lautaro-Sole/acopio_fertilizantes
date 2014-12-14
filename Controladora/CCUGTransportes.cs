using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class CCUGTransportes
    {
        public List<Modelo_Entidades.Transporte> ObtenerTransportes()
        {
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatTransportes.ToList<Modelo_Entidades.Transporte>();
        }

        public List<Modelo_Entidades.Transporte> ObtenerTransportes(string tipo_matricula, string nro_matricula, string nombre_cliente, string nombre_chofer)
        {
            List<Modelo_Entidades.Transporte> oListaTransportes = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatTransportes.ToList<Modelo_Entidades.Transporte>();
            if (!(string.IsNullOrWhiteSpace(tipo_matricula)))
            {
                int _tipo_matricula = Convert.ToInt32(tipo_matricula);
                oListaTransportes = oListaTransportes.FindAll(delegate(Modelo_Entidades.Transporte oTransporteBuscado) { return oTransporteBuscado.tipo_matricula==_tipo_matricula; });
            }
            if (!(string.IsNullOrWhiteSpace(nro_matricula)))
            {
                oListaTransportes = oListaTransportes.FindAll(delegate(Modelo_Entidades.Transporte oTransporteBuscado) { return oTransporteBuscado.nro_matricula.StartsWith(nro_matricula); });
            }
            if (!(string.IsNullOrWhiteSpace(nombre_cliente)))
            {
                //oListaTransportes = oListaTransportes.FindAll(delegate(Modelo_Entidades.Transporte oTransporteBuscado) { return oTransporteBuscado.nro_matricula.StartsWith(nombre_chofer); });

                //crear una lista temporal con todo lo que hay hasta el momento
                
                List<Modelo_Entidades.Transporte> oListaTemporalTransportes = new List<Modelo_Entidades.Transporte>();

                foreach (Modelo_Entidades.Transporte oTransporteActual in oListaTransportes)
                {
                    List<Modelo_Entidades.Chofer> oListaChoferes = oTransporteActual.Choferes.ToList<Modelo_Entidades.Chofer>(); // FindAll(delegate(Modelo_Entidades.Chofer oChoferBuscado) { return oChoferBuscado.nombre.StartsWith(nombre_cliente); });
                    List<Modelo_Entidades.Chofer> oListaTemporalChoferes = new List<Modelo_Entidades.Chofer>();
                    // si el chofer trabaja para al menos uno de los clientes que tienen este nombre no se lo quita de la lista
                    //obtener la lista de los clientes para los que trabaja cada chofer
                    foreach (Modelo_Entidades.Chofer oChofer in oListaChoferes)
                    {
                        List<Modelo_Entidades.Cliente> oListaClientes = oChofer.Clientes.ToList<Modelo_Entidades.Cliente>().FindAll(delegate(Modelo_Entidades.Cliente oClienteBuscado) { return oClienteBuscado.nombre.StartsWith(nombre_cliente); });
                        //si encuentro algún cliente para el que trabaja el chofer cuyo nombre coincida agrego el chofer a la lista temporal
                        if (oListaClientes.Count != 0)
                        {
                            oListaTemporalChoferes.Add(oChofer);
                        }
                    }

                    //si encuentro algún chofer en la lista temporal de choferes
                    if (oListaTemporalChoferes.Count != 0)
                    {
                        oListaTemporalTransportes.Add(oTransporteActual);
                    }
                   
                }
                oListaTransportes = oListaTemporalTransportes;
            }
            if (!(string.IsNullOrWhiteSpace(nombre_chofer)))
            {
                //crear una lista temporal con todo lo que hay hasta el momento
                List<Modelo_Entidades.Transporte> oListaTemporal = new List<Modelo_Entidades.Transporte>();

                foreach (Modelo_Entidades.Transporte oTransporteActual in oListaTransportes)
                {
                    List<Modelo_Entidades.Chofer> oListaChoferes = oTransporteActual.Choferes.ToList<Modelo_Entidades.Chofer>(); // FindAll(delegate(Modelo_Entidades.Chofer oChoferBuscado) { return oChoferBuscado.nombre.StartsWith(nombre_cliente); });

                    // si el transporte puede ser conducido por al menos uno de los choferes con el nombre
                    List<Modelo_Entidades.Chofer> oListaChoferesTemporal = oListaChoferes.FindAll(delegate(Modelo_Entidades.Chofer oChoferBuscado) { return (oChoferBuscado.nombre.StartsWith(nombre_chofer)) == true; });
                    if (oListaChoferesTemporal.Count != 0)
                    {
                        oListaTemporal.Add(oTransporteActual);
                    }
                }
                oListaTransportes = oListaTemporal;
            }

            
                
            



            return oListaTransportes;
        }

        public Modelo_Entidades.Transporte ObtenerTransporte(string tipo_matricula, string numero_matricula)
        {
            int _tipo_matricula = Convert.ToInt32(tipo_matricula);
            return ObtenerTransportes().Find(delegate(Modelo_Entidades.Transporte oTransporteBuscado) { return ((oTransporteBuscado.nro_matricula == numero_matricula) && (oTransporteBuscado.tipo_matricula == _tipo_matricula)); });
        }

        public bool Agregar(Modelo_Entidades.Transporte oTransporte)
        {

            Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatTransportes.AddObject(oTransporte);
            int resultado = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().SaveChanges();
            if (resultado != -1) return true;
            else return false;


        }
        public bool Eliminar(Modelo_Entidades.Transporte oTransporte)
        {
            Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatTransportes.DeleteObject(oTransporte);
            int resultado = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().SaveChanges();
            if (resultado != -1) return true;
            else return false;
        }
        public bool Modificar(Modelo_Entidades.Transporte oTransporte)
        {
            Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatTransportes.ApplyCurrentValues(oTransporte);
            int resultado = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().SaveChanges();
            if (resultado != -1) return true;
            else return false;
        }
    }
}
