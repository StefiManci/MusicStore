using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MusicStore.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private ApplicationDbContext context;
        public EFOrderRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

public IEnumerable<Order> Orders => context.Orders
.Include(o => o.Lines)
.ThenInclude(l => l.music);
        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.music));
            if (order.Id == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}
