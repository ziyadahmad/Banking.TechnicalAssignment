using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using Banking.TechnicalAssignment.Api.Core.Domain;
using Banking.TechnicalAssignment.Api.Core.Dto;
using Banking.TechnicalAssignment.Api.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Banking.TechnicalAssignment.Api.Controllers
{
    [Route("api/v1/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly ITransactionService _transactionService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public TransactionController(ILogger<AccountController> logger, ITransactionService transactionService, IAccountService accountService, IMapper mapper)
        {
            _logger = logger;
            _transactionService = transactionService;
            _accountService = accountService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("deposit/{id}")]
        public IActionResult Deposit(int id, AccountTransactionDto transaction)
        {
            try
            {
                var account = _accountService.GetAccount(id);
                if (account == null)
                {
                    return NotFound();
                }
                var accountTransaction = _mapper.Map<AccountTransaction>(transaction);
                accountTransaction.AccountId = id;
                _transactionService.InsertTransaction(accountTransaction);                
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }            
        }
    }
}
