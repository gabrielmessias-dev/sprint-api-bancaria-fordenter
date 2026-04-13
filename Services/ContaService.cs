using API_bancaria.DTOs.Contas;
using API_bancaria.Models;
using API_bancaria.Repositories.Interfaces;
using API_bancaria.Services.Interfaces;

public class ContaService : IContaService
{
    private readonly IContaRepository _contaRepository;
    private readonly IClienteRepository _clienteRepository;

    public ContaService(
        IContaRepository contaRepository,
        IClienteRepository clienteRepository)
    {
        _contaRepository = contaRepository;
        _clienteRepository = clienteRepository;
    }

    public async Task<object> CriarContaAsync(CreateContaDto dto)
    {
        // REGRA: cliente deve existir
        var cliente = await _clienteRepository.ObterPorIdAsync(dto.ClienteId);

        if (cliente == null)
            throw new KeyNotFoundException("Cliente não encontrado.");

        var conta = new Conta
        {
            ClienteId = dto.ClienteId,
            Saldo = 0,
            Numero = GerarNumeroConta()
        };

        var contaCriada = await _contaRepository.CriarAsync(conta);

        return new
        {
            contaCriada.Id,
            contaCriada.Numero,
            contaCriada.Saldo,
            contaCriada.ClienteId
        };
    }

    private string GerarNumeroConta()
    {
        return DateTime.UtcNow.Ticks.ToString();
    }

    public async Task<Conta> ObterPorIdAsync(int id)
    {
        var conta = await _contaRepository.ObterPorIdAsync(id);

        if (conta == null)
            throw new KeyNotFoundException("Conta não encontrada.");

        return conta;
    }

    public async Task<List<Conta>> ObterPorClienteAsync(int clienteId)
    {
        return await _contaRepository.ObterPorClienteAsync(clienteId);
    }

    public async Task RemoverAsync(int id)
    {
        var conta = await _contaRepository.ObterPorIdAsync(id);

        if (conta == null)
            throw new KeyNotFoundException("Conta não encontrada.");

        if (conta.Saldo != 0)
            throw new Exception("Conta não pode ser removida pois possui saldo.");

        await _contaRepository.RemoverAsync(conta);
    }
}