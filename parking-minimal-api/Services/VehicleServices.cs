using ParkingMinimalApi.Models;
using ParkingMinimalApi.Contracts;
using ParkingMinimalApi.Interfaces;
using ParkingMinimalApi.AppContext;
using ParkingLot.Contracts;
using Microsoft.EntityFrameworkCore;


namespace ParkingMinimalApi.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly ParkingDBContext _context;
        private readonly ILogger<VehicleService> _logger;

        public VehicleService(ParkingDBContext context, ILogger<VehicleService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<VehicleResponse> AddVehicleAsync(CreateVechileRequest vehicle)
        {
            try
            {
                var vehicles = new VehicleModel
                {
                    LicensePlate = vehicle.LicensePlate,
                    Make = vehicle.Make,
                    Model = vehicle.Model,
                    Color = vehicle.Color,
                    ParkingDate = vehicle.ParkingDate
                };

                // Add the book to the database
                _context.Vehicles.Add(vehicles);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Book added successfully.");

                // Return the details of the created book
                return new VehicleResponse
                {

                    LicensePlate = vehicles.LicensePlate,
                    Make = vehicles.Make,
                    Model = vehicles.Model,
                    Color = vehicles.Color,
                    ParkingDate = vehicles.ParkingDate
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding book: {ex.Message}");
                throw;
            }
        }

        public async Task<VehicleResponse> GetVehicleByIdAsync(Guid id)
        {
            try
            {
                // Find the book by its ID
                var vehicles = await _context.Vehicles.FindAsync(id);
                if (vehicles == null)
                {
                    _logger.LogWarning($"vehicle with ID {id} not found.");
                    throw new KeyNotFoundException($"Vehicle with ID {id} not found.");
                }

                // Return the details of the book
                return new VehicleResponse
                {
                    Id = vehicles.Id,
                    LicensePlate = vehicles.LicensePlate,
                    Make = vehicles.Make,
                    Model = vehicles.Model,
                    Color = vehicles.Color,
                    ParkingDate = vehicles.ParkingDate
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving vehicles: {ex.Message}");
                throw;
            }
        }
        public async Task<IEnumerable<VehicleResponse>> GetVehiclesAsync()
        {
            try
            {
                // Get all books from the database
                var vehicles = await _context.Vehicles.ToListAsync();

                // Return the details of all books
                return vehicles.Select(vehicle => new VehicleResponse
                {
                    Id = vehicle.Id,
                    LicensePlate = vehicle.LicensePlate,
                    Make = vehicle.Make,
                    Model = vehicle.Model,
                    Color = vehicle.Color,
                    ParkingDate = vehicle.ParkingDate
                });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving vehicles: {ex.Message}");
                throw;
            }
        }
        public async Task<VehicleResponse> UpdateVehicleAsync(Guid id, UpdateVechileRequest vehicle)
        {
            try
            {
                // Find the existing book by its ID
                var existingVehicle = await _context.Vehicles.FindAsync(id);
                if (existingVehicle == null)
                {
                    _logger.LogWarning($"Vehicles with ID {id} not found.");
                     throw new KeyNotFoundException($"Vehicle with ID {id} not found.");
                }

                // Update the book details
                existingVehicle.LicensePlate = vehicle.LicensePlate;
                existingVehicle.Make = vehicle.Make;
                existingVehicle.Model = vehicle.Model;
                existingVehicle.Color = vehicle.Color;
                existingVehicle.ParkingDate = vehicle.ParkingDate;
            
                // Save the changes to the database
                await _context.SaveChangesAsync();
                _logger.LogInformation("Vehicle updated successfully.");

                // Return the details of the updated book
               // Return the details of the book
                return new VehicleResponse
                {
                    Id = existingVehicle.Id,
                    LicensePlate = existingVehicle.LicensePlate,
                    Make = existingVehicle.Make,
                    Model = existingVehicle.Model,
                    Color = existingVehicle.Color,
                    ParkingDate = existingVehicle.ParkingDate
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating Vechile: {ex.Message}");
                throw;
            }
        }
        public async Task<bool> DeleteVehicleAsync(Guid id)
        {
            try
            {
                // Find the book by its ID
                var book = await _context.Vehicles.FindAsync(id);
                if (book == null)
                {
                    _logger.LogWarning($"Vehicle with ID {id} not found.");
                    return false;
                }

                // Remove the book from the database
                _context.Vehicles.Remove(book);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Book with ID {id} deleted successfully.");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting book: {ex.Message}");
                throw;
            }
        }

    }
}
