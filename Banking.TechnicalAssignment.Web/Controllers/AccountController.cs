using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Banking.TechnicalAssignment.Web.Models;
using RestSharp;
using Banking.TechnicalAssignment.Web.Services;
using Banking.TechnicalAssignment.Web.Core.Domain;

namespace Banking.TechnicalAssignment.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountApiClient _apiClient;

        public AccountController(ILogger<AccountController> logger, IAccountApiClient apiClient)
        {
            _logger = logger;
            _apiClient = apiClient;
        }

        public IActionResult Index(int id)
        {
            var request = new RestRequest($"api/v1/account/summary/{id}", Method.GET);
            var accountSummary = _apiClient.Execute<AccountSummary>(request);

            return View(accountSummary);
        }

        [HttpGet]
        public IActionResult AddAccount(int customerId)
        {
            return View(new AccountViewModel { CustomerId = customerId });
        }

        [HttpPost]
        public IActionResult AddAccount(AccountViewModel accountViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var request = new RestRequest($"api/v1/account/opencurrent", Method.POST);
                    request.AddJsonBody(accountViewModel);
                    _apiClient.Execute<int>(request);
                    return RedirectToActionPermanent("Index", new { id = accountViewModel.CustomerId });
                }
            }
            catch (Exception)
            {                
                throw;                
            }

            return Error();
        }

        [HttpGet]
        public IActionResult AddTransaction(int customerId)
        {
            return View(new AccountViewModel { CustomerId = customerId });
        }

        [HttpPost]
        public IActionResult AddTransaction(AccountViewModel accountViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var request = new RestRequest($"api/v1/account/opencurrent", Method.POST);
                    request.AddJsonBody(accountViewModel);
                    _apiClient.Execute<int>(request);
                    return RedirectToActionPermanent("Index", new { id = accountViewModel.CustomerId });
                }
            }
            catch (Exception)
            {
                throw;
            }

            return Error();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
