using EntityProjectTest.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityProjectTest.Entities;

namespace EntityProjectTest.Concrete
{
    public class FilterNameRepository : IFilterNameRepository
    {
        private readonly EFContext _context;
        public FilterNameRepository(EFContext context)
        {
            _context = context;
        }
        public FilterName Add(FilterName filterName)
        {
            _context.FilterName.Add(filterName);
            return filterName;
        }

        public IQueryable<FilterName> GetAll()
        {
            return _context.FilterName.AsQueryable();
        }

        public FilterName GetByName(string name)
        {
            return this.GetAll()
                .SingleOrDefault(f => f.Name == name);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
