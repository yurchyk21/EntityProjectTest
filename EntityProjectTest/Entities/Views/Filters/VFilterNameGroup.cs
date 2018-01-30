using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityProjectTest.Entities.Views.Filters
{
    [Table ("vFilterNameGoups")]
    public class VFilterNameGroup
    {
        [Key]
        public Guid Id { get; set; }
        public int FilterNameId { get; set; }
        [Required, StringLength(maximumLength: 250)]
        public string FilterName { get; set; }

        public int FilterValueId { get; set; }
        [Required, StringLength(maximumLength: 250)]
        public string FilterValue { get; set; }

    }
}
