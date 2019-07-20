using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ACME_MOTORS.Models;

namespace ACME_MOTORS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly AcmeMotorContext _context;

        public HomeController(AcmeMotorContext context)
        {
            _context = context;
        }
        // GET: api/Home
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var cars = ( from car in _context.cars
                               join manu in _context.manufacturers on car.ManufacturerId equals manu.Id
                               select new
                               {
                                   car.Id,
                                   car.QuantityInStock,
                                   car.Model,
                                   car.Year,
                                   car.Color,
                                   ManufacturerName = manu.Name,
                                   car.Type
                            
                               }
                    ).ToList();
                var trucks = (from truck in _context.trucks
                              join manu in _context.manufacturers on truck.ManufacturerId equals manu.Id
                              select new
                              {
                                  truck.Id,
                                  truck.QuantityInStock,
                                  truck.Model,
                                  truck.Year,
                                  truck.Color,
                                  ManufacturerName = manu.Name,
                                  truck.Type
                                ,
                              }
                            ).ToList();
                var motorbikes = (from motorbike in _context.motorbikes
                              join manu in _context.manufacturers on motorbike.ManufacturerId equals manu.Id
                              select new
                              {
                                  motorbike.Id,
                                  motorbike.QuantityInStock,
                                  motorbike.Model,
                                  motorbike.Year,
                                  motorbike.Color,
                                  ManufacturerName = manu.Name,
                                  motorbike.Type
                                 
                              }
                        ).ToList();
                var Vehicles = cars.Union(trucks).Union(motorbikes);
                var VehicleSorted = Vehicles.OrderBy(x => x.ManufacturerName);
                return Ok(VehicleSorted);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return StatusCode(500);
            }
        }

    }
}
