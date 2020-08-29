using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banking.TechnicalAssignment.Api.Core.Domain;

namespace Banking.TechnicalAssignment.Api.Core.Services
{
    public interface ITransactionService
    {
        void InsertTransaction(AccountTransaction transaction);
        IEnumerable<AccountTransaction> GetTransactions(int accountId);
    }
}
