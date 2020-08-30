using Banking.TechnicalAssignment.Api.Core.Domain;
using Banking.TechnicalAssignment.Api.Core.Dto;

namespace Banking.TechnicalAssignment.Api.Core.Services
{
    public interface IAccountService
    {
        int CreateNewAccount(AccountDto accountDto);
        Account GetAccount(int accountId);
        AccountSummary GetAccountSummary(Customer customer);
    }
}
