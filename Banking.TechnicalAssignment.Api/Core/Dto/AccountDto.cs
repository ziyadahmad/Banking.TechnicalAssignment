using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper.Configuration.Conventions;
using Banking.TechnicalAssignment.Api.Core.Domain;

namespace Banking.TechnicalAssignment.Api.Core.Dto
{
    [DisplayName("account")]
    public class AccountDto
    {
        [JsonPropertyName("customerId")]
        [MapTo(nameof(Account.AccountId))]
        public int CustomerId { get; set; }

        public double Balance { get; set; }

        [JsonPropertyName("initialCredit")]
        private double InitialCredit { set { Balance = value; } }
    }

}
