namespace PetMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PetPictures : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PetPictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PetId = c.Int(nullable: false),
                        Picture = c.Binary(),
                        MainPic = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pets", t => t.PetId, cascadeDelete: true)
                .Index(t => t.PetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PetPictures", "PetId", "dbo.Pets");
            DropIndex("dbo.PetPictures", new[] { "PetId" });
            DropTable("dbo.PetPictures");
        }
    }
}
