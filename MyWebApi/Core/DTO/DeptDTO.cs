using MyWebApi.Enum;
using System.ComponentModel.DataAnnotations;

namespace MyWebApi.DTO
{
    public class DeptDTO
    {
        [Key]
        public int DepartmentID { get; set; }

        public string? DepartmentName { get; set; }
    }

    public class DeptListResponse<T>
    {
        public EnumResponse Result { get; set; }

        public T? Data { get; set; }

        public string? Message { get; set; }

        public static DeptListResponse<T> Success(T data, string message = "Success")
        {
            return new DeptListResponse<T> { Result = EnumResponse.Success, Message = message, Data = default };
        }

        public static DeptListResponse<T> Fail(string message)
        {
            return new DeptListResponse<T> { Result = EnumResponse.Failed, Message = message, Data = default };
        }
    }
}


