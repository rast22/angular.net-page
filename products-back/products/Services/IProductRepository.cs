using products.Models;

namespace products.Services;

public interface IProductRepository

{
     IEnumerable<Products> GetProducts();
    
     IEnumerable<Products> GetProduct(int productId);
    
     IEnumerable<Types> GetTypes();
    
     IEnumerable<Types> GetType(int type_id);
}
