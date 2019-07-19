using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ACME_MOTORS.Models
{
    public class TruckModel:BaseTable
    {

        public Guid EngineId { get; set; }

        public Guid ManufacturerId { get; set; }

        public String Model { get; set; }

        public String Year { get; set; }

        public String Color { get; set; }

        public int QuantityInStock { get; set; }
        public int NumberOfWheels { get; set; }
        public int MaximumLoad { get; set; }
        [NotMapped]
        public String Type { get; set; } = "Truck";
    }
}
