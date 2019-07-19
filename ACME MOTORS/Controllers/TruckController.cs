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
    public class TruckController : ControllerBase
    {
        private readonly AcmeMotorContext _context;

        public TruckController(AcmeMotorContext context)
        {
            _context = context;
        }

        // GET: api/Truck
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TruckModel>>> Gettrucks()
        {
            return await _context.trucks.ToListAsync();
        }

        // GET: api/Truck/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TruckModel>> GetTruckModel(Guid id)
        {
            var truckModel = await _context.trucks.FindAsync(id);

            if (truckModel == null)
            {
                return NotFound();
            }

            return truckModel;
        }

        // PUT: api/Truck/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTruckModel(Guid id, TruckModel truckModel)
        {
            if (id != truckModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(truckModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TruckModelExists(id))
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

        // POST: api/Truck
        [HttpPost]
        public async Task<ActionResult<TruckModel>> PostTruckModel(TruckModel truckModel)
        {
            _context.trucks.Add(truckModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTruckModel", new { id = truckModel.Id }, truckModel);
        }

        // DELETE: api/Truck/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TruckModel>> DeleteTruckModel(Guid id)
        {
            var truckModel = await _context.trucks.FindAsync(id);
            if (truckModel == null)
            {
                return NotFound();
            }

            _context.trucks.Remove(truckModel);
            await _context.SaveChangesAsync();

            return truckModel;
        }

        private bool TruckModelExists(Guid id)
        {
            return _context.trucks.Any(e => e.Id == id);
        }
    }
}
