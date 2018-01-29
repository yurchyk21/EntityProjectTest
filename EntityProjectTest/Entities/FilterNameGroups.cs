using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityProjectTest.Entities
{
    [Table("tblFilterNameGroups")]
    public class FilterNameGroup
    {

        [Key, ForeignKey("FilterNameOf"), Column(Order = 0)]
        public int FilternameId { get; set; }
        public virtual FilterName FilterNameOf { get; set; }

        [Key, ForeignKey("FilterValueOf"), Column(Order = 1)]
        public int FilterValueId { get; set; }
        public virtual FilterValue FilterValueOf { get; set; }

    }
}
