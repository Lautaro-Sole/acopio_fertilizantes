using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class CCUCClave
    {

        public bool cambiarClave(string claveActual, string claveNueva, Modelo_Entidades.USUARIO oUsu)
        {
            string clave = oUsu.USU_CLAVE;
            claveActual = EncriptarClave(claveActual);
            if (clave == claveActual)
            {
                claveNueva = EncriptarClave(claveNueva);
                oUsu.USU_CLAVE = claveNueva;
                CCUGUsuarios oCCUGUsuarios = new CCUGUsuarios();
                bool resultado = oCCUGUsuarios.Modificar(oUsu);
                if (resultado)
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        public string EncriptarClave(string clave)
        {
            //md5 da 32 caracteres
            //sha-1 da 40
            //string clave_encriptada = Convert.ToString(System.Security.Cryptography.MD5.Create(clave));
            //clave_encriptada = Convert.ToString(System.Security.Cryptography.SHA1CryptoServiceProvider.Create(clave));

            System.Security.Cryptography.MD5CryptoServiceProvider encriptadorMD5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] data = encriptadorMD5.ComputeHash(Encoding.Default.GetBytes(clave));
            StringBuilder constructordecadena = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                constructordecadena.Append(data[i].ToString("x2"));

            }
            return constructordecadena.ToString();
        }
    }
}
