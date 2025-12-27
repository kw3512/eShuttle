using eShuttle.WebAPI.Features.Locations;

namespace eShuttle.WebAPI.Extensions;

public static class EndpointRouteBuilderExtensions
{
  public static void RegisterLocationsEndpoints(this IEndpointRouteBuilder app)
  {
    var locationsEndpoints = app.MapGroup("/locations");


    locationsEndpoints.MapGet("", GetLocations.HandleAsync);
  }
}
