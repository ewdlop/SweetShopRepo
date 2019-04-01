using Microsoft.EntityFrameworkCore;
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
            IEnumerable<Sweet> test;
           
            return _appDBContext.Sweets;
        }

        IEnumerable<Sweet> ISweetRepository.SweetsOfTheWeek()
        {

            return _appDBContext.Sweets.Include(s => s.Category).Where(s => s.IsSweetOfTheWeek);
        }
    }
}
