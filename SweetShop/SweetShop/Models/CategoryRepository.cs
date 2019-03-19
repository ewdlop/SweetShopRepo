using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweetShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDBContext _appDbContext;

        public CategoryRepository(AppDBContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Category> Categories => _appDbContext.Categories;
    }
}