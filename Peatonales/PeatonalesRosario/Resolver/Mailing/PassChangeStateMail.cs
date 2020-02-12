#region Usings

using System;
using System.Configuration;
using GO.Fwk.Toolkits;

#endregion

namespace GO.Fwk.Toolkits.Mailing
{
    public class PassChangeStateMail : IStateMail
    {
        #region Members
        private String pathVerify;
        private String[] usersMails;
        private String username;
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
        public PassChangeStateMail(String randomLink, String username, params String[] usersMails)
        {
            this.pathVerify = randomLink;
            this.usersMails = usersMails;
            this.username = username;
        }
        #endregion

        #region Basic Functions
        public String Body()
        {
            //return "Estimado:" + this.username+
            //    "\nPara recuperar su contraseña haga click en el siguiente link:" +
            //       "\n" + this.pathVerify + "\nEsta operación puede tardar algunos minutos";
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
				                    <br>Hola {0}.
				                    <br>
				                    <br>Para recuperar tu contraseña, por favor hacé click en el botón de abajo:
				                    <br>
			                    </div>

			                    <div style='text-align:left; margin-left:230px;'>
				                    <br>
				                    <a href='{1}'><img src='https://i.imgur.com/plCpQff.png'></a>
				                    <br>
			                    </div>


			                    <div style='text-align:left; margin-left:25px;'>
                                    Si no visualizás la imágen, por favor, <a href='{1}'>hacé click aquí</a>
				                    <br>
				                    <br>Esto puede tomar algunos minutos, agradecemos tu paciencia.
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
            String bodyToReturn = String.Format(body, this.username, this.pathVerify);
            return bodyToReturn;

        }

        public String Subject()
        {
            return MailConfiguration.GetInstance().AppSettings["company_name"] + " - Recuperación de contraseña";
        }

        public String[] To()
        {
            return this.usersMails;
        }
        #endregion
    }
}
