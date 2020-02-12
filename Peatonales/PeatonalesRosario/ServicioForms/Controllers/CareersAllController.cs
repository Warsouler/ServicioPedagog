using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicioForms.Proxys;
using ServicioForms.ViewModels;
using Resolver.Enumerations;

namespace ServicioForms.Controllers
{
    public class CareersAllController : IController<CareersVM>
    {
        BaseProxy<CareersVM> proxy = new CareersProxy();

        public void Create(CareersVM viewmodel)
        {
            try
            {
                proxy.Create(viewmodel);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Delete(CareersVM viewmodel)
        {
            try
            {
                viewmodel.state = (Int32)StatesEnum.Annulled;
                proxy.Delete(viewmodel);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<CareersVM> GetAll(string filters)
        {
            try
            {
                if(!String.IsNullOrEmpty(filters))
                filters = "?name=" + filters;
                return proxy.GetAll(filters).Result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public CareersVM GetOne(long id)
        {
            try
            {
               return proxy.Get(id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Update(CareersVM viewmodel)
        {
            try
            {
                proxy.Update(viewmodel);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
