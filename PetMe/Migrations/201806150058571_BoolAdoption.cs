namespace PetMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BoolAdoption : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adoptions", "InterestedUserPermission", c => c.Boolean(nullable: false));
            AddColumn("dbo.Adoptions", "PetOwnerPermission", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adoptions", "PetOwnerPermission");
            DropColumn("dbo.Adoptions", "InterestedUserPermission");
        }
    }
}
