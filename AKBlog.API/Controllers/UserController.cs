using AKBlog.API.DTO;
using AKBlog.API.Validators;
using AKBlog.Core.Model;
using AKBlog.Core.Services;
using AKBlog.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKBlog.API.Controllers
{
    [Route("api /[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService IUserService, IMapper mapper)
        {
            this._mapper = mapper;
            this._userService = IUserService;
        }

        //[HttpGet("")]
        //public ActionResult<IEnumerable<UserDTO>> GetAllUsers()
        //{
        //    var Users =  _userService.GetAllUsers();
        //    return Ok(Users);
        //}
        //[HttpGet("{id}")]
        //public async Task<ActionResult<UserDTO>> GetUserById(int id)
        //{
        //    var Userswithid = await _userService.GetUserById(id);
        //    return Ok(Userswithid);
        //}

        public ActionResult<IEnumerable<UserDTO>> GetAllUsers()
        {
            var Users =  _userService.GetAllUsers();
            var UserResources = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(Users);

            return Ok(UserResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            var User = await _userService.GetUserById(id);
            var UserResource = _mapper.Map<User, UserDTO>(User);

            return Ok(UserResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody] SaveUserDTO saveUserResource)
        {
            var validator = new SaveUserResourceValidator();
            var validationResult = await validator.ValidateAsync(saveUserResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var UserToCreate = _mapper.Map<SaveUserDTO, User>(saveUserResource);

            var newUser = await _userService.CreateUser(UserToCreate);

            var User = await _userService.GetUserById(newUser.ID);

            var UserResource = _mapper.Map<User, UserDTO>(User);

            return Ok(UserResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> UpdateUser(int id, [FromBody] SaveUserDTO saveUserResource)
        {
            var validator = new SaveUserResourceValidator();
            var validationResult = await validator.ValidateAsync(saveUserResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var UserToBeUpdated = await _userService.GetUserById(id);

            if (UserToBeUpdated == null)
                return NotFound();

            var User = _mapper.Map<SaveUserDTO, User>(saveUserResource);

            await _userService.UpdateUser(User);

            var updatedUser = await _userService.GetUserById(id);

            var updatedUserResource = _mapper.Map<User, UserDTO>(updatedUser);

            return Ok(updatedUserResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var User = await _userService.GetUserById(id);

            await _userService.DeleteUser(User);

            return NoContent();
        }


    }
}
