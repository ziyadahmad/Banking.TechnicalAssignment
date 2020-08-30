using Banking.TechnicalAssignment.Api.Core.Domain;
using Banking.TechnicalAssignment.Api.Core.Dto;

namespace Banking.TechnicalAssignment.Api.Core.Services
{
    public interface IAccountService
    {
        /// <summary>
        /// Creates new account
        /// </summary>
        /// <param name="accountDto">initial credit </param>
        /// <returns>account Id</returns>
        int CreateNewAccount(AccountDto accountDto);

        /// <summary>
        /// Get account information by id
        /// </summary>
        /// <param name="accountDto">account id </param>
        /// <returns>account details for provided account id</returns>
        Account GetAccount(int accountId);

        /// <summary>
        /// Get customer details, account and its transactions as summary
        /// </summary>
        /// <param name="accountDto">customer</param>
        /// <returns>account summary</returns>
        AccountSummary GetAccountSummary(Customer customer);
    }
}
