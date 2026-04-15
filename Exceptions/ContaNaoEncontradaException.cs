using System.Net;

namespace API_bancaria.Exceptions;

public class ContaNaoEncontradaException : BaseException
{
    public ContaNaoEncontradaException()
        : base("Conta não encontrada.", (int)HttpStatusCode.NotFound)
    {
    }
}