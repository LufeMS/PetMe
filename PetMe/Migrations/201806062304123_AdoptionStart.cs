namespace PetMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdoptionStart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdoptionMails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdoptionId = c.Int(nullable: false),
                        SenderId = c.String(maxLength: 128),
                        ReceiverId = c.String(maxLength: 128),
                        Text = c.String(nullable: false),
                        SentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Adoptions", t => t.AdoptionId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ReceiverId)
                .ForeignKey("dbo.AspNetUsers", t => t.SenderId)
                .Index(t => t.AdoptionId)
                .Index(t => t.SenderId)
                .Index(t => t.ReceiverId);
            
            CreateTable(
                "dbo.Adoptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InterestedUserId = c.String(maxLength: 128),
                        PetOwnerId = c.String(maxLength: 128),
                        AnimalId = c.Int(nullable: false),
                        AdoptionStatusId = c.Int(nullable: false),
                        AdoptionStart = c.DateTime(nullable: false),
                        AdoptionEnd = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdoptionStatus", t => t.AdoptionStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Pets", t => t.AnimalId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.InterestedUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.PetOwnerId)
                .Index(t => t.InterestedUserId)
                .Index(t => t.PetOwnerId)
                .Index(t => t.AnimalId)
                .Index(t => t.AdoptionStatusId);
            
            CreateTable(
                "dbo.AdoptionStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdoptionMails", "SenderId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AdoptionMails", "ReceiverId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AdoptionMails", "AdoptionId", "dbo.Adoptions");
            DropForeignKey("dbo.Adoptions", "PetOwnerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Adoptions", "InterestedUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Adoptions", "AnimalId", "dbo.Pets");
            DropForeignKey("dbo.Adoptions", "AdoptionStatusId", "dbo.AdoptionStatus");
            DropIndex("dbo.Adoptions", new[] { "AdoptionStatusId" });
            DropIndex("dbo.Adoptions", new[] { "AnimalId" });
            DropIndex("dbo.Adoptions", new[] { "PetOwnerId" });
            DropIndex("dbo.Adoptions", new[] { "InterestedUserId" });
            DropIndex("dbo.AdoptionMails", new[] { "ReceiverId" });
            DropIndex("dbo.AdoptionMails", new[] { "SenderId" });
            DropIndex("dbo.AdoptionMails", new[] { "AdoptionId" });
            DropTable("dbo.AdoptionStatus");
            DropTable("dbo.Adoptions");
            DropTable("dbo.AdoptionMails");
        }
    }
}
