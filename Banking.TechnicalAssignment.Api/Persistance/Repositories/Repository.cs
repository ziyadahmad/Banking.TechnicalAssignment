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
            _liteDatabase.GetCollection<TEntity>(typeof(TEntity).Name).Insert(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _liteDatabase.GetCollection<TEntity>(typeof(TEntity).Name).FindOne(predicate);
        }

        public IEnumerable<TEntity> GetAllById(Expression<Func<TEntity, bool>> predicate)
        {
            return _liteDatabase.GetCollection<TEntity>(typeof(TEntity).Name).Find(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _liteDatabase.GetCollection<TEntity>(typeof(TEntity).Name).FindAll();
        }
    }
}
