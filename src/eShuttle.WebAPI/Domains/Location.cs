namespace eShuttle.WebAPI.Domains;

public class Location
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public string Path { get; set; } = string.Empty;
  public string? Description { get; set; }
  public bool IsActive { get; set; }
}
