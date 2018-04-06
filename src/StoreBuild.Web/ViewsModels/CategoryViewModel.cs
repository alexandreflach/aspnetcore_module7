using System.ComponentModel.DataAnnotations;

namespace StoreBuild.Web.ViewsModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}