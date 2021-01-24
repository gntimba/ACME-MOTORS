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
    public class CarController : ControllerBase
    {
        private readonly AcmeMotorContext _context;

        public CarController(AcmeMotorContext context)
        {
            _context = context;
        }

        // GET: api/Car
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarModel>>> Getcars()
        {
            return await _context.cars.ToListAsync();
        }

        // GET: api/Car/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarModel>> GetCarModel(Guid id)
        {
            var carModel = await _context.cars.FindAsync(id);

            if (carModel == null)
            {
                return NotFound();
            }

            return carModel;
        }

        // PUT: api/Car/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarModel(Guid id, CarModel carModel)
        {
            if (id != carModel.Id)
            {
                return BadRequest();
            }
            var car=new CarModel{
                Id=carModel.Id,
                ManufacturerId=carModel.ManufacturerId,
                Year=carModel.Year,
                QuantityInStock=carModel.QuantityInStock,
                Model=carModel.Model,
                EngineId=carModel.EngineId,
                HasRustDamage=carModel.HasRustDamage,
                Color=carModel.Color,
                CreatedOn=carModel.CreatedOn,
                AmendedOn=DateTime.UtcNow
            };

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Car
        [HttpPost]
        public async Task<ActionResult<CarModel>> PostCarModel(CarModel carModel)
        {
            _context.cars.Add(carModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarModel", new { id = carModel.Id }, carModel);
        }

        // DELETE: api/Car/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CarModel>> DeleteCarModel(Guid id)
        {
            var carModel = await _context.cars.FindAsync(id);
            if (carModel == null)
            {
                return NotFound();
            }

            _context.cars.Remove(carModel);
            await _context.SaveChangesAsync();

            return carModel;
        }

        private bool CarModelExists(Guid id)
        {
            return _context.cars.Any(e => e.Id == id);
        }
    }
}
