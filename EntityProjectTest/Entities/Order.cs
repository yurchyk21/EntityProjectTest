using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityProjectTest.Entities
{
        [Table("tblOrders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateCreate { get; set; }

        [ForeignKey("UserProfiles")]
        public int UserProfileId { get; set; }
        public virtual UserProfile UserProfiles { get; set; }

        [ForeignKey("OrderStatus")]
        public int OrderStatusId { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }

    }
}
