using System;
using System.Collections.Generic;
using AutoMapper;
using Banking.TechnicalAssignment.Api.Core.Domain;
using Banking.TechnicalAssignment.Api.Core.Dto;
using Banking.TechnicalAssignment.Api.Core.Respositories;
using Microsoft.AspNetCore.Mvc;

namespace Banking.TechnicalAssignment.Api.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<AccountTransaction> _transactionRepository;
        private readonly IMapper _mapper;

        public AccountService(IRepository<Account> accountRepository, IRepository<Customer> customerRepository, IRepository<AccountTransaction> transactionRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _customerRepository = customerRepository;
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public int CreateNewAccount(AccountDto accountDto)
        {
            if (accountDto == null || accountDto.CustomerId < 1)
            {
                throw new ArgumentNullException("Null or account id is zero");
            }

            var customer = _customerRepository.Get(x => x.CustomerId == accountDto.CustomerId);
            var account = _mapper.Map<Account>(accountDto);
            var accountId = _accountRepository.Add(account);

            if (account.Balance != 0)
            {
                _transactionRepository.Add(new AccountTransaction
                {
                    AccountId = account.AccountId,
                    Amount = account.Balance,
                    Date = DateTimeOffset.Now
                });
            }

            return accountId;
        }

        public Account GetAccount(int accountId)
        {
            return _accountRepository.Get(x => x.AccountId == accountId);
        }

        public AccountSummary GetAccountSummary(Customer customer)
        {
            if (customer == null || customer.CustomerId < 1)
            {
                throw new ArgumentNullException("Null or customer id is zero");
            }

            return new AccountSummary
            {
                Customer = _mapper.Map<CustomerDto>(customer),
                Account = _mapper.Map<AccountDto>(_accountRepository.Get(x => x.AccountId == customer.CustomerId)),
                Transactions = _mapper.Map<IEnumerable<AccountTransactionDto>>(_transactionRepository.GetAllById(x => x.AccountId == customer.CustomerId))
            };
        }
    }
}