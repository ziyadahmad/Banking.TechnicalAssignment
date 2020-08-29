using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banking.TechnicalAssignment.Web.Core.Domain;
using Banking.TechnicalAssignment.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace Banking.TechnicalAssignment.Web.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountApiClient _apiClient;

        public TransactionController(ILogger<AccountController> logger, IAccountApiClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTransaction(int accountId)
        {
            return View(new AccountTransactionViewModel { AccountId = accountId });
        }

        [HttpPost]
        public IActionResult AddTransaction(AccountTransactionViewModel accountViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var request = new RestRequest($"api/v1/transaction/deposit/{accountViewModel.AccountId}", Method.POST);
                    request.AddJsonBody(accountViewModel);
                    _apiClient.Execute<int>(request);
                    return RedirectToActionPermanent("Index", "Account", new { id = accountViewModel.AccountId });
                }

                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;                
            }            
        }
    }
}
