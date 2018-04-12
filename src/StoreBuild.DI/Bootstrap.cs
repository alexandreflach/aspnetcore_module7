using Microsoft.Extensions.DependencyInjection;
using StoreBuild.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StoreBuild.Domain;
using StoreBuild.Domain.Products;
using StoreBuild.Data.Contexts;
using StoreBuild.Data.Repositories;
using StoreBuild.Data.Identy;
using Microsoft.AspNetCore.Identity;

namespace StoreBuild.DI
{
    public class Bootstrap
    {
        public static void Configure(IServiceCollection services, string connection)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connection));
            services.AddIdentity<ApplicationUser, IdentityRole>(config => {
                config.Password.RequireDigit = false;
                config.Password.RequiredLength = 3;
                config.Password.RequireLowercase = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(config =>{
                config.LoginPath = "/Account/Login";
            });
            services.AddScoped(typeof(IRepository<Product>), typeof(ProductRepository));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<CategoryStorer>();
            services.AddScoped<ProductStorer>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}