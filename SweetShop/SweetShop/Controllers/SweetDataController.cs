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
    [Route("api/[controller]")]
    public class SweetDataController : Controller
    {

        private readonly ISweetRepository _sweetRepository;

        public SweetDataController(ISweetRepository sweetRepository)
        {
            _sweetRepository = sweetRepository;
        }
        [HttpGet]
        public IEnumerable<SweetViewModel> LoadMoreSweets()
        {
            IEnumerable<Sweet> dbSweets = null;
            dbSweets = _sweetRepository.GetSweets().OrderBy(s => s.Id).Take(2);
            List<SweetViewModel> sweets = new List<SweetViewModel>();
            foreach(var dbSweet in dbSweets)
            {
                sweets.Add(MapDbSweetToSweetViewModel(dbSweet));
            }
            return sweets;
        }
        private SweetViewModel MapDbSweetToSweetViewModel(Sweet dbSweet)
        {
            return new SweetViewModel()
            {
                Id = dbSweet.Id,
                Name = dbSweet.Name,
                Price = dbSweet.Price,
                ShortDescription = dbSweet.ShortDescription,
                ImageThumbnailUrl = dbSweet.ImageThumbnailUrl,
                CategoryId = dbSweet.CategoryId
            };
        }
    }
    


}
