using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banking.TechnicalAssignment.Api.Core.Domain;

namespace Banking.TechnicalAssignment.Api.Core.Services
{
    public interface ITransactionService
    {
        /// <summary>
        /// Inserts new transaction to an account
        /// </summary>
        /// <param name="transaction">transaction</param>
        void InsertTransaction(AccountTransaction transaction);
        
        /// <summary>
        /// Get transactions for account
        /// </summary>
        /// <param name="accountId">account id</param>
        /// <returns>list of transactions for the provided account</returns>
        IEnumerable<AccountTransaction> GetTransactions(int accountId);
    }
}
