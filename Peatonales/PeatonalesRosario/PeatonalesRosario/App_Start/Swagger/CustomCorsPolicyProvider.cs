using Microsoft.Owin.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Cors;
using Microsoft.Owin;

namespace Servicio.App_Start.Swagger
{
    public class CustomCorsPolicyProvider : ICorsPolicyProvider
    {
        public Task<CorsPolicy> GetCorsPolicyAsync(IOwinRequest request)
        {
            var corsPolicy = new CorsPolicy();

            if (request.Uri.PathAndQuery.StartsWith("/swagger/docs"))
            {
                corsPolicy.AllowAnyHeader = true;
                corsPolicy.AllowAnyMethod = true;
                corsPolicy.AllowAnyOrigin = true;
            }

            var tsc = new TaskCompletionSource<CorsPolicy>();
            tsc.SetResult(corsPolicy);
            return tsc.Task;
        }

        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var corsPolicy = new CorsPolicy();

            if (request.RequestUri.PathAndQuery.StartsWith("/swagger/docs"))
            {
                corsPolicy.AllowAnyHeader = true;
                corsPolicy.AllowAnyMethod = true;
                corsPolicy.AllowAnyOrigin = true;
            }

            var tsc = new TaskCompletionSource<CorsPolicy>();
            tsc.SetResult(corsPolicy);
            return tsc.Task;
        }
    }
}