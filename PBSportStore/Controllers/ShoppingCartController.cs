using Microsoft.AspNetCore.Mvc;
using PBSportStore.Models;
using PBSportStore.Repositories.Interfaces;
using PBSportStore.ViewModels;

namespace PBSportStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IProductRepository productRepository, 
            ShoppingCart shoppingCart)
        {
            _productRepository = productRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetTotalShoppingCartValue()
            };

            return View(shoppingCartViewModel);
        }

        public IActionResult AddItemToShoppingCart(int productId)
        {
            var selectedProduct = _productRepository.Products
                                    .FirstOrDefault(p => p.ProductId == productId);
            
            if (selectedProduct != null)
            {
                _shoppingCart.AddToCart(selectedProduct);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveItemToShoppingCart(int productId)
        {
            var selectedProduct = _productRepository.Products
                                    .FirstOrDefault(p => p.ProductId == productId);

            if (selectedProduct != null)
            {
                _shoppingCart.RemoveToCart(selectedProduct);
            }

            return RedirectToAction("Index");
        }
    }
}
