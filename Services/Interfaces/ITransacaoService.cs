using API_bancaria.DTOs.Transacoes;

namespace API_bancaria.Services.Interfaces;

public interface ITransacaoService
{
    Task DepositoAsync(DepositoDto dto);
    Task SaqueAsync(SaqueDto dto);
    Task TransferenciaAsync(TransferenciaDto dto);
}