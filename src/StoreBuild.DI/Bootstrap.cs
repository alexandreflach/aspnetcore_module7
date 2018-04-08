using Microsoft.Extensions.DependencyInjection;
using StoreBuild.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StoreBuild.Domain;
using StoreBuild.Domain.Products;
using StoreBuild.Data.Contexts;
using StoreBuild.Data.Repositories;

namespace StoreBuild.DI
{
    public class Bootstrap
    {
        public static void Configure(IServiceCollection services, string connection)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connection));
            services.AddScoped(typeof(IRepository<Product>), typeof(ProductRepository));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<CategoryStorer>();
            services.AddScoped<ProductStorer>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}