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
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService _commentsService;
        private readonly IMapper _mapper;

        public CommentsController(ICommentsService ICommentsService, IMapper mapper)
        {
            this._mapper = mapper;
            this._commentsService = ICommentsService;
        }
        public ActionResult<IEnumerable<CommentsDTO>> GetAllComments()
        {
            var Commentss = _commentsService.GetAllComments();
            var CommentsResources = _mapper.Map<IEnumerable<Comments>, IEnumerable<CommentsDTO>>(Commentss);

            return Ok(CommentsResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentsDTO>> GetCommentsById(int id)
        {
            var Comments = await _commentsService.GetCommentById(id);
            var CommentsResource = _mapper.Map<Comments, CommentsDTO>(Comments);

            return Ok(CommentsResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<CommentsDTO>> CreateComments([FromBody] SaveCommentsDTO saveCommentsResource)
        {
            var validator = new SaveCommentsResourceValidator();
            var validationResult = await validator.ValidateAsync(saveCommentsResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var CommentsToCreate = _mapper.Map<SaveCommentsDTO, Comments>(saveCommentsResource);

            var newComments = await _commentsService.CreateComment(CommentsToCreate);

            var Comments = await _commentsService.GetCommentById(newComments.ID);

            var CommentsResource = _mapper.Map<Comments, CommentsDTO>(Comments);

            return Ok(CommentsResource);
        }

    }
}
