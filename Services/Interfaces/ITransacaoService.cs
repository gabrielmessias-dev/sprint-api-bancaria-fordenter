using API_bancaria.DTOs.Transacoes;

namespace API_bancaria.Services.Interfaces;

public interface ITransacaoService
{
    Task DepositoAsync(CreateTransacaoDto dto);
    Task SaqueAsync(CreateTransacaoDto dto);
}