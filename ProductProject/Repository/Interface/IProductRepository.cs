using System;
using System.Collections.Generic;
using System.Linq;
using ProductProject.Model;

namespace ProductProject.Repository.Interface
{
    public interface IProductRepository:IBaseRepository<Product>
    {
        List<Product> ListProduct();

        void RemovePictures(Product item);
    }
}