using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Banking.TechnicalAssignment.Api.Core.Dto
{    
    [DisplayName("customer")]
    public class CustomerDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}