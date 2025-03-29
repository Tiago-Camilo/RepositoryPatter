using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Services.Standard;
using Domain.Entities;

namespace Application.Interfaces.Services.Domain
{
    public interface IUserService : IServiceBase<User>
    {
        Task<IEnumerable<User>> GetAllIncludingTasksAsync();
        Task<User> GetByIdIncludingTasksAsync(int id);
    }
}
