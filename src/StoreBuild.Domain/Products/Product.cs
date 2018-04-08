using StoreBuild.Data;

namespace StoreBuild.Domain.Products
{
    public class Product : Entity
    {
        public string Name { get; private set; }

        public Category Category { get; private set; }

        public decimal Price { get; private set; }

        public decimal StockQuantity { get; private set; }

        public Product(){

        }
        
        public Product(string name, Category category, decimal price, decimal stockQuantity)
        {

            Validate(name, category, price, stockQuantity);
            SetProperties(name, category, price, stockQuantity);
        }

        public void Update(string name, Category category, decimal price, decimal stockQuantity)
        {
            Validate(name, category, price, stockQuantity);
            SetProperties(name, category, price, stockQuantity);
        }

        private void Validate(string name, Category category, decimal price, decimal stockQuantity)
        {
            DomainException.When(string.IsNullOrEmpty(name), "Name is required");
            DomainException.When(category == null, "Category is required");
            DomainException.When(price < 0, "Price is required");
            DomainException.When(stockQuantity < 0, "Stock Quantity is required");
        }

        private void SetProperties(string name, Category category, decimal price, decimal stockQuantity)
        {
            Name = name;
            Category = category;
            Price = price;
            StockQuantity = stockQuantity;
        }
    }
}