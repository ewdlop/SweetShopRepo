using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SweetShop.Models;
using SweetShop.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SweetShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISweetRepository _sweetRepository;

        public HomeController(ISweetRepository sweetRepository)
        {
            _sweetRepository = sweetRepository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {


            var homeViewModel = new HomeViewModel()
            {
                Title = "Welcome to Sweet Shop",
                SweetsOfTheWeek = _sweetRepository.SweetsOfTheWeek()
            };
            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
