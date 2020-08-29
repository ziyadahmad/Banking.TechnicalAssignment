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

        public void CreateNewAccount(AccountDto accountDto)
        {
            var customer = _customerRepository.Get(x => x.CustomerId == accountDto.CustomerId);
            var account = _mapper.Map(accountDto, new Account());
            var accountTransaction = _mapper.Map(account, new AccountTransaction());

            _accountRepository.Add(account);
            _transactionRepository.Add(accountTransaction);
        }

        public Account GetAccount(int accountId)
        {            
            return _accountRepository.Get(x => x.AccountId == accountId);
        }

        public AccountSummary GetAccountSummary(Customer customer)
        {
            return new AccountSummary
            {
                Customer = _mapper.Map<CustomerDto>(customer),
                Account = _mapper.Map<AccountDto>(_accountRepository.Get(x => x.AccountId == customer.CustomerId)),
                Transactions = _mapper.Map<IEnumerable<AccountTransactionDto>>(_transactionRepository.GetAllById(x => x.AccountId == customer.CustomerId))
            };                        
        }
    }
}