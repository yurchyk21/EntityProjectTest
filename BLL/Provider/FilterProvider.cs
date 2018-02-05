using BLL.Abstract;
using BLL.Model;
using EntityProjectTest.Abstract;
using EntityProjectTest.Concrete;
using EntityProjectTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Provider
{
    public class FilterProvider : IFilterProvider
    {
        private readonly IFilterNameRepository _filterNameRepository;

        public FilterProvider()
        {
            EFContext context = new EFContext();
            _filterNameRepository = new FilterNameRepository(context);
        }
        public FilterTreeViewItem AddFilterName(string name)
        {
            FilterTreeViewItem item = null;
            var findFilter = _filterNameRepository.GetByName(name);
            if (findFilter == null)
            {
                FilterName filterName = new FilterName()
                {
                    Name = name
                };
                _filterNameRepository.Add(filterName);
                _filterNameRepository.SaveChanges();
                item = new FilterTreeViewItem
                {
                    Id = filterName.Id.ToString(),
                    Name = filterName.Name
                };
            }
            return item;
        }
    }
}
