using API_bancaria.Data;
using API_bancaria.Models;
using API_bancaria.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Cliente> CriarAsync(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<Cliente?> ObterPorCPFAsync(string cpf)
    {
        return await _context.Clientes
            .FirstOrDefaultAsync(c => c.CPF == cpf);
    }

    public async Task<Cliente?> ObterPorIdAsync(int id)
    {
        return await _context.Clientes.FindAsync(id);
    }

    public async Task<Cliente?> ObterComContasAsync(int id)
    {
        return await _context.Clientes
            .Include(c => c.Contas)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<Cliente>> ObterTodosAsync()
    {
        return await _context.Clientes.ToListAsync();
    }

    public async Task AtualizarAsync(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverAsync(Cliente cliente)
    {
        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();
    }

    public async Task<Cliente?> ObterPorCpfAsync(string cpf)
    {
        return await _context.Clientes
            .FirstOrDefaultAsync(c => c.CPF == cpf);
    }
}