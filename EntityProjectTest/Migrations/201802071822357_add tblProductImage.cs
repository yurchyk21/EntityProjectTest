namespace EntityProjectTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtblProductImage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblProductImage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblProducts", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblProductImage", "ProductId", "dbo.tblProducts");
            DropIndex("dbo.tblProductImage", new[] { "ProductId" });
            DropTable("dbo.tblProductImage");
        }
    }
}
