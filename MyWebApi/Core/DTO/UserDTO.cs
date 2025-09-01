using MyWebApi.Enum;
using System.ComponentModel.DataAnnotations;

namespace MyWebApi.Core.DTO
{
    public class UserDTO
    {
        [Key]

        public int UserId { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public string? Role { get; set; }

        public bool IsActive { get; set; } = true;
    }

    public class UserListResponse<T>
    {
        public EnumResponse Result { get; set; }

        public T? Data { get; set; }
    }
}
