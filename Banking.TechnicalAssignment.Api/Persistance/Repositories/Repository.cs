using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Banking.TechnicalAssignment.Api.Core.Respositories;
using LiteDB;

namespace Banking.TechnicalAssignment.Api.Persistance.Respositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ILiteDatabase _liteDatabase;

        public Repository(ILiteDbContext liteDbContext)
        {
            _liteDatabase = liteDbContext.Database;
        }

        public int Add(TEntity entity)
        {
            var bson = _liteDatabase.GetCollection<TEntity>(typeof(TEntity).Name).Insert(entity);
            return bson.RawValue;
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

        public bool Update(TEntity entity)
        {
            return _liteDatabase.GetCollection<TEntity>(typeof(TEntity).Name).Update(entity);
        }
    }
}
