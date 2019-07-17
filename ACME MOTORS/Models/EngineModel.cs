using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACME_MOTORS.Models
{
    public class EngineModel:BaseTable
    {
        public Guid ManufacturerId { get; set; }
        public String Model { get; set; }
        public String Year { get; set; }
        public int Mileage { get; set; }
        public int Size { get; set; }
        public String FuelType { get; set; }
    }
}
