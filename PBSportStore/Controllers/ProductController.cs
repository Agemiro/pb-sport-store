using Microsoft.AspNetCore.Mvc;
using PBSportStore.Repositories.Interfaces;
using PBSportStore.ViewModels;

namespace PBSportStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository repository)
        {
            _productRepository = repository;
        }

        public IActionResult List()
        {
            //var products = _productRepository.Products;

            //return View(products);
            var productListViewModel = new ProductListViewModel();
            productListViewModel.Products = _productRepository.Products;
            productListViewModel.CurrentCategory = "Current Category";

            return View(productListViewModel);
        }
    }
}
