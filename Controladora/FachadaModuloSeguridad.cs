﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class FachadaModuloSeguridad
    {
        private static FachadaModuloSeguridad Instancia;
        private Controladora.CCURPF oCCURPF;
        private Controladora.CCUGUsuarios oCCUGUsuarios;
        public static FachadaModuloSeguridad ObtenerInstancia()
        {
            if (Instancia == null) //|| Instancia.IsDisposed == true
                Instancia = new FachadaModuloSeguridad();
            return Instancia;
        }

        private FachadaModuloSeguridad()
        {
            oCCUGUsuarios = Controladora.CCUGUsuarios.ObtenerInstancia();
            oCCURPF = Controladora.CCURPF.ObtenerInstancia();
        }


        /// <summary>
        /// Llama al método Login de la controladora CCULogin.
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="clave"></param>
        /// <returns></returns>
        public Modelo_Entidades.USUARIO RealizarLogIn(string usuario, string clave)
        {
            return Controladora.CCULogin.ObtenerInstancia().login(usuario, clave);
        }

        /// <summary>
        /// Llama al método Login de la controladora CCULogOut.
        /// </summary>
        /// <param name="oUsuario"></param>
        /// <returns></returns>
        public bool RealizarLogOut(Modelo_Entidades.USUARIO oUsuario)
        {
            return Controladora.CCULogOut.ObtenerInstancia().LogOut(oUsuario);
        }

        public Modelo_Entidades.USUARIO ObtenerUsuario(string usuario, string e_mail)
        {
            return Controladora.CCURecuperarClave.ObtenerInstancia().obtenerUsuario(usuario, e_mail);
        }

        public bool ResetearClave(Modelo_Entidades.USUARIO oUsuario)
        {
            return oCCUGUsuarios.ResetearClave(oUsuario);
        }

        public List<Modelo_Entidades.PERFIL> recuperarPerfil(Modelo_Entidades.USUARIO oUsuario)
        {
            return Controladora.CCURPF.ObtenerInstancia().recuperarPerfil(oUsuario);
        }

        public List<Modelo_Entidades.MODULO> obtenerModulos()
        {
            return Controladora.CCURPF.ObtenerInstancia().obtenerModulos();
        }

        public List<Modelo_Entidades.PERFIL> recuperarPerfilForm(Modelo_Entidades.USUARIO oUsu, Modelo_Entidades.FORMULARIO oForm)
        {
            return Controladora.CCURPF.ObtenerInstancia().recuperarPerfilForm(oUsu, oForm);
        }

        public List<Modelo_Entidades.GRUPO> ObtenerGrupos(Modelo_Entidades.USUARIO oUsuario)
        {
            return oCCURPF.obtenerGruposUsuario(oUsuario);
        }

        public List<Modelo_Entidades.MODULO> ObtenerModulos(Modelo_Entidades.GRUPO oGrupo)
        {
            return oCCURPF.ObtenerModulosPorGrupo(oGrupo);
        }

        public List<Modelo_Entidades.FORMULARIO> ObtenerFormularios(Modelo_Entidades.MODULO oModulo)
        {
            return oCCURPF.ObtenerFormulariosPorModulo(oModulo);
        }

        public List<Modelo_Entidades.PERMISO> ObtenerPermisos(string codigo, string formulario)
        {
            return oCCURPF.ObtenerPermisosPorFormulario(codigo, formulario);
        }
        /*
        public List<Modelo_Entidades.MODULO> obtenerModulos(Modelo_Entidades.USUARIO oUsuario)
        {
            return Controladora.CCURPF.ObtenerInstancia().obtenerModulos(Modelo_Entidades.USUARIO oUsuario);
        }
        */
    }
}
