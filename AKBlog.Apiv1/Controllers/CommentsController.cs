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
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService _CommentService;
        private readonly IMapper _mapper;

        public CommentsController(ICommentsService ICommentService, IMapper mapper)
        {
            this._mapper = mapper;
            this._CommentService = ICommentService;
        }
        [HttpGet("api/Comment/GetAllComments")]
        public ActionResult<IEnumerable<CommentsDTO>> GetAllComments()
        {
            var Comments = _CommentService.GetAllComments();
            return Ok(Comments);
        }
        [HttpPost("api/Comment/CreateComment")]
        public async Task<ActionResult<CommentsDTO>> CreateComment([FromBody] SaveCommentsDTO saveCommentResource)
        {
            Result result = new Result();
            try
            {
                var validator = new SaveCommentsResourceValidator();
                var validationResult = await validator.ValidateAsync(saveCommentResource);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors);

                var CommentToCreate = _mapper.Map<SaveCommentsDTO, Comments>(saveCommentResource);

                var newComment = await _CommentService.CreateComment(CommentToCreate);

                var Comment = await _CommentService.GetCommentById(newComment.ID);

                var CommentResource = _mapper.Map<Comments, CommentsDTO>(Comment);
                result.IsSuccess = true;
                result.Message = "Comment Successfull.";
                result.Status = 200;
                result.Data = Comment.Comment;

                return Ok(result);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Comment Create is Unsuccessful.";
                result.Status = 500;
                result.Data = ex;
                return Ok(result);
            }

        }
        //[HttpPut("api/Comment/UpdateComment")]
        //public async Task<ActionResult<CommentsDTO>> UpdateComment(int id, [FromBody] SaveCommentsDTO saveCommentResource)
        //{
        //    Result result = new Result();
        //    try
        //    {
        //        saveCommentResource.ID = id;
        //        var validator = new SaveCommentsResourceValidator();
        //        var validationResult = await validator.ValidateAsync(saveCommentResource);

        //        if (!validationResult.IsValid)
        //            return BadRequest(validationResult.Errors);

        //        var CommentToBeUpdated = await _CommentService.GetCommentById(id);

        //        if (CommentToBeUpdated == null)
        //            return NotFound();

        //        var Comment = _mapper.Map<SaveCommentsDTO, Comments>(saveCommentResource);

        //        await _CommentService.UpdateComments(Comment);

        //        var updatedComment = await _CommentService.GetCommentById(id);

        //        var updatedCommentResource = _mapper.Map<Comments, CommentsDTO>(updatedComment);
        //        result.IsSuccess = true;
        //        result.Message = "Comment Update is Successfull.";
        //        result.Status = 200;
        //        result.Data = "Updated Data";
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        result.IsSuccess = false;
        //        result.Message = "Comment Update is Unsuccessful.";
        //        result.Status = 500;
        //        result.Data = ex.Message;
        //        return Ok(result);
        //    }

        //}
        
        [HttpGet("api/Comment/GetCommentId")]
        public async Task<ActionResult<CommentsDTO>> GetCommentById(int id)
        {
            Result result = new Result();
            try
            {
                var Comment = await _CommentService.GetCommentById(id);
                var CommentResource = _mapper.Map<Comments, CommentsDTO>(Comment);
                result.IsSuccess = true;
                result.Message = "Get Comment with id= " + id + " is Successfull.";
                result.Status = 200;
                result.Data = CommentResource;
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Get Comment with id= " + id + "  is Unsuccessful.";
                result.Status = 500;
                result.Data = ex.Message;
                return Ok(result);
            }
        }

        [HttpDelete("api/Comment/DeleteCommentWithID")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            Result result = new Result();
            try
            {
                var res = await _CommentService.GetCommentById(id);
                await _CommentService.DeleteComment(res);

                result.IsSuccess = true;
                result.Message = "Comment with id= " + id + "Deleted successfull";
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

        //[HttpGet("api/Comment/GetCommentWithPaging")]
        //public IActionResult GetCommentWithPaging(int page = 1, int pageSize = 5)
        //{
        //    Result result = new Result();
        //    try
        //    {
        //        PageParameters pageParameters = new PageParameters();
        //        pageParameters.PageNumber = page;
        //        pageParameters.PageSize = pageSize;
        //        var res = _CommentService.GetCommentsWithPaging(pageParameters);
        //        result.IsSuccess = true;
        //        result.Message = "Get Comment Paging list successfull";
        //        result.Status = 200;
        //        result.Data = res;
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        result.IsSuccess = false;
        //        result.Message = ex.Message;
        //        result.Status = 500;
        //        result.Data = null;
        //        return Ok(result);
        //    }

        //}

        //[HttpGet("api/Comment/GetCommentWithPagingandCategoryName")]
        //public IActionResult GetCommentWithPagingandCategoryName(string Name = "Genel", int page = 1, int pageSize = 5)
        //{
        //    Result result = new Result();
        //    try
        //    {
        //        PageParameters pageParameters = new PageParameters();
        //        pageParameters.PageNumber = page;
        //        pageParameters.PageSize = pageSize;
        //        var res = _CommentService.GetCommentsWithPagingandCategoryName(pageParameters, Name);
        //        result.IsSuccess = true;
        //        result.Message = "Get Comment Paging with Category name = " + Name + " successfull";
        //        result.Status = 200;
        //        result.Data = res;
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        result.IsSuccess = false;
        //        result.Message = ex.Message;
        //        result.Status = 500;
        //        result.Data = null;
        //        return Ok(result);
        //    }
        //}

    }


}
