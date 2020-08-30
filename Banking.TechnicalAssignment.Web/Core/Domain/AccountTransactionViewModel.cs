using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.TechnicalAssignment.Web.Core.Domain
{
    public class AccountTransactionViewModel
    {
        public int AccountId { get; set; }
        public double Amount { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
