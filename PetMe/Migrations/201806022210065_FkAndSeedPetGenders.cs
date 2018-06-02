namespace PetMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FkAndSeedPetGenders : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "PetGenderId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Pets", "PetGenderId");
            AddForeignKey("dbo.Pets", "PetGenderId", "dbo.PetGenders", "Id", cascadeDelete: false);

            Sql("INSERT INTO dbo.PetGenders (Id, Name) Values (1,'Macho'),(2,'Fêmea');");
        }
        
        public override void Down()
        {
        }
    }
}
