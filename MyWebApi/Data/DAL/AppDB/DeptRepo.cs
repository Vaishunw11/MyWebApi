using MyWebApi.BI.Mapping;
using MyWebApi.Core.Contract;
using MyWebApi.Entity;

namespace MyWebApi.Data.DAL.AppDB
{
    public class DeptRepository : IDeptRepo
    {
        private readonly ApplicationDBContext _context;
        private readonly Deptmapping _mapper;

        public DeptRepository(ApplicationDBContext context, Deptmapping mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddDept(Departments dept)
        {
            _context.departments.Add(dept);
            await _context.SaveChangesAsync();
            return dept.DepartmentID;
        }
       
        public async Task<int> UpdateDept(Departments dept)
        {
            return await _context.SaveChangesAsync();
        }

        public Task<IQueryable<Departments>> GetAllDept()
        {
            var active = _context.departments.Where(x => x.IsActive == true);
            return Task.FromResult(active);
        }

        public async Task<bool> DeleteDept(Departments dept)
        {
            dept.IsActive = false;
            _context.departments.Update(dept);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}




