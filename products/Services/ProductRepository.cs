using Microsoft.EntityFrameworkCore;
using Npgsql;
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
    
    public async Task<IEnumerable<Product>> GetProducts()
    {
        return  _context.Product.FromSqlRaw("SELECT * FROM product").ToList();
    }
    
    public async Task<IEnumerable<Product>> GetProduct(int product_id)
    {
        return _context.Product.FromSqlRaw("SELECT * FROM product WHERE product_id = "+product_id).ToList();
    }
}
