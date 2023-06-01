using PBSportStore.Models;

namespace PBSportStore.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Product> FavoriteProducts { get; }

        Product GetById(int id);
    }
}
