using MyWebApi.DTO;
using MyWebApi.Entity;

namespace MyWebApi.Core.Contract
{
    public interface IDeptService
    {
        Task<DeptListResponse<int>> AddorUpdateDept(int id, DeptDTO deptdto);

        Task<DeptListResponse<List<DeptDTO>>> GetAllDept();

        Task<DeptListResponse<bool>> DeleteDept(int Id);

    }
}

