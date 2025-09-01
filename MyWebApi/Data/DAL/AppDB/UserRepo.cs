using MyWebApi.BI.Mapping;
using MyWebApi.Core.Contract;
using MyWebApi.Core.entity;
using MyWebApi.BI.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MyWebApi.Data.DAL.AppDB
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly UserMapping _mapper;

        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<int> AddUsers(Users user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.UserId;
        }

        public async Task<int> UpdateUser(Users user)
        {
            _context.Users.Update(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Users>> GetAllUsers()
        {
            return await _context.Users.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<bool> DeleteUser(Users user)
        {
            user.IsActive = false;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

