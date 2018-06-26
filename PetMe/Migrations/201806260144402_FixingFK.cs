namespace PetMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingFK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pets", "CountyId", "dbo.Counties");
            DropForeignKey("dbo.Pets", "PetBreedTypeId", "dbo.PetBreedTypes");
            DropForeignKey("dbo.Pets", "PetGenderId", "dbo.PetGenders");
            DropForeignKey("dbo.Pets", "PetSizeId", "dbo.PetSizes");
            DropForeignKey("dbo.Pets", "PetTypeId", "dbo.PetTypes");
            DropForeignKey("dbo.Pets", "StateId", "dbo.States");
            DropIndex("dbo.Pets", new[] { "PetTypeId" });
            DropIndex("dbo.Pets", new[] { "PetBreedTypeId" });
            DropIndex("dbo.Pets", new[] { "PetSizeId" });
            DropIndex("dbo.Pets", new[] { "PetGenderId" });
            DropIndex("dbo.Pets", new[] { "CountyId" });
            DropIndex("dbo.Pets", new[] { "StateId" });
            AlterColumn("dbo.Pets", "PetTypeId", c => c.Byte());
            AlterColumn("dbo.Pets", "PetBreedTypeId", c => c.Byte());
            AlterColumn("dbo.Pets", "PetSizeId", c => c.Byte());
            AlterColumn("dbo.Pets", "PetGenderId", c => c.Byte());
            AlterColumn("dbo.Pets", "CountyId", c => c.Int());
            AlterColumn("dbo.Pets", "StateId", c => c.Int());
            CreateIndex("dbo.Pets", "PetTypeId");
            CreateIndex("dbo.Pets", "PetBreedTypeId");
            CreateIndex("dbo.Pets", "PetSizeId");
            CreateIndex("dbo.Pets", "PetGenderId");
            CreateIndex("dbo.Pets", "CountyId");
            CreateIndex("dbo.Pets", "StateId");
            AddForeignKey("dbo.Pets", "CountyId", "dbo.Counties", "Id");
            AddForeignKey("dbo.Pets", "PetBreedTypeId", "dbo.PetBreedTypes", "Id");
            AddForeignKey("dbo.Pets", "PetGenderId", "dbo.PetGenders", "Id");
            AddForeignKey("dbo.Pets", "PetSizeId", "dbo.PetSizes", "Id");
            AddForeignKey("dbo.Pets", "PetTypeId", "dbo.PetTypes", "Id");
            AddForeignKey("dbo.Pets", "StateId", "dbo.States", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pets", "StateId", "dbo.States");
            DropForeignKey("dbo.Pets", "PetTypeId", "dbo.PetTypes");
            DropForeignKey("dbo.Pets", "PetSizeId", "dbo.PetSizes");
            DropForeignKey("dbo.Pets", "PetGenderId", "dbo.PetGenders");
            DropForeignKey("dbo.Pets", "PetBreedTypeId", "dbo.PetBreedTypes");
            DropForeignKey("dbo.Pets", "CountyId", "dbo.Counties");
            DropIndex("dbo.Pets", new[] { "StateId" });
            DropIndex("dbo.Pets", new[] { "CountyId" });
            DropIndex("dbo.Pets", new[] { "PetGenderId" });
            DropIndex("dbo.Pets", new[] { "PetSizeId" });
            DropIndex("dbo.Pets", new[] { "PetBreedTypeId" });
            DropIndex("dbo.Pets", new[] { "PetTypeId" });
            AlterColumn("dbo.Pets", "StateId", c => c.Int(nullable: false));
            AlterColumn("dbo.Pets", "CountyId", c => c.Int(nullable: false));
            AlterColumn("dbo.Pets", "PetGenderId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Pets", "PetSizeId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Pets", "PetBreedTypeId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Pets", "PetTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Pets", "StateId");
            CreateIndex("dbo.Pets", "CountyId");
            CreateIndex("dbo.Pets", "PetGenderId");
            CreateIndex("dbo.Pets", "PetSizeId");
            CreateIndex("dbo.Pets", "PetBreedTypeId");
            CreateIndex("dbo.Pets", "PetTypeId");
            AddForeignKey("dbo.Pets", "StateId", "dbo.States", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Pets", "PetTypeId", "dbo.PetTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Pets", "PetSizeId", "dbo.PetSizes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Pets", "PetGenderId", "dbo.PetGenders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Pets", "PetBreedTypeId", "dbo.PetBreedTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Pets", "CountyId", "dbo.Counties", "Id", cascadeDelete: true);
        }
    }
}
