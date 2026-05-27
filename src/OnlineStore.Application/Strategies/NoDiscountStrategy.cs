using OnlineStore.Domain.Entities;
using OnlineStore.Application.Interfaces;

namespace OnlineStore.Application.Strategies;

public class NoDiscountStrategy : IDiscountStrategy
{
    public decimal ApplyDiscount(Order order)
        => order.TotalPrice;
}