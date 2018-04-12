using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using StoreBuild.Domain.Account;

namespace StoreBuild.Data.Identy
{
    public class Authentication : IAuthentication
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public Authentication(SignInManager<ApplicationUser> signInManager){
            _signInManager = signInManager;
        }

        public async Task<bool> Authenticate(string email, string password){
            var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: true);
            return result.Succeeded;
        }
    }
}