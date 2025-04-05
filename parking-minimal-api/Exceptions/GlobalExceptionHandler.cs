using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using  Microsoft.AspNetCore.Http;
using ParkingMinimalApi.Contracts;
namespace ParkingMinimalApi.Exceptions{
public class GlobalExceptionHandler : IExceptionHandler
 {
     private readonly ILogger<GlobalExceptionHandler> _logger;

     // Constructor to initialize the logger
     public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
     {
         _logger = logger;
     }

     // Method to handle exceptions asynchronously
     public async ValueTask<bool> TryHandleAsync(
         HttpContext httpContext,
         Exception exception,
         CancellationToken cancellationToken)
     {
         // Log the exception details
         _logger.LogError(exception, "An error occurred while processing your request");

         var errorResponse = new ErrorResponse
         {
             Message = exception.Message,
             Title = exception.GetType().Name
         };

         // Determine the status code based on the type of exception
         switch (exception)
         {
             case BadHttpRequestException:
                 errorResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                 break;

             case NoVehicleFoundException:
             case VehicleDoesNotExistException:
                 errorResponse.StatusCode = (int)HttpStatusCode.NotFound;
                 break;

             default:
                 errorResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                 break;
         }

         // Set the response status code
         httpContext.Response.StatusCode = errorResponse.StatusCode;

         // Write the error response as JSON
         await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);

         // Return true to indicate that the exception was handled
         return true;
     }
 }
}