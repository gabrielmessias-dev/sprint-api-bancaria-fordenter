using API_bancaria.Models;

namespace API_bancaria.Repositories.Interfaces;

public interface IClienteRepository
{
    Task<Cliente> CriarAsync(Cliente cliente);
    Task<Cliente?> ObterPorCPFAsync(string cpf);
    Task<Cliente?> ObterPorIdAsync(int id);
    Task<Cliente?> ObterComContasAsync(int id);
    Task<List<Cliente>> ObterTodosAsync();
    Task AtualizarAsync(Cliente cliente);
    Task RemoverAsync(Cliente cliente);
}
