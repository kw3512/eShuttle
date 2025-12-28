using eShuttle.WebAPI.Domains;
using eShuttle.WebAPI.Mappers;
using FluentValidation;

namespace eShuttle.WebAPI.Features.Locations;

public static class AddLocation
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

  public static async Task<IResult> HandleAsync(Request request, CancellationToken cancellationToken)
  {
    // validate request
    var validator = new Validator();
    var validationResult = await validator.ValidateAsync(request, cancellationToken);
    if (!validationResult.IsValid)
    {
      return Results.ValidationProblem(validationResult.ToDictionary());
    }

    // map request to domain
    var location = request.MapToLocation();

    // call repository (pass cancellation token)
    // TODO: Replace with actual repository call
    location.Id = new Random().Next(1, 1000);

    // map to response
    var response = location.MapToAddLocationResponse();

    // return response
    return Results.Created($"/locations/{response.Id}", response);
  }
}
