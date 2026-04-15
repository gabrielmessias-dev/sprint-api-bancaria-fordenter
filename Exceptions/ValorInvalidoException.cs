using System.Net;

namespace API_bancaria.Exceptions;

public class ValorInvalidoException : BaseException
{
    public ValorInvalidoException()
        : base("O valor deve ser maior que zero.", (int)HttpStatusCode.BadRequest)
    {
    }
}