using Microsoft.AspNetCore.Mvc;
using MyWebApi.Core.Contract;
using MyWebApi.DTO;
using MyWebApi.Enum;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDeptService _deptservice;

        public DepartmentController(IDeptService deptservice)
        {
            _deptservice = deptservice;
        }

        [HttpPost("SaveOrUpdateDepartments")]
        public async Task<DeptListResponse<int>> SaveOrUpdateDepartment([FromBody] DeptDTO deptdto)
        {
            return await _deptservice.AddorUpdateDept(deptdto.DepartmentID, deptdto);
        }

        [HttpGet("GetAllDepartments")]
        public async Task<DeptListResponse<List<DeptDTO>>> GetAllDepartments()
        {
            return await _deptservice.GetAllDept();
        }

        [HttpDelete("DeleteDepartments{id}")]
        public async Task<DeptListResponse<bool>> DeleteDepartment(int id)
        {
            return await _deptservice.DeleteDept(id);
        }
    }
}
