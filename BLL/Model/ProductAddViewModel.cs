using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
   public class ProductAddViewModel
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public IList<string> Images { get; set; }
    }
}
