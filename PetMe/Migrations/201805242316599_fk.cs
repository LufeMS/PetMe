namespace PetMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fk : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Pets", "PetTypeId");
            CreateIndex("dbo.Pets", "PetBreedTypeId");
            CreateIndex("dbo.Pets", "PetSizeId");
            CreateIndex("dbo.Pets", "CountyId");
            CreateIndex("dbo.Pets", "StateId");
            AddForeignKey("dbo.Pets", "CountyId", "dbo.Counties", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Pets", "PetBreedTypeId", "dbo.PetBreedTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Pets", "PetSizeId", "dbo.PetSizes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Pets", "PetTypeId", "dbo.PetTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Pets", "StateId", "dbo.States", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pets", "StateId", "dbo.States");
            DropForeignKey("dbo.Pets", "PetTypeId", "dbo.PetTypes");
            DropForeignKey("dbo.Pets", "PetSizeId", "dbo.PetSizes");
            DropForeignKey("dbo.Pets", "PetBreedTypeId", "dbo.PetBreedTypes");
            DropForeignKey("dbo.Pets", "CountyId", "dbo.Counties");
            DropIndex("dbo.Pets", new[] { "StateId" });
            DropIndex("dbo.Pets", new[] { "CountyId" });
            DropIndex("dbo.Pets", new[] { "PetSizeId" });
            DropIndex("dbo.Pets", new[] { "PetBreedTypeId" });
            DropIndex("dbo.Pets", new[] { "PetTypeId" });
        }
    }
}
