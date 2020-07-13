using Exceptions;
using ServicioForms.Proxys;
using ServicioForms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioForms.Controllers
{
    public class CareersController
    {
        #region members
        private CareersProxy _proxy;


        #endregion

        #region properties
        private CareersProxy Proxy
        {
            get
            {
                if (_proxy == null)
                    _proxy = new CareersProxy();
                return _proxy;
            }

            set
            {
                _proxy = value;
            }
        }
        #endregion


        public void Create(CareersVM viewmodel)
        {
            try
            {
                Proxy.Create(viewmodel);
            }
            catch (Exception ex)
            {
                CompositeFillErrors cfe = HandlerClientExceptions.GetInstance().RunCustomExceptions(ex);
                if (cfe != null)
                    throw ex;
            }
        }
    }
}
