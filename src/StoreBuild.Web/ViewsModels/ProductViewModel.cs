using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StoreBuild.Web.ViewsModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set;}

        public string CategoryName { get; set;}

        [Required]
        public decimal Price { get; set; }

        public decimal StockQuantity { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}