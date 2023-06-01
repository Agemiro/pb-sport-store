using Microsoft.EntityFrameworkCore;
using PBSportStore.Context;
using PBSportStore.Models;
using PBSportStore.Repositories.Interfaces;

namespace PBSportStore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> Products => _context.Products.Include(c => c.Category);

        public IEnumerable<Product> FavoriteProducts => _context.Products
                                    .Where(p => p.IsFavoriteProduct)
                                    .Include(c => c.Category);

        public Product GetById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == id);
        }
    }
}
