using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;

namespace Banking.TechnicalAssignment.Web.Services
{
    public interface IAccountApiClient
    {
        TEntity Execute<TEntity>(IRestRequest request) where TEntity : new();
        IEnumerable<TEntity> GetData<TEntity>(IRestRequest request);
    }
}
