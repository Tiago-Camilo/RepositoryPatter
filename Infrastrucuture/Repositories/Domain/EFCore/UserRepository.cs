using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Interfaces.Repository.Domain;
using Infrastrucuture.DBConfiguration.EFCore;
using Infrastrucuture.Repositories.Standard.EFCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastrucuture.Repositories.Domain.EFCore
{
    public class UserRepository : DomainRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<User>> GetAllIncludingTaskAsync()
        {
            IQueryable<User> query = await Task.FromResult(GenerateQuery(filter: null,
                orderBy: null,
                includeProperties: nameof(User.TasksToDo)));

            return query.AsEnumerable();
        }

        public async Task<User> GetByIdIncludingTaskAsync(int id)
        {
            IQueryable<User> query = await Task.FromResult(GenerateQuery(filter: (user => user.Id == id), 
                orderBy: null, 
                includeProperties: nameof(User.TasksToDo)));

            return query.SingleOrDefault();
        }
    }
}
