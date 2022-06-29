using System.Collections.Generic;

namespace Chapter_6_Visual_Studio.Models
{
    public class SimpleRepository
    {
        private static SimpleRepository sharedRepository = new SimpleRepository();
        private Dictionary<string, Product> products = new Dictionary<string, Product>();

        public static SimpleRepository SharedRepository => sharedRepository;
        public SimpleRepository()
        {
            var initialItem = new[]
            {
                new Product { Name = "Kayak", Price = 275M},
                new Product { Name = "LifeJacket", Price = 48.95M},
                new Product { Name = "Soccer Ball", Price = 19.50M},
                new Product { Name = "Corner Flag", Price = 34.95M}
            };

            foreach (var p in initialItem)
            {
                AddProduct(p);
            }
        }

        public IEnumerable<Product> Products => products.Values;
        public void AddProduct(Product p) => products.Add(p.Name, p);
    }
}
