using Microsoft.EntityFrameworkCore;
using Kanini.Core.Entities;
using Kanini.Core.Repositories;
using Kanini.Infrastructure.Data;

namespace Kanini.Infrastructure.Repositories;

public class OrderRepository: RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(OrderContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
    {
        var orderList = await _dbContext.Orders
            .Where(o => o.UserName == userName)
            .ToListAsync();
        return orderList;
    }
}