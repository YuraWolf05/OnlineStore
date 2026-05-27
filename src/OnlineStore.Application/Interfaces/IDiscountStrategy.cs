using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Interfaces;

public interface IDiscountStrategy
{
    decimal ApplyDiscount(Order order);
}