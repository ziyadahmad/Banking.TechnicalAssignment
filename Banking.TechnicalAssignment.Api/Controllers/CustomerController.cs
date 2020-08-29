using System;
using AutoMapper;
using Banking.TechnicalAssignment.Api.Core.Domain;
using Banking.TechnicalAssignment.Api.Core.Dto;
using Banking.TechnicalAssignment.Api.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Banking.TechnicalAssignment.Api.Controllers
{    
    [Route("api/v1/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService, IMapper mapper)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpPost]        
        public ActionResult AddCustomer(CustomerDto customer)
        {
            try
            {
                _customerService.AddCustomer(customer);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("getall")]
        public ActionResult GetAllCustomers()
        {
            try
            {
                return Ok(_customerService.GetAllCustomers());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
