using System;
using System.Linq.Expressions;
using System.Transactions;
using AutoMapper;
using Banking.TechnicalAssignment.Api.Core.Domain;
using Banking.TechnicalAssignment.Api.Core.Dto;
using Banking.TechnicalAssignment.Api.Core.Respositories;
using Banking.TechnicalAssignment.Api.Core.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Http.Features;
using Moq;
using Xunit;

namespace Banking.TechnicalAssignment.Tests
{
    public class CustomerServiceTests
    {
        private readonly Mock<ICustomerRepository> _customerRepository;
        private readonly Mapper _mapper;

        public CustomerServiceTests()
        {
            _customerRepository = new Mock<ICustomerRepository>();
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfile())));
        }

        [Fact]
        public void AddCustomer_WhenCalled_CustomerIsAddedAndNewIdIsReturned()
        {
            // arrange
            int expected = 1;
            _customerRepository.Setup(x => x.Add(It.IsAny<Customer>())).Returns(expected);
            _customerRepository.Setup(x => x.NextCustomerId()).Returns(expected);

            // act
            var service = new CustomerService(_customerRepository.Object, _mapper);
            var actual = service.AddCustomer(new CustomerDto { Name = "Foo", Surname = "Bar" });

            // assert            
            Assert.Equal(expected, actual);
            _customerRepository.Verify(x => x.Add(It.IsAny<Customer>()), Times.Once);
        }

        [Fact]
        public void GetCustomerById_WhenCalled_ReturnsCustomerForMatchingId()
        {
            // arrange
            var expected = new Customer { CustomerId = 1, Name = "foo", Surname = "bar" };
            _customerRepository.Setup(x => x.Get(It.IsAny<Expression<Func<Customer, bool>>>())).Returns(expected);

            // act
            var service = new CustomerService(_customerRepository.Object, _mapper);
            var actual = service.GetCustomerById(1);

            // assert            
            Assert.Equal(expected, actual);
        }
    }
}
