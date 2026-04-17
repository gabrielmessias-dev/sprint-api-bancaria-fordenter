using API_bancaria.DTOs.Transacoes;
using API_bancaria.Models;

namespace API_bancaria.Services.Interfaces;

public interface ITransacaoService
{
    Task DepositoAsync(DepositoDto dto);
    Task SaqueAsync(SaqueDto dto);
    Task TransferenciaAsync(TransferenciaDto dto);
    Task<List<Transacao>> GetExtratoAsync(int contaId);
}