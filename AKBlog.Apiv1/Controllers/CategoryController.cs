using AKBlog.Apiv1.DTO;
using AKBlog.Apiv1.Validators;
using AKBlog.Core.Helper;
using AKBlog.Core.Model;
using AKBlog.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKBlog.Apiv1.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _Categoryervice;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService ICategoryervice, IMapper mapper)
        {
            this._mapper = mapper;
            this._Categoryervice = ICategoryervice;
        }
        [HttpGet("api/Category/GetAllCategory")]
        public ActionResult<IEnumerable<CategoryDTO>> GetAllCategory()
        {
            var Category = _Categoryervice.GetAllWithCategory();
            return Ok(Category);
        }
        [HttpPost("api/Category/CreateCategory")]
        public async Task<ActionResult<CategoryDTO>> CreateCategory([FromBody] SaveCategoryDTO saveCategoryResource)
        {
            Result result = new Result();
            try
            {
                var validator = new SaveCategoryResourceValidator();
                var validationResult = await validator.ValidateAsync(saveCategoryResource);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors);

                var CategoryToCreate = _mapper.Map<SaveCategoryDTO, Category>(saveCategoryResource);

                var newCategory = await _Categoryervice.CreateCategory(CategoryToCreate);

                var Category = await _Categoryervice.GetCategoryById(newCategory.ID);

                var CategoryResource = _mapper.Map<Category, CategoryDTO>(Category);
                result.IsSuccess = true;
                result.Message = "Category Successfull.";
                result.Status = 200;
                result.Data = Category.CategoryName;

                return Ok(result);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Category Create is Unsuccessful.";
                result.Status = 500;
                result.Data = ex;
                return Ok(result);
            }

        }

        [HttpPut("api/Category/UpdateCategory")]
        public async Task<ActionResult<CategoryDTO>> UpdateCategory(int id, [FromBody] SaveCategoryDTO saveCategoryResource)
        {
            Result result = new Result();
            try
            {
                saveCategoryResource.ID = id;
                var validator = new SaveCategoryResourceValidator();
                var validationResult = await validator.ValidateAsync(saveCategoryResource);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors);

                var CategoryToBeUpdated = await _Categoryervice.GetCategoryById(id);

                if (CategoryToBeUpdated == null)
                    return NotFound();

                var Category = _mapper.Map<SaveCategoryDTO, Category>(saveCategoryResource);

                await _Categoryervice.UpdateCategory(Category);

                var updatedCategory = await _Categoryervice.GetCategoryById(id);

                var updatedCategoryResource = _mapper.Map<Category, CategoryDTO>(updatedCategory);
                result.IsSuccess = true;
                result.Message = "Category Update is Successfull.";
                result.Status = 200;
                result.Data = "Updated Data";
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Category Update is Unsuccessful.";
                result.Status = 500;
                result.Data = ex.Message;
                return Ok(result);
            }

        }

        [HttpGet("api/Category/GetCategoryId")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(int id)
        {
            Result result = new Result();
            try
            {
                var Category = await _Categoryervice.GetCategoryById(id);
                var CategoryResource = _mapper.Map<Category, CategoryDTO>(Category);
                result.IsSuccess = true;
                result.Message = "Get Category with id= " + id + " is Successfull.";
                result.Status = 200;
                result.Data = CategoryResource;
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Get Category with id= " + id + "  is Unsuccessful.";
                result.Status = 500;
                result.Data = ex.Message;
                return Ok(result);
            }
        }

        [HttpDelete("api/Category/DeleteCategoryWithID")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            Result result = new Result();
            try
            {
                var res = await _Categoryervice.GetCategoryById(id);
                await _Categoryervice.DeleteCategory(res);

                result.IsSuccess = true;
                result.Message = "Category with id= " + id + "Deleted successfull";
                result.Status = 200;
                result.Data = "";
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                result.Status = 500;
                result.Data = null;
                return Ok(result);
            }
        }

        [HttpGet("api/Category/GetCategoryWithPaging")]
        public IActionResult GetCategoryWithPaging(int page = 1, int pageSize = 3)
        {
            Result result = new Result();
            try
            {
                PageParameters pageParameters = new PageParameters();
                pageParameters.PageNumber = page;
                pageParameters.PageSize = pageSize;
                var res = _Categoryervice.GetCategoryWithPaging(pageParameters);
                result.IsSuccess = true;
                result.Message = "Get Category Paging list successfull";
                result.Status = 200;
                result.Data = res;
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                result.Status = 500;
                result.Data = null;
                return Ok(result);
            }
        }
    }

}
