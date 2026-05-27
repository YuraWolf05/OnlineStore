using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Enums;
using OnlineStore.Domain.Interfaces;

namespace OnlineStore.Application.Services;

public class ProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public void CreateProduct(
        string name,
        decimal price,
        ProductCategory category,
        int stock)
    {
        var product = new Product(
            name,
            price,
            category,
            stock);

        _repository.Add(product);
    }

    public IEnumerable<Product> GetProducts()
    {
        return _repository.GetAll();
    }

    public Product? GetProduct(Guid id)
    {
        return _repository.GetById(id);
    }
}