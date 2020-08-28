using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banking.TechnicalAssignment.Api.Domain;
using Banking.TechnicalAssignment.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Banking.TechnicalAssignment.Api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;
        private readonly ICustomerService _customerService;

        public AccountController(ILogger<AccountController> logger, IAccountService accountService, ICustomerService customerService)
        {
            _logger = logger;
            _accountService = accountService;
            _customerService = customerService;
        }

        [HttpPost]
        [Route("{customerId}")]
        public ActionResult OpenCurrentAccount(int customerId, double initialCredit)
        {
            try
            {
                var customer = _customerService.GetCustomerById(customerId);
                if (customer == null)
                {
                    return NotFound();
                }

                var account = new Account
                {
                    AccountId = customerId,
                    CustomerId = customerId,
                    Balance = initialCredit
                };

                _accountService.CreateNewAccount(account);

                return StatusCode(201);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{customerId}")]
        public ActionResult GetAccountSummary(int customerId)
        {
            try
            {
                var customer = _customerService.GetCustomerById(customerId);
                if (customer == null)
                {
                    return NotFound();
                }

                _accountService.GetAccountSummary(customerId);

                return StatusCode(201);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
