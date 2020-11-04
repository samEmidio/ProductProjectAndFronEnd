using ProductProject.Data;
using ProductProject.Model;
using ProductProject.Repository.Interface;

namespace ProductProject.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext dataContext) : base(dataContext)
        {
            
        }
    }
}