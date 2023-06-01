using PBSportStore.Context;
using PBSportStore.Models;
using PBSportStore.Repositories.Interfaces;

namespace PBSportStore.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> Categories => _context.Categories;
    }
}
