using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACME_MOTORS.Models
{
    public class AcmeMotorContext:DbContext
    {
        public AcmeMotorContext(DbContextOptions<AcmeMotorContext> options) : base(options)
        {
           
        }
        public DbSet<CarModel> cars { get; set; }
        public DbSet<TruckModel> trucks { get; set; }
        public DbSet<MotorbikeModel> motorbikes { get; set; }
        public DbSet<EngineModel> engines { get; set; }
        public DbSet<ManufacturerModel> manufacturers { get; set; }
    }
}
