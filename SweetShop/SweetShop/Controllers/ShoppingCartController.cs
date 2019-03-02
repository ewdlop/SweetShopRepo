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
    public class ShoppingCartController : Controller
    {
        private readonly ISweetRepository _sweetRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(ISweetRepository sweetRepository, ShoppingCart shoppingCart)
        {
            _sweetRepository = sweetRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int Id)
        {
            var selectSweet = _sweetRepository.GetSweets().FirstOrDefault(p => p.Id == Id);

            if (selectSweet != null)
            {
                _shoppingCart.AddToCart(selectSweet, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int Id)
        {
            var selectSweet = _sweetRepository.GetSweets().FirstOrDefault(p => p.Id == Id);

            if (selectSweet != null)
            {
                _shoppingCart.RemoveFromCart(selectSweet);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult ViewShoppingCart()
        {
            return RedirectToAction("Index");
        }
    }
}
