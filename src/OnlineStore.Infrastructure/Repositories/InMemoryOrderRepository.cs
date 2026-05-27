using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Interfaces;

namespace OnlineStore.Infrastructure.Repositories;

public class InMemoryOrderRepository
    : IRepository<Order, Guid>
{
    private readonly List<Order> _orders = new();

    public IReadOnlyCollection<Order> GetAll()
        => _orders.AsReadOnly();

    public Order? GetById(Guid id)
        => _orders.FirstOrDefault(o => o.Id == id);

    public void Add(Order entity)
        => _orders.Add(entity);

    public void Update(Order entity)
    {
        var existing = GetById(entity.Id);
        if (existing == null) return;

        _orders.Remove(existing);
        _orders.Add(entity);
    }

    public void Delete(Guid id)
    {
        var order = GetById(id);
        if (order != null)
            _orders.Remove(order);
    }
}