using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Interfaces;

namespace OnlineStore.Infrastructure.Repositories;

public class InMemoryProductRepository
    : IProductRepository
{
    private readonly Dictionary<Guid, Product> _products;

    public InMemoryProductRepository(
        IEnumerable<Product>? products = null)
    {
        _products = products?
            .ToDictionary(p => p.Id)
            ?? new Dictionary<Guid, Product>();
    }

    public IReadOnlyCollection<Product> GetAll()
    {
        return _products.Values.ToList();
    }

    public Product? GetById(Guid id)
    {
        _products.TryGetValue(id, out var product);

        return product;
    }

    public void Add(Product entity)
    {
        if (_products.ContainsKey(entity.Id))
            throw new InvalidOperationException(
                "Product already exists");

        _products[entity.Id] = entity;
    }

    public void Update(Product entity)
    {
        if (!_products.ContainsKey(entity.Id))
            throw new InvalidOperationException(
                "Product not found");

        _products[entity.Id] = entity;
    }

    public void Delete(Guid id)
    {
        if (!_products.ContainsKey(id))
            throw new InvalidOperationException(
                "Product not found");

        _products.Remove(id);
    }
}