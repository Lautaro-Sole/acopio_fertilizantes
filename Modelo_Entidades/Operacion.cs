using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    public partial class Operacion
    {
        private EstrategiaOperacion _EstrategiaPropia;
        public void EstablecerEstrategia(EstrategiaOperacion oEstrategiaConcreta)
        {
            this._EstrategiaPropia = oEstrategiaConcreta;
        }

        public string ComprobrarPosibilidadDeOperacion()
        {
            string resultado = this._EstrategiaPropia.ComprobarPosibilidadDeOperacion(this.Alquiler, this.Documento);
            return resultado;
        }

        public string ComprobarFertilizanteMovido()
        {
            string resultado = this._EstrategiaPropia.ComprobarFertilizanteMovido(Convert.ToDouble(this.Documento.peso), Convert.ToDouble(this.peso_inicial), Convert.ToDouble(this.peso_final));
            return resultado;
        }

        public void ActualizarAlquiler()
        {
            this._EstrategiaPropia.ActualizarAlquiler(this.Alquiler, this.Documento, Convert.ToDouble(this.peso_inicial), Convert.ToDouble(this.peso_final));
        }
    }
}
