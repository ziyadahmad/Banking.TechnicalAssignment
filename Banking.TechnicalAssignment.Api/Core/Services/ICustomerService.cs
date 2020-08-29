using System;
using System.Collections.Generic;
using Banking.TechnicalAssignment.Api.Core.Domain;
using Banking.TechnicalAssignment.Api.Core.Dto;

namespace Banking.TechnicalAssignment.Api.Core.Services
{
    public interface ICustomerService
    {
        void AddCustomer(int id, CustomerDto customerDto);

        Customer GetCustomerById(int id);

        IEnumerable<CustomerDto> GetAllCustomers();
    }
}
