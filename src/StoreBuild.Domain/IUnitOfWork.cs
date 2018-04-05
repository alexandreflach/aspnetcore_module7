using System.Threading.Tasks;

namespace StoreBuild.Domain
{
    public interface IUnitOfWork
    {
        Task Commit();
        
    }
}