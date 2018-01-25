﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityProjectTest.Entities
{
    [Table ("tblFilterNames")]
    public   class FilterName
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(maximumLength:250)]
        public string Name { get; set; }
        public ICollection<Filters> Filters { get; set; }
    }
}
