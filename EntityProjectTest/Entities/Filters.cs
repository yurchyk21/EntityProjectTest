using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityProjectTest.Entities
{
    [Table("tblFilters")]
    public   class Filters
    {
        [Key, ForeignKey("FilterNameOf"), Column(Order=0)]
        public int FilternameId { get; set; }
        public virtual FilterName FilterNameOf { get; set; }

        [Key, ForeignKey("FilterValueOf"), Column(Order = 1)]
        public int FilterValueId { get; set; }
        public virtual FilterValue FilterValueOf { get; set; }

        [Key, ForeignKey("ProductOf"), Column(Order = 2)]
        public int ProductId { get; set; }
        public virtual Product ProductOf { get; set; }


    }
}
