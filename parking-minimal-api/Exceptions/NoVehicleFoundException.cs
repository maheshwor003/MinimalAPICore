
namespace ParkingMinimalApi.Exceptions
{
    
    public class NoVehicleFoundException : Exception
    {
        
        public NoVehicleFoundException() : base("No books found")
        {}
    }
}