namespace WeddingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEnquiryAndEnquiryCategoryClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enquiries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        EnquiryCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EnquiryCategories", t => t.EnquiryCategoryId, cascadeDelete: true)
                .Index(t => t.EnquiryCategoryId);
            
            CreateTable(
                "dbo.EnquiryCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enquiries", "EnquiryCategoryId", "dbo.EnquiryCategories");
            DropIndex("dbo.Enquiries", new[] { "EnquiryCategoryId" });
            DropTable("dbo.EnquiryCategories");
            DropTable("dbo.Enquiries");
        }
    }
}
