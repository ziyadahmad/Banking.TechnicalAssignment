using System;
using System.Collections.Generic;
using AutoMapper;
using Banking.TechnicalAssignment.Api.Core.Domain;
using Banking.TechnicalAssignment.Api.Core.Dto;
using Banking.TechnicalAssignment.Api.Core.Respositories;

namespace Banking.TechnicalAssignment.Api.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _repository;
        private readonly IMapper _mapper;

        public CustomerService(IRepository<Customer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void AddCustomer(int id, CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            customer.CustomerId = id;            
            _repository.Add(customer);
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
