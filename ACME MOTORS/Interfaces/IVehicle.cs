using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACME_MOTORS.Interfaces
{
    interface IVehicle
    {
         Guid Id { get; set; }
         int QuantityInStock { get; set; }
        String Model { get; set; }
        String Color { get; set; }
        String GetManufactureName();
        //enum getVehicleType()
      


    }
}
