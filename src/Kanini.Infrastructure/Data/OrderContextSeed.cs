using Microsoft.Extensions.Logging;
using Kanini.Core.Entities;

namespace Kanini.Infrastructure.Data;

public class OrderContextSeed
{
    public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
    {
        if (!orderContext.Orders.Any())
        {
            orderContext.Orders.AddRange(GetOrders());
            await orderContext.SaveChangesAsync();
            logger.LogInformation($"Ordering Database: {typeof(OrderContext).Name} seeded.");
        }
    }

    private static IEnumerable<Order> GetOrders()
    {
        return new List<Order>
        {
            new()
            {
                UserName = "crmohan",
                FirstName = "Rama Mohan",
                LastName = "Chandragiri",
                EmailAddress = "ramamohan.chandragiri@kanini.com",
                AddressLine = "Chennai",
                Country = "India",
                TotalPrice = 750,
                State = "TN",
                ZipCode = "600091",

                CardName = "Visa",
                CardNumber = "1234567890123456",
                CreatedBy = "RamaMohan",
                Expiration = "12/25",
                Cvv = "123",
                PaymentMethod = 1,
                LastModifiedBy = "RamaMohan",
                LastModifiedDate = new DateTime()
            }
        };
    }
}