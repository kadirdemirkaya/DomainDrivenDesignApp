namespace FlavorWorld.Contracts.Models;

public class ErrorResponse
{
    public List<ErrorModel> Errors { get; set; } = new();
}