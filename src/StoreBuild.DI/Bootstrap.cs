using Microsoft.Extensions.DependencyInjection;
using StoreBuild.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace StoreBuild.DI
{
    public class Bootstrap
    {
        public static void Configure(IServiceCollection services, string connection){
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connection));
        }
    }
}