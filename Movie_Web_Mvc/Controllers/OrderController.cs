using Microsoft.AspNetCore.Mvc;
using Movie_Web_Mvc.Cart;
using Movie_Web_Mvc.Models;
using Movie_Web_Mvc.Service;
using System.Security.Claims;

namespace Movie_Web_Mvc.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMovieServices _MoviesService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrderServices _ordersService;
        public OrderController(IMovieServices MoviesService, ShoppingCart shoppingCart, IOrderServices ordersService)
        {
            _MoviesService = MoviesService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }
       
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartViewModel()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }
        public IActionResult AddToShoppingCart(int id)
        {
            var item = _MoviesService.GetById(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }

            return RedirectToAction(nameof(ShoppingCart));
        }
        public IActionResult RemoveItemFromShoppingCart(int id)
        {
            var item = _MoviesService.GetById(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
        public IActionResult CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = ""; /*User.FindFirstValue(ClaimTypes.NameIdentifier);*/
            string userEmailAddress = ""; /*User.FindFirstValue(ClaimTypes.Email);*/

            _ordersService.StoreOrder(items, userId, userEmailAddress);
            _shoppingCart.ClearShoppingCart();
            return View("OrderCompleted");
        }
    }
}

