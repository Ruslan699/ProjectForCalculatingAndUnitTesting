namespace AteshgahApp.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientUniqueId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 30),
                        Surname = c.String(nullable: false, maxLength: 30),
                        TelephoneNr = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.ClientUniqueId);
            
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, storeType: "money"),
                        InterestRate = c.Decimal(nullable: false, precision: 5, scale: 2),
                        LoanPeriod = c.Int(nullable: false),
                        PayoutDate = c.DateTime(nullable: false),
                        ClientId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, storeType: "money"),
                        DueDate = c.DateTime(nullable: false),
                        InvoiceNr = c.Int(nullable: false),
                        OrderNr = c.Int(nullable: false),
                        LoanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Loans", t => t.LoanId)
                .Index(t => t.LoanId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loans", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Invoices", "LoanId", "dbo.Loans");
            DropIndex("dbo.Invoices", new[] { "LoanId" });
            DropIndex("dbo.Loans", new[] { "ClientId" });
            DropTable("dbo.Invoices");
            DropTable("dbo.Loans");
            DropTable("dbo.Clients");
        }
    }
}
