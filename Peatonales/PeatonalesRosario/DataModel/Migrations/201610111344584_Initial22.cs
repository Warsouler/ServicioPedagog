namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial22 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
            DropTable("dbo.Cities");

            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Year = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Genre = c.String(),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId);

            CreateTable(
                "dbo.Cities",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    Country = c.String(),
                    Population01 = c.Int(nullable: false),
                    Population05 = c.Int(nullable: false),
                    Population10 = c.Int(nullable: false),
                    Population15 = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
               "dbo.Users",
               u => new
               {
                   UserId = u.Int(nullable: false, identity: true),
                   UserName = u.String(nullable: false),
                   Password = u.String(),
                   Name = u.String(nullable: false),
                   
               })
               .PrimaryKey(t => t.UserId);

            CreateTable(
               "dbo.Tokens",
               u => new
               {
                   TokenId = u.Int(nullable: false, identity: true),
                   AuthToken = u.String(nullable: false, maxLength: 255),
                   IssuedOn = u.DateTime(nullable: false),
                   ExpiresOn = u.DateTime(nullable: false),
                   UserId = u.Int(nullable: false),

               })
               .PrimaryKey(t => t.TokenId)
               .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);


        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
            DropTable("dbo.Cities");
        }

        
    }
}
