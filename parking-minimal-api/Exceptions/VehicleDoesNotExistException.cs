namespace ParkingMinimalApi.Exceptions
{
     public class VehicleDoesNotExistException : Exception
    {
        private int id { get; set; }

        public VehicleDoesNotExistException(int id) : base($"Vehicle with id {id} does not exist")
        {
            this.id = id;
        } 
        
    }
}