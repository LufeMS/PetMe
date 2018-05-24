namespace PetMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkstate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "StateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pets", "StateId");
            AddForeignKey("dbo.Pets", "StateId", "dbo.States", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pets", "StateId", "dbo.States");
            DropIndex("dbo.Pets", new[] { "StateId" });
            DropColumn("dbo.Pets", "StateId");
        }
    }
}
