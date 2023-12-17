using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SampleProject.Core.Repositories;
using SampleProject.Infrastructure.Data;
using SampleProject.Infrastructure.Repositories;

namespace SampleProject.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<OrderContext>(ctx =>
            ctx.UseSqlServer(configuration.GetConnectionString("OrderingConnectionString")));
            serviceCollection.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            serviceCollection.AddScoped<IOrderRepository, OrderRepository>();

            return serviceCollection;
        }

    }
}
