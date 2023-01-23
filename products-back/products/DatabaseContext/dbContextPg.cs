using Microsoft.EntityFrameworkCore;
using products.Models;


namespace products.DatabaseContext;

public class dbContextPg : DbContext
{
    public dbContextPg(DbContextOptions<dbContextPg> options) : base(options)
    {
    }
    public DbSet<Products> Products{ get; set; }
    public DbSet<Types> Types{ get; set; }

}
