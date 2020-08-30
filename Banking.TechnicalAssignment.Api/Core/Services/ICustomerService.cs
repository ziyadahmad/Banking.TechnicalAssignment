using System;
using System.Collections.Generic;
using Banking.TechnicalAssignment.Api.Core.Domain;
using Banking.TechnicalAssignment.Api.Core.Dto;

namespace Banking.TechnicalAssignment.Api.Core.Services
{
    public interface ICustomerService
    {
        /// <summary>
        /// Adds new customer
        /// </summary>
        /// <param name="customerDto">customer details</param>
        /// <returns>customer id</returns>
        int AddCustomer(CustomerDto customerDto);

        /// <summary>
        /// Get customer by customer id
        /// </summary>
        /// <param name="id">customer id</param>
        /// <returns>customer</returns>
        Customer GetCustomerById(int id);

        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns>List of all customers</returns>
        IEnumerable<CustomerDto> GetAllCustomers();
    }
}
