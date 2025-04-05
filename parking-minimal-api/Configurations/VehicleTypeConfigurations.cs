
using ParkingMinimalApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkingMinimalApi.Configurations
{
    public class BookTypeConfigurations : IEntityTypeConfiguration<VehicleModel>
    {
        public void Configure(EntityTypeBuilder<VehicleModel> builder)
        {
            // Configure the table name
            builder.ToTable("Vehicles");

            // Configure the primary key

            builder.Property(x => x.Id).HasColumnType("uuid").IsRequired();
            builder.Property(x => x.LicensePlate).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Make).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Model).IsRequired().HasMaxLength(500);
            builder.Property(x => x.ParkingDate).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Color).IsRequired().HasMaxLength(100);

            // Seed data
            builder.HasData(
      new VehicleModel
      {
          Id = Guid.NewGuid(), // Use a unique GUID or static value
          LicensePlate = "AB123CD",
          Make = "Toyota",
          Model = "Corolla",
          ParkingDate = new DateTime(2023, 01, 01, 10, 30, 00, DateTimeKind.Utc), // Static date-time value
          Color = "Blue"
      },
      new VehicleModel
      {
          Id = Guid.NewGuid(), // Another unique GUID or static value
          LicensePlate = "XY987ZT",
          Make = "Honda",
          Model = "Civic",
          ParkingDate = new DateTime(2023, 02, 01, 15, 45, 00, DateTimeKind.Utc), // Static date-time value
          Color = "Red"
      }
  );
        }
    }
}