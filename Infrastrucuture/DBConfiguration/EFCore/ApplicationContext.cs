using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Configuration;
using Domain.Entities;
using Infrastructure.DBConfiguration;
namespace Infrastrucuture.DBConfiguration.EFCore
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(DatabaseConnection.ConnectionConfiguration
                                                    .GetConnectionString("DefaultConnection"));
            }
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<TaskToDo> TaskToDo { get; set; }
    }
}
