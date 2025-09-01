using MyWebApi.Core.Contract;
using MyWebApi.Core.DTO;
using MyWebApi.Enum;

namespace MyWebApi.BI.Mapping
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;   
        }

        public async Task<UserListResponse<UserDTO>> AddOrUpdateUsers(int id, UserDTO userdto)
        {
            var response = new UserListResponse<UserDTO>();
            try
            {
                if (userdto.UserId == 0)
                {
                    var entity = UserMapping.MapToEntity(userdto);
                    entity.IsActive = true;

                    var newId = await _repository.AddUsers(entity);
                    var dto = UserMapping.MapToDto(entity);

                    response.Data = dto;
                    response.Result = newId > 0 ? EnumResponse.Success : EnumResponse.Failed;
                }
                else
                {
                    var allUsers = await _repository.GetAllUsers();
                    var existing = allUsers.FirstOrDefault(x => x.UserId == userdto.UserId);

                    if (existing == null)
                    {
                        response.Result = EnumResponse.NotFound;
                        return response;
                    }
                    existing.Username = userdto.Username;
                    existing.Password = userdto.Password;
                    existing.Role = userdto.Role;

                    await _repository.UpdateUser(existing);

                    response.Data = UserMapping.MapToDto(existing);
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

        public async Task<UserListResponse<bool>> DeleteUser(int id)
        {
            var response = new UserListResponse<bool>();
            try
            {
                var allUsers = await _repository.GetAllUsers();
                var entity = allUsers.FirstOrDefault(x => x.UserId == id);
                if (entity == null)
                {
                    response.Result = EnumResponse.NotFound;
                    return response;
                }
                var deleted = await _repository.DeleteUser(entity);
                response.Data = deleted;
                response.Result = deleted ? EnumResponse.Success : EnumResponse.Failed;
            }
            catch
            {
                response.Result = EnumResponse.Failed;
            }
            return response;
        }

        public async Task<UserListResponse<List<UserDTO>>> GetAllUsers()
        {
            var response = new UserListResponse<List<UserDTO>>();
            try
            {
                var allUsers = await _repository.GetAllUsers();
                var dtoList = allUsers.Select(u => new UserDTO
                {
                    UserId = u.UserId,
                    Username = u.Username,
                    Password = u.Password,
                    Role = u.Role,
                    IsActive = u.IsActive
                }).ToList();

                response.Data = dtoList;
                response.Result = dtoList.Any() ? EnumResponse.Success : EnumResponse.NotFound;
            }
            catch
            {
                response.Result = EnumResponse.Failed;
            }
            return response;
        }

    }
}

