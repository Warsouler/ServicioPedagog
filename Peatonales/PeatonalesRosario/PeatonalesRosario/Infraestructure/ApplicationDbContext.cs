using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio.Infraestructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ServicioContext", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public System.Data.Entity.DbSet<PeatonUser> PeatonUsers { get; set; }
        //public System.Data.Entity.DbSet<Business> Business { get; set; }
        //public System.Data.Entity.DbSet<ConfirmRegistrations> ConfirmRegsitrations { get; set; }
        //public System.Data.Entity.DbSet<PlayerUser> PlayerUsers { get; set; }
        public System.Data.Entity.DbSet<ResetPassword> ResetPasswords { get; set; }
        public System.Data.Entity.DbSet<HistorialLogin> HistorialLogins { get; set; }






    }
}