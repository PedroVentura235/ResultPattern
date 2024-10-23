using System.Net;

public record Error(HttpStatusCode StatusCode, string Code, string? Message = null);