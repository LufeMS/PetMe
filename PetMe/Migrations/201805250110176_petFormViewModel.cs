namespace PetMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class petFormViewModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pets", "ZipCode", c => c.String(nullable: false, maxLength: 8));
            AlterColumn("dbo.Pets", "Address", c => c.String(nullable: false, maxLength: 65));
            AlterColumn("dbo.Pets", "AddressNumber", c => c.String(nullable: false, maxLength: 8));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pets", "AddressNumber", c => c.String(maxLength: 8));
            AlterColumn("dbo.Pets", "Address", c => c.String(maxLength: 65));
            AlterColumn("dbo.Pets", "ZipCode", c => c.String(maxLength: 8));
        }
    }
}
