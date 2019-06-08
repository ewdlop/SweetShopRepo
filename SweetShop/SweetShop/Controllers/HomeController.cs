using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SweetShop.Models;
using SweetShop.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SweetShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISweetRepository _sweetRepository;
        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(ISweetRepository sweetRepository, IStringLocalizer<HomeController> localizer)
        {
            _sweetRepository = sweetRepository;
            _localizer = localizer;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {

            var homeViewModel = new HomeViewModel()
            {
                Title = _localizer["Welcome to Sweet Shop"],
                SweetsOfTheWeek = _sweetRepository.SweetsOfTheWeek()
            };
            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}
