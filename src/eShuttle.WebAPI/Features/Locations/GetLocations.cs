using eShuttle.WebAPI.Domains;
using eShuttle.WebAPI.Mappers;
using FluentValidation;

namespace eShuttle.WebAPI.Features.Locations;

public static class GetLocations
{
  public record Response(int Id, string Name, string Path, string? Description, bool IsActive);

  public class Validator : AbstractValidator<Location> 
  {
    //// docs: https://docs.fluentvalidation.net/en/latest/aspnet.html
    //// Example validation rules
    //public Validator()
    //{
    //  RuleFor(x => x.Name).Length(2, 50);
    //  RuleFor(x => x.Path).NotNull().NotEmpty();
    //}   
  }

  public static async Task<IResult> HandleAsync(CancellationToken cancellationToken)
  {
    // map request to model  

    //// validate model    
    //Validator validator = new();
    //var validationResult = validator.Validate(location);
    //if (!validationResult.IsValid)
    //{
    //  return Results.ValidationProblem(validationResult.ToDictionary());
    //}

    // call repository (pass cancellation token)
    var locations = new List<Location>
    {
      new() { Id = 1, Name = "Location A", Path = "/location/a", Description = "Description A", IsActive = true },
      new() { Id = 2, Name = "Location B", Path = "/location/b", Description = "Description B", IsActive = false },
      new() { Id = 3, Name = "Location C", Path = "/location/c", Description = "Description C", IsActive = true }
    };

    // map to response    
    var response = locations.MapToReponse();

    // return response
    return Results.Ok(response);
  }
}
