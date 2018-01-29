namespace EntityProjectTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddtblFilterNameGroups : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblFilterNameGroups",
                c => new
                    {
                        FilternameId = c.Int(nullable: false),
                        FilterValueId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FilternameId, t.FilterValueId })
                .ForeignKey("dbo.tblFilterNames", t => t.FilternameId, cascadeDelete: true)
                .ForeignKey("dbo.tblFilterValue", t => t.FilterValueId, cascadeDelete: true)
                .Index(t => t.FilternameId)
                .Index(t => t.FilterValueId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblFilterNameGroups", "FilterValueId", "dbo.tblFilterValue");
            DropForeignKey("dbo.tblFilterNameGroups", "FilternameId", "dbo.tblFilterNames");
            DropIndex("dbo.tblFilterNameGroups", new[] { "FilterValueId" });
            DropIndex("dbo.tblFilterNameGroups", new[] { "FilternameId" });
            DropTable("dbo.tblFilterNameGroups");
        }
    }
}
