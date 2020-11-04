using Microsoft.EntityFrameworkCore;
using ProductProject.Model;
using ProductProject.Repository.Interface;

namespace ProductProject.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {   
        IProductRepository productRepository { get; }
        ICategoryRepository categoryRepository { get; }

        
        IProductMockRepository productMockRepository { get; }
        ICategoryMockRepository categoryMockRepository { get; }

        void Save();

        void Dispose();
    }
}