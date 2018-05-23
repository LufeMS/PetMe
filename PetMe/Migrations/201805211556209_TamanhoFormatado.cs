namespace PetMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TamanhoFormatado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FormOk", c => c.Boolean());
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String(maxLength: 35));
            AlterColumn("dbo.AspNetUsers", "Surname", c => c.String(maxLength: 35));
            AlterColumn("dbo.AspNetUsers", "DocumentNumber", c => c.String(maxLength: 14));
            AlterColumn("dbo.AspNetUsers", "Address", c => c.String(maxLength: 65));
            AlterColumn("dbo.AspNetUsers", "AddressNumber", c => c.String(maxLength: 8));
            AlterColumn("dbo.AspNetUsers", "AddressComplement", c => c.String(maxLength: 100));
            AlterColumn("dbo.AspNetUsers", "District", c => c.String(maxLength: 50));
            AlterColumn("dbo.AspNetUsers", "ZipCode", c => c.String(maxLength: 8));
            AlterColumn("dbo.AspNetUsers", "City", c => c.String(maxLength: 50));
            AlterColumn("dbo.AspNetUsers", "State", c => c.String(maxLength: 50));
            DropColumn("dbo.AspNetUsers", "Gender");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Gender", c => c.String());
            AlterColumn("dbo.AspNetUsers", "State", c => c.String());
            AlterColumn("dbo.AspNetUsers", "City", c => c.String());
            AlterColumn("dbo.AspNetUsers", "ZipCode", c => c.String());
            AlterColumn("dbo.AspNetUsers", "District", c => c.String());
            AlterColumn("dbo.AspNetUsers", "AddressComplement", c => c.String());
            AlterColumn("dbo.AspNetUsers", "AddressNumber", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Address", c => c.String());
            AlterColumn("dbo.AspNetUsers", "DocumentNumber", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Surname", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String());
            DropColumn("dbo.AspNetUsers", "FormOk");
        }
    }
}
