namespace ParkingLot.Contracts
{
    public class VehicleResponse
    {
        public Guid Id { get; set; }
        public string? LicensePlate { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? Color { get; set; }
        public DateTime ParkingDate { get; set; }
    }
}