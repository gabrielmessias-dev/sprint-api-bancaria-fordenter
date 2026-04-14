using API_bancaria.DTOs.Transacoes;
using API_bancaria.Models;
using API_bancaria.Repositories.Interfaces;
using API_bancaria.Services.Interfaces;

public class TransacaoService : ITransacaoService
{
    private readonly IContaRepository _contaRepository;
    private readonly ITransacaoRepository _transacaoRepository;

    public TransacaoService(
        IContaRepository contaRepository,
        ITransacaoRepository transacaoRepository)
    {
        _contaRepository = contaRepository;
        _transacaoRepository = transacaoRepository;
    }

    public async Task DepositoAsync(CreateTransacaoDto dto)
    {
        var conta = await _contaRepository.ObterPorIdAsync(dto.ContaId);

        if (conta == null)
            throw new KeyNotFoundException("Conta não encontrada.");

        conta.Saldo += dto.Valor;

        var transacao = new Transacao
        {
            ContaId = conta.Id,
            Valor = dto.Valor,
            Tipo = TipoTransacao.Deposito
        };

        await _transacaoRepository.CriarAsync(transacao);
    }

    public async Task SaqueAsync(CreateTransacaoDto dto)
    {
        var conta = await _contaRepository.ObterPorIdAsync(dto.ContaId);

        if (conta == null)
            throw new KeyNotFoundException("Conta não encontrada.");

        if (conta.Saldo < dto.Valor)
            throw new Exception("Saldo insuficiente.");

        conta.Saldo -= dto.Valor;

        var transacao = new Transacao
        {
            ContaId = conta.Id,
            Valor = dto.Valor,
            Tipo = TipoTransacao.Saque
        };

        await _transacaoRepository.CriarAsync(transacao);
    }
}