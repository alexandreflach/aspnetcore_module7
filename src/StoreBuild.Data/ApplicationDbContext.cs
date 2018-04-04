using Microsoft.EntityFrameworkCore;
using StoreBuild.Domain.Products;

namespace StoreBuild.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){

        }

        public DbSet<Category> Categories { get; set; }
    }
}