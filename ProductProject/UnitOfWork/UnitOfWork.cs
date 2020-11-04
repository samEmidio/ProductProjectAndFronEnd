using System;
using ProductProject.Data;
using ProductProject.Model;
using ProductProject.Repository;
using ProductProject.Repository.Interface;
using ProductProject.UnitOfWork.Interface;

namespace ProductProject.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public IProductRepository productRepository => new ProductRepository(this.dataContext);

        public ICategoryRepository categoryRepository => new CategoryRepository(this.dataContext);

        public IProductMockRepository productMockRepository => new ProductMockRepository();

        public ICategoryMockRepository categoryMockRepository => new CategoryMockRepository();


        public void Dispose()
        {
            this.dataContext.Dispose();
        }

        public void Save()
        {
            this.dataContext.SaveChanges();
        }
    }
}