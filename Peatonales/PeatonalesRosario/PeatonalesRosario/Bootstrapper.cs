using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using System.Web.Http;
using BusinessServices;
//using DataModel.UnitOfWork;
using Resolver;
using BusinessServices.Interfaces;
using BusinessServices.Services;
//using BusinessServices.Interfaces;
//using BusinessServices.Services;
//using BusinessServices.Services.ReportAll;

namespace Servicio
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            System.Web.Mvc.DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        public static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();            
            //container.RegisterType<IBookServices, BookServices>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());
            #region Juan
            //container.RegisterType<ITestService, TestService>();
            //container.RegisterType<IReportActivitiesService, ReportActivitiesService>();
            container.RegisterType<ICareersServices, CareersServices>();
          //  container.RegisterType<ISubjectsServices, SubjectsServices>();














































            #endregion

            #region Develop1 = Leo
            //85
            //container.RegisterType<IItemServices, ItemServices>();













































            //132
            #endregion





            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {

            //Component initialization via MEF
            ComponentLoader.LoadContainer(container, ".\\bin", "Servicio.dll");
            ComponentLoader.LoadContainer(container, ".\\bin", "BusinessServices.dll");

        }
    }
}