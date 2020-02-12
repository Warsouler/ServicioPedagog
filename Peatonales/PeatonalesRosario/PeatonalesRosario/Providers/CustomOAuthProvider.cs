using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Servicio.Infraestructure;
using Resolver.Enumerations;
using Resolver.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Servicio.Providers
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {

        //Este método valida la autentificación del cliente sea Mobile, Angular o JS, son validaciones
        //Extras a quien te llama.
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            var allowedOrigin = "*";

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

                         
                ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);
                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }

                if (!user.EmailConfirmed)
                {
                    context.SetError("no_confirmed", "Su cuenta no esta habilitada, confirme el registro desde su casilla de email");
                    return;
                }

                ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager, "JWT");
                Dictionary<string, string> dic = new Dictionary<string, string>();
            var mycontext = HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>();
            mycontext.HistorialLogins.Add(new HistorialLogin() { date = DateTime.Now, Id = user.Id });
            mycontext.SaveChanges();
            //var peatonuser = mycontext.PeatonUsers.FirstOrDefault(t => t.Id.Equals(user.Id));
            //if (peatonuser != null)
            //    dic.Add("principalid", peatonuser.idpeatonusers.ToString());
            //else
            //{
            //    var registeruser = mycontext.Business.FirstOrDefault(t => t.Id.Equals(user.Id));
            //    if (registeruser == null)
            //    {
            //        bool isad = false;
            //        var a = user.Roles.ToList();
            //        foreach (var b in a)
            //        {
            //            if (b.RoleId == "2e8e7846-0fd6-4186-9711-a85add7c65ca")
            //            { isad = true; break; }
            //        }
            //        if (!isad)
            //        {
            //            context.SetError("invalid_reference", "No hay una relación con un rol determinado");
            //            return;
            //        }
            //    }
            //    else
            //    {
            //        dic.Add("principalid", registeruser.idbusiness.ToString());
            //    }

            //    List<Claim> claims = new List<Claim>();
            //    var listremove = oAuthIdentity.Claims.Where(t => (t.Type.Equals("Comprar combos")
            // || t.Type.Equals("Adquirir servicios destacados") || t.Type.Equals("Gestionar servicios")
            // || t.Type.Equals("Gestionar servicios destacados") || t.Type.Equals("Gestionar pantalla")
            // || t.Type.Equals("Gestionar regalos") || t.Type.Equals("Gestionar canjes puntos")
            // || t.Type.Equals("Ingresar códigos") || t.Type.Equals("Ver reportes/estadísticos")
            // || t.Type.Equals("Gestionar perfil")
            // ) && t.Value.ToLower() != context.UserName.ToLower());
            //    foreach (var c in listremove)
            //    {
            //        //claims.Add(new Claim(c.Type, c.Value,c.ValueType,c.Issuer,c.OriginalIssuer,c.Subject));
            //        claims.Add(c);
            //        //oAuthIdentity.RemoveClaim(c);
            //    }
            //    foreach (var c in claims)
            //    {
            //        oAuthIdentity.RemoveClaim(c);
            //    }

            //    oAuthIdentity.AddClaim(new Claim("AdminB", "AdminB"));
            //}
            AuthenticationProperties properties = new AuthenticationProperties(dic);
                var ticket = new AuthenticationTicket(oAuthIdentity, properties);
                context.Validated(ticket);
        }
    }
}