using API_bancaria.DTOs.Clientes;
using API_bancaria.Models;

namespace API_bancaria.Services.Interfaces;

public interface IClienteService
{
    Task<ResponseClienteDto> CriarClienteAsync(CreateClienteDto dto);
    Task<ClienteDetalheDto> ObterPorIdAsync(int id);
    Task<List<ResponseClienteDto>> ObterTodosAsync();
    Task AtualizarAsync(int id, UpdateClienteDto dto);
    Task RemoverAsync(int id);
}
