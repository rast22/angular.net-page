using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using products.DatabaseContext;
using products.Models;
using products.Services;

namespace products.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    
    private readonly dbContextPg _context;
    
    private readonly ILogger<ProductController> _logger;

    public ProductController(dbContextPg context, ILogger<ProductController> logger)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "getProducts")]
    public IEnumerable<Product> Get([FromQuery] int? product_id, [FromServices] IProductRepository productRepo)
    {
        if (product_id.HasValue)
        {
            return productRepo.GetProduct(product_id.Value).Result;
            
        }
        else
        {
            return productRepo.GetProducts().Result;
        }
    }
}
