namespace PetMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class genderSeed : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT into dbo.UserGenders (Name) values ('Masculino'), ('Feminino');");
        }
        
        public override void Down()
        {
        }
    }
}
