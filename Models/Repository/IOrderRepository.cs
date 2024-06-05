using System.Collections.Generic;

namespace MusicStore.Models.Repository
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Interface To implement Order Enumerable
        /// </summary>
        IEnumerable<Order> Orders { get; }
        /// <summary>
        /// Save Order to the database
        /// </summary>
        void SaveOrder(Order order);
    }
}
