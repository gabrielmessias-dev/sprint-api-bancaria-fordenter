using System.Net;

namespace API_bancaria.Exceptions;

public class TransferenciaInvalidaException : BaseException
{
    public TransferenciaInvalidaException()
        : base("Não é permitido transferir para a mesma conta.", (int)HttpStatusCode.BadRequest)
    {
    }
}