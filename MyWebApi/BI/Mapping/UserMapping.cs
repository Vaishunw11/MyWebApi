using MyWebApi.Core.DTO;
using MyWebApi.Core.entity;

namespace MyWebApi.BI.Mapping
{
    public class UserMapping
    {
        public static Users MapToEntity(UserDTO dto)
        {
            return new Users
            {
                UserId = dto.UserId,
                Username = dto.Username,
                Password = dto.Password,
                Role = dto.Role,
                IsActive = dto.IsActive

            };
        }

        public static UserDTO MapToDto(Users entity)
        {
            return new UserDTO
            {
                UserId = entity.UserId,
                Username = entity.Username,
                Password = entity.Password,
                Role = entity.Role,
                IsActive = entity.IsActive

            };
        }
    }
}
