using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banking.TechnicalAssignment.Web.Core.Domain;
using Banking.TechnicalAssignment.Web.Services;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace Banking.TechnicalAssignment.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IAccountApiClient _accountApiClient;

        public CustomerController(IAccountApiClient accountApiClient)
        {
            _accountApiClient = accountApiClient;
        }

        public IActionResult Index()
        {
            var request = new RestRequest($"api/v1/customer/getall", Method.GET);
            var customers = _accountApiClient.GetData<CustomerViewModel>(request);

            return View(customers);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View(new CustomerViewModel());
        }

        [HttpPost]
        public IActionResult AddCustomer(CustomerViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                var request = new RestRequest($"api/v1/customer", Method.POST);
                request.AddJsonBody(customerViewModel);

                _accountApiClient.Execute<int>(request);
                return RedirectToActionPermanent("Index");
            }

            return View(customerViewModel);
        }
    }
}
