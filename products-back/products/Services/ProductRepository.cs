using Microsoft.EntityFrameworkCore;
using products.DatabaseContext;
using products.Models;

namespace products.Services;

public class ProductRepository:IProductRepository
{
    private readonly dbContextPg _context;

    public ProductRepository(dbContextPg context)
    {
        _context = context;
    }
    
    public IEnumerable<Products> GetProducts()
    {
        return  _context.Products.FromSqlRaw("SELECT * FROM products").ToList();
    }
    
    public IEnumerable<Products> GetProduct(int product_id)
    {
        return _context.Products.FromSqlRaw("SELECT * FROM products WHERE product_id = "+product_id).ToList();
    }
    
    public IEnumerable<Types> GetTypes()
    {
        return _context.Types.FromSqlRaw("SELECT * FROM product_types").ToList();
    }
    
    public IEnumerable<Types> GetType(int type_id)
    {
        return _context.Types.FromSqlRaw("SELECT * FROM product_types WHERE type_id = "+type_id).ToList();
    }

}
