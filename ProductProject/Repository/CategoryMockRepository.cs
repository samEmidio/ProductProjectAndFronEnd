using System.Collections.Generic;
using ProductProject.Model;
using ProductProject.Repository.Interface;

namespace ProductProject.Repository
{
    public class CategoryMockRepository : ICategoryMockRepository
    {
        public List<Category> ListCategory()
        {
            return  new List<Category>(){
                new Category(){id=1,name="Feminino",description="Produtos destinados ao publico feminino "},
                new Category(){id=2,name="Masculino",description="Produtos destinados ao publico masculino "},
                new Category(){id=3,name="Esportes",description="Produtos destinados a esportes "},
                new Category(){id=4,name="Moda",description="Produtos destinados a moda "},
            };
        }
    }
}