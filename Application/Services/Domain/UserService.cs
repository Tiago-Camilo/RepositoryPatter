using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Services.Domain;
using Application.Services.Standard;
using Domain.Entities;
using Infrastructure.Interfaces.Repository.Domain;

namespace Application.Services.Domain
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> GetAllIncludingTasksAsync()
        {
            return await _repository.GetAllIncludingTaskAsync();
        }

        public async Task<User> GetByIdIncludingTasksAsync(int id)
        {
            return await GetByIdIncludingTasksAsync(id);
        }
    }
}
