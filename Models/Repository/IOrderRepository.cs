using System.Collections.Generic;

namespace MusicStore.Models.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}
