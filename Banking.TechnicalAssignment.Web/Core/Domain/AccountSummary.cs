using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.TechnicalAssignment.Web.Core.Domain
{
    public class AccountSummary
    {

        public CustomerViewModel Customer { get; set; }
        public AccountViewModel Account { get; set; }
        public IEnumerable<AccountTransactionViewModel> Transactions { get; set; }
    }
}
