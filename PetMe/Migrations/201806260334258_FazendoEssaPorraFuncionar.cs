namespace PetMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FazendoEssaPorraFuncionar : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pets", "OwnerId", "dbo.AspNetUsers");
            DropIndex("dbo.Pets", new[] { "OwnerId" });
            AlterColumn("dbo.Pets", "OwnerId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Pets", "Name", c => c.String());
            AlterColumn("dbo.Pets", "ZipCode", c => c.String(maxLength: 8));
            AlterColumn("dbo.Pets", "Address", c => c.String(maxLength: 65));
            AlterColumn("dbo.Pets", "AddressNumber", c => c.String(maxLength: 8));
            AlterColumn("dbo.Pets", "District", c => c.String());
            CreateIndex("dbo.Pets", "OwnerId");
            AddForeignKey("dbo.Pets", "OwnerId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pets", "OwnerId", "dbo.AspNetUsers");
            DropIndex("dbo.Pets", new[] { "OwnerId" });
            AlterColumn("dbo.Pets", "District", c => c.String(nullable: false));
            AlterColumn("dbo.Pets", "AddressNumber", c => c.String(nullable: false, maxLength: 8));
            AlterColumn("dbo.Pets", "Address", c => c.String(nullable: false, maxLength: 65));
            AlterColumn("dbo.Pets", "ZipCode", c => c.String(nullable: false, maxLength: 8));
            AlterColumn("dbo.Pets", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Pets", "OwnerId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Pets", "OwnerId");
            AddForeignKey("dbo.Pets", "OwnerId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
