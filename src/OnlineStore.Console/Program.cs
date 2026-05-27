using OnlineStore.Application.Services;
using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Enums;
using OnlineStore.Infrastructure.Data;
using OnlineStore.Infrastructure.Repositories;

// LOAD DATA
var dataStore = new JsonProductDataStore();
var productsFromFile = await dataStore.LoadAsync();

var productRepository =
    new InMemoryProductRepository(productsFromFile);

var productService =
    new ProductService(productRepository);

var orderRepository =
    new InMemoryOrderRepository();
var orderService =
    new OrderService(orderRepository);

var cart = new Cart();

while (true)
{
    Console.WriteLine("\n=== ONLINE STORE (LAB 35) ===");
    Console.WriteLine("1. Add product");
    Console.WriteLine("2. Show products");
    Console.WriteLine("3. Add to cart");
    Console.WriteLine("4. Checkout order");
    Console.WriteLine("5. Show orders");
    Console.WriteLine("6. Analytics");
    Console.WriteLine("0. Exit");

    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
        {
            Console.Write("Name: ");
            var name = Console.ReadLine();

            Console.Write("Price: ");
            var price = decimal.Parse(Console.ReadLine()!);

            Console.Write("Stock: ");
            var stock = int.Parse(Console.ReadLine()!);

            var product = new Product(
                name!,
                price,
                ProductCategory.Electronics,
                stock);

            productService.CreateProduct(
                product.Name,
                product.Price,
                product.Category,
                product.StockQuantity);

            await dataStore.SaveAsync(productRepository.GetAll());

            Console.WriteLine("Product created");
            break;
        }

        case "2":
        {
            foreach (var p in productService.GetProducts())
            {
                Console.WriteLine($"{p.Name} | {p.Price} | {p.StockQuantity}");
            }
            break;
        }

        case "3":
        {
            Console.Write("Product name: ");
            var name = Console.ReadLine();

            var product = productService
                .GetProducts()
                .FirstOrDefault(p => p.Name == name);

            if (product == null)
            {
                Console.WriteLine("Not found");
                break;
            }

            Console.Write("Quantity: ");
            var qty = int.Parse(Console.ReadLine()!);

            cart.AddProduct(product, qty);

            Console.WriteLine("Added to cart");
            break;
        }

        case "4":
        {
            var customer = new Customer(
                "Test User",
                "test@mail.com");

            var order = orderService.CreateOrder(customer, cart);

            order.MarkAsPaid();

            Console.WriteLine($"Order created: {order.Id}");

            break;
        }

        case "5":
        {
            var orders = orderService.GetOrders();

            foreach (var o in orders)
            {
                Console.WriteLine($"{o.Id} | {o.TotalPrice} | {o.Status}");
            }

            break;
        }

        case "6":
        {
            var orders = orderService.GetOrders();

            Console.WriteLine($"Total revenue: {orders.Sum(o => o.TotalPrice)}");

            break;
        }

        case "0":
            return;
    }
}