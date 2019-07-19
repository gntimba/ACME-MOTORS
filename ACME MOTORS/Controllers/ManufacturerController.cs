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
    public class ManufacturerController : ControllerBase
    {
        private readonly AcmeMotorContext _context;

        public ManufacturerController(AcmeMotorContext context)
        {
            _context = context;
        }

        // GET: api/Manufacturer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManufacturerModel>>> Getmanufacturers()
        {
            return await _context.manufacturers.ToListAsync();
        }

        // GET: api/Manufacturer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManufacturerModel>> GetManufacturerModel(Guid id)
        {
            var manufacturerModel = await _context.manufacturers.FindAsync(id);

            if (manufacturerModel == null)
            {
                return NotFound();
            }

            return manufacturerModel;
        }

        // PUT: api/Manufacturer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManufacturerModel(Guid id, ManufacturerModel manufacturerModel)
        {
            if (id != manufacturerModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(manufacturerModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManufacturerModelExists(id))
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

        // POST: api/Manufacturer
        [HttpPost]
        public async Task<ActionResult> PostManufacturerModel([FromBody] ManufacturerModel manufacturerModel)
        {
            var manu = new ManufacturerModel
            {
                Name=manufacturerModel.Name,
                AmendedOn=DateTime.Now,
                CreatedOn=DateTime.Now
            };
            _context.manufacturers.Add(manu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManufacturerModel", new { id = manu.Id }, manu);
        }

        // DELETE: api/Manufacturer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ManufacturerModel>> DeleteManufacturerModel(Guid id)
        {
            var manufacturerModel = await _context.manufacturers.FindAsync(id);
            if (manufacturerModel == null)
            {
                return NotFound();
            }

            _context.manufacturers.Remove(manufacturerModel);
            await _context.SaveChangesAsync();

            return manufacturerModel;
        }

        private bool ManufacturerModelExists(Guid id)
        {
            return _context.manufacturers.Any(e => e.Id == id);
        }
    }
}
