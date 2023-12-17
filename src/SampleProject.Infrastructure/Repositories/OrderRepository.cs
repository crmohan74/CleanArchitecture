using Microsoft.EntityFrameworkCore;
using SampleProject.Core.Entities;
using SampleProject.Core.Repositories;
using SampleProject.Infrastructure.Data;

namespace SampleProject.Infrastructure.Repositories;

public class OrderRepository: RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(OrderContext dbContext) : base(dbContext)
    {
    }
}