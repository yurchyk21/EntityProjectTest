using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityProjectTest.Entities.Views.Filters;
namespace EntityProjectTest.Entities
{

    public class EFContext :DbContext
    {
        public EFContext() : base ("MyConnection")
        {

        }
        #region Tables

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<FilterName> FilterName { get; set; }
        public DbSet<Filters> Filters { get; set; }
        public DbSet<FilterValue> FilterValue { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<FilterNameGroup> FilterNameGroup { get; set; }
        public DbSet<Category> Category { get; set; }
        #endregion

        #region Views
        public DbSet<VFilterNameGroup> VFilterNameGroup { get; set; }
        #endregion

    }
}
