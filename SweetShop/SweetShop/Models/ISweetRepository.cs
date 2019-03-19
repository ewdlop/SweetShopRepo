using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweetShop.Models
{
    public interface ISweetRepository
    {
        IEnumerable<Sweet> GetSweets();
        Sweet GetSweetById(int sweetId);
        IEnumerable<Sweet> SweetsOfTheWeek();
    }
}
