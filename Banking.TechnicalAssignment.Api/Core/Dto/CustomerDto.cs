using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Banking.TechnicalAssignment.Api.Core.Dto
{    
    [DisplayName("customer")]
    public class CustomerDto
    {
        [BindRequired]
        public int CustomerId { get; set; }
        
        [BindRequired]
        public string Name { get; set; }
        
        [BindRequired]
        public string Surname { get; set; }
    }
}