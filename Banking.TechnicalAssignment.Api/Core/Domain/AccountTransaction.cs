using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration.Conventions;

namespace Banking.TechnicalAssignment.Api.Core.Domain
{
    public class AccountTransaction
    {
        private DateTimeOffset _date;
        public int AccountId { get; set; }

        public double Amount { get; set; }
        public DateTimeOffset Date
        {
            get{ return DateTimeOffset.Now; }
            set { _date = value; }
        }
    }
}
