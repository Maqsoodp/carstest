using System;
using Cars.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Cars.Domain
{
    public class CarsDbContext : DbContext
    {
        public CarsDbContext(DbContextOptions<CarsDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new OwnerConfiguration());
            builder.ApplyConfiguration(new CarConfiguration());
        }

        internal class OwnerConfiguration : IEntityTypeConfiguration<Owner>
        {
            public void Configure(EntityTypeBuilder<Owner> builder)
            {
                builder.ToTable("Owner");
                builder.HasKey(c => c.Id);
                builder.Property(c => c.Name).HasMaxLength(200);
                builder.HasMany(e => e.Cars).WithOne(o => o.Owner);
            }
        }

        internal class CarConfiguration : IEntityTypeConfiguration<Car>
        {
            public void Configure(EntityTypeBuilder<Car> builder)
            {
                builder.ToTable("Car");
                builder.HasKey(c => c.Id);
                builder.Property(c => c.Brand).HasMaxLength(200);
                builder.Property(c => c.Colour).HasMaxLength(200);
                builder.HasOne(o => o.Owner).WithMany(c=> c.Cars);
            }
        }
        
    }
}
