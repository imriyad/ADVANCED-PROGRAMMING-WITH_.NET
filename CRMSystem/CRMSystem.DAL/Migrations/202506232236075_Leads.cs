namespace CRMSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Leads : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "FullName", c => c.String());
            AddColumn("dbo.Contacts", "CreatedAt", c => c.DateTime(nullable: false));
            DropColumn("dbo.Contacts", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "Name", c => c.String());
            DropColumn("dbo.Contacts", "CreatedAt");
            DropColumn("dbo.Contacts", "FullName");
        }
    }
}
