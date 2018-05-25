namespace PetMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedStateCounty : DbMigration
    {
        public override void Up()
        {
            Sql(@"Insert into dbo.States (UFCode, Name, Abbreviation) values (12, 'Acre', 'AC');");
            Sql(@"Insert into dbo.States (UFCode, Name, Abbreviation) values (27, 'Alagoas', 'AL');");
            Sql(@"Insert into dbo.States (UFCode, Name, Abbreviation) values (16, 'Amap�', 'AP');");
            Sql(@"Insert into dbo.States (UFCode, Name, Abbreviation) values (13, 'Amazonas', 'AM');");
            Sql(@"Insert into dbo.States (UFCode, Name, Abbreviation) values (29, 'Bahia', 'BA');");
            Sql(@"Insert into dbo.States (UFCode, Name, Abbreviation) values (23, 'Cear�', 'CE');");
            Sql(@"Insert into dbo.States (UFCode, Name, Abbreviation) values (53, 'Distrito Federal', 'DF');");
            Sql(@"Insert into dbo.States (UFCode, Name, Abbreviation) values (32, 'Esp�rito Santo', 'ES');");
            Sql(@"Insert into dbo.States (UFCode, Name, Abbreviation) values (52, 'Goi�s', 'GO');");
            Sql(@"Insert into dbo.States (UFCode, Name, Abbreviation) values (21, 'Maranh�o', 'MA');");
            Sql(@"Insert into dbo.States (UFCode, Name, Abbreviation) values (51, 'Mato Grosso', 'MT');");
            Sql(@"Insert into dbo.States (UFCode, Name, Abbreviation) values (50, 'Mato Grosso do Sul', 'MS');");
            Sql(@"Insert into dbo.States (UFCode, Name, Abbreviation) values (31, 'Minas Gerais', 'MG');");
            Sql(@"Insert into dbo.States (UFCode, Name, Abbreviation) values (15, 'Par�', 'PA');");
            Sql(@"Insert into dbo.States (UFCode, Name, Abbreviation) values (25, 'Para�ba', 'PB');");
            Sql(@"Insert into dbo.States (UFCode, Name, Abbreviation) values (41, 'Paran�', 'PR');");
            Sql(@"Insert into dbo.States (UFCode, Name, Abbreviation) values (26, 'Pernambuco', 'PE');");
            Sql(@"Insert into dbo.States (UFCode, Name, Abbreviation) values (22, 'Piau�', 'PI');");
            Sql(@"Insert into dbo.States (UFCode, Name, Abbreviation) values (33, 'Rio de Janeiro', 'RJ');");
            Sql(@"Insert into dbo.States (UFCode, Name, Abbreviation) values (24, 'Rio Grande do Norte', 'RN');");
            Sql(@"Insert into dbo.States (UFCode, Name, Abbreviation) values (43, 'Rio Grande do Sul', 'RS');");
            Sql(@"Insert into dbo.States (UFCode, Name, Abbreviation) values (11, 'Rond�nia', 'RO');");
            Sql(@"Insert into dbo.States (UFCode, Name, Abbreviation) values (14, 'Roraima', 'RR');");
            Sql(@"Insert into dbo.States (UFCode, Name, Abbreviation) values (42, 'Santa Catarina', 'SC');");
            Sql(@"Insert into dbo.States (UFCode, Name, Abbreviation) values (35, 'S�o Paulo', 'SP');");
            Sql(@"Insert into dbo.States (UFCode, Name, Abbreviation) values (28, 'Sergipe', 'SE');");
            Sql(@"Insert into dbo.States (UFCode, Name, Abbreviation) values (17, 'Tocantins', 'TO');");

        }

        public override void Down()
        {
        }
    }
}
