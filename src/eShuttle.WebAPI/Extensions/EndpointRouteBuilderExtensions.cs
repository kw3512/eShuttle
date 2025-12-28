using eShuttle.WebAPI.Features.Locations;

namespace eShuttle.WebAPI.Extensions;

public static class EndpointRouteBuilderExtensions
{
  public static void RegisterLocationsEndpoints(this IEndpointRouteBuilder app)
  {
    var locationsEndpoints = app.MapGroup("/locations");
    var locationWithLocationIdEndpoints = locationsEndpoints.MapGroup("/{id:int}");

    locationsEndpoints.MapGet("", GetLocations.HandleAsync);
    locationWithLocationIdEndpoints.MapGet("", GetLocationById.HandleAsync);
    locationsEndpoints.MapPost("", AddLocation.HandleAsync);
    locationWithLocationIdEndpoints.MapPut("", UpdateLocation.HandleAsync);
    locationWithLocationIdEndpoints.MapDelete("", DeleteLocation.HandleAsync);
  }
}
