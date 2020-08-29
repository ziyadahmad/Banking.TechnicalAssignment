using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Banking.TechnicalAssignment.Api.Core.Respositories;
using LiteDB;

namespace Banking.TechnicalAssignment.Api.Persistance.Respositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ILiteDatabase _liteDatabase;

        public Repository(ILiteDbContext liteDbContext)
        {
            _liteDatabase = liteDbContext.Database;            
        }

        public void Add(TEntity entity)
        {            
            _liteDatabase.GetCollection<TEntity>(nameof(TEntity)).Insert(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _liteDatabase.GetCollection<TEntity>(nameof(TEntity)).FindOne(predicate);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _liteDatabase.GetCollection<TEntity>(nameof(TEntity)).Find(predicate);
        }
    }
}
