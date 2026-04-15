using System.Net;

namespace API_bancaria.Exceptions;

public class SaldoInsuficienteException : BaseException
{
    public SaldoInsuficienteException()
        : base("Saldo insuficiente para realizar a operação.", (int)HttpStatusCode.BadRequest)
    {
    }
}