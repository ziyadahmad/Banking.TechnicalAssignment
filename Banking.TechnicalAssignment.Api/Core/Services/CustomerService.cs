using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using Banking.TechnicalAssignment.Api.Core.Domain;
using Banking.TechnicalAssignment.Api.Core.Dto;
using Banking.TechnicalAssignment.Api.Core.Respositories;

namespace Banking.TechnicalAssignment.Api.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public int AddCustomer(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            customer.CustomerId = _repository.NextCustomerId();
            _repository.Add(customer);
            return customer.CustomerId;
        }

        public Customer GetCustomerById(int id)
        {
            return _repository.Get(x => x.CustomerId == id);
        }

        public IEnumerable<CustomerDto> GetAllCustomers()
        {
            return _mapper.Map<IEnumerable<CustomerDto>>(_repository.GetAll());
        }
    }
}
