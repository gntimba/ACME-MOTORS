using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TruckModel>()
                .Property(b => b.AmendedOn)
                .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<TruckModel>()
                .Property(b => b.CreatedOn)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<CarModel>()
            .Property(b => b.AmendedOn)
            .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<CarModel>()
                .Property(b => b.CreatedOn)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<MotorbikeModel>()
            .Property(b => b.AmendedOn)
            .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<MotorbikeModel>()
                .Property(b => b.CreatedOn)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<EngineModel>()
            .Property(b => b.AmendedOn)
            .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<EngineModel>()
                .Property(b => b.CreatedOn)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<EngineModel>()
            .Property(b => b.AmendedOn)
            .HasDefaultValueSql("getdate()");
            modelBuilder.Entity<EngineModel>()
                .Property(b => b.CreatedOn)
                .HasDefaultValueSql("getdate()");
        }

    }
}
