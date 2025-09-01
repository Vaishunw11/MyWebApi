using MyWebApi.Entity;

namespace MyWebApi.Core.Contract
{
    public interface IDeptRepo
    {
        Task<int> AddDept(Departments dept);

        Task<int> UpdateDept(Departments dept);

        Task<IQueryable<Departments>> GetAllDept();

        Task<bool> DeleteDept(Departments dept);
    }
}
