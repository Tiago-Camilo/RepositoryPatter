using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Interfaces.Repository.Standard;

namespace Infrastructure.Interfaces.Repository.Domain.Standard
{
    public interface IDomainRepository<TEntity> : IRepositoryAsync<TEntity> where TEntity : class, IIdentityEntity
    {
    }
}
