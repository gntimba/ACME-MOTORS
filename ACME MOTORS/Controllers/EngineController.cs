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
    public class EngineController : ControllerBase
    {
        private readonly AcmeMotorContext _context;

        public EngineController(AcmeMotorContext context)
        {
            _context = context;
        }

        // GET: api/Engine
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EngineModel>>> Getengines()
        {
            return await _context.engines.ToListAsync();
        }

        // GET: api/Engine/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EngineModel>> GetEngineModel(Guid id)
        {
            var engineModel = await _context.engines.FindAsync(id);

            if (engineModel == null)
            {
                return NotFound();
            }

            return engineModel;
        }

        // PUT: api/Engine/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEngineModel(Guid id, EngineModel engineModel)
        {
            if (id != engineModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(engineModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EngineModelExists(id))
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

        // POST: api/Engine
        [HttpPost]
        public async Task<ActionResult<EngineModel>> PostEngineModel(EngineModel engineModel)
        {
            //var engine = new EngineModel
            //{
            //    AmendedOn=DateTime.Now,
            //    CreatedOn=DateTime.Now,
            //    FuelType=engineModel.FuelType,
            //    ManufacturerId= engineModel.ManufacturerId,
            //    Mileage=engineModel.Mileage,
            //    Model=engineModel.Model,
            //    Size=engineModel.Size,
            //    Year=engineModel.Year
            //};
            _context.engines.Add(engineModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEngineModel", new { id = engineModel.Id }, engineModel);
        }

        // DELETE: api/Engine/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EngineModel>> DeleteEngineModel(Guid id)
        {
            var engineModel = await _context.engines.FindAsync(id);
            if (engineModel == null)
            {
                return NotFound();
            }

            _context.engines.Remove(engineModel);
            await _context.SaveChangesAsync();

            return engineModel;
        }

        private bool EngineModelExists(Guid id)
        {
            return _context.engines.Any(e => e.Id == id);
        }
    }
}
