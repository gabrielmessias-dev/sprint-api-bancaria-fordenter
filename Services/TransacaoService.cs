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

        if (dto.Valor <= 0)
            throw new Exception("Valor inválido.");

        conta.Saldo += dto.Valor;

        // Salvar alteração do saldo
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

    public async Task SaqueAsync(CreateTransacaoDto dto)
    {
        var conta = await _contaRepository.ObterPorIdAsync(dto.ContaId);

        if (conta == null)
            throw new KeyNotFoundException("Conta não encontrada.");

        if (dto.Valor <= 0)
            throw new Exception("Valor inválido.");

        if (conta.Saldo < dto.Valor)
            throw new Exception("Saldo insuficiente.");

        conta.Saldo -= dto.Valor;

        // Salvar alteração do saldo
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

    public async Task TransferenciaAsync(CreateTransacaoDto dto)
    {
        var contaOrigem = await _contaRepository.ObterPorIdAsync(dto.ContaId);

        if (contaOrigem == null)
            throw new KeyNotFoundException("Conta de origem não encontrada.");

        if (dto.Valor <= 0)
            throw new Exception("Valor inválido.");

        if (!dto.ContaDestinoId.HasValue)
            throw new Exception("Conta destino é obrigatória.");

        var contaDestino = await _contaRepository.ObterPorIdAsync(dto.ContaDestinoId.Value);

        if (contaDestino == null)
            throw new KeyNotFoundException("Conta destino não encontrada.");

        if (contaOrigem.Saldo < dto.Valor)
            throw new Exception("Saldo insuficiente.");

        // Débito na origem
        contaOrigem.Saldo -= dto.Valor;

        // Crédito no destino
        contaDestino.Saldo += dto.Valor;

        // Salvar ambas contas
        await _contaRepository.AtualizarAsync(contaOrigem);
        await _contaRepository.AtualizarAsync(contaDestino);

        // Transação de saída (origem)
        var transacaoSaida = new Transacao
        {
            ContaId = contaOrigem.Id,
            Valor = dto.Valor,
            Tipo = TipoTransacao.Transferencia,
            Data = DateTime.UtcNow
        };

        // Transação de entrada (destino)
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