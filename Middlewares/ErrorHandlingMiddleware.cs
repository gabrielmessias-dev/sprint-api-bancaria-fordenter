using System.Net;
using System.Text.Json;
using API_bancaria.Exceptions;

namespace API_bancaria.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (BaseException ex)
        {
            await HandleException(context, ex.StatusCode, ex.Message);
        }
        catch (Exception ex)
        {
            await HandleException(context, (int)HttpStatusCode.InternalServerError, "Erro interno no servidor.", ex.Message);
        }
    }

    private static async Task HandleException(HttpContext context, int statusCode, string mensagem, string? detalhes = null)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var response = new ErrorResponse
        {
            StatusCode = statusCode,
            Mensagem = mensagem,
            Detalhes = detalhes
        };

        var json = JsonSerializer.Serialize(response);

        await context.Response.WriteAsync(json);
    }
}