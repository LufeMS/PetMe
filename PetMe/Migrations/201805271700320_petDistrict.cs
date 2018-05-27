namespace PetMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class petDistrict : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "District", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pets", "District");
        }
    }
}
