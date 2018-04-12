using System.ComponentModel.DataAnnotations;

namespace StoreBuild.Web.ViewsModels
{
    public class LoginViewModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}