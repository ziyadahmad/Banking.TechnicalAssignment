using AutoMapper.Configuration.Conventions;
using Banking.TechnicalAssignment.Api.Core.Dto;

namespace Banking.TechnicalAssignment.Api.Core.Domain
{
    public class Account
    {
        [MapTo(nameof(AccountDto.CustomerId))]
        public int AccountId { get; set; }
                
        public double Balance { get; set; }
    }
}
