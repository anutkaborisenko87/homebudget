using AutoMapper;
using HomeBudget.Models.Entities.Api;
using HomeBudget.Models.Entities.BLL;
using HomeBudget.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeBudget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
    
        public UserApiController(
            IUserService userService,
            IMapper mapper
        )
        {
            _userService = userService;
            _mapper = mapper;
        }
        
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<IEnumerable<GetUserResponse>>(_userService.GetAllUsers()));
        }
        
        [HttpGet]
        public IActionResult Get(int id)
        {
            var res = _userService.GetUser(id);
            if (res == null)
            {
                return NotFound(new { message = "User not found" });
            }
            return Ok(_mapper.Map<GetUserResponse>(_userService.GetUser(id)));
        }
        
        [HttpPost]
        public IActionResult Post(PostUserRequest user)
        {
            return Ok(_mapper.Map<GetUserResponse>(_userService.AddUser(_mapper.Map<UserBLL>(user))));
        }
        
        [HttpPut]
        public IActionResult Put(PutUserRequest user)
        {
            return Ok(_mapper.Map<GetUserResponse>(_userService.UpdateUser(_mapper.Map<UserBLL>(user))));
        }
        
        [HttpDelete]
        public IActionResult  Delete(int id)
        {
            var res = _userService.GetUser(id);
            if (res == null)
            {
                return NotFound(new { message = "User not found" });
            }
            _userService.DeleteUser(id);
            return Ok(_mapper.Map<GetUserResponse>(res));
        }
    }
}
