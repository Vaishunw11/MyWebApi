using Microsoft.AspNetCore.Mvc;
using MyWebApi.Core.Contract;
using MyWebApi.Core.DTO;
using MyWebApi.Core.entity;
using MyWebApi.Data.DAL.AppDB;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("SaveOrUpdateUsers")]
        public async Task<UserListResponse<UserDTO>> SaveOrUpdateParentMaterial([FromBody] UserDTO userdto)
        {
            return await _service.AddOrUpdateUsers(userdto.UserId, userdto);
        }

        [HttpGet("GetAllUsers")]
        public async Task<UserListResponse<List<UserDTO>>> GetAllUsers()
        {
            return await _service.GetAllUsers();
        }

        [HttpDelete("DeleteUser/{userId}")]
        public async Task<UserListResponse<bool>> DeleteUser(int userId)
        {
            return await _service.DeleteUser(userId);
        }
    }
}
   