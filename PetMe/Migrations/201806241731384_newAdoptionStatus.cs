namespace PetMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newAdoptionStatus : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.AdoptionStatus (Name, Details) VALUES ('Aguardando transferencia', null)");
        }
        
        public override void Down()
        {
        }
    }
}
