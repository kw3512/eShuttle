using eShuttle.WebAPI.Domains;

namespace eShuttle.WebAPI.Features.Locations;

public static class DeleteLocation
{
  public static async Task<IResult> HandleAsync(int id, CancellationToken cancellationToken)
  {
    // call repository (pass cancellation token)
    // TODO: Replace with actual repository call
    // Check if location exists
    var locationExists = true; // Mock check

    if (!locationExists)
    {
      return Results.NotFound(new { message = $"Location with ID {id} not found." });
    }

    // Delete location
    // await repository.DeleteAsync(id, cancellationToken);

    // return response
    return Results.NoContent();
  }
}
