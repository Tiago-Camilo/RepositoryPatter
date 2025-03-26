using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Interfaces.Repository.Domain.Standard;
using Microsoft.EntityFrameworkCore;

namespace Infrastrucuture.Repositories.Standard.EFCore
{
    public class DomainRepository<TEntity> : RepositoryAsync<TEntity>, IDomainRepository<TEntity> where TEntity : class, IIdentityEntity
    {
        protected DomainRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
