using OnlineStore.Domain.Entities;

namespace OnlineStore.Domain.Interfaces;

public interface IProductRepository
    : IRepository<Product, Guid>
{
}