namespace PetMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedDbPets : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO dbo.PetSizes (Id, Name) Values (1,'Pequeno'), (2,'Médio'), (3,'Grande')");
            Sql(@"INSERT INTO dbo.PetBreedTypes (Id, Name) Values (1,'Pura'), (2,'Mista')");
            Sql(@"INSERT INTO dbo.PetTypes (Id, Name) Values (1,'Cachorro')
                                                            ,(2,'Gato')
                                                            ,(3,'Furão')
                                                            ,(4,'Mico')
                                                            ,(5,'Coelho')
                                                            ,(6,'Hamster')
                                                            ,(7,'Rato')
                                                            ,(8,'Camundongo')
                                                            ,(9,'Porco da Índia')
                                                            ,(10,'Porco doméstico')
                                                            ,(11,'Chinchila')
                                                            ,(12,'Gerbil')
                                                            ,(13,'Esquilo')
                                                            ,(14,'Cavalo')
                                                            ,(15,'Piriquitos')
                                                            ,(16,'Canário')
                                                            ,(17,'Calopsita')
                                                            ,(18,'Cacatuas')
                                                            ,(19,'Papagaios')
                                                            ,(20,'Galinha/Galo')
                                                            ,(21,'Peru')
                                                            ,(22,'Arara')
                                                            ,(23,'Mandarim')
                                                            ,(24,'Agapornis')
                                                            ,(25,'Pardal doméstico')
                                                            ,(26,'Galah')
                                                            ,(27,'Calafate')
                                                            ,(28,'Cardeal')
                                                            ,(29,'Curió')
                                                            ,(30,'Canário-da-terra')
                                                            ,(31,'Cágado')
                                                            ,(32,'Tartaruga')
                                                            ,(33,'Jabuti')
                                                            ,(34,'Lagarto')
                                                            ,(35,'Cobra')
                                                            ,(36,'Sapo')
                                                            ,(37,'Perereca')
                                                            ,(38,'Salamandra')
                                                            ,(39,'Betta')
                                                            ,(40,'Kinguio')
                                                            ,(41,'Carpa')
                                                            ,(42,'Barbo')
                                                            ,(43,'Peixe-palhaço')
                                                            ,(44,'Tetra')
                                                            ,(45,'Acará')
                                                            ,(46,'Oscar')
                                                            ,(47,'Cascudo')
                                                            ,(48,'Coridora')
                                                            ,(49,'Tarântula')");
        }
        
        public override void Down()
        {
        }
    }
}
