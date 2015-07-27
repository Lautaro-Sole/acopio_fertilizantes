using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class CCULogin
    {
        private static CCULogin Instancia;
        public static CCULogin ObtenerInstancia()
        {
            if (Instancia == null) //|| Instancia.IsDisposed == true
                Instancia = new CCULogin();
            return Instancia;
        }

        //private CCULogin();

        private Modelo_Entidades.USUARIO oUsuario = new Modelo_Entidades.USUARIO();
        public Modelo_Entidades.USUARIO login(string usuario, string clave)
        {
            //buscar un usuario con el mismo login
            Modelo_Entidades.USUARIO oUsuarioEncontrado = Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().USUARIOS.ToList<Modelo_Entidades.USUARIO>().Find(delegate(Modelo_Entidades.USUARIO oUsuarioBuscado) { return oUsuarioBuscado.USU_CODIGO == usuario; });
            if (oUsuarioEncontrado != null)
            {
                if (oUsuarioEncontrado.USU_ESTADO == true)
                {
                    //oUsuario=oUsuarioEncontrado;
                    string clave_encriptada = this.encriptarValidar(clave);
                    //string clave_encriptada = clave.GetHashCode(System.Security.Cryptography.MD5)
                    // comparar el md5 obtenido con el guardado
                    if (oUsuarioEncontrado.USU_CLAVE == clave_encriptada)
                    {
                        //auditar el login

                        //crear el log
                        Modelo_Entidades.Log oLogin = new Modelo_Entidades.Log();
                        //asignarle los valores
                        oLogin.accion = "LOGIN";
                        oLogin.fecha_y_hora = System.DateTime.Now;
                        oLogin.USU_CODIGO = oUsuarioEncontrado.USU_CODIGO;
                        //guardarlo en la base de datos:
                        Modelo_Entidades.Modelo_Auditoria.ObtenerInstancia().Log_Historia.AddObject(oLogin);
                        int resultado = Modelo_Entidades.Modelo_Auditoria.ObtenerInstancia().SaveChanges();
                        if (resultado == -1)
                        {
                            throw new Exception("Error al registrar el login.");
                            //oUsuario.USU_CLAVE = clave;
                            //return oUsuario; //devuelvo el usuario con la clave ingresada
                        }
                        // entregar el usuario encontrado al formulario
                        return oUsuarioEncontrado;
                    }
                    else
                    {
                        throw new Exception("La contraseña ingresada es incorrecta");
                        //oUsuario.USU_CLAVE = clave;
                        //return oUsuario; //devuelvo el usuario con la clave ingresada
                    }
                }
                else
                {
                    throw new Exception("El usuario ingresado está deshabilitado");
                }
            }
            else
            {
                throw new Exception("El usuario ingresado no se encuentra registrado en el sistema");
                //return oUsuarioEncontrado; //devuelvo el usuario nulo
            }
        }
        private string encriptarValidar(string clave)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider encriptadorMD5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] data = encriptadorMD5.ComputeHash(Encoding.Default.GetBytes(clave));
            StringBuilder constructordecadena = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                constructordecadena.Append(data[i].ToString("x2"));

            }
            return constructordecadena.ToString();
        }

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

        public List<Modelo_Entidades.MODULO> obtenerModulos()
        {
            return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().MODULOS.ToList<Modelo_Entidades.MODULO>();
        }


    }
}