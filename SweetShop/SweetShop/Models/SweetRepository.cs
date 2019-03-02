using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweetShop.Models
{
    public class SweetRepository : ISweetRepository
    {
        private readonly AppDBContext _appDBContext;

        public SweetRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        Sweet ISweetRepository.GetSweetById(int sweetId)
        {
            return _appDBContext.Sweets.FirstOrDefault(s => s.Id == sweetId);
        }

        IEnumerable<Sweet> ISweetRepository.GetSweets()
        {
            return _appDBContext.Sweets;
        }
    }
}
