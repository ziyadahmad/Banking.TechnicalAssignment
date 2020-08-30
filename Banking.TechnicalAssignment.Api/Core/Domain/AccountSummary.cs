using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Banking.TechnicalAssignment.Api.Core.Dto;

namespace Banking.TechnicalAssignment.Api.Core.Domain
{
    public class AccountSummary
    {
        public CustomerDto Customer { get; set; }
        public AccountDto Account { get; set; }
        public IEnumerable<AccountTransactionDto> Transactions { get; set; }
    }
}
