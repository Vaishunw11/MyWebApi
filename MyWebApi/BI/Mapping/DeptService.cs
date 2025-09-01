using Authorization.BI.MAP;
using Authorization.Core.Contract;
using Authorization.DTO;
using Authorization.Entity;
using Authorization.Enum;
using Authorization.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.BI.Mapping;
using MyWebApi.Core.Contract;
using MyWebApi.Data.DAL.AppDB;
using MyWebApi.DTO;
using MyWebApi.Entity;
using MyWebApi.Enum;
using System.Collections.Generic;

namespace Authorization.Service
{
    public class DeptService : IDeptService
    {
        private readonly IDeptRepo _repository;
        private readonly Deptmapping _mapper;

        public DeptService(IDeptRepo repository, Deptmapping mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DeptListResponse<int>> AddorUpdateDept(int id, DeptDTO deptdto)
        {
            var response = new DeptListResponse<int>();
            try
            {
                if (deptdto.DepartmentID == 0)
                {
                    var entity = Deptmapping.MapToEntity(deptdto);
                    var newId = await _repository.AddDept(entity);

                    response.Result = newId > 0 ? EnumResponse.Success : EnumResponse.Failed;
                }
                else
                {
                    var allDepts = await _repository.GetAllDept();
                    var existing = await allDepts
                        .Where(x => x.DepartmentID == deptdto.DepartmentID)
                        .FirstOrDefaultAsync();

                    if (existing == null)
                    {
                        response.Result = EnumResponse.NotFound;
                        return response;
                    }
                    Deptmapping.UpdateEntity(existing, deptdto);
                    await _repository.UpdateDept(existing);
                    response.Result = EnumResponse.Success;
                }
            }
            catch (Exception ex)
            {
                response.Result = EnumResponse.Failed;
                Console.WriteLine("Exception: " + ex.Message);
            }
            return response;
        }

        public async Task<DeptListResponse<List<DeptDTO>>> GetAllDept()
        {
            var response = new DeptListResponse<List<DeptDTO>>();
            try
            {
                var data = await _repository.GetAllDept();
              
                var dtoList = data.Select(item => new DeptDTO
                {
                    DepartmentID = item.DepartmentID,
                    DepartmentName = item.DepartmentName,
                }).ToList();
                response.Result = data.Any() ? EnumResponse.Success : EnumResponse.NotFound;
                response.Data = dtoList;

            }
            catch (Exception ex)
            {
                response.Result = EnumResponse.Failed;
                Console.WriteLine("Inner Exception: " + ex.InnerException?.Message);
                Console.WriteLine("Exception: " + ex.Message);
            }
            return response;
        }

        public async Task<DeptListResponse<bool>> DeleteDept(int id)
        {
            var response = new DeptListResponse<bool>();
            try
            {
                var allDepts = await _repository.GetAllDept();
                var entity = allDepts.FirstOrDefault(x => x.DepartmentID == id);

                if (entity == null)
                {
                    response.Result = EnumResponse.NotFound;
                    return response;
                }
                entity.IsActive = false;
                await _repository.UpdateDept(entity);

                response.Result = EnumResponse.Success;
            }
            catch (Exception ex)
            {
                response.Result = EnumResponse.Failed;
                Console.WriteLine("Inner Exception: " + ex.InnerException?.Message);
                Console.WriteLine("Exception: " + ex.Message);
            }
            return response;
        }
        
        public async Task<DeptListResponse<Departments>> CreateDepartmentAsync(Departments department)
        {
            if (department == null)
                return DeptListResponse<Departments>.Fail("Department cannot be null");

            await _repository.AddDept(department);

            return DeptListResponse<Departments>.Success(department, "Department created successfully");
        }
    }
}


