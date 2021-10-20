using System;
using System.Collections.Generic;
using Resolver.Enumerations;
using ServicioForms.Proxys;
using ServicioForms.ViewModels;


namespace ServicioForms.Controllers
{
    public class SubjectsController : IController<SubjectsVM>
    {
        BaseProxy<SubjectsVM> proxy = new SubjectsProxy();

        public void Create(SubjectsVM viewmodel)
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

        public void Delete(SubjectsVM viewmodel)
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

        public List<SubjectsVM> GetAll(string filters)
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

        public SubjectsVM GetOne(long id)
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

        public void Update(SubjectsVM viewmodel)
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
