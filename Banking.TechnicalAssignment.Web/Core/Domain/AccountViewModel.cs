using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Banking.TechnicalAssignment.Web.Core.Domain
{
    public class AccountViewModel
    {
        public int CustomerId { get; set; }        
        
        [DisplayName("Initial Credit")]        
        public double Balance { get; set; }
    }
}
