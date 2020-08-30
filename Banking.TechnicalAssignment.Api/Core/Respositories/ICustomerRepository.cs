using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banking.TechnicalAssignment.Api.Core.Domain;

namespace Banking.TechnicalAssignment.Api.Core.Respositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        int NextCustomerId();
    }
}
