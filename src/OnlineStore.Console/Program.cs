using OnlineStore.Application.Services;
using OnlineStore.Domain.Enums;
using OnlineStore.Infrastructure.Repositories;

var repository = new InMemoryProductRepository();

var productService = new ProductService(repository);

while (true)
{
    Console.WriteLine("\n=== ONLINE STORE ===");

    Console.WriteLine("1. Add product");

    Console.WriteLine("2. Show products");

    Console.WriteLine("0. Exit");

    Console.Write("Choose option: ");

    var input = Console.ReadLine();

    switch (input)
    {
        case "1":

            try
            {
                Console.Write("Product name: ");
                var name = Console.ReadLine();

                Console.Write("Price: ");
                var price = decimal.Parse(Console.ReadLine()!);

                Console.WriteLine("Category:");
                Console.WriteLine("0 - Electronics");
                Console.WriteLine("1 - Clothing");
                Console.WriteLine("2 - Books");
                Console.WriteLine("3 - Food");
                Console.WriteLine("4 - Accessories");

                var category =
                    (ProductCategory)int.Parse(Console.ReadLine()!);

                Console.Write("Stock quantity: ");

                var stock =
                    int.Parse(Console.ReadLine()!);

                productService.CreateProduct(
                    name!,
                    price,
                    category,
                    stock);

                Console.WriteLine("Product added successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            break;

        case "2":

            var products =
                productService.GetProducts().ToList();

            if (!products.Any())
            {
                Console.WriteLine("No products found");
                break;
            }

            foreach (var product in products)
            {
                Console.WriteLine(
                    $"{product.Name} | " +
                    $"{product.Price:C} | " +
                    $"{product.Category} | " +
                    $"Stock: {product.StockQuantity}");
            }

            break;

        case "0":
            return;

        default:
            Console.WriteLine("Invalid option");
            break;
    }
}