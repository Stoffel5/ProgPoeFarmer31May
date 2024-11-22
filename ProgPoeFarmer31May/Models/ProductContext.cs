namespace ProgPoeFarmer31May.Models
{
    public class ProductContext
    {
        public static List<Product> products = new List<Product>();
        public static List<Product> userproducts = new List<Product>();
        public ProductContext() 
        
        {
            if (products.Count == 0)
            {
                products.Add(new Product(1, "CP", "Tractor", "Agriculture", "May 03 2024"));
                products.Add(new Product(2, "Birdfeeder29", "Shovel", "Landscaping", "Oct 10 2024"));
                products.Add(new Product(3, "Peace4Reece", "BurgerApp", "FoodCart", "Sep 13 2024"));
                products.Add(new Product(4, "CP", "Forklift", "Storage", "Aug 24 2024"));
                products.Add(new Product(4, "Peace4Reece", "Forklift", "Storage", "Aug 24 2024"));
            }
        }
    }
}
