namespace PetMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PetRefactoring : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pets", "DonoId", "dbo.AspNetUsers");
            DropIndex("dbo.Pets", new[] { "DonoId" });
            RenameColumn(table: "dbo.Pets", name: "DonoId", newName: "OwnerId");
            AddColumn("dbo.Pets", "AgeInMonths", c => c.Byte(nullable: false));
            AddColumn("dbo.Pets", "DetailsSCare", c => c.String());
            AddColumn("dbo.Pets", "Description", c => c.String());
            AddColumn("dbo.Pets", "LivesWithOwner", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pets", "ZipCode", c => c.String(maxLength: 8));
            AddColumn("dbo.Pets", "Address", c => c.String(maxLength: 65));
            AddColumn("dbo.Pets", "AddressNumber", c => c.String(maxLength: 8));
            AddColumn("dbo.Pets", "AddressComplement", c => c.String(maxLength: 50));
            AddColumn("dbo.Pets", "AddedIn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Pets", "OwnerId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Pets", "Color", c => c.String());
            AlterColumn("dbo.Pets", "Active", c => c.Boolean(nullable: false));
            AlterColumn("dbo.AspNetUsers", "AddressComplement", c => c.String(maxLength: 50));
            CreateIndex("dbo.Pets", "OwnerId");
            AddForeignKey("dbo.Pets", "OwnerId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Pets", "Age");
            DropColumn("dbo.Pets", "Subspecies");
            DropColumn("dbo.Pets", "Weight");
            DropColumn("dbo.Pets", "Size");
            DropColumn("dbo.Pets", "DetailsSpecCare");
            DropColumn("dbo.Pets", "MoreDetails");
            DropColumn("dbo.Pets", "DateOfPublication");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pets", "DateOfPublication", c => c.DateTime(nullable: false));
            AddColumn("dbo.Pets", "MoreDetails", c => c.String());
            AddColumn("dbo.Pets", "DetailsSpecCare", c => c.String());
            AddColumn("dbo.Pets", "Size", c => c.String(nullable: false));
            AddColumn("dbo.Pets", "Weight", c => c.Single(nullable: false));
            AddColumn("dbo.Pets", "Subspecies", c => c.String(nullable: false));
            AddColumn("dbo.Pets", "Age", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Pets", "OwnerId", "dbo.AspNetUsers");
            DropIndex("dbo.Pets", new[] { "OwnerId" });
            AlterColumn("dbo.AspNetUsers", "AddressComplement", c => c.String(maxLength: 100));
            AlterColumn("dbo.Pets", "Active", c => c.Boolean());
            AlterColumn("dbo.Pets", "Color", c => c.String(nullable: false));
            AlterColumn("dbo.Pets", "OwnerId", c => c.String(maxLength: 128));
            DropColumn("dbo.Pets", "AddedIn");
            DropColumn("dbo.Pets", "AddressComplement");
            DropColumn("dbo.Pets", "AddressNumber");
            DropColumn("dbo.Pets", "Address");
            DropColumn("dbo.Pets", "ZipCode");
            DropColumn("dbo.Pets", "LivesWithOwner");
            DropColumn("dbo.Pets", "Description");
            DropColumn("dbo.Pets", "DetailsSCare");
            DropColumn("dbo.Pets", "AgeInMonths");
            RenameColumn(table: "dbo.Pets", name: "OwnerId", newName: "DonoId");
            CreateIndex("dbo.Pets", "DonoId");
            AddForeignKey("dbo.Pets", "DonoId", "dbo.AspNetUsers", "Id");
        }
    }
}
