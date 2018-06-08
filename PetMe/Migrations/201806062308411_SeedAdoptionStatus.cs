namespace PetMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAdoptionStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdoptionStatus", "Name", c => c.String(nullable: false));
            AddColumn("dbo.AdoptionStatus", "Details", c => c.String());
            DropColumn("dbo.AdoptionStatus", "Description");

            Sql("INSERT INTO dbo.AdoptionStatus (Name) VALUES ('Aguardando aceita��o da proposta'), ('Ado��o em andamento'), ('Ado��o finalizada com sucesso'), ('Ado��o Cancelada')");
        }

        public override void Down()
        {
            AddColumn("dbo.AdoptionStatus", "Description", c => c.String());
            DropColumn("dbo.AdoptionStatus", "Details");
            DropColumn("dbo.AdoptionStatus", "Name");
        }
    }
}
