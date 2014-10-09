﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    public class EstrategiaDescarga : EstrategiaOperacion
    {
        /*
        public override string ComprobarPosibilidadDeOperacion(double pesodocumento, double capacidad, double capacidadocupada)
        {
            double capacidaddisponible = capacidad - capacidadocupada;
            if (pesodocumento <= capacidaddisponible)
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
            double capacidaddisponible = Convert.ToDouble(oAlquiler.capacidad) - Convert.ToDouble(oAlquiler.EspacioUtilizado);
            if (oDocumento.peso <= capacidaddisponible)
            {
                return "Posible";
            }
            else
            {
                return "Imposible";
            }
        }

        public override string ComprobarFertilizanteMovido(double pesodocumento, double pesoinicial, double pesofinal)
        {
            double pesocargado = (pesoinicial - pesofinal);
            double pesomaximo = (1 + _porcentajetolerancia / 100) * pesodocumento;
            double pesominimo = (1 - _porcentajetolerancia / 100) * pesodocumento;
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
            //obtener la cantidad de fertilizante movida realmente
            double pesomovido = pesoinicial - pesofinal;

            //buscar la relación entre el alquiler y el producto especificado en el documento
            Modelo_Entidades.Alquiler_Producto oAlquiler_Producto = oAlquiler.Alquiler_Productos.ToList<Modelo_Entidades.Alquiler_Producto>().Find(delegate(Modelo_Entidades.Alquiler_Producto oAlquiler_ProductoActual) { return oAlquiler_ProductoActual.Producto == oDocumento.Producto; });
            //si no existe crearlo
            if (oAlquiler_Producto == null)
            {
                oAlquiler_Producto = new Alquiler_Producto();
                //asignarle el alquiler recibido
                oAlquiler_Producto.Alquiler = oAlquiler;
                //asignarle el producto en el documento
                oAlquiler_Producto.Producto = oDocumento.Producto;
            }

            //actualizar la cantidad del tipo de fertilizante especificado (+= porque se suma a lo que ya existe, aunque sea 0)
            oAlquiler_Producto.cantidad_kg += pesomovido;
        }
    }
}
