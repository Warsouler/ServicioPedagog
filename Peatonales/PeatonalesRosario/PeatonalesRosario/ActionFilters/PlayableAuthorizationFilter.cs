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

namespace Servicio.ActionFilters
{
    public class PlayableAuthorizationFilter : AuthorizationFilterAttribute
    {
        


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
                if (principal.Claims.FirstOrDefault(t => t.Type == "AdminB" && t.Value == "AdminB") == null)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                    return Task.FromResult<object>(null);
                }
            }

            //User is Authorized, complete execution
            return Task.FromResult<object>(null);


        }
    }
}