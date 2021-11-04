using AKBlog.API.DTO;
using AKBlog.API.Validators;
using AKBlog.Core.Model;
using Microsoft.AspNetCore.Mvc;
using AKBlog.Core.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKBlog.API.Controllers
{
    public class TagsController : ControllerBase
    {
        private readonly ITagsService _tagsService;
        private readonly IMapper _mapper;

        public TagsController(ITagsService ITagsService, IMapper mapper)
        {
            this._mapper = mapper;
            this._tagsService = ITagsService;
        }
        public ActionResult<IEnumerable<TagsDTO>> GetAllTags()
        {
            var Tagss = _tagsService.GetAllTags();
            var TagsResources = _mapper.Map<IEnumerable<Tags>, IEnumerable<TagsDTO>>(Tagss);

            return Ok(TagsResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TagsDTO>> GetTagsById(int id)
        {
            var Tags = await _tagsService.GetTagById(id);
            var TagsResource = _mapper.Map<Tags, TagsDTO>(Tags);

            return Ok(TagsResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<TagsDTO>> CreateTags([FromBody] SaveTagsDTO saveTagsResource)
        {
            var validator = new SaveTagsResourceValidator();
            var validationResult = await validator.ValidateAsync(saveTagsResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var TagsToCreate = _mapper.Map<SaveTagsDTO, Tags>(saveTagsResource);

            var newTags = await _tagsService.CreateTag(TagsToCreate);

            var Tags = await _tagsService.GetTagById(newTags.ID);

            var TagsResource = _mapper.Map<Tags, TagsDTO>(Tags);

            return Ok(TagsResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TagsDTO>> UpdateTags(int id, [FromBody] SaveTagsDTO saveTagsResource)
        {
            var validator = new SaveTagsResourceValidator();
            var validationResult = await validator.ValidateAsync(saveTagsResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var TagsToBeUpdated = await _tagsService.GetTagById(id);

            if (TagsToBeUpdated == null)
                return NotFound();

            var Tags = _mapper.Map<SaveTagsDTO, Tags>(saveTagsResource);

            await _tagsService.UpdateTag(Tags);

            var updatedTags = await _tagsService.GetTagById(id);

            var updatedTagsResource = _mapper.Map<Tags, TagsDTO>(updatedTags);

            return Ok(updatedTagsResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTags(int id)
        {
            var Tags = await _tagsService.GetTagById(id);

            await _tagsService.DeleteTag(Tags);

            return NoContent();
        }

    }
}
