using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DataModel
{
    public class ServicioContext : /*IdentityDbContext<User>*/ DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ServicioContext() : base("name=ServicioContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
             
        }

        //public System.Data.Entity.DbSet<DataModel.Author> Authors { get; set; }

        //public System.Data.Entity.DbSet<DataModel.Book> Books { get; set; }

        //public System.Data.Entity.DbSet<DataModel.City> Cities { get; set; }

        #region Juan
        //34

        public System.Data.Entity.DbSet<DataModel.AspNetUser> AspNetUsers { get; set; }
        public System.Data.Entity.DbSet<DataModel.HistorialLogin> HistorialLogins { get; set; }
        public System.Data.Entity.DbSet<DataModel.Models.Cycles> Cycles { get; set; }
        public System.Data.Entity.DbSet<DataModel.Models.Careers> Careers { get; set; }
        public System.Data.Entity.DbSet<DataModel.Models.Subjects> Subjects { get; set; }












































        //83
        #endregion
        //85
        #region Develop1 = Leo - 86
        //87

































        //146
        #endregion
        //148





        //364
        //366

        //public System.Data.Entity.DbSet<DataModel.User> Users { get; set; }

        //public System.Data.Entity.DbSet<DataModel.Token> Tokens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ServicioContext>(null);
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            //modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            //modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

        public static ServicioContext Create()
        {
            return new ServicioContext();
        }
    }
}
