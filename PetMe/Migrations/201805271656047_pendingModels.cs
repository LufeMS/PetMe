namespace PetMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pendingModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserGenders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "GenderId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "CountyId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "StateId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "GenderId");
            CreateIndex("dbo.AspNetUsers", "CountyId");
            CreateIndex("dbo.AspNetUsers", "StateId");
            AddForeignKey("dbo.AspNetUsers", "CountyId", "dbo.Counties", "Id");
            AddForeignKey("dbo.AspNetUsers", "GenderId", "dbo.UserGenders", "Id");
            AddForeignKey("dbo.AspNetUsers", "StateId", "dbo.States", "Id");
            DropColumn("dbo.AspNetUsers", "Avatar");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "State");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "State", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "City", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "Avatar", c => c.Binary());
            DropForeignKey("dbo.AspNetUsers", "StateId", "dbo.States");
            DropForeignKey("dbo.AspNetUsers", "GenderId", "dbo.UserGenders");
            DropForeignKey("dbo.AspNetUsers", "CountyId", "dbo.Counties");
            DropIndex("dbo.AspNetUsers", new[] { "StateId" });
            DropIndex("dbo.AspNetUsers", new[] { "CountyId" });
            DropIndex("dbo.AspNetUsers", new[] { "GenderId" });
            DropColumn("dbo.AspNetUsers", "StateId");
            DropColumn("dbo.AspNetUsers", "CountyId");
            DropColumn("dbo.AspNetUsers", "GenderId");
            DropTable("dbo.UserGenders");
        }
    }
}
