using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityProjectTest.Entities
{
    [Table ("tblCategories")]
    public class Category
    {
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        [ForeignKey("Parent"), Column(Order = 1)]
        public int? ParentId { get; set; }

        [Required, StringLength(maximumLength: 250)]
        public string Name { get; set; }

        public ICollection<Category> Parent { get; set; }
        public ICollection<Product> Product { get; set; }

    }
}
