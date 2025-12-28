using eShuttle.WebAPI.Domains;
using eShuttle.WebAPI.Mappers;

namespace eShuttle.WebAPI.Features.Locations;

public static class GetLocationById
{
  public record Response(int Id, string Name, string Path, string? Description, bool IsActive);

  public static async Task<IResult> HandleAsync(int id, CancellationToken cancellationToken)
  {
    // call repository (pass cancellation token)
    // TODO: Replace with actual repository call
    var location = new Location
    {
      Id = id,
      Name = "Sample Location",
      Path = "/sample/path",
      Description = "Sample Description",
      IsActive = true
    };

    if (location == null)
    {
      return Results.NotFound(new { message = $"Location with ID {id} not found." });
    }

    // map to response
    var response = location.MapToGetLocationByIdResponse();

    // return response
    return Results.Ok(response);
  }
}
