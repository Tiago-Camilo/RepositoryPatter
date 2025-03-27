using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Interfaces.Repository.Domain;
using Infrastrucuture.Repositories.Standard.EFCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastrucuture.Repositories.Domain.EFCore
{
    public class TaskToDoRepository : DomainRepository<TaskToDo>, ITaskToDoRepository
    {
        protected TaskToDoRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<TaskToDo>> GetAllIncludingUserAsync()
        {
            IQueryable<TaskToDo> query = await Task.FromResult(GenerateQuery(null, null, nameof(TaskToDo.User)));
            return query.AsEnumerable();
        }

        public async Task<TaskToDo> GetByIdIncludingUserAsync(int id)
        {
            IQueryable<TaskToDo> query = await Task.FromResult(GenerateQuery((taskToDo => taskToDo.Id == id), null, nameof(TaskToDo.User)));
            return query.SingleOrDefault();
        }
    }
}
