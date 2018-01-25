using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityProjectTest.Entities
{
    [Table("tblRoles")]
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 250)]
        public string Name { get; set; }
        public virtual ICollection<UserProfile> UserProfile { get; set; }
    }
}
