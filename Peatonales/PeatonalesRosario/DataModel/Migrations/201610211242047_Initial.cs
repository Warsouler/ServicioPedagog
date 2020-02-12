namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Authors",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Books",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Title = c.String(nullable: false),
            //            Year = c.Int(nullable: false),
            //            Price = c.Decimal(nullable: false, precision: 18, scale: 2),
            //            Genre = c.String(),
            //            AuthorId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
            //    .Index(t => t.AuthorId);
            
            //CreateTable(
            //    "dbo.Cities",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false),
            //            Country = c.String(),
            //            Population01 = c.Int(nullable: false),
            //            Population05 = c.Int(nullable: false),
            //            Population10 = c.Int(nullable: false),
            //            Population15 = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Tokens",
            //    c => new
            //        {
            //            TokenId = c.Int(nullable: false, identity: true),
            //            AuthToken = c.String(nullable: false),
            //            IssuedOn = c.DateTime(nullable: false),
            //            ExpiresOn = c.DateTime(nullable: false),
            //            UserId = c.Int(nullable: false),
            //            User_Id = c.String(maxLength: 128),
            //        })
            //    .PrimaryKey(t => t.TokenId)
            //    .ForeignKey("dbo.Users", t => t.User_Id)
            //    .Index(t => t.User_Id);
            
            //CreateTable(
            //    "dbo.AspNetUsers",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            UserName = c.String(nullable: false),
            //            Password = c.String(),
            //            Name = c.String(),
            //            Email = c.String(),
            //            EmailConfirmed = c.Boolean(nullable: false),
            //            PasswordHash = c.String(),
            //            SecurityStamp = c.String(),
            //            PhoneNumber = c.String(),
            //            TwoFactorEnabled = c.Boolean(nullable: false),
            //            LockoutEndDateUtc = c.DateTime(),
            //            LockoutEnabled = c.Boolean(nullable: false),
            //            AccessFailedCount = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.AspNetUserClaims",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            UserId = c.String(maxLength: 128),
            //            ClaimType = c.String(),
            //            ClaimValue = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId)
            //    .Index(t => t.UserId);

            //CreateTable(
            //    "dbo.AspNetUserLogins",
            //    c => new
            //    {
            //        UserId = c.String(nullable: false, maxLength: 128),
            //        LoginProvider = c.String(),
            //        ProviderKey = c.String(),
            //        Id = c.String(nullable: false, maxLength: 128),
            //        Date = c.DateTime(),
            //    })
            //    .PrimaryKey(t => t.UserId)
            //    .ForeignKey("dbo.AspNetUsers", t => t.Id)
            //    .Index(t => t.Id);

            //CreateTable(
            //    "dbo.AspNetUserRoles",
            //    c => new
            //    {
            //        RoleId = c.String(nullable: false, maxLength: 128),
            //        UserId = c.String(nullable: false, maxLength: 128),
            //    })
            //    .PrimaryKey(t => new { t.RoleId, t.UserId })
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId);
            
            //CreateTable(
            //    "dbo.AspNetRoles",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            //DropForeignKey("dbo.Tokens", "User_Id", "dbo.Users");
            //DropForeignKey("dbo.IdentityUserRoles", "UserId", "dbo.Users");
            //DropForeignKey("dbo.IdentityUserLogins", "User_Id", "dbo.Users");
            //DropForeignKey("dbo.IdentityUserClaims", "UserId", "dbo.Users");
            //DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            //DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            //DropIndex("dbo.IdentityUserRoles", new[] { "UserId" });
            //DropIndex("dbo.IdentityUserLogins", new[] { "User_Id" });
            //DropIndex("dbo.IdentityUserClaims", new[] { "UserId" });
            //DropIndex("dbo.Tokens", new[] { "User_Id" });
            //DropIndex("dbo.Books", new[] { "AuthorId" });
            //DropTable("dbo.IdentityRoles");
            //DropTable("dbo.IdentityUserRoles");
            //DropTable("dbo.IdentityUserLogins");
            //DropTable("dbo.IdentityUserClaims");
            //DropTable("dbo.Users");
            //DropTable("dbo.Tokens");
            //DropTable("dbo.Cities");
            //DropTable("dbo.Books");
            //DropTable("dbo.Authors");
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




        }
    }
}
