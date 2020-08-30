using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banking.TechnicalAssignment.Api.Core.Domain;
using Banking.TechnicalAssignment.Api.Core.Respositories;
using Banking.TechnicalAssignment.Api.Persistance.Respositories;
using LiteDB;

namespace Banking.TechnicalAssignment.Api.Persistance.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ILiteDbContext liteDbContext) : base(liteDbContext)
        {
        }

        public int NextCustomerId()
        {
            int lastId = Database.GetCollection(nameof(Customer)).Count();
            lastId++;
            return lastId;
        }

        public LiteDatabase Database
        {
            get { return _liteDatabase as LiteDatabase; }
        }
    }
}
