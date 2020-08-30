using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;
using Banking.TechnicalAssignment.Api.Core.Domain;
using Banking.TechnicalAssignment.Api.Core.Dto;
using Banking.TechnicalAssignment.Api.Core.Respositories;
using Banking.TechnicalAssignment.Api.Core.Services;
using Moq;
using Xunit;

namespace Banking.TechnicalAssignment.Tests
{
    public class TransactionServiceTests
    {
        private readonly Mock<IRepository<AccountTransaction>> _transactionRepository;
        private readonly Mock<IRepository<Account>> _accountRepository;

        private readonly Mapper _mapper;

        public TransactionServiceTests()
        {
            _transactionRepository = new Mock<IRepository<AccountTransaction>>();
            _accountRepository = new Mock<IRepository<Account>>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfile())));
        }

        [Fact]
        public void GetTransactions_WhenCalled_ReturnsAllTransactionsForProvidedAccountId()
        {
            // arrange
            var fakeDate = new DateTimeOffset(new DateTime(2020, 08, 30));
            var transactions = new[]
            {
                new AccountTransaction {AccountId =1, Amount=10,Date =fakeDate},
                new AccountTransaction {AccountId =2, Amount=15,Date =fakeDate}
            };

            _transactionRepository.Setup(x => x.GetAllById(It.IsAny<Expression<Func<AccountTransaction, bool>>>())).Returns(transactions);

            // act
            var service = new TransactionService(_transactionRepository.Object, _accountRepository.Object);
            var actual = service.GetTransactions(1);

            // assert            
            Assert.Equal(transactions, actual);
            _transactionRepository.Verify(x => x.GetAllById(It.IsAny<Expression<Func<AccountTransaction, bool>>>()), Times.Once);
        }

        [Fact]
        public void InsertTransactions_WhenCalled_AddTransactionsAndUpdateAccountBalance()
        {
            // arrange
            var fakeDate = new DateTimeOffset(new DateTime(2020, 08, 30));
            var account = new Account { AccountId = 1, Balance = 10 };
            var accountTransaction = new AccountTransaction { AccountId = 1, Amount = 10, Date = fakeDate };

            _accountRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Account, bool>>>())).Returns(account);
            _accountRepository.Setup(x => x.Update(It.IsAny<Account>())).Returns(true);
            _transactionRepository.Setup(x => x.Add(It.IsAny<AccountTransaction>())).Returns(1);

            // act
            var service = new TransactionService(_transactionRepository.Object, _accountRepository.Object);
            service.InsertTransaction(accountTransaction);
            
            // assert                        
            _transactionRepository.Verify(x => x.Add(It.IsAny<AccountTransaction>()), Times.Once);
            _accountRepository.Verify(x => x.Update(It.IsAny<Account>()), Times.Once);
        }
    }
}
