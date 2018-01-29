namespace EntityProjectTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddtblCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblCategories", t => t.ParentId)
                .Index(t => t.ParentId);
            
            AddColumn("dbo.tblProducts", "Category_Id", c => c.Int());
            CreateIndex("dbo.tblProducts", "Category_Id");
            AddForeignKey("dbo.tblProducts", "Category_Id", "dbo.tblCategories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblProducts", "Category_Id", "dbo.tblCategories");
            DropForeignKey("dbo.tblCategories", "ParentId", "dbo.tblCategories");
            DropIndex("dbo.tblProducts", new[] { "Category_Id" });
            DropIndex("dbo.tblCategories", new[] { "ParentId" });
            DropColumn("dbo.tblProducts", "Category_Id");
            DropTable("dbo.tblCategories");
        }
    }
}
