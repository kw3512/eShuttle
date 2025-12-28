using eShuttle.WebAPI.Domains;
using eShuttle.WebAPI.Mappers;
using FluentValidation;

namespace eShuttle.WebAPI.Features.Locations;

public static class UpdateLocation
{
  public record Request(string Name, string Path, string? Description, bool IsActive);
  public record Response(int Id, string Name, string Path, string? Description, bool IsActive);

  public class Validator : AbstractValidator<Request>
  {
    public Validator()
    {
      RuleFor(x => x.Name).NotEmpty().Length(2, 50);
      RuleFor(x => x.Path).NotEmpty();
    }
  }

  public static async Task<IResult> HandleAsync(int id, Request request, CancellationToken cancellationToken)
  {
    // validate request
    var validator = new Validator();
    var validationResult = await validator.ValidateAsync(request, cancellationToken);
    if (!validationResult.IsValid)
    {
      return Results.ValidationProblem(validationResult.ToDictionary());
    }

    // call repository (pass cancellation token)
    // TODO: Replace with actual repository call
    // Check if location exists
    var locationExists = true; // Mock check

    if (!locationExists)
    {
      return Results.NotFound(new { message = $"Location with ID {id} not found." });
    }

    // map request to domain
    var location = request.MapToLocation(id);

    // Update location
    // await repository.UpdateAsync(location, cancellationToken);

    // map to response
    var response = location.MapToUpdateLocationResponse();

    // return response
    return Results.Ok(response);
  }
}
