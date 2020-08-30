using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.TechnicalAssignment.Api.Core.Dto
{
    public class AccountTransactionDto
    {
        public double Amount { get; set; }
        public DateTimeOffset Date { get; set; }        
    }
}
