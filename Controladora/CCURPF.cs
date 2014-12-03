using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class CCURPF
    {
        private static CCURPF Instancia;
        public static CCURPF ObtenerInstancia()
        {
            if (Instancia == null) //|| Instancia.IsDisposed == true
                Instancia = new CCURPF();
            return Instancia;
        }

        //private CCURPF();

        public List<Modelo_Entidades.PERFIL> recuperarPerfil(Modelo_Entidades.USUARIO oUsu)
        {
            CCUGPerfiles oCCUGPerfiles = new CCUGPerfiles();
            List<Modelo_Entidades.PERFIL> collPerfilesObtenidos = new List<Modelo_Entidades.PERFIL>();
            foreach (Modelo_Entidades.GRUPO oGrupo in oUsu.GRUPOS)
            {
                List<Modelo_Entidades.PERFIL> collPerfiles = new List<Modelo_Entidades.PERFIL>();
                collPerfiles = oCCUGPerfiles.obtenerPerfiles(oGrupo);
                foreach (Modelo_Entidades.PERFIL oPerfil in collPerfiles)
                {

                    if (collPerfilesObtenidos.Find(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return oPerfilBuscado == oPerfil; }) == null)
                    {
                        collPerfilesObtenidos.Add(oPerfil);
                    }
                }
            }
            return collPerfilesObtenidos;
        }

        public List<Modelo_Entidades.PERFIL> recuperarPerfilForm(Modelo_Entidades.USUARIO oUsu, Modelo_Entidades.FORMULARIO oForm)
        {
            CCUGPerfiles oCCUGPerfiles = new CCUGPerfiles();
            List<Modelo_Entidades.PERFIL> collPerfilesObtenidos = new List<Modelo_Entidades.PERFIL>();//
            foreach (Modelo_Entidades.GRUPO oGrupo in oUsu.GRUPOS)
            {
                List<Modelo_Entidades.PERFIL> collPerfiles = new List<Modelo_Entidades.PERFIL>();
                collPerfiles = oCCUGPerfiles.obtenerPerfiles(oGrupo, oForm);
                foreach (Modelo_Entidades.PERFIL oPerfil in collPerfiles)
                {
                    
                    if (collPerfilesObtenidos.Find(delegate(Modelo_Entidades.PERFIL oPerfilBuscado){return oPerfilBuscado==oPerfil;})==null)
                    {
                        collPerfilesObtenidos.Add(oPerfil);
                    }
                }
            }
            return collPerfilesObtenidos;
        }

        public Modelo_Entidades.FORMULARIO obtenerFormulario(string frm_formulario)
        {
            return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().FORMULARIOS.ToList<Modelo_Entidades.FORMULARIO>().Find(delegate(Modelo_Entidades.FORMULARIO oFormBuscado) { return oFormBuscado.FRM_FORMULARIO == frm_formulario; });
        }

        public Modelo_Entidades.FORMULARIO obtenerFormulariopordesc(string descripcion)
        {
            return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().FORMULARIOS.ToList<Modelo_Entidades.FORMULARIO>().Find(delegate(Modelo_Entidades.FORMULARIO oFormBuscado) { return oFormBuscado.FRM_DESCRIPCION == descripcion; });
        }
        public List<Modelo_Entidades.MODULO> obtenerModulos()
        {
            return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().MODULOS.ToList<Modelo_Entidades.MODULO>();
        }
        
        //public List<Modelo_Entidades.MODULO> obtenerModulosGrupo(Modelo_Entidades.GRUPO oGrupo)
        //{
        //    List<Modelo_Entidades.MODULO> oListaModulosGrupo = new List<Modelo_Entidades.MODULO>();
            


        //    return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().MODULOS.ToList<Modelo_Entidades.MODULO>().FindAll(delegate(Modelo_Entidades.MODULO oModuloActual){ return oModuloActual.FORMULARIOS}
        //}
        
        /// <summary>
        /// Busca la lista de formularios del módulo indicado a la que el usuario tiene acceso.
        /// </summary>
        /// <param name="Cod_Usuario"></param>
        /// <param name="Cod_Modulo"></param>
        /// <returns>Lista de formularios</returns>
        public List<Modelo_Entidades.FORMULARIO> obtenerFormularios(string Cod_Usuario, string Cod_Modulo)
        {
            //creo la lista de formularios que voy a devolver
            List<Modelo_Entidades.FORMULARIO> Lista_Formularios_Modulo_Usuario= new List<Modelo_Entidades.FORMULARIO>();
            //obtengo la lista de formularios del módulo.
            List<Modelo_Entidades.FORMULARIO> Lista_Formularios_Modulo=  Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().FORMULARIOS.ToList<Modelo_Entidades.FORMULARIO>().FindAll(delegate(Modelo_Entidades.FORMULARIO oFormBuscado) { return oFormBuscado.FRM_MODULO == Cod_Modulo; });
            //obtener el usuario
            Modelo_Entidades.USUARIO oUsuario = Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().USUARIOS.ToList<Modelo_Entidades.USUARIO>().Find(delegate(Modelo_Entidades.USUARIO oUsuarioBuscado){return oUsuarioBuscado.USU_CODIGO==Cod_Usuario;});
            //obtengo la lista de grupos a los que pertenece el usuario
            List<Modelo_Entidades.GRUPO> Lista_Grupos_Usuario = oUsuario.GRUPOS.ToList<Modelo_Entidades.GRUPO>();
                
            // obtengo todos los perfiles asociados a cada formulario y cada grupo

            //recorro los formularios del módulo
            foreach (Modelo_Entidades.FORMULARIO oFormulario in Lista_Formularios_Modulo)
            {
                //recorro los grupos del usuario
                foreach (Modelo_Entidades.GRUPO oGrupo in Lista_Grupos_Usuario)
                {
                    // debería alcanzarme con un único perfil para esto, por eso comento la siguiente línea
                    //List<Modelo_Entidades.PERFIL> Lista_Perfiles = Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().PERFILES.ToList<Modelo_Entidades.PERFIL>().FindAll(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return (oPerfilBuscado.FRM_CODIGO == oFormulario.FRM_CODIGO)&(oPerfilBuscado.GRU_CODIGO==oGrupo.GRU_CODIGO); });
                    
                    //busco al menos un perfil para ese formulario y ese grupo
                    Modelo_Entidades.PERFIL oPerfil = Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().PERFILES.ToList<Modelo_Entidades.PERFIL>().Find(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return (oPerfilBuscado.FRM_CODIGO == oFormulario.FRM_CODIGO) & (oPerfilBuscado.GRU_CODIGO == oGrupo.GRU_CODIGO); });
                    //si hay al menos un perfil que cumple los requisitos
                    if (oPerfil != null)
                    {
                        //compruebo que el formulario no haya sido agregado a la lista 
                        if (Lista_Formularios_Modulo_Usuario.Find(delegate(Modelo_Entidades.FORMULARIO oFormularioBuscado){return oFormularioBuscado.FRM_CODIGO == oFormulario.FRM_CODIGO;})==null)
                        {
                            Lista_Formularios_Modulo_Usuario.Add(oFormulario); //y lo agrego a la lista
                        }

                    }
                    
                }
            }
            //finalmente devuelvo la lista
            return Lista_Formularios_Modulo_Usuario;
        }
        public List<Modelo_Entidades.FORMULARIO> obtenerFormularios()
        {
            return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().FORMULARIOS.ToList<Modelo_Entidades.FORMULARIO>();
        }

        public List<Modelo_Entidades.GRUPO> obtenerGruposUsuario(Modelo_Entidades.USUARIO oUsuario)
        {
            List<Modelo_Entidades.GRUPO> Lista_Grupos_Usuario = oUsuario.GRUPOS.ToList<Modelo_Entidades.GRUPO>();
            return Lista_Grupos_Usuario;
        }

        public List<Modelo_Entidades.GRUPO> obtenerGruposUsuario(string id_usuario)
        {
            Modelo_Entidades.USUARIO oUsuario = Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().USUARIOS.ToList().Find(delegate(Modelo_Entidades.USUARIO oUsuarioBuscado) { return oUsuarioBuscado.USU_CODIGO == id_usuario; });
            return oUsuario.GRUPOS.ToList<Modelo_Entidades.GRUPO>();
        }

        public Modelo_Entidades.PERFIL ObtenerPerfil(int perfil)
        {
            Modelo_Entidades.PERFIL oPerfil = Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().PERFILES.ToList<Modelo_Entidades.PERFIL>().Find(delegate(Modelo_Entidades.PERFIL fPerfil)
            {
                return fPerfil.PRF_CODIGO == perfil;
            });

            return oPerfil;
        }

        public Modelo_Entidades.PERMISO ObtenerPermiso(string descripcion)
        {
            return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().PERMISOS.ToList<Modelo_Entidades.PERMISO>().Find(delegate(Modelo_Entidades.PERMISO oPermisoBuscado) { return oPermisoBuscado.PER_DESCRIPCION == descripcion; });
        }

        public List<Modelo_Entidades.PERMISO> ObtenerPermisos()
        {
           return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().PERMISOS.ToList<Modelo_Entidades.PERMISO>();

        }

        public List<Modelo_Entidades.PERMISO> ObtenerPermisosPorFormulario(string id_grupo, string form)
        {
            Modelo_Entidades.GRUPO oGrupo = Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().GRUPOS.ToList().Find(delegate(Modelo_Entidades.GRUPO oGrupoBuscado) { return oGrupoBuscado.GRU_CODIGO == id_grupo; });
            Modelo_Entidades.FORMULARIO oFormulario = Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().FORMULARIOS.ToList().Find(delegate(Modelo_Entidades.FORMULARIO oFormularioBuscado) { return oFormularioBuscado.FRM_FORMULARIO == form; });
            List<Modelo_Entidades.PERFIL> oListaPerfiles = Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().PERFILES.ToList().FindAll(delegate(Modelo_Entidades.PERFIL oPerfilBuscado) { return oPerfilBuscado.FORMULARIOS == oFormulario && oPerfilBuscado.GRUPOS == oGrupo; });
            List<Modelo_Entidades.PERMISO> oListaPermisos = new List<Modelo_Entidades.PERMISO>();
            foreach (Modelo_Entidades.PERFIL oPerfilActual in oListaPerfiles)
            {
                if (oListaPermisos.Contains(oPerfilActual.PERMISOS) == false)
                    oListaPermisos.Add(oPerfilActual.PERMISOS);
            }
            return oListaPermisos;
        }
    }
}

