using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banking.TechnicalAssignment.Api.Domain;

namespace Banking.TechnicalAssignment.Api.Services
{
    public interface IAccountService
    {
        bool CreateNewAccount(Account account);
        AccountSummary GetAccountSummary(int customerId);
    }
}
