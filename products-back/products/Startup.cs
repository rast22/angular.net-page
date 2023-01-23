
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using products.DatabaseContext;
using products.Services;

namespace products;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddAuthentication();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddDbContext<dbContextPg>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
        services.AddSwaggerGen(c =>
        {
            c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
        });
        services.AddCors(options => options.AddDefaultPolicy(
            builder =>
            {
                builder
                    .WithOrigins("*");
            }
        ));
    }   
    public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DotNet5WebApiExample v1"));
        }

        app.UseRouting();
            
        app.UseCors( builder=>builder.AllowAnyOrigin());

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        DbInitializer dbInit = new DbInitializer(Configuration);
        await dbInit.InitializeDatabaseAsync();
        
    }   
}
