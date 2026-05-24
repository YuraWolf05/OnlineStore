using OnlineStore.Domain.Entities;

namespace OnlineStore.Domain.Interfaces;

public interface IProductRepository
{
    IEnumerable<Product> GetAll();

    Product? GetById(Guid id);

    void Save(Product product);
}