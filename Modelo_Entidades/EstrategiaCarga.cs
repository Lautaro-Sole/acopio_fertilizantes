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
    }
}
