namespace BookTracker.Private.Api.Contracts;

public class ErrorResponse
{
    public int Code { get; set; }
    public string Description { get; set; } = string.Empty;
    public string? Message { get; set; }
}