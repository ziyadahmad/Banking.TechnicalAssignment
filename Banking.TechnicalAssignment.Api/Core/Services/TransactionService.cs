using System.Collections.Generic;
using Banking.TechnicalAssignment.Api.Core.Domain;
using Banking.TechnicalAssignment.Api.Core.Respositories;

namespace Banking.TechnicalAssignment.Api.Core.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IRepository<AccountTransaction> _repository;

        public TransactionService(IRepository<AccountTransaction> repository)
        {
            _repository = repository;
        }

        public IEnumerable<AccountTransaction> GetTransactions(int accountId)
        {
            return _repository.GetAll(x => x.AccountId == accountId);
        }

        public void InsertTransaction(AccountTransaction transaction)
        {
            _repository.Add(transaction);
        }
    }
}