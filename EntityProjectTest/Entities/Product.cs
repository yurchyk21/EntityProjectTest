using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityProjectTest.Entities
{
    [Table("tblProducts")]
   public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 250)]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }
        public float Price { get; set; }
        public DateTime DateCreate { get; set; }
        public virtual ICollection<Filters> Filters { get; set; }
        public virtual ICollection<ProductImage> ProductImage { get; set; }
    }
}
