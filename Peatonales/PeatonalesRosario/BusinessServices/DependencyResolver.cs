using System;
using System.ComponentModel.Composition;
using DataModel;
using DataModel.UnitOfWork;
using Resolver;
using BusinessServices.Interfaces;
using BusinessServices.Services;
//using BusinessServices.Interfaces;
//using BusinessServices.Services;

namespace BusinessServices
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            //registerComponent.RegisterType<IBookServices, BookServices>();
            //registerComponent.RegisterType<IUserService, UserServices>();
            //registerComponent.RegisterType<ITokenService, TokenServices>();
            registerComponent.RegisterType<IOwinSecurityService, OwinSecurityServer>();

            #region Juan
            //registerComponent.RegisterType<IAuthorServices, AuthorServices>();
            //registerComponent.RegisterType<IPeatonUserServices, PeatonUserServices>();
            //registerComponent.RegisterType<IBusinessServices, BusinessServices.Services.BusinessServices>();
            //registerComponent.RegisterType<ITestService, BusinessServices.Services.TestService>();
            //registerComponent.RegisterType<IReportPrizeService, BusinessServices.Services.ReportPrizeService>();
            registerComponent.RegisterType<ICyclesServices, CyclesServices>();
            registerComponent.RegisterType<ICareersServices, CareersServices>();
            registerComponent.RegisterType<ISubjectsServices, SubjectsServices>();













































            #endregion

            #region Develop1 = Leo
            //76



































            //124
            #endregion


        }
    }
}
