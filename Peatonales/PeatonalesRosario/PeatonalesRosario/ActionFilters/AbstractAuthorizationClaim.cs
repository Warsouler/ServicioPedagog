using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace Servicio.ActionFilters
{
    public abstract class AbstractAuthorizationClaim: AuthorizationFilterAttribute
    {
        public string Value { get; set; }
        public virtual string Type { get; set; }
    }
}