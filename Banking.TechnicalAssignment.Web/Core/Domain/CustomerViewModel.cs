using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.TechnicalAssignment.Web.Core.Domain
{
    public class CustomerViewModel
    {
        [Required]
        [DisplayName("Customer Id")]
        public int CustomerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required] 
        public string Surname { get; set; }
    }
}
