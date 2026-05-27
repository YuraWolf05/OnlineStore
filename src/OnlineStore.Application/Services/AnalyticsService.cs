using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Services;

public class AnalyticsService
{
    public decimal TotalRevenue(IEnumerable<Order> orders)
    {
        return orders.Sum(o => o.TotalPrice);
    }

    public IEnumerable<Order> GetTopOrders(IEnumerable<Order> orders)
    {
        return orders
            .OrderByDescending(o => o.TotalPrice)
            .Take(5);
    }

    public IEnumerable<IGrouping<string, Order>> GroupByCustomer(
        IEnumerable<Order> orders)
    {
        return orders.GroupBy(o => o.Customer.Email);
    }
}