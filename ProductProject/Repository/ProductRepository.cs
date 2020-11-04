using System.Xml.Linq;
using System.Linq;
using ProductProject.Data;
using ProductProject.Model;
using ProductProject.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ProductProject.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {

        private readonly DataContext dataContext;

        public ProductRepository(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext;
        }

        public List<Product> ListProduct()
        {
            return this.dataContext.product.Include(x => x.category).Include(x => x.pictures).ToList();
        }

        public void RemovePictures(Product item)
        {
            var pics =  this.dataContext.product.Include(x => x.pictures).Where(x => x.id == item.id).FirstOrDefault().pictures;

            this.dataContext.picture.RemoveRange(pics);  

        }
    }
}