
using ParkingMinimalApi.Contracts;
using ParkingMinimalApi.Interfaces;

namespace ParkingMinimalApi.Endpoints
{
     public static class VehicleEndPoint
    {
        public static IEndpointRouteBuilder MapVehicleEndPoint(this IEndpointRouteBuilder app)
        {
            // Define the endpoints

            // Endpoint to add a new Vehicle
            app.MapPost("/Vehicles", async (CreateVechileRequest createVehicleRequest, IVehicleService VehicleService) =>
            {
                var result = await VehicleService.AddVehicleAsync(createVehicleRequest);
                return Results.Created($"/Vehicles/{result.Id}", result); 
            });
           

               // Endpoint to get all Vehicles
            app.MapGet("/Vehicles", async (IVehicleService VehicleService) =>
            {
                var result = await VehicleService.GetVehiclesAsync();
                return Results.Ok(result);
            });

            // Endpoint to get a Vehicle by ID
            app.MapGet("/Vehicles/{id:guid}", async (Guid id, IVehicleService VehicleService) =>
            {
                var result = await VehicleService.GetVehicleByIdAsync(id);
                return result != null ? Results.Ok(result) : Results.NotFound();
            });

        
            // Endpoint to update a Vehicle by ID
            app.MapPut("/Vehicles/{id:guid}", async (Guid id, UpdateVechileRequest updateVehicleRequest, IVehicleService VehicleService) =>
            {
                var result = await VehicleService.UpdateVehicleAsync(id, updateVehicleRequest);
                return result != null ? Results.Ok(result) : Results.NotFound();
            });

            // Endpoint to delete a Vehicle by ID
            app.MapDelete("/Vehicles/{id:guid}", async (Guid id, IVehicleService VehicleService) =>
            {
                var result = await VehicleService.DeleteVehicleAsync(id);
                return result ? Results.NoContent() : Results.NotFound();
            });

            return app;
        }
    }
}