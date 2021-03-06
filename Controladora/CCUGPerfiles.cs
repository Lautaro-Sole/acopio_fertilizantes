﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class CCUGPerfiles
    {
        public List<Modelo_Entidades.PERFIL> obtenerPerfiles()
        {
            return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().PERFILES.ToList<Modelo_Entidades.PERFIL>();
        }
        private static CCUGPerfiles oInstancia;
        public static CCUGPerfiles ObtenerInstancia()
    {
        if (oInstancia==null) oInstancia= new CCUGPerfiles();
            return oInstancia;
    }
        /// <summary>
        /// Obtener perfiles por grupo
        /// </summary>
        /// <param name="oGrupo"></param>
        /// <returns></returns>
        public List<Modelo_Entidades.PERFIL> obtenerPerfiles(Modelo_Entidades.GRUPO oGrupo)
        {
            return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().PERFILES.ToList<Modelo_Entidades.PERFIL>().FindAll(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return oPerfilBuscado.GRU_CODIGO == oGrupo.GRU_CODIGO; });
        }

        /// <summary>
        /// Obtener Perfiles por grupo y formulario
        /// </summary>
        /// <param name="oGrupo"></param>
        /// <param name="oFormulario"></param>
        /// <returns></returns>
        public List<Modelo_Entidades.PERFIL> obtenerPerfiles(Modelo_Entidades.GRUPO oGrupo, Modelo_Entidades.FORMULARIO oFormulario)
        {
            return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().PERFILES.ToList<Modelo_Entidades.PERFIL>().FindAll(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return (oPerfilBuscado.GRU_CODIGO == oGrupo.GRU_CODIGO)&&(oPerfilBuscado.FRM_CODIGO == oFormulario.FRM_CODIGO); });
        }

        /// <summary>
        /// Obtener Perfiles por grupo y permiso
        /// </summary>
        /// <param name="oGrupo"></param>
        /// <param name="oFormulario"></param>
        /// <returns></returns>
        public List<Modelo_Entidades.PERFIL> obtenerPerfiles(Modelo_Entidades.GRUPO oGrupo, Modelo_Entidades.PERMISO oPermiso)
        {
            return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().PERFILES.ToList<Modelo_Entidades.PERFIL>().FindAll(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return (oPerfilBuscado.GRU_CODIGO == oGrupo.GRU_CODIGO) & (oPerfilBuscado.PER_CODIGO == oPermiso.PER_CODIGO); });
        }

        /// <summary>
        /// Obtener Perfiles por grupo y formulario y permiso
        /// </summary>
        /// <param name="oGrupo"></param>
        /// <param name="oFormulario"></param>
        /// <returns></returns>
        public List<Modelo_Entidades.PERFIL> obtenerPerfiles(Modelo_Entidades.GRUPO oGrupo, Modelo_Entidades.FORMULARIO oFormulario, Modelo_Entidades.PERMISO oPermiso)
        {
            return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().PERFILES.ToList<Modelo_Entidades.PERFIL>().FindAll(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return (oPerfilBuscado.GRU_CODIGO == oGrupo.GRU_CODIGO) & (oPerfilBuscado.FRM_CODIGO == oFormulario.FRM_CODIGO) & (oPerfilBuscado.PER_CODIGO == oPermiso.PER_CODIGO); });
        }

        /// <summary>
        /// Obtener Perfiles por formulario y permiso
        /// </summary>
        /// <param name="oGrupo"></param>
        /// <param name="oFormulario"></param>
        /// <returns></returns>
        public List<Modelo_Entidades.PERFIL> obtenerPerfiles(Modelo_Entidades.FORMULARIO oFormulario, Modelo_Entidades.PERMISO oPermiso)
        {
            return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().PERFILES.ToList<Modelo_Entidades.PERFIL>().FindAll(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return (oPerfilBuscado.FRM_CODIGO == oFormulario.FRM_CODIGO) & (oPerfilBuscado.PER_CODIGO == oPermiso.PER_CODIGO); });
        }

        /// <summary>
        /// Obtener Perfiles por permiso
        /// </summary>
        /// <param name="oGrupo"></param>
        /// <param name="oFormulario"></param>
        /// <returns></returns>
        public List<Modelo_Entidades.PERFIL> obtenerPerfiles(Modelo_Entidades.PERMISO oPermiso)
        {
            return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().PERFILES.ToList<Modelo_Entidades.PERFIL>().FindAll(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return (oPerfilBuscado.PER_CODIGO == oPermiso.PER_CODIGO); });
        }

        /// <summary>
        /// Obtener Perfiles por formulario
        /// </summary>
        /// <param name="oGrupo"></param>
        /// <param name="oFormulario"></param>
        /// <returns></returns>
        public List<Modelo_Entidades.PERFIL> obtenerPerfiles(Modelo_Entidades.FORMULARIO oFormulario)
        {
            return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().PERFILES.ToList<Modelo_Entidades.PERFIL>().FindAll(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return (oPerfilBuscado.FRM_CODIGO == oFormulario.FRM_CODIGO); });
        }

        /// <summary>
        /// Obtener Perfiles por formulario y grupo y permiso
        /// </summary>
        /// <param name="oGrupo"></param>
        /// <param name="oFormulario"></param>
        /// <returns></returns>
        public List<Modelo_Entidades.PERFIL> obtenerPerfiles(Modelo_Entidades.FORMULARIO oFormulario, Modelo_Entidades.GRUPO oGrupo, Modelo_Entidades.PERMISO oPermiso)
        {
            return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().PERFILES.ToList<Modelo_Entidades.PERFIL>().FindAll(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return (oPerfilBuscado.GRU_CODIGO == oGrupo.GRU_CODIGO) & (oPerfilBuscado.FRM_CODIGO == oFormulario.FRM_CODIGO) & (oPerfilBuscado.PER_CODIGO == oPermiso.PER_CODIGO); });
        }

        /// <summary>
        /// Obtener Perfiles por formulario y grupo
        /// </summary>
        /// <param name="oGrupo"></param>
        /// <param name="oFormulario"></param>
        /// <returns></returns>
        public List<Modelo_Entidades.PERFIL> obtenerPerfiles(Modelo_Entidades.FORMULARIO oFormulario, Modelo_Entidades.GRUPO oGrupo)
        {
            return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().PERFILES.ToList<Modelo_Entidades.PERFIL>().FindAll(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return (oPerfilBuscado.GRU_CODIGO == oGrupo.GRU_CODIGO) & (oPerfilBuscado.FRM_CODIGO == oFormulario.FRM_CODIGO); });
        }

        public List<Modelo_Entidades.PERFIL> obtenerPerfiles(string grupo, string formulario, string permiso)
        {
            var Consulta = from oPerfil in Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().PERFILES.ToList()
                           select oPerfil;

            if (grupo != "0")
            {
                Consulta = Consulta.Where(oPerfil => oPerfil.GRUPOS.GRU_DESCRIPCION == grupo);
            }

            if (formulario != "0")
            {
                Consulta = Consulta.Where(oPerfil => oPerfil.FORMULARIOS.FRM_DESCRIPCION == formulario);
            }

            if (permiso != "0")
            {
                Consulta = Consulta.Where(oPerfil => oPerfil.PERMISOS.PER_DESCRIPCION == permiso);
            }

            return (List<Modelo_Entidades.PERFIL>)Consulta.ToList();
        }


        public List<Modelo_Entidades.FORMULARIO> obtenerFormularios()
        {
            return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().FORMULARIOS.ToList<Modelo_Entidades.FORMULARIO>();
        }

        public List<Modelo_Entidades.GRUPO> obtenerGrupos()
        {
            return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().GRUPOS.ToList<Modelo_Entidades.GRUPO>();
        }

        
        public List<Modelo_Entidades.PERMISO> obtenerPermisos()
        {
            return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().PERMISOS.ToList<Modelo_Entidades.PERMISO>();
        }

        /// <summary>
        /// Devuelve true si ya existe un perfil con ese código de grupo, formulario y permiso.
        /// </summary>
        public bool ValidarPerfil(Modelo_Entidades.PERFIL oPerfil)
        {
            Modelo_Entidades.PERFIL oPerfilEncontrado = Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().PERFILES.ToList<Modelo_Entidades.PERFIL>().Find(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return (oPerfilBuscado.FRM_CODIGO == oPerfil.FRM_CODIGO) & (oPerfilBuscado.GRU_CODIGO == oPerfil.GRU_CODIGO) & (oPerfilBuscado.PER_CODIGO == oPerfil.PER_CODIGO); });
            if (oPerfilEncontrado != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidarPerfil(Modelo_Entidades.GRUPO oGrupo, Modelo_Entidades.PERMISO oPermiso, Modelo_Entidades.FORMULARIO oFormulario)
        {
            Modelo_Entidades.PERFIL oPerfilEncontrado = Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().PERFILES.ToList<Modelo_Entidades.PERFIL>().Find(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return (oPerfilBuscado.FORMULARIOS == oFormulario) & (oPerfilBuscado.GRUPOS == oGrupo) & (oPerfilBuscado.PERMISOS == oPermiso); });
            if (oPerfilEncontrado != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Modelo_Entidades.PERFIL ObtenerPerfil(int perfil)
        {
            Modelo_Entidades.PERFIL oPerfil = Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().PERFILES.ToList().Find(delegate(Modelo_Entidades.PERFIL fPerfil)
            {
                return fPerfil.PRF_CODIGO == perfil;
            });

            return oPerfil;
        }

        public bool Agregar(Modelo_Entidades.PERFIL oPerfil)
        {

            Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().PERFILES.AddObject(oPerfil);
            int resultado = Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().SaveChanges();
            if (resultado != -1) return true;
            else return false;


        }
        public bool Eliminar(Modelo_Entidades.PERFIL oPerfil)
        {
            Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().PERFILES.DeleteObject(oPerfil);
            int resultado = Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().SaveChanges();
            if (resultado != -1) return true;
            else return false;
        }
        public bool Modificacion(Modelo_Entidades.PERFIL oPerfil)
        {
            Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().PERFILES.ApplyCurrentValues(oPerfil);
            int resultado = Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().SaveChanges();
            if (resultado != -1) return true;
            else return false;
        }



    }
}
