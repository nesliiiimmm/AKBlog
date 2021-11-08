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
    public class TagsController : ControllerBase
    {
        private readonly ITagsService _TagService;
        private readonly IMapper _mapper;

        public TagsController(ITagsService ITagsService, IMapper mapper)
        {
            this._mapper = mapper;
            this._TagService = ITagsService;
        }
        [HttpGet("api/Tag/GetAllTags")]
        public ActionResult<IEnumerable<TagsDTO>> GetAllTags()
        {
            var Tags = _TagService.GetAllTags();
            return Ok(Tags);
        }
        [HttpPost("api/Tag/CreateTag")]
        public async Task<ActionResult<TagsDTO>> CreateTag([FromBody] SaveTagsDTO saveTagResource)
        {
            Result result = new Result();
            try
            {
                var validator = new SaveTagsResourceValidator();
                var validationResult = await validator.ValidateAsync(saveTagResource);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors);

                var TagToCreate = _mapper.Map<SaveTagsDTO, Tags>(saveTagResource);

                var newTag = await _TagService.CreateTag(TagToCreate);

                var Tag = await _TagService.GetTagById(newTag.ID);

                var TagResource = _mapper.Map<Tags, TagsDTO>(Tag);
                result.IsSuccess = true;
                result.Message = "Tag Successfull.";
                result.Status = 200;
                result.Data = Tag.Tag;

                return Ok(result);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Tag Create is Unsuccessful.";
                result.Status = 500;
                result.Data = ex;
                return Ok(result);
            }

        }
        [HttpPut("api/Tag/UpdateTag")]
        public async Task<ActionResult<TagsDTO>> UpdateTag(int id, [FromBody] SaveTagsDTO saveTagResource)
        {
            Result result = new Result();
            try
            {
                saveTagResource.ID = id;
                var validator = new SaveTagsResourceValidator();
                var validationResult = await validator.ValidateAsync(saveTagResource);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors);

                var TagToBeUpdated = await _TagService.GetTagById(id);

                if (TagToBeUpdated == null)
                    return NotFound();

                var Tag = _mapper.Map<SaveTagsDTO, Tags>(saveTagResource);

                await _TagService.UpdateTag(Tag);

                var updatedTag = await _TagService.GetTagById(id);

                var updatedTagResource = _mapper.Map<Tags, TagsDTO>(updatedTag);
                result.IsSuccess = true;
                result.Message = "Tag Update is Successfull.";
                result.Status = 200;
                result.Data = "Updated Data";
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Tag Update is Unsuccessful.";
                result.Status = 500;
                result.Data = ex.Message;
                return Ok(result);
            }

        }
        [HttpGet("api/Tag/GetTagId")]
        public async Task<ActionResult<TagsDTO>> GetTagById(int id)
        {
            Result result = new Result();
            try
            {
                var Tag = await _TagService.GetTagById(id);
                var TagResource = _mapper.Map<Tags, TagsDTO>(Tag);
                result.IsSuccess = true;
                result.Message = "Get Tag with id= " + id + " is Successfull.";
                result.Status = 200;
                result.Data = TagResource;
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Get Tag with id= " + id + "  is Unsuccessful.";
                result.Status = 500;
                result.Data = ex.Message;
                return Ok(result);
            }
        }
        [HttpDelete("api/Tag/DeleteTagWithID")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            Result result = new Result();
            try
            {
                var res = await _TagService.GetTagById(id);
                await _TagService.DeleteTag(res);

                result.IsSuccess = true;
                result.Message = "Tag with id= " + id + "Deleted successfull";
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

    }

}
