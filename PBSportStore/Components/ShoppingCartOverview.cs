using Microsoft.AspNetCore.Mvc;
using PBSportStore.Models;
using PBSportStore.ViewModels;

namespace PBSportStore.Components
{
    public class ShoppingCartOverview : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartOverview(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            
            //var items =  new List<ShoppingCartItem>()
            //{
            //    new ShoppingCartItem(),
            //    new ShoppingCartItem()
            //};

            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetTotalShoppingCartValue()
            };

            return View(shoppingCartViewModel);
        }
    }
}
