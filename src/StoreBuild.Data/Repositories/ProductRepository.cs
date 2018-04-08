using StoreBuild.Data.Contexts;
using StoreBuild.Domain.Products;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace StoreBuild.Data.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public override Product GetById(int id)
        {
            var query = _context.Set<Product>().Include(p => p.Category).Where(e => e.Id == id);
            if(query.Any())
                return query.First();
            return null;
        }

        public override IEnumerable<Product> All()
        {
            return _context.Set<Product>().Include( p => p.Category).AsEnumerable();
        }
    }
}