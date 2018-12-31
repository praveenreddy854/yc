namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Name = c.String(),
                        ImageUrl = c.String(),
                        AmazonInUrl = c.String(),
                        AmazonInPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaytmUrl = c.String(),
                        PaytmPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ProductFeatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        FeatureId = c.Int(nullable: false),
                        SubFeature_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Features", t => t.FeatureId, cascadeDelete: true)
                .ForeignKey("dbo.SubFeatures", t => t.SubFeature_Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.FeatureId)
                .Index(t => t.SubFeature_Id);
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubFeatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MainFeatureId = c.Int(nullable: false),
                        Feature_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Features", t => t.Feature_Id)
                .Index(t => t.Feature_Id);
            
            CreateTable(
                "dbo.ProductSubFeatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        SubFeatureId = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.SubFeatures", t => t.SubFeatureId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.SubFeatureId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductSubFeatures", "SubFeatureId", "dbo.SubFeatures");
            DropForeignKey("dbo.ProductSubFeatures", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductFeatures", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductFeatures", "SubFeature_Id", "dbo.SubFeatures");
            DropForeignKey("dbo.SubFeatures", "Feature_Id", "dbo.Features");
            DropForeignKey("dbo.ProductFeatures", "FeatureId", "dbo.Features");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.ProductSubFeatures", new[] { "SubFeatureId" });
            DropIndex("dbo.ProductSubFeatures", new[] { "ProductId" });
            DropIndex("dbo.SubFeatures", new[] { "Feature_Id" });
            DropIndex("dbo.ProductFeatures", new[] { "SubFeature_Id" });
            DropIndex("dbo.ProductFeatures", new[] { "FeatureId" });
            DropIndex("dbo.ProductFeatures", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.ProductSubFeatures");
            DropTable("dbo.SubFeatures");
            DropTable("dbo.Features");
            DropTable("dbo.ProductFeatures");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
