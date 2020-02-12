//using BusinessServices;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Security.Claims;
//using System.Security.Principal;
//using System.Threading;
//using System.Web;
//using System.Web.Http.Controllers;

//namespace Servicio.Filters
//{
//    public class ApiAuthenticationFilter : GenericAuthenticationFilter
//    { /// <summary>
//      /// Default Authentication Constructor
//      /// </summary>
//        public ApiAuthenticationFilter()
//        {
//        }

//        /// <summary>
//        /// AuthenticationFilter constructor with isActive parameter
//        /// </summary>
//        /// <param name="isActive"></param>
//        public ApiAuthenticationFilter(bool isActive)
//            : base(isActive)
//        {
//        }

//        /// <summary>
//        /// Protected overriden method for authorizing user
//        /// </summary>
//        /// <param name="username"></param>
//        /// <param name="password"></param>
//        /// <param name="actionContext"></param>
//        /// <returns></returns>
//        protected override bool OnAuthorizeUser(string username, string password, HttpActionContext actionContext)
//        {
//            var provider = actionContext.ControllerContext.Configuration
//                               .DependencyResolver.GetService(typeof(IUserService)) as IUserService;



//            if (provider != null)
//            {
//                var userId = provider.Authenticate(username, password);
//                //var users = provider.GetById(username, password);
//                if (userId > 0)
//                //if (user!=null)
//                {
//                    var basicAuthenticationIdentity = Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
//                    if (basicAuthenticationIdentity != null)
//                    {
//                        basicAuthenticationIdentity.UserId = userId;
//                        //basicAuthenticationIdentity.AddClaims(users.Claimers);
//                        //basicAuthenticationIdentity.UserId = user.UserId;
//                        //basicAuthenticationIdentity.AddClaims(user.Claims);
//                    }

//                    //ClaimsPrincipal cp = (ClaimsPrincipal)Thread.CurrentPrincipal;
//                    //cp.AddIdentities(user.Claims);
//                    //cp.AddIdentities(user.Claims);
//                    //Thread.CurrentPrincipal = cp;

//                    return true;
//                }
//            }
//            return false;
//        }

//        //public static DbContext Create(HttpActionContext actionContext)
//        //{
//        //    var provider = actionContext.ControllerContext.Configuration
//        //                       .DependencyResolver.GetService(typeof(IOwinSecurityService)) as IOwinSecurityService;
//        //    return provider.Create();

//        //}
//    }
//}