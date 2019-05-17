using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SweetShop.Models;
using SweetShop.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SweetShop.Controllers
{
    public class SweetController : Controller
    {
        private readonly ISweetRepository _sweetRepository;
        private readonly ICategoryRepository _categoryRepository;

        public SweetController(ISweetRepository sweetRepository, ICategoryRepository categoryRepository)
        {
            _sweetRepository = sweetRepository;
            _categoryRepository = categoryRepository;
        }

        //public ViewResult List()
        //{
        //    PiesListViewModel piesListViewModel = new PiesListViewModel();
        //    piesListViewModel.Pies = _pieRepository.Pies;

        //    piesListViewModel.CurrentCategory = "Cheese cakes";

        //    return View(piesListViewModel);
        //}

        public ViewResult List(string category)
        {
            IEnumerable<Sweet> sweets;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                sweets = _sweetRepository.GetSweets().OrderBy(s => s.Id);
                currentCategory = "All sweets";
            }
            else
            {
                sweets = _sweetRepository.GetSweets().Where(s => s.CategoryId == (Int32.Parse(category)))
                   .OrderBy(s => s.Id);
                currentCategory = _categoryRepository.Categories.FirstOrDefault(c => c.CategoryId == (Int32.Parse(category))).CategoryName;
            }

            return View(new SweetsListViewModel
            {
                Sweets = sweets,
                CurrentCategory = currentCategory
            });
        }

        public IActionResult Details(int id)
        {
            var sweet = _sweetRepository.GetSweetById(id);
            if (sweet == null)
                return NotFound();

            return View(sweet);
        }

        public ViewResult Filter(string search)
        {
            IEnumerable<Sweet> sweets;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(search))
            {
                return View(new SweetsListViewModel
                {
                    Sweets = _sweetRepository.GetSweets().Where(s => s.Name.ToLower().Contains("XXXXXXXXX"))
                   .OrderBy(s => s.Id),
                    CurrentCategory = "All sweets"
                });
            }
            else
            {
                sweets = _sweetRepository.GetSweets().Where(s => s.Name.ToLower().Contains(search.ToLower()))
                   .OrderBy(s => s.Id);
                currentCategory = "All sweets";
            }

            return View(new SweetsListViewModel
            {
                Sweets = sweets,
                CurrentCategory = "All sweets"
            });
        }
    }
}

