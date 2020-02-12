namespace DataModel.Migrations
{
    using DataModel;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Claims;

    internal sealed class Configuration : DbMigrationsConfiguration<ServicioContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ServicioContext context)
        {

            //context.Authors.AddOrUpdate(x => x.Id,
            //    new Author() { Id = 1, Name = "Jane Austen" },
            //    new Author() { Id = 2, Name = "Charles Dickens" },
            //    new Author() { Id = 3, Name = "Miguel de Cervantes" }
            //    );

            //context.Books.AddOrUpdate(x => x.Id,
            //    new Book()
            //    {
            //        Id = 1,
            //        Title = "Pride and Prejudice",
            //        Year = 1813,
            //        AuthorId = 1,
            //        Price = 9.99M,
            //        Genre = "Comedy of manners"
            //    },
            //    new Book()
            //    {
            //        Id = 2,
            //        Title = "Northanger Abbey",
            //        Year = 1817,
            //        AuthorId = 1,
            //        Price = 12.95M,
            //        Genre = "Gothic parody"
            //    },
            //    new Book()
            //    {
            //        Id = 3,
            //        Title = "David Copperfield",
            //        Year = 1850,
            //        AuthorId = 2,
            //        Price = 15,
            //        Genre = "Bildungsroman"
            //    },
            //    new Book()
            //    {
            //        Id = 4,
            //        Title = "Don Quixote",
            //        Year = 1617,
            //        AuthorId = 3,
            //        Price = 8.95M,
            //        Genre = "Picaresque"
            //    }
            //    );

            //context.Cities.AddOrUpdate(
            //     new City
            //     {
            //         Id = 1,
            //         Country = "India",
            //         Name = "Delhi",
            //         Population01 = 20,
            //         Population05 = 22,
            //         Population10 = 25,
            //         Population15 = 30
            //     },
            //     new City
            //     {
            //         Id = 2,
            //         Country = "India",
            //         Name = "Gurgaon",
            //         Population01 = 10,
            //         Population05 = 18,
            //         Population10 = 20,
            //         Population15 = 22
            //     },
            //      new City
            //      {
            //          Id = 3,
            //          Country = "India",
            //          Name = "Bangalore",
            //          Population01 = 8,
            //          Population05 = 20,
            //          Population10 = 25,
            //          Population15 = 28
            //      }

            //     );

            #region Juan


















































            #endregion

            #region Develop1 = Nahuel

















































            #endregion

            #region Develop2 = Wilson

















































            #endregion

            #region Develop3 = Manu

















































            #endregion

            #region Develop4 = Pradel
















































            #endregion

            #region Develop5 = Juli

















































            #endregion

            //context.SaveChanges();


        }

    }
}
