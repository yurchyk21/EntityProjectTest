namespace EntityProjectTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alltables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblCarts",
                c => new
                    {
                        UserProfileId = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserProfileId)
                .ForeignKey("dbo.tblUserProfiles", t => t.UserProfileId)
                .Index(t => t.UserProfileId);
            
            CreateTable(
                "dbo.tblUserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Image = c.String(nullable: false, maxLength: 128),
                        Telephone = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreate = c.DateTime(nullable: false),
                        UserProfileId = c.Int(nullable: false),
                        OrderStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblOrderStatuses", t => t.OrderStatusId, cascadeDelete: true)
                .ForeignKey("dbo.tblUserProfiles", t => t.UserProfileId, cascadeDelete: true)
                .Index(t => t.UserProfileId)
                .Index(t => t.OrderStatusId);
            
            CreateTable(
                "dbo.tblOrderStatuses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblFilterNames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblFilters",
                c => new
                    {
                        FilternameId = c.Int(nullable: false),
                        FilterValueId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FilternameId, t.FilterValueId, t.ProductId })
                .ForeignKey("dbo.tblFilterNames", t => t.FilternameId, cascadeDelete: true)
                .ForeignKey("dbo.tblFilterValue", t => t.FilterValueId, cascadeDelete: true)
                .ForeignKey("dbo.tblProducts", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.FilternameId)
                .Index(t => t.FilterValueId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.tblFilterValue",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Quantity = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleUserProfiles",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        UserProfile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.UserProfile_Id })
                .ForeignKey("dbo.tblRoles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.tblUserProfiles", t => t.UserProfile_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.UserProfile_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblFilters", "ProductId", "dbo.tblProducts");
            DropForeignKey("dbo.tblFilters", "FilterValueId", "dbo.tblFilterValue");
            DropForeignKey("dbo.tblFilters", "FilternameId", "dbo.tblFilterNames");
            DropForeignKey("dbo.tblCarts", "UserProfileId", "dbo.tblUserProfiles");
            DropForeignKey("dbo.RoleUserProfiles", "UserProfile_Id", "dbo.tblUserProfiles");
            DropForeignKey("dbo.RoleUserProfiles", "Role_Id", "dbo.tblRoles");
            DropForeignKey("dbo.tblOrders", "UserProfileId", "dbo.tblUserProfiles");
            DropForeignKey("dbo.tblOrders", "OrderStatusId", "dbo.tblOrderStatuses");
            DropIndex("dbo.RoleUserProfiles", new[] { "UserProfile_Id" });
            DropIndex("dbo.RoleUserProfiles", new[] { "Role_Id" });
            DropIndex("dbo.tblFilters", new[] { "ProductId" });
            DropIndex("dbo.tblFilters", new[] { "FilterValueId" });
            DropIndex("dbo.tblFilters", new[] { "FilternameId" });
            DropIndex("dbo.tblOrders", new[] { "OrderStatusId" });
            DropIndex("dbo.tblOrders", new[] { "UserProfileId" });
            DropIndex("dbo.tblCarts", new[] { "UserProfileId" });
            DropTable("dbo.RoleUserProfiles");
            DropTable("dbo.tblProducts");
            DropTable("dbo.tblFilterValue");
            DropTable("dbo.tblFilters");
            DropTable("dbo.tblFilterNames");
            DropTable("dbo.tblRoles");
            DropTable("dbo.tblOrderStatuses");
            DropTable("dbo.tblOrders");
            DropTable("dbo.tblUserProfiles");
            DropTable("dbo.tblCarts");
        }
    }
}
