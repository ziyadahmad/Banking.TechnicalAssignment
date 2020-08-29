using System.Collections.Generic;
using Banking.TechnicalAssignment.Api.Core.Domain;
using Banking.TechnicalAssignment.Api.Core.Respositories;

namespace Banking.TechnicalAssignment.Api.Core.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IRepository<AccountTransaction> _repository;
        private readonly IRepository<Account> _accountRepository;

        public TransactionService(IRepository<AccountTransaction> repository, IRepository<Account> accountRepository)
        {
            _repository = repository;
            _accountRepository = accountRepository;
        }

        public IEnumerable<AccountTransaction> GetTransactions(int accountId)
        {
            return _repository.GetAllById(x => x.AccountId == accountId);
        }

        public void InsertTransaction(AccountTransaction transaction)
        {
            var account = _accountRepository.Get(x => x.AccountId == transaction.AccountId);
            account.Balance += transaction.Amount;
            _repository.Add(transaction);
            _accountRepository.Update(account);
        }
    }
}