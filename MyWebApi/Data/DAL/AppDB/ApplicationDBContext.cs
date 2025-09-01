using Microsoft.EntityFrameworkCore;
using MyWebApi.Core.entity;
using MyWebApi.Entity;
using System.Collections.Generic;

namespace MyWebApi.Data.DAL.AppDB
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Departments> Departments { get; set; }
    }
}
