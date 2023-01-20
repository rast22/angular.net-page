using products.Models;

namespace products.Services;

public interface IProductRepository

{
    Task <IEnumerable<Product>> GetProducts();
    Task <IEnumerable<Product>> GetProduct(int productId);
}
