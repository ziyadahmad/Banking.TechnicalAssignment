using System;
using AutoMapper;
using Banking.TechnicalAssignment.Api.Core;
using Banking.TechnicalAssignment.Api.Core.Domain;
using Banking.TechnicalAssignment.Api.Core.Dto;
using Banking.TechnicalAssignment.Api.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Banking.TechnicalAssignment.Api.Controllers
{
    [Route("api/v1/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public AccountController(ILogger<AccountController> logger, IAccountService accountService, ICustomerService customerService, IMapper mapper)
        {
            _logger = logger;
            _accountService = accountService;
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("opencurrent")]
        public ActionResult OpenCurrentAccount(AccountDto accountDto)
        {
            try
            {
                _accountService.CreateNewAccount(accountDto);
                return CreatedAtAction(nameof(GetAccount), new { id = accountDto.CustomerId }, "New account is created");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetAccount(int id)
        {
            try
            {
                var account = _accountService.GetAccount(id);

                if(account == null)
                {
                    return NotFound();
                }

                return Ok(account);                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("summary/{id}")]
        public ActionResult GetAccountSummary(int id)
        {
            try
            {
                var customer = _customerService.GetCustomerById(id);
                if (customer == null)
                {
                    return NotFound();
                }

                return Ok(_accountService.GetAccountSummary(customer)); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }
    }
}