using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace Controladora
{
	public class CCUGUsuarios
	{
		public List<Modelo_Entidades.USUARIO> ObtenerUsuarios()
		{
			return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().USUARIOS.ToList<Modelo_Entidades.USUARIO>();
		}

		public List<Modelo_Entidades.GRUPO> ObtenerGrupos()
		{
			return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().GRUPOS.ToList<Modelo_Entidades.GRUPO>();
		}

		public Modelo_Entidades.USUARIO ObtenerUsuario(string codigo_usuario)
		{
			return Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().USUARIOS.ToList<Modelo_Entidades.USUARIO>().Find(delegate(Modelo_Entidades.USUARIO unUsuario) { return unUsuario.USU_CODIGO == codigo_usuario; });
		}
		
		public List<Modelo_Entidades.USUARIO> ObtenerUsuarios(string nombre, string apellido, string grupo, string estado)
		{
			List<Modelo_Entidades.USUARIO> oListaUsuarios = Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().USUARIOS.ToList<Modelo_Entidades.USUARIO>();
			if (!(string.IsNullOrWhiteSpace(nombre)))
			{
				oListaUsuarios.FindAll(delegate(Modelo_Entidades.USUARIO oUsuarioBuscado) { return oUsuarioBuscado.USU_NOMBRE.StartsWith(nombre); });
			}
			if (!(string.IsNullOrWhiteSpace(apellido)))
			{
				oListaUsuarios.FindAll(delegate(Modelo_Entidades.USUARIO oUsuarioBuscado) { return oUsuarioBuscado.USU_APELLIDO.StartsWith(apellido); });
			}
			if (!(string.IsNullOrWhiteSpace(estado) || estado== "TODOS" ))
			{
				bool estadousuario;
				if (estado == "Activo")
				{
					estadousuario = true;
				}
				else
				{
					estadousuario = false;
				}
				oListaUsuarios.FindAll(delegate(Modelo_Entidades.USUARIO oUsuarioBuscado) { return oUsuarioBuscado.USU_ESTADO == estadousuario; });
			}
			if (!(string.IsNullOrWhiteSpace(grupo) || grupo =="TODOS"))
			{
				List<Modelo_Entidades.USUARIO> oListaUsuariosTemporal = new List<Modelo_Entidades.USUARIO>(); 
				foreach (Modelo_Entidades.USUARIO oUsuarioActual in oListaUsuarios)
				{
					Modelo_Entidades.GRUPO oGrupo = oUsuarioActual.GRUPOS.ToList<Modelo_Entidades.GRUPO>().Find(delegate(Modelo_Entidades.GRUPO oGrupoBuscado) { return oGrupoBuscado.GRU_DESCRIPCION.StartsWith(grupo); });
					if (oGrupo != null)
					{
						oListaUsuariosTemporal.Add(oUsuarioActual);
					}
				}
				oListaUsuarios.Clear();
				oListaUsuarios = oListaUsuariosTemporal;
			}

			return oListaUsuarios;

		}

		


		public bool Agregar(Modelo_Entidades.USUARIO oUSUARIO)
		{
			
			Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().USUARIOS.AddObject(oUSUARIO);
			int resultado = Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().SaveChanges();
			if (resultado != -1) 
			{
				bool resultadoreset = this.ResetearClave(oUSUARIO);
				if (resultadoreset)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else return false;


		}
		public bool Eliminar(Modelo_Entidades.USUARIO oUSUARIO)
		{
			Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().USUARIOS.DeleteObject(oUSUARIO);
			int resultado = Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().SaveChanges();
			if (resultado != -1) return true;
			else return false;
		}
		public bool Modificar(Modelo_Entidades.USUARIO oUSUARIO)
		{
			Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().USUARIOS.ApplyCurrentValues(oUSUARIO);
			int resultado = Modelo_Entidades.ModeloSeguridadContainer.ObtenerInstancia().SaveChanges();
			if (resultado != -1) return true;
			else return false;
		}

		/// <summary>
		/// Genera una contraseña al azar. 
		/// Caracteres es la cantidad de caracteres.
		/// minusculas es para indicar si se quieren generar todas minúsculas
		/// </summary>
		public string generarClaveAleatoria(int caracteres, bool minusculas)
		{
			StringBuilder constructor = new StringBuilder();
			Random numeroalazar = new Random(DateTime.Now.Millisecond); // generar con el milisegundo actual como semilla
			char caracter;
			for(int i=0; i<caracteres; i++)
			{
				caracter = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * numeroalazar.NextDouble() + 65)));
				constructor.Append(caracter);
			}
			if(minusculas)
			{
				return constructor.ToString().ToLower();
			}
			else
			{
				return constructor.ToString();
			} 
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

		public bool ResetearClave(Modelo_Entidades.USUARIO oUSUARIO) //generar una clave al azar para la creación del usuario
		{
			//generar una clave aleatoria
			oUSUARIO.USU_CLAVE = generarClaveAleatoria(8, false);
			//enviar la clave sin encriptar por mail
			
			string De="tc.prueba@gmail.com";
			string Password="732112.Na$a";
			string Para=oUSUARIO.USU_EMAIL;
			string Mensaje = "Bienvenido al sistema. Por favor descarguelo de http://www.mediafire.com/?y34c2yu26htau (Prueba.rar) y pruebe todo el módulo de seguridad, ejecutando el sql incluído y los dos de adentro del proyecto. Su nombre de usuario es " + oUSUARIO.USU_CODIGO + " y su clave temporal es " + oUSUARIO.USU_CLAVE + ". Por favor cambie su clave la primera vez que entre al sistema." + "Sólo faltan unos filtros que no los pude hacer porque no sabía cómo poner que en los combobox llenos con objetos diga 'TODOS'."; 
			string Asunto="Usuario y Contraseña para el sistema"; 
			System.Net.Mail.MailMessage Email; 

			Email = new System.Net.Mail.MailMessage(De, Para, Asunto, Mensaje); 
			/*
			System.Net.Mail.SmtpClient smtpMail = new System.Net.Mail.SmtpClient("smtp.gmail.com"); 
			Email.IsBodyHtml = false; 
			smtpMail.EnableSsl = true; 
			smtpMail.UseDefaultCredentials = false;
			smtpMail.Host = "smtp.gmail.com";
			smtpMail.Port = ; 
			smtpMail.Credentials = new System.Net.NetworkCredential(De, Password); 
			//smtpMail.ClientCertificates. 
			SmtpClient clienteSmtp = new SmtpClient("WIN02");
			 * */
			/*
			 * Cliente SMTP
			 * Gmail:  smtp.gmail.com  puerto:587
			 * Hotmail: smtp.liva.com  puerto:25
			 */
			SmtpClient server = new SmtpClient("smtp.gmail.com", 587);
			/*
			* Autenticacion en el Servidor
			* Utilizaremos nuestra cuenta de correo
			*
			* Direccion de Correo (Gmail o Hotmail)
			* y Contrasena correspondiente
			*/
			server.Credentials = new System.Net.NetworkCredential(De, Password);
			server.EnableSsl = true;
 


			server.Send(Email); 
			
			//obtener el hash md5 de la clave generada
			string clave_temporal = oUSUARIO.USU_CLAVE;
			oUSUARIO.USU_CLAVE = EncriptarClave(clave_temporal);
			//guardar el cambio 
			bool resultado = Modificar(oUSUARIO);
			if (resultado) return true;
			else return false;
		}
		public bool CambiarClave(Modelo_Entidades.USUARIO oUsuario, string clave)
		{
			string clave_encriptada = EncriptarClave(clave);
			oUsuario.USU_CLAVE = clave_encriptada;
			bool resultado = Modificar(oUsuario);
			if (resultado) return true;
			else return false;
		}
		public bool RegenerarClave(Modelo_Entidades.USUARIO oUsuario) //volver a generar una clave al azar, para la petición cuando se la pierde
		{
			bool resultado = ResetearClave(oUsuario);
			if (resultado) return true;
			else return false;
		}

        public bool ComprobarRelaciones(string codigo_usuario)
        {
            //buscar en el catálogo de trabajo y el de auditoría si alguna de las operaciones fue hecha o modificada por el usuario
            Modelo_Entidades.Operacion oOperacionEncontrada = Modelo_Entidades.Acopio_FertilizantesEntities.ObtenerInstancia().CatOperaciones.ToList<Modelo_Entidades.Operacion>().Find(delegate(Modelo_Entidades.Operacion oOperacionBuscada){return oOperacionBuscada.USU_CODIGO==codigo_usuario;});
            Modelo_Entidades.Operacion_Auditoria oOperacion_AuditoriaEncontrada = Modelo_Entidades.Modelo_AuditoriaEntities2.ObtenerInstancia().CatOperaciones_Auditoria.ToList<Modelo_Entidades.Operacion_Auditoria>().Find(delegate(Modelo_Entidades.Operacion_Auditoria oOperacionBuscada){return oOperacionBuscada.USU_CODIGO==codigo_usuario;});

            if ((oOperacionEncontrada != null) || (oOperacion_AuditoriaEncontrada != null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
	}
}
