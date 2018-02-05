using EntityProjectTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityProjectTest.Abstract
{
   public interface IFilterNameRepository
    {
        FilterName Add(FilterName filterName);
        FilterName GetByName(string name);
        IQueryable<FilterName> GetAll();
        int SaveChanges();
    }
}
