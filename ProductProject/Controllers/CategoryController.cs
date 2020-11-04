using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProductProject.Dto.Category;
using ProductProject.Model;
using ProductProject.UnitOfWork.Interface;

namespace CategoryProject.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        
        private readonly IUnitOfWork iUnitOfWork;
        private readonly IMapper iMapper;

        public CategoryController(IUnitOfWork iUnitOfWork, IMapper iMapper)
        {
            this.iMapper = iMapper;
            this.iUnitOfWork = iUnitOfWork;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryReadDto>> getAllCategories()
        {
            var categorys = this.iUnitOfWork.categoryRepository.List();

            return Ok(this.iMapper.Map<IEnumerable<CategoryReadDto>>(categorys));
        }

        [HttpGet("{id}", Name = "getCategoryById")]
        public ActionResult<CategoryReadDto> getCategoryById(int id)
        {
            var category = this.iUnitOfWork.categoryRepository.Find(id);

            if (category != null)
            {
                return Ok(this.iMapper.Map<CategoryReadDto>(category));
            }

            return NoContent();
        }


        [HttpPost]
        public ActionResult<CategoryReadDto> CreateCategory(CategoryCreateDto categoryCreateDto)
        {
            var categoryModel = this.iMapper.Map<Category>(categoryCreateDto);
            this.iUnitOfWork.categoryRepository.Add(categoryModel);
            this.iUnitOfWork.Save();

            var categoryReadDto = this.iMapper.Map<CategoryReadDto>(categoryModel);

            return CreatedAtRoute(nameof(getCategoryById), new { id = categoryReadDto.id }, categoryReadDto);
        }



        [HttpPut("{id}")]
        public ActionResult UpdateCategory(int id, CategoryUpdateDto categoryUpdateDto)
        {
            var categoryModel = this.iUnitOfWork.categoryRepository.Find(id);

            if (categoryModel == null)
            {
                return NotFound();
            }

            this.iMapper.Map(categoryUpdateDto, categoryModel);

            this.iUnitOfWork.categoryRepository.Edit(categoryModel);

            this.iUnitOfWork.Save();

            return NoContent();

        }


        [HttpPatch("{id}")]
        public ActionResult PartialCategoryUpdate(int id, JsonPatchDocument<CategoryUpdateDto> patchDoc)
        {
            var categoryModel = this.iUnitOfWork.categoryRepository.Find(id);

            if (categoryModel == null)
            {
                return NotFound();
            }

            var categoryToPatch = this.iMapper.Map<CategoryUpdateDto>(categoryModel);

            patchDoc.ApplyTo(categoryToPatch, ModelState);

            if (!TryValidateModel(categoryToPatch))
            {
                return ValidationProblem(ModelState);
            }
            this.iMapper.Map(categoryToPatch, categoryModel);

            this.iUnitOfWork.Save();

            return NoContent();

        }


        [HttpDelete("{id}")]
        public ActionResult deleteCategory(int id)
        {

            var categoryModel = this.iUnitOfWork.categoryRepository.Find(id);

            if(categoryModel == null){
                return NotFound();
            }

            this.iUnitOfWork.categoryRepository.Remove(categoryModel);

            this.iUnitOfWork.Save();
            
            return NoContent();
        }


    }
}