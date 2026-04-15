using API_bancaria.DTOs.Transacoes;
using API_bancaria.Models;
using API_bancaria.Repositories.Interfaces;
using API_bancaria.Services.Interfaces;
using API_bancaria.Exceptions;

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

    public async Task DepositoAsync(DepositoDto dto)
    {
        if (dto.Valor <= 0)
            throw new ValorInvalidoException();

        var conta = await _contaRepository.ObterPorIdAsync(dto.ContaId);

        if (conta == null)
            throw new ContaNaoEncontradaException();

        conta.Saldo += dto.Valor;

        await _contaRepository.AtualizarAsync(conta);

        var transacao = new Transacao
        {
            ContaId = conta.Id,
            Valor = dto.Valor,
            Tipo = TipoTransacao.Deposito,
            Data = DateTime.UtcNow
        };

        await _transacaoRepository.CriarAsync(transacao);
    }

    public async Task SaqueAsync(SaqueDto dto)
    {
        if (dto.Valor <= 0)
            throw new ValorInvalidoException();

        var conta = await _contaRepository.ObterPorIdAsync(dto.ContaId);

        if (conta == null)
            throw new ContaNaoEncontradaException();

        if (conta.Saldo < dto.Valor)
            throw new SaldoInsuficienteException();

        conta.Saldo -= dto.Valor;

        await _contaRepository.AtualizarAsync(conta);

        var transacao = new Transacao
        {
            ContaId = conta.Id,
            Valor = dto.Valor,
            Tipo = TipoTransacao.Saque,
            Data = DateTime.UtcNow
        };

        await _transacaoRepository.CriarAsync(transacao);
    }

    public async Task TransferenciaAsync(TransferenciaDto dto)
    {
        if (dto.Valor <= 0)
            throw new ValorInvalidoException();

        if (dto.ContaDestinoId <= 0)
            throw new ContaDestinoObrigatoriaException();

        if (dto.ContaId == dto.ContaDestinoId)
            throw new TransferenciaInvalidaException();

        var contaOrigem = await _contaRepository.ObterPorIdAsync(dto.ContaId);

        if (contaOrigem == null)
            throw new ContaNaoEncontradaException();

        var contaDestino = await _contaRepository.ObterPorIdAsync(dto.ContaDestinoId);

        if (contaDestino == null)
            throw new ContaNaoEncontradaException();

        if (contaOrigem.Saldo < dto.Valor)
            throw new SaldoInsuficienteException();

        // Débito na origem
        contaOrigem.Saldo -= dto.Valor;

        // Crédito no destino
        contaDestino.Saldo += dto.Valor;

        await _contaRepository.AtualizarAsync(contaOrigem);
        await _contaRepository.AtualizarAsync(contaDestino);

        var transacaoSaida = new Transacao
        {
            ContaId = contaOrigem.Id,
            Valor = dto.Valor,
            Tipo = TipoTransacao.Transferencia,
            Data = DateTime.UtcNow
        };

        var transacaoEntrada = new Transacao
        {
            ContaId = contaDestino.Id,
            Valor = dto.Valor,
            Tipo = TipoTransacao.Deposito,
            Data = DateTime.UtcNow
        };

        await _transacaoRepository.CriarAsync(transacaoSaida);
        await _transacaoRepository.CriarAsync(transacaoEntrada);
    }
}