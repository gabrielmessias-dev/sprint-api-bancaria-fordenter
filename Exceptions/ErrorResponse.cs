namespace API_bancaria.Exceptions;

public class ErrorResponse
{
    public int StatusCode { get; set; }
    public string Mensagem { get; set; } = string.Empty;
    public string? Detalhes { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}