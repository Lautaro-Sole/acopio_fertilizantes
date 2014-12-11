using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class CCUGGrupos
    {
        private static CCUGGrupos oInstancia;
        public static CCUGGrupos ObtenerInstancia()
        {
            if (oInstancia == null) oInstancia = new CCUGGrupos();
            return oInstancia;
        }
        /// <summary>
        /// Devuelve todos los grupos. 
        /// </summary>
        public List<Modelo_Entidades.GRUPO> ObtenerGrupos()
        {
            return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().GRUPOS.ToList<Modelo_Entidades.GRUPO>();
        }

        /// <summary>
        /// Devuelve todos los grupos con el estado indicado. 
        /// </summary>
        public List<Modelo_Entidades.GRUPO> ObtenerGrupos(bool estado)
        {
            return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().GRUPOS.ToList<Modelo_Entidades.GRUPO>().FindAll(delegate(Modelo_Entidades.GRUPO oGrupo) { return oGrupo.GRU_ESTADO == estado; });
        }

        /// <summary>
        /// Devuelve todos los grupos cuyas descripciones comienzen con la descripción ingresada.
        /// </summary>
        public List<Modelo_Entidades.GRUPO> ObtenerGrupos(string descripcion)
        {
            return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().GRUPOS.ToList<Modelo_Entidades.GRUPO>().FindAll(delegate(Modelo_Entidades.GRUPO oGrupo) { return oGrupo.GRU_DESCRIPCION.StartsWith(descripcion); });
        }

        /// <summary>
        /// Devuelve todos los grupos cuyas descripciones comienzen con la descripción ingresada y que tengan el estado indicado.
        /// </summary>
        public List<Modelo_Entidades.GRUPO> ObtenerGrupos(string descripcion, bool estado)
        {
            return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().GRUPOS.ToList<Modelo_Entidades.GRUPO>().FindAll(delegate(Modelo_Entidades.GRUPO oGrupo) { return (oGrupo.GRU_DESCRIPCION.StartsWith(descripcion))&(oGrupo.GRU_ESTADO==estado); });
        }

        /// <summary>
        /// Devuelve true si ya existe un grupo con esa descripción. 
        /// </summary>
        public bool ComprobarGrupo(string descripcion)
        {
            Modelo_Entidades.GRUPO oGrupo = Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().GRUPOS.ToList<Modelo_Entidades.GRUPO>().Find(delegate(Modelo_Entidades.GRUPO oGrupoBuscado) { return oGrupoBuscado.GRU_DESCRIPCION == descripcion; });
            if (oGrupo != null)
            {
                return true;
            }
            return false;
        }

        public Modelo_Entidades.GRUPO ObtenerGrupo(string descripcion)
        {
            return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().GRUPOS.ToList<Modelo_Entidades.GRUPO>().Find(delegate(Modelo_Entidades.GRUPO oGrupoBuscado) { return oGrupoBuscado.GRU_DESCRIPCION == descripcion; });

        }
        /// <summary>
        /// Devuelve true si ya existe un grupo con esa descripción y es que estoy modificando en este momento, lo que significa que puedo seguir. 
        /// Devuelve false si no hay un grupo con esa descripción o si hay un grupo con esa descripcion y con distinto código.
        /// </summary>
        public bool ObtenerGrupo(string codigo, string descripcion)
        {
            
            //Modelo_Entidades.GRUPO oGrupo = Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().GRUPOS.ToList<Modelo_Entidades.GRUPO>().Find(delegate(Modelo_Entidades.GRUPO oGrupoBuscado) { return (oGrupoBuscado.GRU_DESCRIPCION == descripcion & oGrupoBuscado.GRU_CODIGO==codigo); });
            
            //buscar un grupo con el código enviado
            Modelo_Entidades.GRUPO oGrupo = Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().GRUPOS.ToList<Modelo_Entidades.GRUPO>().Find(delegate(Modelo_Entidades.GRUPO oGrupoBuscado) { return oGrupoBuscado.GRU_DESCRIPCION == descripcion; });
            if (oGrupo == null) // existe algún grupo con esa descripción?
            {
                return true;// si no existe un grupo con esa descripción entonces puedo seguir
            }
            if (oGrupo.GRU_CODIGO == codigo) //y si el código es el mismo
            {
                return true; //entonces puedo seguir
            }
            else return false; //si tiene distinto código es otro grupo con la misma descripción, entonces no puedo guardar este
        }

        public Modelo_Entidades.GRUPO ObtenerGrupoPorCodigo(string codigo)
        {
            return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().GRUPOS.ToList().Find(delegate(Modelo_Entidades.GRUPO oGrupoBuscdo) { return oGrupoBuscdo.GRU_CODIGO == codigo; });
        }

        /// <summary>
        /// Comprueba si el el grupo tiene alguna relación con perfiles o usuarios.
        /// </summary>
        /// <param name="oGrupo"></param>
        /// <returns>bool (fue usado = verdadero, no fue usado = falso)</returns>
        public bool ComprobarUso(Modelo_Entidades.GRUPO oGrupo)
        {
            Modelo_Entidades.GRUPO oGrupoAComprobar = Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().GRUPOS.ToList().Find(delegate(Modelo_Entidades.GRUPO oGrupoBuscado) { return oGrupoBuscado == oGrupo; });

            if (oGrupo.PERFILES.Count == 0 && oGrupo.USUARIOS.Count == 0)
            {
                return false;
            }
            else return true;
        }
        /// <summary>
        /// Guarda un nuevo grupo. Devuelve verdadero si no hubo errores.
        /// </summary>
        public bool Agregar(Modelo_Entidades.GRUPO oGRUPO)
        {

            Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().GRUPOS.AddObject(oGRUPO);
            int resultado = Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().SaveChanges();
            if (resultado != -1) return true;
            else return false;
        }

        /// <summary>
        /// Elimina un grupo. Devuelve verdadero si no hubo errores.
        /// </summary>
        public bool Eliminar(Modelo_Entidades.GRUPO oGRUPO)
        {
            Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().GRUPOS.DeleteObject(oGRUPO);
            int resultado = Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().SaveChanges();
            if (resultado != -1) return true;
            else return false;
        }

        /// <summary>
        /// Actualiza un grupo. Devuelve verdadero si no hubo errores.
        /// </summary>
        public bool Modificar(Modelo_Entidades.GRUPO oGRUPO)
        {
            Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().GRUPOS.ApplyCurrentValues(oGRUPO);
            int resultado = Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().SaveChanges();
            if (resultado != -1) return true;
            else return false;
        }
    }
}
