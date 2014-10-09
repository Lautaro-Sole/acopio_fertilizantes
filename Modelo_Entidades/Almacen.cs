using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    public partial class Almacen
    {
        public override string ToString()
        {
            return nombre;
        }
        /*
        public float SuperficieNoAlquilada
        {
            get { _capacidad - (this.Alquileres.) }
        }
        */

        public double ObtenerCapacidadNoAlquilada()
        {
            double SuperficieNoAlquilada = new double();
            double SuperficieAlquilada = new double();
            foreach (Modelo_Entidades.Alquiler oAlquilerActual in this.Alquileres.ToList<Modelo_Entidades.Alquiler>())
            {
                SuperficieAlquilada += Convert.ToDouble(oAlquilerActual.capacidad);
            }
            SuperficieNoAlquilada = Convert.ToDouble(this.capacidad) - SuperficieAlquilada;
            return SuperficieNoAlquilada;
        }

        public double CapacidadAlquilada
        {
            get
            {
                double _SuperficieAlquilada = new double();
                foreach (Modelo_Entidades.Alquiler oAlquilerActual in this.Alquileres.ToList<Modelo_Entidades.Alquiler>().FindAll(delegate(Modelo_Entidades.Alquiler oAlquilerBuscado){ return oAlquilerBuscado.estado == true;}))
                {
                    _SuperficieAlquilada += Convert.ToDouble(oAlquilerActual.capacidad);
                }
                return _SuperficieAlquilada;
            }
        }

        
    }
}
