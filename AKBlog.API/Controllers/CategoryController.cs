using AKBlog.API.DTO;
using AKBlog.API.Validators;
using AKBlog.Core.Model;
using AKBlog.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKBlog.API.Controllers
{
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService ICategorytService, IMapper mapper)
        {
            this._mapper = mapper;
            this._categoryService = ICategorytService;
        }
        public ActionResult<IEnumerable<CategoryDTO>> GetAllCategorys()
        {
            var Categorys = _categoryService.GetAllWithCategory();
            var CategoryResources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(Categorys);

            return Ok(CategoryResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(int id)
        {
            var Category = await _categoryService.GetCategoryById(id);
            var CategoryResource = _mapper.Map<Category, CategoryDTO>(Category);

            return Ok(CategoryResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<CategoryDTO>> CreateCategory([FromBody] SaveCategoryDTO saveCategoryResource)
        {
            var validator = new SaveCategoryResourceValidator();
            var validationResult = await validator.ValidateAsync(saveCategoryResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var CategoryToCreate = _mapper.Map<SaveCategoryDTO, Category>(saveCategoryResource);

            var newCategory = await _categoryService.CreateCategory(CategoryToCreate);

            var Category = await _categoryService.GetCategoryById(newCategory.ID);

            var CategoryResource = _mapper.Map<Category, CategoryDTO>(Category);

            return Ok(CategoryResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDTO>> UpdateCategory(int id, [FromBody] SaveCategoryDTO saveCategoryResource)
        {
            var validator = new SaveCategoryResourceValidator();
            var validationResult = await validator.ValidateAsync(saveCategoryResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var CategoryToBeUpdated = await _categoryService.GetCategoryById(id);

            if (CategoryToBeUpdated == null)
                return NotFound();

            var Category = _mapper.Map<SaveCategoryDTO, Category>(saveCategoryResource);

            await _categoryService.UpdateCategory(Category);

            var updatedCategory = await _categoryService.GetCategoryById(id);

            var updatedCategoryResource = _mapper.Map<Category, CategoryDTO>(updatedCategory);

            return Ok(updatedCategoryResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var Category = await _categoryService.GetCategoryById(id);

            await _categoryService.DeleteCategory(Category);

            return NoContent();
        }
    }
}
