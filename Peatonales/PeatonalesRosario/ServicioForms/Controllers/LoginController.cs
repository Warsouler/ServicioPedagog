using ServicioForms.General;
using ServicioForms.Proxys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioForms.Controllers
{
   public class LoginController
    {
        #region members
        private LoginProxy _proxy;


        #endregion

        #region properties
        private LoginProxy Proxy
        {
            get
            {
                if (_proxy == null)
                    _proxy = new LoginProxy();
                return _proxy;
            }

            set
            {
                _proxy = value;
            }
        }
        #endregion


        public async Task<string> Login(string username, string password)
        {

            var loginSuccess = await Proxy.PerformLoginActions(username, password);
            if (loginSuccess.Equals("ok"))
            {
                return "";
            }
            else if (loginSuccess.Contains("invalid_grant"))
            {
                return "El nombre de usuario y/o contraseña son incorrectos";
            }
            else if (loginSuccess.Contains("no_confirmed"))
            {
                return "Su cuenta no esta habilitada, confirme el registro desde su casilla de email";
            }
            return "Hubo un error, intentelo de nuevo";
        }
    }
}
