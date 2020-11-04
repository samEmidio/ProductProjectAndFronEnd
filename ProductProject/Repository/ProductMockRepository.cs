using System.Collections.Generic;
using ProductProject.Model;
using ProductProject.Repository.Interface;

namespace ProductProject.Repository
{
    public class ProductMockRepository : IProductMockRepository
    {
      
        public List<Product> ListProduct()
        {


            return new List<Product>(){
                new Product(){
                id=1,name="camisa",description="camiseta masculina",category =
                    new Category(){id=2,name="Masculino",description="Produtos destinados ao publico masculino "},
                    price = 29.90,
                    pictures = new List<Picture>(){
                        new Picture(){id = 1,path = "camisa_masculina.jpg"},
                        new Picture(){id = 2,path = "camisa_masculina2.jpg"}
                        }
                },
                new Product(){
                id=2,name="camisa",description="camiseta feminina",category =
                    new Category(){id=1,name="Feminino",description="Produtos destinados ao publico feminino "},
                    price = 29.90,
                    pictures = new List<Picture>(){
                        new Picture(){id = 1,path = "camisa_feminina.jpg"},
                        new Picture(){id = 2,path = "camisa_feminina2.jpg"}
                        }
                },
                new Product(){
                id=3,name="Chuteira Nike",description="Chuteira Nike",category =
                    new Category(){id=3,name="Esportes",description="Produtos destinados a esportes "},
                    price = 329.90,
                    pictures = new List<Picture>(){
                        new Picture(){id = 1,path = "chuteira_nike.jpg"},
                        new Picture(){id = 2,path = "chuteira_nike2.png"}
                        }
                },
                new Product(){
                id=4,name="Bolsa Nike",description="Bolsa Nike",category =
                    new Category(){id=4,name="Moda",description="Produtos destinados a moda "},
                    price = 429.90,
                    pictures = new List<Picture>(){
                        new Picture(){id = 1,path = "bolsa_nike.jpg"},
                        new Picture(){id = 2,path = "bolsa_nike2.jpg"}
                        }
                }
            };
        }
    }
}