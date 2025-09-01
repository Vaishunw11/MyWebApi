using Authorization.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebApi.Data.DAL.AppDB;
using MyWebApi.DTO;
using MyWebApi.Entity;
using MyWebApi.Enum;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly DeptService _deptservice;

        public DepartmentController(ApplicationDBContext context, DeptService deptservice)
        {
            _context = context;
            _deptservice = deptservice;
        }

        [HttpPost]
        public IActionResult AddDepartment(Departments dept)
        {
            var userId = int.Parse(User.Claims.First(c => c.Type == "UserId").Value);
            dept.CreatedById = userId;   
            _context.Departments.Add(dept);
            _context.SaveChanges();
            return Ok(dept);
        }

        [HttpGet]
        public IActionResult GetDepartments()
        {
            var userId = int.Parse(User.Claims.First(c => c.Type == "UserId").Value);

            var depts = _context.Departments
                                .Where(d => d.CreatedById == userId)
                                .ToList();
            return Ok(depts);
        }
       
        [HttpDelete]
        public async Task<IActionResult> DeleteDept(int id)
        {
            var result = await _deptservice.DeleteDept(id);

            if (result.Result == EnumResponse.Success)
                return Ok(result);
            else
                return NotFound(result);
        }
    }
}