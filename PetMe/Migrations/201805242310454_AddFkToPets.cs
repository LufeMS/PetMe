namespace PetMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFkToPets : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "PetTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Pets", "PetBreedTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Pets", "BreedDetail", c => c.String());
            AddColumn("dbo.Pets", "PetSizeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Pets", "CountyId", c => c.Int(nullable: false));
            AddColumn("dbo.Pets", "StateId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pets", "StateId");
            DropColumn("dbo.Pets", "CountyId");
            DropColumn("dbo.Pets", "PetSizeId");
            DropColumn("dbo.Pets", "BreedDetail");
            DropColumn("dbo.Pets", "PetBreedTypeId");
            DropColumn("dbo.Pets", "PetTypeId");
        }
    }
}
