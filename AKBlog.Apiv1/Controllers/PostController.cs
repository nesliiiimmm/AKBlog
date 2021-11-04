using AKBlog.Apiv1.DTO;
using AKBlog.Apiv1.Validators;
using AKBlog.Core.Helper;
using AKBlog.Core.Model;
using AKBlog.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKBlog.Apiv1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostController(IPostService IPostService, IMapper mapper)
        {
            this._mapper = mapper;
            this._postService = IPostService;
        }
        [HttpGet("api/Post/GetAllPosts")]
        public ActionResult<IEnumerable<PostsDTO>> GetAllPosts()
        {
            var Posts = _postService.GetAllPosts();
            return Ok(Posts);
        }
        [HttpPost("api/Post/CreatePost")]
        public async Task<ActionResult<PostsDTO>> CreatePost([FromBody] SavePostsDTO savePostResource)
        {
            Result result = new Result();
            try
            {
                var validator = new SavePostsResourceValidator();
                var validationResult = await validator.ValidateAsync(savePostResource);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors);

                var PostToCreate = _mapper.Map<SavePostsDTO, Posts>(savePostResource);

                var newPost = await _postService.CreatePost(PostToCreate);

                var Post = await _postService.GetPostById(newPost.ID);

                var PostResource = _mapper.Map<Posts, PostsDTO>(Post);
                result.IsSuccess = true;
                result.Message = "Post Successfull.";
                result.Status = 200;
                result.Data = Post.Description;

                return Ok(result);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Post Create is Unsuccessful.";
                result.Status = 500;
                result.Data = ex;
                return Ok(result);
            }

        }
        [HttpPut("api/Post/UpdatePost")]
        public async Task<ActionResult<PostsDTO>> UpdatePost(int id, [FromBody] SavePostsDTO savePostResource)
        {
            Result result = new Result();
            try
            {
                var validator = new SavePostsResourceValidator();
                var validationResult = await validator.ValidateAsync(savePostResource);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors);

                var PostToBeUpdated = await _postService.GetPostById(id);

                if (PostToBeUpdated == null)
                    return NotFound();

                var Post = _mapper.Map<SavePostsDTO, Posts>(savePostResource);

                await _postService.UpdatePost(Post);

                var updatedPost = await _postService.GetPostById(id);

                var updatedPostResource = _mapper.Map<Posts, PostsDTO>(updatedPost);
                result.IsSuccess = true;
                result.Message = "Post Update is Successfull.";
                result.Status = 200;
                result.Data = "Updated Data";
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Post Update is Unsuccessful.";
                result.Status = 500;
                result.Data = ex.Message;
                return Ok(result);
            }

        }
        [HttpGet("api/Post/GetPostId")]
        public async Task<ActionResult<PostsDTO>> GetPostById(int id)
        {
            Result result = new Result();
            try
            {
                var Post = await _postService.GetPostById(id);
                var PostResource = _mapper.Map<Posts, PostsDTO>(Post);
                result.IsSuccess = true;
                result.Message = "Get Post with id= " + id + " is Successfull.";
                result.Status = 200;
                result.Data = PostResource;
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "Get Post with id= " + id + "  is Unsuccessful.";
                result.Status = 500;
                result.Data = ex.Message;
                return Ok(result);
            }
        }
        [HttpGet("api/Post/GetBestReadCountView5")]
        public ActionResult<IEnumerable<PostsDTO>> GetBestRead5()
        {
            Result result = new Result();
            try
            {
                var Posts = _postService.GetBestRead5();
                result.IsSuccess = true;
                result.Message = "Get Best 5 Post list successfull";
                result.Status = 200;
                result.Data = Posts;
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
        [HttpDelete("api/Post/DeletePostWithID")]
        public async Task<IActionResult> DeletePost(int id)
        {
            Result result = new Result();
            try
            {
                var res = await _postService.GetPostById(id);
                await _postService.DeletePost(res);

                result.IsSuccess = true;
                result.Message = "Post with id= " + id + "Deleted successfull";
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

        [HttpGet("api/Post/GetPostWithPaging")]
        public IActionResult GetPostWithPaging(int page = 1, int pageSize = 5)
        {
            Result result = new Result();
            try
            {
                PageParameters pageParameters = new PageParameters();
                pageParameters.PageNumber = page;
                pageParameters.PageSize = pageSize;
                var res = _postService.GetPostsWithPaging(pageParameters);
                result.IsSuccess = true;
                result.Message = "Get Best 5 Post list successfull";
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
