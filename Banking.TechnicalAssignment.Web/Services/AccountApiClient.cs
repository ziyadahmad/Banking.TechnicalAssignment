using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace Banking.TechnicalAssignment.Web.Services
{
    public class AccountApiClient: IAccountApiClient
    {
        private readonly IRestClient _restClient;

        private readonly IConfiguration _configuration;

        public AccountApiClient(IRestClient restClient, IConfiguration configuration)
        {
            _configuration = configuration;
            _restClient = restClient;
            _restClient.BaseUrl = new Uri(_configuration["AccountApiEndpoint"]);
        }

        public TEntity Execute<TEntity>(IRestRequest request) where TEntity : new()
        {
            var response = _restClient.Execute<TEntity>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data;
            }
            else
            {                
                return default;
            }
        }

        public IEnumerable<TEntity> GetData<TEntity>(IRestRequest request)
        {            
            var response = _restClient.Execute<IEnumerable<TEntity>>(request);

            return response.Data;
        }
    }
}
