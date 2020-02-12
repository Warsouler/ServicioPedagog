using Resolver.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Servicio.Filters.ClaimsFilters
{
    public class ClaimsAuthorizationAttribute : AuthorizationFilterAttribute
    {
        public string ClaimType { get; set; }
        

        public override Task OnAuthorizationAsync(HttpActionContext actionContext, System.Threading.CancellationToken cancellationToken)
        {

            var principal = actionContext.RequestContext.Principal as ClaimsPrincipal;

            if (!principal.Identity.IsAuthenticated)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                return Task.FromResult<object>(null);
            }

            if (principal.IsInRole("Empresas"))
            {

                if (principal.Claims.FirstOrDefault(t => t.Type == "AdminB" && t.Value == "AdminB")==null)
                {
                    //List<string> claims = ClaimType.Split(',').ToList();
                    foreach (var claim in ClaimType.Split(',').ToList())
                    { 
                        if ((principal.HasClaim(x => x.Type == ClaimConverter.Convert(claim).ToString())))
                        {
                            return Task.FromResult<object>(null);
                        }
                    }
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                    return Task.FromResult<object>(null);
                }
            }

            //User is Authorized, complete execution
            return Task.FromResult<object>(null);


        }
    }
}