using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    public abstract class EstrategiaOperacion
    {
        protected double _porcentajetolerancia = 2;
        //public abstract string ComprobarPosibilidadDeOperacion(double pesodocumento, double capacidad, double capacidadocupada);
        public abstract string ComprobarPosibilidadDeOperacion(Modelo_Entidades.Alquiler oAlquiler, Modelo_Entidades.Documento oDocumento);
        public abstract string ComprobarFertilizanteMovido(double pesodocumento, double pesoinicial, double pesofinal);
        public abstract string ComprobarTolerancia(Modelo_Entidades.Alquiler oAlquiler, Modelo_Entidades.Documento oDocumento, Modelo_Entidades.Transporte oTransporte, double pesoinicial, double? pesofinal, string estado);
        public abstract void ActualizarAlquiler(Modelo_Entidades.Alquiler oAlquiler, Modelo_Entidades.Documento oDocumento, double pesoinicial, double pesofinal);
    }
}
