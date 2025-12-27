using System.Reflection.Metadata;
using eShuttle.WebAPI.Domains;
using FluentValidation;

namespace eShuttle.WebAPI.Features.Locations;

public static class GetLocations
{
  public record Request(bool isActive);
  public record Response(string allLocations);

  public class LocationValidator : AbstractValidator<Location> 
  {
    // Example validation rules
    //public LocationValidator()
    //{
    //  RuleFor(x => x.Id).NotNull();
    //  RuleFor(x => x.Name).Length(0, 10);
    //  RuleFor(x => x.Email).EmailAddress();
    //  RuleFor(x => x.Age).InclusiveBetween(18, 60);
    //}
    // docs: https://docs.fluentvalidation.net/en/latest/aspnet.html
  }

  public static async Task<Response> HandleAsync(Request request, CancellationToken cancellationToken)
  {
    // map request to model/domain obj.
    var location = new Location
    {
      IsActive = request.isActive
    };
    // validate model/domain obj.
    // call repository (pass cancellation token)
    // map to response
    // return response

    // Simulate fetching locations based on the isActive flag      
    var locations = location.IsActive ? "Active Locations List" : "All Locations List";
    return await Task.FromResult(new Response(locations));
  }
}
