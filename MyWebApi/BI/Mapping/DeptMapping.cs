using MyWebApi.DTO;
using MyWebApi.Entity;

namespace MyWebApi.BI.Mapping
{
    public class Deptmapping
    {
        public static Departments MapToEntity(DeptDTO dto)
        {
            return new Departments
            {
                DepartmentID = dto.DepartmentID,
                DepartmentName = dto.DepartmentName,
                IsActive = true
            };
        }

        public static DeptDTO MapToDto(Departments entity)
        {
            return new DeptDTO
            {
                DepartmentID = entity.DepartmentID,
                DepartmentName = entity.DepartmentName
            };
        }

        public static void UpdateEntity(Departments entity, DeptDTO dto)
        {
            entity.DepartmentName = dto.DepartmentName;
            entity.DepartmentID = dto.DepartmentID;
        }
    }
}