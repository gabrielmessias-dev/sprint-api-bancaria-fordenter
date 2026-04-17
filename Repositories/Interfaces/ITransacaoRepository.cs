using API_bancaria.Models;

namespace API_bancaria.Repositories.Interfaces;

public interface ITransacaoRepository
{
    Task CriarAsync(Transacao transacao);
    Task<List<Transacao>> GetByContaIdAsync(int contaId);
}