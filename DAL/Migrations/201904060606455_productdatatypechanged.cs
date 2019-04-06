namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productdatatypechanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "AmazonInPrice", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Products", "PaytmPrice", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "PaytmPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "AmazonInPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
