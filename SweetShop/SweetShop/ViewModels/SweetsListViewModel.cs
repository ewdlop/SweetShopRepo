using SweetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweetShop.ViewModels
{
    public class SweetsListViewModel
    {
        public IEnumerable<Sweet> Sweets { get; set; }
        public string CurrentCategory { get; set; }
    }
}
