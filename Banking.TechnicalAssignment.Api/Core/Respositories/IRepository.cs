using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Banking.TechnicalAssignment.Api.Core.Respositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAllById(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
    }
}
