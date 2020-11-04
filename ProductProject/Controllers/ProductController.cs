using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProductProject.Dto.Product;
using ProductProject.Model;
using ProductProject.Services.Interface;
using ProductProject.UnitOfWork.Interface;

namespace ProductProject.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork iUnitOfWork;
        private readonly IMapper iMapper;
        private readonly IImage iImage;

        public ProductController(IUnitOfWork iUnitOfWork, IMapper iMapper,IImage iImage)
        {
            this.iMapper = iMapper;
            this.iUnitOfWork = iUnitOfWork;
            this.iImage = iImage;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDto>> getAllProducts()
        {
            //var products = this.iUnitOfWork.productRepository.ListProduct();
            var products = this.iUnitOfWork.productMockRepository.ListProduct();

            return Ok(this.iMapper.Map<IEnumerable<ProductReadDto>>(products));
        }

        [HttpGet("{id}", Name = "getProductById")]
        public ActionResult<ProductReadDto> getProductById(int id)
        {
            var product = this.iUnitOfWork.productRepository.Find(id);

            if (product != null)
            {
                return Ok(this.iMapper.Map<ProductReadDto>(product));
            }

            return NoContent();
        }


        [HttpPost]
        public ActionResult<ProductReadDto> CreateProduct([FromForm] ProductCreateDto productCreateDto)
        {

            var productModel = this.iMapper.Map<Product>(productCreateDto);
            
            productModel.pictures = new List<Picture>();
            this.iImage.saveImage(productCreateDto.picturesForm).ForEach(x => productModel.pictures.Add(new Picture() { path = x }));

            this.iUnitOfWork.productRepository.Add(productModel);
            this.iUnitOfWork.Save();

            var productReadDto = this.iMapper.Map<ProductReadDto>(productModel);

            return CreatedAtRoute(nameof(getProductById), new { id = productReadDto.id }, productReadDto);
        }




        [HttpPut("{id}")]
        public ActionResult UpdateProduct([FromRoute]int id, [FromForm]ProductUpdateDto productUpdateDto)
        {
            var productModel = this.iUnitOfWork.productRepository.Find(id);

            if(productModel == null)
            {
                return NotFound();
            }


            this.iUnitOfWork.productRepository.RemovePictures(productModel);

            productModel.pictures = new List<Picture>();
            this.iImage.saveImage(productUpdateDto.picturesForm).ForEach(x => productModel.pictures.Add(new Picture() { path = x }));

            this.iMapper.Map(productUpdateDto, productModel);

            this.iUnitOfWork.productRepository.Edit(productModel);

            this.iUnitOfWork.Save();

            return NoContent();

        }


        [HttpPatch("{id}")]
        public ActionResult PartialProductUpdate(int id, JsonPatchDocument<ProductUpdateDto> patchDoc)
        {
            var productModel = this.iUnitOfWork.productRepository.Find(id);

            if (productModel == null)
            {
                return NotFound();
            }

            var productToPatch = this.iMapper.Map<ProductUpdateDto>(productModel);

            patchDoc.ApplyTo(productToPatch, ModelState);

            if (!TryValidateModel(productToPatch))
            {
                return ValidationProblem(ModelState);
            }
            this.iMapper.Map(productToPatch, productModel);

            this.iUnitOfWork.Save();

            return NoContent();

        }


        [HttpDelete("{id}")]
        public ActionResult deleteProduct(int id)
        {

            var productModel = this.iUnitOfWork.productRepository.Find(id);

            if(productModel == null){
                return NotFound();
            }

            this.iUnitOfWork.productRepository.Remove(productModel);

            this.iUnitOfWork.Save();
            
            return NoContent();
        }


    }
}