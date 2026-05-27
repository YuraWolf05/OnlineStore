using OnlineStore.Domain.Entities;
using OnlineStore.Application.Interfaces;

namespace OnlineStore.Application.Strategies;

public class PercentageDiscountStrategy : IDiscountStrategy
{
    private readonly decimal _percent;

    public PercentageDiscountStrategy(decimal percent)
    {
        _percent = percent;
    }

    public decimal ApplyDiscount(Order order)
    {
        return order.TotalPrice - (order.TotalPrice * _percent);
    }
}