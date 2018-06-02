namespace PetMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PetGenders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PetGenders",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pets", "PetGenderId", "dbo.PetGenders");
            DropIndex("dbo.Pets", new[] { "PetGenderId" });
            DropColumn("dbo.Pets", "PetGenderId");
            DropTable("dbo.PetGenders");
        }
    }
}
