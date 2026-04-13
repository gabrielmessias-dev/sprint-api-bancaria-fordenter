using API_bancaria.DTOs.Clientes;
using API_bancaria.DTOs.Contas;
using API_bancaria.Models;

namespace API_bancaria.Services.Interfaces;

public interface IContaService
{
    Task<object> CriarContaAsync(CreateContaDto dto);
    Task<Conta> ObterPorIdAsync(int id);
    Task<List<Conta>> ObterPorClienteAsync(int clienteId);
    Task RemoverAsync(int id); // Só pode apagar se saldo == 0

}
