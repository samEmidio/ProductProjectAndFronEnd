using System.Collections.Generic;
using ProductProject.Model;

namespace ProductProject.Repository.Interface
{
    public interface IProductMockRepository
    {
         List<Product> ListProduct();
    }
}