using MyWebApi.Core.entity;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace MyWebApi.Data.DAL.AppDB
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<Users> user { get; set; }
    }
}
