using Microsoft.EntityFrameworkCore;
using products.Models;


namespace products.DatabaseContext;

public class dbContextPg : DbContext
{
    public dbContextPg(DbContextOptions<dbContextPg> options) : base(options)
    {
    }
    public DbSet<Product> Product{ get; set; }
    
}
