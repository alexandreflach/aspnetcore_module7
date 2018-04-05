using Microsoft.Extensions.DependencyInjection;
using StoreBuild.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StoreBuild.Domain;
using StoreBuild.Domain.Products;

namespace StoreBuild.DI
{
    public class Bootstrap
    {
        public static void Configure(IServiceCollection services, string connection)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connection));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<CategoryStorer>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}