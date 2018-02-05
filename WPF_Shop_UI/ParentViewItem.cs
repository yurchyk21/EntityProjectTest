using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Shop_UI
{
   public  class ParentViewItem
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public List<string> children { get; set; }
        public override string ToString()
        {
            return Name;
        }
        ///
    }
}
