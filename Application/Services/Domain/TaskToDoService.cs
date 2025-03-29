using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Services.Domain;
using Application.Interfaces.Services.Standard;
using Application.Services.Standard;
using Domain.Entities;
using Infrastructure.Interfaces.Repository.Domain;

namespace Application.Services.Domain
{
    public class TaskToDoService : ServiceBase<TaskToDo>,
                               ITaskToDoService
    {
        private readonly ITaskToDoRepository _repository;

        public TaskToDoService(ITaskToDoRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TaskToDo>> GetAllIncludingUserAsync()
        {
            return await _repository.GetAllIncludingUserAsync();
        }

        public async Task<TaskToDo> GetByIdIncludingUserAsync(int id)
        {
            return await _repository.GetByIdIncludingUserAsync(id);
        }

        public async override Task UpdateAsync(TaskToDo obj)
        {
            var taskToDo = await GetByIdAsync(obj.Id);
            obj.Status = taskToDo.Status;
            await base.UpdateAsync(obj);
        }
        public async Task UpdateStatusAsync(int id, bool status)
        {
            var taskToDo = await GetByIdAsync(id);
            taskToDo.Status = status;
            await base.UpdateAsync(taskToDo);
        }
    }
}
