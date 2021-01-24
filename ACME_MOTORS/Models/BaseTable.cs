using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ACME_MOTORS.Models
{
    public class BaseTable
    {
        [Key]
        public Guid Id { get; set; }
       
        public DateTime CreatedOn { get; set; }
     
        public DateTime AmendedOn { get; set; }
    }
}
