namespace PetMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FormUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 35));
            DropColumn("dbo.AspNetUsers", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(maxLength: 35));
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
