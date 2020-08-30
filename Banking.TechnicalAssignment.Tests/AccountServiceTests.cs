using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;
using AutoMapper;
using Banking.TechnicalAssignment.Api.Core.Domain;
using Banking.TechnicalAssignment.Api.Core.Dto;
using Banking.TechnicalAssignment.Api.Core.Respositories;
using Banking.TechnicalAssignment.Api.Core.Services;
using Microsoft.AspNetCore.Http.Features;
using Moq;
using Xunit;
using FluentAssertions;

namespace Banking.TechnicalAssignment.Tests
{
    public class AccountServiceTests
    {
        private readonly Mock<IRepository<Customer>> _customerRepository;
        private readonly Mock<IRepository<Account>> _accountRepository;
        private readonly Mock<IRepository<AccountTransaction>> _transactionRepository;
        private readonly Mapper _mapper;

        public AccountServiceTests()
        {
            _customerRepository = new Mock<IRepository<Customer>>();
            _accountRepository = new Mock<IRepository<Account>>();
            _transactionRepository = new Mock<IRepository<AccountTransaction>>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfile())));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(-10)]
        [InlineData(double.MaxValue)]
        public void CreateNewAccount_BalanceIsNotZero_AccountIsCreatedAndTransactionIsAdded(double balance)
        {
            // arrange
            _customerRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Customer, bool>>>())).Returns(new Customer { CustomerId = 1 });
            _transactionRepository.Setup(x => x.Add(It.IsAny<AccountTransaction>())).Returns(1);
            _accountRepository.Setup(x => x.Add(It.IsAny<Account>())).Returns(1);

            // act
            var service = new AccountService(_accountRepository.Object, _customerRepository.Object, _transactionRepository.Object, _mapper);
            var actual = service.CreateNewAccount(new AccountDto { CustomerId = 1, Balance = balance });

            // assert
            Assert.Equal(1, actual);
            _transactionRepository.Verify(x => x.Add(It.IsAny<AccountTransaction>()), Times.Once);
        }

        [Fact]
        public void CreateNewAccount_BalanceIsZero_AccountIsCreatedAndNoTransactionAdded()
        {
            // arrange
            double balance = 0;
            _customerRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Customer, bool>>>())).Returns(new Customer { CustomerId = 1 });
            _transactionRepository.Setup(x => x.Add(It.IsAny<AccountTransaction>())).Returns(1);
            _accountRepository.Setup(x => x.Add(It.IsAny<Account>())).Returns(1);

            // act
            var service = new AccountService(_accountRepository.Object, _customerRepository.Object, _transactionRepository.Object, _mapper);
            var actual = service.CreateNewAccount(new AccountDto { CustomerId = 1, Balance = balance });

            // assert
            Assert.Equal(1, actual);
            _transactionRepository.Verify(x => x.Add(It.IsAny<AccountTransaction>()), Times.Never);
            _accountRepository.Verify(x => x.Add(It.IsAny<Account>()), Times.Once);
        }

        [Fact]
        public void CreateNewAccount_AccountDetailsAreNull_ArgumentNullReferenceExceptionIsThrown()
        {
            // arrange            
            _customerRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Customer, bool>>>())).Returns(new Customer { CustomerId = 1 });
            _transactionRepository.Setup(x => x.Add(It.IsAny<AccountTransaction>())).Returns(1);
            _accountRepository.Setup(x => x.Add(It.IsAny<Account>())).Returns(1);

            // act
            var service = new AccountService(_accountRepository.Object, _customerRepository.Object, _transactionRepository.Object, _mapper);
            Action actual = () => service.CreateNewAccount(null);

            // assert
            actual.Should().Throw<ArgumentNullException>();

        }

        [Fact]
        public void CreateNewAccount_CustomerIdIsZero_ArgumentNullReferenceExceptionIsThrown()
        {
            // arrange            
            _customerRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Customer, bool>>>())).Returns(new Customer { CustomerId = 1 });
            _transactionRepository.Setup(x => x.Add(It.IsAny<AccountTransaction>())).Returns(1);
            _accountRepository.Setup(x => x.Add(It.IsAny<Account>())).Returns(1);

            // act
            var service = new AccountService(_accountRepository.Object, _customerRepository.Object, _transactionRepository.Object, _mapper);
            Action actual = () => service.CreateNewAccount(new AccountDto());            

            // assert
            actual.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void GetAccount_AccountIdIsValid_ReturnsAccountFromRepository()
        {
            // arrange            
            var expected = new Account { AccountId = 1, Balance = 10 };
            _accountRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Account, bool>>>())).Returns(expected);

            // act
            var service = new AccountService(_accountRepository.Object, _customerRepository.Object, _transactionRepository.Object, _mapper);
            var actual = service.GetAccount(1);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetAccountSummary_CustomerIsAvailable_ReturnsAccountSummary()
        {
            // arrange            
            var fakeDate = new DateTimeOffset(new DateTime(2020, 08, 30));
            var expected = new AccountSummary
            {
                Account = new AccountDto { CustomerId = 1, Balance = 10 },
                Customer = new CustomerDto { CustomerId = 1, Name = "James", Surname = "Bond" },
                Transactions = new[] { new AccountTransactionDto { Amount = 10, Date = fakeDate } }
            };

            _transactionRepository.Setup(x => x.GetAllById(It.IsAny<Expression<Func<AccountTransaction, bool>>>()))
                .Returns(new[] { new AccountTransaction { AccountId = 1, Amount = 10, Date = fakeDate } });

            _accountRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Account, bool>>>()))
                .Returns(new Account { AccountId = 1, Balance = 10 });

            // act
            var service = new AccountService(_accountRepository.Object, _customerRepository.Object, _transactionRepository.Object, _mapper);
            var actual = service.GetAccountSummary(new Customer { CustomerId = 1, Name = "James", Surname = "Bond" });

            // assert         
            expected.Should().BeEquivalentTo(actual);
            _transactionRepository.Verify(x => x.GetAllById(It.IsAny<Expression<Func<AccountTransaction, bool>>>()), Times.Once);
            _accountRepository.Verify(x => x.Get(It.IsAny<Expression<Func<Account, bool>>>()), Times.Once);
        }

        [Fact]
        public void GetAccountSummary_CustomerIsNullOrCustomerIdIsZero_ThrowsArgumentNullException()
        {
            // arrange            
            var fakeDate = new DateTimeOffset(new DateTime(2020, 08, 30));
            var expected = new AccountSummary
            {
                Account = new AccountDto { CustomerId = 1, Balance = 10 },
                Customer = new CustomerDto { CustomerId = 1, Name = "James", Surname = "Bond" },
                Transactions = new[] { new AccountTransactionDto { Amount = 10, Date = fakeDate } }
            };

            _transactionRepository.Setup(x => x.GetAllById(It.IsAny<Expression<Func<AccountTransaction, bool>>>()))
                .Returns(new[] { new AccountTransaction { AccountId = 1, Amount = 10, Date = fakeDate } });

            _accountRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Account, bool>>>()))
                .Returns(new Account { AccountId = 1, Balance = 10 });

            // act
            var service = new AccountService(_accountRepository.Object, _customerRepository.Object, _transactionRepository.Object, _mapper);
            Action actual = () => service.GetAccountSummary(new Customer());

            // assert         
            actual.Should().Throw<ArgumentNullException>();
            _transactionRepository.Verify(x => x.GetAllById(It.IsAny<Expression<Func<AccountTransaction, bool>>>()), Times.Never);
            _accountRepository.Verify(x => x.Get(It.IsAny<Expression<Func<Account, bool>>>()), Times.Never);
        }
    }
}
