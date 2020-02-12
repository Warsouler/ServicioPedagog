using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Servicio.Models;
using Servicio.Results;
using Servicio.Infraestructure;
using static Servicio.Controllers.ModelFactory;
using Servicio.Filters.ClaimsFilters;
using Servicio.Filters;
using Resolver.Exceptions;
using System.Data;
using Servicio.Models.Security;
using Resolver.Enumerations;
using Servicio.ActionFilters;
using System.Linq;
using GO.Fwk.Toolkits.Cryptography;
using GO.Fwk.Toolkits.Mailing;
using Servicio.Infraestructure.Facades.Files;
using Resolver.TypeDocuments;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Servicio.Controllers
{
    [RoutePrefix("api/accounts")]
    public class AccountsController : BaseApiController
    {
        [Authorize]
        [Route("users")]
        //[RequireHttps]
        //[TestClaimAuthorizationFilter(ClaimTypes = "MyType", ClaimValue = "45")]
        public IHttpActionResult GetUsers()
        {
            //return Ok(this.AppUserManager.Users.Select(u => this.TheModelFactory.Create(u)));
            var iq = this.AppUserManager.Users;
            List<UserReturnModel> myusers = new List<UserReturnModel>();
            foreach (var us in iq)
            {
                myusers.Add(this.TheModelFactory.Create(us));
            }
            return Ok(myusers);
        }

        [Authorize]
        [Route("user/{id:guid}", Name = "GetUserById")]
        public async Task<IHttpActionResult> GetUser(string Id)
        {
            var user = await this.AppUserManager.FindByIdAsync(Id);

            if (user != null)
            {
                return Ok(this.TheModelFactory.Create(user));
            }

            return NotFound();
            
        }

        #region Globals
        [Route("user/{username}")]
        public async Task<IHttpActionResult> GetUserByName(string username)
        {
            if (User.Identity.IsAuthenticated)
            {
                var duplicate = await this.AppUserManager.FindByIdAsync(User.Identity.GetUserId());
                if (duplicate.UserName == username)
                    return NotFound();
            }
            var user = await this.AppUserManager.FindByNameAsync(username);

            if (user != null)
            {
                return Ok(this.TheModelFactory.Create(user));
            }

            return NotFound();
        }

        [Route("emails/{email}")]
        public async Task<IHttpActionResult> GetUserByEmail(string email)
        {
            if (User.Identity.IsAuthenticated)
            {
                var duplicate = await this.AppUserManager.FindByIdAsync(User.Identity.GetUserId());
                if (duplicate.Email == email)
                    return NotFound();
            }
            var user = await this.AppUserManager.FindByEmailAsync(email);
            if (user != null)
            {
                return Ok(this.TheModelFactory.Create(user));
            }
            return NotFound();
        }

        //[Route("confirmregistration")]
        //[GlobalException]
        //public async Task<IHttpActionResult> ConfirmRegistration(ConfirmRegistrationBindingModel model)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    using (var dataContext = HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>())
        //    {
        //        using (var trans = dataContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
        //        {
        //            try
        //            {
        //                model.RandomKey = RandomLink.getVerifyPath() + model.RandomKey;
        //                var existing = dataContext.ConfirmRegsitrations.Where(t => t.randomkey == model.RandomKey).FirstOrDefault();
        //                if (existing == null)
        //                    throw new ApiDataException(0005, "No corresponde a ningun link de confirmación", System.Net.HttpStatusCode.NotFound, "Http");
        //                if (existing.state == (Int32)StatesEnum.Confirmed)
        //                    throw new ApiBusinessException(0006, "El link ya fue utilizado", System.Net.HttpStatusCode.NotFound, "Http");

        //                if (existing.state == (Int32)StatesEnum.Annulled)
        //                    throw new ApiDataException(18, "La confirmación fue reemplazada por una nueva o ya expiró"
        //                        , System.Net.HttpStatusCode.NotFound, "Http://");

        //                if (existing.expiredate < DateTime.Now)
        //                    throw new ApiBusinessException(17, "Esta solicitud ya expiró, mande una nueva solicitud."
        //                        , System.Net.HttpStatusCode.NotFound, "Http://");

        //                var userduplicate = this.AppUserManager.FindById(existing.Id);
        //                if (userduplicate.EmailConfirmed)
        //                    throw new ApiBusinessException(0007, "El usuario ya fue confirmado", System.Net.HttpStatusCode.NotFound, "Http");

        //                userduplicate.EmailConfirmed = true;
        //                existing.state = (Int32)StatesEnum.Confirmed;
        //                dataContext.SaveChanges();
        //                trans.Commit();
        //                return Ok();
        //            }
        //            catch (Exception ex)
        //            {
        //                trans.Rollback();
        //                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
        //            }
        //        }
        //    }
        //}

        //[HttpGet]
        //[Route("requestresetpassword/{email}")]
        //[GlobalException]
        //public async Task<IHttpActionResult> RequestResetPassword(string email)
        //{
        //    using (var dataContext = HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>())
        //    {
        //        using (var trans = dataContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
        //        {
        //            try
        //            {
        //                var user = await this.AppUserManager.FindByEmailAsync(email);
        //                if (user == null)
        //                    throw new ApiDataException(15, "No existe ese email en nuestro sistema",
        //                        System.Net.HttpStatusCode.NotFound, "Http://");
                        
        //                var olders=dataContext.ResetPasswords.Where(t => t.email.Equals(email) &&
        //                t.state == (Int32)StatesEnum.NotConfirmed);
        //                if (olders != null && olders.Count() > 0)
        //                {
        //                    foreach (var old in olders)
        //                    {
        //                        old.state = (Int32)StatesEnum.Annulled;
        //                    }
        //                    dataContext.SaveChanges();
        //                }
        //                String randomLink = RandomLink.GetRandomLinkResetPsw();
        //                ResetPassword rp = new ResetPassword()
        //                {
        //                    email = email,
        //                    expiredate = DateTime.Now.AddDays(1),
        //                    state = (Int32)StatesEnum.NotConfirmed,
        //                    token = randomLink
        //                };
        //                dataContext.ResetPasswords.Add(rp);
        //                dataContext.SaveChanges();
        //                randomLink += "&email=" + email;
        //                var peaton = dataContext.PeatonUsers.Where(t => t.Id.Equals(user.Id));
        //                if (peaton != null && peaton.Count()>0)
        //                {
        //                    randomLink += "&rid=3347";
        //                }
        //                else
        //                {
        //                    randomLink += "&rid=3993";
        //                }

                        
        //                PassChangeStateMail passChangeUserMail =
        //                new PassChangeStateMail(randomLink,user.UserName,email);
        //                new SimpleMail().SendMail(passChangeUserMail);
        //                trans.Commit();
        //                return Ok();
        //            }
        //            catch (Exception ex)
        //            {
        //                trans.Rollback();
        //                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
        //            }
        //        }
        //    }
        //}

        //[HttpGet]
        //[Route("requestnewconfirmregistration/{email}")]
        //[GlobalException]
        //public async Task<IHttpActionResult> RequestNewConfirmRegistration(string email)
        //{
        //    using (var dataContext = HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>())
        //    {
        //        using (var trans = dataContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
        //        {
        //            try
        //            {
        //                var user = await this.AppUserManager.FindByEmailAsync(email);
        //                if (user == null)
        //                    throw new ApiDataException(15, "No existe ese email en nuestro sistema",
        //                        System.Net.HttpStatusCode.NotFound, "Http://");

        //                if (user.EmailConfirmed)
        //                    throw new ApiDataException(19, "La cuenta ya fue confirmada",
        //                        System.Net.HttpStatusCode.BadRequest, "Http://");

        //                var olders = dataContext.ConfirmRegsitrations.Where(t => t.Id.Equals(user.Id) &&
        //                  t.state == (Int32)StatesEnum.NotConfirmed);
        //                if (olders != null && olders.Count() > 0)
        //                {
        //                    foreach (var old in olders)
        //                    {
        //                        old.state = (Int32)StatesEnum.Annulled;
        //                    }
        //                    dataContext.SaveChanges();
        //                }
        //                String randomLink = RandomLink.GetRandomLink();
        //                var confirmregistration = new ConfirmRegistrations()
        //                {
        //                    dateup = DateTime.Now,
        //                    Id = user.Id,
        //                    state = (Int32)StatesEnum.NotConfirmed,
        //                    randomkey = randomLink,
        //                    expiredate = DateTime.Now.AddDays(1),

        //                };
        //                dataContext.ConfirmRegsitrations.Add(confirmregistration);
        //                dataContext.SaveChanges();
        //                RegisterUserStateMail registerUserMail =
        //                                        new RegisterUserStateMail(user.FirstName + " " + user.LastName, 
        //                                        user.UserName, randomLink, "(No se visualiza en reenvíos)","", email);
        //                new SimpleMail().SendMail(registerUserMail);
        //                trans.Commit();
        //                return Ok();
        //            }
        //            catch (Exception ex)
        //            {
        //                trans.Rollback();
        //                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
        //            }
        //        }
        //    }
        //}



        [Route("resetpassword")]
        [GlobalException]
        public async Task<IHttpActionResult> RequestResetPassword(ResetPasswordBindingModel resetmodel)
        {
            using (var dataContext = HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>())
            {
                using (var trans = dataContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        resetmodel.token = RandomLink.getVerifyPathResetPsw() + resetmodel.token;
                        var resetpass=dataContext.ResetPasswords.FirstOrDefault(t => t.email.Equals(resetmodel.email)  && t.token.Equals(resetmodel.token));
                        if (resetpass == null)
                            throw new ApiDataException(16, "No existe una confirmación en el sistema para confirmar"
                                , System.Net.HttpStatusCode.NotFound, "Http://");

                        if (resetpass.state == (Int32)StatesEnum.Confirmed)
                            throw new ApiBusinessException(0006, "El link ya fue utilizado", System.Net.HttpStatusCode.NotFound, "Http");

                        if (resetpass.state == (Int32)StatesEnum.Annulled)
                                throw new ApiDataException(18, "La confirmación fue reemplazada por una nueva o ya expiró"
                                    , System.Net.HttpStatusCode.NotFound, "Http://");

                        if (resetpass.expiredate<DateTime.Now)
                            throw new ApiBusinessException(17, "Esta solicitud ya expiró, mande una nueva solicitud."
                                , System.Net.HttpStatusCode.NotFound, "Http://");

                        var user = await this.AppUserManager.FindByEmailAsync(resetpass.email);
                        if (user == null)
                            throw new ApiDataException(15, "No existe ese email en nuestro sistema",
                                System.Net.HttpStatusCode.NotFound, "Http://");

                        user.PasswordHash = this.AppUserManager.PasswordHasher.HashPassword(resetmodel.newpassword);
                        this.AppUserManager.UpdateSecurityStamp(user.Id);
                        resetpass.state = (Int32)StatesEnum.Confirmed;
                        dataContext.SaveChanges();
                        trans.Commit();
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
        #endregion

        #region PeatonUsers
        [Route("dnis/{dni}")]
        public IHttpActionResult GetUserByDni(string dni)
        {
            var dataContext = HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>();
            //if (User.Identity.IsAuthenticated)
            //{
            //    string id = User.Identity.GetUserId();
            //    var duplicate = dataContext.PeatonUsers.FirstOrDefault(u => u.Id.Equals(id));
            //    if (duplicate!=null && duplicate.dni == dni)
            //        return NotFound();
            //    var duplicateb = dataContext.Business.Include("PlayerUser")
            //        .Where(t=>t.Id.Equals(id) && t.PlayerUser.dni.Equals(dni)).FirstOrDefault();
            //    if (duplicateb != null && duplicateb.PlayerUser!=null && duplicateb.PlayerUser.dni == dni)
            //        return NotFound();
            //}
            //var user = dataContext.PeatonUsers.FirstOrDefault(u => u.dni.Equals(dni));
            //if (user != null)
            //{
            //    return Ok(user);
            //}
            //var duplicatebusiness = dataContext.PlayerUsers.FirstOrDefault(t => t.dni.Equals(dni));
            //if (duplicatebusiness != null)
            //{
            //    return Ok(duplicatebusiness);
            //}
            return NotFound();
        }

        //[RequireHttps]
        [AllowAnonymous]
        [Route("create")]
        [HttpPost]
        [GlobalException]
        public async Task<IHttpActionResult> CreateUser(CreateUserBindingModel createUserModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            using (var dataContext = HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>())
            {
                using (var trans = dataContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        var user = new ApplicationUser()
                        {
                            UserName = createUserModel.Username,
                            Email = createUserModel.Email,
                            Name = createUserModel.Name,
                            //Level = 3,
                            //JoinDate = DateTime.Now.Date,
                            EmailConfirmed = true,
                        };
                        //var userpeaton = new PeatonUser()
                        //{
                        //    address = createUserModel.address,
                        //    addressnumber = createUserModel.addressnumber,
                        //    //age = createUserModel.age,
                        //    dni = createUserModel.dni,
                        //    genre = createUserModel.genre,
                        //    idlocation = createUserModel.idlocation,
                        //    name = createUserModel.FirstName,
                        //    lastname = createUserModel.LastName,
                        //    profession = createUserModel.profession,
                        //    //profilephoto = Cryptography.Decrypt(createUserModel.profilephoto),
                        //    profilephoto =createUserModel.profilephoto,
                        //    state = (Int32)StatesEnum.Valid,
                        //    Id = user.Id,
                        //    birthdate = createUserModel.birthdate,
                        //    apartment=createUserModel.apartment,
                        //    civilstatus=createUserModel.civilstatus,
                        //    floor=createUserModel.floor,
                        //    phonenumber = createUserModel.phonenumber
                        //};
                        //String randomLink = RandomLink.GetRandomLink();
                        //var confirmregistration = new ConfirmRegistrations()
                        //{
                        //    dateup = DateTime.Now,
                        //    Id = user.Id,
                        //    state = (Int32)StatesEnum.NotConfirmed,
                        //    randomkey = randomLink,
                        //    expiredate = DateTime.Now.AddDays(1),

                        //};

                        var userduplicate = this.AppUserManager.FindByName(user.UserName);
                        if (userduplicate != null)
                            throw new ApiBusinessException(0002, "Nombre de usuario duplicado",
                                System.Net.HttpStatusCode.BadRequest, "Http");
                        userduplicate = this.AppUserManager.FindByEmail(user.Email);
                        if (userduplicate != null)
                            throw new ApiBusinessException(0003, "Email duplicado", System.Net.HttpStatusCode.BadRequest, "Http");

                        //var userdniduplicate = dataContext.PeatonUsers.Where(t => t.dni.Equals(userpeaton.dni)).FirstOrDefault();
                        //if (userdniduplicate != null)
                        //    throw new ApiBusinessException(0004, "Dni duplicado", System.Net.HttpStatusCode.BadRequest, "Http");

                        //var userdniduplicateplayer = dataContext.PlayerUsers.Where(t => t.dni.Equals(userpeaton.dni)).FirstOrDefault();
                        //if (userdniduplicateplayer != null)
                        //    throw new ApiBusinessException(0004, "Dni duplicado", System.Net.HttpStatusCode.BadRequest, "Http");

                        var role = new CreateRoleBindingModel() { Name = createUserModel.RoleName };
                        IdentityResult addUserResult = await this.AppUserManager
                    .CreateAsync(user, createUserModel.Password);
                        if (!addUserResult.Succeeded)
                        {
                            trans.Rollback();
                            return GetErrorResult(addUserResult);
                        }

                        IdentityResult addUserToRoleResult = await this.AppUserManager.
                         AddToRoleAsync(user.Id, role.Name);
                        if (!addUserToRoleResult.Succeeded)
                        {
                            trans.Rollback();
                            return GetErrorResult(addUserResult);
                        }
                        //dataContext.PeatonUsers.Add(userpeaton);
                        //dataContext.SaveChanges();
                        //dataContext.ConfirmRegsitrations.Add(confirmregistration);
                        //dataContext.SaveChanges();
                        //RegisterUserStateMail registerUserMail =
                        //new RegisterUserStateMail(user.FirstName + " " + user.LastName, user.UserName, randomLink, createUserModel.Password, createUserModel.Email);
                        //new SimpleMail().SendMail(registerUserMail);
                        trans.Commit();
                        Uri locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));
                        return Created(locationHeader, TheModelFactory.Create(user));

                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
                    }
                }
            }
        }
        //[RequireHttps]
        [Authorize(Roles = "Usuarios")]
        [Route("update")]
        [HttpPost]
        [GlobalException]
        public async Task<IHttpActionResult> UpdateUser(UpdateUserBindingModel createUserModel)
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
                        var user = this.AppUserManager.FindById(User.Identity.GetUserId());
                        var userduplicate = this.AppUserManager.FindByName(user.UserName);
                        if (userduplicate != null && userduplicate.Id != user.Id)
                            throw new ApiBusinessException(0002, "Nombre de usuario duplicado", System.Net.HttpStatusCode.BadRequest, "Http");
                        userduplicate = this.AppUserManager.FindByEmail(user.Email);
                        if (userduplicate != null && userduplicate.Id != user.Id)
                            throw new ApiBusinessException(0003, "Email duplicado", System.Net.HttpStatusCode.BadRequest, "Http");

                        //var userdniduplicate = dataContext.PeatonUsers.Where(t => t.dni.Equals(createUserModel.dni)).FirstOrDefault();
                        //if (userdniduplicate != null && userdniduplicate.Id != user.Id)
                        //    throw new ApiBusinessException(0004, "Dni duplicado", System.Net.HttpStatusCode.BadRequest, "Http");
                        //var userdniduplicateplayer = dataContext.PlayerUsers.Where(t => t.dni.Equals(createUserModel.dni)).FirstOrDefault();
                        //if (userdniduplicateplayer != null)
                        //    throw new ApiBusinessException(0004, "Dni duplicado", System.Net.HttpStatusCode.BadRequest, "Http");

                        user.UserName = createUserModel.Username;
                        user.Email = createUserModel.Email;
                        user.Name = createUserModel.Name;

                        var passwordResult = this.AppUserManager.CheckPassword(user, createUserModel.OldPassword);
                        if (!passwordResult)
                            throw new ApiBusinessException(0008, "La contraseña actual no es correcta", System.Net.HttpStatusCode.BadRequest, "Http");

                        if (!String.IsNullOrEmpty(createUserModel.Password) &&
                            !String.IsNullOrEmpty(createUserModel.ConfirmPassword)
                            && createUserModel.Password.Equals(createUserModel.ConfirmPassword))
                        {
                            IdentityResult addUserResult = this.AppUserManager
                                .ChangePassword(User.Identity.GetUserId(), createUserModel.OldPassword, createUserModel.Password);
                            if (!addUserResult.Succeeded)
                            {


                                if (addUserResult.Errors.Contains("Incorrect password."))
                                    throw new ApiBusinessException(0008, "La contraseña actual no es correcta", System.Net.HttpStatusCode.BadRequest, "Http");
                                trans.Rollback();
                                return GetErrorResult(addUserResult);
                            }
                        }
                        //var userpeaton = dataContext.PeatonUsers.FirstOrDefault(t => t.idpeatonusers == createUserModel.idpeatonusers);
                        //userpeaton.address = createUserModel.address;
                        //userpeaton.addressnumber = createUserModel.addressnumber;
                        //userpeaton.phonenumber = createUserModel.phonenumber;
                        ////userpeaton.age = createUserModel.age;
                        //userpeaton.dni = createUserModel.dni;
                        //userpeaton.genre = createUserModel.genre;
                        //userpeaton.idlocation = createUserModel.idlocation;
                        //userpeaton.name = createUserModel.FirstName;
                        //userpeaton.lastname = createUserModel.LastName;
                        //userpeaton.profession = createUserModel.profession.Replace(" / ", "_");
                        ////userpeaton.profilephoto = Cryptography.Decrypt(createUserModel.profilephoto);
                        //userpeaton.profilephoto = createUserModel.profilephoto;
                        //userpeaton.civilstatus = createUserModel.civilstatus;
                        //userpeaton.apartment = createUserModel.apartment;
                        //userpeaton.floor = createUserModel.floor;
                        //dataContext.SaveChanges();

                        //Points Security
                        //SetFullProfilePoints(user, dataContext);
                        //End Points






                        trans.Commit();
                        Uri locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));
                        return Created(locationHeader, TheModelFactory.Create(user));

                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
                    }
                }
            }
        }
        #endregion


        //#region Full Profile
        //#region SetFullProfilePoints
        //public void SetFullProfilePoints(ApplicationUser userpeaton,ApplicationDbContext context)
        //{

        //    Preference preference;
        //    Expression<Func<Preference, Boolean>> predicatePreference = x => x.idaspnetuser == userpeaton.Id;
        //    preference = context.Preferences.Include("banks").Include("items").Include("tags").FirstOrDefault(predicatePreference);
            
        //    if (CheckFullProfile(preference, context) == true)
        //    {
        //        #region Points
        //        #region Preference Points
        //        Expression<Func<PreferencePoint, Boolean>> predicatePoint = t => t.idpreference == preference.idpreference;
        //        PreferencePoint pproints = context.PreferencePoints.FirstOrDefault(predicatePoint);
        //        #endregion

        //        #region PointType
        //        Expression<Func<PointType, Boolean>> predicateType = t => t.idpointtype == (Int32)TypePointEnum.ProfileComplete;
        //        PointType pointType = context.PointTypes.FirstOrDefault(predicateType);
        //        #endregion

        //        #region AddPoints
        //        if (pproints != null)
        //        {
        //            //If it exists
        //            AddPoint points = new AddPoint()
        //            {
        //                date = DateTime.Now,
        //                idpointtype = (Int32)TypePointEnum.ProfileComplete,
        //                keyservice = preference.idpreference,
        //                points = pointType.points,
        //                state = (Int32)StatesEnum.Valid,
        //                idpreferencepoint = pproints.idpreferencepoint
        //            };
        //            context.AddPoints.Add(points);
        //            pproints.totalpoints += points.points;
        //            context.Entry<PreferencePoint>(pproints).State = EntityState.Unchanged;
        //            context.Entry<PreferencePoint>(pproints).Property("totalpoints").IsModified = true;

        //        }
        //        else
        //        {
        //            pproints = new PreferencePoint()
        //            {
        //                idpreference = preference.idpreference,
        //                state = (Int32)StatesEnum.Valid,
        //                totalpoints = 0,
        //                addpoints = new List<AddPoint>()
        //            };
        //            AddPoint points = new AddPoint()
        //            {
        //                date = DateTime.Now,
        //                idpointtype = (Int32)TypePointEnum.ProfileComplete,
        //                keyservice = preference.idpreference,
        //                points = pointType.points,
        //                state = (Int32)StatesEnum.Valid
        //            };
        //            pproints.totalpoints += points.points;
        //            pproints.addpoints.Add(points);
        //            context.PreferencePoints.Add(pproints);
        //            //_unitofwork.PreferencePointRepository.Insert(pproints);
        //        }
        //        #endregion
        //        #endregion

        //        context.SaveChanges();
        //    }
        //}
        //#endregion
        //#endregion





        //#region Check Full Profile
        //private Boolean CheckFullProfile(Preference preference, ApplicationDbContext context)
        //{
        //    #region Get Preference
        //    //Preference preference;
        //    //Expression<Func<Preference, Boolean>> predicatePreference = x => x.idaspnetuser == user.Id;
        //    //preference = context.Preferences.Include("banks").Include("items").Include("tags").FirstOrDefault(predicatePreference);



        //    //context.Preferences.Include("banks").Include("items").Include("tags").FirstOrDefault(predicatePreference);
        //    //predicatePreference = x => x.idpreference == preference.idpreference;
        //    //preference = context.Preferences.GetOneByFilters(predicatePreference, "banks", "items", "tags");

        //    #endregion

        //    if (preference == null)
        //        return false;

        //    #region Ya tiene los puntos por perfil completo?
        //    Expression<Func<PreferencePoint, Boolean>> predicatePreferencePoint = x => x.idpreference == preference.idpreference;
        //    PreferencePoint preferencePoint = context.PreferencePoints.Include("addpoints").FirstOrDefault(predicatePreferencePoint);
        //    if (preferencePoint != null)
        //    {
        //        AddPoint fullprofile = preferencePoint.addpoints.Find(x => x.idpointtype == (Int32)TypePointEnum.ProfileComplete);
        //        if (fullprofile != null)
        //        {
        //            return false;
        //        }
        //    }
        //    #endregion

        //    #region Tiene las preferences completas?
        //    if (preference.banks.Count < 1)
        //        return false;
        //    if (preference.tags.Count < 1)
        //        return false;
        //    if (preference.items.Count < 1)
        //        return false;
        //    #endregion

        //    #region Tiene completo los datos de usuario?
        //    Expression<Func<PeatonUser, Boolean>> predicateUser = x => x.Id == preference.idaspnetuser;
        //    PeatonUser user = context.PeatonUsers.FirstOrDefault(predicateUser);
        //    if (user != null)
        //    { 
        //        if (user.address != null && user.birthdate != null && user.dni != null && user.genre != null && user.lastname != null && user.name != null && user.profession != null && user.profilephoto != null)
        //        {
        //            if (user.address != "" && user.addressnumber != 0 /*&& user.age != 0 */&& user.birthdate != DateTime.MinValue && user.birthdate != DateTime.MaxValue && user.dni != "" && user.genre != "" && user.idlocation != 0 && user.lastname != "" && user.name != "" && user.profession != "" && user.profilephoto != "" && user.state != (Int32)StatesEnum.Annulled)
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        Expression<Func<Business, Boolean>> predicateBusiness = x => x.Id == preference.idaspnetuser;
        //        Business business = context.Business.Include("PlayerUser").FirstOrDefault(predicateBusiness);
        //        if (business.idplayeruser != 1)
        //        {
        //            if (business.PlayerUser.publicname != null && business.PlayerUser.genre != null && business.PlayerUser.birthdate != null && business.PlayerUser.profession != null && business.PlayerUser.profilephoto != null && business.PlayerUser.dni != null && business.PlayerUser.civilstatus != null)
        //            {
        //                if (business.PlayerUser.publicname != "" && business.PlayerUser.genre != "" /*&& business.PlayerUser.birthdate != null*/ && business.PlayerUser.profession != "" && business.PlayerUser.profilephoto != "" && business.PlayerUser.dni != "" && business.PlayerUser.civilstatus != "")
        //                {
        //                    return true;
        //                }
        //            }
        //        }
        //    }

        //    return false;
        //    #endregion
        //}
        //#endregion
        //#endregion


        



        #region OthersMembership
        [Authorize(Roles = "Admin")]
        [Route("user/{id:guid}/roles")]
        [HttpPut]
        public async Task<IHttpActionResult> AssignRolesToUser([FromUri] string id, [FromBody] string[] rolesToAssign)
        {
            var appUser = await this.AppUserManager.FindByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            var currentRoles = await this.AppUserManager.GetRolesAsync(appUser.Id);
            string[] currentroles = new string[currentRoles.Count];
            for (int i = 0; i <= currentRoles.Count; i++)
            {
                currentroles[i] = currentRoles.GetEnumerator().Current;
                currentRoles.GetEnumerator().MoveNext();
            }

            //var rolesNotExists = rolesToAssign.Except(this.AppRoleManager.Roles.Select(x => x.Name)).ToArray();

            //if (rolesNotExists.Count() > 0)
            //{

            //    ModelState.AddModelError("", string.Format("Roles '{0}' does not exixts in the system", string.Join(",", rolesNotExists)));
            //    return BadRequest(ModelState);
            //}

            IdentityResult removeResult = await this.AppUserManager.RemoveFromRolesAsync(appUser.Id, currentroles);

            if (!removeResult.Succeeded)
            {
                ModelState.AddModelError("", "Failed to remove user roles");
                return BadRequest(ModelState);
            }

            IdentityResult addResult = await this.AppUserManager.AddToRolesAsync(appUser.Id, rolesToAssign);

            if (!addResult.Succeeded)
            {
                ModelState.AddModelError("", "Failed to add user roles");
                return BadRequest(ModelState);
            }

            return Ok();

        }

        [Authorize(Roles = "Admin")]
        [Route("user/{id:guid}/assignclaims")]
        [HttpPut]
        public async Task<IHttpActionResult> AssignClaimsToUser([FromUri] string id, [FromBody] List<ClaimBindingModel> claimsToAssign)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appUser = await this.AppUserManager.FindByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }
            IdentityUserClaim iuc;
            foreach (ClaimBindingModel claimModel in claimsToAssign)
            {
                iuc = new IdentityUserClaim()
                {
                    ClaimType = claimModel.Type,
                    ClaimValue = claimModel.Value
                };
                //if (appUser.Claims.Any(c => c.ClaimType == claimModel.Type))
                if (appUser.Claims.Contains(iuc))
                {

                    await this.AppUserManager.RemoveClaimAsync(id, ExtendedClaimsProvider.CreateClaim(claimModel.Type, claimModel.Value));
                }

                await this.AppUserManager.AddClaimAsync(id, ExtendedClaimsProvider.CreateClaim(claimModel.Type, claimModel.Value));
            }

            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [Route("user/{id:guid}/removeclaims")]
        [HttpPut]
        public async Task<IHttpActionResult> RemoveClaimsFromUser([FromUri] string id, [FromBody] List<ClaimBindingModel> claimsToRemove)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appUser = await this.AppUserManager.FindByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }
            IdentityUserClaim iuc;

            foreach (ClaimBindingModel claimModel in claimsToRemove)
            {
                iuc = new IdentityUserClaim()
                {
                    ClaimType = claimModel.Type,
                    ClaimValue = claimModel.Value,
                    UserId = id,
                };
                //if (appUser.Claims.Any(c => c.ClaimType == claimModel.Type))

                if (appUser.Claims.Contains(iuc))
                {
                    await this.AppUserManager.RemoveClaimAsync(id, ExtendedClaimsProvider.CreateClaim(claimModel.Type, claimModel.Value));
                }
            }

            return Ok();
        }

        [AllowAnonymous]
        [Route("createadmin")]
        [HttpPost]
        [GlobalException]
        public async Task<IHttpActionResult> CreateAdmin(CreateUserBindingModel createUserModel)
        {
            //throw new ApiBusinessException(0002, "Nombre de usuario duplicado", System.Net.HttpStatusCode.BadRequest, "Http");
            using (var dataContext = HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>())
            {
                using (var trans = dataContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        var user = new ApplicationUser()
                        {
                            UserName = createUserModel.Username,
                            Email = createUserModel.Email,
                            Name = createUserModel.Name,
                            //LastName = createUserModel.LastName,
                            //Level = 3,
                            //JoinDate = DateTime.Now.Date,
                            EmailConfirmed = true
                        };


                        var role = new CreateRoleBindingModel() { Name = createUserModel.RoleName };
                        IdentityResult addUserResult = await this.AppUserManager
                    .CreateAsync(user, createUserModel.Password);
                        if (!addUserResult.Succeeded)
                        {
                            trans.Rollback();
                            return GetErrorResult(addUserResult);
                        }

                        IdentityResult addUserToRoleResult = await this.AppUserManager.
                         AddToRoleAsync(user.Id, role.Name);
                        if (!addUserToRoleResult.Succeeded)
                        {
                            trans.Rollback();
                            return GetErrorResult(addUserResult);
                        }

                        trans.Commit();
                        Uri locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));
                        return Created(locationHeader, TheModelFactory.Create(user));

                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
                    }
                }
            }
        }
        #endregion




    }

}

