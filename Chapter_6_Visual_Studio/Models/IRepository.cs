using System.Collections.Generic;

namespace Chapter_6_Visual_Studio.Models
{
    public interface IRepository
    {
        IEnumerable<Product> Products { get; }
        void AddProduct(Product p);
    }
}
