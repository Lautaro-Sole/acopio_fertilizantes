using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class CCUInformes
    {
        public struct ClienteYEspacioAlquilado
        {
            //int id;
            public string NombreCliente;
            public Modelo_Entidades.Cliente oCliente;
            public double EspacioAlquilado;
        }

        public struct ClienteYMovimiento
        {
            //int id;
            public string NombreCliente;
            public Modelo_Entidades.Cliente oCliente;
            public double KGMovidos;
        }

        /// <summary>
        /// Da la lista de los diez clientes que han alquilado más espacio.
        /// </summary>
        /// <returns></returns>
        public DataTable ObtenerMejoresClientes(int cantidad)
        {
            List<Modelo_Entidades.Cliente> ListaCompleta = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatClientes.ToList<Modelo_Entidades.Cliente>();
            List<ClienteYEspacioAlquilado> ListaEspaciosAlquilados = new List<ClienteYEspacioAlquilado>();

            //llenar la lista con los espacios alquilados para cada cliente
            foreach (Modelo_Entidades.Cliente oClienteActual in ListaCompleta)
            {
                double EspacioAlquilado = new double();
                foreach (Modelo_Entidades.Alquiler oAlquilerActual in oClienteActual.Alquileres)
                {
                    if (oAlquilerActual.estado == true)
                    {
                        EspacioAlquilado += Convert.ToDouble(oAlquilerActual.capacidad);
                    }
                }
                ClienteYEspacioAlquilado oClienteYEspacioAlquilado = new ClienteYEspacioAlquilado();
                oClienteYEspacioAlquilado.NombreCliente = oClienteActual.nombre;
                oClienteYEspacioAlquilado.EspacioAlquilado = EspacioAlquilado;
                oClienteYEspacioAlquilado.oCliente = oClienteActual;
                ListaEspaciosAlquilados.Add(oClienteYEspacioAlquilado);
            }
            
            //ordenar de forma descendente los clientes
            ListaEspaciosAlquilados.OrderByDescending(oEstructura => oEstructura.EspacioAlquilado);
            //agregar la cantidad especificada de clientes al 

            //devolver la cantidad especificada decimal clientes action la vista
            ListaEspaciosAlquilados.Take<ClienteYEspacioAlquilado>(cantidad);
            //ListaCompleta.Take<Modelo_Entidades.Cliente>(5);

            DataTable TablaVIP = new DataTable();
            TablaVIP.Columns.Add("Nombre", Type.GetType("System.String"));
            TablaVIP.Columns.Add("Teléfono");
            TablaVIP.Columns.Add("E-Mail");
            TablaVIP.Columns.Add("Capacidad Alquilada", Type.GetType("System.Double"));
            
            foreach (ClienteYEspacioAlquilado oClienteYEspacioAlquilado in ListaEspaciosAlquilados)
            {
                DataRow fila = TablaVIP.NewRow();
                /*
                fila.SetField<String>(0, oClienteYEspacioAlquilado.oCliente.nombre);
                fila.SetField<String>(0, oClienteYEspacioAlquilado.oCliente.telefono);
                fila.SetField<String>(0, oClienteYEspacioAlquilado.oCliente.email);
                fila.SetField<Double>(0, oClienteYEspacioAlquilado.EspacioAlquilado);
                */

                fila["Nombre"] = oClienteYEspacioAlquilado.oCliente.nombre;
                fila["Teléfono"] = oClienteYEspacioAlquilado.oCliente.telefono;
                fila["E-Mail"] = oClienteYEspacioAlquilado.oCliente.email;
                fila["Capacidad Alquilada"] = oClienteYEspacioAlquilado.EspacioAlquilado;
                TablaVIP.Rows.Add(fila);

            }


            

            return TablaVIP;

        }

        /// <summary>
        /// Da la lista de los diez clientes que han movido más fertilizante.
        /// </summary>
        /// <returns></returns>
        public DataTable ObtenerMayorCantidadDeFertilizanteMovido(int cantidad)
        {
            List<Modelo_Entidades.Cliente> ListaCompleta = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatClientes.ToList<Modelo_Entidades.Cliente>();
            List<ClienteYMovimiento> ListaMovimientos = new List<ClienteYMovimiento>();

            //llenar la lista con los espacios alquilados para cada cliente
            foreach (Modelo_Entidades.Cliente oClienteActual in ListaCompleta)
            {
                double KGMovidos = new double();
                foreach (Modelo_Entidades.Operacion oOperacionActual in oClienteActual.Operaciones)
                {
                    if (((oOperacionActual.Estado_Operacion.descripcion == "Finalizado") || (oOperacionActual.Estado_Operacion.descripcion == "Cerrado")))
                    {
                        if (oOperacionActual.Tipo_Operacion.descripcion == "Carga")
                        {
                            KGMovidos += Convert.ToDouble(oOperacionActual.peso_final - oOperacionActual.peso_inicial);
                        }
                        else
                        {
                            KGMovidos += Convert.ToDouble(oOperacionActual.peso_inicial - oOperacionActual.peso_final);
                        }
                    }
                }

                ClienteYMovimiento oClienteYMovimiento = new ClienteYMovimiento();
                oClienteYMovimiento.NombreCliente = oClienteActual.nombre;
                oClienteYMovimiento.KGMovidos = KGMovidos;
                oClienteYMovimiento.oCliente = oClienteActual;
                ListaMovimientos.Add(oClienteYMovimiento);
            }

            //ordenar de forma descendente los clientes
            ListaMovimientos.OrderByDescending(oEstructura => oEstructura.KGMovidos);
            //agregar la cantidad especificada de clientes al 

            //devolver la cantidad especificada decimal clientes action la vista
            ListaMovimientos.Take<ClienteYMovimiento>(cantidad);
            //ListaCompleta.Take<Modelo_Entidades.Cliente>(5);

            DataTable TablaVIP = new DataTable();
            TablaVIP.Columns.Add("Nombre", Type.GetType("System.String"));
            TablaVIP.Columns.Add("Teléfono");
            TablaVIP.Columns.Add("E-Mail");
            TablaVIP.Columns.Add("Kilogramos Movidos", Type.GetType("System.Double"));

            foreach (ClienteYMovimiento oClienteYMovimientoActual in ListaMovimientos)
            {
                DataRow fila = TablaVIP.NewRow();
                /*
                fila.SetField<String>(0, oClienteYEspacioAlquilado.oCliente.nombre);
                fila.SetField<String>(0, oClienteYEspacioAlquilado.oCliente.telefono);
                fila.SetField<String>(0, oClienteYEspacioAlquilado.oCliente.email);
                fila.SetField<Double>(0, oClienteYEspacioAlquilado.EspacioAlquilado);
                */

                fila["Nombre"] = oClienteYMovimientoActual.oCliente.nombre;
                fila["Teléfono"] = oClienteYMovimientoActual.oCliente.telefono;
                fila["E-Mail"] = oClienteYMovimientoActual.oCliente.email;
                fila["Kilogramos Movidos"] = oClienteYMovimientoActual.KGMovidos;
                TablaVIP.Rows.Add(fila);

            }




            return TablaVIP;

        }

        /// <summary>
        /// Da la lista de los diez clientes que han movido más fertilizante en el mes especificado.
        /// </summary>
        /// <returns></returns>
        public DataTable ObtenerMayorCantidadDeFertilizanteMovido(int cantidad, int año,int mes)
        {
            List<Modelo_Entidades.Cliente> ListaCompleta = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatClientes.ToList<Modelo_Entidades.Cliente>();
            List<ClienteYMovimiento> ListaMovimientos = new List<ClienteYMovimiento>();

            int DiasDelMes = DateTime.DaysInMonth(año, mes);
            DateTime FechaInicial = Convert.ToDateTime("01-" + mes + "-" + año + " 00:00:00");
            DateTime FechaFinal = Convert.ToDateTime(DiasDelMes + "-" + mes + "-" + año + " 23:59:59");


            //llenar la lista con los espacios alquilados para cada cliente
            foreach (Modelo_Entidades.Cliente oClienteActual in ListaCompleta)
            {
                double KGMovidos = new double();
                foreach (Modelo_Entidades.Operacion oOperacionActual in oClienteActual.Operaciones)
                {
                    //contar sólo las que hayan comenzado durante el mes elegido
                    if ((((oOperacionActual.Estado_Operacion.descripcion == "Finalizado") || (oOperacionActual.Estado_Operacion.descripcion == "Cerrado"))) && ((FechaFinal <= oOperacionActual.fecha_y_hora_inicio) && (oOperacionActual.fecha_y_hora_inicio <= FechaFinal)))
                    {
                        if (oOperacionActual.Tipo_Operacion.descripcion == "Carga")
                        {
                            KGMovidos += Convert.ToDouble(oOperacionActual.peso_final - oOperacionActual.peso_inicial);
                        }
                        else
                        {
                            KGMovidos += Convert.ToDouble(oOperacionActual.peso_inicial - oOperacionActual.peso_final);
                        }
                    }
                }

                ClienteYMovimiento oClienteYMovimiento = new ClienteYMovimiento();
                oClienteYMovimiento.NombreCliente = oClienteActual.nombre;
                oClienteYMovimiento.KGMovidos = KGMovidos;
                oClienteYMovimiento.oCliente = oClienteActual;
                ListaMovimientos.Add(oClienteYMovimiento);
            }

            //ordenar de forma descendente los clientes
            ListaMovimientos.OrderByDescending(oEstructura => oEstructura.KGMovidos);
            //agregar la cantidad especificada de clientes al 

            //devolver la cantidad especificada decimal clientes action la vista
            ListaMovimientos.Take<ClienteYMovimiento>(cantidad);
            //ListaCompleta.Take<Modelo_Entidades.Cliente>(5);

            DataTable TablaVIP = new DataTable();
            TablaVIP.Columns.Add("Nombre", Type.GetType("System.String"));
            TablaVIP.Columns.Add("Teléfono");
            TablaVIP.Columns.Add("E-Mail");
            TablaVIP.Columns.Add("Kilogramos Movidos", Type.GetType("System.Double"));

            foreach (ClienteYMovimiento oClienteYMovimientoActual in ListaMovimientos)
            {
                DataRow fila = TablaVIP.NewRow();
                /*
                fila.SetField<String>(0, oClienteYEspacioAlquilado.oCliente.nombre);
                fila.SetField<String>(0, oClienteYEspacioAlquilado.oCliente.telefono);
                fila.SetField<String>(0, oClienteYEspacioAlquilado.oCliente.email);
                fila.SetField<Double>(0, oClienteYEspacioAlquilado.EspacioAlquilado);
                */

                fila["Nombre"] = oClienteYMovimientoActual.oCliente.nombre;
                fila["Teléfono"] = oClienteYMovimientoActual.oCliente.telefono;
                fila["E-Mail"] = oClienteYMovimientoActual.oCliente.email;
                fila["Kilogramos Movidos"] = oClienteYMovimientoActual.KGMovidos;
                TablaVIP.Rows.Add(fila);

            }




            return TablaVIP;

        }



        /// <summary>
        /// Da la lista de los diez clientes que han movido más fertilizante en los meses especificados.
        /// </summary>
        /// <returns></returns>
        public DataTable ObtenerMayorCantidadDeFertilizanteMovido(int cantidad, int añoinicial, int mesinicial, int añofinal, int mesfinal)
        {
            List<Modelo_Entidades.Cliente> ListaCompleta = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatClientes.ToList<Modelo_Entidades.Cliente>();
            List<ClienteYMovimiento> ListaMovimientos = new List<ClienteYMovimiento>();

            int DiasDelMes = DateTime.DaysInMonth(añofinal, mesfinal);
            DateTime FechaInicial = Convert.ToDateTime("01-" + mesinicial + "-" + añoinicial + " 00:00:00");
            DateTime FechaFinal = Convert.ToDateTime(DiasDelMes + "-" + mesfinal + "-" + añofinal + " 23:59:59");


            //llenar la lista con los espacios alquilados para cada cliente
            foreach (Modelo_Entidades.Cliente oClienteActual in ListaCompleta)
            {
                double KGMovidos = new double();
                foreach (Modelo_Entidades.Operacion oOperacionActual in oClienteActual.Operaciones)
                {
                    //contar sólo las que hayan comenzado durante el mes elegido
                    if ((((oOperacionActual.Estado_Operacion.descripcion == "Finalizado") || (oOperacionActual.Estado_Operacion.descripcion == "Cerrado"))) && ((FechaInicial <= oOperacionActual.fecha_y_hora_inicio) && (oOperacionActual.fecha_y_hora_inicio <= FechaFinal)))
                    {
                        if (oOperacionActual.Tipo_Operacion.descripcion == "Carga")
                        {
                            KGMovidos += Convert.ToDouble(oOperacionActual.peso_final - oOperacionActual.peso_inicial);
                        }
                        else
                        {
                            KGMovidos += Convert.ToDouble(oOperacionActual.peso_inicial - oOperacionActual.peso_final);
                        }
                    }
                }

                ClienteYMovimiento oClienteYMovimiento = new ClienteYMovimiento();
                oClienteYMovimiento.NombreCliente = oClienteActual.nombre;
                oClienteYMovimiento.KGMovidos = KGMovidos;
                oClienteYMovimiento.oCliente = oClienteActual;
                ListaMovimientos.Add(oClienteYMovimiento);
            }

            //ordenar de forma descendente los clientes
            ListaMovimientos.OrderByDescending(oEstructura => oEstructura.KGMovidos);
            //agregar la cantidad especificada de clientes al 

            //devolver la cantidad especificada decimal clientes action la vista
            ListaMovimientos.Take<ClienteYMovimiento>(cantidad);
            //ListaCompleta.Take<Modelo_Entidades.Cliente>(5);

            DataTable TablaVIP = new DataTable();
            TablaVIP.Columns.Add("Nombre", Type.GetType("System.String"));
            TablaVIP.Columns.Add("Teléfono");
            TablaVIP.Columns.Add("E-Mail");
            TablaVIP.Columns.Add("Kilogramos Movidos", Type.GetType("System.Double"));

            foreach (ClienteYMovimiento oClienteYMovimientoActual in ListaMovimientos)
            {
                DataRow fila = TablaVIP.NewRow();
                /*
                fila.SetField<String>(0, oClienteYEspacioAlquilado.oCliente.nombre);
                fila.SetField<String>(0, oClienteYEspacioAlquilado.oCliente.telefono);
                fila.SetField<String>(0, oClienteYEspacioAlquilado.oCliente.email);
                fila.SetField<Double>(0, oClienteYEspacioAlquilado.EspacioAlquilado);
                */

                fila["Nombre"] = oClienteYMovimientoActual.oCliente.nombre;
                fila["Teléfono"] = oClienteYMovimientoActual.oCliente.telefono;
                fila["E-Mail"] = oClienteYMovimientoActual.oCliente.email;
                fila["Kilogramos Movidos"] = oClienteYMovimientoActual.KGMovidos;
                TablaVIP.Rows.Add(fila);

            }




            return TablaVIP;

        }


        public void GenerarInformeMejoresClientes(int cantidad)
        {
            
        }
    }



}
