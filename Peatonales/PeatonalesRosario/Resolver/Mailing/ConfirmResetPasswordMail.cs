using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GO.Fwk.Toolkits.Mailing
{
    public class ConfirmResetPasswordMail : IStateMail
    {
        #region Members
        private String[] usersMails;
        private String userName;
        private String pathRecov;
        #endregion

        #region Constructor
        public ConfirmResetPasswordMail(String userName, String pathrecov, params String[] usersMails)
        {
            this.userName = userName;
            this.pathRecov = pathrecov;
            this.usersMails = usersMails;
        }
        #endregion

        #region Basic Functions
        public String Body()
        {
            //return "Estimado: " +
            //        this.userName + ".\n Por medio del presente le pedimos que confirme la solicitud de cambio de clave solicitada al sistema." +
            //        "\n Si confirma, le enviaremos un nuevo email con la contraseña generada automaticamente por el sistema. Si usted no solicitó el cambio de contraseña ignore este mensaje. \n Confirme presionando Aquí " + this.pathRecov + 
            //        " \n Atentamente." +
            //        " \n Administrador del sistema";
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
				                    <br>Requerimos la confirmacion de su solicitud de cambio de su contraseña.
				                    <br>Al aceptar, le enviaremos un nuevo email con su nueva contraseña
				                    <br>generada automaticamente por el sistema.
				                    <br>
				                    <br>Si usted no solicitó un cambio de contraseña, le rogamos que ignore este mensaje.
				                    <br>Para confirmar, por favor haga click en el botón de abajo:
				                    <br>
			                    </div>

			                    <div style='text-align:left; margin-left:230px;'>
				                    <br>
				                    <a href='{1}'><img src='https://i.imgur.com/plCpQff.png'></a>
				                    <br>
			                    </div>


			                    <div style='text-align:left; margin-left:25px;'>
                                    Si no visualiza la imagen, por favor, <a href='{1}'>haga click aquí</a>
				                    <br>
				                    <br>Gracias.
				                    <br>Equipo ©PeatonUp.
			                    </div>
			
			                    <div style='text-align:left; margin-top:25px;'>
				                    <img src='http://i.imgur.com/zAZn9Lb.png'>
			                    </div>
		                    </div>

	                    </body>

                    </html>

                    ";
            String bodyToReturn = String.Format(body, this.userName, this.pathRecov);
            return bodyToReturn;
        }

        public String Subject()
        {
            return MailConfiguration.GetInstance().AppSettings["company_name"].ToString() + " - Solicitud de cambio de contraseña";
        }

        public String[] To()
        {
            return this.usersMails;
        }
        #endregion
    }
}
