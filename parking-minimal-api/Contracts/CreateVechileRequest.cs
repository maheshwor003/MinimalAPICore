  
  namespace ParkingMinimalApi.Contracts;
  
  public record CreateVechileRequest
  { 
  
      public string ? LicensePlate { get; set; }
        public string ? Make { get; set; }
        public string ? Model { get; set; }
        public string  ? Color { get; set; }
        public DateTime ParkingDate { get; set; }
  }