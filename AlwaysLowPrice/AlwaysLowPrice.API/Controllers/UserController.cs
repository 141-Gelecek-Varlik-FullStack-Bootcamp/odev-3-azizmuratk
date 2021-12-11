using AlwaysLowPrice.Model;
using AlwaysLowPrice.Service.User;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlwaysLowPrice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService _userService, IMapper _mapper)
        {
            userService = _userService;
            mapper = _mapper;
        }

        // User Insert
        [HttpPost]
        public General<Model.User.User> Insert([FromBody] Model.User.User newUser)
        {
            return userService.Insert(newUser);
        }

        // User Login
        [HttpPost("login")]
        public General<Model.User.Login> Login([FromBody] Model.User.Login user)
        {
            return userService.Login(user);
        }

        // Update User
        [HttpPut("{id}")]
        public General<Model.User.User> Update(int id, [FromBody] Model.User.User user)
        {
            return userService.Update(id, user);
        }

        // Delete User
        [HttpDelete("{id}")]
        public General<Model.User.User> Delete(int id)
        {
            return userService.Delete(id);
        }
    }
}
