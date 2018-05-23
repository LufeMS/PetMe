namespace PetMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class petfix : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Pets", new[] { "Dono_Id" });
            DropColumn("dbo.Pets", "DonoId");
            RenameColumn(table: "dbo.Pets", name: "Dono_Id", newName: "DonoId");
            AlterColumn("dbo.Pets", "DonoId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Pets", "DetailsSpecCare", c => c.String());
            AlterColumn("dbo.Pets", "MoreDetails", c => c.String());
            CreateIndex("dbo.Pets", "DonoId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Pets", new[] { "DonoId" });
            AlterColumn("dbo.Pets", "MoreDetails", c => c.String(nullable: false));
            AlterColumn("dbo.Pets", "DetailsSpecCare", c => c.String(nullable: false));
            AlterColumn("dbo.Pets", "DonoId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Pets", name: "DonoId", newName: "Dono_Id");
            AddColumn("dbo.Pets", "DonoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pets", "Dono_Id");
        }
    }
}
