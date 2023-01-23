using Microsoft.AspNetCore.Mvc;
using products.DatabaseContext;
using products.Models;
using products.Services;

namespace products.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    
    private readonly ILogger<ProductsController> _logger;

    public ProductsController( ILogger<ProductsController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet]
    [Route("getProduct")]
    
    public async Task<ActionResult<Products>> GetProduct([FromQuery] int? product_id, [FromServices] IProductRepository productRepo)
    {
        var product =  productRepo.GetProduct(product_id.Value).FirstOrDefault();
        return  product == null ? NotFound("Product not found") : product;;
    }
    
    [HttpGet]
    [Route("getProducts")]
    public async Task<ActionResult<IEnumerable<Products>>> GetProduct([FromServices] IProductRepository productRepo)
    {
        return Ok(productRepo.GetProducts());
    }
    
    [HttpGet]
    [Route("getType")]
    public async Task<ActionResult<Types>> GetType([FromQuery] int? type_id,[FromServices] IProductRepository productRepo)
    {   
        var type = (productRepo.GetType(type_id.Value)).FirstOrDefault();
        return  type == null ? NotFound("Type not found") : type;
    }
    [HttpGet]
    [Route("getTypes")]
    public async Task<ActionResult<IEnumerable<Types>>> GetType([FromServices] IProductRepository productRepo)
    {
        return Ok(productRepo.GetTypes());
    }
}
