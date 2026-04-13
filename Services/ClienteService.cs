using API_bancaria.DTOs.Clientes;
using API_bancaria.Models;
using API_bancaria.Repositories.Interfaces;
using API_bancaria.Services.Interfaces;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _repository;

    public ClienteService(IClienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResponseClienteDto> CriarClienteAsync(CreateClienteDto dto)
    {
        var clienteExistente = await _repository.ObterPorCPFAsync(dto.CPF);

        if (clienteExistente != null)
            throw new Exception("CPF já cadastrado.");

        var cliente = new Cliente
        {
            Nome = dto.Nome,
            CPF = dto.CPF
        };

        var clienteCriado = await _repository.CriarAsync(cliente);

        return new ResponseClienteDto
        {
            Id = clienteCriado.Id,
            Nome = clienteCriado.Nome,
            CPF = clienteCriado.CPF
        };
    }

    public async Task<ClienteDetalheDto> ObterPorIdAsync(int id)
    {
        var cliente = await _repository.ObterComContasAsync(id);

        if (cliente == null)
            throw new KeyNotFoundException("Cliente não encontrado.");

        return new ClienteDetalheDto
        {
            Id = cliente.Id,
            Nome = cliente.Nome,
            CPF = cliente.CPF,
            Contas = cliente.Contas.Select(c => new ContaDto
            {
                Id = c.Id,
                Numero = c.Numero,
                Saldo = c.Saldo
            }).ToList()
        };
    }

    public async Task<List<ResponseClienteDto>> ObterTodosAsync()
    {
        var clientes = await _repository.ObterTodosAsync();

        return clientes.Select(c => new ResponseClienteDto
        {
            Id = c.Id,
            Nome = c.Nome,
            CPF = c.CPF
        }).ToList();
    }

    public async Task AtualizarAsync(int id, UpdateClienteDto dto)
    {
        var cliente = await _repository.ObterPorIdAsync(id);

        if (cliente == null)
            throw new KeyNotFoundException("Cliente não encontrado.");

        cliente.Nome = dto.Nome;

        await _repository.AtualizarAsync(cliente);
    }

    public async Task RemoverAsync(int id)
    {
        var cliente = await _repository.ObterComContasAsync(id);

        if (cliente == null)
            throw new KeyNotFoundException("Cliente não encontrado.");

        if (cliente.Contas.Any())
            throw new Exception("Cliente possui contas e não pode ser removido.");

        await _repository.RemoverAsync(cliente);
    }
}