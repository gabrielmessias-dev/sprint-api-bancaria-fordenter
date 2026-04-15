using System.Net;

namespace API_bancaria.Exceptions;

public class ContaDestinoObrigatoriaException : BaseException
{
    public ContaDestinoObrigatoriaException()
        : base("Conta destino é obrigatória.", (int)HttpStatusCode.BadRequest)
    {
    }
}