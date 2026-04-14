using API_bancaria.Models;

namespace API_bancaria.Repositories.Interfaces;

public interface IContaRepository
{
    Task<Conta> CriarAsync(Conta conta);
    Task<Conta?> ObterPorIdAsync(int id);
    Task<List<Conta>> ObterPorClienteAsync(int clienteId);
    Task RemoverAsync(Conta conta);
    Task AtualizarAsync(Conta conta);
}
