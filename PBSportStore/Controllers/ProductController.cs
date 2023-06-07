using Microsoft.AspNetCore.Mvc;
using PBSportStore.Models;
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

        public IActionResult List(string category)
        {
            IEnumerable<Product> products;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                products = _productRepository.Products.OrderBy(p => p.CategoryId);
                currentCategory = "All products";
            }
            else
            {
                products = _productRepository.Products
                        .Where(p => p.Category.CategoryName.Equals(category))
                        .OrderBy(p => p.Name);
                currentCategory = category;
            }

            var productListViewModel = new ProductListViewModel
            {
                Products = products,
                CurrentCategory = currentCategory
            };

            return View(productListViewModel);
        }

        public IActionResult Details(int productId)
        {
            var product = _productRepository.Products.FirstOrDefault(p => p.ProductId == productId);
            return View(product);
        }

        public ViewResult Search(string searchString)
        {
            IEnumerable<Product> products;
            string currentCategory = string.Empty;

            if(string.IsNullOrEmpty(searchString))
            {
                products = _productRepository.Products.OrderBy(p => p.ProductId);
                currentCategory = "All products";
            }
            else
            {
                products = _productRepository.Products
                    .Where(p => p.Name.ToLower().Contains(searchString.ToLower()));

                if(products.Any())
                {
                    currentCategory = "Products";
                }
                else
                {
                    currentCategory = "No product was found";
                }
            }

            return View("~/Views/Product/List.cshtml", new ProductListViewModel
            {
                Products = products,
                CurrentCategory = currentCategory
            });
        }
    }
}
