using StoreBuild.Data.Contexts;
using StoreBuild.Domain;
using System.Collections.Generic;
using System.Linq;

namespace StoreBuild.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public virtual TEntity GetById(int id)
        {
            return _context.Set<TEntity>().SingleOrDefault(e => e.Id == id);
        }

        public virtual IEnumerable<TEntity> All()
        {
            return _context.Set<TEntity>().AsEnumerable();
        }

        public void Save(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }
    }
}