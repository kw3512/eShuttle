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
}
