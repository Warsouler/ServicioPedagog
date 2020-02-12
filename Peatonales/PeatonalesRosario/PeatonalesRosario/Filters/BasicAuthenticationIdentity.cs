using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace Servicio.Filters
{
    public class BasicAuthenticationIdentity: GenericIdentity
    {
        /// <summary>
        /// Get/Set for password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Get/Set for UserName
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Get/Set for UserId
        /// </summary>
        public Int32 UserId { get; set; }

        
        public IEnumerable<Claim> Claimers { get; set; }


        /// <summary>
        /// Basic Authentication Identity Constructor
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        //public BasicAuthenticationIdentity(string userName, string password, IEnumerable<Claim> claims)
        //    : base(userName, "Basic")
        //{
        //    Password = password;
        //    UserName = userName;
        //    Claims = claims;
        //}

        public BasicAuthenticationIdentity(string userName, string password, IEnumerable<Claim> cmrs)
            : base(userName, "Basic")
        {
            Password = password;
            UserName = userName;
            this.AddClaims(cmrs);

            
        }

        public BasicAuthenticationIdentity(string userName, string password)
            : base(userName, "Basic")
        {
            Password = password;
            UserName = userName;
        }
    }
}