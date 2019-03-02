using SweetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweetShop.ViewModels
{
    public class HomeViewModel
    {
        public string Title { get; set; }
        public List<Sweet> Sweets { get; set; }
    }
}
