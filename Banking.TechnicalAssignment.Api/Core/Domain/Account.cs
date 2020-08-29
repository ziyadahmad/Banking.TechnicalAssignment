using AutoMapper.Configuration.Conventions;

namespace Banking.TechnicalAssignment.Api.Core.Domain
{
    public class Account
    {        
        public int AccountId { get; set; }
        
        [MapTo(nameof(AccountTransaction.Amount))]
        public double Balance { get; set; }
    }
}
