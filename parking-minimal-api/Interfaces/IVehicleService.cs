using ParkingLot.Contracts;
using ParkingMinimalApi.Contracts;
using ParkingMinimalApi.Models;

namespace ParkingMinimalApi.Interfaces
{
    public interface IVehicleService
    {
        Task<VehicleResponse> AddVehicleAsync(CreateVechileRequest createVehicleRequest);
        Task<VehicleResponse> GetVehicleByIdAsync(Guid id);
        Task<IEnumerable<VehicleResponse>> GetVehiclesAsync();
        Task<VehicleResponse> UpdateVehicleAsync(Guid id, UpdateVechileRequest updateVehicleRequest);
        Task<bool> DeleteVehicleAsync(Guid id);
    }
}