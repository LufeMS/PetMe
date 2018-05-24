namespace PetMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkstate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pets", "StateId", "dbo.States");
            DropIndex("dbo.Pets", new[] { "StateId" });
            DropColumn("dbo.Pets", "StateId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pets", "StateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pets", "StateId");
            AddForeignKey("dbo.Pets", "StateId", "dbo.States", "Id", cascadeDelete: true);
        }
    }
}
