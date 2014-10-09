using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    public partial class Alquiler
    {
        public double EspacioUtilizado
        { 
            get
            {
                double _espacio_Utilizado = 0;
                foreach (Modelo_Entidades.Alquiler_Producto oProductoActual in this.Alquiler_Productos)
                   {
                        _espacio_Utilizado += Convert.ToDouble(oProductoActual.cantidad_kg);
                   }
                return _espacio_Utilizado;
            }
        }

        public int DistanciaAEmpresa
        {
            get
            {
                return Convert.ToInt32(this.Almacen.distancia_a_empresa);
            }
        }

        public double CantidadBolsa
        {
            get
                {
                    //return Convert.ToDouble(this.Alquiler_Productos.ToList<Alquiler_Producto>().Find(delegate(Alquiler_Producto oAlquiler_ProductoActual) { return oAlquiler_ProductoActual.codigo_producto == 1; }).cantidad_kg);
                    Modelo_Entidades.Alquiler_Producto oAlquilerProducto = this.Alquiler_Productos.ToList<Alquiler_Producto>().Find(delegate(Alquiler_Producto oAlquiler_ProductoActual) { return oAlquiler_ProductoActual.codigo_producto == 1; });
                    if (oAlquilerProducto == null)
                    {
                        return 0;
                    }
                    else
                    {
                        return Convert.ToDouble(oAlquilerProducto.cantidad_kg);
                    }
                }
        }

        public double CantidadGranel
        {
            get
            {
                Modelo_Entidades.Alquiler_Producto oAlquilerProducto = this.Alquiler_Productos.ToList<Alquiler_Producto>().Find(delegate(Alquiler_Producto oAlquiler_ProductoActual) { return oAlquiler_ProductoActual.codigo_producto == 2; });
                if (oAlquilerProducto == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToDouble(oAlquilerProducto.cantidad_kg);
                }
            }
        }

        public string EstadoActual
        {
            get
            {
                if (this.estado == true)
                {
                    return "Activo";
                }
                else
                {
                    return "Vencido";
                }
            }
        }

        public override string ToString()
        {
            return this.Almacen.nombre + "(" + this.Almacen.direccion + "), " + (this.capacidad - this.EspacioUtilizado).ToString() + " kg de " + this.capacidad.ToString() + " kg disponibles.";
        }

    }
}
