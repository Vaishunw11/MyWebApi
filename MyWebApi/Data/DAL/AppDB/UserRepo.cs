using Microsoft.EntityFrameworkCore;
using MyWebApi.BI.Mapping;
using MyWebApi.Core.Contract;
using MyWebApi.Core.entity;

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
            _context.user.Add(user);
            await _context.SaveChangesAsync();
            return user.UserId;
        }

        public async Task<int> UpdateUser(Users user)
        {
            _context.user.Update(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Users>> GetAllUsers()
        {
            return await _context.user.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<bool> DeleteUser(Users user)
        {
            user.IsActive = false;
            _context.user.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

