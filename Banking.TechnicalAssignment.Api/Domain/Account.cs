using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.TechnicalAssignment.Api.Domain
{
    public class Account
    {
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public double Balance { get; set; }
    }
}
