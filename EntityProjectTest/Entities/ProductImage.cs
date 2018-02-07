using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityProjectTest.Entities
{
   [Table("tblProductImage")]
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [Required, StringLength(maximumLength:150)]
        public string Name { get; set; }
        public Product Product { get; set; }
    }
}
