using ParkingMinimalApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ParkingMinimalApi.AppContext
{

    public class ParkingDBContext(DbContextOptions<ParkingDBContext> options) : DbContext(options)
    {
        private const string DefaultSchema = "parkingapi";

        public DbSet<VehicleModel> Vehicles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(DefaultSchema);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ParkingDBContext).Assembly);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ParkingDBContext).Assembly);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

    }
}