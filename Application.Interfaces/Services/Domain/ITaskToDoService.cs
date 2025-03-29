using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Services.Standard;
using Domain.Entities;

namespace Application.Interfaces.Services.Domain
{
     public interface ITaskToDoService : IServiceBase<TaskToDo>
    {
        Task UpdateStatusAsync(int id, bool status);
        Task<IEnumerable<TaskToDo>> GetAllIncludingUserAsync();
        Task<TaskToDo> GetByIdIncludingUserAsync(int id);
    }
}
