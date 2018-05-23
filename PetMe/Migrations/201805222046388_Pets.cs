namespace PetMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DonoId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Age = c.Byte(nullable: false),
                        Subspecies = c.String(nullable: false),
                        Color = c.String(nullable: false),
                        Weight = c.Single(nullable: false),
                        Size = c.String(nullable: false),
                        Vaccinated = c.Boolean(nullable: false),
                        Trained = c.Boolean(nullable: false),
                        Castrated = c.Boolean(nullable: false),
                        SpecialCare = c.Boolean(nullable: false),
                        DetailsSpecCare = c.String(nullable: false),    
                        MoreDetails = c.String(nullable: false),
                        DateOfPublication = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Dono_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Dono_Id)
                .Index(t => t.Dono_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pets", "Dono_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Pets", new[] { "Dono_Id" });
            DropTable("dbo.Pets");
        }
    }
}
