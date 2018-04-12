using System.Threading.Tasks;

namespace StoreBuild.Domain.Account
{
    public interface IAuthentication
    {
        Task<bool> Authenticate(string email, string password);
    }
}