using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    public class EstrategiaCarga : EstrategiaOperacion
    {
        /*
        public override string ComprobarPosibilidadDeOperacion(double pesodocumento, double capacidad, double capacidadocupada)
        {
            if (pesodocumento <= capacidadocupada)
            {
                return "Posible";
            }
            else
            {
                return "Imposible";
            }
        }
        */
        public override string ComprobarPosibilidadDeOperacion(Alquiler oAlquiler, Documento oDocumento)
        {
                //comprobar si el peso del documento es menor o igual a la capacidad utilizada
            if (oDocumento.peso <= oAlquiler.EspacioUtilizado)
            {
                //obtener la relación entre el alquiler y el producto especificado en el documento
                Modelo_Entidades.Alquiler_Producto oAlquiler_Producto = oAlquiler.Alquiler_Productos.ToList<Modelo_Entidades.Alquiler_Producto>().Find(delegate(Modelo_Entidades.Alquiler_Producto oAlquiler_ProductoActual) { return oAlquiler_ProductoActual.Producto == oDocumento.Producto; });
                //comprobar si existe la cantidad del tipo de fertilizante especificada en el documento en el alquiler
                if (oAlquiler_Producto == null || oAlquiler_Producto.cantidad_kg < oDocumento.peso)
                {
                    return "Imposible"; //porque no hay la cantidad suficiente del tipo de fertilizante en el documento
                }
                else
                {
                    return "Posible";
                }
            }
            else
            {
                return "Imposible";
            }
        }
        

        public override string ComprobarFertilizanteMovido(double pesodocumento, double pesoinicial, double pesofinal)
        {
            double pesocargado = (pesofinal-pesoinicial);
            double pesomaximo = (1 + _porcentajetolerancia/100) * pesodocumento;
            double pesominimo = (1 - _porcentajetolerancia/100) * pesodocumento;
            if (pesominimo <= pesocargado && pesocargado <= pesomaximo)
            {
                return "Correcto";
            }
            else
            {
                return "Incorrecto";
            }
        }

        public override void ActualizarAlquiler(Modelo_Entidades.Alquiler oAlquiler, Modelo_Entidades.Documento oDocumento, double pesoinicial, double pesofinal)
        {
            double pesomovido = pesofinal - pesoinicial;

            //obtener la relación entre el alquiler y el producto especificado en el documento
            Modelo_Entidades.Alquiler_Producto oAlquiler_Producto = oAlquiler.Alquiler_Productos.ToList<Modelo_Entidades.Alquiler_Producto>().Find(delegate(Modelo_Entidades.Alquiler_Producto oAlquiler_ProductoActual) { return oAlquiler_ProductoActual.Producto == oDocumento.Producto; });
            // debería no ser nulo nunca porque se comprueba si existe antes

            //actualizar la cantidad del tipo de fertilizante especificado (+= porque se suma a lo que ya existe, aunque sea 0)
            oAlquiler_Producto.cantidad_kg -= pesomovido;
        }

        public override string ComprobarTolerancia(Modelo_Entidades.Alquiler oAlquiler, Modelo_Entidades.Documento oDocumento, Modelo_Entidades.Transporte oTransporte, double pesoinicial, double? pesofinal, string estado)
        {
            if (estado == "Autorizado")
            {
                //obtener la carga actual del transporte
                double cargaactual = Convert.ToDouble(pesoinicial) - Convert.ToDouble(oTransporte.tara);
                //calcular espacio libre en transporte
                double espaciolibre = Convert.ToDouble(oTransporte.carga_maxima) - cargaactual;
                //comprobar si el peso del documento puede ser cargado en el transporte
                if ((oDocumento.peso * ( 1+ _porcentajetolerancia/100))<= espaciolibre)
                {
                    return "Aceptable";
                }
                else
                {
                    return "Fuera de tolerancia";
                }
            }
            else
            {
                //estado "En Proceso"
                //convertir el peso final en double
                double _pesofinal = Convert.ToDouble(pesofinal);
                //comprobar que el peso del documento haya sido cargado

                double pesocargado = (_pesofinal - pesoinicial);
                double pesomaximo = (1 + _porcentajetolerancia / 100) * Convert.ToDouble(oDocumento.peso);
                double pesominimo = (1 - _porcentajetolerancia / 100) * Convert.ToDouble(oDocumento.peso);
                if (pesominimo <= pesocargado && pesocargado <= pesomaximo)
                {
                    return "Aceptable";
                }
                else
                {
                    return "Fuera de tolerancia";
                }
            }
        }
    }
}
