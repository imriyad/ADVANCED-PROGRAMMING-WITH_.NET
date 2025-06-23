namespace CRMSystem.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Contacts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sales", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Sales", new[] { "ContactId" });
            AddColumn("dbo.Sales", "LeadId", c => c.Int(nullable: false));
            AddColumn("dbo.Sales", "SaleDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sales", "Description", c => c.String());
            DropColumn("dbo.Sales", "Product");
            DropColumn("dbo.Sales", "Date");
            DropColumn("dbo.Sales", "ContactId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "ContactId", c => c.Int(nullable: false));
            AddColumn("dbo.Sales", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Sales", "Product", c => c.String());
            DropColumn("dbo.Sales", "Description");
            DropColumn("dbo.Sales", "SaleDate");
            DropColumn("dbo.Sales", "LeadId");
            CreateIndex("dbo.Sales", "ContactId");
            AddForeignKey("dbo.Sales", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
        }
    }
}
