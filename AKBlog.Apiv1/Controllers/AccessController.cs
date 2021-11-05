using AKBlog.Core.Interfaces;
using AKBlog.Core.Model;
using AKBlog.Core.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AKBlog.Apiv1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
public class AccessController : ControllerBase
    {
        //private readonly ILogger<AccessController> _logger;

        //public AccessController(ILogger<AccessController> logger)
        //{
        //    _logger = logger;
        //}
        private readonly IJwtAuth jwtAuth;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AccessController(IJwtAuth jwtAuth, IUserService IUserService, IMapper mapper)
        {
            this.jwtAuth = jwtAuth;
            this._userService = IUserService;
            this._mapper = mapper;
            
        }
        [AllowAnonymous]
        [HttpPost("Api/authentication")]
        public IActionResult Authentication(string UserName,string Password)
        {
            User userCredential = new User();
            userCredential.UserName = UserName;
            userCredential.Password = Password;
            var login = _userService.LoginUser(userCredential);
            if (login!=null)
            {
                var token = jwtAuth.Authentication(login);
                if (token == null)
                    return Unauthorized();
                return Ok(token);
            }
            else
                return Unauthorized();
            
        }
    }
}
