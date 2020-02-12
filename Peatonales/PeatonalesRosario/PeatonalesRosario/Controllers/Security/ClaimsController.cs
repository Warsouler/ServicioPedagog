using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Servicio.ActionFilters;
using Servicio.Infraestructure;
using Servicio.Models;
using Servicio.Models.Security;
using Resolver.Enumerations;
using Resolver.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace Servicio.Controllers
{
    //[RoutePrefix("api/claims")]
    //public class ClaimsController : BaseApiController
    public class ClaimsController : ApiController
    {
        [Authorize]
        //[Route("~/api/claims/{id:long}")]
        [ResponseType(typeof(List<ClaimBindingModel>))]
        public async Task<IHttpActionResult> GetClaim(long id)
        {

            using (var dataContext = HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>())
            {
                using (var trans = dataContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        //var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
                        //ApplicationUser user = await userManager.FindByNameAsync(User.Identity.Name);
                        //var employee=dataContext.EmployeeAccounts.First(t => t.idemployeeaccount == id);
                        //List<ClaimBindingModel> claims = new List<ClaimBindingModel>();
                        //foreach (var claim in user.Claims)
                        //{
                        //    if (claim.ClaimType.Equals("iss") || claim.ClaimType.Equals("aud") || claim.ClaimType.Equals("nbf") ||
                        //                   claim.ClaimType.Equals("exp") || claim.ClaimType.Equals("nameid") ||
                        //                   claim.ClaimType.Equals("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider")
                        //                   || claim.ClaimType.Equals("role")
                        //                   || claim.ClaimType.Equals("AspNet.Identity.SecurityStamp") || claim.ClaimType.Equals("exp")
                        //                   || claim.ClaimType.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
                        //                   || claim.ClaimType.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")
                        //                   || claim.ClaimType.Equals("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider")
                        //                   || claim.ClaimType.Equals("AspNet.Identity.SecurityStamp")
                        //                   || claim.ClaimType.Equals("http://schemas.microsoft.com/ws/2008/06/identity/claims/role")
                        //                   )
                        //        continue;
                        //    else if (claim.ClaimValue==employee.username)
                        //    { 
                        //        claims.Add(new ClaimBindingModel() { Type = claim.ClaimType, Value = claim.ClaimValue });
                        //    }
                        //}
                        //trans.Commit();
                        //return Ok(claims);
                        return Ok();

                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
                    }

                }
            }          
        }

        

        //[Authorize]
        //[ResponseType(typeof(List<EmployeeAccountBindingModel>))]
        //public async Task<IHttpActionResult> GetAllEmployees()
        //{
        //    using (var dataContext = HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>())
        //    {
        //        using (var trans = dataContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
        //        {
        //            try
        //            {
        //                //HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>().Users.First(t=>t.)
        //                //var appuser = this.AppUserManager.FindByNameAsync(User.Identity.Name);

        //                var appuser = dataContext.Users.First(t => t.UserName.Equals(User.Identity.Name));
        //                var business = dataContext.Business.FirstOrDefault(t => t.Id == appuser.Id);
        //                var employess = dataContext.EmployeeAccounts.Where(t => t.BusinessConfiguration.idbusiness == business.idbusiness && t.state==(Int32)StatesEnum.Valid);
        //                List<EmployeeAccountBindingModel> myemployees = new List<EmployeeAccountBindingModel>();
        //                foreach (var empdb in employess)
        //                {
        //                    myemployees.Add(new EmployeeAccountBindingModel() {
        //                        idemployeeaccount = empdb.idemployeeaccount,
        //                        password = empdb.password,
        //                        state = empdb.state,
        //                        username = empdb.username
        //                    });
        //                }
        //                trans.Commit();
        //                return Ok(myemployees);
        //                //identity.AddClaim
        //            }
        //            catch (Exception ex)
        //            {
        //                trans.Rollback();
        //                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
        //            }

        //        }
        //    }
        //}


        [HttpPost]
        [GlobalException]
        [Authorize]
        public async Task<IHttpActionResult> PostClaims(List<PostClaimBindingModel> permisionss)
        {
            //throw new ApiBusinessException(0002, "Nombre de usuario duplicado", System.Net.HttpStatusCode.BadRequest, "Http");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            using (var dataContext = HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>())
            {
                using (var trans = dataContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        //List<Claim> NewClaims = new List<Claim>();
                        //foreach (var claim in permisionss)
                        //{
                            
                        //NewClaims.Add(new Claim(claim.Type, claim.Value));
                        //}

                        //var identity = User.Identity as ClaimsIdentity;
                        //var claims = identity.Claims.ToList();
                        //foreach (var claim in claims)
                        //{
                        //    if (claim.Type.Equals("iss") || claim.Type.Equals("aud") || claim.Type.Equals("nbf") ||
                        //        claim.Type.Equals("exp") || claim.Type.Equals("nameid") ||
                        //        claim.Type.Equals("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider")
                        //        || claim.Type.Equals("role")
                        //        || claim.Type.Equals("AspNet.Identity.SecurityStamp") || claim.Type.Equals("exp")
                        //        || claim.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
                        //        || claim.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")
                        //        || claim.Type.Equals("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider")
                        //        || claim.Type.Equals("AspNet.Identity.SecurityStamp")
                        //        || claim.Type.Equals("http://schemas.microsoft.com/ws/2008/06/identity/claims/role")
                        //        )
                        //        continue;
                        //    else
                        //        claims.Remove(claim);

                        //}

                        //identity.AddClaims(NewClaims);
                        var appUser=   Request.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByNameAsync(User.Identity.Name);
                        //var appUser = await this.AppUserManager.FindByIdAsync(id);

                        if (appUser == null)
                        {
                            return NotFound();
                        }
                        Claim iuc;
                        var realclaims = Request.GetOwinContext().GetUserManager<ApplicationUserManager>().GetClaimsAsync(appUser.Result.Id);
                        foreach (PostClaimBindingModel claimModel in permisionss)
                        {
                            iuc = new Claim(claimModel.Type, claimModel.Value);
                            if (claimModel.ischecked)
                            {
                                //iuc = new IdentityUserClaim()
                                //{
                                //    ClaimType = claimModel.Type,
                                //    ClaimValue = claimModel.Value
                                //};
                                
                                //if (appUser.Claims.Any(c => c.ClaimType == claimModel.Type))

                                if (realclaims.Result.FirstOrDefault(t=>t.Type==iuc.Type && t.Value==claimModel.Value)!=null)
                                {
                                    await Request.GetOwinContext().GetUserManager<ApplicationUserManager>().RemoveClaimAsync(appUser.Result.Id, iuc);
                                }

                                //await Request.GetOwinContext().GetUserManager<ApplicationUserManager>().AddClaimAsync(appUser.Result.Id, ExtendedClaimsProvider.CreateClaim(claimModel.Type, claimModel.Value));
                                await Request.GetOwinContext().GetUserManager<ApplicationUserManager>().AddClaimAsync(appUser.Result.Id, iuc);
                            }
                            else
                            {
                                
                                //if (appUser.Claims.Any(c => c.ClaimType == claimModel.Type))

                                if (realclaims.Result.FirstOrDefault(t => t.Type == iuc.Type && t.Value == claimModel.Value) != null)
                                {
                                    await Request.GetOwinContext().GetUserManager<ApplicationUserManager>().RemoveClaimAsync(appUser.Result.Id, iuc);
                                }
                            }
                        }
                        //ClaimsIdentity oAuthIdentity = await appUser.Result.GenerateUserIdentityAsync(Request.GetOwinContext().GetUserManager<ApplicationUserManager>(), "JWT");
                        //HttpContext.Current.GetOwinContext().Authentication.User.AddIdentity(oAuthIdentity);
                        //Request.GetOwinContext().Environment.
                        //var ticket = new AuthenticationTicket(oAuthIdentity, properties);
                        //Request.GetOwinContext().Authentication.
                        //OAuthGrantResourceOwnerCredentialsContext
                        //context.Validated(ticket);
                        trans.Commit();
                        return Ok();
                        //identity.AddClaim
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
                    }

                }
            }
        }
    }
}
