﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Security.Claims;
//using System.Security.Principal;
//using System.Text;
//using System.Threading;
//using System.Web;
//using System.Web.Http.Controllers;
//using System.Web.Http.Filters;

//namespace Servicio.Filters
//{
//    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
//    public class GenericAuthenticationFilter : AuthorizationFilterAttribute
//    {
//        public GenericAuthenticationFilter()
//        {
//        }

//        private readonly bool _isActive = true;

//        /// <summary>
//        /// parameter isActive explicitly enables/disables this filetr.
//        /// </summary>
//        /// <param name="isActive"></param>
//        public GenericAuthenticationFilter(bool isActive)
//        {
//            _isActive = isActive;
//        }

//        /// <summary>
//        /// Checks basic authentication request
//        /// </summary>
//        /// <param name="filterContext"></param>
//        public override void OnAuthorization(HttpActionContext filterContext)
//        {
//            if (!_isActive) return;
//            var identity = FetchAuthHeader(filterContext);
//            if (identity == null)
//            {
//                ChallengeAuthRequest(filterContext);
//                return;
//            }

//            //var provider = filterContext.ControllerContext.Configuration
//            //                   .DependencyResolver.GetService(typeof(BusinessServices.IUserService)) as BusinessServices.IUserService;

//            var genericPrincipal = new GenericPrincipal(identity, null);

//            Thread.CurrentPrincipal = genericPrincipal;
//            //var user = provider.GetById("Juani", "MySuperPassword!");
//            //ClaimsPrincipal cp = new ClaimsPrincipal(user.Claims);
//            //cp.AddIdentity
//            //Thread.CurrentPrincipal = cp;
//            if (!OnAuthorizeUser(identity.Name, identity.Password, filterContext))
//            {
//                ChallengeAuthRequest(filterContext);
//                return;
//            }
//            base.OnAuthorization(filterContext);
//        }

//        /// <summary>
//        /// Virtual method.Can be overriden with the custom Authorization.
//        /// </summary>
//        /// <param name="user"></param>
//        /// <param name="pass"></param>
//        /// <param name="filterContext"></param>
//        /// <returns></returns>
//        protected virtual bool OnAuthorizeUser(string user, string pass, HttpActionContext filterContext)
//        {
//            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
//                return false;
//            return true;
//        }

//        /// <summary>
//        /// Checks for autrhorization header in the request and parses it, creates user credentials and returns as BasicAuthenticationIdentity
//        /// </summary>
//        /// <param name="filterContext"></param>
//        protected virtual BasicAuthenticationIdentity FetchAuthHeader(HttpActionContext filterContext)
//        {
//            string authHeaderValue = null;
//            var authRequest = filterContext.Request.Headers.Authorization;
//            if (authRequest != null && !String.IsNullOrEmpty(authRequest.Scheme) && authRequest.Scheme == "Basic")
//                authHeaderValue = authRequest.Parameter;
//            if (string.IsNullOrEmpty(authHeaderValue))
//                return null;
//            authHeaderValue = Encoding.Default.GetString(Convert.FromBase64String(authHeaderValue));
//            var credentials = authHeaderValue.Split(':');

//            var provider = filterContext.ControllerContext.Configuration
//                               .DependencyResolver.GetService(typeof(BusinessServices.IUserService)) as BusinessServices.IUserService;


//            return credentials.Length < 2 ? null : new BasicAuthenticationIdentity(credentials[0], credentials[1]);

//            //return credentials.Length < 2 ? null : new BasicAuthenticationIdentity(credentials[0], credentials[1],provider.GetById("Juani", "MySuperPassword!").Claimers);
//        }


//        /// <summary>
//        /// Send the Authentication Challenge request
//        /// </summary>
//        /// <param name="filterContext"></param>
//        private static void ChallengeAuthRequest(HttpActionContext filterContext)
//        {
//            var dnsHost = filterContext.Request.RequestUri.DnsSafeHost;
//            filterContext.Response = filterContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
//            filterContext.Response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", dnsHost));
//        }
//    }
//}