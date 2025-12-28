using eShuttle.WebAPI.Domains;
using eShuttle.WebAPI.Features.Locations;
using System.Linq;

namespace eShuttle.WebAPI.Mappers;

public static class LocationMapperExtensions
{
  public static IEnumerable<GetLocations.Response> MapToReponse(this IEnumerable<Location> locations)
  {
    return locations.Select(location => new GetLocations.Response(
      location.Id,
      location.Name,
      location.Path,
      location.Description,
      location.IsActive
    )).ToArray();
  }

  public static Location MapToLocation(this AddLocation.Request request)
  {
    return new Location
    {
      Name = request.Name,
      Path = request.Path,
      Description = request.Description,
      IsActive = request.IsActive
    };
  }

  public static AddLocation.Response MapToAddLocationResponse(this Location location)
  {
    return new AddLocation.Response(
      location.Id,
      location.Name,
      location.Path,
      location.Description,
      location.IsActive
    );
  }

  public static Location MapToLocation(this UpdateLocation.Request request, int id)
  {
    return new Location
    {
      Id = id,
      Name = request.Name,
      Path = request.Path,
      Description = request.Description,
      IsActive = request.IsActive
    };
  }

  public static UpdateLocation.Response MapToUpdateLocationResponse(this Location location)
  {
    return new UpdateLocation.Response(
      location.Id,
      location.Name,
      location.Path,
      location.Description,
      location.IsActive
    );
  }

  public static GetLocationById.Response MapToGetLocationByIdResponse(this Location location)
  {
    return new GetLocationById.Response(
      location.Id,
      location.Name,
      location.Path,
      location.Description,
      location.IsActive
    );
  }
}
