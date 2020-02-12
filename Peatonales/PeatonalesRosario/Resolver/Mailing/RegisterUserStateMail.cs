#region Usings

using GO.Fwk.Toolkits.Cryptography;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace GO.Fwk.Toolkits.Mailing
{
    public class RegisterUserStateMail : IStateMail
    {
        #region Members
        private String fullName;
        private String userName;
        private String userPass;
        private String pathVerify;
        private String[] usersMails;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="fullName">Nombre Completo del usuario</param>
        /// <param name="userName">Nombre de cuenta del usuario</param>
        /// <param name="userPass">contraseña de la cuenta</param>
        /// <param name="randomLink">Link aleatorio de verificacion (class RandomLink)</param>
        /// <param name="userMail">Mail del usuario</param>
        public RegisterUserStateMail(String fullName, String userName, String randomLink, String userPass, params String[] usersMails)
        {
            this.fullName = fullName;
            this.userName = userName;
            this.userPass = userPass;
            this.pathVerify = randomLink;
            this.usersMails = usersMails;
        }
        #endregion

        #region Basic Functions
        public String Body()
        {
            /*return "Estimado " + this.fullName + ": \nPor medio del presente le damos la bienvenida a la plataforma" +
                   " ®PeatonUp y le informamos que debe confirmar su cuenta haciendo click en el siguiente link: " +
                   "\n" + this.pathVerify + "\nUna vez que haya confirmado, los datos para ingresar son:" +
                   "\n - Usuario: " + this.userName + " \n - Clave de acceso: " + this.userPass + "\n ";*/
            String body = @"

                    <html>
	                    <head>

	                    </head>

	                    <body style='width:600px;'>

		                    <div>
			                    <div>
				                    <img src='http://i.imgur.com/MFynzbw.png'>
				                    <br>
			                    </div>

			                    <div style='text-align:left; margin-left:25px; margin-top:10px'>
				                    <br>Bienvenido {0}.
				                    <br>
				                    <br>Gracias por registrarte en <b>PeatonUp©</b>.
				                    <br>Para continuar, por favor confirmá tu cuenta haciendo click en el botón de abajo:
				                    <br>
			                    </div>

			                    <div style='text-align:left; margin-left:230px;'>
				                    <br>
				                    <a href='{3}'><img src='http://i.imgur.com/MNrJ1aj.png'></a>
				                    <br>
			                    </div>


			                    <div style='text-align:left; margin-left:25px;'>
                                    Si no visualizás la imágen, por favor, <a href='{3}'>hacé click aquí</a>
				                    <br>
				                    <br>Una vez  que confirmes la cuenta podés inciar sesión con tus datos: 
				                    <br>- Usuario: {1}
				                    <br>- Clave de acceso: {2}
				                    <br>
				                    <br>Gracias.
				                    <br>Equipo <b>PeatonUp©</b>.
			                    </div>
			
			                    <div style='text-align:left; margin-top:25px;'>
				                    <img src='http://i.imgur.com/zAZn9Lb.png'>
			                    </div>
		                    </div>

	                    </body>

                    </html>

                    ";
            String bodyToReturn = String.Format(body, this.fullName, this.userName, this.userPass, this.pathVerify);
            return bodyToReturn;
        }

        public String Subject()
        {
            //return MailConfiguration.GetInstance().AppSettings["company_name"] + " - Registro de Usuario";
            return MailConfiguration.GetInstance().AppSettings["company_name"] + " - Validación de cuenta";
        }

        public String[] To()
        {
            return this.usersMails;
        }
        #endregion
    }
}
