using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Interfaces.DBConfiguration;
using Infrastructure.Interfaces.Repository.Domain.Standard;

namespace Infrastructure.Repositories.Standard.Dapper
{
    public abstract class DomainRepository<TEntity> : RepositoryAsync<TEntity>,
        IDomainRepository<TEntity> where TEntity : class, IIdentityEntity
    {
        protected DomainRepository(IDatabaseFactory databaseOptions) : base(databaseOptions)
        {
        }

        protected DomainRepository(IDbConnection databaseConnection, IDbTransaction transaction = null) : base(databaseConnection, transaction)
        {
        }
    }
}
