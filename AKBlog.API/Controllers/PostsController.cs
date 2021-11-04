using AKBlog.API.DTO;
using AKBlog.API.Validators;
using AKBlog.Core.Model;
using AKBlog.Core.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKBlog.API.Controllers
{
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostsController(IPostService IPostService, IMapper mapper)
        {
            this._mapper = mapper;
            this._postService = IPostService;
        }
        public ActionResult<IEnumerable<PostsDTO>> GetAllPosts()
        {
            var Posts = _postService.GetAllPosts();
            var PostResources = _mapper.Map<IEnumerable<Posts>, IEnumerable<PostsDTO>>(Posts);

            return Ok(PostResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostsDTO>> GetPostById(int id)
        {
            var Post = await _postService.GetPostById(id);
            var PostResource = _mapper.Map<Posts, PostsDTO>(Post);

            return Ok(PostResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<PostsDTO>> CreatePost([FromBody] SavePostsDTO savePostResource)
        {
            var validator = new SavePostsResourceValidator();
            var validationResult = await validator.ValidateAsync(savePostResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var PostToCreate = _mapper.Map<SavePostsDTO, Posts>(savePostResource);

            var newPost = await _postService.CreatePost(PostToCreate);

            var Post = await _postService.GetPostById(newPost.ID);

            var PostResource = _mapper.Map<Posts, PostsDTO>(Post);

            return Ok(PostResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PostsDTO>> UpdatePost(int id, [FromBody] SavePostsDTO savePostResource)
        {
            var validator = new SavePostsResourceValidator();
            var validationResult = await validator.ValidateAsync(savePostResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var PostToBeUpdated = await _postService.GetPostById(id);

            if (PostToBeUpdated == null)
                return NotFound();

            var Post = _mapper.Map<SavePostsDTO, Posts>(savePostResource);

            await _postService.UpdatePost(Post);

            var updatedPost = await _postService.GetPostById(id);

            var updatedPostResource = _mapper.Map<Posts, PostsDTO>(updatedPost);

            return Ok(updatedPostResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var Post = await _postService.GetPostById(id);

            await _postService.DeletePost(Post);

            return NoContent();
        }
    }
}
