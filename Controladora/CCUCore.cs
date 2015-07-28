using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Data.Objects;

namespace Controladora
{
    public class CCUCore
    {
        private static CCUCore Instancia;

        public static CCUCore ObtenerInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new CCUCore();
            }
            return Instancia;
        }

        private CCUCore()
        {

        }


        #region Utilidades
        
        int kilosporbolsa = 50;
        int kilospormetrocuadrado = 90;
        public Int32 ConvertirM2aKG(Int32 metros)
        {
            return metros * kilospormetrocuadrado;
        }

        public Int32 ConvertirM2aBolsas(Int32 metros)
        {
            return metros * kilospormetrocuadrado / kilosporbolsa;
        }

        public Int32 ConvertirKGaM2(Int32 kilogramos)
        {
            return kilogramos / kilospormetrocuadrado;
        }
        public Int64 ConvertirKGaM2(Int64 kilogramos)
        {
            return Convert.ToInt64(kilogramos) / Convert.ToInt64(kilospormetrocuadrado);
        }

        public Int32 ConvertirKGaBolsas(Int32 kilogramos)
        {
            return kilogramos / kilosporbolsa;
        }

        public Int32 ConvertirBolsasaKG(Int32 bolsas)
        {
            return bolsas * kilosporbolsa;
        }

        public Int32 ConvertirBolsasaM2(Int32 bolsas)
        {
            return bolsas / kilosporbolsa / kilospormetrocuadrado;
        }
        #endregion

        #region Otros
        // seccion clientes:
        public List<Modelo_Entidades.Cliente> ObtenerClientes()
        {
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatClientes.ToList<Modelo_Entidades.Cliente>();
        }

        public List<Modelo_Entidades.Cliente> ObtenerClientes(string nombre)
        {
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatClientes.ToList<Modelo_Entidades.Cliente>().FindAll(delegate(Modelo_Entidades.Cliente oClienteBuscado) { return oClienteBuscado.nombre.StartsWith(nombre); });
        }
        //seccion choferes:
        public List<Modelo_Entidades.Chofer> ObtenerChoferes()
        {
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatChoferes.ToList<Modelo_Entidades.Chofer>();
        }

        public List<Modelo_Entidades.Chofer> ObtenerChoferes(string nombre, string apellido, string tipo_documento, int nro_documento, string nombre_cliente)
        {
            List<Modelo_Entidades.Chofer> oListaChoferes = new List<Modelo_Entidades.Chofer>();
            oListaChoferes = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatChoferes.ToList<Modelo_Entidades.Chofer>();
            if (nombre != null & nombre != "")
            {
                //oListaChoferes = oListaChoferes.FindAll(delegate(Modelo_Entidades.Chofer oChoferBuscado) { return oChoferBuscado.nombre == nombre; });
                oListaChoferes = oListaChoferes.FindAll(delegate(Modelo_Entidades.Chofer oChoferBuscado) { return oChoferBuscado.nombre.StartsWith(Convert.ToString(nombre)); });
            }
            if (apellido != null & apellido != "")
            {
                oListaChoferes = oListaChoferes.FindAll(delegate(Modelo_Entidades.Chofer oChoferBuscado) { return oChoferBuscado.apellido.StartsWith(apellido.ToString()); });
            }
            if (tipo_documento != null & tipo_documento != "")
            {
                oListaChoferes = oListaChoferes.FindAll(delegate(Modelo_Entidades.Chofer oChoferBuscado) { return oChoferBuscado.tipo_documento.StartsWith(tipo_documento.ToString()); });
            }

            if (nro_documento != 0)
            {
                oListaChoferes = oListaChoferes.FindAll(delegate(Modelo_Entidades.Chofer oChoferBuscado) { return Convert.ToString(oChoferBuscado.num_documento).StartsWith(Convert.ToString(nro_documento)); });
            }
            List<Modelo_Entidades.Chofer> oListaChoferesTemporal = oListaChoferes;
            List<Modelo_Entidades.Chofer> oListaChoferesTemporal2 = new List<Modelo_Entidades.Chofer>();

            if (nombre_cliente != null & nombre_cliente != "")
            {
                // si el chofer trabaja para al menos uno de los clientes que tienen este nombre no se lo quita de la lista
                //obtener la lista de los clientes para los que trabaja cada chofer
                foreach (Modelo_Entidades.Chofer oChofer in oListaChoferesTemporal)
                {
                    List<Modelo_Entidades.Cliente> oListaClientes = oChofer.Clientes.ToList<Modelo_Entidades.Cliente>().FindAll(delegate(Modelo_Entidades.Cliente oClienteBuscado) { return oClienteBuscado.nombre.StartsWith(nombre_cliente.ToString()); });
                    //si la lista está vacía quitar el chofer de la lista de choferes
                    if (oListaClientes.Count != 0)
                    {
                        oListaChoferesTemporal2.Add(oChofer);
                    }
                }
            }
            if (oListaChoferesTemporal2.Count != 0)
            {
                return oListaChoferesTemporal2;
            }
            else return oListaChoferes;

        }
        //seccion transportes:
        public List<Modelo_Entidades.Transporte> ObtenerTransportes()
        {
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatTransportes.ToList<Modelo_Entidades.Transporte>();
        }

        public List<Modelo_Entidades.Transporte> ObtenerTransportes(string tipo_matricula, string nro_matricula, string nombre_cliente, string nombre_chofer)
        {
            List<Modelo_Entidades.Transporte> oListaTransportes = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatTransportes.ToList<Modelo_Entidades.Transporte>();
            if (tipo_matricula != null & tipo_matricula != "")
            {
                int _tipo_matricula = Convert.ToInt32(tipo_matricula);
                oListaTransportes = oListaTransportes.FindAll(delegate(Modelo_Entidades.Transporte oTransporteBuscado) { return oTransporteBuscado.tipo_matricula == _tipo_matricula; });
            }
            if (nro_matricula != null & nro_matricula != "")
            {
                oListaTransportes = oListaTransportes.FindAll(delegate(Modelo_Entidades.Transporte oTransporteBuscado) { return oTransporteBuscado.nro_matricula.StartsWith(nro_matricula); });
            }
            if (nombre_chofer != null & nombre_chofer != "")
            {
                //oListaTransportes = oListaTransportes.FindAll(delegate(Modelo_Entidades.Transporte oTransporteBuscado) { return oTransporteBuscado.Choferes..StartsWith(nombre_chofer); });
                List<Modelo_Entidades.Transporte> oListaTemporal = new List<Modelo_Entidades.Transporte>();
                foreach (Modelo_Entidades.Transporte oTransporteActual in oListaTransportes)
                {
                    Modelo_Entidades.Chofer oChofer = oTransporteActual.Choferes.ToList<Modelo_Entidades.Chofer>().Find(delegate(Modelo_Entidades.Chofer oChoferBuscado) { return oChoferBuscado.nombre.StartsWith(nombre_chofer); });
                    if (oChofer != null)
                    {
                        oListaTemporal.Add(oTransporteActual);
                    }
                }
                oListaTransportes = oListaTemporal;

            }
            List<Modelo_Entidades.Transporte> oListaTemporal2 = new List<Modelo_Entidades.Transporte>();
            if (nombre_cliente != null & nombre_cliente != "")
            {

                foreach (Modelo_Entidades.Transporte oTransporte in oListaTransportes)
                {
                    List<Modelo_Entidades.Chofer> oListaChoferes = oTransporte.Choferes.ToList<Modelo_Entidades.Chofer>(); // FindAll(delegate(Modelo_Entidades.Chofer oChoferBuscado) { return oChoferBuscado.nombre.StartsWith(nombre_cliente); });
                    List<Modelo_Entidades.Chofer> oListaChoferes2 = oTransporte.Choferes.ToList<Modelo_Entidades.Chofer>();
                    // si el chofer trabaja para al menos uno de los clientes que tienen este nombre no se lo quita de la lista
                    //obtener la lista de los clientes para los que trabaja cada chofer
                    foreach (Modelo_Entidades.Chofer oChofer in oListaChoferes)
                    {
                        List<Modelo_Entidades.Cliente> oListaClientes = oChofer.Clientes.ToList<Modelo_Entidades.Cliente>().FindAll(delegate(Modelo_Entidades.Cliente oClienteBuscado) { return oClienteBuscado.nombre.StartsWith(nombre_cliente); });
                        //si la lista está vacía quitar el chofer de la lista de choferes
                        if (oListaClientes.Count != 0)
                        {
                            oListaChoferes2.Add(oChofer);
                        }
                    }

                    //si la lista de choferes está vacía quitar el transporte de la lista de transportes
                    if (oListaChoferes2.Count != 0)
                    {
                        oListaTemporal2.Add(oTransporte);
                    }
                }
            }
            oListaTransportes = oListaTemporal2;
            return oListaTransportes;
        }
        #endregion

        public List<Modelo_Entidades.Operacion> ObtenerOperaciones()
        {
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatOperaciones.ToList<Modelo_Entidades.Operacion>();
        }

        #region Búsquedas
        

        /// <summary>
        /// Buscar todos los Operaciones de carga
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public List<Modelo_Entidades.Operacion> ObtenerOperacionesCarga()
        {
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatOperaciones.ToList<Modelo_Entidades.Operacion>().FindAll(delegate(Modelo_Entidades.Operacion oOperacionBuscada) { return (oOperacionBuscada.Tipo_Operacion.descripcion == "Carga"); });
        }

        /// <summary>
        /// Buscar todos los Operaciones de descarga
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public List<Modelo_Entidades.Operacion> ObtenerOperacionesDescarga()
        {
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatOperaciones.ToList<Modelo_Entidades.Operacion>().FindAll(delegate(Modelo_Entidades.Operacion oOperacionBuscada) { return (oOperacionBuscada.Tipo_Operacion.descripcion == "Descarga"); });
        }

        public List<Modelo_Entidades.Operacion> ObtenerOperaciones(string tipo_matricula, string nro_matricula, string tipo_operacion, string estado, string nombre_cliente, string nombre_chofer)
        {
            List<Modelo_Entidades.Operacion> oListaOperaciones = new List<Modelo_Entidades.Operacion>();
            oListaOperaciones = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatOperaciones.ToList<Modelo_Entidades.Operacion>();
            if (tipo_matricula != null && !string.IsNullOrWhiteSpace(tipo_matricula))
            {
                int _tipo_matricula = Convert.ToInt32(tipo_matricula);
                oListaOperaciones = oListaOperaciones.FindAll(delegate(Modelo_Entidades.Operacion oOperacionBuscada) { return (oOperacionBuscada.Transporte.tipo_matricula == _tipo_matricula); });
            }
            if (nro_matricula != null && !string.IsNullOrWhiteSpace(nro_matricula))
            {
                oListaOperaciones = oListaOperaciones.FindAll(delegate(Modelo_Entidades.Operacion oOperacionBuscada) { return (oOperacionBuscada.Transporte.nro_matricula.StartsWith(nro_matricula)); });
            }
            if (tipo_operacion != null && !string.IsNullOrWhiteSpace(tipo_operacion))
            {
                int _tipo_operacion = Convert.ToInt32(tipo_operacion);
                oListaOperaciones = oListaOperaciones.FindAll(delegate(Modelo_Entidades.Operacion oOperacionBuscada) { return (oOperacionBuscada.tipo_operacion == _tipo_operacion); });
            }
            if (estado != null && !string.IsNullOrWhiteSpace(estado))
            {
                int _estado = Convert.ToInt32(estado);
                oListaOperaciones = oListaOperaciones.FindAll(delegate(Modelo_Entidades.Operacion oOperacionBuscada) { return (oOperacionBuscada.estado == _estado); });
            }
            if (nombre_chofer != null && !string.IsNullOrWhiteSpace(nombre_chofer))
            {
                oListaOperaciones = oListaOperaciones.FindAll(delegate(Modelo_Entidades.Operacion oOperacionBuscada) { return (oOperacionBuscada.Chofer.nombre.StartsWith(nombre_chofer)); });
            }
            if (nombre_cliente != null && !string.IsNullOrWhiteSpace(nombre_cliente))
            {
                oListaOperaciones = oListaOperaciones.FindAll(delegate(Modelo_Entidades.Operacion oOperacionBuscada) { return (oOperacionBuscada.Alquiler.Cliente.nombre.StartsWith(nombre_cliente)); });
            }
            return oListaOperaciones;
        }

        /*
        /// <summary>
        /// Buscar todos los Operaciones de un cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public List<Modelo_Entidades.Operacion> ObtenerOperaciones(string cliente)
        {
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatOperaciones.ToList<Modelo_Entidades.Operacion>().FindAll(delegate(Modelo_Entidades.Operacion oOperacionBuscada) { return oOperacionBuscada.Transporte.Chofer.Cliente.nombre == cliente; });
        }
        

        /// <summary>
        /// Buscar todos los Operaciones de carga de un cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public List<Modelo_Entidades.Operacion> ObtenerOperacionesCarga(string cliente)
        {
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatOperaciones.ToList<Modelo_Entidades.Operacion>().FindAll(delegate(Modelo_Entidades.Operacion oOperacionBuscada) { return (oOperacionBuscada.Transporte.Chofer.Cliente.nombre == cliente) & (oOperacionBuscada.GetType() == typeof(Modelo_Entidades.Operacion)); });
        }

        /// <summary>
        /// Buscar todos los Operaciones de descarga de un cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public List<Modelo_Entidades.Operacion> ObtenerOperacionesDescarga(string cliente)
        {
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatOperaciones.ToList<Modelo_Entidades.Operacion>().FindAll(delegate(Modelo_Entidades.Operacion oOperacionBuscada) { return (oOperacionBuscada.Transporte.Chofer.Cliente.nombre == cliente) & (oOperacionBuscada.GetType() == typeof(Modelo_Entidades.Operacion)); });
        }
        */
        /*
        /// <summary>
        /// Buscar todos los Operaciones con el estado especificado de un cliente
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public List<Modelo_Entidades.Operacion> ObtenerOperaciones(string estado, string cliente)
        {
            if (estado != "Cualquiera")
            {
                return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatOperaciones.ToList<Modelo_Entidades.Operacion>().FindAll(delegate(Modelo_Entidades.Operacion oOperacionBuscada) { return (oOperacionBuscada.Transporte.Chofer.Cliente.nombre == cliente) & (oOperacionBuscada.estado == estado); });
            }
            else
            {
                return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatOperaciones.ToList<Modelo_Entidades.Operacion>().FindAll(delegate(Modelo_Entidades.Operacion oOperacionBuscada) { return oOperacionBuscada.Transporte.Chofer.Cliente.nombre == cliente; });
            }
        }

        /// <summary>
        /// Buscar todos los Operaciones con el estado especificado 
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public List<Modelo_Entidades.Operacion> ObtenerOperaciones(string estado)
        {
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatOperaciones.ToList<Modelo_Entidades.Operacion>().FindAll(delegate(Modelo_Entidades.Operacion oOperacionBuscada) { return (oOperacionBuscada.estado == estado); });
        }

        /// <summary>
        /// Buscar todos los Operaciones de carga con el estado especificado de un cliente
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public List<Modelo_Entidades.Operacion> ObtenerOperacionesCarga(string estado, string cliente)
        {
            if (estado != "Cualquiera")
            {
                return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatOperaciones.ToList<Modelo_Entidades.Operacion>().FindAll(delegate(Modelo_Entidades.Operacion oOperacionBuscada) { return (oOperacionBuscada.Transporte.Chofer.Cliente.nombre == cliente) & (oOperacionBuscada.estado == estado) & (oOperacionBuscada.GetType() == typeof(Modelo_Entidades.Operacion)); });
            }
            else
            {
                return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatOperaciones.ToList<Modelo_Entidades.Operacion>().FindAll(delegate(Modelo_Entidades.Operacion oOperacionBuscada) { return (oOperacionBuscada.Transporte.Chofer.Cliente.nombre == cliente) & (oOperacionBuscada.GetType() == typeof(Modelo_Entidades.Operacion)); });
            }
        }

        /// <summary>
        /// Buscar todos los Operaciones de descarga con el estado especificado de un cliente
        /// </summary>
        /// <param name="estado"></param>
        /// <returns></returns>
        public List<Modelo_Entidades.Operacion> ObtenerOperacionesDesCarga(string estado, string cliente)
        {
            if (estado != "Cualquiera")
            {
                return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatOperaciones.ToList<Modelo_Entidades.Operacion>().FindAll(delegate(Modelo_Entidades.Operacion oOperacionBuscada) { return (oOperacionBuscada.Transporte.Chofer.Cliente.nombre == cliente) & (oOperacionBuscada.estado == estado) & (oOperacionBuscada.GetType() == typeof(Modelo_Entidades.Operacion)); });
            }
            else
            {
                return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatOperaciones.ToList<Modelo_Entidades.Operacion>().FindAll(delegate(Modelo_Entidades.Operacion oOperacionBuscada) { return (oOperacionBuscada.Transporte.Chofer.Cliente.nombre == cliente) & (oOperacionBuscada.GetType() == typeof(Modelo_Entidades.Operacion)); });
            }
        }
        
        */
        #endregion
        /*
        //sección carga
        public bool Alta(Modelo_Entidades.Operacion oTicket_Carga)
        {
            Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatOperaciones.AddObject(oTicket_Carga);
            int resultado = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().SaveChanges();
            if (resultado != -1) return true;
            else return false;
        }
        public bool Modificacion(Modelo_Entidades.Operacion oTicket_Carga)
        {
            Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatOperaciones.ApplyCurrentValues(oTicket_Carga);
            int resultado = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().SaveChanges();
            if (resultado != -1) return true;
            else return false;
        }

        //sección descarga
        public bool Alta(Modelo_Entidades.Operacion oTicket_Descarga)
        {
            Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatOperaciones.AddObject(oTicket_Descarga);
            int resultado = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().SaveChanges();
            if (resultado != -1) return true;
            else return false;
        }
        public bool Modificacion(Modelo_Entidades.Operacion oTicket_Descarga)
        {
            Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatOperaciones.ApplyCurrentValues(oTicket_Descarga);
            int resultado = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().SaveChanges();
            if (resultado != -1) return true;
            else return false;
        }
        */

        public bool Agregar(Modelo_Entidades.Operacion oOperacion)
        {
            Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatOperaciones.AddObject(oOperacion);
            int resultado = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().SaveChanges();
            if (resultado != -1) return true;
            else return false;
        }
        public bool Modificar(Modelo_Entidades.Operacion oOperacion)
        {
            bool resultadoauditoria = Auditar(Convert.ToInt64(oOperacion.nro_operacion));
            if (resultadoauditoria)
            {
                Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatOperaciones.ApplyCurrentValues(oOperacion);
                /*
                int resultado = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().SaveChanges();
                if (resultado != -1) return true;
                else return false;
                 * */
                // fuente: http://stackoverflow.com/questions/11819344/visual-studio-2012-cant-find-system-transactions-assembly-in-net-4-5-framew
                using (TransactionScope scope = new TransactionScope())
                {
                    //Hacer algo con el contexto 1
                    //Hacer algo con el contexto 2

                    //Guardar cambios pero no descartar todavía
                    //cambiado por obsoleto
                    //Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().SaveChanges(false);
                    Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().SaveChanges(SaveOptions.DetectChangesBeforeSave);

                    //Guardar cambios pero no descartar todavía
                    //Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().SaveChanges(false);
                    Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().SaveChanges(SaveOptions.DetectChangesBeforeSave);

                    //si llegamos acá vamos bien
                    scope.Complete();
                    //completado lo que se mandará en transacción
                    Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().AcceptAllChanges();
                    Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().AcceptAllChanges();
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        #region Auditoría



        public bool Auditar(Int64 nro_operacion)
        {
            //buscar el objeto sin modificar en el catálogo de operaciones de la base de trabajo
            Modelo_Entidades.Operacion oOperacionAntigua = ObtenerOperacion(nro_operacion);
            //crear el objeto nuevo del tipo de la auditoría
            Modelo_Entidades.Operacion_Auditoria oOperacionAuditoria = new Modelo_Entidades.Operacion_Auditoria();
            //si existe la operación
            if (oOperacionAntigua != null)
            {
                //entonces asignar los valores antiguos a la operación que será guardada en la tabla de auditoría
                oOperacionAuditoria = this.CopiarValores(oOperacionAntigua, oOperacionAuditoria);
                //enviar la operacion con los valores antiguos al catálogo de auditoría
                Modelo_Entidades.Modelo_Auditoria.ObtenerInstancia().CatOperaciones_Auditoria.AddObject(oOperacionAuditoria);
                // se quita este savechanges para que se guarden todos los cambios de una sola vez
                /*
                int resultado1 = Modelo_Entidades.Modelo_AuditoriaEntities2.ObtenerInstancia().SaveChanges();
                if (resultado1 != -1)
                    return true;
                else return false;
                 * */
                return true;
            }
            else return false;
        }



        public Modelo_Entidades.Operacion ObtenerOperacion(Int64 nro_operacion)
        {
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatOperaciones.ToList<Modelo_Entidades.Operacion>().Find(delegate(Modelo_Entidades.Operacion oOperacionBuscada) { return oOperacionBuscada.nro_operacion == nro_operacion; });
        }

        public Modelo_Entidades.Operacion_Auditoria CopiarValores(Modelo_Entidades.Operacion oOperacionAntigua, Modelo_Entidades.Operacion_Auditoria oOperacionAuditoria)
        {
            oOperacionAuditoria.accion = oOperacionAntigua.accion;
            //oOperacionAuditoria.estado = oOperacionAntigua.estado;
            //oOperacionAuditoria.estado = oOperacionAntigua.Estado_Operacion.id_estado_operacion;
            oOperacionAuditoria.estado = oOperacionAntigua.estado;

            oOperacionAuditoria.fecha_y_hora_accion = oOperacionAntigua.fecha_y_hora_accion;
            oOperacionAuditoria.fecha_y_hora_fin = oOperacionAntigua.fecha_y_hora_fin;
            oOperacionAuditoria.fecha_y_hora_inicio = oOperacionAntigua.fecha_y_hora_inicio;
            oOperacionAuditoria.notas = oOperacionAntigua.notas;
            oOperacionAuditoria.nro_alquiler = oOperacionAntigua.nro_alquiler;
            oOperacionAuditoria.nro_chofer = oOperacionAntigua.nro_chofer;
            oOperacionAuditoria.nro_documento = oOperacionAntigua.nro_documento;
            //oOperacionAuditoria.nro_documento = oOperacionAntigua.nro_documento;
            oOperacionAuditoria.nro_operacion = oOperacionAntigua.Documento.nro_documento;
            oOperacionAuditoria.nro_transporte = oOperacionAntigua.nro_transporte;
            oOperacionAuditoria.peso_final = oOperacionAntigua.peso_final;
            oOperacionAuditoria.peso_inicial = oOperacionAntigua.peso_inicial;
            oOperacionAuditoria.tipo_documento = oOperacionAntigua.tipo_documento;
            oOperacionAuditoria.tipo_operacion = oOperacionAntigua.tipo_operacion;
            oOperacionAuditoria.USU_CODIGO = oOperacionAntigua.USU_CODIGO;
            oOperacionAuditoria.nro_cliente = oOperacionAntigua.nro_cliente;
            return oOperacionAuditoria;
        }

        #endregion









        #region Strategy


        public bool ComprobrarPosibilidadDeOperacion(Modelo_Entidades.Operacion oOperacion)
        {
            string respuesta = oOperacion.ComprobrarPosibilidadDeOperacion();
            if (respuesta == "Posible")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ComprobarFertilizanteMovido(Modelo_Entidades.Operacion oOperacion)
        {
            string respuesta = oOperacion.ComprobarFertilizanteMovido();
            if (respuesta == "Correcto")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ActualizarAlquiler(Modelo_Entidades.Operacion oOperacion)
        {
            oOperacion.ActualizarAlquiler();
        }

        public bool ComprobarTolerancia(Modelo_Entidades.Operacion oOperacion)
        {
            string respuesta = oOperacion.ComprobarTolerancia();
            if (respuesta == "Aceptable")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion


        #region tipos
        public List<Modelo_Entidades.Tipo_Matricula> ObtenerTiposMatricula()
        {
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatTipos_Matricula.ToList();
        }

        public List<Modelo_Entidades.Tipo_Operacion> ObtenerTiposOperacion()
        {
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatTipos_Operacion.ToList();
        }

        public List<Modelo_Entidades.Estado_Operacion> ObtenerEstadosOperacion()
        {
            return Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatEstados_Operacion.ToList();
        }
        #endregion
    }
}
