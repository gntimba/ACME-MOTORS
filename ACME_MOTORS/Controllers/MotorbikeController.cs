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
    public class MotorbikeController : ControllerBase
    {
        private readonly AcmeMotorContext _context;

        public MotorbikeController(AcmeMotorContext context)
        {
            _context = context;
        }

        // GET: api/Motorbike
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotorbikeModel>>> Getmotorbikes()
        {
            return await _context.motorbikes.ToListAsync();
        }

        // GET: api/Motorbike/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MotorbikeModel>> GetMotorbikeModel(Guid id)
        {
            var motorbikeModel = await _context.motorbikes.FindAsync(id);

            if (motorbikeModel == null)
            {
                return NotFound();
            }

            return motorbikeModel;
        }

        // PUT: api/Motorbike/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMotorbikeModel(Guid id, MotorbikeModel motorbikeModel)
        {
            if (id != motorbikeModel.Id)
            {
                return BadRequest();
            }
             var motorbike=new MotorbikeModel{
                Id=motorbikeModel.Id,
                ManufacturerId=motorbikeModel.ManufacturerId,
                Year=motorbikeModel.Year,
                QuantityInStock=motorbikeModel.QuantityInStock,
                Model=motorbikeModel.Model,
                EngineId=motorbikeModel.EngineId,
                HasWindVisor=motorbikeModel.HasWindVisor,
                Color=motorbikeModel.Color,
                CreatedOn=motorbikeModel.CreatedOn,
                AmendedOn=DateTime.UtcNow
                
            };

            _context.Entry(motorbike).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotorbikeModelExists(id))
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

        // POST: api/Motorbike
        [HttpPost]
        public async Task<ActionResult<MotorbikeModel>> PostMotorbikeModel(MotorbikeModel motorbikeModel)
        {
            _context.motorbikes.Add(motorbikeModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMotorbikeModel", new { id = motorbikeModel.Id }, motorbikeModel);
        }

        // DELETE: api/Motorbike/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MotorbikeModel>> DeleteMotorbikeModel(Guid id)
        {
            var motorbikeModel = await _context.motorbikes.FindAsync(id);
            if (motorbikeModel == null)
            {
                return NotFound();
            }

            _context.motorbikes.Remove(motorbikeModel);
            await _context.SaveChangesAsync();

            return motorbikeModel;
        }

        private bool MotorbikeModelExists(Guid id)
        {
            return _context.motorbikes.Any(e => e.Id == id);
        }
    }
}
