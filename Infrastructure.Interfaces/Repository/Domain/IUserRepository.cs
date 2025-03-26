using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Interfaces.Repository.Domain.Standard;

namespace Infrastructure.Interfaces.Repository.Domain
{
    public interface IUserRepository : IDomainRepository<User>
    {
        Task<IEnumerable<User>> GetAllIncludingTaskAsync();
        Task<User> GetByIdIncludingTaskAsync(int id);
    }
}
