using PBSportStore.Models;

namespace PBSportStore.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
